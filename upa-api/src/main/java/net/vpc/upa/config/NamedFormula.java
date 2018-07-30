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

import net.vpc.upa.FormulaType;

import java.lang.annotation.ElementType;
import java.lang.annotation.Retention;
import java.lang.annotation.RetentionPolicy;
import java.lang.annotation.Target;

/**
 * The following formulas in fields formula1 and formula2 are equivalent that simply concatenates str1 and str2.
 * formula1 uses UPQL formula and formula2 uses.
 * <p>ddd</p>
 *<blockquote><pre>
 * &#64;Entity
 * public class Example{
 *     private int id;
 *     private String str1;
 *     private String str2;

 *     &#64;Formula(value="concat(this.str1,this.str2)")
 *     private String formula1;

 *     &#64;Formula(name="myconcat")
 *     private String formula2;
 * }
 *
 * &#64;Callback
 * public class ExampleSupport{
 *    &#64;NamedFormula
 *    public String myconcat({@link net.vpc.upa.CustomFormulaContext} ctx){
 *      String str1=ctx.getUpdateDocument().getString("str1")
 *      String str2=ctx.getUpdateDocument().getString("str2")
 *      return str1+str2;
 *    }
 * }
 * </pre></blockquote>
 * public Double alpha14AD(CustomFormulaContext ctx){
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
@Target(value = {ElementType.METHOD})
@Retention(value = RetentionPolicy.RUNTIME)
public @interface NamedFormula {

    /**
     * if defined will consider named Custom formula registered in PersistenceUnit
     */
    String name() default "";

    /**
     * annotation config defines how this annotation must be handled
     *
     * @return annotation configuration
     */
    ItemConfig config() default @ItemConfig();
}
