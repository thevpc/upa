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
package net.vpc.upa.bulk;

import net.vpc.upa.PortabilityHint;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class SheetColumn extends DataColumn implements Cloneable {

    private int skippedColumns;

    public SheetColumn() {
    }

    public int getSkippedColumns() {
        return skippedColumns;
    }

    public void setSkippedColumns(int skippedColumns) {
        this.skippedColumns = skippedColumns;
    }

    public DataColumn updateSkippedColumns(int skippedColumns) {
        setSkippedColumns(skippedColumns);
        return this;
    }

    @PortabilityHint(target = "C#", name = "suppress")
    @Override
    public DataColumn updateTrimValue(boolean trimValue) {
        return (SheetColumn) super.updateTrimValue(trimValue);
    }

    @PortabilityHint(target = "C#", name = "suppress")
    @Override
    public DataColumn updateRawValueConverter(ValueConverter rawValueConverter) {
        return (SheetColumn) super.updateRawValueConverter(rawValueConverter);
    }

    @PortabilityHint(target = "C#", name = "suppress")
    @Override
    public DataColumn updateValueValidator(ValueValidator valueValidator) {
        return (SheetColumn) super.updateValueValidator(valueValidator);
    }

    @PortabilityHint(target = "C#", name = "suppress")
    @Override
    public DataColumn updateValueConverter(ValueConverter valueConverter) {
        return (SheetColumn) super.updateValueConverter(valueConverter);
    }

    @PortabilityHint(target = "C#", name = "suppress")
    @Override
    public DataColumn updateTitle(String title) {
        return (SheetColumn) super.updateTitle(title);
    }

    @PortabilityHint(target = "C#", name = "suppress")
    @Override
    public DataColumn updateName(String name) {
        return (SheetColumn) super.updateName(name);
    }

    @PortabilityHint(target = "C#", name = "suppress")
    @Override
    public DataColumn updateIndex(int index) {
        return (SheetColumn) super.updateIndex(index);
    }

}
