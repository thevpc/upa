/**
 * ====================================================================
 * UPA (Unstructured Persistence API)
 *    Yet another ORM Framework
 * ++++++++++++++++++++++++++++++++++
 * Unstructured Persistence API, referred to as UPA, is a genuine effort
 * to raise programming language frameworks managing relational data in
 * applications using Java Platform, Standard Edition and Java Platform,
 * Enterprise Edition and Dot Net Framework equally to the next level of
 * handling ORM for mutable data structures. UPA is intended to provide
 * a solid reflection mechanisms to the mapped data structures while
 * affording to make changes at runtime of those data structures.
 * Besides, UPA has learned considerably of the leading ORM
 * (JPA, Hibernate/NHibernate, MyBatis and Entity Framework to name a few)
 * failures to satisfy very common even known to be trivial requirement in
 * enterprise applications.
 *
 * Copyright (C) 2014-2015 Taha BEN SALAH
 *
 * This program is free software; you can redistribute it and/or modify it under
 * the terms of the GNU General Public License as published by the Free Software
 * Foundation; either version 2 of the License, or (at your option) any later
 * version.
 *
 * This program is distributed in the hope that it will be useful, but WITHOUT
 * ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS
 * FOR A PARTICULAR PURPOSE. See the GNU General Public License for more
 * details.
 *
 * You should have received a copy of the GNU General Public License along with
 * this program; if not, write to the Free Software Foundation, Inc., 51
 * Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA.
 * ====================================================================
 */
package net.vpc.upa.expressions;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

// Referenced classes of package net.vpc.lib.pheromone.ariana.database.sql:
//            StatementExpression, And, Expression, Litteral,
//            Equals, Var, SQLContext
public final class Update extends DefaultEntityStatement implements NonQueryStatement {

    private static final DefaultTag ENTITY = new DefaultTag("ENTITY");
    private static final DefaultTag COND = new DefaultTag("COND");

    private static final long serialVersionUID = 1L;
    private List<VarVal> fields;
    private Expression condition;
    private EntityName entity;
    private String entityAlias;

    public Update() {
        fields = new ArrayList<VarVal>();
    }

    @Override
    public List<TaggedExpression> getChildren() {
        List<TaggedExpression> list = new ArrayList<TaggedExpression>();
        if (entity != null) {
            list.add(new TaggedExpression(entity, ENTITY));
        }
        for (int i = 0; i < fields.size(); i++) {
            list.add(new TaggedExpression(fields.get(i).getVar(), new IndexedTag("VAR", i)));
            list.add(new TaggedExpression(fields.get(i).getVal(), new IndexedTag("VAL", i)));
        }
        if (COND != null) {
            list.add(new TaggedExpression(condition, COND));
        }
        return list;
    }

    @Override
    public void setChild(Expression e, ExpressionTag tag) {
        if (ENTITY.equals(tag)) {
            this.entity = (EntityName) e;
        } else if (COND.equals(tag)) {
            this.condition = e;
        } else {
            IndexedTag ii = (IndexedTag) tag;
            if (ii.getName().equals("VAR")) {
                fields.get(ii.getIndex()).setVar((Var) e);
            } else {
                fields.get(ii.getIndex()).setVal(e);
            }
        }
    }

    public Map<Var, Expression> getUpdatesMapping() {
        Map<Var, Expression> m = new HashMap<Var, Expression>();
        for (VarVal f : fields) {
            m.put(f.getVar(), f.getVal());
        }
        return m;
    }

    public Update(Update other) {
        this();
        addQuery(other);
    }

    private Update entity(String entity, String alias) {
        this.entity = new EntityName(entity);
        entityAlias = alias;
        return this;
    }

    public String getEntityName() {
        EntityName e = getEntity();
        return (e != null) ? ((EntityName) e).getName() : null;
    }

    public Update entity(String entity) {
        return entity(entity, null);
    }

    public EntityName getEntity() {
        return entity;
    }

    public String getEntityAlias() {
        return entityAlias == null ? (entity == null ? null : entity.getName()) : entityAlias;
    }

    public int size() {
        return 3;
    }

    public Update addQuery(Update other) {
        if (other == null) {
            return this;
        }
        if (other.entity != null) {
            entity = (EntityName) other.entity.copy();
        }
        if (other.entityAlias != null) {
            entityAlias = other.entityAlias;
        }
        for (int i = 0; i < other.fields.size(); i++) {
            set(other.getField(i).getName(), other.getFieldValue(i));
        }

        if (other.condition != null) {
            if (condition == null) {
                condition = other.condition.copy();
            } else {
                condition = new And(condition, other.condition.copy());
            }
        }
        return this;
    }

    public Expression copy() {
        Update o = new Update();
        o.addQuery(this);
//        o.extraFrom = extraFrom;
        return o;
    }

    public Update set(String key, Object value) {
        if (value != null && (value instanceof Expression)) {
            return set(key, (Expression) value);
        } else {
            return set(key, ((Expression) (new Literal(value, null))));
        }
    }

    public Update set(String key, Expression value) {
        fields.add(new VarVal(new Var(key), value));
        return this;
    }

    public void removeFieldAt(int index) {
        fields.remove(index);
    }

    public Update where(Expression condition) {
        this.condition = condition;
        return this;
    }

    public Expression getCondition() {
        return condition;
    }

    public int countFields() {
        return fields.size();
    }

    public VarVal getVarVal(int i) {
        return fields.get(i);
    }
    
    public Var getField(int i) {
        return fields.get(i).getVar();
    }

    public Expression getFieldValue(int i) {
        return (Expression) fields.get(i).getVal();
    }

    public List<Var> getFields() {
        List<Var> all = new ArrayList<Var>(fields.size());
        for (VarVal field : fields) {
            all.add(field.getVar());
        }
        return all;
    }

    @Override
    public String toString() {
        StringBuilder sb = new StringBuilder("Update " + entity);
        if (entityAlias != null) {
            sb.append(" ").append(ExpressionHelper.escapeIdentifier(entityAlias));
        }
        sb.append(" Set ");
        boolean isFirst = true;
        int max = countFields();
        for (int i = 0; i < max; i++) {
            Var field = getField(i);
            Expression fieldValue = getFieldValue(i);
            if (isFirst) {
                isFirst = false;
            } else {
                sb.append(", ");
            }
            sb.append(field);
            sb.append("=");
            if(fieldValue instanceof Function
                    || fieldValue instanceof Param
                    || fieldValue instanceof Literal
                    || fieldValue instanceof Var
                    || fieldValue instanceof Cst
                    ) {
                sb.append(fieldValue);
            }else{
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
}
