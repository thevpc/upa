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

import net.vpc.upa.types.PlatformUtils;

/**
 * Created by IntelliJ IDEA.
 * User: vpc
 * Date: 29 janv. 2006
 * Time: 15:26:00
 * To change this template use File | Settings | File Templates.
 */
public class QLParameter {

    private QLParameterType parameterType;
    private String typeName;
    private String id;
    private String title;
    private String description;
    private String expression;

    public QLParameter(QLParameterType QLParameterType, String typeName, String expression, String name, String title, String description) {
        this.parameterType = QLParameterType;
        this.typeName = typeName;
        this.expression = expression;
        this.id = name;
        this.title = title;
        this.description = description;
        this.expression = expression;
    }

    public String getDescription() {
        return description;
    }

    public String getId(int index) {
        if (index == 0) {
            return getId();
        }
        return getId() + "." + (index + 1);
    }

    public String getId() {
        return id;
    }

    public String getTitle() {
        return title;
    }

    public QLParameterType getParameterType() {
        return parameterType;
    }

    public String getTypeName() {
        return typeName;
    }

    public String getExpression() {
        return expression;
    }

    public QLParameter copy() {

        return new QLParameter(parameterType, typeName, expression, id, title, description);
    }

}
