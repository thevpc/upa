package net.vpc.upa.impl.persistence.shared.marshallers;

import net.vpc.upa.impl.persistence.SimpleTypeMarshaller;
import net.vpc.upa.impl.util.DateUtils;

import java.sql.*;
import java.sql.Time;

/**
* @author Taha BEN SALAH <taha.bensalah@gmail.com>
* @creationdate 12/20/12 2:48 AM
*/
public class VpcTimeMarshaller
        extends SimpleTypeMarshaller {


    public Object read(int index, ResultSet resultSet)
            throws SQLException {
        /**
         * @PortabilityHint(target = "C#",name = "todo")
         **/
        if(true) {
            Time t = resultSet.getTime(index);
            return t == null ? null : new net.vpc.upa.types.Time(t);

        }
        return null;
    }

    @Override
    public void write(Object object, int i, ResultSet updatableResultSet) throws SQLException {
        /**@PortabilityHint(target = "C#",name = "suppress")*/
        updatableResultSet.updateTime(i, new Time(((java.sql.Date) object).getTime()));
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

    public VpcTimeMarshaller() {
    }
}
