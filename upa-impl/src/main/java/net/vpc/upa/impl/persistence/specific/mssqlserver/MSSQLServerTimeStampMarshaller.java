package net.vpc.upa.impl.persistence.specific.mssqlserver;

import net.vpc.upa.PortabilityHint;
import net.vpc.upa.impl.persistence.MarshallManager;
import net.vpc.upa.types.DateTime;
import net.vpc.upa.impl.persistence.SimpleTypeMarshaller;
import net.vpc.upa.impl.util.DateUtils;

import java.sql.*;

/**
* @author Taha BEN SALAH <taha.bensalah@gmail.com>
* @creationdate 11/22/12 10:01 PM
*/
@PortabilityHint(target = "C#",name = "suppress")
class MSSQLServerTimeStampMarshaller
        extends SimpleTypeMarshaller {

    public Object read(int index, ResultSet resultSet)
            throws SQLException {
        Timestamp ts = resultSet.getTimestamp(index);
        return ts == null ? null : new DateTime(ts);
//            return resultSet.getTimestamp(index);
    }

    @Override
    public String toSQLLiteral(Object object) {
        if(object==null){
            return super.toSQLLiteral(object);
        }
        return "'" + DateUtils.formatUniversalDateTime(MSSQLServerPersistenceStore.toTimestamp(object)) + "'";
    }

    public void write(Object object, int i, ResultSet updatableResultSet) throws SQLException {
        /**@PortabilityHint(target = "C#",name = "suppress")*/
        if (object == null) {
            updatableResultSet.updateNull(i);
        } else {
            updatableResultSet.updateTimestamp(i, MSSQLServerPersistenceStore.toTimestamp(object));
        }
    }


    public void write(Object object, int i, PreparedStatement preparedStatement)
            throws SQLException {
        if (object == null) {
            preparedStatement.setNull(i, Types.TIMESTAMP);
        } else {
            preparedStatement.setTimestamp(i, MSSQLServerPersistenceStore.toTimestamp(object));
        }
    }

    public MSSQLServerTimeStampMarshaller(MarshallManager marshallManager) {
        super(marshallManager);
    }
}
