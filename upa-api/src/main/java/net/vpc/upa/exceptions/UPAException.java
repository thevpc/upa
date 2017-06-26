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
package net.vpc.upa.exceptions;

import net.vpc.upa.types.I18NString;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class UPAException extends RuntimeException {
    private I18NString messageId;
    private Object[] parameters;

    public UPAException() {
        this("UPAException");
    }

    public UPAException(String message, Object... parameters) {
        this(new I18NString(message), parameters);
    }

    public UPAException(I18NString message, Object... parameters) {
        this(null, message, parameters);
    }

    public UPAException(Throwable cause, I18NString messageId, Object... parameters) {
        super(buildMessage(messageId, parameters), cause);
        this.messageId = messageId;
        this.parameters = parameters;
    }


    public I18NString getMessageId() {
        return messageId;
    }

    public Object[] getParameters() {
        return parameters;
    }

    private static String buildMessage(I18NString messageId, Object... parameters) {
        StringBuilder b = new StringBuilder();
        b.append(messageId == null ? "UPAException" : messageId.toString());
        if (parameters.length > 0) {
            b.append("(");
            for (int i = 0; i < parameters.length; i++) {
                if (i > 0) {
                    b.append(",");
                }
                b.append(parameters[i]);
            }
            b.append(")");
        }
        return b.toString();
    }
}
