package net.thevpc.upa.impl.persistence.shared.marshallers;

import net.thevpc.upa.impl.persistence.MarshallManager;
import net.thevpc.upa.types.Year;
import net.thevpc.upa.impl.persistence.SimpleTypeMarshaller;
import net.thevpc.upa.impl.util.DateUtils;

import java.sql.Types;
import net.thevpc.upa.persistence.NativeResult;
import net.thevpc.upa.persistence.NativeStatement;

/**
* @author Taha BEN SALAH <taha.bensalah@gmail.com>
* @creationdate 12/20/12 2:48 AM
*/
public class YearMarshaller
        extends SimpleTypeMarshaller {

    public Object read(int index, NativeResult resultSet)
             {
        /**
         * @PortabilityHint(target = "C#",name = "todo")
         **/
        if(true) {
            java.sql.Date t = resultSet.getDate(index);
            return t == null ? null : new Year(t);

        }
        return null;
    }

    @Override
    public void write(Object object, int i, NativeResult updatableResultSet) {
        /**@PortabilityHint(target = "C#",name = "suppress")*/
        updatableResultSet.updateDate(i,(java.sql.Date)object);
    }

    @Override
    public String toSQLLiteral(Object object) {
        if(object==null){
            return super.toSQLLiteral(object);
        }
        return "{d '" + DateUtils.formatUniversalDate((java.util.Date) object) + "'}";
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
            preparedStatement.setTimestamp(i,
                    (object instanceof java.sql.Timestamp)
                            ? ((java.sql.Timestamp) object)
                            : (new java.sql.Timestamp(((java.util.Date) object).getTime())));
        }
    }

    public YearMarshaller(MarshallManager marshallManager) {
        super(marshallManager);
    }
}
