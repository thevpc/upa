/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.android;

import android.database.Cursor;
import java.io.InputStream;
import java.io.Reader;
import java.math.BigDecimal;
import java.sql.Date;
import java.sql.Time;
import java.sql.Timestamp;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import net.vpc.upa.persistence.NativeResult;

/**
 *
 * @author vpc
 */
public class AndroidSqliteNativeResult implements NativeResult {

    public static final SimpleDateFormat DF = new SimpleDateFormat("yyyy-MM-dd hh:mm:ss.SSS");

    private Cursor cursor;
    private boolean _wasNull;

    public AndroidSqliteNativeResult(Cursor cursor) {
        this.cursor = cursor;
    }

    @Override
    public String getColumnName(int index) {
        return cursor.getColumnName(index-1);
    }

    @Override
    public int getColumnCount() {
        return cursor.getColumnCount();
    }

    @Override
    public String getColumnClassName(int column) {
        return String.class.getName();
    }

    @Override
    public Object getObject(int columnIndex) {
        String s = cursor.getString(columnIndex - 1);
        _wasNull = s == null;
        return s;
    }

    @Override
    public boolean wasNull() {
        return _wasNull;
    }

    @Override
    public String getString(int columnIndex) {
        String s = cursor.getString(columnIndex - 1);
        _wasNull = s == null;
        return s;
    }

    @Override
    public boolean getBoolean(int columnIndex) {
        int s = cursor.getInt(columnIndex - 1);
        _wasNull = cursor.isNull(columnIndex);
        return s != 0;
    }

    @Override
    public byte getByte(int columnIndex) {
        int s = cursor.getInt(columnIndex - 1);
        _wasNull = cursor.isNull(columnIndex);
        return (byte) s;
    }

    @Override
    public short getShort(int columnIndex) {
        short s = cursor.getShort(columnIndex - 1);
        _wasNull = cursor.isNull(columnIndex);
        return s;
    }

    @Override
    public int getInt(int columnIndex) {
        int s = cursor.getInt(columnIndex - 1);
        _wasNull = cursor.isNull(columnIndex);
        return s;
    }

    @Override
    public long getLong(int columnIndex) {
        long s = cursor.getLong(columnIndex - 1);
        _wasNull = cursor.isNull(columnIndex);
        return s;
    }

    @Override
    public float getFloat(int columnIndex) {
        float s = cursor.getFloat(columnIndex - 1);
        _wasNull = cursor.isNull(columnIndex);
        return s;
    }

    @Override
    public double getDouble(int columnIndex) {
        double s = cursor.getDouble(columnIndex - 1);
        _wasNull = cursor.isNull(columnIndex);
        return s;
    }

    @Override
    public byte[] getBytes(int columnIndex) {
        byte[] s = cursor.getBlob(columnIndex - 1);
        _wasNull = cursor.isNull(columnIndex);
        return s;
    }

    @Override
    public Date getDate(int columnIndex) {
        try {
            String s = cursor.getString(columnIndex - 1);
            _wasNull = s == null;
            return s == null ? null : new java.sql.Date(DF.parse(s).getTime());
        } catch (ParseException ex) {
            return null;
        }
    }

    @Override
    public Time getTime(int columnIndex) {
        try {
            String s = cursor.getString(columnIndex - 1);
            _wasNull = s == null;
            return s == null ? null : new java.sql.Time(DF.parse(s).getTime());
        } catch (ParseException ex) {
            return null;
        }
    }

    @Override
    public Timestamp getTimestamp(int columnIndex) {
        try {
            String s = cursor.getString(columnIndex - 1);
            _wasNull = s == null;
            return s == null ? null : new java.sql.Timestamp(DF.parse(s).getTime());
        } catch (ParseException ex) {
            return null;
        }
    }

    @Override
    public BigDecimal getBigDecimal(int index) {
        throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
    }

    @Override
    public net.vpc.upa.types.Blob getBlob(int index) {
        throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
    }

    @Override
    public net.vpc.upa.types.Clob getClob(int index) {
        throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
    }

    @Override
    public boolean next() {
        return cursor.moveToNext();
    }

    @Override
    public void close() {
        cursor.close();
    }

    @Override
    public boolean isClosed() {
        return cursor.isClosed();
    }

    @Override
    public void updateNull(int columnIndex) {
        throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
    }

    @Override
    public void updateBoolean(int columnIndex, boolean x) {
        throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
    }

    @Override
    public void updateByte(int columnIndex, byte x) {
        throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
    }

    @Override
    public void updateShort(int columnIndex, short x) {
        throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
    }

    @Override
    public void updateInt(int columnIndex, int x) {
        throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
    }

    @Override
    public void updateLong(int columnIndex, long x) {
        throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
    }

    @Override
    public void updateFloat(int columnIndex, float x) {
        throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
    }

    @Override
    public void updateDouble(int columnIndex, double x) {
        throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
    }

    @Override
    public void updateBigDecimal(int columnIndex, BigDecimal x) {
        throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
    }

    @Override
    public void updateString(int columnIndex, String x) {
        throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
    }

    @Override
    public void updateBytes(int columnIndex, byte[] x) {
        throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
    }

    @Override
    public void updateDate(int columnIndex, Date x) {
        throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
    }

    @Override
    public void updateTime(int columnIndex, Time x) {
        throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
    }

    @Override
    public void updateTimestamp(int columnIndex, Timestamp x) {
        throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
    }

    @Override
    public void updateAsciiStream(int columnIndex, InputStream x, int length) {
        throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
    }

    @Override
    public void updateBinaryStream(int columnIndex, InputStream x, int length) {
        throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
    }

    @Override
    public void updateCharacterStream(int columnIndex, Reader x, int length) {
        throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
    }

    @Override
    public void updateObject(int columnIndex, Object x, int scaleOrLength) {
        throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
    }

    @Override
    public void updateObject(int columnIndex, Object x) {
        throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
    }

    @Override
    public void updateRow() {
        throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
    }

    @Override
    public void updateBlob(int i, net.vpc.upa.types.Blob blob) {
        throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
    }

    @Override
    public void updateBlob(int i, InputStream byteArrayInputStream) {
        throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
    }

    @Override
    public void updateClob(int i, net.vpc.upa.types.Clob clob) {
        throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
    }

    @Override
    public void updateClob(int i, Reader reader) {
        throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
    }

}
