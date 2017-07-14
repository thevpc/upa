package net.vpc.upa.impl.persistence.shared.marshallers;

import net.vpc.upa.impl.persistence.MarshallManager;
import net.vpc.upa.impl.persistence.SimpleTypeMarshaller;

import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Types;

/**
* @author Taha BEN SALAH <taha.bensalah@gmail.com>
* @creationdate 12/20/12 2:46 AM
*/
public class BooleanToNumberMarshaller
        extends SimpleTypeMarshaller {

    public Object read(int index, ResultSet resultSet)
            throws SQLException {
        /**
         * @PortabilityHint(target = "C#",name = "todo")
         **/
        if(true) {
            return resultSet.getDouble(index) != 0.0D ? Boolean.TRUE : Boolean.FALSE;
        }
        return null;

    }

    public void write(Object object, int i, ResultSet updatableResultSet) throws SQLException {
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

    public void write(Object object, int i, PreparedStatement preparedStatement)
            throws SQLException {
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
