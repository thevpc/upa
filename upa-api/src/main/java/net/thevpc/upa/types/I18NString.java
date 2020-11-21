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
package net.thevpc.upa.types;

import net.thevpc.upa.exceptions.IllegalUPAArgumentException;

import java.util.*;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 8/23/12 2:30 AM
 */
public class I18NString {

    private List<String> keys;
    private String defaultValue;

    public String getDefaultValue() {
        return defaultValue;
    }

    public I18NString setDefaultValue(String defaultValue) {
        I18NString n = new I18NString(keys);
        n.defaultValue = defaultValue;
        return n;
    }

    public I18NString(String... keys) {
        this(Arrays.asList(keys));
    }

    public I18NString(List<String> keys) {
        if (keys == null) {
            throw new IllegalUPAArgumentException();
        }
        this.keys = new ArrayList<String>(keys);
    }

    public String getKey(int index) {
        if(keys==null){
            throw new ArrayIndexOutOfBoundsException(index);
        }
        return keys.get(index);
    }

    public List<String> getKeys() {
        return keys==null? Collections.EMPTY_LIST:keys;
    }

    public I18NString append(I18NString path) {
        if (path == null) {
            throw new IllegalUPAArgumentException();
        }
        LinkedHashSet<String> a = new LinkedHashSet<String>();
        for (String key1 : keys) {
            for (String key2 : path.keys) {
                String s = key1.isEmpty() ? key2 : key2.isEmpty() ? key1 : (key1 + "." + key2);
                if (!a.contains(s)) {
                    a.add(s);
                }
            }
        }
        return new I18NString(a.toArray(new String[a.size()]));
    }

    public I18NString appendNonNull(String path) {
        if (path == null || path.isEmpty()) {
            return this;
        }
        return append(path);
    }
    
    public I18NString append(String path) {
        if (path == null || path.isEmpty()) {
            throw new IllegalUPAArgumentException();
        }
        ArrayList<String> a = new ArrayList<String>(keys.size());
        for (String key : keys) {
            a.add(key.isEmpty() ? path : key + "." + path);
        }
        return new I18NString(a);
    }

    public I18NString union(I18NString other) {
        ArrayList<String> a = new ArrayList<String>(this.keys.size() + other.keys.size());
        a.addAll(this.keys);
        a.addAll(other.keys);
        I18NString b = new I18NString(a);
        String t = defaultValue;
        if (t == null) {
            t = other.defaultValue;
        }
        b.defaultValue = t;
        return b;
    }

    public I18NString union(String other) {
        if (other == null || other.isEmpty()) {
            throw new IllegalUPAArgumentException();
        }
        ArrayList<String> a = new ArrayList<String>(this.keys.size() + 1);
        a.addAll(this.keys);
        a.add(other);
        return new I18NString(a);
    }

    @Override
    public String toString() {
        StringBuilder b = new StringBuilder();
        if (defaultValue != null) {
            b.append(defaultValue);
            if (!keys.isEmpty()) {
                b.append(":");
            }
        }
        for (String key : keys) {
            if (b.length() > 0) {
                b.append("|");
            }
            b.append(key);
        }
        return b.toString();
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) {
            return true;
        }
        if (o == null || getClass() != o.getClass()) {
            return false;
        }

        I18NString that = (I18NString) o;

        if (defaultValue != null ? !defaultValue.equals(that.defaultValue) : that.defaultValue != null) {
            return false;
        }

        if (keys != null ? !keys.equals(that.keys) : that.keys != null) {
            return false;
        }

        return true;
    }

    @Override
    public int hashCode() {
        int hash = 3;
        hash = 71 * hash + (this.keys != null ? this.keys.hashCode() : 0);
        hash = 71 * hash + (this.defaultValue != null ? this.defaultValue.hashCode() : 0);
        return hash;
    }

}
