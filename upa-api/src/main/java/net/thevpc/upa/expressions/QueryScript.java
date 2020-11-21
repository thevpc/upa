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
package net.thevpc.upa.expressions;

import java.util.ArrayList;

public class QueryScript {
    private ArrayList<String> lines;

    public QueryScript() {
        lines = new ArrayList<String>();
    }

    public void addStatement(String stmt) {
        if (stmt != null) {
            lines.add(stmt);
        }
    }

    public void addScript(QueryScript script) {
        if (script != null) {
            for (int i = 0; i < script.size(); i++) {
                addStatement(script.getStatement(i));
            }
        }
    }

    public String getStatement(int i) {
        return lines.get(i);
    }

    public int size() {
        return lines.size();
    }

    //    public String toSql() {
//        StringBuilder sb = new StringBuilder();
//        for (int i = 0; i < lines.size(); i++) {
//            if (i > 0) {
//                sb.append("\n");
//            }
//            String s = lines.get(i);
//            if (s != null) {
//                sb.append(s);
//                if (!s.endsWith(";")) {
//                    sb.append(" ;");
//                }
//            }
//        }
//
//        return sb.toString();
//    }
//
    public String toString() {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < lines.size(); i++) {
            if (i > 0) {
                sb.append("\n");
            }
            sb.append(lines.get(i));
        }

        return sb.toString();
    }

}
