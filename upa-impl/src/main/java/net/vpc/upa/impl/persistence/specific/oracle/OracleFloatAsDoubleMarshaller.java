package net.vpc.upa.impl.persistence.specific.oracle;

import net.vpc.upa.PortabilityHint;
import net.vpc.upa.impl.persistence.MarshallManager;
import net.vpc.upa.impl.persistence.SimpleTypeMarshaller;

import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Types;

/**
* @author Taha BEN SALAH <taha.bensalah@gmail.com>
* @creationdate 1/8/13 1:52 AM
*/
@PortabilityHint(target = "C#", name = "suppress")
public class OracleFloatAsDoubleMarshaller
        extends SimpleTypeMarshaller {

    public Object read(int index, ResultSet resultSet)
            throws SQLException {
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

    public void write(Object object, int i, PreparedStatement preparedStatement)
            throws SQLException {
        if (object == null) {
            preparedStatement.setNull(i, Types.DOUBLE);
        } else {
            preparedStatement.setDouble(i, ((Number) object).doubleValue());
        }
    }

    public void write(Object object, int i, ResultSet updatableResultSet) throws SQLException {
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

    public OracleFloatAsDoubleMarshaller() {
    }

    @Override
    public void setMarshallManager(MarshallManager marshallManager) {

    }
}
