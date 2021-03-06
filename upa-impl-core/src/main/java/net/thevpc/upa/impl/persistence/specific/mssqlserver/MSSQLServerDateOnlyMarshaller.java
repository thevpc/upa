package net.thevpc.upa.impl.persistence.specific.mssqlserver;

import net.thevpc.upa.PortabilityHint;
import net.thevpc.upa.impl.persistence.MarshallManager;
import net.thevpc.upa.impl.persistence.SimpleTypeMarshaller;
import net.thevpc.upa.impl.util.DateUtils;
import net.thevpc.upa.persistence.NativeResult;
import net.thevpc.upa.persistence.NativeStatement;
import net.thevpc.upa.types.Date;

import java.sql.Types;

/**
* @author Taha BEN SALAH <taha.bensalah@gmail.com>
* @creationdate 11/22/12 10:00 PM
*/
@PortabilityHint(target = "C#",name = "suppress")
class MSSQLServerDateOnlyMarshaller
        extends SimpleTypeMarshaller {

    public Object read(int index, NativeResult resultSet)
            {
        java.sql.Date t = resultSet.getDate(index);
        return t == null ? null : new Date(t);
    }

    @Override
    public String toSQLLiteral(Object object) {
        if(object==null){
            return super.toSQLLiteral(object);
        }
        //TODO : pkoa Utils.UNIVERSAL_DATE_TIME_FORMAT?
        //2005-11-05 j'ai change en date seulement
//            return "'" + Utils.UNIVERSAL_DATE_TIME_FORMAT.format(toTimestamp(object)) + "'";
        return "'" + DateUtils.formatUniversalDate(MSSQLServerPersistenceStore.toTimestamp(object)) + "'";
    }

    public void write(Object object, int i, NativeStatement preparedStatement)
             {
        if (object == null) {
            preparedStatement.setNull(i, Types.DATE);
        } else {
            preparedStatement.setTimestamp(i, MSSQLServerPersistenceStore.toTimestamp(object));
        }
    }

    public void write(Object object, int i, NativeResult updatableResultSet) {
        /**@PortabilityHint(target = "C#",name = "suppress")*/
        if (object == null) {
            updatableResultSet.updateNull(i);
        } else {
            updatableResultSet.updateTimestamp(i, MSSQLServerPersistenceStore.toTimestamp(object));
        }
    }

    public MSSQLServerDateOnlyMarshaller(MarshallManager marshallManager) {
        super(marshallManager);
    }
}
