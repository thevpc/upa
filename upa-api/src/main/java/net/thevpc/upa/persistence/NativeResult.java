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
package net.thevpc.upa.persistence;

import net.thevpc.upa.types.Blob;
import net.thevpc.upa.types.Clob;

import java.io.InputStream;
import java.io.Reader;
import java.math.BigDecimal;

/**
 *
 * @author vpc
 */
public interface NativeResult {

    String getColumnName(int index);

    int getColumnCount();

    String getColumnClassName(int column);

    boolean next();

    boolean wasNull();

    // Methods for accessing results by column index
    /**
     * Retrieves the value of the designated column in the current row of this
     * <code>ResultSet</code> object as a <code>String</code> in the Java
     * programming language.
     *
     * @param columnIndex the first column is 1, the second is 2, ...
     * @return the column value; if the value is SQL <code>NULL</code>, the
     * value returned is <code>null</code>
     */
    String getString(int columnIndex);

    /**
     * Retrieves the value of the designated column in the current row of this
     * <code>ResultSet</code> object as a <code>boolean</code> in the Java
     * programming language.
     *
     * <P>
     * If the designated column has a datatype of CHAR or VARCHAR and contains a
     * "0" or has a datatype of BIT, TINYINT, SMALLINT, INTEGER or BIGINT and
     * contains a 0, a value of <code>false</code> is returned. If the
     * designated column has a datatype of CHAR or VARCHAR and contains a "1" or
     * has a datatype of BIT, TINYINT, SMALLINT, INTEGER or BIGINT and contains
     * a 1, a value of <code>true</code> is returned.
     *
     * @param columnIndex the first column is 1, the second is 2, ...
     * @return the column value; if the value is SQL <code>NULL</code>, the
     * value returned is <code>false</code>
     */
    boolean getBoolean(int columnIndex);

    /**
     * Retrieves the value of the designated column in the current row of this
     * <code>ResultSet</code> object as a <code>byte</code> in the Java
     * programming language.
     *
     * @param columnIndex the first column is 1, the second is 2, ...
     * @return the column value; if the value is SQL <code>NULL</code>, the
     * value returned is <code>0</code>
     */
    byte getByte(int columnIndex);

    /**
     * Retrieves the value of the designated column in the current row of this
     * <code>ResultSet</code> object as a <code>short</code> in the Java
     * programming language.
     *
     * @param columnIndex the first column is 1, the second is 2, ...
     * @return the column value; if the value is SQL <code>NULL</code>, the
     * value returned is <code>0</code>
     */
    short getShort(int columnIndex);

    /**
     * Retrieves the value of the designated column in the current row of this
     * <code>ResultSet</code> object as an <code>int</code> in the Java
     * programming language.
     *
     * @param columnIndex the first column is 1, the second is 2, ...
     * @return the column value; if the value is SQL <code>NULL</code>, the
     * value returned is <code>0</code>
     */
    int getInt(int columnIndex);

    /**
     * Retrieves the value of the designated column in the current row of this
     * <code>ResultSet</code> object as a <code>long</code> in the Java
     * programming language.
     *
     * @param columnIndex the first column is 1, the second is 2, ...
     * @return the column value; if the value is SQL <code>NULL</code>, the
     * value returned is <code>0</code>
     */
    long getLong(int columnIndex);

    /**
     * Retrieves the value of the designated column in the current row of this
     * <code>ResultSet</code> object as a <code>float</code> in the Java
     * programming language.
     *
     * @param columnIndex the first column is 1, the second is 2, ...
     * @return the column value; if the value is SQL <code>NULL</code>, the
     * value returned is <code>0</code>
     */
    float getFloat(int columnIndex);

    /**
     * Retrieves the value of the designated column in the current row of this
     * <code>ResultSet</code> object as a <code>double</code> in the Java
     * programming language.
     *
     * @param columnIndex the first column is 1, the second is 2, ...
     * @return the column value; if the value is SQL <code>NULL</code>, the
     * value returned is <code>0</code>
     */
    double getDouble(int columnIndex);

    /**
     * Retrieves the value of the designated column in the current row of this
     * <code>ResultSet</code> object as a <code>byte</code> array in the Java
     * programming language. The bytes represent the raw values returned by the
     * driver.
     *
     * @param columnIndex the first column is 1, the second is 2, ...
     * @return the column value; if the value is SQL <code>NULL</code>, the
     * value returned is <code>null</code>
     */
    byte[] getBytes(int columnIndex);

    /**
     * Retrieves the value of the designated column in the current row of this
     * <code>ResultSet</code> object as a <code>java.sql.Date</code> object in
     * the Java programming language.
     *
     * @param columnIndex the first column is 1, the second is 2, ...
     * @return the column value; if the value is SQL <code>NULL</code>, the
     * value returned is <code>null</code>
     */
    java.sql.Date getDate(int columnIndex);

    /**
     * Retrieves the value of the designated column in the current row of this
     * <code>ResultSet</code> object as a <code>java.sql.Time</code> object in
     * the Java programming language.
     *
     * @param columnIndex the first column is 1, the second is 2, ...
     * @return the column value; if the value is SQL <code>NULL</code>, the
     * value returned is <code>null</code>
     */
    java.sql.Time getTime(int columnIndex);

    /**
     * Retrieves the value of the designated column in the current row of this
     * <code>ResultSet</code> object as a <code>java.sql.Timestamp</code> object
     * in the Java programming language.
     *
     * @param columnIndex the first column is 1, the second is 2, ...
     * @return the column value; if the value is SQL <code>NULL</code>, the
     * value returned is <code>null</code>
     */
    java.sql.Timestamp getTimestamp(int columnIndex);

    /**
     * Updates the designated column with a <code>null</code> value.
     *
     * The updater methods are used to update column values in the current row
     * or the insert row. The updater methods do not update the underlying
     * database; instead the <code>updateRow</code> or <code>insertRow</code>
     * methods are called to update the database.
     *
     * @param columnIndex the first column is 1, the second is 2, ...
     * <code>CONCUR_READ_ONLY</code> or this method is called on a closed result
     * set
     * @since 1.2
     */
    void updateNull(int columnIndex);

    /**
     * Updates the designated column with a <code>boolean</code> value. The
     * updater methods are used to update column values in the current row or
     * the insert row. The updater methods do not update the underlying
     * database; instead the <code>updateRow</code> or <code>insertRow</code>
     * methods are called to update the database.
     *
     * @param columnIndex the first column is 1, the second is 2, ...
     * @param x the new column value
     * @since 1.2
     */
    void updateBoolean(int columnIndex, boolean x);

    /**
     * Updates the designated column with a <code>byte</code> value. The updater
     * methods are used to update column values in the current row or the insert
     * row. The updater methods do not update the underlying database; instead
     * the <code>updateRow</code> or <code>insertRow</code> methods are called
     * to update the database.
     *
     *
     * @param columnIndex the first column is 1, the second is 2, ...
     * @param x the new column value
     * @since 1.2
     */
    void updateByte(int columnIndex, byte x);

    /**
     * Updates the designated column with a <code>short</code> value. The
     * updater methods are used to update column values in the current row or
     * the insert row. The updater methods do not update the underlying
     * database; instead the <code>updateRow</code> or <code>insertRow</code>
     * methods are called to update the database.
     *
     * @param columnIndex the first column is 1, the second is 2, ...
     * @param x the new column value
     * @since 1.2
     */
    void updateShort(int columnIndex, short x);

    /**
     * Updates the designated column with an <code>int</code> value. The updater
     * methods are used to update column values in the current row or the insert
     * row. The updater methods do not update the underlying database; instead
     * the <code>updateRow</code> or <code>insertRow</code> methods are called
     * to update the database.
     *
     * @param columnIndex the first column is 1, the second is 2, ...
     * @param x the new column value
     * @since 1.2
     */
    void updateInt(int columnIndex, int x);

    /**
     * Updates the designated column with a <code>long</code> value. The updater
     * methods are used to update column values in the current row or the insert
     * row. The updater methods do not update the underlying database; instead
     * the <code>updateRow</code> or <code>insertRow</code> methods are called
     * to update the database.
     *
     * @param columnIndex the first column is 1, the second is 2, ...
     * @param x the new column value
     * @since 1.2
     */
    void updateLong(int columnIndex, long x);

    /**
     * Updates the designated column with a <code>float</code> value. The
     * updater methods are used to update column values in the current row or
     * the insert row. The updater methods do not update the underlying
     * database; instead the <code>updateRow</code> or <code>insertRow</code>
     * methods are called to update the database.
     *
     * @param columnIndex the first column is 1, the second is 2, ...
     * @param x the new column value
     * @since 1.2
     */
    void updateFloat(int columnIndex, float x);

    /**
     * Updates the designated column with a <code>double</code> value. The
     * updater methods are used to update column values in the current row or
     * the insert row. The updater methods do not update the underlying
     * database; instead the <code>updateRow</code> or <code>insertRow</code>
     * methods are called to update the database.
     *
     * @param columnIndex the first column is 1, the second is 2, ...
     * @param x the new column value
     * @since 1.2
     */
    void updateDouble(int columnIndex, double x);

    /**
     * Updates the designated column with a <code>java.math.BigDecimal</code>
     * value. The updater methods are used to update column values in the
     * current row or the insert row. The updater methods do not update the
     * underlying database; instead the <code>updateRow</code> or
     * <code>insertRow</code> methods are called to update the database.
     *
     * @param columnIndex the first column is 1, the second is 2, ...
     * @param x the new column value
     * @since 1.2
     */
    void updateBigDecimal(int columnIndex, BigDecimal x);

    /**
     * Updates the designated column with a <code>String</code> value. The
     * updater methods are used to update column values in the current row or
     * the insert row. The updater methods do not update the underlying
     * database; instead the <code>updateRow</code> or <code>insertRow</code>
     * methods are called to update the database.
     *
     * @param columnIndex the first column is 1, the second is 2, ...
     * @param x the new column value
     * @since 1.2
     */
    void updateString(int columnIndex, String x);

    /**
     * Updates the designated column with a <code>byte</code> array value. The
     * updater methods are used to update column values in the current row or
     * the insert row. The updater methods do not update the underlying
     * database; instead the <code>updateRow</code> or <code>insertRow</code>
     * methods are called to update the database.
     *
     * @param columnIndex the first column is 1, the second is 2, ...
     * @param x the new column value
     * @since 1.2
     */
    void updateBytes(int columnIndex, byte x[]);

    /**
     * Updates the designated column with a <code>java.sql.Date</code> value.
     * The updater methods are used to update column values in the current row
     * or the insert row. The updater methods do not update the underlying
     * database; instead the <code>updateRow</code> or <code>insertRow</code>
     * methods are called to update the database.
     *
     * @param columnIndex the first column is 1, the second is 2, ...
     * @param x the new column value
     * @since 1.2
     */
    void updateDate(int columnIndex, java.sql.Date x);

    /**
     * Updates the designated column with a <code>java.sql.Time</code> value.
     * The updater methods are used to update column values in the current row
     * or the insert row. The updater methods do not update the underlying
     * database; instead the <code>updateRow</code> or <code>insertRow</code>
     * methods are called to update the database.
     *
     * @param columnIndex the first column is 1, the second is 2, ...
     * @param x the new column value
     * @since 1.2
     */
    void updateTime(int columnIndex, java.sql.Time x);

    /**
     * Updates the designated column with a <code>java.sql.Timestamp</code>
     * value. The updater methods are used to update column values in the
     * current row or the insert row. The updater methods do not update the
     * underlying database; instead the <code>updateRow</code> or
     * <code>insertRow</code> methods are called to update the database.
     *
     * @param columnIndex the first column is 1, the second is 2, ...
     * @param x the new column value
     * @since 1.2
     */
    void updateTimestamp(int columnIndex, java.sql.Timestamp x);

    /**
     * Updates the designated column with an ascii stream value, which will have
     * the specified number of bytes. The updater methods are used to update
     * column values in the current row or the insert row. The updater methods
     * do not update the underlying database; instead the <code>updateRow</code>
     * or <code>insertRow</code> methods are called to update the database.
     *
     * @param columnIndex the first column is 1, the second is 2, ...
     * @param x the new column value
     * @param length the length of the stream
     * @since 1.2
     */
    void updateAsciiStream(int columnIndex,
            java.io.InputStream x,
            int length);

    /**
     * Updates the designated column with a binary stream value, which will have
     * the specified number of bytes. The updater methods are used to update
     * column values in the current row or the insert row. The updater methods
     * do not update the underlying database; instead the <code>updateRow</code>
     * or <code>insertRow</code> methods are called to update the database.
     *
     * @param columnIndex the first column is 1, the second is 2, ...
     * @param x the new column value
     * @param length the length of the stream
    * @since 1.2
     */
    void updateBinaryStream(int columnIndex,
            java.io.InputStream x,
            int length);

    /**
     * Updates the designated column with a character stream value, which will
     * have the specified number of bytes. The updater methods are used to
     * update column values in the current row or the insert row. The updater
     * methods do not update the underlying database; instead the
     * <code>updateRow</code> or <code>insertRow</code> methods are called to
     * update the database.
     *
     * @param columnIndex the first column is 1, the second is 2, ...
     * @param x the new column value
     * @param length the length of the stream
     * @since 1.2
     */
    void updateCharacterStream(int columnIndex,
            java.io.Reader x,
            int length);

    /**
     * Updates the designated column with an <code>Object</code> value.
     *
     * The updater methods are used to update column values in the current row
     * or the insert row. The updater methods do not update the underlying
     * database; instead the <code>updateRow</code> or <code>insertRow</code>
     * methods are called to update the database.
     * <p>
     * If the second argument is an <code>InputStream</code> then the stream
     * must contain the number of bytes specified by scaleOrLength. If the
     * second argument is a <code>Reader</code> then the reader must contain the
     * number of characters specified by scaleOrLength. If these conditions are
     * not true the driver will generate a <code>SQLException</code> when the
     * statement is executed.
     *
     * @param columnIndex the first column is 1, the second is 2, ...
     * @param x the new column value
     * @param scaleOrLength for an object of <code>java.math.BigDecimal</code> ,
     * this is the number of digits after the decimal point. For Java Object
     * types <code>InputStream</code> and <code>Reader</code>, this is the
     * length of the data in the stream or reader. For all other types, this
     * value will be ignored.
     * @since 1.2
     */
    void updateObject(int columnIndex, Object x, int scaleOrLength);

    /**
     * Updates the designated column with an <code>Object</code> value.
     *
     * The updater methods are used to update column values in the current row
     * or the insert row. The updater methods do not update the underlying
     * database; instead the <code>updateRow</code> or <code>insertRow</code>
     * methods are called to update the database.
     *
     * @param columnIndex the first column is 1, the second is 2, ...
     * @param x the new column value
     * @since 1.2
     */
    void updateObject(int columnIndex, Object x);

    void close();

    boolean isClosed();

    void updateRow();

    Object getObject(int index);

    BigDecimal getBigDecimal(int index);

    Blob getBlob(int index);

    void updateBlob(int i, Blob blob);

    void updateBlob(int i, InputStream byteArrayInputStream);

    Clob getClob(int index);

    void updateClob(int i, Clob clob);

    void updateClob(int i, Reader reader);

}
