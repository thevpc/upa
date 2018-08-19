package net.vpc.upa.impl.upql.ext.expr;

import java.util.ArrayList;
import java.util.List;

import net.vpc.upa.expressions.ExpressionHelper;
import net.vpc.upa.impl.ext.expressions.CompiledExpressionExt;
import net.vpc.upa.impl.upql.DecObjectType;

public class CompiledDelete extends DefaultCompiledEntityStatement
        implements Cloneable, CompiledUpdateStatement {

    private static final long serialVersionUID = 1L;
    protected CompiledExpressionExt condition;
    protected CompiledEntityName entity;
    protected String entityAlias;

    public CompiledDelete(CompiledDelete other) {
        this();
        addQuery(other);
    }

    public CompiledDelete() {
        entity = null;
        entityAlias = null;
    }

    @Override
    public String getEntityName() {
        CompiledEntityName entity = getEntity();
        return entity==null?null:entity.getName();
    }

    private CompiledDelete from(String entityName, String alias) {
        this.entity = new CompiledEntityName(entityName);
        entityAlias = alias;
        exportDeclaration(alias, DecObjectType.ENTITY, entityName, null);
        bindChildren(entity);
        return this;
    }

    public CompiledDelete from(String table) {
        return from(table, null);
    }

    public CompiledEntityName getEntity() {
        return entity;
    }

    public String getEntityAlias() {
        return entityAlias;// == null ? entity.getName() : entityAlias;
    }
    public void setEntityAlias(String alias) {
        this.entityAlias=alias;
    }

    public CompiledDelete where(CompiledExpressionExt condition) {
        this.condition = condition;
        bindChildren(condition);
        return this;
    }

    public CompiledExpressionExt getCondition() {
        return condition;
    }

//    public Delete whereEquals(String key, DataPrimitiveType type, Object value) {
//        Expression e = ((Expression) (value != null && (value instanceof Expression) ? (Expression) value : ((Expression) (new Litteral(value)))));
//        return where(new Equals(new Var(key,type), e));
//    }
//
//    public Delete whereEquals(String[] keys, DataPrimitiveType[] type,Object[] values) {
//        for (int i = 0; i < keys.length; i++)
//            whereEquals(keys[i], type[i],values[i]);
//
//        return this;
//    }
//    public Delete whereEquals(Map keysValues) {
//        java.util.Map.Entry e;
//        for (Iterator i = keysValues.entrySet().iterator(); i.hasNext(); ) {
//            e = (java.util.Map.Entry) i.next();
//            whereEquals(e.getKey().toString(), e.getValue());
//        }
//
//        return this;
//    }
    public CompiledExpressionExt copy() {
        CompiledDelete o = new CompiledDelete();
        o.setDescription(getDescription());
        o.getClientParameters().setAll(getClientParameters());
        o.addQuery(this);
        return o;
    }

//    public synchronized String toSQL(boolean integrated, PersistenceUnitFilter database) {
//        if (query == null) {
//            StringBuffer sb = new StringBuffer("Delete From " + entity);
//            if (entityAlias != null)
//                sb.append(" ").append(entityAlias);
//            if (basicAndCondition.isValid())
//                sb.append(" Where ").append(getConditions().toSQL(database));
//            query = sb.toString();
//        }
//        return integrated ? '(' + query + ')' : query;
//    }
    public int size() {
        return 3;
    }

    public CompiledDelete addQuery(CompiledDelete other) {
        if (other == null) {
            return this;
        }
        if (other.entity != null) {
            from(other.entity.getName(), other.entityAlias);
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

    @Override
    public CompiledExpressionExt[] getSubExpressions() {
        ArrayList<CompiledExpressionExt> all = new ArrayList<CompiledExpressionExt>();
        if (entity != null) {
            all.add(entity);
        }
        if (condition != null) {
            all.add(condition);
        }
        return all.toArray(new CompiledExpressionExt[all.size()]);
    }

    @Override
    public void setSubExpression(int index, CompiledExpressionExt expression) {
        int i = 0;
        if (entity != null) {
            if (i == index) {
                unbindChildren(this.entity);
                entity = (CompiledEntityName) expression;
                bindChildren(entity);
            }
            i++;
        }
        if (condition != null) {
            if (i == index) {
                unbindChildren(this.condition);
                condition = expression;
                bindChildren(condition);
            }
            i++;
        }
    }

    protected List<CompiledNamedExpression> findEntityDefinitions() {
        ArrayList<CompiledNamedExpression> list = new ArrayList<CompiledNamedExpression>();
        list.add(new CompiledNamedExpression(getEntityAlias()==null?getEntity().getName():getEntityAlias(), getEntity()));
        return list;
    }

    @Override
    public String toString() {
        StringBuilder sb = new StringBuilder("Delete From " + entity);
        if (entityAlias != null) {
            sb.append(" ").append(ExpressionHelper.escapeIdentifier(entityAlias));
        }
        if (condition != null && condition.isValid()) {
            sb.append(" Where ").append(getCondition().toString());
        }
        return sb.toString();
    }

}
