package net.vpc.upa.impl.persistence.shared.marshallers;

import net.vpc.upa.impl.persistence.MarshallManager;
import net.vpc.upa.impl.persistence.SimpleTypeMarshaller;
import net.vpc.upa.impl.util.DateUtils;

import java.sql.*;

/**
* @author Taha BEN SALAH <taha.bensalah@gmail.com>
* @creationdate 12/20/12 2:48 AM
*/
public class SqlTimeMarshaller
        extends SimpleTypeMarshaller {


    public Object read(int index, ResultSet resultSet)
            throws SQLException {
        /**
         * @PortabilityHint(target = "C#",name = "todo")
         **/
        if(true) {
            return resultSet.getTime(index);
        }
        return null;
    }

    @Override
    public void write(Object object, int i, ResultSet updatableResultSet) throws SQLException {
        /**@PortabilityHint(target = "C#",name = "suppress")*/
        updatableResultSet.updateTime(i, (((Time) object)));
    }

    @Override
    public String toSQLLiteral(Object object) {
        if(object==null){
            return super.toSQLLiteral(object);
        }
        return "{t '" + DateUtils.formatUniversalTime((java.util.Date) object) + "'}";
    }

    public void write(Object object, int i, PreparedStatement preparedStatement)
            throws SQLException {
        /**@PortabilityHint(target = "C#",name = "todo")*/
        if (object == null) {
            preparedStatement.setNull(i, Types.TIME);
        } else {
            preparedStatement.setTime(i,
                    (object instanceof Time)
                            ? ((Time) object)
                            : (new Time(((java.util.Date) object).getTime())));
        }
    }

    public SqlTimeMarshaller(MarshallManager marshallManager) {
        super(marshallManager);
    }
}
