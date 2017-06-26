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

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public final class Sequence implements Formula {

    private SequenceStrategy strategy = SequenceStrategy.AUTO;
    private int initialValue = 1;
    private int allocationSize = 50;
    private String format;
    private String group;
    private String name;

    public Sequence() {
        this(SequenceStrategy.AUTO);
    }

    public Sequence(SequenceStrategy strategy) {
        this(strategy, 1, 50, null, null, null);
    }

    public Sequence(SequenceStrategy strategy, int initialValue, int allocationSize) {
        this(strategy, initialValue, allocationSize, null, null, null);
    }

    public Sequence(SequenceStrategy strategy, int seed, int allocationSize, String name, String group, String format) {
        this.strategy = strategy;
        this.initialValue = seed;
        this.allocationSize = allocationSize;
        this.format = format;
        this.group = group;
        this.name = name;
    }

    public SequenceStrategy getStrategy() {
        return strategy;
    }

    public String getFormat() {
        return format;
    }

    public void setFormat(String format) {
        this.format = format;
    }

    public String getGroup() {
        return group;
    }

    public void setGroup(String group) {
        this.group = group;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public int getInitialValue() {
        return initialValue;
    }

    public void setInitialValue(int seed) {
        this.initialValue = seed;
    }

    public int getAllocationSize() {
        return allocationSize;
    }

    public void setAllocationSize(int increment) {
        this.allocationSize = increment;
    }
}
