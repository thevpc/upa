package net.vpc.upa.impl.persistence.shared.marshallers;

import net.vpc.upa.impl.persistence.MarshallManager;
import net.vpc.upa.impl.persistence.SimpleTypeMarshaller;

import java.math.BigDecimal;
import java.sql.Types;
import net.vpc.upa.persistence.NativeResult;
import net.vpc.upa.persistence.NativeStatement;

/**
* @author Taha BEN SALAH <taha.bensalah@gmail.com>
* @creationdate 12/20/12 2:47 AM
*/
public class BigDecimalMarshaller
        extends SimpleTypeMarshaller {

    @Override
    public Object read(int index, net.vpc.upa.persistence.NativeResult resultSet)
             {
        /**
         * @PortabilityHint(target = "C#",name = "todo")
         **/
        if(true) {
            return resultSet.getBigDecimal(index);
        }
        return null;
    }

    @Override
    public void write(Object object, int i, NativeResult updatableResultSet)  {
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

    public void write(Object object, int i, NativeStatement preparedStatement)
             {
        /**@PortabilityHint(target = "C#",name = "todo")*/
        if (object == null) {
            preparedStatement.setNull(i, Types.DECIMAL);
        } else {
            preparedStatement.setBigDecimal(i, ((BigDecimal) object));
        }
    }

    public BigDecimalMarshaller(MarshallManager marshallManager) {
        super(marshallManager);
    }
}
