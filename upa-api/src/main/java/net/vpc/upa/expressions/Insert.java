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
import java.util.List;
import java.util.Map;

public class Insert extends DefaultEntityStatement implements NonQueryStatement, Cloneable {

    private static final DefaultTag ENTITY = new DefaultTag("ENTITY");
    private static final long serialVersionUID = 1L;
    private List<VarVal> fields;
    private EntityName entity;

    public Insert() {
        fields = new ArrayList<VarVal>();
    }

    public Insert(String entityName, String[] fields, Object[] values) {
        this();
        into(entityName);
        for (int i = 0; i < fields.length; i++) {
            set(fields[i], values[i]);
        }

    }

    public Insert(Insert other) {
        this();
        addQuery(other);
    }

    @Override
    public List<TaggedExpression> getChildren() {
        List<TaggedExpression> list = new ArrayList<TaggedExpression>(fields.size()+1);
        if (entity != null) {
            list.add(new TaggedExpression(entity, ENTITY));
        }
        for (int i = 0; i < fields.size(); i++) {
            list.add(new TaggedExpression(fields.get(i).getVar(), new IndexedTag("VAR", i)));
            list.add(new TaggedExpression(fields.get(i).getVal(), new IndexedTag("VAL", i)));
        }
        return list;
    }

    @Override
    public void setChild(Expression e, ExpressionTag tag) {
        if (ENTITY.equals(tag)) {
            this.entity = (EntityName) e;
        } else {
            IndexedTag ii = (IndexedTag) tag;
            if (ii.getName().equals("VAR")) {
                fields.get(ii.getIndex()).setVar((Var) e);
            } else {
                fields.get(ii.getIndex()).setVal(e);
            }
        }
    }

    public Insert into(String entity) {
        this.entity = new EntityName(entity);
        return this;
    }

    public EntityName getEntity() {
        return entity;
    }

    public String getEntityName() {
        EntityName e = getEntity();
        return (e != null) ? ((EntityName) e).getName() : null;
    }

    public int size() {
        return 3;
    }

    public Insert addQuery(Insert other) {
        if (other == null) {
            return this;
        }
        if (other.entity != null) {
            entity = (EntityName) other.entity.copy();
        }
        for (int i = 0; i < other.fields.size(); i++) {
            set(other.getField(i).getName(), other.getFieldValue(i).copy());
        }
        return this;
    }

    public Expression copy() {
        Insert o = new Insert();
        o.addQuery(this);
        return o;
    }

    public Insert set(String key, Object value) {
        if (value != null && (value instanceof Expression)) {
            return set(key, (Expression) value);
        } else {
            return set(key, ((Expression) (new Literal(value, null))));
        }
    }

    public Insert set(String key, Expression value) {
        fields.add(new VarVal(new Var(key), value));
        return this;
    }

    public Insert set(int index, Expression value) {
        fields.add(index, new VarVal(fields.get(index).getVar(), value));
        return this;
    }

    public Insert set(String[] keys, Object[] values) {
        for (int i = 0; i < keys.length; i++) {
            set(keys[i], values[i]);
        }

        return this;
    }

    public Insert set(Map<String, Object> keysValues) {
        for (Map.Entry<String, Object> e : keysValues.entrySet()) {
            set(e.getKey(), e.getValue());
        }
        return this;
    }

    @Override
    public String toString() {
        StringBuilder sb = new StringBuilder("Insert Into " + entity);
//        if (entityAlias != null) {
//            sb.append(" ").append(entityAlias);
//        }
        sb.append("(");
        StringBuilder sbVals = new StringBuilder();
        boolean isFirst = true;
        for (VarVal varVal : fields) {
            if (isFirst) {
                isFirst = false;
            } else {
                sb.append(", ");
                sbVals.append(", ");
            }
            sb.append(varVal.getVar());
            sbVals.append(varVal.getVal());
        }

        return sb.append(") Values (").append(sbVals).append(")").toString();
    }

    public int countFields() {
        return fields.size();
    }

    public Var getField(int i) {
        return fields.get(i).getVar();
    }

    public Expression getFieldValue(int i) {
        return fields.get(i).getVal();
    }

    @Override
    public boolean isValid() {
        return entity != null && fields.size() > 0;
    }

    @Override
    public String getEntityAlias() {
        return null;
    }
    
}
