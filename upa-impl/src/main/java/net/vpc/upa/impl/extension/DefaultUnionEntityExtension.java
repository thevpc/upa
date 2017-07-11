package net.vpc.upa.impl.extension;

import net.vpc.upa.*;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.exceptions.UPAIllegalArgumentException;
import net.vpc.upa.expressions.*;
import net.vpc.upa.extensions.EntityExtensionDefinition;
import net.vpc.upa.extensions.UnionEntityExtensionDefinition;
import net.vpc.upa.extensions.UnionQueryInfo;
import net.vpc.upa.impl.DefaultEntity;
import net.vpc.upa.impl.util.filters.FieldFilters2;
import net.vpc.upa.persistence.EntityOperationManager;
import net.vpc.upa.persistence.UnionEntityExtension;
import net.vpc.upa.types.TypesFactory;

import java.util.ArrayList;
import java.util.List;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 8/30/12 12:48 AM
 */
public class DefaultUnionEntityExtension extends AbstractEntityExtension implements UnionEntityExtension {

    QueryStatement viewQuery;
    private List<Entity> updatableTables;
    private String discriminator;
    private List<String> viewFields;
    private String[][] fieldsMapping;

    @Override
    public void install(Entity entity, EntityOperationManager entityOperationManager, EntityExtensionDefinition extension) throws UPAException {
        super.install(entity, entityOperationManager, extension);
        UnionEntityExtensionDefinition e = (UnionEntityExtensionDefinition) extension;
        List<Object> list = new ArrayList<Object>();
        for (Entity updatableTable : updatableTables) {
            list.add(updatableTable.getName());
        }
        if (discriminator != null) {
            Field field = getEntity().addField(
                    new DefaultFieldDescriptor()
                            .setName(discriminator)
                            .setModifiers(FlagSets.of(UserFieldModifier.SUMMARY))
                            .setDefaultObject(updatableTables.get(0).getName())
                            .setDataType(TypesFactory.forList(entity.getName() + "." + discriminator, list, TypesFactory.STRING, false))
            );
            field.setPersistFormula(new Sequence(SequenceStrategy.AUTO));
        }
        getPersistenceUnit().addPersistenceUnitListener(new UnionPersistenceUnitInterceptorAdapter(this));
        entityOperationManager.setRemoveOperation(new EntityRemoveOperationHelper(this, updatableTables));
    }

    @Override
    public void commitModelChanges() throws UPAException {
        Entity entity = getEntity();
        FlagSet<EntityModifier> modifiers = entity.getUserModifiers();
        FlagSet<EntityModifier> excluded = entity.getUserExcludeModifiers();
        FlagSet<EntityModifier> effectiveModifiers = entity.getModifiers();
        if (!excluded.contains(EntityModifier.TRANSIENT)) {
            effectiveModifiers = effectiveModifiers.add(EntityModifier.TRANSIENT);
        }
        if (!excluded.contains(EntityModifier.UPDATE)) {
            effectiveModifiers = effectiveModifiers.add(EntityModifier.UPDATE);
        }
        if (!excluded.contains(EntityModifier.REMOVE)) {
            effectiveModifiers = effectiveModifiers.add(EntityModifier.REMOVE);
        }
        if (!modifiers.contains(EntityModifier.USER_ID)) {
            effectiveModifiers = effectiveModifiers.remove(EntityModifier.USER_ID);
        }
//        if (!modifiers.contains(EntityModifier.GENERATED_ID)) {
//            effectiveModifiers=effectiveModifiers.remove(EntityModifier.GENERATED_ID);
//        }
        ((DefaultEntity) entity).setModifiers(effectiveModifiers);
    }

    protected QueryStatement createViewQuery() throws UPAException {
        UnionEntityExtensionDefinition entityExtension = (UnionEntityExtensionDefinition) getDefinition();
        UnionQueryInfo queryInfo = entityExtension.getQueryInfo(getEntity());
        updatableTables = new ArrayList<Entity>(queryInfo.getEntities().size());
        for (String table : queryInfo.getEntities()) {
            updatableTables.add(getPersistenceUnit().getEntity(table));
        }
        this.discriminator = queryInfo.getDiscriminator();

        String[] tabNames = new String[updatableTables.size()];
        for (int i = 0; i < tabNames.length; i++) {
            tabNames[i] = updatableTables.get(i).getName();
        }
        viewFields = getEntity().getFieldNames(FieldFilters2.READ);
        viewFields.remove(discriminator);
        fieldsMapping = new String[queryInfo.getEntities().size()][viewFields.size()];
        for (int i = 0; i < tabNames.length; i++) {
            for (int j = 0; j < viewFields.size(); j++) {
                fieldsMapping[i][i] = queryInfo.getFieldName(tabNames[i], viewFields.get(j), i, j);

            }
        }
        return createViewQuery(getEntity().getName(), tabNames, discriminator, viewFields, fieldsMapping);
    }

    private static QueryStatement createViewQuery(
            String name,
            String[] tables,
            String updatableTableFieldName,
            List<String> viewFields,
            String[][] fieldsMapping) {
//        StringBuilder sb=new StringBuilder("");
        if (tables.length < 2) {
            if (tables.length == 0) {
                throw new UPAIllegalArgumentException("UnionTableUpdatableView must be over at least a couple of entities");
            }
            System.err.println("[WARNING] UnionTableUpdatableView must be over at least a couple of tables");
        }
        if (fieldsMapping != null && tables.length != fieldsMapping.length) {
            throw new UPAIllegalArgumentException("tables.length!=fieldsMapping.length");
        }
        Union u = new Union();
        for (int i = 0; i < tables.length; i++) {
            if (fieldsMapping != null && viewFields.size() != fieldsMapping[i].length) {
                throw new UPAIllegalArgumentException("UnionTableUpdatableView " + name + " requires " + viewFields.size() + " fields but got " + fieldsMapping[i].length + " for " + tables[i]);
            }
            Select s = new Select();
            s.field(new Literal(tables[i]), updatableTableFieldName);
            for (int j = 0; j < viewFields.size(); j++) {
                String viewField = viewFields.get(j);
                String varName = fieldsMapping == null ? viewField : fieldsMapping[i][j];
                s.field(new Var(varName), viewField);
            }
            s.from(tables[i]);
            u.add(s);
        }
        return u;
    }

    public QualifiedIdentifier getViewElementKey(QualifiedIdentifier viewKey) throws UPAException {
        Entity viewElementTable = getPersistenceUnit().getEntity(viewKey.getKey().getStringAt(0));
        List<Field> fields = viewElementTable.getIdFields();
        Object[] elemKeyVals = new Object[fields.size()];
        Object[] viewKeyVals = viewKey.getKey().getValue();
        System.arraycopy(viewKeyVals, 1, elemKeyVals, 0, elemKeyVals.length);
        return new QualifiedIdentifier(viewElementTable, viewElementTable.createId(elemKeyVals));
    }

    public QualifiedIdentifier getViewKey(Entity wiewElementTable, QualifiedIdentifier viewElementKey) throws UPAException {
        List<Field> fields = getEntity().getIdFields();
        Object[] viewKeyVals = new Object[fields.size()];
        Object[] elemKeyVals = viewElementKey.getKey().getValue();
        System.arraycopy(elemKeyVals, 0, viewKeyVals, 0, elemKeyVals.length);
        viewKeyVals[0] = wiewElementTable.getName();
        return new QualifiedIdentifier(getEntity(), getEntity().createId(viewKeyVals));
    }

    public String viewFieldToViewElementField(Entity viewElementTable, String viewField) throws UPAException {
        List<Field> pf = getEntity().getIdFields();
        List<Field> primaryFields = viewElementTable.getIdFields();
        for (int i = 1; i < pf.size(); i++) {
            if (viewField.equals(pf.get(i).getName())) {
                return primaryFields.get(i - 1).getName();
            }
        }
        return null;
    }

    public String viewElementFieldToViewField(Entity viewElementTable, String viewElementField) throws UPAException {
        List<Field> pf = viewElementTable.getIdFields();
        List<Field> primaryFields = getEntity().getIdFields();
        for (int i = 0; i < pf.size(); i++) {
            if (viewElementField.equals(pf.get(i).getName())) {
                return primaryFields.get(i + 1).getName();
            }
        }
        return null;
    }

    public String getUpdatedField(String viewFieldName, Entity entity) {
        int ti = updatableTables.indexOf(entity);
        int fi = viewFields.indexOf(viewFieldName);
        return fieldsMapping[ti][fi];
    }

    public List<Entity> getEntities() {
        return updatableTables;
    }

    public String getDiscriminator() {
        return discriminator;
    }

    public int indexOf(Entity entity) {
        return updatableTables.indexOf(entity);
    }

    public Expression getViewElementExpressionAt(int updatableTableIndex, Expression expression) throws UPAException {
        List<Field> pf = getEntity().getIdFields();
        List<Field> pft = updatableTables.get(updatableTableIndex).getIdFields();
        Expression[] pfte = new Expression[pft.size()];
        for (int i = 0; i < pfte.length; i++) {
            Field f = pft.get(i);
            pfte[i] = new Var(f.getName());
        }
        Uplet ut = new Uplet(pfte);

        Expression[] pfe = new Expression[pf.size() - 1];
        for (int i = 0; i < pfe.length; i++) {
            Field f = pf.get(i + 1);
            pfe[i] = new Var(f.getName());
        }
        Expression w = new Equals(new Var(pf.get(0).getName()), new Literal(updatableTables.get(updatableTableIndex).getName()));
        if (expression != null) {
            w = new And(w, expression);
        }
        Select q = new Select()
                .from(getEntity().getName())
                .uplet(pfe)
                .where(w);
        return new InSelection(ut, q);
    }

    public QueryStatement getQuery() {
        return viewQuery;
    }

}
