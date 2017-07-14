package net.vpc.upa.impl.persistence.shared.marshallers;

import net.vpc.upa.impl.persistence.MarshallManager;
import net.vpc.upa.impl.persistence.SimpleTypeMarshaller;

import java.math.BigDecimal;
import java.math.BigInteger;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Types;

/**
* @author Taha BEN SALAH <taha.bensalah@gmail.com>
* @creationdate 12/20/12 2:47 AM
*/
public class BigIntegerMarshaller
        extends SimpleTypeMarshaller {

    public Object read(int index, ResultSet resultSet)
            throws SQLException {
        /**
         * @PortabilityHint(target = "C#",name = "todo")
         * return null;
         */
        {
            BigDecimal b = null;
            b = resultSet.getBigDecimal(index);
            if (b == null) {
                return null;
            }
            return b.toBigInteger();
        }
    }

    @Override
    public void write(Object object, int i, ResultSet updatableResultSet) throws SQLException {
        /**@PortabilityHint(target = "C#",name = "todo")*/
        updatableResultSet.updateBigDecimal(i, new BigDecimal(((BigInteger)object)));
    }

    public String toSQLLiteral(Object object) {
        if(object==null){
            return super.toSQLLiteral(object);
        }
        return String.valueOf(object);
    }

    public void write(Object object, int i, PreparedStatement preparedStatement)
            throws SQLException {
        if (object == null) {
            /**@PortabilityHint(target = "C#",name = "todo")*/
            preparedStatement.setNull(i, Types.INTEGER);
        } else {
            /**@PortabilityHint(target = "C#",name = "todo")*/
            preparedStatement.setBigDecimal(i, new BigDecimal(((BigInteger) object)));
        }
    }

    public BigIntegerMarshaller(MarshallManager marshallManager) {
        super(marshallManager);
    }
}
