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

import java.io.Serializable;
import java.util.Date;

/**
 * Key is an abstract definition of any identifier on any entity. Keys can be composed.
 * Thus Key is defined as an Array of Objects and should be manipulated as such even though Identifier would be single, non composed value.
 * When Entity defines a single field as Identifier, Key represents an Array of One Single Element.
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public interface Key extends Serializable {

    /**
     * Update all Key values. <code>value</value> cannot be null and cannot contain null values
     *
     * @param value new values
     */
    void setValue(Object[] value);

    /**
     * an array of key values. The returned array cannot be null and cannot contain null values
     *
     * @return an array of key values
     */
    Object[] getValue();

    /**
     * Key as single value
     *
     * @return single instance as Object
     * @throws RuntimeException if multi-dimensional key
     */
    Object getObject();

    /**
     * Key as single String value
     *
     * @return single instance as String
     * @throws RuntimeException if multi-dimensional key
     */
    String getString();

    /**
     * Key as single int value
     *
     * @return single instance as int
     * @throws RuntimeException if multi-dimensional key
     */
    int getInt();

    /**
     * Key as single long value
     *
     * @return single instance as long
     * @throws RuntimeException if multi-dimensional key
     */
    long getLong();

    /**
     * Key as single date value
     *
     * @return single instance as date
     * @throws RuntimeException if multi-dimensional key
     */
    Date getDate();

    /**
     * Key portion at <code>index</code> position as string value
     *
     * @param index position
     * @return Key portion at <code>index</code> position as string value
     * @throws RuntimeException if invalid <code>index</code>
     */
    String getStringAt(int index);

    /**
     * Key portion at <code>index</code> position as Object value
     *
     * @param index position
     * @return Key portion at <code>index</code> position as Object value
     * @throws RuntimeException if invalid <code>index</code>
     */
    Object getObjectAt(int index);

    /**
     * Key portion at <code>index</code> position as int value
     *
     * @param index position
     * @return Key portion at <code>index</code> position as int value
     * @throws RuntimeException if invalid <code>index</code>
     */
    int getIntAt(int index);

    /**
     * Key portion at <code>index</code> position as long value
     *
     * @param index position
     * @return Key portion at <code>index</code> position as long value
     * @throws RuntimeException if invalid <code>index</code>
     */
    long getLongAt(int index);

    /**
     * Key portion at <code>index</code> position as date value
     *
     * @param index position
     * @return Key portion at <code>index</code> position as date value
     * @throws RuntimeException if invalid <code>index</code>
     */
    Date getDateAt(int index);
}
