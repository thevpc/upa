package net.vpc.upa.impl.uql.compiledexpression;

import net.vpc.upa.Field;
import net.vpc.upa.expressions.CompiledExpression;
import net.vpc.upa.expressions.ExpressionHelper;
import net.vpc.upa.expressions.JoinType;
import net.vpc.upa.impl.uql.DecObjectType;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

public final class CompiledUpdate extends DefaultCompiledEntityStatement implements CompiledUpdateStatement {

    private static final long serialVersionUID = 1L;
    private List<CompiledVarVal> fields;
    private DefaultCompiledExpression condition;
    private CompiledEntityName entityName;
    private String entityAlias;
    private List<CompiledJoinCriteria> joinsTables=new ArrayList<>();

    public CompiledUpdate() {
        fields = new ArrayList<CompiledVarVal>();
    }

//    public Update from(String extraFrom) {
//        this.extraFrom = extraFrom;
//        return this;
//    }

    public CompiledUpdate(CompiledUpdate other) {
        this();
        addQuery(other);
    }

    public Map<CompiledVar, DefaultCompiledExpression> getUpdatesMapping() {
        Map<CompiledVar, DefaultCompiledExpression> m = new HashMap<CompiledVar, DefaultCompiledExpression>();
        for (CompiledVarVal f : fields) {
            m.put(f.getVar(), f.getVal());
        }
        return m;
    }

    private CompiledUpdate entity(String entity, String alias) {
        this.entityName = new CompiledEntityName(entity);
        entityAlias = alias;
        prepareChildren(this.entityName);
        exportDeclaration(entityAlias, DecObjectType.ENTITY, ((CompiledEntityName) this.entityName).getName(), null);
        return this;
    }

    public CompiledUpdate entity(String entity) {
        return entity(entity, null);
    }

    @Override
    public String getEntityName() {
        CompiledEntityName entity = getEntity();
        return entity == null ? null : entity.getName();
    }

    public CompiledEntityName getEntity() {
        return entityName;
    }

    public String getEntityAlias() {
        return entityAlias;
    }

    public void setEntityAlias(String alias) {
        this.entityAlias = alias;
    }

    public int size() {
        return 3;
    }

    public CompiledUpdate addQuery(CompiledUpdate other) {
        if (other == null) {
            return this;
        }
        if (other.entityName != null) {
            this.entity(((CompiledEntityName) other.entityName).getName(), other.entityAlias);
        }
        for (int i = 0; i < other.fields.size(); i++) {
            CompiledVar fvar = other.getField(i);
            Field field = (Field) fvar.getReferrer();
            DefaultCompiledExpression fieldValue = other.getFieldValue(i);
            set(field, fieldValue == null ? null : fieldValue.copy());
        }

        if (other.condition != null) {
            if (condition == null) {
                where(other.condition.copy());
            } else {
                where(new CompiledAnd(condition, other.condition.copy()));
            }
        }
        return this;
    }

    public DefaultCompiledExpression copy() {
        CompiledUpdate o = new CompiledUpdate();
        o.setDescription(getDescription());
        o.getClientParameters().setAll(getClientParameters());
        o.addQuery(this);
//        o.extraFrom = extraFrom;
        return o;
    }

    public CompiledUpdate set(Field key, DefaultCompiledExpression value) {
        CompiledVarVal varVal = new CompiledVarVal(new CompiledVar(key), value);
        fields.add(varVal);
        prepareChildren(varVal);
        return this;
    }

    //    public Update set(String[] keys, Object[] values) {
//        for (int i = 0; i < keys.length; i++)
//            set(keys[i], values[i]);
//
//        return this;
//    }
//    public Update set(Map keysValues) {
//        java.util.Map.Entry e;
//        for (Iterator i = keysValues.entrySet().iterator(); i.hasNext(); set((String) e.getKey(), e.getValue()))
//            e = (java.util.Map.Entry) i.next();
//
//        return this;
//    }
    public CompiledUpdate where(DefaultCompiledExpression condition) {
        this.condition = condition;
        prepareChildren(condition);
        return this;
    }

    public DefaultCompiledExpression getCondition() {
        return condition;
    }

    //    public Update whereEquals(String key, DataPrimitiveType type,Object value) {
//        Expression e = ((Expression) (value != null && (value instanceof Expression) ? (Expression) value : ((Expression) (new Litteral(value)))));
//        return where(new Equals(new Var(key,type), e));
//    }
//    public Update whereEquals(String[] keys, Object[] values) {
//        for (int i = 0; i < keys.length; i++)
//            whereEquals(keys[i], values[i]);
//
//        return this;
//    }
//    public Update whereEquals(Map keysValues) {
//        java.util.Map.Entry e;
//        for (Iterator i = keysValues.entrySet().iterator(); i.hasNext(); whereEquals(e.getKey().toString(), e.getValue()))
//            e = (java.util.Map.Entry) i.next();
//
//        return this;
//    }
//    public synchronized String toSQL(boolean integrated, PersistenceUnitFilter database) {
//        if (query == null) {
//            StringBuffer sb = new StringBuffer("Update " + entity);
//            if (entityAlias != null)
//                sb.append(" ").append(entityAlias);
//            sb.append(" Set ");
//            boolean isFirst = true;
//            java.util.Map.Entry entry;
//            for (Iterator i = fields.entrySet().iterator(); i.hasNext(); sb.append(entry.getKey()).append("=").append(((Expression) entry.getValue()).toSQL(true, database))) {
//                entry = (java.util.Map.Entry) i.next();
//                if (isFirst)
//                    isFirst = false;
//                else
//                    sb.append(", ");
//            }
//
//            if (basicAndCondition.isValid())
//                sb.append(" Where ").append(getConditions().toSQL(database));
////            if (extraFrom != null)
////                sb.append(" ").append(extraFrom);
//            query = sb.toString();
//        }
//        return integrated ? '(' + query + ')' : query;
//    }
    public int countFields() {
        return fields.size();
    }

    public CompiledVar getField(int i) {
        return fields.get(i).getVar();
    }

    public DefaultCompiledExpression getFieldValue(int i) {
        return fields.get(i).getVal();
    }

    @Override
    public DefaultCompiledExpression[] getSubExpressions() {
        ArrayList<DefaultCompiledExpression> all = new ArrayList<DefaultCompiledExpression>();
        if (entityName != null) {
            all.add(entityName);
        }
        if (joinsTables != null) {
            for (CompiledJoinCriteria joinCriteria : joinsTables) {
                all.add(joinCriteria);
            }
        }
        for (CompiledVarVal varVal : fields) {
            all.add(varVal);
        }
        all.add(condition);
        return all.toArray(new DefaultCompiledExpression[all.size()]);
    }

    @Override
    public void setSubExpression(int index, DefaultCompiledExpression expression) {
        int i = 0;
        if (entityName != null) {
            if (i == index) {
                entityName = (CompiledEntityName) expression;
                if (expression != null) {
                    expression.setParentExpression(this);
                }
                return;
            }
            i++;
        }

        if (fields != null) {
            for (CompiledVarVal field : fields) {
                if (i == index) {
                    field.setVal(expression);
                    if (expression != null) {
                        expression.setParentExpression(this);
                    }
                    return;
                }
                i++;
            }
        }
        if (joinsTables != null) {
            for (int ii = 0; ii < joinsTables.size(); ii++) {
                if (i == index) {
                    joinsTables.set(ii, (CompiledJoinCriteria) expression);
                    if (expression != null) {
                        expression.setParentExpression(this);
                    }
                    return;
                }
                i++;
            }
        }
        if (condition != null) {
            if (i == index) {
                condition = expression;
                if (expression != null) {
                    expression.setParentExpression(this);
                }
            }
            i++;
        }
    }

    public List<CompiledVar> getFields() {
        List<CompiledVar> all = new ArrayList<CompiledVar>(fields.size());
        for (CompiledVarVal field : fields) {
            all.add(field.getVar());
        }
        return all;
    }

    protected List<CompiledNamedExpression> findEntityDefinitions() {
        ArrayList<CompiledNamedExpression> list = new ArrayList<CompiledNamedExpression>();
        list.add(new CompiledNamedExpression(getEntityAlias(), getEntity()));
        return list;
    }

    @Override
    public String toString() {
        StringBuilder sb = new StringBuilder("Update " + entityName);
        if (entityAlias != null) {
            sb.append(" ").append(ExpressionHelper.escapeIdentifier(entityAlias));
        }
        sb.append(" Set ");
        boolean isFirst = true;
        int max = countFields();
        for (int i = 0; i < max; i++) {
            CompiledVar field = getField(i);
            CompiledExpression fieldValue = getFieldValue(i);
            if (isFirst) {
                isFirst = false;
            } else {
                sb.append(", ");
            }
            sb.append(field);
            sb.append("=");
            if (fieldValue instanceof CompiledQLFunctionExpression
                    || fieldValue instanceof CompiledParam
                    || fieldValue instanceof CompiledLiteral
                    || fieldValue instanceof CompiledVar
                    || fieldValue instanceof CompiledCst
                    ) {
                sb.append(fieldValue);
            } else {
                sb.append("(");
                sb.append(fieldValue);
                sb.append(")");
            }
        }
        if (getCondition() != null && getCondition().isValid()) {
            sb.append(" Where ").append(getCondition());
        }
//            if (extraFrom != null)
        return sb.toString();
    }

    protected void exportDeclaration(CompiledNameOrSelect e, String entityAlias) {
        if (e instanceof CompiledEntityName) {
            exportDeclaration(entityAlias, DecObjectType.ENTITY, ((CompiledEntityName) e).getName(), null);
        } else {
            exportDeclaration(entityAlias, DecObjectType.SELECT, e, null);
        }
    }

    private CompiledUpdate join(JoinType joinType, CompiledNameOrSelect entityName, String alias, DefaultCompiledExpression condition) {
        join(new CompiledJoinCriteria(joinType, entityName, alias, condition));
        //getContext().declare(alias, entityName);
        return this;
    }

    public CompiledUpdate join(CompiledJoinCriteria someJoin) {
        joinsTables.add(someJoin);
        prepareChildren(someJoin);
        exportDeclaration(someJoin.getEntity(), someJoin.getEntityAlias());
        return this;
    }

    public CompiledUpdate join(String entityName, String alias, DefaultCompiledExpression condition) {
        return join(JoinType.INNER_JOIN, new CompiledEntityName(entityName), alias, condition);
    }

    public CompiledUpdate join(CompiledSelect entityName, String alias, DefaultCompiledExpression condition) {
        return join(JoinType.INNER_JOIN, entityName, alias, condition);
    }

    public CompiledUpdate innerJoin(String entityName, String alias, DefaultCompiledExpression condition) {
        return join(JoinType.INNER_JOIN, new CompiledEntityName(entityName), alias, condition);
    }

    public CompiledUpdate innerJoin(CompiledSelect entityName, String alias, DefaultCompiledExpression condition) {
        return join(JoinType.INNER_JOIN, entityName, alias, condition);
    }

    public CompiledUpdate leftJoin(String entityName, String alias, DefaultCompiledExpression condition) {
        return join(JoinType.LEFT_JOIN, new CompiledEntityName(entityName), alias, condition);
    }

    public CompiledUpdate leftJoin(CompiledSelect entityName, String alias, DefaultCompiledExpression condition) {
        return join(JoinType.LEFT_JOIN, entityName, alias, condition);
    }

    public CompiledUpdate rightJoin(String entityName, String alias, DefaultCompiledExpression condition) {
        return join(JoinType.RIGHT_JOIN, new CompiledEntityName(entityName), alias, condition);
    }

    public CompiledUpdate rightJoin(CompiledSelect entityName, String alias, DefaultCompiledExpression condition) {
        return join(JoinType.RIGHT_JOIN, entityName, alias, condition);
    }

    public CompiledUpdate fullJoin(String entityName, String alias, DefaultCompiledExpression condition) {
        return join(JoinType.FULL_JOIN, new CompiledEntityName(entityName), alias, condition);
    }

    public CompiledUpdate fullJoin(CompiledSelect entityName, String alias, DefaultCompiledExpression condition) {
        return join(JoinType.FULL_JOIN, entityName, alias, condition);
    }

    public CompiledUpdate crossJoin(String entityName) {
        return join(JoinType.CROSS_JOIN, new CompiledEntityName(entityName), null, null);
    }

    public CompiledUpdate crossJoin(String entityName, String alias) {
        return join(JoinType.CROSS_JOIN, new CompiledEntityName(entityName), alias, null);
    }

    public CompiledUpdate crossJoin(CompiledSelect entityName, String alias) {
        return join(JoinType.CROSS_JOIN, entityName, alias, null);
    }

    public int countJoins() {
        return joinsTables.size();
    }

    public CompiledJoinCriteria[] getJoins() {
        List<CompiledJoinCriteria> values = joinsTables;
        return values.toArray(new CompiledJoinCriteria[values.size()]);
    }

    public CompiledJoinCriteria getJoin(int i) {
        return joinsTables.get(i);
    }

}
