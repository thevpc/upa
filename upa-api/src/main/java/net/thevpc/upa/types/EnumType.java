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
package net.thevpc.upa.types;

import net.thevpc.upa.DataTypeInfo;
import net.thevpc.upa.PortabilityHint;

import java.util.Arrays;
import java.util.List;

@PortabilityHint(target = "C#", name = "partial")
public class EnumType extends SeriesType implements Cloneable {

    public EnumType(Class enumClass, boolean nullable) {
        super(enumClass.getName(), enumClass, nullable);
    }
    @Override
    protected void reevaluateCachedValues() {
        super.reevaluateCachedValues();
        if(!defaultValueUserDefined && !isNullable()) {
            defaultValue=(getValues().get(0));
        }
    }

    @Override
    public void check(Object value, String name, String description) throws ConstraintsException {
        super.check(value, name, description);
        if (value != null && !getPlatformType().isInstance(value)) {
            throw new ConstraintsException("InvalidCast", name, description, value);
        }
    }

    @PortabilityHint(target = "C#", name = "ignore")
    @Override
    public List<Object> getValues() {
        return Arrays.asList(getPlatformType().getEnumConstants());
    }

    @Override
    public String toString() {
        return "EnumType{" + getPlatformType() + '}';
    }

    public Object parse(String value) {
        if (value == null || value.trim().isEmpty()) {
            return null;
        }
        return Enum.valueOf(getPlatformType(), value);
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        if (!super.equals(o)) return false;
        return true;
    }

    @Override
    public int hashCode() {
        int result = super.hashCode();
        return result;
    }

    @Override
    public DataTypeInfo getInfo() {
        DataTypeInfo d = super.getInfo();
        StringBuilder v=new StringBuilder();
        for (Object o : getPlatformType().getEnumConstants()) {
            if(v.length()>0){
                v.append(",");
            }
            v.append(o.toString());
        }
        d.getProperties().put("values", String.valueOf(v));
        return d;
    }
}
