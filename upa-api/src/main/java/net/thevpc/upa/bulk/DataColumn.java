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
package net.thevpc.upa.bulk;

import net.thevpc.upa.exceptions.UnexpectedException;
import net.thevpc.upa.types.DataType;

import java.util.HashSet;
import java.util.LinkedHashSet;
import java.util.Set;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class DataColumn implements Cloneable {

    private int index;
    private String name;
    private Set<String> extraNames = new HashSet<String>();
    private String title;
    private DataType dataType;
    private ValueConverter rawValueConverter;
    private ValueConverter valueConverter;
    private ValueValidator valueValidator;
    private boolean trimValue;

    public DataColumn() {
    }

    public DataColumn(int index, String name) {
        this.index = index;
        this.name = name;
    }

    public int getIndex() {
        return index;
    }

    public void setIndex(int index) {
        this.index = index;
    }

    public DataColumn updateIndex(int index) {
        setIndex(index);
        return this;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public DataColumn updateName(String name) {
        setName(name);
        return this;

    }

    public String getTitle() {
        return title;
    }

    public void setTitle(String title) {
        this.title = title;
    }

    public DataColumn updateTitle(String title) {
        setTitle(title);
        return this;

    }

    public DataType getDataType() {
        return dataType;
    }

    public void setDataType(DataType dataType) {
        this.dataType = dataType;
    }

    public DataColumn updateDataType(DataType dataType) {
        setDataType(dataType);
        return this;

    }

    public ValueConverter getValueConverter() {
        return valueConverter;
    }

    public void setValueConverter(ValueConverter valueConverter) {
        this.valueConverter = valueConverter;
    }

    public DataColumn updateValueConverter(ValueConverter valueConverter) {
        setValueConverter(valueConverter);
        return this;
    }

    public ValueValidator getValueValidator() {
        return valueValidator;
    }

    public void setValueValidator(ValueValidator valueValidator) {
        this.valueValidator = valueValidator;
    }

    public DataColumn updateValueValidator(ValueValidator valueValidator) {
        setValueValidator(valueValidator);
        return this;

    }

    public ValueConverter getRawValueConverter() {
        return rawValueConverter;
    }

    public void setRawValueConverter(ValueConverter rawValueConverter) {
        this.rawValueConverter = rawValueConverter;
    }

    public DataColumn updateRawValueConverter(ValueConverter rawValueConverter) {
        setRawValueConverter(rawValueConverter);
        return this;
    }

    public boolean isTrimValue() {
        return trimValue;
    }

    public void setTrimValue(boolean trimValue) {
        this.trimValue = trimValue;
    }

    public DataColumn updateTrimValue(boolean trimValue) {
        setTrimValue(trimValue);
        return this;
    }

    public Set<String> getExtraNames() {
        return extraNames;
    }

    public void setExtraNames(Set<String> extraNames) {
        this.extraNames = extraNames;
    }

    public DataColumn updateExtraNames(Set<String> extraNames) {
        setExtraNames(extraNames);
        return this;
    }

    public Object copy() {
        try {
            DataColumn c = (DataColumn) super.clone();
            if (extraNames != null) {
                c.extraNames = new LinkedHashSet<String>(extraNames);
            }
            return c;
        } catch (CloneNotSupportedException ex) {
            throw new UnexpectedException("Missing Cloneable Interface Anchor for " + getClass().getName(), ex);
        }
    }

    @Override
    public String toString() {
        return "DataColumn{" + "index=" + index + ", name=" + name + ", title=" + title + '}';
    }
}
