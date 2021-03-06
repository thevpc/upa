package net.thevpc.upa.impl.persistence.shared.marshallers;

import net.thevpc.upa.impl.persistence.MarshallManager;
import net.thevpc.upa.impl.persistence.SimpleTypeMarshaller;

import java.sql.Types;
import net.thevpc.upa.persistence.NativeResult;
import net.thevpc.upa.persistence.NativeStatement;

/**
* @author Taha BEN SALAH <taha.bensalah@gmail.com>
* @creationdate 12/20/12 2:47 AM
*/
public class ShortMarshaller
        extends SimpleTypeMarshaller {
    public ShortMarshaller(MarshallManager marshallManager) {
        super(marshallManager);
    }

    public Object read(int index, NativeResult resultSet)
            {
        /**
         * @PortabilityHint(target = "C#",name = "todo")
         **/
        if(true) {
            short n = resultSet.getShort(index);
            if (n == 0 && resultSet.wasNull()) {
                return null;
            }
            return n;
        }
        return null;

    }

    @Override
    public void write(Object object, int i, NativeResult updatableResultSet) {
        /**@PortabilityHint(target = "C#",name = "suppress")*/
        updatableResultSet.updateShort(i, (Short) object);
    }

    public String toSQLLiteral(Object object) {
        if(object==null){
            return super.toSQLLiteral(object);
        }
        return String.valueOf(object);
    }

    public void write(Object object, int i, NativeStatement preparedStatement) {
        /**@PortabilityHint(target = "C#",name = "todo")*/
        if (object == null) {
            preparedStatement.setNull(i, Types.DOUBLE);
        } else {
            preparedStatement.setShort(i, ((Number) object).shortValue());
        }
    }
}
