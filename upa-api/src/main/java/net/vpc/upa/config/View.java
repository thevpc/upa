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

import net.vpc.upa.extensions.ViewEntityExtensionDefinition;

import java.lang.annotation.ElementType;
import java.lang.annotation.Retention;
import java.lang.annotation.RetentionPolicy;
import java.lang.annotation.Target;

/**
 *
 * Views are compiled queries (mapped as RDBMS Views if supported)
 * but defined as UPQL query expression
 * Here is an example :
 * <pre>
 *     @View(
 * query = "Select o from Product o where o.country='TN'"
 * )
 * public class TunisianProducts {
 * @Id @Sequence
 * private int id;
 * private String name;
 *
 * public int getId() {
 * return id;
 * }
 *
 * public void setId(int id) {
 * this.id = id;
 * }
 *
 * public String getName() {
 * return name;
 * }
 *
 * public void setName(String name) {
 * this.name = name;
 * }
 *
 * }
 *
 * </pre>
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 8/28/12 8:28 PM
 */
@Target(value = {ElementType.TYPE})
@Retention(value = RetentionPolicy.RUNTIME)
public @interface View {

    /**
     * View Query
     * @return UPQL query
     */
    String query() default "";

    /**
     * View Query defined as ViewEntityExtensionDefinition class.
     * If defined will replace the String query defined in query()
     * @return
     */
    Class<ViewEntityExtensionDefinition> spec() default ViewEntityExtensionDefinition.class;

    /**
     * annotation config defines how this annotation must be handled
     *
     * @return annotation configuration
     */
    Config config() default @Config();
}
