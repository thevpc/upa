/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package net.thevpc.upa.impl.android;

import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import java.io.InputStream;
import java.io.Reader;
import java.math.BigDecimal;
import java.sql.Date;
import java.sql.Time;
import java.sql.Timestamp;
import java.util.ArrayList;
import java.util.List;

import net.thevpc.upa.persistence.NativeResult;
import net.thevpc.upa.persistence.NativeStatement;
import net.thevpc.upa.types.Blob;
import net.thevpc.upa.types.Clob;

/**
 *
 * @author vpc
 */
public class AndroidSqliteNativeStatement implements NativeStatement {

    private SQLiteDatabase db;
    private String query;
    private List<Object> args = new ArrayList<>();
    private boolean gen;
    private int lastId = -1;

    public AndroidSqliteNativeStatement(SQLiteDatabase db, String query, boolean gen) {
        this.db = db;
        this.query = query;
        this.gen = gen;
    }

    @Override
    public int executeUpdate() {
        db.execSQL(query, args.toArray(new Object[args.size()]));
        if (gen) {
            Cursor cursor = db.rawQuery("SELECT last_insert_rowid() a, changes() b", null);
            if (cursor.getCount() > 0) {
                cursor.moveToFirst();
                lastId = Integer.parseInt(cursor.getString(0));
                return Integer.parseInt(cursor.getString(1));
            }
        } else {
            Cursor cursor = db.rawQuery("SELECT changes() b", null);
            if (cursor.getCount() > 0) {
                cursor.moveToFirst();
                return Integer.parseInt(cursor.getString(0));
            }
        }
        return 0;
    }

    @Override
    public NativeResult executeQuery() {
        String[] values = new String[args.size()];
        for (int i = 0; i < values.length; i++) {
            Object object = args.get(i);
            String s = null;
            if (object != null) {
                s = String.valueOf(object);
            }
            values[i] = s;
        }
        Cursor t = db.rawQuery(query, values);
        return new AndroidSqliteNativeResult(t);
    }

    @Override
    public NativeResult getGeneratedKeys() {
        SimpleNativeResult simpleNativeResult = new SimpleNativeResult();
        simpleNativeResult.addRow(new Object[]{lastId});
        return simpleNativeResult;
    }

    @Override
    public void setNull(int parameterIndex, int sqlType) {
        setObject(parameterIndex, null);
    }

    @Override
    public void setBoolean(int parameterIndex, boolean x) {
        setObject(parameterIndex, x);
    }

    @Override
    public void setByte(int parameterIndex, byte x) {
        setObject(parameterIndex, x);
    }

    @Override
    public void setShort(int parameterIndex, short x) {
        setObject(parameterIndex, x);
    }

    @Override
    public void setInt(int parameterIndex, int x) {
        setObject(parameterIndex, x);
    }

    @Override
    public void setLong(int parameterIndex, long x) {
        setObject(parameterIndex, x);
    }

    @Override
    public void setFloat(int parameterIndex, float x) {
        setObject(parameterIndex, x);
    }

    @Override
    public void setDouble(int parameterIndex, double x) {
        setObject(parameterIndex, x);
    }

    @Override
    public void setBigDecimal(int parameterIndex, BigDecimal x) {
        setObject(parameterIndex, x);
    }

    @Override
    public void setString(int parameterIndex, String x) {
        setObject(parameterIndex, x);
    }

    @Override
    public void setBytes(int parameterIndex, byte[] x) {
        setObject(parameterIndex, x);
    }

    @Override
    public void setDate(int parameterIndex, Date x) {
        setObject(parameterIndex, x);
    }

    @Override
    public void setTime(int parameterIndex, Time x) {
        setObject(parameterIndex, x);
    }

    @Override
    public void setTimestamp(int parameterIndex, Timestamp x) {
        setObject(parameterIndex, x);
    }

    @Override
    public void setBlob(int parameterIndex, Blob x) {
        setObject(parameterIndex, x);
    }

    @Override
    public void setBlob(int parameterIndex, InputStream x) {
        setObject(parameterIndex, x);
    }

    @Override
    public void setClob(int parameterIndex, Reader x) {
        setObject(parameterIndex, x);
    }

    @Override
    public void setClob(int parameterIndex, Clob x) {
        setObject(parameterIndex, x);
    }

    @Override
    public void setClob(int parameterIndex, String x) {
        setObject(parameterIndex, x);
    }

    @Override
    public void setObject(int i, Object object) {
        while (args.size() < i) {
            args.add(null);
        }
        args.set(i, object);
    }

}
