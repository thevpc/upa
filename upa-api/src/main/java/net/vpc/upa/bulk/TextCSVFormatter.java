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

import java.util.ArrayList;
import java.util.List;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public abstract class TextCSVFormatter extends AbstractDataFormatter {

    private boolean writeHeader;
    private boolean trimValues = true;
    private String separators = ";";
    private boolean supportsDoubleQuote = true;
    private boolean supportsSimpleQuote = true;
    private boolean supportsBackSlash = true;
    private List<TextCSVColumn> columns = new ArrayList<TextCSVColumn>();
    private String newLine;
    private int skipRows;

    public List<TextCSVColumn> getColumns() {
        return columns;
    }

    public boolean isWriteHeader() {
        return writeHeader;
    }

    public TextCSVFormatter setWriteHeader(boolean writeHeader) {
        this.writeHeader = writeHeader;
        return this;
    }

    public String getSeparators() {
        return separators;
    }

    public TextCSVFormatter setSeparators(String separators) {
        this.separators = separators;
        return this;
    }

    public boolean isSupportsDoubleQuote() {
        return supportsDoubleQuote;
    }

    public TextCSVFormatter setSupportsDoubleQuote(boolean supportsDoubleQuote) {
        this.supportsDoubleQuote = supportsDoubleQuote;
        return this;
    }

    public boolean isSupportsSimpleQuote() {
        return supportsSimpleQuote;
    }

    public TextCSVFormatter setSupportsSimpleQuote(boolean supportsSimpleQuote) {
        this.supportsSimpleQuote = supportsSimpleQuote;
        return this;
    }

    public boolean isSupportsBackSlash() {
        return supportsBackSlash;
    }

    public TextCSVFormatter setSupportsBackSlash(boolean supportsBackSlash) {
        this.supportsBackSlash = supportsBackSlash;
        return this;
    }

    public boolean isTrimValues() {
        return trimValues;
    }

    public TextCSVFormatter setTrimValues(boolean trimValues) {
        this.trimValues = trimValues;
        return this;
    }

    public String getNewLine() {
        return newLine;
    }

    public TextCSVFormatter setNewLine(String newLine) {
        this.newLine = newLine;
        return this;
    }

    public int getSkipRows() {
        return skipRows;
    }

    public TextCSVFormatter setSkipRows(int skipRows) {
        this.skipRows = skipRows;
        return this;
    }
}
