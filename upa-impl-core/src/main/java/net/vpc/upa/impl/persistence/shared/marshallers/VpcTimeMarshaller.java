package net.vpc.upa.impl.persistence.shared.marshallers;

import net.vpc.upa.impl.persistence.MarshallManager;
import net.vpc.upa.impl.persistence.SimpleTypeMarshaller;
import net.vpc.upa.impl.util.DateUtils;

import java.sql.*;
import java.sql.Time;
import net.vpc.upa.persistence.NativeResult;
import net.vpc.upa.persistence.NativeStatement;

/**
* @author Taha BEN SALAH <taha.bensalah@gmail.com>
* @creationdate 12/20/12 2:48 AM
*/
public class VpcTimeMarshaller
        extends SimpleTypeMarshaller {


    public Object read(int index, net.vpc.upa.persistence.NativeResult resultSet)
            {
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
    public void write(Object object, int i, NativeResult updatableResultSet) {
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

    public void write(Object object, int i, NativeStatement preparedStatement)
            {
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

    public VpcTimeMarshaller(MarshallManager marshallManager) {
        super(marshallManager);
    }
}
