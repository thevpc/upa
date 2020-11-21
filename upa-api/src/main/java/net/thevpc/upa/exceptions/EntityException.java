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
package net.thevpc.upa.exceptions;

import net.thevpc.upa.Entity;
import net.thevpc.upa.types.I18NString;

import java.util.ArrayList;
import java.util.Arrays;

public class EntityException extends UPAException {
    public EntityException(String message) {
        super(message);
    }

    public EntityException(Entity entity, String operationName, String errorName) {
        super(entity.getI18NTitle().append("Operations").append(operationName).append(errorName), entity.getI18NTitle());
    }

    public EntityException(Entity entity, String operationName, String errorName, Object... params) {
        super(entity.getI18NTitle().append("Operations").append(operationName), combineParams(entity.getI18NTitle(), params));
    }

    public EntityException(Throwable cause, Entity entity, String operationName, String errorName, Object... params) {
        super(cause, entity.getI18NTitle().append("Operations").append(operationName), combineParams(entity.getI18NTitle(), params));
    }

    public EntityException() {
    }

    public EntityException(String entityName,String operationName, String errorName, Object... parameters) {
        super(new I18NString("Entity").append(entityName).append("Operations").append(operationName).append(errorName), parameters);
    }

    public EntityException(I18NString message, Object... parameters) {
        super(message, parameters);
    }

    public EntityException(Throwable cause, I18NString messageId, Object... parameters) {
        super(cause, messageId, parameters);
    }

    private static Object[] combineParams(I18NString entityTitle, Object[] params) {
        ArrayList<Object> a = new ArrayList<Object>(params.length + 1);
        a.add(entityTitle);
        a.addAll(Arrays.asList(params));
        return a.toArray();
    }

    public String toString() {
        String s = getClass().getName();
        String message = getLocalizedMessage();
        return (message != null) ? (message) : s;
    }
}
