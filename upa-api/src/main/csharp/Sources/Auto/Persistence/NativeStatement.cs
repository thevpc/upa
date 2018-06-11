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
     * @author vpc
     */
    public interface NativeStatement {

        /**
             * Sets the designated parameter to SQL <code>NULL</code>.
             * <p>
             * <p>
             * <B>Note:</B> You must specify the parameter's SQL type.
             *
             * @param parameterIndex the first parameter is 1, the second is 2, ...
             * @param sqlType        the SQL type code defined in <code>java.sql.Types</code>
             * @throws SQLException                    if parameterIndex does not correspond to a
             *                                         parameter marker in the SQL statement; if a database access error occurs
             *                                         or this method is called on a closed <code>PreparedStatement</code>
             * @throws SQLFeatureNotSupportedException if <code>sqlType</code> is a
             *                                         <code>ARRAY</code>, <code>BLOB</code>, <code>CLOB</code>,
             *                                         <code>DATALINK</code>, <code>JAVA_OBJECT</code>, <code>NCHAR</code>,
             *                                         <code>NCLOB</code>, <code>NVARCHAR</code>, <code>LONGNVARCHAR</code>,
             *                                         <code>REF</code>, <code>ROWID</code>, <code>SQLXML</code> or
             *                                         <code>STRUCT</code> data type and the JDBC driver does not support this
             *                                         data type
             */
         void SetNull(int parameterIndex, int sqlType);

        /**
             * Sets the designated parameter to the given Java <code>boolean</code>
             * value. The driver converts this to an SQL <code>BIT</code> or
             * <code>BOOLEAN</code> value when it sends it to the database.
             *
             * @param parameterIndex the first parameter is 1, the second is 2, ...
             * @param x              the parameter value
             * @throws SQLException if parameterIndex does not correspond to a
             *                      parameter marker in the SQL statement; if a database access error occurs
             *                      or this method is called on a closed <code>PreparedStatement</code>
             */
         void SetBoolean(int parameterIndex, bool x);

        /**
             * Sets the designated parameter to the given Java <code>byte</code> value.
             * The driver converts this to an SQL <code>TINYINT</code> value when it
             * sends it to the database.
             *
             * @param parameterIndex the first parameter is 1, the second is 2, ...
             * @param x              the parameter value
             * @throws SQLException if parameterIndex does not correspond to a
             *                      parameter marker in the SQL statement; if a database access error occurs
             *                      or this method is called on a closed <code>PreparedStatement</code>
             */
         void SetByte(int parameterIndex, byte x);

        /**
             * Sets the designated parameter to the given Java <code>short</code> value.
             * The driver converts this to an SQL <code>SMALLINT</code> value when it
             * sends it to the database.
             *
             * @param parameterIndex the first parameter is 1, the second is 2, ...
             * @param x              the parameter value
             * @throws SQLException if parameterIndex does not correspond to a
             *                      parameter marker in the SQL statement; if a database access error occurs
             *                      or this method is called on a closed <code>PreparedStatement</code>
             */
         void SetShort(int parameterIndex, short x);

        /**
             * Sets the designated parameter to the given Java <code>int</code> value.
             * The driver converts this to an SQL <code>INTEGER</code> value when it
             * sends it to the database.
             *
             * @param parameterIndex the first parameter is 1, the second is 2, ...
             * @param x              the parameter value
             * @throws SQLException if parameterIndex does not correspond to a
             *                      parameter marker in the SQL statement; if a database access error occurs
             *                      or this method is called on a closed <code>PreparedStatement</code>
             */
         void SetInt(int parameterIndex, int x);

        /**
             * Sets the designated parameter to the given Java <code>long</code> value.
             * The driver converts this to an SQL <code>BIGINT</code> value when it
             * sends it to the database.
             *
             * @param parameterIndex the first parameter is 1, the second is 2, ...
             * @param x              the parameter value
             * @throws SQLException if parameterIndex does not correspond to a
             *                      parameter marker in the SQL statement; if a database access error occurs
             *                      or this method is called on a closed <code>PreparedStatement</code>
             */
         void SetLong(int parameterIndex, long x);

        /**
             * Sets the designated parameter to the given Java <code>float</code> value.
             * The driver converts this to an SQL <code>REAL</code> value when it sends
             * it to the database.
             *
             * @param parameterIndex the first parameter is 1, the second is 2, ...
             * @param x              the parameter value
             * @throws SQLException if parameterIndex does not correspond to a
             *                      parameter marker in the SQL statement; if a database access error occurs
             *                      or this method is called on a closed <code>PreparedStatement</code>
             */
         void SetFloat(int parameterIndex, float x);

        /**
             * Sets the designated parameter to the given Java <code>double</code>
             * value. The driver converts this to an SQL <code>DOUBLE</code> value when
             * it sends it to the database.
             *
             * @param parameterIndex the first parameter is 1, the second is 2, ...
             * @param x              the parameter value
             * @throws SQLException if parameterIndex does not correspond to a
             *                      parameter marker in the SQL statement; if a database access error occurs
             *                      or this method is called on a closed <code>PreparedStatement</code>
             */
         void SetDouble(int parameterIndex, double x);

        /**
             * Sets the designated parameter to the given
             * <code>java.math.BigDecimal</code> value. The driver converts this to an
             * SQL <code>NUMERIC</code> value when it sends it to the database.
             *
             * @param parameterIndex the first parameter is 1, the second is 2, ...
             * @param x              the parameter value
             * @throws SQLException if parameterIndex does not correspond to a
             *                      parameter marker in the SQL statement; if a database access error occurs
             *                      or this method is called on a closed <code>PreparedStatement</code>
             */
         void SetBigDecimal(int parameterIndex, System.Decimal? x);

        /**
             * Sets the designated parameter to the given Java <code>String</code>
             * value. The driver converts this to an SQL <code>VARCHAR</code> or
             * <code>LONGVARCHAR</code> value (depending on the argument's size relative
             * to the driver's limits on <code>VARCHAR</code> values) when it sends it
             * to the database.
             *
             * @param parameterIndex the first parameter is 1, the second is 2, ...
             * @param x              the parameter value
             * @throws SQLException if parameterIndex does not correspond to a
             *                      parameter marker in the SQL statement; if a database access error occurs
             *                      or this method is called on a closed <code>PreparedStatement</code>
             */
         void SetString(int parameterIndex, string x);

        /**
             * Sets the designated parameter to the given Java array of bytes. The
             * driver converts this to an SQL <code>VARBINARY</code> or
             * <code>LONGVARBINARY</code> (depending on the argument's size relative to
             * the driver's limits on <code>VARBINARY</code> values) when it sends it to
             * the database.
             *
             * @param parameterIndex the first parameter is 1, the second is 2, ...
             * @param x              the parameter value
             * @throws SQLException if parameterIndex does not correspond to a
             *                      parameter marker in the SQL statement; if a database access error occurs
             *                      or this method is called on a closed <code>PreparedStatement</code>
             */
         void SetBytes(int parameterIndex, byte x/*[]*/);

        /**
             * Sets the designated parameter to the given <code>java.sql.Date</code>
             * value using the default time zone of the virtual machine that is running
             * the application. The driver converts this to an SQL <code>DATE</code>
             * value when it sends it to the database.
             *
             * @param parameterIndex the first parameter is 1, the second is 2, ...
             * @param x              the parameter value
             * @throws SQLException if parameterIndex does not correspond to a
             *                      parameter marker in the SQL statement; if a database access error occurs
             *                      or this method is called on a closed <code>PreparedStatement</code>
             */
         void SetDate(int parameterIndex, Net.Vpc.Upa.Types.Date x);

        /**
             * Sets the designated parameter to the given <code>java.sql.Time</code>
             * value. The driver converts this to an SQL <code>TIME</code> value when it
             * sends it to the database.
             *
             * @param parameterIndex the first parameter is 1, the second is 2, ...
             * @param x              the parameter value
             * @throws SQLException if parameterIndex does not correspond to a
             *                      parameter marker in the SQL statement; if a database access error occurs
             *                      or this method is called on a closed <code>PreparedStatement</code>
             */
         void SetTime(int parameterIndex, Net.Vpc.Upa.Types.Time x);

        /**
             * Sets the designated parameter to the given
             * <code>java.sql.Timestamp</code> value. The driver converts this to an SQL
             * <code>TIMESTAMP</code> value when it sends it to the database.
             *
             * @param parameterIndex the first parameter is 1, the second is 2, ...
             * @param x              the parameter value
             * @throws SQLException if parameterIndex does not correspond to a
             *                      parameter marker in the SQL statement; if a database access error occurs
             *                      or this method is called on a closed <code>PreparedStatement</code>
             */
         void SetTimestamp(int parameterIndex, Net.Vpc.Upa.Types.Timestamp x);

         int ExecuteUpdate();

         Net.Vpc.Upa.Persistence.NativeResult ExecuteQuery();

         Net.Vpc.Upa.Persistence.NativeResult GetGeneratedKeys();

         void SetObject(int i, object @object);

         void SetBlob(int i, Net.Vpc.Upa.Types.Blob stream);

         void SetBlob(int i, System.IO.Stream stream);

         void SetClob(int i, System.IO.TextReader reader);

         void SetClob(int i, Net.Vpc.Upa.Types.Clob reader);
    }
}
