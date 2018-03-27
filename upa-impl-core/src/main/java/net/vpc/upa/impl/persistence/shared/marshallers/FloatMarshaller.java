package net.vpc.upa.impl.persistence.shared.marshallers;

import net.vpc.upa.impl.persistence.MarshallManager;
import net.vpc.upa.impl.persistence.SimpleTypeMarshaller;

import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Types;
import net.vpc.upa.persistence.NativeResult;
import net.vpc.upa.persistence.NativeStatement;

/**
* @author Taha BEN SALAH <taha.bensalah@gmail.com>
* @creationdate 12/20/12 2:47 AM
*/
public class FloatMarshaller
        extends SimpleTypeMarshaller {

    public Object read(int index, net.vpc.upa.persistence.NativeResult resultSet)
             {
        /**
         * @PortabilityHint(target = "C#",name = "todo")
         * return null;
         **/
        {
            float f = resultSet.getFloat(index);
            if (f == 0f && resultSet.wasNull()) {
                return null;
            }
            return new Float(f);
        }
    }

    @Override
    public void write(Object object, int i, NativeResult updatableResultSet)  {
        /**@PortabilityHint(target = "C#",name = "suppress")*/
        updatableResultSet.updateFloat(i, (Float) object);
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
        /**
         * @PortabilityHint(target = "C#",name = "todo")
         **/
        if (object == null) {
            preparedStatement.setNull(i, Types.FLOAT);
        } else {
            preparedStatement.setFloat(i, (((Number) object)).floatValue());
        }
    }

    public FloatMarshaller(MarshallManager marshallManager) {
        super(marshallManager);
    }
}
