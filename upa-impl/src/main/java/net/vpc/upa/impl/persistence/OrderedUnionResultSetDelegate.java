///*
// * Created by IntelliJ IDEA.
// * User: taha
// * Date: 6 nov. 02
// * Time: 13:30:40
// * To change template for new class use
// * Code Style | Class Templates options (Tools | IDE Options).
// */
//package net.vpc.upa.impl.persistence;
//
//
//import net.vpc.upa.impl.util.UPAUtils;
//
//import java.io.InputStream;
//import java.io.Reader;
//import java.math.BigDecimal;
//import java.net.URL;
//import java.sql.*;
//import java.util.Arrays;
//import java.util.Calendar;
//import java.util.Map;
//
//public class OrderedUnionResultSetDelegate extends ResultSetHandler {
//    private ResultSet[] rs;
//    private int current_index;
//    private int[] rs_next_call_consumed;
//    private int[] orderColumns;
//    public static final int UNKNOWN = 0;
//    public static final int TRUE = 1;
//    public static final int FALSE = 2;
//
//    private boolean[] asc;
//
//    private static final boolean[] fillBool(int length, boolean val) {
//        boolean[] b = new boolean[length];
//        Arrays.fill(b, val);
//        return b;
//    }
//
//    public OrderedUnionResultSetDelegate(ResultSet[] rs, int orderColumn, boolean asc) {
//        this(
//                rs, new int[]{orderColumn}, new boolean[]{asc}
//        );
//    }
//
//    public OrderedUnionResultSetDelegate(ResultSet[] rs, int[] orderColumns, boolean asc) {
//        this(
//                rs, orderColumns, orderColumns == null ? null : fillBool(orderColumns.length, asc)
//        );
//    }
//
//    public OrderedUnionResultSetDelegate(ResultSet[] rs, int[] orderColumns, boolean[] asc) {
//        super(rs[0]);
//        if (orderColumns != null && orderColumns.length > 2) {
//            throw new IllegalArgumentException("sorry, order columns > 2 not yet implemented...");
//        }
//        this.rs = rs;
//        this.orderColumns = orderColumns;
//        this.asc = asc;
//        if (orderColumns != null) {
//            if (orderColumns.length == 0 || asc == null || asc.length != orderColumns.length) {
//                throw new IllegalArgumentException();
//            }
//        } else {
//            if (asc != null) {
//                throw new IllegalArgumentException();
//            }
//        }
//        this.rs_next_call_consumed = new int[rs.length];
//    }
//
////    public boolean next() throws SQLException {
////        for(int i=0;i<rs.length;i++){
////            if(rs_next_call_consumed[i]==UNKNOWN){
////                rs_next_call_consumed[i]=rs[i].next() ? TRUE:FALSE;
////            }
////        }
////        boolean next_result=false;
////
////        if(orderColumns!=null && orderColumns.length>0){
////            int max=-1;
////            int min=-1;
////            Object maxObject=null;
////            Object minObject=null;
////            Object[] values=new Object[rs.length];
////            for(int i=0;i<rs.length;i++){
////                if(rs_next_call_consumed[i]==TRUE){
////                    next_result=true;
////                    values[i]=rs[i].getObject(orderColumns[0]);
////                }else{
////                    values[i]=UNDEFINED;
////                }
////
////                if((maxObject==null && values[i]!=UNDEFINED) ||(values[i]!=null && values[i]!=UNDEFINED && ((Comparable)values[i]).compareTo(maxObject)>0)){
////					maxObject=values[i];
////                    max=i;
////                }
////                if(values[i]==null) {
////                    minObject=null;
////                    min=i;
////                }else if ((minObject==null && values[i]!=UNDEFINED) || (values[i]!=UNDEFINED && ((Comparable)values[i]).compareTo(minObject)<0)){
////                    minObject=values[i];
////                    min=i;
////                }
////            }
////
////            if(asc){
////                current_index=min;
////            }else{
////                current_index=max;
////            }
////			if(current_index>=0){
////				rs_next_call_consumed[current_index]=UNKNOWN;
////			}
////        }else{
////            for(int i=0;i<rs.length;i++){
////                if(rs_next_call_consumed[i]==TRUE){
////                    current_index=i;
////					rs_next_call_consumed[i]=UNKNOWN;
////                    next_result=true;
////                    break;
////                }
////            }
////        }
////        return next_result;
////    }
//
//    public boolean next() throws SQLException {
//        for (int i = 0; i < rs.length; i++) {
//            if (rs_next_call_consumed[i] == UNKNOWN) {
//                rs_next_call_consumed[i] = rs[i].next() ? TRUE : FALSE;
//            }
//        }
//        boolean next_result = false;
//
//        if (orderColumns != null && orderColumns.length > 0) {
//            Object[][] values = new Object[rs.length][];
//            for (int i = 0; i < rs.length; i++) {
//                if (rs_next_call_consumed[i] == TRUE) {
//                    next_result = true;
//                    Object[] vi = new Object[orderColumns.length];
//                    for (int j = 0; j < orderColumns.length; j++) {
//                        vi[j] = rs[i].getObject(orderColumns[j]);
//                    }
//                    values[i] = vi;
//                } else {
//                    values[i] = UPAUtils.UNDEFINED_ARRAY;
//                }
//            }
//            if (next_result) {
//                int[] max = UPAUtils.maxIndexes(values, asc);
//                if (max == null) {
//                    current_index = -1;
//                } else {
//                    current_index = max[0];
//                }
//                if (current_index >= 0) {
//                    rs_next_call_consumed[current_index] = UNKNOWN;
//                }
//            }
//        } else {
//            for (int i = 0; i < rs.length; i++) {
//                if (rs_next_call_consumed[i] == TRUE) {
//                    current_index = i;
//                    rs_next_call_consumed[i] = UNKNOWN;
//                    next_result = true;
//                    break;
//                }
//            }
//        }
//        return next_result;
//    }
//
//    public Timestamp getTimestamp(String param_1, Calendar param_2)
//            throws SQLException {
//        return rs[current_index].getTimestamp(param_1, param_2);
//    }
//
//    public short getShort(int param_1)
//            throws SQLException {
//        return rs[current_index].getShort(param_1);
//    }
//
//    public short getShort(String param_1)
//            throws SQLException {
//        return rs[current_index].getShort(param_1);
//    }
//
//    public Statement getStatement()
//            throws SQLException {
//        return rs[current_index].getStatement();
//    }
//
//    public String getString(int param_1)
//            throws SQLException {
//        return rs[current_index].getString(param_1);
//    }
//
//    public String getString(String param_1)
//            throws SQLException {
//        return rs[current_index].getString(param_1);
//    }
//
//    public Time getTime(int param_1)
//            throws SQLException {
//        return rs[current_index].getTime(param_1);
//    }
//
//    public Time getTime(int param_1, Calendar param_2)
//            throws SQLException {
//        return rs[current_index].getTime(param_1, param_2);
//    }
//
//    public Time getTime(String param_1)
//            throws SQLException {
//        return rs[current_index].getTime(param_1);
//    }
//
//    public Time getTime(String param_1, Calendar param_2)
//            throws SQLException {
//        return rs[current_index].getTime(param_1, param_2);
//    }
//
//    public Timestamp getTimestamp(int param_1)
//            throws SQLException {
//        return rs[current_index].getTimestamp(param_1);
//    }
//
//    public Timestamp getTimestamp(int param_1, Calendar param_2)
//            throws SQLException {
//        return rs[current_index].getTimestamp(param_1, param_2);
//    }
//
//    public Timestamp getTimestamp(String param_1)
//            throws SQLException {
//        return rs[current_index].getTimestamp(param_1);
//    }
//
////    public InputStream getUnicodeStream(int param_1)
////            throws SQLException {
////        return rs[current_index].getUnicodeStream(param_1);
////    }
//
////    public InputStream getUnicodeStream(String param_1)
////            throws SQLException {
////        return rs[current_index].getUnicodeStream(param_1);
////    }
//
//    public URL getURL(int param_1)
//            throws SQLException {
//        return rs[current_index].getURL(param_1);
//    }
//
//    public URL getURL(String param_1)
//            throws SQLException {
//        return rs[current_index].getURL(param_1);
//    }
//
//    public Ref getRef(String param_1)
//            throws SQLException {
//        return rs[current_index].getRef(param_1);
//    }
//
//    public Ref getRef(int param_1)
//            throws SQLException {
//        return rs[current_index].getRef(param_1);
//    }
//
//    public Object getObject(String param_1, Map param_2)
//            throws SQLException {
//        return rs[current_index].getObject(param_1, param_2);
//    }
//
//    public Object getObject(String param_1)
//            throws SQLException {
//        return rs[current_index].getObject(param_1);
//    }
//
//    public Object getObject(int param_1, Map param_2)
//            throws SQLException {
//        return rs[current_index].getObject(param_1, param_2);
//    }
//
//    public Object getObject(int param_1)
//            throws SQLException {
//        return rs[current_index].getObject(param_1);
//    }
//
//    public long getLong(String param_1)
//            throws SQLException {
//        return rs[current_index].getLong(param_1);
//    }
//
//    public long getLong(int param_1)
//            throws SQLException {
//        return rs[current_index].getLong(param_1);
//    }
//
//    public int getInt(String param_1)
//            throws SQLException {
//        return rs[current_index].getInt(param_1);
//    }
//
//    public int getInt(int param_1)
//            throws SQLException {
//        return rs[current_index].getInt(param_1);
//    }
//
//    public float getFloat(String param_1)
//            throws SQLException {
//        return rs[current_index].getFloat(param_1);
//    }
//
//    public float getFloat(int param_1)
//            throws SQLException {
//        return rs[current_index].getFloat(param_1);
//    }
//
//    public double getDouble(String param_1)
//            throws SQLException {
//        return rs[current_index].getDouble(param_1);
//    }
//
//    public double getDouble(int param_1)
//            throws SQLException {
//        return rs[current_index].getDouble(param_1);
//    }
//
//    public Date getDate(String param_1, Calendar param_2)
//            throws SQLException {
//        return rs[current_index].getDate(param_1, param_2);
//    }
//
//    public Date getDate(String param_1)
//            throws SQLException {
//        return rs[current_index].getDate(param_1);
//    }
//
//    public Date getDate(int param_1, Calendar param_2)
//            throws SQLException {
//        return rs[current_index].getDate(param_1, param_2);
//    }
//
//    public Date getDate(int param_1)
//            throws SQLException {
//        return rs[current_index].getDate(param_1);
//    }
//
//    public Clob getClob(String param_1)
//            throws SQLException {
//        return rs[current_index].getClob(param_1);
//    }
//
//    public Clob getClob(int param_1)
//            throws SQLException {
//        return rs[current_index].getClob(param_1);
//    }
//
//    public Reader getCharacterStream(String param_1)
//            throws SQLException {
//        return rs[current_index].getCharacterStream(param_1);
//    }
//
//    public Reader getCharacterStream(int param_1)
//            throws SQLException {
//        return rs[current_index].getCharacterStream(param_1);
//    }
//
//    public byte[] getBytes(String param_1)
//            throws SQLException {
//        return rs[current_index].getBytes(param_1);
//    }
//
//    public byte[] getBytes(int param_1)
//            throws SQLException {
//        return rs[current_index].getBytes(param_1);
//    }
//
//    public byte getByte(String param_1)
//            throws SQLException {
//        return rs[current_index].getByte(param_1);
//    }
//
//    public byte getByte(int param_1)
//            throws SQLException {
//        return rs[current_index].getByte(param_1);
//    }
//
//    public boolean getBoolean(String param_1)
//            throws SQLException {
//        return rs[current_index].getBoolean(param_1);
//    }
//
//    public boolean getBoolean(int param_1)
//            throws SQLException {
//        return rs[current_index].getBoolean(param_1);
//    }
//
//    public Blob getBlob(String param_1)
//            throws SQLException {
//        return rs[current_index].getBlob(param_1);
//    }
//
//    public Blob getBlob(int param_1)
//            throws SQLException {
//        return rs[current_index].getBlob(param_1);
//    }
//
//    public InputStream getBinaryStream(String param_1)
//            throws SQLException {
//        return rs[current_index].getBinaryStream(param_1);
//    }
//
//    public InputStream getBinaryStream(int param_1)
//            throws SQLException {
//        return rs[current_index].getBinaryStream(param_1);
//    }
//
////    public BigDecimal getBigDecimal(String param_1, int param_2)
////            throws SQLException {
////        return rs[current_index].getBigDecimal(param_1, param_2);
////    }
//
//    public BigDecimal getBigDecimal(String param_1)
//            throws SQLException {
//        return rs[current_index].getBigDecimal(param_1);
//    }
//
//    //    public BigDecimal getBigDecimal(int param_1, int param_2)
////            throws SQLException {
////        return rs[current_index].getBigDecimal(param_1, param_2);
////    }
////
//    public BigDecimal getBigDecimal(int param_1)
//            throws SQLException {
//        return rs[current_index].getBigDecimal(param_1);
//    }
//
//    public InputStream getAsciiStream(String param_1)
//            throws SQLException {
//        return rs[current_index].getAsciiStream(param_1);
//    }
//
//    public InputStream getAsciiStream(int param_1)
//            throws SQLException {
//        return rs[current_index].getAsciiStream(param_1);
//    }
//
//    public Array getArray(String param_1)
//            throws SQLException {
//        return rs[current_index].getArray(param_1);
//    }
//
//    public Array getArray(int param_1)
//            throws SQLException {
//        return rs[current_index].getArray(param_1);
//    }
//
//    public boolean wasNull()
//            throws SQLException {
//        return rs[current_index].wasNull();
//    }
//
//    public int getCurrentResultSetIndex() {
//        return current_index;
//    }
//
//    public ResultSet[] getResultSetArray() {
//        return rs;
//    }
//
//    public void close()
//            throws SQLException {
//        for (ResultSet r : rs) {
//            r.close();
//        }
//    }
//
//    public void closeStatements()
//            throws SQLException {
//        for (ResultSet r : rs) {
//            if (r instanceof OrderedUnionResultSetDelegate) {
//                ((OrderedUnionResultSetDelegate) r).closeStatements();
//            } else {
//                r.getStatement().close();
//            }
//        }
//    }
//}
