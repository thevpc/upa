package net.thevpc.upa.impl.persistence.shared.marshallers;

import net.thevpc.upa.PortabilityHint;
import net.thevpc.upa.impl.persistence.MarshallManager;
import net.thevpc.upa.impl.persistence.SimpleTypeMarshaller;

import java.sql.Types;
import net.thevpc.upa.persistence.NativeResult;
import net.thevpc.upa.persistence.NativeStatement;

/**
* @author Taha BEN SALAH <taha.bensalah@gmail.com>
* @creationdate 11/22/12 10:02 PM
*/
@PortabilityHint(target = "C#", name = "suppress")
public class FloatAsDoubleMarshaller
        extends SimpleTypeMarshaller {

    private MarshallManager adapter;

    @Override
    public void setMarshallManager(MarshallManager marshallManager) {
        this.adapter = marshallManager;
    }

    public Object read(int index, NativeResult resultSet)
             {
        double n = resultSet.getDouble(index);
        if (n == 0D && resultSet.wasNull()) {
            return null;
        }
        return new Float(n);
    }

    public String toSQLLiteral(Object object) {
        if(object==null){
            return super.toSQLLiteral(object);
        }
        return String.valueOf(object);
    }

    public void write(Object object, int i, NativeStatement preparedStatement)
             {
        if (object == null) {
            preparedStatement.setNull(i, Types.DOUBLE);
        } else {
            preparedStatement.setDouble(i, ((Number) object).doubleValue());
        }
    }

    public void write(Object object, int i, NativeResult updatableResultSet)  {
        /**@PortabilityHint(target = "C#",name = "suppress")*/
        if (object == null) {
            updatableResultSet.updateNull(i);
        } else {
            updatableResultSet.updateDouble(i, ((Number) object).doubleValue());
        }
    }


    public boolean isLiteralSupported() {
        return true;
    }

    public FloatAsDoubleMarshaller(MarshallManager marshallManager) {
        super(marshallManager);
    }
}
