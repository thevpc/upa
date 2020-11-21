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
package net.thevpc.upa.expressions;
//            Expression

import java.util.Collections;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import net.thevpc.upa.exceptions.UnsupportedUPAFeatureException;

public class UserExpression extends DefaultExpression
        implements Cloneable {

    private static final long serialVersionUID = 1L;
    private String expression;
    private Map<String, Object> parameters = null;

    public UserExpression(String qlString) {
        this.expression = qlString;
    }

    @Override
    public List<TaggedExpression> getChildren() {
        return Collections.EMPTY_LIST;
    }

    @Override
    public void setChild(Expression e, ExpressionTag tag) {
        throw new UnsupportedUPAFeatureException("Not supported yet.");
    }

    public UserExpression setParameters(Map<String, Object> parameters) {
        if (parameters != null) {
            if (this.parameters == null) {
                this.parameters = new HashMap<String, Object>();
            }
            this.parameters.putAll(parameters);
        }
        return this;
    }

    public Object getParameter(String name) {
        if (parameters != null) {
            return parameters.get(name);
        }
        return null;
    }

    public Map<String, Object> getParameters() {
        if (parameters == null) {
            //could not be supported safely on C#
            //return Collections.EMPTY_MAP;
            return new HashMap<String, Object>();
        }
        return new HashMap<String, Object>(parameters);
    }

    public UserExpression setParameter(String name, Object value) {
        if (parameters == null) {
            parameters = new HashMap<String, Object>();
        }
        parameters.put(name, value);
        return this;
    }

    public UserExpression removeParameter(String name, Object value) {
        if (parameters != null) {
            parameters.remove(name);
        }
        return this;
    }

    public boolean containsParameter(String name) {
        if (parameters != null) {
            return parameters.containsKey(name);
        }
        return false;
    }

    //    public String toSQL(boolean integrated, PersistenceUnit database) {
//
//        return //integrated? '(' + value + ')' : value;
//        value;
//    }
    public String getExpression() {
        return expression;
    }

    @Override
    public Expression copy() {
        UserExpression o = new UserExpression(expression);
        return o;
    }

    @Override
    public String toString() {
        return String.valueOf(expression);
    }
}
