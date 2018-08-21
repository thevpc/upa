/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.persistence;

import java.io.InputStream;
import java.io.Reader;
import java.math.BigDecimal;
import java.sql.SQLException;
import java.sql.SQLFeatureNotSupportedException;

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
    void setNull(int parameterIndex, int sqlType);

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
    void setBoolean(int parameterIndex, boolean x);

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
    void setByte(int parameterIndex, byte x);

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
    void setShort(int parameterIndex, short x);

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
    void setInt(int parameterIndex, int x);

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
    void setLong(int parameterIndex, long x);

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
    void setFloat(int parameterIndex, float x);

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
    void setDouble(int parameterIndex, double x);

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
    void setBigDecimal(int parameterIndex, BigDecimal x);

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
    void setString(int parameterIndex, String x);

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
    void setBytes(int parameterIndex, byte x[]);

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
    void setDate(int parameterIndex, java.sql.Date x);

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
    void setTime(int parameterIndex, java.sql.Time x);

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
    void setTimestamp(int parameterIndex, java.sql.Timestamp x);

    int executeUpdate();

    NativeResult executeQuery();

    NativeResult getGeneratedKeys();

    void setObject(int i, Object object);

    void setBlob(int i, net.vpc.upa.types.Blob stream);

    void setBlob(int i, InputStream stream);

    void setClob(int i, Reader reader);

    void setClob(int i, net.vpc.upa.types.Clob reader);
    
    void setClob(int i, String str);

}
