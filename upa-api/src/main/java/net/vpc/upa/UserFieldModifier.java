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

public enum UserFieldModifier {

    /**
     * ID fields defines the Entity Identifier's fields which are mapped to the
     * Table's primary key. An Entity may define zero or many ID fields but is
     * is recommended to define at least one ID field. When many fields are
     * defines as ID, the order in which fields are defines happens to be the
     * same order the primary keys definition. An ID field may be a compound
     * field but could not be dynamic field. ID fields could not be transient
     * (QUERY, VIEW, ...)
     */
    ID,
    /**
     * Main field is the user friendly field that helps distinguishing distinct
     * entities. This is, in most cases the "name" or "label" of the entity such
     * as Client's name or Company's name. An Entity may define zero or one MAIN
     * Field but is is recommended to de define exactly one MAIN field. If many
     * MAIN fields (more than one) are defined, only the first one is to be
     * considered as MAIN. If no field is defined as MAIN, first Id field will be
     * taken if it exists.
     */
    MAIN,
    /**
     * SUMMARY field is a field that "summaries" and "highlights" significant
     * information needed to be known at first degree. SUMMARY fields are less
     * important than MAIN field be should be more significant than other
     * fields. An Entity may define zero or more SUMMARY Fields. a "COMPUTER"
     * Product's brand maybe considered as a "SUMMARY" information, an other example
     * is an "Email"'s "sender" may also be considered as "SUMMARY" field. Dynamic
     * UI builder frameworks may use this information to force "Listing" of such
     * fields along with MAIN field.
     */
    SUMMARY,


    /**
     * TRANSIENT field is a field this is not managed by the framework and so
     * never stored nor retrieved
     */
    TRANSIENT,

    PERSIST,

    UPDATE,

    SELECT,

    COMPILED,

    LIVE,


    SYSTEM,

    UNIQUE,

    INDEX

}

