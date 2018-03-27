package net.vpc.upa.impl.persistence.shared.marshallers;

import net.vpc.upa.impl.persistence.MarshallManager;
import net.vpc.upa.impl.persistence.SimpleTypeMarshaller;

import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Types;

import net.vpc.upa.impl.util.PlatformUtils;
import net.vpc.upa.persistence.NativeResult;
import net.vpc.upa.persistence.NativeStatement;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 12/20/12 2:47 AM
 */
public class EnumAsIntMarshaller
        extends SimpleTypeMarshaller {

    private Class<? extends Enum> type;
    private Object[] values;

    public EnumAsIntMarshaller(MarshallManager marshallManager,Class<? extends Enum> type) {
        super(marshallManager);
        this.type = type;
        values = PlatformUtils.getEnumValues(type);
    }

    public Object read(int index, net.vpc.upa.persistence.NativeResult resultSet)
             {
/**
 * @PortabilityHint(target = "C#",name = "todo")
 **/
        if(true) {
            int n = resultSet.getInt(index);

            if (n == 0 && resultSet.wasNull()) {
                return null;
            }
            try {
                return values[n];
            } catch (IndexOutOfBoundsException e) {
                return null;
            }
        }
        return null;
    }

    @Override
    public void write(Object object, int i, NativeResult updatableResultSet) {
        /**
         * @PortabilityHint(target = "C#",name = "suppress")
         */
        if (object == null) {
            updatableResultSet.updateNull(i);
        } else {
            updatableResultSet.updateInt(i, ((Enum) object).ordinal());
        }
    }

    @Override
    public String toSQLLiteral(Object object) {
        if (object == null) {
            return super.toSQLLiteral(object);
        }
        /**
         * @PortabilityHint(target = "C#",name = "replace")
         * return System.Convert.ToString((int)@object);
         */
        return String.valueOf(((Enum) object).ordinal());
    }

    public void write(Object object, int i, NativeStatement preparedStatement)
             {
/**
 * @PortabilityHint(target = "C#",name = "todo")
 **/
        if (object == null) {
            preparedStatement.setNull(i, Types.INTEGER);
        } else {
            preparedStatement.setInt(i, ((Enum) object).ordinal());
        }
    }

    @Override
    public String toString() {
        return "EnumAsIntMarshaller[" +
                type +
                ']';
    }
}
