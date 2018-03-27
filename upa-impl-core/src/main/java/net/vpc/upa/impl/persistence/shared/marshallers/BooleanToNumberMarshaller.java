package net.vpc.upa.impl.persistence.shared.marshallers;

import net.vpc.upa.impl.persistence.MarshallManager;
import net.vpc.upa.impl.persistence.SimpleTypeMarshaller;

import java.sql.SQLException;
import java.sql.Types;
import net.vpc.upa.persistence.NativeResult;
import net.vpc.upa.persistence.NativeStatement;

/**
* @author Taha BEN SALAH <taha.bensalah@gmail.com>
* @creationdate 12/20/12 2:46 AM
*/
public class BooleanToNumberMarshaller
        extends SimpleTypeMarshaller {

    public Object read(int index, net.vpc.upa.persistence.NativeResult resultSet)
             {
        /**
         * @PortabilityHint(target = "C#",name = "todo")
         **/
        if(true) {
            return resultSet.getDouble(index) != 0.0D ? Boolean.TRUE : Boolean.FALSE;
        }
        return null;

    }

    public void write(Object object, int i, NativeResult updatableResultSet) {
        /**@PortabilityHint(target = "C#",name = "suppress")*/
        updatableResultSet.updateInt(i, ((Boolean) object) ? 1 : 0);
    }
    @Override
    public String toSQLLiteral(Object object) {
        if(object==null){
            return super.toSQLLiteral(object);
        }
        Boolean b = (Boolean) object;
        return b.booleanValue() ? "1" : "0";
    }

    public void write(Object object, int i, NativeStatement preparedStatement)
             {
        /**@PortabilityHint(target = "C#",name = "todo")*/
        if (object == null) {
            preparedStatement.setNull(i, Types.INTEGER);
        } else {
            preparedStatement.setInt(i, ((Boolean) object).booleanValue() ? 1 : 0);
        }
    }

    public BooleanToNumberMarshaller(MarshallManager marshallManager) {
        super(marshallManager);
    }
}
