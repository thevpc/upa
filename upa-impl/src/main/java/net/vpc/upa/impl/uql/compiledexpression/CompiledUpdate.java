package net.vpc.upa.impl.uql.compiledexpression;

import net.vpc.upa.Field;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import net.vpc.upa.impl.uql.DecObjectType;

// Referenced classes of package net.vpc.lib.pheromone.ariana.database.sql:
//            StatementExpression, And, Expression, Litteral,
//            Equals, Var, SQLContext
public final class CompiledUpdate extends DefaultCompiledEntityStatement implements CompiledUpdateStatement {

    private static final long serialVersionUID = 1L;
    private List<CompiledVarVal> fields;
    private DefaultCompiledExpression condition;
    private CompiledEntityName entityName;
    private String entityAlias;

    public CompiledUpdate() {
        fields = new ArrayList<CompiledVarVal>();
    }

//    public Update from(String extraFrom) {
//        this.extraFrom = extraFrom;
//        return this;
//    }
    public Map<CompiledVar, DefaultCompiledExpression> getUpdatesMapping() {
        Map<CompiledVar, DefaultCompiledExpression> m = new HashMap<CompiledVar, DefaultCompiledExpression>();
        for (CompiledVarVal f : fields) {
            m.put(f.getVar(), f.getVal());
        }
        return m;
    }

    public CompiledUpdate(CompiledUpdate other) {
        this();
        addQuery(other);
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

    public CompiledEntityName getEntity() {
        return entityName;
    }

    public String getEntityAlias() {
        return entityAlias == null ? entityName.getName() : entityAlias;
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
        for (CompiledVarVal varVal : fields) {
            all.add(varVal);
        }
        all.add(condition);
        return all.toArray(new DefaultCompiledExpression[all.size()]);
    }

    @Override
    public void setSubExpression(int index, DefaultCompiledExpression expression) {
        if (index == 0) {
            entityName = (CompiledEntityName) expression;
            prepareChildren(expression);
        } else if(index<=fields.size()){
            fields.set(index-1, (CompiledVarVal)expression);
            prepareChildren(expression);
        }else{
            condition=expression;
            prepareChildren(expression);
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
}
