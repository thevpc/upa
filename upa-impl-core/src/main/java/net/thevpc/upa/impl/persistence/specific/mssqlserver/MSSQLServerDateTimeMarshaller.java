package net.thevpc.upa.impl.persistence.specific.mssqlserver;

import net.thevpc.upa.PortabilityHint;
import net.thevpc.upa.impl.persistence.MarshallManager;
import net.thevpc.upa.impl.persistence.SimpleTypeMarshaller;
import net.thevpc.upa.impl.util.DateUtils;
import net.thevpc.upa.persistence.NativeResult;
import net.thevpc.upa.persistence.NativeStatement;
import net.thevpc.upa.types.DateTime;

import java.sql.*;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 11/22/12 10:02 PM
 */
@PortabilityHint(target = "C#", name = "suppress")
class MSSQLServerDateTimeMarshaller
        extends SimpleTypeMarshaller {

    public Object read(int index, NativeResult resultSet) {
//            Timestamp ts=resultSet.getDate(index);
        Timestamp ts = resultSet.getTimestamp(index);
        return ts == null ? null : new DateTime(ts);
    }

    @Override
    public String toSQLLiteral(Object object) {
        if (object == null) {
            return super.toSQLLiteral(object);
        }
        //return "'" + Utils.UNIVERSAL_DATE_TIME_FORMAT.format((java.util.Date)object) + "'";
        return "'" + DateUtils.formatUniversalDateTime(MSSQLServerPersistenceStore.toTimestamp(object)) + "'";
    }

    public void write(Object object, int i, NativeStatement preparedStatement) {
        if (object == null) {
            preparedStatement.setNull(i, Types.DATE);
        } else {
            preparedStatement.setTimestamp(i, MSSQLServerPersistenceStore.toTimestamp(object));
        }
    }

    public void write(Object object, int i, NativeResult updatableResultSet) {
        /**
         * @PortabilityHint(target = "C#",name = "suppress")
         */
        if (object == null) {
            updatableResultSet.updateNull(i);
        } else {
            updatableResultSet.updateTimestamp(i, MSSQLServerPersistenceStore.toTimestamp(object));
        }
    }

    public MSSQLServerDateTimeMarshaller(MarshallManager marshallManager) {
        super(marshallManager);
    }
}
