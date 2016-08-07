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
package net.vpc.upa.types;


public class ConstraintsException extends RuntimeException {
    private String name;
    private Object[] parameters;

    public ConstraintsException() {
    }

    public ConstraintsException(Throwable cause) {
        super(cause);
    }

    public ConstraintsException(String message, Throwable cause) {
        super(message, cause);
    }

    public String toString2() {
        String content = "";
        if (name != null) {
            content = content + "(" + name + ")";
        }
        if (getMessage() != null) {
            content = content + ":" + getMessage();
        }
        return content;
    }

    @Override
    public String toString() {
        return getMessage();
    }

    public ConstraintsException(String msg) {
        super(msg);
    }

    public ConstraintsException(String msg, String name, String description, Object value, Object... parameters) {
        super(msg);
        this.name = name;
        Object[] allParameters;
        if (parameters == null || parameters.length == 0) {
            allParameters = new Object[]{
                    name,
                    description,
                    value};
        } else {
            allParameters = new Object[parameters.length + 3];
            allParameters[0] = name;
            allParameters[1] = description;
            allParameters[2] = value;
            System.arraycopy(parameters, 0, allParameters, 3, parameters.length);
        }

        this.parameters = allParameters;
    }

    public String getName() {
        return name;
    }

    public Object[] getParameters() {
        return parameters;
    }

}
