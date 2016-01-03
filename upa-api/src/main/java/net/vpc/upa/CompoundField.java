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

import java.util.List;

/**
 * A compound field defines a simple way for embeddable structures in Entities.
 * A compound Field defines a "super" field that is composed of a set of primitive fields.
 * Compound fields can not include other compound fields.
 */
public interface CompoundField extends Field {


    /**
     * all inner fields
     *
     * @return all fields
     */
    public List<PrimitiveField> getFields();

    /**
     * field by position
     * @param index position
     * @return Field at the given position
     */
    public PrimitiveField getFieldAt(int index);

    /**
     * field by name
     * @param name name of the field
     * @return Field with the given name
     */
    public PrimitiveField getField(String name);

    /**
     * return index of the given field or -1 if not found
     * @param child field to look for
     * @return index of the given field or -1 if not found
     */
    public int indexOfField(PrimitiveField child);

    /**
     * return index of the given field or -1 if not found
     * @param fieldName field to look for
     * @return index of the given field or -1 if not found
     */
    public int indexOfField(String fieldName);

    /**
     * leading (very first) field
     * @return leading (very first) field
     */
    public PrimitiveField getLeadingField();

    /**
     * number of primitive fields in the compound field
     * @return number of primitive fields in the compound field
     */
    public int getFieldsCount();

    /**
     * flatten an object value to resolve every primitive field value
     * @param object to flatten
     * @return array of primitive value (in the same order of the fields definition)
     */
    public abstract Object[] getPrimitiveValues(Object object);

    /**
     * composed single value equivalent to the given array
     * @param values flattened values to compose
     * @return composed single value equivalent to the given array
     */
    public abstract Object getCompoundValue(Object[] values);
}
