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
package net.thevpc.upa.config;

import net.thevpc.upa.UPA;
import net.thevpc.upa.persistence.PersistenceNameTransformer;

import java.lang.annotation.ElementType;
import java.lang.annotation.Retention;
import java.lang.annotation.RetentionPolicy;
import java.lang.annotation.Target;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 9/4/12 11:00 PM
 */
@Target(value = ElementType.TYPE)
@Retention(value = RetentionPolicy.RUNTIME)
public @interface PersistenceNameStrategy {

    String persistenceName() default UPA.UNDEFINED_STRING;

    Class customTypeName() default net.thevpc.upa.persistence.PersistenceNameStrategy.class;

    PersistenceNameFormat[] persistenceNameFormats() default {};


    /**
     * defines an implementation of {@link PersistenceNameTransformer} that
     * will be applied to persistence names
     * #{@link PersistenceNameTransformer}
     * @return persistence name transformer class name
     */
    Class transformerType() default PersistenceNameTransformer.class;

    /**
     * Top level pattern applied for Top Level Object names. This pattern will
     * be applied to Tables and constraints for instance but not to Column
     * names. Note that this naming strategy is applied after any specific
     * strategy defined in names() Pattern can include the following variables
     * <ul>
     * <li> * : replaces the exact value of the name</li>
     * <li> {ObjectName} : replaces the name in the given form</li>
     * <li> {object_name} : replaces the name in the given form</li>
     * </ul>
     *
     * @return Naming pattern for global scope objects
     */
    String globalPersistenceNameFormat() default UPA.UNDEFINED_STRING;

    String localPersistenceNameFormat() default UPA.UNDEFINED_STRING;

    String escape() default UPA.UNDEFINED_STRING;

    /**
     * annotation config defines how this annotation must be handled
     *
     * @return annotation configuration
     */
    ItemConfig config() default @ItemConfig();
}
