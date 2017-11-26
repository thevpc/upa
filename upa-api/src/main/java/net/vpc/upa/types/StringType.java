/**
 * ==================================================================== UPA
 * (Unstructured Persistence API) Yet another ORM Framework
 * ++++++++++++++++++++++++++++++++++ Unstructured Persistence API, referred to
 * as UPA, is a genuine effort to raise programming language frameworks managing
 * relational data in applications using Java Platform, Standard Edition and
 * Java Platform, Enterprise Edition and Dot Net Framework equally to the next
 * level of handling ORM for mutable data structures. UPA is intended to provide
 * a solid reflection mechanisms to the mapped data structures while affording
 * to make changes at runtime of those data structures. Besides, UPA has learned
 * considerably of the leading ORM (JPA, Hibernate/NHibernate, MyBatis and
 * Entity Framework to name a few) failures to satisfy very common even known to
 * be trivial requirement in enterprise applications.
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

import net.vpc.upa.DataTypeInfo;

public class StringType extends DefaultDataType implements Cloneable {

    public static final StringType DEFAULT = new StringType("String", 0, 255, true);
    public static final StringType UNLIMITED = new StringType("String", 0, Integer.MAX_VALUE, true);
    protected int min;
    protected int max;

    public int getMin() {
        return min;
    }

    public int getMax() {
        return max;
    }

    public StringType(String name) {
        this(name, 0, 255, true);
    }

    public StringType(String name, int min, int max, boolean nullable) {
        super(name, String.class, max, 0, nullable);
        this.max = max;
        this.min = min;
    }

    @Override
    protected void reevaluateCachedValues() {
        super.reevaluateCachedValues();
        if(!defaultValueUserDefined && !isNullable()) {
            defaultValue=("");
        }
    }

    @Override
    public void check(Object value, String name, String description)
            throws ConstraintsException {
        super.check(value, name, description);
        if (value == null) {
            return;
        }
        if (!(value instanceof String)) {
            throw new ConstraintsException("InvalidCast", name, description, value);
        }
        String sval = (String) value;
        if (getMin() >= 0 && sval.length() < getMin()) {
            throw new ConstraintsException("StringTooShort", name, description, value, min);
        }
        if (getMax() > 0 && sval.length() > getMax()) {
            throw new ConstraintsException("StringTooLong", name, description, value, max);
        }
    }

    @Override
    public String toString() {
        StringBuilder s = new StringBuilder("String");
        if (max > 0 || (min > 0)) {
            s.append("[");
            if (min > 0) {
                s.append(min);
                s.append("...");
            }
            if (max > 0) {
                s.append(max);
            }
            s.append("]");
        }
        return s.toString();
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        if (!super.equals(o)) return false;

        StringType that = (StringType) o;

        if (min != that.min) return false;
        return max == that.max;
    }

    @Override
    public int hashCode() {
        int result = super.hashCode();
        result = 31 * result + min;
        result = 31 * result + max;
        return result;
    }

    @Override
    public DataTypeInfo getInfo() {
        DataTypeInfo d = super.getInfo();
        d.getProperties().put("min", String.valueOf(min));
        d.getProperties().put("max", String.valueOf(max));
        return d;
    }

}
