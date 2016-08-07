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
package net.vpc.upa.bulk;

import java.io.IOException;
import java.util.ArrayList;
import java.util.List;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public abstract class SheetParser extends AbstractDataParser {

    private boolean containsHeader;
    private boolean trimValues = true;
    private int sheetIndex = 0;
    private int skipRows = 0;
    private int minColumns = 0;
    private boolean skipEmptyRows = false;
    private List<SheetColumn> columns = new ArrayList<SheetColumn>();

    public List<SheetColumn> getColumns() {
        return columns;
    }

    public boolean isContainsHeader() {
        return containsHeader;
    }

    public void setContainsHeader(boolean containsHeader) {
        this.containsHeader = containsHeader;
    }

    public boolean isTrimValues() {
        return trimValues;
    }

    public void setTrimValues(boolean trimValues) {
        this.trimValues = trimValues;
    }

    public int getSheetIndex() {
        return sheetIndex;
    }

    public void setSheetIndex(int sheetIndex) {
        this.sheetIndex = sheetIndex;
    }

    public int getSkipRows() {
        return skipRows;
    }

    public void setSkipRows(int skipRows) {
        this.skipRows = skipRows;
    }

    public int getMinColumns() {
        return minColumns;
    }

    public void setMinColumns(int minColumns) {
        this.minColumns = minColumns;
    }

    public boolean isSkipEmptyRows() {
        return skipEmptyRows;
    }

    public void setSkipEmptyRows(boolean skipEmptyRows) {
        this.skipEmptyRows = skipEmptyRows;
    }

    public abstract String[] getSheetNames() throws IOException;
}
