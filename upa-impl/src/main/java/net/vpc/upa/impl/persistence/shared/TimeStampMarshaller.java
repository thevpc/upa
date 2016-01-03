package net.vpc.upa.impl.persistence.shared;

import net.vpc.upa.impl.persistence.SimpleTypeMarshaller;
import net.vpc.upa.impl.util.DateUtils;

import java.sql.*;

/**
* @author Taha BEN SALAH <taha.bensalah@gmail.com>
* @creationdate 12/20/12 2:48 AM
*/
public class TimeStampMarshaller
        extends SimpleTypeMarshaller {

    public Object read(int index, ResultSet resultSet)
            throws SQLException {
        Timestamp ts = resultSet.getTimestamp(index);
        return ts == null ? null : ts;
//            return resultSet.getTimestamp(index);
    }

    @Override
    public void write(Object object, int i, ResultSet updatableResultSet) throws SQLException {
        /**@PortabilityHint(target = "C#",name = "suppress")*/
        updatableResultSet.updateTimestamp(i, (Timestamp) object);
    }

    public String toSQLLiteral(Object object) {
        if(object==null){
            return super.toSQLLiteral(object);
        }
        return "{ts '" + DateUtils.formatUniversalDateTime((java.util.Date) object) + "'}";
    }

    public void write(Object object, int i, PreparedStatement preparedStatement)
            throws SQLException {
        if (object == null) {
            preparedStatement.setNull(i, Types.TIMESTAMP);
        } else {
            preparedStatement.setTimestamp(i,
                    (object instanceof Timestamp)
                            ? ((Timestamp) object)
                            : (new Timestamp(((java.util.Date) object).getTime())));
        }
    }

    public TimeStampMarshaller() {
    }
}
