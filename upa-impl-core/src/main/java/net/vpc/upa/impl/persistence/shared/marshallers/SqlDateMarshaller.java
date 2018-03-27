package net.vpc.upa.impl.persistence.shared.marshallers;

import net.vpc.upa.impl.persistence.MarshallManager;
import net.vpc.upa.impl.persistence.SimpleTypeMarshaller;
import net.vpc.upa.impl.util.DateUtils;

import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Types;
import net.vpc.upa.persistence.NativeResult;
import net.vpc.upa.persistence.NativeStatement;

/**
* @author Taha BEN SALAH <taha.bensalah@gmail.com>
* @creationdate 12/20/12 2:48 AM
*/
public class SqlDateMarshaller
        extends SimpleTypeMarshaller {

    public Object read(int index, net.vpc.upa.persistence.NativeResult resultSet)
            {
        /**
         * @PortabilityHint(target = "C#",name = "todo")
         **/
        if(true) {
            java.sql.Date t = resultSet.getDate(index);
            return t;
        }
        return null;

    }

    public String toSQLLiteral(Object object) {
        if(object==null){
            return super.toSQLLiteral(object);
        }
        return "{d '" + DateUtils.formatUniversalDate((java.util.Date) object) + "'}";
    }

    @Override
    public void write(Object object, int i, NativeResult updatableResultSet)  {
        /**@PortabilityHint(target = "C#",name = "suppress")*/
        updatableResultSet.updateDate(i,(java.sql.Date)object);
    }

    public void write(Object object, int i, NativeStatement preparedStatement)
             {
        /**@PortabilityHint(target = "C#",name = "todo")*/
        if (object == null) {
            preparedStatement.setNull(i, Types.DATE);
        } else {
//                preparedStatement.setDate(i,
//                        (object instanceof java.sql.Date) ?
//                            ((java.sql.Date)object) :
//                            (new java.sql.Date(((java.util.Date)object).getTime()))
//                );
            preparedStatement.setDate(i,
                    (object instanceof java.sql.Date)
                            ? ((java.sql.Date) object)
                            : (new java.sql.Date(((java.util.Date) object).getTime())));
        }
    }

    public SqlDateMarshaller(MarshallManager marshallManager) {
        super(marshallManager);
    }
}
