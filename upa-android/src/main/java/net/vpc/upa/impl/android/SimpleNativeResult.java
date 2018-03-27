/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.android;

import java.io.InputStream;
import java.io.Reader;
import java.math.BigDecimal;
import java.sql.Date;
import java.sql.Time;
import java.sql.Timestamp;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

import net.vpc.upa.persistence.NativeResult;

/**
 * @author vpc
 */
public class SimpleNativeResult implements NativeResult {

    private List<List> rows = new ArrayList<>();
    private List<String> columnNames = new ArrayList<>();
    private List<String> columnTypes = new ArrayList<>();
    private int currentRow = -1;
    private boolean _wasNull = false;

    public void addRow(Object[] values) {
        rows.add(Arrays.asList(values));
    }

    public void addColumn(String name,Class type){
        columnNames.add(name);
        columnTypes.add(type.getName());
    }

    @Override
    public String getColumnName(int index) {
        return columnNames.get(index - 1);
    }

    @Override
    public int getColumnCount() {
        return columnNames.size();
    }

    @Override
    public String getColumnClassName(int column) {
        return columnTypes.get(column-1);
    }

    @Override
    public boolean next() {
        currentRow++;
        return currentRow < rows.size();
    }

    @Override
    public void close() {
        currentRow = Integer.MIN_VALUE;
    }

    @Override
    public boolean isClosed() {
        return currentRow == Integer.MIN_VALUE;
    }

    public Object getObject(int index) {
        Object o = rows.get(currentRow).get(index - 1);
        _wasNull = o == null;
        return o;
    }

    @Override
    public boolean wasNull() {
        return _wasNull;
    }

    @Override
    public String getString(int columnIndex) {
        Object v = getObject(columnIndex);
        return v == null ? null : String.valueOf(v);
    }

    @Override
    public boolean getBoolean(int columnIndex) {
        Object v = getObject(columnIndex);
        return v == null ? false : (v instanceof Number) ? ((Number) v).doubleValue() != 0 : Boolean.parseBoolean(String.valueOf(v));
    }

    @Override
    public byte getByte(int columnIndex) {
        Object v = getObject(columnIndex);
        return v == null ? 0 : (v instanceof Number) ? ((Number) v).byteValue() : Byte.parseByte(String.valueOf(v));
    }

    @Override
    public short getShort(int columnIndex) {
        Object v = getObject(columnIndex);
        return v == null ? 0 : (v instanceof Number) ? ((Number) v).shortValue() : Short.parseShort(String.valueOf(v));
    }

    @Override
    public int getInt(int columnIndex) {
        Object v = getObject(columnIndex);
        return v == null ? 0 : (v instanceof Number) ? ((Number) v).intValue() : Integer.parseInt(String.valueOf(v));
    }

    @Override
    public long getLong(int columnIndex) {
        Object v = getObject(columnIndex);
        return v == null ? 0 : (v instanceof Number) ? ((Number) v).longValue() : Long.parseLong(String.valueOf(v));
    }

    @Override
    public float getFloat(int columnIndex) {
        Object v = getObject(columnIndex);
        return v == null ? 0 : (v instanceof Number) ? ((Number) v).floatValue() : Float.parseFloat(String.valueOf(v));
    }

    @Override
    public double getDouble(int columnIndex) {
        Object v = getObject(columnIndex);
        return v == null ? 0 : (v instanceof Number) ? ((Number) v).doubleValue() : Double.parseDouble(String.valueOf(v));
    }

    @Override
    public byte[] getBytes(int columnIndex) {
        return (byte[]) getObject(columnIndex);
    }

    @Override
    public Date getDate(int columnIndex) {
        return (Date) getObject(columnIndex);
    }

    @Override
    public Time getTime(int columnIndex) {
        return (Time) getObject(columnIndex);
    }

    @Override
    public Timestamp getTimestamp(int columnIndex) {
        return (Timestamp) getObject(columnIndex);
    }

    @Override
    public BigDecimal getBigDecimal(int columnIndex) {
        return (BigDecimal) getObject(columnIndex);
    }

    @Override
    public net.vpc.upa.types.Blob getBlob(int columnIndex) {
        return (net.vpc.upa.types.Blob) getObject(columnIndex);
    }

    @Override
    public net.vpc.upa.types.Clob getClob(int columnIndex) {
        return (net.vpc.upa.types.Clob) getObject(columnIndex);
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
