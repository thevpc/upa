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
package net.vpc.upa.config;

import java.lang.annotation.ElementType;
import java.lang.annotation.Retention;
import java.lang.annotation.RetentionPolicy;
import java.lang.annotation.Target;

/**
 * Specifies that the class is an entity or is an Entity Descriptor. To Its
 * simplest form, this annotation is similar to JPA @Entity Annotation.
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @Entity
 * @creationdate 8/28/12 10:14 PM
 */
@Target(value = ElementType.TYPE)
@Retention(value = RetentionPolicy.RUNTIME)
public @interface Column {

    /**
     * Entity Name
     * Optional, needed if the annotation is defined on a non entity class
     * If this annotation is defined on an entity class, defining this value
     * leads to an exception
     *
     * @return Entity Name
     */
    String entityName() default "";

    /**
     * Field Name
     * Optional, needed if the annotation is defined on a non entity field
     * If this annotation is defined on an entity field, defining this value
     * leads to an exception
     *
     * @return Entity Name
     */
    String fieldName() default "";

    /**
     * column name
     *
     * @return
     */
    String value();

    String table() default "";

    String catalog() default "";

    String schema() default "";

    String columnDefinition() default "";

    DatabaseCondition condition() default @DatabaseCondition();

    /**
     * annotation config defines how this annotation must be handled
     *
     * @return annotation configuration
     */
    ItemConfig config() default @ItemConfig();

}
