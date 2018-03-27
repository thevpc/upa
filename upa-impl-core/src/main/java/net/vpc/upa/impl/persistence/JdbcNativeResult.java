/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.persistence;

import java.io.InputStream;
import java.io.Reader;
import java.math.BigDecimal;
import java.sql.*;

import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.persistence.NativeResult;

/**
 *
 * @author vpc
 */
public class JdbcNativeResult implements NativeResult {

    private ResultSet resultSet;
    private ResultSetMetaData metaData;

    public JdbcNativeResult(ResultSet resultSet) {
        this.resultSet = resultSet;
    }


    @Override
    public String getColumnName(int index) {
        try {
            return getMetaData().getColumnName(index);
        } catch (SQLException e) {
            throw new UPAException(e);
        }
    }

    @Override
    public int getColumnCount() {
        try {
            return getMetaData().getColumnCount();
        } catch (SQLException e) {
            throw new UPAException(e);
        }
    }

    @Override
    public String getColumnClassName(int column) {
        try {
            return getMetaData().getColumnClassName(column);
        } catch (SQLException e) {
            throw new UPAException(e);
        }
    }

    @Override
    public boolean isClosed() {
        try {
            return resultSet.isClosed();
        } catch (SQLException ex) {
            throw new UPAException(ex);
        }
    }

    @Override
    public void close() {
        try {
            if (!resultSet.isClosed()) {

                /**
                 * @PortabilityHint(target="C#",name="ignore")
                 */
                resultSet.getStatement().close();

                if (!resultSet.isClosed()) {
                    resultSet.close();
                }
            }
        } catch (SQLException ex) {
            throw new UPAException(ex);
        }
    }

    @Override
    public void updateRow() {
        try {
            resultSet.updateRow();
        } catch (SQLException ex) {
            throw new UPAException(ex);
        }
    }

    @Override
    public boolean next() {
        try {
            return resultSet.next();
        } catch (SQLException ex) {
            throw new UPAException(ex);
        }
    }

    @Override
    public boolean wasNull() {
        try {
            return resultSet.wasNull();
        } catch (SQLException ex) {
            throw new UPAException(ex);
        }
    }

    @Override
    public String getString(int columnIndex) {
        try {
            return resultSet.getString(columnIndex);
        } catch (SQLException ex) {
            throw new UPAException(ex);
        }
    }

    @Override
    public boolean getBoolean(int columnIndex) {
        try {
            return resultSet.getBoolean(columnIndex);
        } catch (SQLException ex) {
            throw new UPAException(ex);
        }
    }

    @Override
    public byte getByte(int columnIndex) {
        try {
            return resultSet.getByte(columnIndex);
        } catch (SQLException ex) {
            throw new UPAException(ex);
        }
    }

    @Override
    public short getShort(int columnIndex) {
        try {
            return resultSet.getShort(columnIndex);
        } catch (SQLException ex) {
            throw new UPAException(ex);
        }
    }

    @Override
    public int getInt(int columnIndex) {
        try {
            return resultSet.getInt(columnIndex);
        } catch (SQLException ex) {
            throw new UPAException(ex);
        }
    }

    @Override
    public long getLong(int columnIndex) {
        try {
            return resultSet.getLong(columnIndex);
        } catch (SQLException ex) {
            throw new UPAException(ex);
        }
    }

    @Override
    public float getFloat(int columnIndex) {
        try {
            return resultSet.getFloat(columnIndex);
        } catch (SQLException ex) {
            throw new UPAException(ex);
        }
    }

    @Override
    public double getDouble(int columnIndex) {
        try {
            return resultSet.getDouble(columnIndex);
        } catch (SQLException ex) {
            throw new UPAException(ex);
        }
    }

    @Override
    public byte[] getBytes(int columnIndex) {
        try {
            return resultSet.getBytes(columnIndex);
        } catch (SQLException ex) {
            throw new UPAException(ex);
        }
    }

    @Override
    public Date getDate(int columnIndex) {
        try {
            return resultSet.getDate(columnIndex);
        } catch (SQLException ex) {
            throw new UPAException(ex);
        }
    }

    @Override
    public Time getTime(int columnIndex) {
        try {
            return resultSet.getTime(columnIndex);
        } catch (SQLException ex) {
            throw new UPAException(ex);
        }
    }

    @Override
    public Timestamp getTimestamp(int columnIndex) {
        try {
            return resultSet.getTimestamp(columnIndex);
        } catch (SQLException ex) {
            throw new UPAException(ex);
        }
    }

    @Override
    public void updateNull(int columnIndex) {
        try {
            resultSet.updateNull(columnIndex);
        } catch (SQLException ex) {
            throw new UPAException(ex);
        }
    }

    @Override
    public void updateBoolean(int columnIndex, boolean x) {
        try {
            resultSet.updateBoolean(columnIndex, x);
        } catch (SQLException ex) {
            throw new UPAException(ex);
        }
    }

    @Override
    public void updateByte(int columnIndex, byte x) {
        try {
            resultSet.updateByte(columnIndex, x);
        } catch (SQLException ex) {
            throw new UPAException(ex);
        }
    }

    @Override
    public void updateShort(int columnIndex, short x) {
        try {
            resultSet.updateShort(columnIndex, x);
        } catch (SQLException ex) {
            throw new UPAException(ex);
        }
    }

    @Override
    public void updateInt(int columnIndex, int x) {
        try {
            resultSet.updateInt(columnIndex, x);
        } catch (SQLException ex) {
            throw new UPAException(ex);
        }
    }

    @Override
    public void updateLong(int columnIndex, long x) {
        try {
            resultSet.updateLong(columnIndex, x);
        } catch (SQLException ex) {
            throw new UPAException(ex);
        }
    }

    @Override
    public void updateFloat(int columnIndex, float x) {
        try {
            resultSet.updateFloat(columnIndex, x);
        } catch (SQLException ex) {
            throw new UPAException(ex);
        }
    }

    @Override
    public void updateDouble(int columnIndex, double x) {
        try {
            resultSet.updateDouble(columnIndex, x);
        } catch (SQLException ex) {
            throw new UPAException(ex);
        }
    }

    @Override
    public void updateBigDecimal(int columnIndex, BigDecimal x) {
        try {
            resultSet.updateBigDecimal(columnIndex, x);
        } catch (SQLException ex) {
            throw new UPAException(ex);
        }
    }

    @Override
    public void updateString(int columnIndex, String x) {
        try {
            resultSet.updateString(columnIndex, x);
        } catch (SQLException ex) {
            throw new UPAException(ex);
        }
    }

    @Override
    public void updateBytes(int columnIndex, byte[] x) {
        try {
            resultSet.updateBytes(columnIndex, x);
        } catch (SQLException ex) {
            throw new UPAException(ex);
        }
    }

    @Override
    public void updateDate(int columnIndex, Date x) {
        try {
            resultSet.updateDate(columnIndex, x);
        } catch (SQLException ex) {
            throw new UPAException(ex);
        }
    }

    @Override
    public void updateTime(int columnIndex, Time x) {
        try {
            resultSet.updateTime(columnIndex, x);
        } catch (SQLException ex) {
            throw new UPAException(ex);
        }
    }

    @Override
    public void updateTimestamp(int columnIndex, Timestamp x) {
        try {
            resultSet.updateTimestamp(columnIndex, x);
        } catch (SQLException ex) {
            throw new UPAException(ex);
        }
    }

    @Override
    public void updateAsciiStream(int columnIndex, InputStream x, int length) {
        try {
            resultSet.updateAsciiStream(columnIndex, x, length);
        } catch (SQLException ex) {
            throw new UPAException(ex);
        }
    }

    @Override
    public void updateBinaryStream(int columnIndex, InputStream x, int length) {
        try {
            resultSet.updateBinaryStream(columnIndex, x, length);
        } catch (SQLException ex) {
            throw new UPAException(ex);
        }
    }

    @Override
    public void updateCharacterStream(int columnIndex, Reader x, int length) {
        try {
            resultSet.updateCharacterStream(columnIndex, x, length);
        } catch (SQLException ex) {
            throw new UPAException(ex);
        }
    }

    @Override
    public void updateObject(int columnIndex, Object x, int scaleOrLength) {
        try {
            resultSet.updateObject(columnIndex, x, scaleOrLength);
        } catch (SQLException ex) {
            throw new UPAException(ex);
        }
    }

    @Override
    public void updateObject(int columnIndex, Object x) {
        try {
            resultSet.updateObject(columnIndex, x);
        } catch (SQLException ex) {
            throw new UPAException(ex);
        }
    }

    private ResultSetMetaData getMetaData() {
        if(metaData==null) {
            try {
                metaData=resultSet.getMetaData();
            } catch (SQLException ex) {
                throw new UPAException(ex);
            }
        }
        return metaData;
    }

    @Override
    public Object getObject(int index) {
        try {
            Object object = resultSet.getObject(index);
            if(object instanceof java.sql.Blob){
                return new DefaultBlob((java.sql.Blob) object);
            }
            if(object instanceof java.sql.Clob){
                return new DefaultClob((java.sql.Clob) object);
            }
            return object;
        } catch (SQLException ex) {
            throw new UPAException(ex);
        }
    }

    @Override
    public BigDecimal getBigDecimal(int index) {
        try {
            return resultSet.getBigDecimal(index);
        } catch (SQLException ex) {
            throw new UPAException(ex);
        }
    }

    @Override
    public net.vpc.upa.types.Blob getBlob(int index) {
        try {
            return new DefaultBlob(resultSet.getBlob(index));
        } catch (SQLException ex) {
            throw new UPAException(ex);
        }
    }

    @Override
    public void updateBlob(int i, net.vpc.upa.types.Blob blob) {
        try {
            resultSet.updateBlob(i, ((DefaultBlob)blob).getData());
        } catch (SQLException ex) {
            throw new UPAException(ex);
        }
    }

    @Override
    public void updateBlob(int i, InputStream stream) {
        try {
            resultSet.updateBlob(i, stream);
        } catch (SQLException ex) {
            throw new UPAException(ex);
        }
    }

    @Override
    public net.vpc.upa.types.Clob getClob(int index) {
        try {
            return new DefaultClob(resultSet.getClob(index));
        } catch (SQLException ex) {
            throw new UPAException(ex);
        }
    }

    @Override
    public void updateClob(int i, net.vpc.upa.types.Clob clob) {
        try {
            resultSet.updateClob(i, ((DefaultClob)clob).getData());
        } catch (SQLException ex) {
            throw new UPAException(ex);
        }
    }

    @Override
    public void updateClob(int i, Reader reader) {
        try {
            resultSet.updateClob(i, reader);
        } catch (SQLException ex) {
            throw new UPAException(ex);
        }
    }

}
