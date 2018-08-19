/**
 * ====================================================================
 * UPA (Unstructured Persistence API)
 * Yet another ORM Framework
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
 * <p>
 * Copyright (C) 2014-2015 Taha BEN SALAH
 * <p>
 * This program is free software; you can redistribute it and/or modify it under
 * the terms of the GNU General Public License as published by the Free Software
 * Foundation; either version 2 of the License, or (at your option) any later
 * version.
 * <p>
 * This program is distributed in the hope that it will be useful, but WITHOUT
 * ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS
 * FOR A PARTICULAR PURPOSE. See the GNU General Public License for more
 * details.
 * <p>
 * You should have received a copy of the GNU General Public License along with
 * this program; if not, write to the Free Software Foundation, Inc., 51
 * Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA.
 * ====================================================================
 */
package net.vpc.upa.expressions;

import java.util.ArrayList;
import java.util.List;

/**
 * Created with IntelliJ IDEA. User: vpc Date: 8/19/12 Time: 12:34 AM To change
 * this template use File | Settings | File Templates.
 */
public class Union extends DefaultEntityStatement implements QueryStatement {

    private List<Select> queryStatements = new ArrayList<Select>(2);

    public Union() {
    }

    public Union(Select[] selects) {
        for (Select select : selects) {
            add(select);
        }
    }

    @Override
    public List<TaggedExpression> getChildren() {
        List<TaggedExpression> all = new ArrayList<TaggedExpression>();
        for (int i = 0; i < queryStatements.size(); i++) {
            all.add(new TaggedExpression(queryStatements.get(i), new IndexedTag("#", i)));
        }
        return all;
    }

    @Override
    public void setChild(Expression e, ExpressionTag tag) {
        queryStatements.set(((IndexedTag) tag).getIndex(), (Select) e);
    }

    public void add(QueryStatement query) {
        if (query instanceof Union) {
            for (Select queryStatement : ((Union) query).queryStatements) {
                add((Select) queryStatement);
            }
        } else {
            add((Select) query);
        }
    }

    public void add(Select s) {
        queryStatements.add(s);
    }

    public List<Select> getQueryStatements() {
        return new ArrayList<Select>(queryStatements);
    }

    public String getEntityName() {
        for (Select q : queryStatements) {
            String n = q.getEntityName();
            if (n != null) {
                return n;
            }
        }
        return null;
    }

    @Override
    public String getEntityAlias() {
        return null;
    }

    //    @Override
//    public String toSQL(boolean integrated, PersistenceUnit database) {
//        throw new net.vpc.upa.exceptions.UPAIllegalArgumentException("Unsupported");
//    }
    @Override
    public int countFields() {
        return queryStatements.get(0).countFields();
    }

    @Override
    public QueryField getField(int i) {
        return queryStatements.get(0).getField(i);
    }

    @Override
    public List<QueryField> getFields() {
        if (queryStatements.isEmpty()) {
            return new ArrayList<QueryField>();
        }
        return queryStatements.get(0).getFields();
    }

    @Override
    public boolean isValid() {
        if (queryStatements.isEmpty()) {
            return false;
        }
        for (QueryStatement queryStatement : queryStatements) {
            if (!queryStatement.isValid()) {
                return false;
            }
        }
        return true;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) {
            return true;
        }
        if (o == null || getClass() != o.getClass()) {
            return false;
        }

        Union union = (Union) o;

        if (queryStatements != null ? !queryStatements.equals(union.queryStatements) : union.queryStatements != null) {
            return false;
        }

        return true;
    }

    @Override
    public int hashCode() {
        return queryStatements != null ? queryStatements.hashCode() : 0;
    }

    @Override
    public Expression copy() {
        Union o = new Union();
        for (Select queryStatement : queryStatements) {
            o.add((Select) queryStatement.copy());
        }
        return o;
    }

}
