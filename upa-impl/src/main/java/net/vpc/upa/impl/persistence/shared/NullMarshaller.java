package net.vpc.upa.impl.persistence.shared;

import net.vpc.upa.impl.persistence.SimpleTypeMarshaller;

import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;

/**
* @author Taha BEN SALAH <taha.bensalah@gmail.com>
* @creationdate 12/20/12 2:46 AM
*/
public class NullMarshaller
        extends SimpleTypeMarshaller {

    public Object read(int index, ResultSet resultSet)
            throws SQLException {
        resultSet.getString(index);
        return null;
    }

    public void write(Object object, int i, ResultSet updatableResultSet) throws SQLException {
        /**@PortabilityHint(target = "C#",name = "suppress")*/
        updatableResultSet.updateString(i, null);
    }

    @Override
    public String toSQLLiteral(Object object) {
        return "NULL";
    }

    public void write(Object object, int i, PreparedStatement preparedStatement)
            throws SQLException {
        throw new RuntimeException("setter not supported for NullMarshaller");
    }

    public NullMarshaller() {
    }
}
