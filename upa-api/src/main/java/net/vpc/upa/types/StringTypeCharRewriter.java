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
package net.vpc.upa.types;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 9/29/12 1:45 AM
 */
public class StringTypeCharRewriter implements TypeValueRewriter {
    protected String from;
    protected String to;

    public StringTypeCharRewriter(String from, String to) {
        this.from = from;
        this.to = to;
        if (from == null || to == null || from.length() == 0 || from.length() != to.length()) {
            throw new net.vpc.upa.exceptions.IllegalArgumentException();
        }
    }

    public String getFrom() {
        return from;
    }

    public String getTo() {
        return to;
    }

    @Override
    public Object rewriteValue(Object typeValue, String name, String description, DataType type) throws ConstraintsException {
        if (typeValue != null && typeValue instanceof String) {
            char[] c = ((String) typeValue).toCharArray();
            boolean updated = false;
            for (int i = 0; i < c.length; i++) {
                int j = from.indexOf(c[i]);
                if (j >= 0) {
                    c[i] = to.charAt(j);
                    updated = true;
                }
            }
            return updated ? new String(c) : typeValue;
        }
        return typeValue;
    }


}
