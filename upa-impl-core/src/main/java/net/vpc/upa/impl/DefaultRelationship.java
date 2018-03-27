package net.vpc.upa.impl;

import java.util.*;

import net.vpc.upa.exceptions.UPAIllegalArgumentException;
import net.vpc.upa.impl.ext.EntityExt;
import net.vpc.upa.impl.uql.util.ThatExpressionReplacer;
import net.vpc.upa.impl.uql.util.UQLUtils;
import net.vpc.upa.impl.util.StringUtils;
import net.vpc.upa.types.I18NString;
import net.vpc.upa.*;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.expressions.*;
import net.vpc.upa.extensions.ViewEntityExtensionDefinition;
import net.vpc.upa.expressions.IdCollectionExpression;
import net.vpc.upa.expressions.IdExpression;
import net.vpc.upa.impl.util.UPAUtils;

import net.vpc.upa.extensions.HierarchyExtension;
import net.vpc.upa.impl.util.PlatformUtils;

import net.vpc.upa.types.ManyToOneType;
import net.vpc.upa.types.DataType;

public class DefaultRelationship extends AbstractUPAObject implements Relationship {

    private RelationshipRole targetRole;
    private RelationshipRole sourceRole;
    protected Map<String, String> targetToSourceKeyMap;
    protected Map<String, String> sourceToTargetKeyMap;
    protected DataType dataType;
    private RelationshipType relationType;
    protected Expression filter;
    private int tuningMaxInline = 10;
    private boolean nullable;
    private HierarchyExtension hierarchyExtension;

    public DefaultRelationship() {
        targetRole = new DefaultRelationshipRole();
        targetRole.setRelationship(this);
        targetRole.setRelationshipRoleType(RelationshipRoleType.TARGET);
        sourceRole = new DefaultRelationshipRole();
        sourceRole.setRelationship(this);
        sourceRole.setRelationshipRoleType(RelationshipRoleType.SOURCE);
    }

    @Override
    public String getAbsoluteName() {
        return getName();
    }

    public void setNullable(boolean nullable) {
        this.nullable = nullable;
    }

    @Override
    public void commitModelChanged() throws UPAException {
        Entity sourceEntity = getSourceRole().getEntity();
        Entity targetEntity = getTargetRole().getEntity();

        if (sourceEntity == null || targetEntity == null) {
            throw new UPAException("InvalidRelationDefinition");
        }
        if (!sourceEntity.getUserExcludeModifiers().contains(EntityModifier.VALIDATE_PERSIST)) {
            sourceEntity.getModifiers().add(EntityModifier.VALIDATE_PERSIST);
        }
        if (!sourceEntity.getUserExcludeModifiers().contains(EntityModifier.VALIDATE_UPDATE)) {
            sourceEntity.getModifiers().add(EntityModifier.VALIDATE_UPDATE);
        }
        List<Field> sourceFieldsList = sourceRole.getFields();
        Field[] sourceFields = sourceFieldsList.toArray(new Field[sourceFieldsList.size()]);

        KeyType keyType = new KeyType(targetEntity, filter, false);
        setDataType(keyType);

        tuningMaxInline = getPersistenceUnit().getProperties().getInt(Relationship.class.getName() + ".maxInline", 10);
        List<Field> targetFieldsList = targetEntity.getIdFields();
        Field[] targetFields = targetFieldsList.toArray(new Field[targetFieldsList.size()]);;

        // some checks
        if (sourceFields.length == 0) {
            throw new UPAIllegalArgumentException("No source fields are specified");
        }
        if (targetFields.length == 0) {
            throw new UPAIllegalArgumentException("Target Entity " + targetEntity.getName() + " has no primary fields");
        }
        if (sourceFields.length != targetFields.length) {
            throw new UPAIllegalArgumentException("source fields and target fields have not the same count");
        }
        sourceEntity.addDependencyOnEntity(targetEntity.getName());
        if (dataType == null) {
            dataType = targetEntity.getDataType();
        }
        if (dataType.isNullable() != nullable) {
            DataType trCloned = (DataType) dataType.copy();
            trCloned.setNullable(nullable);
            dataType = trCloned;
        }
        this.sourceToTargetKeyMap = new HashMap<String, String>(sourceFields.length);
        this.targetToSourceKeyMap = new HashMap<String, String>(sourceFields.length);
//        if ((theSourceTable  instanceof View))
//            this.type = 0;
        for (int i = 0; i < sourceFields.length; i++) {
            if (sourceFields[i].getModifiers().contains(FieldModifier.TRANSIENT) && this.relationType != RelationshipType.TRANSIENT) {
                //Log. System.err.println("Type should be VIEW for " + getName());
                this.relationType = RelationshipType.TRANSIENT;
            } else if (sourceFields[i].getUpdateFormula() != null && this.relationType != RelationshipType.TRANSIENT && this.relationType != RelationshipType.SHADOW_ASSOCIATION) {
                // Log. System.err.println("Type should be either VIEW or SHADOW for " + name);
                this.relationType = RelationshipType.SHADOW_ASSOCIATION;
            }

            this.sourceToTargetKeyMap.put(sourceFields[i].getName(), targetFields[i].getName());
            this.targetToSourceKeyMap.put(targetFields[i].getName(), sourceFields[i].getName());
//            targetFields[i].addManyToOneRelation(this);
            ((AbstractField)sourceFields[i]).setEffectiveModifiers(sourceFields[i].getModifiers().add(FieldModifier.FOREIGN));

            ((AbstractField)targetFields[i]).setEffectiveModifiers(targetFields[i].getModifiers().add(FieldModifier.REFERENCED));
//            if (sourceFields[i].getTitle() == null) {
//                sourceFields[i].setTitle(targetFields[i].getTitle());
//            }
            if (sourceFields[i].getDataType() == null) {
                DataType tr = targetFields[i].getDataType();
                if (tr.isNullable() == nullable) {
                    sourceFields[i].setDataType(tr);
                } else {
                    DataType trCloned = (DataType) tr.copy();
                    trCloned.setNullable(nullable);
                    sourceFields[i].setDataType(trCloned);
                }
            }
        }

        if (getSourceRole().getEntityField() != null) {
            Field sourceEntityField = getSourceRole().getEntityField();
            DataType dt = sourceEntityField.getDataType();
            if (dt instanceof ManyToOneType) {
                ManyToOneType edt = (ManyToOneType) dt;
                edt.setRelationship(this);
            }
        }
        if (getTargetRole().getEntityField() != null) {
            Field targetEntityField = getTargetRole().getEntityField();
            DataType dt = targetEntityField.getDataType();
            if (dt instanceof ManyToOneType) {
                ManyToOneType edt = (ManyToOneType) dt;
                edt.setRelationship(this);
            }
        }

        this.sourceToTargetKeyMap = PlatformUtils.unmodifiableMap(sourceToTargetKeyMap);
        this.targetToSourceKeyMap = PlatformUtils.unmodifiableMap(targetToSourceKeyMap);
        setI18NTitle(new I18NString("Relationship").append(getName()));
        setI18NDescription(getI18NTitle().append(".desc"));

        StringBuilder preferredPersistenceName = new StringBuilder(getName().length());
        for (int i = 0; i < getName().length(); i++) {
            if (ExpressionHelper.isIdentifierPart(getName().charAt(i))) {
                preferredPersistenceName.append(getName().charAt(i));
            } else {
                preferredPersistenceName.append('_');
            }
        }
        setPersistenceName(preferredPersistenceName.toString());
        if (getRelationshipType() == RelationshipType.COMPOSITION) {
            ((EntityExt) sourceEntity).setCompositionRelationship(this);
        }

        targetRole.setFields(targetFields);
        UPAUtils.prepare(getPersistenceUnit(), targetRole, this.getName() + "_" + targetRole.getRelationshipRoleType());
        UPAUtils.prepare(getPersistenceUnit(), sourceRole, this.getName() + "_" + sourceRole.getRelationshipRoleType());

        if (((getTargetRole().getEntity().getExtensionDefinitions(ViewEntityExtensionDefinition.class).size() > 0) || (getSourceRole().getEntity().getExtensionDefinitions(ViewEntityExtensionDefinition.class).size() > 0)) && relationType != RelationshipType.TRANSIENT) {
            throw new UPAIllegalArgumentException(this + " : Relationship Type must be TYPE_VIEW");
        }
        if (((getTargetRole().getEntity().getShield().isTransient()) || (getSourceRole().getEntity().getShield().isTransient())) && relationType != RelationshipType.TRANSIENT) {
            throw new UPAIllegalArgumentException(this + " : Relationship Type must be TYPE_VIEW");
        }

        FlagSet<FieldModifier> modifierstoRemove = FlagSets.ofType(FieldModifier.class)
                .addAll(
                        FieldModifier.PERSIST,
                        FieldModifier.PERSIST_DEFAULT,
                        FieldModifier.PERSIST_FORMULA,
                        FieldModifier.PERSIST_SEQUENCE,
                        FieldModifier.UPDATE,
                        FieldModifier.UPDATE_DEFAULT,
                        FieldModifier.UPDATE_FORMULA,
                        FieldModifier.UPDATE_SEQUENCE);
        switch (getSourceRole().getRelationshipUpdateType()) {
            case FLAT: {
                Field f = getSourceRole().getEntityField();
                if (f != null) {
                    ((AbstractField)f).setEffectiveModifiers(f.getModifiers().removeAll(modifierstoRemove));
                }
                break;
            }
            case COMPOSED: {
                List<Field> fields = getSourceRole().getFields();
                if (fields != null) {
                    for (Field f : fields) {
                        ((AbstractField)f).setEffectiveModifiers(f.getModifiers().removeAll(modifierstoRemove));
                    }
                }
                break;
            }
        }
    }

    public void setDataType(DataType dataType) {
        this.dataType = dataType;
    }

    public RelationshipType getRelationshipType() {
        return relationType;
    }

    public void setRelationshipType(RelationshipType relationType) {
        this.relationType = relationType;
    }

    public int size() {
        return getSourceRole().getFields().size();
    }

    public DataType getDataType() {
        return dataType;
    }

//    public Entity getSourceEntity() {
//        return sourceFields[0].getEntity();
//    }
//
//    public Entity getTargetEntity() {
//        return targetFields[0].getEntity();
//    }
    public Map<String, String> getSourceToTargetFieldNamesMap(boolean absolute) throws UPAException {
        Map<String, String> m = new HashMap<String, String>(getSourceToTargetFieldsMap().size());
        if (absolute) {
            for (Map.Entry<String, String> e : sourceToTargetKeyMap.entrySet()) {
                m.put(getSourceRole().getEntity().getField(e.getKey()).getName(), getTargetRole().getEntity().getField(e.getValue()).getName());
            }
        } else {
            for (Map.Entry<String, String> e : sourceToTargetKeyMap.entrySet()) {
                m.put(e.getKey(), e.getValue());
            }
        }
        return m;
    }

    public Map<String, String> getTargetToSourceFieldNamesMap(boolean absolute) throws UPAException {
        Map<String, String> m = new HashMap<String, String>(getSourceToTargetFieldsMap().size());
        if (absolute) {
            for (Map.Entry<String, String> e : targetToSourceKeyMap.entrySet()) {
                m.put(getTargetRole().getEntity().getField(e.getKey()).getName(), getSourceRole().getEntity().getField(e.getValue()).getName());
            }
        } else {
            for (Map.Entry<String, String> e : targetToSourceKeyMap.entrySet()) {
                m.put(e.getKey(), e.getValue());
            }
        }
        return m;
    }

//    public int indexOfTargetField(String fieldName) {
//        for (int i = 0; i < targetFields.length; i++) {
//            if (targetFields[i].getName().equals(fieldName)) {
//                return i;
//            }
//        }
//        return -1;
//    }
//
//    public int indexOfSourceField(String fieldName) {
//        for (int i = 0; i < sourceFields.length; i++) {
//            if (sourceFields[i].getName().equals(fieldName)) {
//                return i;
//            }
//        }
//        return -1;
//    }
    public Map<String, String> getSourceToTargetFieldsMap() {
        return sourceToTargetKeyMap;
    }

    public Map<String, String> getTargetToSourceFieldsMap() {
        return targetToSourceKeyMap;
    }

    @Override
    public boolean equals(Object other) {
        if (other == null || !(other instanceof DefaultRelationship)) {
            return false;
        } else {
            DefaultRelationship o = (DefaultRelationship) other;
            return getPersistenceUnit().getNamingStrategy().equals(getName(), o.getName());
        }
    }

    @Override
    public String toString() {
        return getName();
    }

//    public int compareTo(Object other) {
//        return toString().compareTo(other.toString());
//    }
    public Expression getTargetCondition(Expression sourceCondition, String sourceAlias, String targetAlias) {
        Field[] sourceFields = getSourceRole().getFields().toArray(new Field[getSourceRole().getFields().size()]);
        Field[] targetFields = getTargetRole().getFields().toArray(new Field[getTargetRole().getFields().size()]);
        Var[] lvar = new Var[sourceFields.length];
        Var[] rvar = new Var[targetFields.length];
        for (int i = 0; i < lvar.length; i++) {
            lvar[i] = (sourceAlias == null) ? new Var(sourceFields[i].getName()) : new Var(new Var(sourceAlias), sourceFields[i].getName());
            rvar[i] = (targetAlias == null) ? new Var(targetFields[i].getName()) : new Var(new Var(targetAlias), targetFields[i].getName());
        }
        if (tuningMaxInline > 0) {
            try {
                List<Document> list = getSourceRole().getEntity().createQuery(new Select().uplet(lvar, "lvar").where(sourceCondition)).getDocumentList();
                int j = 0;
                IdCollectionExpression inCollection = new IdCollectionExpression(rvar);
                for (Document r : list) {
                    j++;
                    if (j > tuningMaxInline) {
                        return new InSelection(lvar, new Select().from(getSourceRole().getEntity().getName()).uplet(lvar).where(sourceCondition));
                    }
                    inCollection.add(new Param(null, r.getSingleResult()));
                    //inCollection.add(new Litteral(rs.getObject(1)));
                }
                return inCollection;
//                return new InSelection(rvar, new Select().from(getSourceTable().getPersistenceName()).uplet(lvar).where(inCollection));
            } catch (UPAException e) {
                return new InSelection(rvar, new Select().from(getSourceRole().getEntity().getName()).uplet(lvar).where(sourceCondition));
            }
        } else {
            return new InSelection(rvar, new Select().from(getSourceRole().getEntity().getName()).uplet(lvar).where(sourceCondition));
        }
    }

    public Expression getSourceCondition(Expression targetCondition, String sourceAlias, String targetAlias) throws UPAException {
        //Key Rkey=getTargetTable().getKeyForExpression(targetCondition);
        Field[] sourceFields = getSourceRole().getFields().toArray(new Field[getSourceRole().getFields().size()]);
        Field[] targetFields = getTargetRole().getFields().toArray(new Field[getTargetRole().getFields().size()]);
        if (targetCondition instanceof IdExpression) {
            Key Rkey = targetRole.getEntity().getBuilder().idToKey(((IdExpression) targetCondition).getId());
            if (sourceFields.length == 1) {
                Var lvar = (sourceAlias == null) ? new Var(sourceFields[0].getName()) : new Var(new Var(sourceAlias), sourceFields[0].getName());
                return new Equals(lvar, new Literal(Rkey==null?null:Rkey.getValue()[0], targetFields[0].getDataType()));
            } else {
                Expression a = null;
                for (int i = 0; i < sourceFields.length; i++) {
                    Var lvar = (sourceAlias == null) ? new Var(sourceFields[i].getName()) : new Var(new Var(sourceAlias), sourceFields[i].getName());
                    Expression rvar = new Literal(Rkey==null?null:Rkey.getObjectAt(i), targetFields[i].getDataType());
                    Expression e = new Equals(lvar, rvar);
                    a = a == null ? e : a;
                }
                return a;
            }
        } else if (tuningMaxInline > 0) {
            Var[] lvar = new Var[sourceFields.length];
            Var[] rvar = new Var[targetFields.length];
            for (int i = 0; i < lvar.length; i++) {
                lvar[i] = new Var((sourceAlias == null) ? null : new Var(sourceAlias), sourceFields[i].getName());
                rvar[i] = new Var((targetAlias == null) ? null : new Var(targetAlias), targetFields[i].getName());
            }
            try {
                List<Document> list = getTargetRole().getEntity().createQuery(new Select().uplet(rvar, "rval").where(targetCondition)).getDocumentList();
                int j = 0;
                IdCollectionExpression inCollection = new IdCollectionExpression(lvar);
                for (Document r : list) {
                    j++;
                    if (j > tuningMaxInline) {
                        return new InSelection(lvar, new Select().from(getTargetRole().getEntity().getName()).uplet(rvar).where(targetCondition));
                    }
                    inCollection.add(new Param(null, r.getSingleResult()));
                    //inCollection.add(new Litteral(rs.getObject(1)));
                }
                return inCollection;
            } catch (UPAException e) {
                return new InSelection(lvar, new Select().from(getTargetRole().getEntity().getName()).uplet(rvar).where(targetCondition));
            }
        } else {
            Var[] lvar = new Var[sourceFields.length];
            Var[] rvar = new Var[targetFields.length];
            for (int i = 0; i < lvar.length; i++) {
                lvar[i] = new Var((sourceAlias == null) ? null : new Var(sourceAlias), sourceFields[i].getName());
                rvar[i] = new Var((targetAlias == null) ? null : new Var(targetAlias), targetFields[i].getName());
            }
            return new InSelection(lvar, new Select().from(getTargetRole().getEntity().getName()).uplet(rvar).where(targetCondition));
        }
    }

    public Expression getFilter() {
        return filter;
    }

//    public void setTargetFields(Field[] targetFields) {
//        this.targetFields = targetFields;
//    }
//
//    public void setTargetRole(RelationRole targetRole) {
//        this.targetRole = targetRole;
//    }
    //    public void setTargetToSourceKeyMap(Map<String,String> targetToSourceKeyMap) {
//        this.targetToSourceKeyMap = targetToSourceKeyMap;
//    }
//
//    public void setSourceFields(Field[] sourceFields) {
//        this.sourceFields = sourceFields;
//    }
//
//    public void setSourceRole(RelationRole sourceRole) {
//        this.sourceRole = sourceRole;
//    }
//    public void setSourceToTargetKeyMap(Map sourceToTargetKeyMap) {
//        this.sourceToTargetKeyMap = sourceToTargetKeyMap;
//    }
    //    public void setDataType(DataType dataType) {
//        this.dataType = dataType;
//    }
//
    public void setFilter(Expression filter) {
        this.filter = filter;
    }

    //    public void setTuningMaxInline(int tuningMaxInline) {
//        this.tuningMaxInline = tuningMaxInline;
//    }
//
    public boolean isTransient() {
        switch (relationType) {
            case TRANSIENT: {
                return true;
            }
        }
        return false;
    }

    @Override
    public boolean isFollowLinks() {
        switch (relationType) {
            case DEFAULT:
            case ASSOCIATION:
            case AGGREGATION:
            case COMPOSITION:
            case SHADOW_ASSOCIATION: {
                return true;
            }
        }
        return false;
    }

    @Override
    public boolean isAskForConfirm() {
        switch (relationType) {
            case DEFAULT:
            case ASSOCIATION:
            case AGGREGATION: {
                return true;
            }
        }
        return false;
    }

    public RelationshipRole getTargetRole() {
        return targetRole;
    }


    public RelationshipRole getSourceRole() {
        return sourceRole;
    }

    public Entity getTargetEntity() throws UPAException {
        return targetRole==null?null:targetRole.getEntity();
    }

    public Entity getSourceEntity() throws UPAException {
        return sourceRole==null?null:sourceRole.getEntity();
    }

    //    public void setRelationType(RelationType relationType) {
//        this.relationType = relationType;
//    }
//
//    @Override
//    public int hashCode() {
//        return getName() != null ? getName().hashCode() : 0;
//    }
    //    @Override
//    public String getDumpString() {
//        DumpStringHelper h = new DumpStringHelper(this, false);
//        h.add("name", name);
//        h.add("persistenceName", persistenceName);
//        h.add("title", title);
//        h.add("dataType", dataType);
//        h.add("nullable", nullable);
//        h.add("type", relationType);
//        h.add("filter", filter);
//        h.add("targetToSourceKeyMap", targetToSourceKeyMap);
//        h.add("sourceToTargetKeyMap", sourceToTargetKeyMap);
//        h.add("targetFields", targetFields);
//        h.add("sourceFields", sourceFields);
//        h.add("targetRole", targetRole);
//        h.add("sourceRole", sourceRole);
//        h.add("tuningMaxInline", tuningMaxInline);
//        return h.toString();
//    }
//    public Key[] loadAllSourceKeys(Key targetKey,Expression whereClause, Order criteria, boolean check){
//
//    }
//
//    public Document[] loadAllSourceDocuments(Key targetKey,Expression whereClause, Field[] fields, Order criteria){
//
//    }
//
//    public Document[] loadAllSourceDocuments(Expression whereClause, FieldFilter fieldFilter, Order criteria){
//
//    }
//
//    public Document[] loadAllSourceDocuments(Expression whereClause, String[] fields, Order criteria){
//
//    }
    public void close() throws UPAException {
        //
    }

    public Key extractKey(Document sourceDocument) {
        switch (getSourceRole().getRelationshipUpdateType()) {
            case COMPOSED: {
                Object targetEntityVal = sourceDocument.getObject(getSourceRole().getEntityField().getName());
                if (targetEntityVal == null) {
                    return null;
                }
                EntityBuilder targetConverter = getTargetRole().getEntity().getBuilder();
                return targetConverter.objectToKey(targetEntityVal);
            }
            case FLAT: {
                List<Field> relFields = getSourceRole().getFields();
                ArrayList<Object> keys = new ArrayList<Object>(relFields.size());
                for (Field field : relFields) {
                    Object keyPart = sourceDocument.getObject(field.getName());
                    if (keyPart == null) {
                        return null;
                    }
                    keys.add(keyPart);
                }
                return getTargetRole().getEntity().createKey(keys.toArray());

            }
        }
        return null;
    }

    public Object extractIdByEntityField(Document sourceDocument) {
        Object targetEntityVal = sourceDocument.getObject(getSourceRole().getEntityField().getName());
        if (targetEntityVal == null) {
            return null;
        }
        EntityBuilder targetConverter = getTargetRole().getEntity().getBuilder();
        return targetConverter.objectToId(targetEntityVal);
    }

    public Object extractIdByForeignFields(Document sourceDocument) {
        List<Field> relFields = getSourceRole().getFields();
        ArrayList<Object> keys = new ArrayList<Object>(relFields.size());
        for (Field field : relFields) {
            Object keyPart = sourceDocument.getObject(field.getName());
            if (keyPart == null) {
                return null;
            }
            keys.add(keyPart);
        }
        return getTargetRole().getEntity().createId(keys.toArray());
    }

    public Object extractId(Document sourceDocument) {
        switch (getSourceRole().getRelationshipUpdateType()) {
            case COMPOSED: {
                Object o = extractIdByEntityField(sourceDocument);
                return o;
            }
            case FLAT: {
                return extractIdByForeignFields(sourceDocument);
            }
        }
        return null;
    }

    public HierarchyExtension getHierarchyExtension() {
        return hierarchyExtension;
    }

    public void setHierarchyExtension(HierarchyExtension hierarchyExtension) {
        this.hierarchyExtension = hierarchyExtension;
    }

    public Expression createTargetListExpression(Object currentInstance, String alias){
        if(filter==null){
            return null;
        }
        HashMap<String,Object> v=new HashMap<String,Object>();
        v.put(UQLUtils.THIS,currentInstance);
        if(StringUtils.isNullOrEmpty(alias)){
            alias=getTargetEntity().getName();
        }
        final String alias2=alias;
        ExpressionManager expressionManager = getPersistenceUnit().getExpressionManager();
        Expression filter2= expressionManager.simplifyExpression(filter.copy(),v);
        filter2=expressionManager.createEvaluator().evalObject(filter2,null);
        filter2.visit(new ThatExpressionReplacer(alias2));
        return filter2;

    }

    @Override
    public RelationshipInfo getInfo() {
        RelationshipInfo i = new RelationshipInfo("many2one");
        fillObjectInfo(i);
        i.setAskForConfirm(isAskForConfirm());
        i.setFollowLinks(isFollowLinks());
        i.setFiltered(getFilter()!=null);
        i.setLive(isTransient());
        i.setRelationshipType(getRelationshipType());
        i.setNullable(nullable);
        i.setSource(getSourceEntity()==null?null:getSourceEntity().getName());
        i.setTarget(getTargetEntity()==null?null:getTargetEntity().getName());
        i.setSourceField(getTargetEntity()==null||getSourceRole().getEntityField()==null?null:getSourceRole().getEntityField().getName());
        i.setTargetField(getTargetEntity()==null||getTargetRole().getEntityField()==null?null:getTargetRole().getEntityField().getName());
        i.setSourceFields(getTargetEntity()==null?new String[0]:toString(getSourceRole().getFields()));
        i.setTargetFields(getTargetEntity()==null?new String[0]:toString(getTargetRole().getFields()));
        return i;
    }

    private String[] toString(List<Field> f){
        if(f==null){
            f= Collections.EMPTY_LIST;
        }
        String[] all=new String[f.size()];
        for (int i = 0; i < all.length; i++) {
            all[i]=f.get(i).getName();
        }
        return all;
    }
}
