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
package net.vpc.upa;

import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.expressions.Expression;
import net.vpc.upa.expressions.UserExpression;
import net.vpc.upa.types.DataType;
import net.vpc.upa.types.StructType;

import java.util.List;


public class KeyType extends StructType {
    //    private KeyInputType keyInputType;
    private Expression filter;
    private Entity entity;

    public KeyType(Entity entity)  {
        this(entity, (Expression) null, true);
    }

    public KeyType(Entity entity, String filter, boolean nullable)  {
        this(entity, filter == null ? null : new UserExpression(filter), nullable);
    }

    public KeyType(Entity entity, boolean nullable)  {
        this(entity, (Expression) null, nullable);
    }

    public KeyType(Entity entity, Expression filter, boolean nullable)  {
        super(entity.getName(), Key.class, constructorFieldNames(entity), constructorFieldTypes(entity), nullable);
        this.entity = entity;
        this.filter = filter;
    }

    public Expression getFilter() {
        return filter;
    }

    public void setFilter(Expression filter) {
        this.filter = filter;
    }


    public Entity getEntity() {
        return entity;
    }

    private static String[] constructorFieldNames(Entity entity)  {
        List<Field> primaryFields = entity.getIdFields();
        String[] fs = new String[primaryFields.size()];
        for (int i = 0; i < fs.length; i++) {
            fs[i] = primaryFields.get(i).getName();
        }
        return fs;
    }

    private static DataType[] constructorFieldTypes(Entity entity)  {

        List<Field> primaryFields = entity.getIdFields();
        DataType[] dt = new DataType[primaryFields.size()];
        for (int i = 0; i < dt.length; i++) {
            dt[i] = primaryFields.get(i).getDataType();
        }
        return dt;
    }

    @Override
    public Object getItemValueAt(int index, Object value) {
        return value == null ? null : ((Key) value).getValue()[index];
    }

    @Override
    public Object getObjectForArray(Object[] value) {
        return entity.createId(value);
    }

    @Override
    public Object[] getArrayForObject(Object value) {
        return value == null ? null : ((Key) value).getValue();
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        if (!super.equals(o)) return false;

        KeyType keyType = (KeyType) o;

        if (filter != null ? !filter.equals(keyType.filter) : keyType.filter != null) return false;
        return entity != null ? entity.equals(keyType.entity) : keyType.entity == null;
    }

    @Override
    public int hashCode() {
        int result = super.hashCode();
        result = 31 * result + (filter != null ? filter.hashCode() : 0);
        result = 31 * result + (entity != null ? entity.hashCode() : 0);
        return result;
    }
}
