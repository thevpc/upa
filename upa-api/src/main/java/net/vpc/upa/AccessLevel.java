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

/**
 * AccessLevel defines access level for field manipulation and retrieval. Default value is PUBLIC.
 * For each field, an insertAccessLevel, updateAccessLevel and readAccessLevel are defined.
 * <p>
 * Public access level means that every end used should have the ability
 * to modify/query the field (for insertion, for update or for retrieval)
 * This is most likely the very usual case
 * </p>
 * <p>
 * Protected access level means that only application should have the ability to modify/query the field (for insertion, for update or for retrieval)
 * This is most likely when the field is created by developer wut should net be "used" by end users
 * </p>
 * <p>
 * Private access level means that only ORM (UPA Framework or one of its extensions) should have the ability to modify/query the field (for insertion, for update or for retrieval).
 * This is most likely when the field is generated by the ORM
 * </p>
 * <p>
 * Default access level is a synonym  of PUBLIC access level.
 * Particularly when used in @Field annotation, the default value is ignored and older value is retained.
 * </p>
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public enum AccessLevel {
    /**
     * Default access level is a synonym  of PUBLIC access level.
     * Particularly when used in @Field annotation, the default value is ignored and older value is retained.
     */
    DEFAULT,

    /**
     * Private access level means that only ORM (UPA Framework or one of its extensions) should have the ability to modify/query the field (for insertion, for update or for retrieval).
     * This is most likely when the field is generated by the ORM
     */
    PRIVATE,

    /**
     * Protected access level means that only application should have the ability to modify/query the field (for insertion, for update or for retrieval)
     * This is most likely when the field is created by developer but should net be "used" by end users.
     * Actually one should always check :
     * UPA.getPersistenceUnit().getSecurityManager().isAllowedRead(field)
     * or
     * UPA.getPersistenceUnit().getSecurityManager().isAllowedWrite(field)
     * Before reading/writing the field
     */
    PROTECTED,

    /**
     * Public access level means that every end used should have the ability
     * to modify/query the field (for insertion, for update or for retrieval)
     * This is most likely the very usual case
     */
    PUBLIC,
}
