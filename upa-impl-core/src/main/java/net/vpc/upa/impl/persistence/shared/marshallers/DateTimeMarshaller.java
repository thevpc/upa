package net.vpc.upa.impl.persistence.shared.marshallers;

import net.vpc.upa.impl.persistence.MarshallManager;
import net.vpc.upa.types.DateTime;
import net.vpc.upa.impl.persistence.SimpleTypeMarshaller;
import net.vpc.upa.impl.util.DateUtils;

import java.sql.*;
import net.vpc.upa.persistence.NativeResult;
import net.vpc.upa.persistence.NativeStatement;

/**
* @author Taha BEN SALAH <taha.bensalah@gmail.com>
* @creationdate 12/20/12 2:48 AM
*/ //    protected class DateWrapper
//            implements DataWrapper {
//
//        public Object get(int index, ResultSet resultSet)
//                throws SQLException {
//            Date ts=resultSet.getDate(index);
//            return ts==null ? null : new Date(ts);
////            return resultSet.getDate(index);
//        }
//
//        public String litteral(Object object){
//            return "'" + Utils.UNIVERSAL_DATE_FORMAT.format((java.util.Date)object) + "'";
//        }
//
//        public void set(Object object, int i, PreparedStatement preparedStatement)
//                throws SQLException {
//            if(object==null){
//                preparedStatement.setNull(i,Types.DATE);
//            }else{
//                preparedStatement.setDate(i,
//                        (object instanceof java.sql.Date) ?
//                            ((java.sql.Date)object) :
//                            (new java.sql.Date(((java.util.Date)object).getTime()))
//                );
//            }
//        }
//
//        public boolean isLitteralSupported() {
//            return true;
//        }
//
//        public DateWrapper() {
//        }
//    }
public class DateTimeMarshaller
        extends SimpleTypeMarshaller {

    public Object read(int index, net.vpc.upa.persistence.NativeResult resultSet)
             {
        /**
         * @PortabilityHint(target = "C#",name = "todo")
         **/
        if(true) {
            Timestamp ts = resultSet.getTimestamp(index);
            return ts == null ? null : new DateTime(ts);

        }
        return null;
    }

    @Override
    public void write(Object object, int i, NativeResult updatableResultSet)  {
        /**@PortabilityHint(target = "C#",name = "suppress")*/
        updatableResultSet.updateTimestamp(i, new Timestamp(((java.util.Date)object).getTime()));
    }

    public String toSQLLiteral(Object object) {
        if(object==null){
            return super.toSQLLiteral(object);
        }
        //return "'" + Utils.UNIVERSAL_DATE_TIME_FORMAT.format((java.util.Date)object) + "'";
        return "{ts '" + DateUtils.formatUniversalDateTime((java.util.Date) object) + "'}";
    }

    public void write(Object object, int i, NativeStatement preparedStatement)
             {
        /**@PortabilityHint(target = "C#",name = "todo")*/
        if (object == null) {
            preparedStatement.setNull(i, Types.DATE);
        } else {
//                preparedStatement.setDate(i,
//                        (object instanceof java.sql.Date) ?
//                            ((java.sql.Date)object) :
//                            (new java.sql.Date(((java.util.Date)object).getTime()))
//                );
            preparedStatement.setTimestamp(i,
                    (object instanceof Timestamp)
                            ? ((Timestamp) object)
                            : (new Timestamp(((java.util.Date) object).getTime())));
        }
    }

    public DateTimeMarshaller(MarshallManager marshallManager) {
        super(marshallManager);
    }

    @Override
    public String toString() {
        return "DateTimeMarshaller";
    }
}
