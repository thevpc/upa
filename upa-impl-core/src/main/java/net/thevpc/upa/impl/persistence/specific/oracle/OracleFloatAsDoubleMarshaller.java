package net.thevpc.upa.impl.persistence.specific.oracle;

import net.thevpc.upa.PortabilityHint;
import net.thevpc.upa.impl.persistence.MarshallManager;
import net.thevpc.upa.impl.persistence.SimpleTypeMarshaller;
import net.thevpc.upa.persistence.NativeResult;
import net.thevpc.upa.persistence.NativeStatement;

import java.sql.Types;

/**
* @author Taha BEN SALAH <taha.bensalah@gmail.com>
* @creationdate 1/8/13 1:52 AM
*/
@PortabilityHint(target = "C#", name = "suppress")
public class OracleFloatAsDoubleMarshaller
        extends SimpleTypeMarshaller {

    public Object read(int index, NativeResult resultSet)
            {
        double n = resultSet.getDouble(index);
        if (n == 0D && resultSet.wasNull()) return null;
        return new Float(n);
    }

    @Override
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

    @Override
    public boolean isLiteralSupported() {
        return true;
    }

    public OracleFloatAsDoubleMarshaller(MarshallManager marshallManager) {
        super(marshallManager);
    }
}
