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

import java.util.ArrayList;
import java.util.List;

public class ConstraintsEvent {

    private List<ConstraintsException> errors = new ArrayList<ConstraintsException>(1);

    /**
     * The object on which the Event initially occurred.
     */
    protected transient Object source;

    /**
     * Constructs a prototypical Event.
     *
     * @param source The object on which the Event initially occurred.
     * @throws IllegalArgumentException if source is null.
     */
    public ConstraintsEvent(Object source) {
        if (source == null)
            throw new net.vpc.upa.exceptions.IllegalArgumentException("null source");

        this.source = source;
    }

    /**
     * The object on which the Event initially occurred.
     *
     * @return The object on which the Event initially occurred.
     */
    public Object getSource() {
        return source;
    }

    public ConstraintsEvent add(ConstraintsException e) {
        errors.add(e);
        return this;
    }

    public ConstraintsEvent remove(ConstraintsException e) {
        errors.remove(e);
        return this;
    }

    public int countErrors() {
        return errors.size();
    }

    public ConstraintsException getConstraints(int pos) {
        return (ConstraintsException) errors.get(pos);
    }

    @Override
    public String toString() {
        return "ConstraintsEvent{" + getClass().getName() + "[source=" + source + "]" + __concatPaths(errors.toArray(), ",\n", true) + '}';
    }

    private static String __concatPaths(Object[] paths, String separator, boolean ignoreNull) {
        if (paths == null || paths.length == 0) {
            return "";
        }
        StringBuilder sb = new StringBuilder();
        if (paths[0] != null && paths[0].toString().length() > 0) {
            sb.append(paths[0]);
        } else if (!ignoreNull) {
            sb.append(separator);
        }
        for (int i = 1; i < paths.length; i++) {
            if (paths[i] != null && paths[i].toString().length() != 0 || !ignoreNull) {
                int x = 0;
                if (sb.length() > separator.length() - 1 && sb.substring(sb.length() - separator.length()).equals(separator)) {
                    x++;
                }
                if (paths[i].toString().substring(0, separator.length()).equals(separator)) {
                    x += 2;
                }
                switch (x) {
                    case 0: // '\0'
                        sb.append(separator).append(paths[i]);
                        break;

                    case 1: // '\001'
                    case 2: // '\002'
                        sb.append(paths[i]);
                        break;

                    case 3: // '\003'
                        sb.deleteCharAt(sb.length() - 1).append(paths[i]);
                        break;
                }
            }
        }

        return sb.toString();
    }
}
