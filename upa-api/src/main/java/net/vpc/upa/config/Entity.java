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
package net.vpc.upa.config;

import net.vpc.upa.EntityModifier;

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
public @interface Entity {

    /**
     * Entity Name
     *
     * @return Entity Name
     */
    String name() default "";

    String shortName() default "";

    /**
     * Entity Instances Type. When Not specified (or when it is set to
     * java.lang.Object), the current class is considered to be Entity Instances
     * Type (as does JPA). When Specified, the current class is an Entity
     * Descriptor rather than an Entity it self. In that case, the Entity Type
     * is given by the value of this property.
     *
     * @return entity Type
     */
    Class entityType() default void.class;

    /**
     * Entity ID Class Type. When Not Specified will be guessed by the
     * framework. Composite Types are resolved as net.vpc.upa.Key Type
     *
     * @return Entity ID Class Type
     */
    Class idType() default void.class;

    /**
     * Entity Modifiers
     *
     * @return Entity Modifiers
     */
    EntityModifier[] modifiers() default {};

    /**
     * Entity Modifiers
     *
     * @return Entity Modifiers
     */
    EntityModifier[] excludeModifiers() default {};

    /**
     * '/' Separated Entity Path as sequence of parent Package names
     *
     * @return Entity Path
     */
    String path() default "";

    /**
     * When true (default) the Entity Class is parsed for fields. This is
     * helpful when defining an Entity Descriptor (entityType value specified)
     * while ignoring all already defined fields in the target entityType.
     *
     * @return true if the Entity Class is parsed for fields
     */
    boolean useEntityTypeFields() default true;

    /**
     * When true (default) the Entity Class is parsed for modifiers. This is
     * helpful when defining an Entity Descriptor (entityType value specified)
     * while ignoring all already defined modifiers in the target entityType.
     *
     * @return true if the Entity Class is parsed for modifiers
     */
    boolean useEntityTypeModifiers() default true;

    /**
     * When true (default) the Entity Class is parsed for modifiers. This is
     * helpful when defining an Entity Descriptor (entityType value specified)
     * while ignoring all already defined modifiers in the target entityType.
     *
     * @return true if the Entity Class is parsed for modifiers
     */
    boolean useEntityTypeExtensions() default true;

    /**
     * list order is the default order used if no order is specified.
     * This can be useful for natural ordering (names, dates,...)
     * @return order expression with no UPAQL prefixes
     */
    String listOrder() default "";
    
    /**
     * archiving order is the default order used when importing/exporting items.
     * @return order expression with no UPAQL prefixes
     */
    String archivingOrder() default "";
    
    /**
     * annotation config defines how this annotation must be handled
     *
     * @return annotation configuration
     */
    Config config() default @Config();

}
