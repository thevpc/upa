package net.thevpc.upa.impl.persistence.shared.marshallers;

import net.thevpc.upa.impl.persistence.MarshallManager;
import net.thevpc.upa.impl.persistence.SimpleTypeMarshaller;

import java.math.BigDecimal;
import java.math.BigInteger;
import java.sql.Types;
import net.thevpc.upa.persistence.NativeResult;
import net.thevpc.upa.persistence.NativeStatement;

/**
* @author Taha BEN SALAH <taha.bensalah@gmail.com>
* @creationdate 12/20/12 2:47 AM
*/
public class BigIntegerMarshaller
        extends SimpleTypeMarshaller {

    public Object read(int index, NativeResult resultSet)
             {
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
    public void write(Object object, int i, NativeResult updatableResultSet) {
        /**@PortabilityHint(target = "C#",name = "todo")*/
        updatableResultSet.updateBigDecimal(i, new BigDecimal(((BigInteger)object)));
    }

    public String toSQLLiteral(Object object) {
        if(object==null){
            return super.toSQLLiteral(object);
        }
        return String.valueOf(object);
    }

    public void write(Object object, int i, NativeStatement preparedStatement)
            {
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
