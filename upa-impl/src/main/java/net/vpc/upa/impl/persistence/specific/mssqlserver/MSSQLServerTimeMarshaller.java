package net.vpc.upa.impl.persistence.specific.mssqlserver;

import net.vpc.upa.PortabilityHint;
import net.vpc.upa.impl.persistence.MarshallManager;
import net.vpc.upa.impl.persistence.SimpleTypeMarshaller;
import net.vpc.upa.impl.util.DateUtils;

import java.sql.*;
import java.sql.Time;

/**
* @author Taha BEN SALAH <taha.bensalah@gmail.com>
* @creationdate 11/22/12 10:01 PM
*/
@PortabilityHint(target = "C#",name = "suppress")
class MSSQLServerTimeMarshaller
        extends SimpleTypeMarshaller {

    public Object read(int index, ResultSet resultSet)
            throws SQLException {
        Time t = resultSet.getTime(index);
        return t == null ? null : new net.vpc.upa.types.Time(t);
    }

    @Override
    public String toSQLLiteral(Object object) {
        if(object==null){
            return super.toSQLLiteral(object);
        }
        return "'" + DateUtils.formatUniversalTime((java.util.Date) object) + "'";
    }

    public void write(Object object, int i, PreparedStatement preparedStatement)
            throws SQLException {
        if (object == null) {
            preparedStatement.setNull(i, Types.TIME);
        } else {
            preparedStatement.setTime(i,
                    (object instanceof Time) ?
                            ((Time) object) :
                            (new Time(((java.util.Date) object).getTime()))
            );
        }
    }

    public void write(Object object, int i, ResultSet updatableResultSet) throws SQLException {
        /**@PortabilityHint(target = "C#",name = "suppress")*/
        if (object == null) {
            updatableResultSet.updateNull(i);
        } else {
            updatableResultSet.updateTime(i,
                    (object instanceof Time) ?
                            ((Time) object) :
                            (new Time(((java.util.Date) object).getTime()))
            );
        }
    }

    public MSSQLServerTimeMarshaller(MarshallManager marshallManager) {
        super(marshallManager);
    }
}
