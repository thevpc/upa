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

import java.util.ArrayList;
import java.util.List;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public abstract class SheetFormatter extends AbstractDataFormatter {

    private boolean writeHeader;
    private int skipRows;
    private boolean trimValues = true;
    private int sheetIndex = 0;
    private String sheetName;
    private SheetContentType contentType;

    private List<SheetColumn> columns = new ArrayList<SheetColumn>();

    public List<SheetColumn> getColumns() {
        return columns;
    }

    public boolean isWriteHeader() {
        return writeHeader;
    }

    public SheetFormatter setWriteHeader(boolean writeHeader) {
        this.writeHeader = writeHeader;
        return this;
    }

    public boolean isTrimValues() {
        return trimValues;
    }

    public SheetFormatter setTrimValues(boolean trimValues) {
        this.trimValues = trimValues;
        return this;
    }

    public int getSheetIndex() {
        return sheetIndex;
    }

    public SheetFormatter setSheetIndex(int sheetIndex) {
        this.sheetIndex = sheetIndex;
        return this;
    }

    public String getSheetName() {
        return sheetName;
    }

    public SheetFormatter setSheetName(String sheetName) {
        this.sheetName = sheetName;
        return this;
    }

    public int getSkipRows() {
        return skipRows;
    }

    public SheetFormatter setSkipRows(int skipRows) {
        this.skipRows = skipRows;
        return this;
    }

    public SheetContentType getContentType() {
        return contentType;
    }

    public SheetFormatter setContentType(SheetContentType contentType) {
        this.contentType = contentType;
        return this;
    }

    public abstract boolean isSupported(SheetContentType contentType);

    public abstract SheetContentType getDefaultContentType();
}
