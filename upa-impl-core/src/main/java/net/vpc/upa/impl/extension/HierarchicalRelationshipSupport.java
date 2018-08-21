package net.vpc.upa.impl.extension;

import java.util.ArrayList;

import net.vpc.upa.exceptions.IllegalUPAArgumentException;
import net.vpc.upa.impl.ext.EntityExt;
import net.vpc.upa.impl.upql.util.UPQLUtils;
import net.vpc.upa.impl.util.StringUtils;
import net.vpc.upa.types.*;
import net.vpc.upa.*;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.expressions.*;
import net.vpc.upa.persistence.EntityExecutionContext;

import java.util.List;
import net.vpc.upa.extensions.HierarchyExtension;

import net.vpc.upa.filters.FieldFilters;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 8/29/12 11:32 PM
 */
public class HierarchicalRelationshipSupport implements HierarchyExtension {

    private String hierarchySeparator;

    private String hierarchyPathField;

    private Relationship treeRelation;

    public HierarchicalRelationshipSupport(Relationship treeRelation) {
        this.treeRelation = treeRelation;
    }

    public String getHierarchyPathSeparator() {
        return hierarchySeparator;
    }

    public void setHierarchyPathSeparator(String hierarchySeparator) {
        this.hierarchySeparator = hierarchySeparator;
    }

    public String getHierarchyPathField() {
        return hierarchyPathField;
    }

    public void setHierarchyPathField(String hierarchyPathField) {
        this.hierarchyPathField = hierarchyPathField;
    }

    private Entity getEntity() {
        return treeRelation.getSourceRole().getEntity();
    }

    public boolean isParent(Object parentId, Object childId) throws UPAException {
        String p = toStringId(parentId);
        String c = toStringId(childId);
        return getEntity().getEntityCount(new And(
                new Or(
                        new Like(new Var(getHierarchyPathField()), new Param("isParentParam", "%/" + p + "/%/" + c)),
                        new Like(new Var(getHierarchyPathField()), new Param("isParentParam", "%/" + p + "/" + c))),
                getEntity().getBuilder().idToExpression(childId, UPQLUtils.THIS))) > 0;
    }

    public boolean isEqualOrIsParent(Object parentId, Object childId) throws UPAException {
        String p = toStringId(parentId);
//        String c = getPathPartFromId(childId);
        return getEntity().getEntityCount(new And(
                new Or(
                        //TODO incorrect
                        new Like(new Var(getHierarchyPathField()), new Param("isEqualOrIsParentParam1", "%/" + p + "/%")),
                        new Like(new Var(getHierarchyPathField()), new Param("isEqualOrIsParentParam2", "%/" + p))),
                getEntity().getBuilder().idToExpression(childId, UPQLUtils.THIS))) > 0;
    }

    public static ManyToOneRelationship getTreeRelation(Entity e) throws UPAException {
        ManyToOneRelationship r = null;
        for (Relationship relation : e.getPersistenceUnit().getRelationshipsBySource(e)) {
            if(relation instanceof ManyToOneRelationship) {
                if (relation.getTargetRole().getEntity().equals(e)) {
                    if (r != null) {
                        throw new IllegalStateException("Ambiguity in resolving tree relation");
                    }
                    r = (ManyToOneRelationship) relation;
                }
            }
        }
        return r;
    }

    public Relationship getTreeRelationship() throws UPAException {
        return treeRelation;
    }

    public Expression createFindRootsExpression(String alias) throws UPAException {
        Var v = new Var(alias == null ? null : new Var(alias), getHierarchyPathField());
        return new Equals(v, new Concat(
                new Expression[]{new Literal(getHierarchyPathField()), v}
        ));

    }

    public Expression createFindDeepChildrenExpression(String alias, Object id, boolean includeId) throws UPAException {
        Expression v = null;
        if (alias == null) {
            v = new Var(getHierarchyPathField());
        } else {
            Expression r = getEntity().getPersistenceUnit().getExpressionManager().parseExpression(alias);
            if (!(r instanceof Var)) {
                throw new IllegalUPAArgumentException("Only var expressions are supported");
            }
            v = new Var((Var) r, getHierarchyPathField());
        }
        if (includeId) {
            return new Or(
                    new Like(
                            v,
                            new Literal("%" + getHierarchyPathSeparator() + id)),
                    new Like(
                            v,
                            new Literal("%" + getHierarchyPathSeparator() + id + getHierarchyPathSeparator() + "%")));
        } else {
            return new Like(
                    v,
                    new Literal("%" + getHierarchyPathSeparator() + id + getHierarchyPathSeparator() + "%"));
        }
    }

    public Expression createFindImmediateChildrenExpression(String alias, Object id) throws UPAException {
        List<Field> parentFields = getTreeRelationship().getSourceRole().getFields();
        Expression a = null;
        Key key = getEntity().getBuilder().idToKey(id);
        for (int i = 0; i < parentFields.size(); i++) {
            Field field = parentFields.get(i);
            Var v = new Var(alias == null ? null : new Var(alias), field.getName());
            Expression e = (new Equals(
                    v,
                    new Literal(key.getObjectAt(i), field.getDataType())));
            a = a == null ? e : new And(a, e);
        }
        return a;
    }

    public String toStringId(Object id) throws UPAException {
        return toStringKey(getEntity().getBuilder().idToKey(id));
    }

    public String toStringKey(Key key) throws UPAException {
        if (key == null) {
            return "";
        }
        StringBuilder s = new StringBuilder();
        Object[] kvalue = key.getValue();
        for (int i = 0; i < kvalue.length; i++) {
            if (i > 0) {
                s.append(getHierarchyPathSeparator());
            }
            s.append(kvalue[i].toString());
        }

        return s.toString();
    }

    private List<Field> getUpdateTreeFields() {
        Relationship treeRelation = getTreeRelationship();
        List<Field> updateTreeFields = new ArrayList<Field>();
        switch (treeRelation.getSourceRole().getRelationshipUpdateType()) {
            case COMPOSED: {
                Field f = treeRelation.getSourceRole().getEntityField();
                if (f != null) {
                    updateTreeFields.add(f);
                }
                break;
            }
            case FLAT: {
                List<Field> fields = treeRelation.getSourceRole().getFields();
                if (fields != null) {
                    for (Field f : fields) {
                        updateTreeFields.add(f);
                    }
                }
                break;
            }
        }
        return updateTreeFields;
    }

    protected void validatePathField(Object id, EntityExecutionContext executionContext)
            throws UPAException {
        List<Field> lfs = getTreeRelationship().getSourceRole().getFields();
        Object[] parent_id = new Object[lfs.size()];
        Document values = getEntity()
                .createQueryBuilder()
                .byExpression(getEntity().getBuilder().idToExpression(id, UPQLUtils.THIS))
                .setFieldFilter(FieldFilters.regular().and(FieldFilters.byList(lfs)))
                .getDocument();
        if (values == null) {
            parent_id = null;
        } else {
            for (int i = 0; i < parent_id.length; i++) {
                Field field = lfs.get(i);
                parent_id[i] = values.getObject(field.getName());
                if (parent_id[i] != null) {
                    continue;
                }
                parent_id = null;
                break;
            }
        }

        String path = getHierarchyPathSeparator()+toStringId(id);
        if (parent_id != null) {
            Document r = getEntity().createQueryBuilder().byExpression(getEntity().getBuilder().idToExpression(getEntity().createId(parent_id), UPQLUtils.THIS)).setFieldFilter(FieldFilters.byName(getHierarchyPathField())).getDocument();
            if (r != null) {
                path = r.getString(getHierarchyPathField()) + path;
            }
        }
        Document r2 = getEntity().getBuilder().createDocument();
        r2.setString(getHierarchyPathField(), path);
        ((EntityExt)getEntity()).updateCore(r2, getEntity().getBuilder().idToExpression(id, UPQLUtils.THIS), executionContext);
    }

    protected void validateChildren(Object key, EntityExecutionContext executionContext)
            throws UPAException {
        Document r = getEntity().createQueryBuilder().byExpression(getEntity().getBuilder().idToExpression(key, UPQLUtils.THIS)).setFieldFilter(FieldFilters.byName(getHierarchyPathField())).getDocument();

        List<Field> lfs = getTreeRelationship().getSourceRole().getFields();
        Concat concat = new Concat();
        concat.add(new Literal(r.getString(getHierarchyPathField()), getEntity().getField(getHierarchyPathField()).getDataType()));
        List<Field> primaryFields = getEntity().getIdFields();
        for (Field f : primaryFields) {
            concat.add(new Literal(getHierarchyPathSeparator()));
            //implicit conversion will be done in ConcatSQLProvider
            concat.add(new Var(f.getName()));
        }

        Document s = getEntity().getBuilder().createDocument();
        s.setObject(getHierarchyPathField(), concat);

        Expression p = null;
        Relationship rel = getTreeRelationship();
        Object[] kvalue = getEntity().getBuilder().idToKey(key).getValue();
        for (int i = 0; i < rel.size(); i++) {
            Field field = lfs.get(i);
            Expression e = (new Equals(new Var(field.getName()), new Literal(kvalue[i], field.getDataType())));
            p = p == null ? e : new And(p, e);
        }
        ((EntityExt)getEntity()).updateCore(s, p, executionContext);
        List<Object> children = getEntity().createQueryBuilder().byExpression(p).getIdList();
        for (Object aChildren : children) {
            validateChildren(aChildren, executionContext);
        }
    }

    public Object findEntityByMainPath(String mainFieldPath) {
        Entity entity = getEntity();
        return entity.createQueryBuilder().byExpression(createFindEntityByMainPathExpression(mainFieldPath, null)).getFirstResultOrNull();
    }

    public Object findEntityByIdPath(Object[] idPath) throws UPAException {
        Entity entity = getEntity();
        return entity.createQueryBuilder().byExpression(createFindEntityByIdPathExpression(idPath, null)).getFirstResultOrNull();
    }

    public Object findEntityByKeyPath(Key[] keyPath) throws UPAException {
        Entity entity = getEntity();
        return entity.createQueryBuilder().byExpression(createFindEntityByKeyPathExpression(keyPath, null)).getFirstResultOrNull();
    }

    public Expression createFindEntityByIdPathExpression(Object[] idPath, String entityAlias) throws UPAException {
        Entity entity = getEntity();
        if (entityAlias == null) {
            entityAlias = entity.getName();
        }
        StringBuilder b = new StringBuilder();
        for (Object o : idPath) {
            b.append(getHierarchyPathSeparator());
            b.append(toStringId(o));
        }
        return new Equals(new Var(new Var(entityAlias), getHierarchyPathField()), new Param(entityAlias + "_ebip", b.toString()));
    }

    public Expression createFindEntityByKeyPathExpression(Key[] keyPath, String entityAlias) throws UPAException {
        Entity entity = getEntity();
        if (entityAlias == null) {
            entityAlias = entity.getName();
        }
        StringBuilder b = new StringBuilder();
        for (Key o : keyPath) {
            b.append(getHierarchyPathSeparator());
            b.append(toStringKey(o));
        }
        return new Equals(new Var(new Var(entityAlias), getHierarchyPathField()), new Param(entityAlias + "_ebip", b.toString()));
    }

    public Expression createFindEntityByMainPathExpression(String mainFieldPath, String entityAlias) {
        Entity entity = getEntity();
        RelationshipRole detailRole = getTreeRelationship().getSourceRole();
        if (StringUtils.isNullOrEmpty(mainFieldPath)) {
            return null;
        }
        String mainFieldName = entity.getMainField().getName();
        Object mainFieldValue = null;
        Object parent = null;
        String[] parentAndName = StringUtils.split(mainFieldPath, getHierarchyPathSeparator().charAt(0), false);
        if (parentAndName != null) {
            parent = findEntityByMainPath(parentAndName[0]);
            mainFieldValue = parentAndName[1];
        } else {
            mainFieldValue = mainFieldPath;
        }
        Expression expr = null;
        if (entityAlias == null) {
            entityAlias = entity.getName();
        }
        expr = new Equals(new Var(new Var(entityAlias), mainFieldName), mainFieldValue);
        Key entityToKey = parent == null ? null : entity.getBuilder().objectToKey(parent);
        List<Field> primaryFields = detailRole.getFields();
        for (int index = 0; index < primaryFields.size(); index++) {
            Field field = primaryFields.get(index);
            expr = new And(expr, new Equals(new Var(new Var(entityAlias), field.getName()), entityToKey == null ? null : entityToKey.getObjectAt(index)));
        }
        return expr;
    }

//    @Override
//    public void addSecuritySupport() {
//        super.addSecuritySupport();
//        //TODO
////        getPersistenceUnit().getApplication().getSecurityManager().registerAction(
////                getSecurityActionIdForNavigateByRecurseTree(),
////                getName(),
////                getPersistenceUnit().getResources().getGeneric(
////                        "Entity.*.security.treetable", getName(),
////                        new Object[]{getTitle()}), Resources.loadImageIcon("/images/net/vpc/swing/Tree.gif"));
//    }
//    public String getSecurityActionIdForNavigateByRecurseTree() {
//        return getName() + ".provider.recursetree";
//    }
    public <T> List<T> findDeepChildrenEntityList(Object id, boolean includeId) throws UPAException {
        return treeRelation.getPersistenceUnit().createQueryBuilder(getEntity().getName()).byExpression(createFindDeepChildrenExpression(getEntity().getName(), id, includeId)).getResultList();
    }

    public <T> List<T> findImmediateChildrenEntityList(Object id) throws UPAException {
        return treeRelation.getPersistenceUnit().createQueryBuilder(getEntity().getName()).byExpression(createFindImmediateChildrenExpression(getEntity().getName(), id)).getResultList();
    }

    public <T> List<T> findRootsEntityList() throws UPAException {
        return treeRelation.getPersistenceUnit().createQueryBuilder(getEntity().getName()).byExpression(createFindRootsExpression(getEntity().getName())).getResultList();
    }
}
