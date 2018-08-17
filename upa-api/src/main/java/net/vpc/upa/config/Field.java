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

import net.vpc.upa.AccessLevel;
import net.vpc.upa.ProtectionLevel;
import net.vpc.upa.UserFieldModifier;

import java.lang.annotation.ElementType;
import java.lang.annotation.Retention;
import java.lang.annotation.RetentionPolicy;
import java.lang.annotation.Target;

/**
 * corresponds to the JPA
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @Id
 * @creationdate 8/28/12 10:17 PM
 */
@Target(value = {ElementType.METHOD, ElementType.FIELD})
@Retention(value = RetentionPolicy.RUNTIME)
public @interface Field {

    String path() default "";

    int position() default Integer.MIN_VALUE;

    String name() default "";

    String max() default "";

    String min() default "";

    String charsAccepted() default "";

    String charsRejected() default "";

    /**
     * String ==> regexpr number ==> decimal format date ==> date format
     *
     * @return
     */
    String format() default "";

    String layout() default "";

    int precision() default -1;

    int scale() default -1;

    BoolEnum nullable() default BoolEnum.DEFAULT;

    //    BoolEnum end() default BoolEnum.DEFAULT;
    UserFieldModifier[] modifiers() default {};

    UserFieldModifier[] excludeModifiers() default {};

    Class valueType() default void.class;

    String namedType() default "";

    String defaultValue() default "";

    String unspecifiedValue() default "";

    AccessLevel accessLevel() default AccessLevel.DEFAULT;

    AccessLevel persistAccessLevel() default AccessLevel.DEFAULT;

    AccessLevel updateAccessLevel() default AccessLevel.DEFAULT;

    AccessLevel readAccessLevel() default AccessLevel.DEFAULT;

    ProtectionLevel protectionLevel() default ProtectionLevel.DEFAULT;

    ProtectionLevel persistProtectionLevel() default ProtectionLevel.DEFAULT;

    ProtectionLevel updateProtectionLevel() default ProtectionLevel.DEFAULT;

    ProtectionLevel readProtectionLevel() default ProtectionLevel.DEFAULT;

    /**
     * annotation config defines how this annotation must be handled
     *
     * @return annotation configuration
     */
    ItemConfig config() default @ItemConfig();
}
