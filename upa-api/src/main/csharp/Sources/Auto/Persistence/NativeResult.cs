/*********************************************************
 *********************************************************
 **   DO NOT EDIT                                       **
 **                                                     **
 **   THIS FILE HAS BEEN GENERATED AUTOMATICALLY         **
 **   BY UPA PORTABLE GENERATOR                         **
 **   (c) vpc                                           **
 **                                                     **
 *********************************************************
 ********************************************************/



namespace Net.Vpc.Upa.Persistence
{


    /**
     *
     * @author vpc
     */
    public interface NativeResult {

         string GetColumnName(int index);

         int GetColumnCount();

         string GetColumnClassName(int column);

         bool Next();

         bool WasNull();

        /**
             * Retrieves the value of the designated column in the current row of this
             * <code>ResultSet</code> object as a <code>String</code> in the Java
             * programming language.
             *
             * @param columnIndex the first column is 1, the second is 2, ...
             * @return the column value; if the value is SQL <code>NULL</code>, the
             * value returned is <code>null</code>
             */
         string GetString(int columnIndex);

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
         bool GetBoolean(int columnIndex);

        /**
             * Retrieves the value of the designated column in the current row of this
             * <code>ResultSet</code> object as a <code>byte</code> in the Java
             * programming language.
             *
             * @param columnIndex the first column is 1, the second is 2, ...
             * @return the column value; if the value is SQL <code>NULL</code>, the
             * value returned is <code>0</code>
             */
         byte GetByte(int columnIndex);

        /**
             * Retrieves the value of the designated column in the current row of this
             * <code>ResultSet</code> object as a <code>short</code> in the Java
             * programming language.
             *
             * @param columnIndex the first column is 1, the second is 2, ...
             * @return the column value; if the value is SQL <code>NULL</code>, the
             * value returned is <code>0</code>
             */
         short GetShort(int columnIndex);

        /**
             * Retrieves the value of the designated column in the current row of this
             * <code>ResultSet</code> object as an <code>int</code> in the Java
             * programming language.
             *
             * @param columnIndex the first column is 1, the second is 2, ...
             * @return the column value; if the value is SQL <code>NULL</code>, the
             * value returned is <code>0</code>
             */
         int GetInt(int columnIndex);

        /**
             * Retrieves the value of the designated column in the current row of this
             * <code>ResultSet</code> object as a <code>long</code> in the Java
             * programming language.
             *
             * @param columnIndex the first column is 1, the second is 2, ...
             * @return the column value; if the value is SQL <code>NULL</code>, the
             * value returned is <code>0</code>
             */
         long GetLong(int columnIndex);

        /**
             * Retrieves the value of the designated column in the current row of this
             * <code>ResultSet</code> object as a <code>float</code> in the Java
             * programming language.
             *
             * @param columnIndex the first column is 1, the second is 2, ...
             * @return the column value; if the value is SQL <code>NULL</code>, the
             * value returned is <code>0</code>
             */
         float GetFloat(int columnIndex);

        /**
             * Retrieves the value of the designated column in the current row of this
             * <code>ResultSet</code> object as a <code>double</code> in the Java
             * programming language.
             *
             * @param columnIndex the first column is 1, the second is 2, ...
             * @return the column value; if the value is SQL <code>NULL</code>, the
             * value returned is <code>0</code>
             */
         double GetDouble(int columnIndex);

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
         byte[] GetBytes(int columnIndex);

        /**
             * Retrieves the value of the designated column in the current row of this
             * <code>ResultSet</code> object as a <code>java.sql.Date</code> object in
             * the Java programming language.
             *
             * @param columnIndex the first column is 1, the second is 2, ...
             * @return the column value; if the value is SQL <code>NULL</code>, the
             * value returned is <code>null</code>
             */
         Net.Vpc.Upa.Types.Date GetDate(int columnIndex);

        /**
             * Retrieves the value of the designated column in the current row of this
             * <code>ResultSet</code> object as a <code>java.sql.Time</code> object in
             * the Java programming language.
             *
             * @param columnIndex the first column is 1, the second is 2, ...
             * @return the column value; if the value is SQL <code>NULL</code>, the
             * value returned is <code>null</code>
             */
         Net.Vpc.Upa.Types.Time GetTime(int columnIndex);

        /**
             * Retrieves the value of the designated column in the current row of this
             * <code>ResultSet</code> object as a <code>java.sql.Timestamp</code> object
             * in the Java programming language.
             *
             * @param columnIndex the first column is 1, the second is 2, ...
             * @return the column value; if the value is SQL <code>NULL</code>, the
             * value returned is <code>null</code>
             */
         Net.Vpc.Upa.Types.Timestamp GetTimestamp(int columnIndex);

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
         void UpdateNull(int columnIndex);

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
         void UpdateBoolean(int columnIndex, bool x);

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
         void UpdateByte(int columnIndex, byte x);

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
         void UpdateShort(int columnIndex, short x);

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
         void UpdateInt(int columnIndex, int x);

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
         void UpdateLong(int columnIndex, long x);

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
         void UpdateFloat(int columnIndex, float x);

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
         void UpdateDouble(int columnIndex, double x);

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
         void UpdateBigDecimal(int columnIndex, System.Decimal? x);

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
         void UpdateString(int columnIndex, string x);

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
         void UpdateBytes(int columnIndex, byte x/*[]*/);

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
         void UpdateDate(int columnIndex, Net.Vpc.Upa.Types.Date x);

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
         void UpdateTime(int columnIndex, Net.Vpc.Upa.Types.Time x);

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
         void UpdateTimestamp(int columnIndex, Net.Vpc.Upa.Types.Timestamp x);

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
         void UpdateAsciiStream(int columnIndex, System.IO.Stream x, int length);

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
         void UpdateBinaryStream(int columnIndex, System.IO.Stream x, int length);

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
         void UpdateCharacterStream(int columnIndex, System.IO.TextReader x, int length);

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
         void UpdateObject(int columnIndex, object x, int scaleOrLength);

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
         void UpdateObject(int columnIndex, object x);

         void Close();

         bool IsClosed();

         void UpdateRow();

         object GetObject(int index);

         System.Decimal? GetBigDecimal(int index);

         Net.Vpc.Upa.Types.Blob GetBlob(int index);

         void UpdateBlob(int i, Net.Vpc.Upa.Types.Blob blob);

         void UpdateBlob(int i, System.IO.Stream byteArrayInputStream);

         Net.Vpc.Upa.Types.Clob GetClob(int index);

         void UpdateClob(int i, Net.Vpc.Upa.Types.Clob clob);

         void UpdateClob(int i, System.IO.TextReader reader);
    }
}
