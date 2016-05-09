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

// Referenced classes of package net.vpc.lib.pheromone.ariana.database.sql:
//            StatementExpression, Select, SQLContext
public class InsertSelection extends DefaultEntityStatement
        implements NonQueryStatement, Cloneable {

    private static final long serialVersionUID = 1L;
    private static final DefaultTag ENTITY = new DefaultTag("ENTITY");
    private static final DefaultTag SELECTION = new DefaultTag("SELECTION");
    private QueryStatement selection;
    private ArrayList<Var> fields;
    private EntityName entity;
    private String alias;

    public InsertSelection() {
        selection = null;
        fields = new ArrayList<Var>(1);
    }

    @Override
    public List<TaggedExpression> getChildren() {
        List<TaggedExpression> list = new ArrayList<TaggedExpression>();
        if (entity != null) {
            list.add(new TaggedExpression(entity, ENTITY));
        }
        for (int i = 0; i < fields.size(); i++) {
            list.add(new TaggedExpression(fields.get(i), new IndexedTag("FIELD", i)));
        }
        if (selection != null) {
            list.add(new TaggedExpression(selection, SELECTION));
        }
        return list;
    }

    @Override
    public void setChild(Expression e, ExpressionTag tag) {
        if (ENTITY.equals(tag)) {
            this.entity = (EntityName) e;
        } else if (SELECTION.equals(tag)) {
            this.selection = (QueryStatement) e;
        } else {
            IndexedTag ii = (IndexedTag) tag;
            fields.set(ii.getIndex(), (Var) e);
        }
    }

    public InsertSelection(InsertSelection other) {
        this();
        addQuery(other);
    }

    private InsertSelection into(String entity, String alias) {
        this.entity = new EntityName(entity);
        this.alias = alias;
        return this;
    }

    public InsertSelection into(String entity) {
        return into(entity, null);
    }

    public String getEntityName() {
        EntityName e = getEntity();
        return (e != null) ? ((EntityName) e).getName() : null;
    }

    public EntityName getEntity() {
        return entity;
    }

    public String getAlias() {
        return alias;
    }

    public int size() {
        return 3;
    }

    public InsertSelection addQuery(InsertSelection other) {
        if (other == null) {
            return this;
        }
        if (other.entity != null) {
            entity = other.entity;
        }
        if (other.alias != null) {
            alias = other.alias;
        }
        for (int i = 0; i < other.fields.size(); i++) {
            field(other.getField(i).getName());
        }

        if (other.selection != null) {
            selection = (QueryStatement) other.selection.copy();
        }
        return this;
    }

    public Expression copy() {
        InsertSelection o = new InsertSelection();
        o.addQuery(this);
        return o;
    }

    public InsertSelection field(String key) {
        fields.add(new Var(key));
        return this;
    }

    public InsertSelection field(String[] keys) {
        for (String key : keys) {
            field(key);
        }

        return this;
    }

    public InsertSelection from(QueryStatement selection) {
        this.selection = selection;
        return this;
    }

//    public synchronized String toSQL(boolean integrated, PersistenceUnit database) {
//        if (query == null) {
//            StringBuffer sb = new StringBuffer("Insert Into " + entity);
//            if (alias != null)
//                sb.append(" ").append(alias);
//            sb.append("(");
//            boolean isFirst = true;
//            for (int i = 0; i < fields.size(); i++) {
//                if (isFirst)
//                    isFirst = false;
//                else
//                    sb.append(", ");
//                sb.append(fields.get(i));
//            }
//
//            query = sb.append(") ").append(selection.toSQL(database)).toString();
//        }
//        return query;
//    }
    public int countFields() {
        return fields.size();
    }

    public Var getField(int i) {
        return fields.get(i);
    }

    public QueryStatement getSelection() {
        return selection;
    }

    @Override
    public boolean isValid() {
        return entity != null && fields.size() > 0 && selection.isValid();
    }

    @Override
    public String getEntityAlias() {
        return null;
    }

}
