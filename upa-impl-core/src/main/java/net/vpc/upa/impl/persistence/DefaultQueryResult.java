/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.persistence;

import java.sql.ResultSetMetaData;
import net.vpc.upa.exceptions.FindException;
import net.vpc.upa.impl.UPAImplDefaults;
import net.vpc.upa.impl.util.UPADeadLock;
import net.vpc.upa.persistence.QueryResult;
import net.vpc.upa.types.DataTypeTransform;
import net.vpc.upa.types.I18NString;

import java.util.HashMap;
import java.util.Map;
import java.util.logging.Level;
import java.util.logging.Logger;
import net.vpc.upa.persistence.NativeResult;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class DefaultQueryResult implements QueryResult {

    private static final Logger log = Logger.getLogger(DefaultQueryResult.class.getName());
    private NativeResult resultSet;
    private TypeMarshaller[] marshallers;
    private DataTypeTransform[] types;
    private boolean closed;
    private int[] nativePos;
    private Map<Integer, Object> updates = new HashMap<Integer, Object>();
    private String query;
    private String nameDebugString;
    private UPADeadLock.VrDeadLockInfo mon;

    public DefaultQueryResult(String nameDebugString, String query, NativeResult resultSet, TypeMarshaller[] marshallers, DataTypeTransform[] types) {
        this.nameDebugString = nameDebugString;
        this.query = query;
        this.resultSet = resultSet;
        this.marshallers = marshallers;
        this.types = types;
        this.nativePos = new int[marshallers.length];
        int lastNativePos = 1;
        int np = 0;
        for (TypeMarshaller marshaller : marshallers) {
            nativePos[np] = lastNativePos;
            lastNativePos += marshaller.getSize();
            np++;
        }
        if (!UPAImplDefaults.PRODUCTION_MODE) {
            mon = UPADeadLock.addMonitor("QueryResult", query, 20, new Throwable());
        }
//        try {
//            System.out.println("create ResultSet " + resultSet + " for connection " + resultSet.getStatement().getConnection());
//        } catch (SQLException ex) {
//            ex.printStackTrace();
//        }
    }

    @Override
    public int getColumnsCount() {
        return marshallers.length;
    }

    @Override
    public String getColumnName(int index) {
        try {
            return resultSet.getColumnName(nativePos[index]);
        } catch (Exception e) {
            throw new FindException(e, new I18NString("ReadQueryResultColumnFailed"), index, nativePos[index]);
        }
    }

    @Override
    public Class getColumnType(int index) {
        try {
            return Class.forName(resultSet.getColumnClassName(nativePos[index]));
        } catch (Exception e) {
            throw new FindException(e, new I18NString("ReadQueryResultColumnFailed"), index, nativePos[index]);
        }
    }

    @Override
    public <T> T read(int index) {
        try {
            Object read = marshallers[index].read(nativePos[index], resultSet);
//            read = types[index].reverseTransformValue(read);
            return (T) read;
        } catch (Exception e) {
            throw new FindException(e, new I18NString("ReadQueryResultColumnFailed"), index, nativePos[index]);
        }
    }

    @Override
    public <T> void write(int index, T value) {
        updates.put(index, value);
    }

    @Override
    public boolean hasNext() {
        try {
            if (closed || resultSet.isClosed()) {
                log.log(Level.WARNING, nameDebugString + " ResultSet closed, unable to retrieve next document : " + query);
            }
            updates.clear();
            return resultSet.next();
        } catch (Exception e) {
            boolean alreadyClosed = false;
            try {
                alreadyClosed = resultSet.isClosed();
            } catch (Exception e2) {
                //ignore
            }
            if (alreadyClosed) {
                return false;
            }
            throw new FindException(e, new I18NString("ReadQueryHasNextFailed"));
        }
    }

    public void close() {
        try {
            if (!UPAImplDefaults.PRODUCTION_MODE) {
                if (!closed) {
                    mon.release();
//                log.log(Level.FINE, nameDebugString+" executeQuery     : "+query);
                    log.log(Level.FINE, nameDebugString + " RS closed   " + query);
                } else {
                    log.log(Level.WARNING, "       " + nameDebugString + " ResultSet re-closed: " + query);
                }
            }
            closed = true;
            resultSet.close();
//            System.out.println("close  ResultSet " + resultSet);
        } catch (Exception e) {
            throw new FindException(e, new I18NString("CloseFailed"));
        }
    }

    public void updateCurrent() {
        Integer index = null;
        try {
            for (Map.Entry<Integer, Object> entry : updates.entrySet()) {
                index = entry.getKey();
                marshallers[index].write(entry.getValue(), nativePos[index], resultSet);
            }

            /**
             * @PortabilityHint(target="C#",name="ignore")
             */
            resultSet.updateRow();
        } catch (Exception e) {
            throw new FindException(e, new I18NString("ReadQueryResultColumnFailed"), index, index == null ? null : nativePos[index]);
        }
    }
}
