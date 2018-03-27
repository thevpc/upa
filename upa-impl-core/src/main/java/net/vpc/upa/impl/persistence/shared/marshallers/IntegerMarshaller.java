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
public class IntegerMarshaller
        extends SimpleTypeMarshaller {

    public Object read(int index, net.vpc.upa.persistence.NativeResult resultSet)
            {
        /**
         * @PortabilityHint(target = "C#",name = "todo")
         * return null;
         **/
        {
            int n = resultSet.getInt(index);
            if (n == 0 && resultSet.wasNull()) {
                return null;
            }
            return Integer.valueOf(n);
        }
    }

    @Override
    public void write(Object object, int i, NativeResult updatableResultSet) {
        /**
         * @PortabilityHint(target = "C#",name = "suppress")
         */
        updatableResultSet.updateInt(i, ((Integer) object));
    }

    public String toSQLLiteral(Object object) {
        if (object == null) {
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
            preparedStatement.setNull(i, Types.INTEGER);
        } else {
            try {
                preparedStatement.setInt(i, (((Number) object)).intValue());
            } catch (ClassCastException e) {
                throw e;
            }
        }
    }

    public IntegerMarshaller(MarshallManager marshallManager) {
        super(marshallManager);
    }

    @Override
    public String toString() {
        return "IntegerMarshaller";
    }
}
