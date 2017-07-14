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
package net.vpc.upa.types;

import java.util.ArrayList;
import java.util.List;

public class BooleanType extends SeriesType implements Cloneable {

    public static final BooleanType BOOLEAN = new BooleanType("BOOLEAN", false, true);
    public static final BooleanType BOOLEAN_REF = new BooleanType("BOOLEAN", true, false);

    public BooleanType(String name, boolean nullable, boolean primitiveType) {
        super(name, primitiveType ? Boolean.TYPE : Boolean.class, nullable);
        setDefaultNonNullValue(false);
    }

    @Override
    public void check(Object value, String name, String description) throws ConstraintsException {
        super.check(value, name, description);
        if (!(value instanceof Boolean)) {
            throw new ConstraintsException("InvalidCast", name, description, value);
        }
    }

    @Override
    public List<Object> getValues() {
        List<Object> list = new ArrayList<Object>(2);
        list.add(Boolean.TRUE);
        list.add(Boolean.FALSE);
        return list;
    }

    @Override
    public String toString() {
        return "Boolean" + (isNullable()?"?":"");
    }

    public Boolean parse(String value) {
        if (value == null || value.trim().isEmpty()) {
            return null;
        }
        return Boolean.parseBoolean(value);
    }

}
