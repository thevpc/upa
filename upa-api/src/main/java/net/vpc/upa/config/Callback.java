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
 * Callback Annotation is used for all Callback definitions
 * A Callback is a Pojo class that is called when appropriate event happens.
 * Callback class can define one or more "event" methods which are decorated
 * with the following annotations
 * <ul>
 *     <li>@OnCreate</li>
 *     <li>@OnPreCreate</li>
 *     <li>@OnAlter</li>
 *     <li>@OnPreAlter</li>
 *     <li>@OnDrop</li>
 *     <li>@OnPreDrop</li>
 *     <li>@OnInit</li>
 *     <li>@OnPreInit</li>
 *     <li>@OnPersist</li>
 *     <li>@OnPrePersist</li>
 *     <li>@OnRemove</li>
 *     <li>@OnPreRemove</li>
 *     <li>@OnReset</li>
 *     <li>@OnPreReset</li>
 *     <li>@OnUpdate</li>
 *     <li>@OnPreUpdate</li>
 *     <li>@OnUpdateFormula</li>
 *     <li>@OnPreUpdateFormula</li>
 * </ul>
 * Callback are also called if implementing one of the following interfaces
 * <ul>
 * <li>PackageDefinitionListener</li>
 * <li>SectionDefinitionListener</li>
 * <li>EntityDefinitionListener</li>
 * <li>FieldDefinitionListener</li>
 * <li>IndexDefinitionListener</li>
 * <li>TriggerDefinitionListener</li>
 * <li>RelationshipDefinitionListener</li>
 * <li>PersistenceUnitListener</li>
 * <li>EntityInterceptor</li>
 * </ul>
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 9/4/12 11:00 PM
 */
@Target(value = ElementType.TYPE)
@Retention(value = RetentionPolicy.RUNTIME)
public @interface Callback {

    /**
     * callback name, not mandatory
     * @return
     */
    String name() default "";

    /**
     * if applicable, the Callback will be bound to entities
     * (depending of the Callback type) which name matches the filter
     * (shell wildcards are allowed)
     * @return
     */
    String filter() default "";

    /**
     * true all entities,including Systems Entities should be tracked
     * @return true all entities,including Systems Entities should be tracked
     */
    boolean trackSystemObjects() default false;

    /**
     * annotation config defines how this annotation must be handled
     *
     * @return annotation configuration
     */
    Config config() default @Config();
}
