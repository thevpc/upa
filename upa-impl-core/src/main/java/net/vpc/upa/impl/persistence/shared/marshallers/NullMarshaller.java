package net.vpc.upa.impl.persistence.shared.marshallers;

import net.vpc.upa.impl.persistence.MarshallManager;
import net.vpc.upa.impl.persistence.SimpleTypeMarshaller;

import net.vpc.upa.persistence.NativeResult;
import net.vpc.upa.persistence.NativeStatement;

/**
* @author Taha BEN SALAH <taha.bensalah@gmail.com>
* @creationdate 12/20/12 2:46 AM
*/
public class NullMarshaller
        extends SimpleTypeMarshaller {

    public Object read(int index, net.vpc.upa.persistence.NativeResult resultSet)
             {
        resultSet.getString(index);
        return null;
    }

    public void write(Object object, int i, NativeResult updatableResultSet) {
        /**@PortabilityHint(target = "C#",name = "suppress")*/
        updatableResultSet.updateString(i, null);
    }

    @Override
    public String toSQLLiteral(Object object) {
        return "NULL";
    }

    public void write(Object object, int i, NativeStatement preparedStatement)
            {
        throw new RuntimeException("setter not supported for NullMarshaller");
    }

    public NullMarshaller(MarshallManager marshallManager) {
        super(marshallManager);
    }
}
