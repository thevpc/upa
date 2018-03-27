package net.vpc.upa.impl.persistence.shared.marshallers;

import net.vpc.upa.impl.persistence.MarshallManager;
import net.vpc.upa.types.Date;
import net.vpc.upa.impl.persistence.SimpleTypeMarshaller;
import net.vpc.upa.impl.util.DateUtils;

import java.sql.SQLException;
import java.sql.Types;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.persistence.NativeResult;
import net.vpc.upa.persistence.NativeStatement;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 12/20/12 2:48 AM
 */
public class DateOnlyMarshaller
        extends SimpleTypeMarshaller {

    public Object read(int index, net.vpc.upa.persistence.NativeResult resultSet) {
        /**
         * @PortabilityHint(target = "C#",name = "todo")
         *
         */
        if (true) {
            java.sql.Date t = resultSet.getDate(index);
            return t == null ? null : new Date(t);
        }
        return null;

    }

    @Override
    public void write(Object object, int i, NativeResult updatableResultSet) {
        updatableResultSet.updateDate(i, (java.sql.Date) object);
    }

    @Override
    public String toSQLLiteral(Object object) {
        if (object == null) {
            return super.toSQLLiteral(object);
        }
        return "{d '" + DateUtils.formatUniversalDate((java.util.Date) object) + "'}";
    }

    @Override
    public void write(Object object, int i, NativeStatement preparedStatement) {
        /**
         * @PortabilityHint(target = "C#",name = "todo")
         */
        if (object == null) {
            preparedStatement.setNull(i, Types.DATE);
        } else {
//                preparedStatement.setDate(i,
//                        (object instanceof java.sql.Date) ?
//                            ((java.sql.Date)object) :
//                            (new java.sql.Date(((java.util.Date)object).getTime()))
//                );
            preparedStatement.setTimestamp(i,
                    (object instanceof java.sql.Timestamp)
                            ? ((java.sql.Timestamp) object)
                            : (new java.sql.Timestamp(((java.util.Date) object).getTime())));
        }
    }

    public DateOnlyMarshaller(MarshallManager marshallManager) {
        super(marshallManager);
    }

    @Override
    public String toString() {
        return "DateOnlyMarshaller";
    }
}
