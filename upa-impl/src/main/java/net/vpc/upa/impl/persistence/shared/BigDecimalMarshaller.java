package net.vpc.upa.impl.persistence.shared;

import net.vpc.upa.PortabilityHint;
import net.vpc.upa.impl.persistence.SimpleTypeMarshaller;

import java.math.BigDecimal;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Types;

/**
* @author Taha BEN SALAH <taha.bensalah@gmail.com>
* @creationdate 12/20/12 2:47 AM
*/
@PortabilityHint(target = "C#",name = "ignore")
public class BigDecimalMarshaller
        extends SimpleTypeMarshaller {

    public Object read(int index, ResultSet resultSet)
            throws SQLException {
        return resultSet.getBigDecimal(index);
    }

    @Override
    public void write(Object object, int i, ResultSet updatableResultSet) throws SQLException {
        /**@PortabilityHint(target = "C#",name = "suppress")*/
        updatableResultSet.updateBigDecimal(i, (BigDecimal) object);
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
            preparedStatement.setNull(i, Types.DECIMAL);
        } else {
            preparedStatement.setBigDecimal(i, ((BigDecimal) object));
        }
    }

    public BigDecimalMarshaller() {
    }
}
