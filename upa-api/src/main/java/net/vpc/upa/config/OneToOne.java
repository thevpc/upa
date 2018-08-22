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

import net.vpc.upa.RelationshipType;

import java.lang.annotation.ElementType;
import java.lang.annotation.Retention;
import java.lang.annotation.RetentionPolicy;
import java.lang.annotation.Target;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @ManyToOne are equivalents to JPA's ManyToOne
 * <p/>
 * Example 1 : countryId defines a FK to Country Entity. No extra field will be created
 * <pre>
 *  public class Client {
 *     @ManyToOne(targetEntityType=Country.class)
 *     int countryId;
 *  }
 * </pre>
 * <p/>
 * <p/>
 * <p/>
 * <p/>
 * Example 2 : country defines a FK to Entity named "Country"
 * <pre>
 *  public class Client {
 *     @ManyToOne(targetEntityType="Country")
 *     int countryId;
 *  }
 * </pre>
 * <p/>
 * <p/>
 * Example 3 : country defines a FK to Country Entity. updates to countryId are ignore and
 * overridden by associated country updates (country is actually readOnly)
 * <pre>
 *  public class Client {
 *     int countryId;
 *     @ManyToOne(mappedTo="countryId")
 *     Country country;
 *  }
 * </pre>
 * <p/>
 * Example 4 : country defines a FK to Country Entity. updates to country are ignore and
 * overridden by associated countryId updates (countryId is actually readOnly)
 * <pre>
 *  public class Client {
 *     @ManyToOne(mappedTo="country")
 *     int countryId;
 *     Country country;
 *  }
 * </pre>
 * <p/>
 * In this example, Country reference is updatable via countryId and not country
 * <p/>
 * <pre>
 *  public class Client {
 *     @ManyToOne
 *     int countryId;
 *     @ManyToOne(mappedBy="countryId")
 *     Country country;
 *  }
 * </pre>
 * @creationdate 8/28/12 10:17 PM
 */
@Target(value = {ElementType.METHOD, ElementType.FIELD})
@Retention(value = RetentionPolicy.RUNTIME)
public @interface OneToOne {

    String name() default "";

    /**
     * relation filter expression defines a simple way to restrict possible values in the relation.
     * Only Target Entity instances that verifies that filter condition are eligible to be references
     * the expression may use two special keywords :
     * this : refers to the current entity (Source Entity)
     * that : refers to the referenced entity (Target Entity)
     * In the following example only instances of B having the same discriminator as the A instance
     * (for each A instance) are eligible:
     * <pre>
     *
     * &#64;Entity
     * class A{
     *     &#64;Id int id;
     *     int discriminator;
     *     &#64;ManyToOne(filter="this.discriminator=that.otherDiscriminator")
     *     B b;
     * }
     *
     * &#64;Entity
     * class B{
     *     &#64;Id int id;
     *     int otherDiscriminator;
     * }
     *
     * </pre>
     * Recommendation :
     * It is recommended not to use private fields (generated by framework) in such expressions
     * as some of the expression may be evaluated outside persistence sandbox. For instance do
     * not use foreign key ids.
     * @return filter expression
     */
    String filter() default "";

    String[] mappedTo() default {};

    RelationshipType relationType() default RelationshipType.DEFAULT;

    String targetEntity() default "";

    Class targetEntityType() default void.class;

    /**
     * annotation config defines how this annotation must be handled
     *
     * @return annotation configuration
     */
    ItemConfig config() default @ItemConfig();
}