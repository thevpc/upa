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

import net.thevpc.upa.PortabilityHint;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class TextFixedWidthColumn extends DataColumn implements Cloneable {

    private int skippedColumns;
    private String skippedColumnsChars;
    private int columnWidth;
    private TextAlignment textAlignment;
    private String defaultPaddingChars;
    private String leftPaddingChars;
    private String rightPaddingChars;

    public TextFixedWidthColumn() {
    }

    public TextFixedWidthColumn(int columnWidth) {
        this.columnWidth = columnWidth;
    }

    public int getSkippedColumns() {
        return skippedColumns;
    }

    public void setSkippedColumns(int skippedColumns) {
        this.skippedColumns = skippedColumns;
    }

    public TextFixedWidthColumn updateSkippedColumns(int skippedColumns) {
        setSkippedColumns(skippedColumns);
        return this;
    }

    public int getColumnWidth() {
        return columnWidth;
    }

    public void setColumnWidth(int columnWidth) {
        this.columnWidth = columnWidth;
    }

    public TextFixedWidthColumn updateColumnWidth(int columnWidth) {
        setColumnWidth(columnWidth);
        return this;
    }

    public TextAlignment getTextAlignment() {
        return textAlignment;
    }

    public void setTextAlignment(TextAlignment textAlignment) {
        this.textAlignment = textAlignment;
    }

    public TextFixedWidthColumn updateTextAlignment(TextAlignment textAlignment) {
        setTextAlignment(textAlignment);
        return this;
    }

    public String getDefaultPaddingChars() {
        return defaultPaddingChars;
    }

    public void setDefaultPaddingChars(String defaultPaddingChars) {
        this.defaultPaddingChars = defaultPaddingChars;
    }

    public TextFixedWidthColumn updateDefaultPaddingChars(String defaultPaddingChars) {
        setDefaultPaddingChars(defaultPaddingChars);
        return this;
    }

    public String getLeftPaddingChars() {
        return leftPaddingChars;
    }

    public void setLeftPaddingChars(String leftPaddingChars) {
        this.leftPaddingChars = leftPaddingChars;
    }

    public TextFixedWidthColumn updateLeftPaddingChars(String leftPaddingChars) {
        setLeftPaddingChars(leftPaddingChars);
        return this;
    }

    public String getRightPaddingChars() {
        return rightPaddingChars;
    }

    public void setRightPaddingChars(String rightPaddingChars) {
        this.rightPaddingChars = rightPaddingChars;
    }

    public TextFixedWidthColumn updateRightPaddingChars(String rightPaddingChars) {
        setRightPaddingChars(rightPaddingChars);
        return this;
    }

    public String getSkippedColumnsChars() {
        return skippedColumnsChars;
    }

    public void setSkippedColumnsChars(String skippedColumnsChars) {
        this.skippedColumnsChars = skippedColumnsChars;
    }

    public TextFixedWidthColumn updateSkippedColumnsChars(String skippedColumnsChars) {
        setSkippedColumnsChars(skippedColumnsChars);
        return this;
    }

    @PortabilityHint(target = "C#", name = "suppress")
    @Override
    public TextFixedWidthColumn updateTrimValue(boolean trimValue) {
        return (TextFixedWidthColumn) super.updateTrimValue(trimValue);
    }

    @PortabilityHint(target = "C#", name = "suppress")
    @Override
    public TextFixedWidthColumn updateRawValueConverter(ValueConverter rawValueConverter) {
        return (TextFixedWidthColumn) super.updateRawValueConverter(rawValueConverter);
    }

    @PortabilityHint(target = "C#", name = "suppress")
    @Override
    public TextFixedWidthColumn updateValueValidator(ValueValidator valueValidator) {
        return (TextFixedWidthColumn) super.updateValueValidator(valueValidator);
    }

    @PortabilityHint(target = "C#", name = "suppress")
    @Override
    public TextFixedWidthColumn updateValueConverter(ValueConverter valueConverter) {
        return (TextFixedWidthColumn) super.updateValueConverter(valueConverter);
    }

    @PortabilityHint(target = "C#", name = "suppress")
    @Override
    public TextFixedWidthColumn updateTitle(String title) {
        return (TextFixedWidthColumn) super.updateTitle(title);
    }

    @PortabilityHint(target = "C#", name = "suppress")
    @Override
    public TextFixedWidthColumn updateName(String name) {
        return (TextFixedWidthColumn) super.updateName(name);
    }

    @PortabilityHint(target = "C#", name = "suppress")
    @Override
    public TextFixedWidthColumn updateIndex(int index) {
        return (TextFixedWidthColumn) super.updateIndex(index);
    }

}
