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
    private Relationship relationship;
    private Entity entity;

    public KeyType(Entity entity, String filter, boolean nullable) throws UPAException {
        this(entity, filter == null ? null : new UserExpression(filter), nullable);
    }

    public KeyType(Entity entity, Expression filter, boolean nullable) throws UPAException {
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

    public Relationship getRelationship() {
        return relationship;
    }

    public void setRelationship(Relationship r) {
        relationship = r;
    }

    private static String[] constructorFieldNames(Entity entity) throws UPAException {
        List<Field> primaryFields = entity.getPrimaryFields();
        String[] fs = new String[primaryFields.size()];
        for (int i = 0; i < fs.length; i++) {
            fs[i] = primaryFields.get(i).getName();
        }
        return fs;
    }

    private static DataType[] constructorFieldTypes(Entity entity) throws UPAException {

        List<Field> primaryFields = entity.getPrimaryFields();
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

}
