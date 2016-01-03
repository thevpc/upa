package net.vpc.upa.impl.persistence.specific.mssqlserver;

import net.vpc.upa.types.Year;
import net.vpc.upa.impl.persistence.SimpleTypeMarshaller;
import net.vpc.upa.impl.util.DateUtils;

import java.sql.*;

/**
* @author Taha BEN SALAH <taha.bensalah@gmail.com>
* @creationdate 11/22/12 10:01 PM
*/
class MSSQLServerYearMarshaller
        extends SimpleTypeMarshaller {

    public Object read(int index, ResultSet resultSet)
            throws SQLException {
        Date t = resultSet.getDate(index);
        return t == null ? null : new Year(t);
    }

    @Override
    public String toSQLLiteral(Object object) {
        if(object==null){
            return super.toSQLLiteral(object);
        }
        return "'" + DateUtils.formatUniversalDateTime(MSSQLServerPersistenceStore.toTimestamp(object)) + "'";
    }

    public void write(Object object, int i, PreparedStatement preparedStatement)
            throws SQLException {
        if (object == null) {
            preparedStatement.setNull(i, Types.DATE);
        } else {
            preparedStatement.setTimestamp(i, MSSQLServerPersistenceStore.toTimestamp(object));
        }
    }

    public void write(Object object, int i, ResultSet updatableResultSet) throws SQLException {
        /**@PortabilityHint(target = "C#",name = "suppress")*/
        if (object == null) {
            updatableResultSet.updateNull(i);
        } else {
            updatableResultSet.updateTimestamp(i, MSSQLServerPersistenceStore.toTimestamp(object));
        }
    }

    public MSSQLServerYearMarshaller() {
    }
}
