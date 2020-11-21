package net.thevpc.upa.impl.persistence.shared.marshallers;

import net.thevpc.upa.impl.persistence.MarshallManager;
import net.thevpc.upa.impl.persistence.SimpleTypeMarshaller;

import net.thevpc.upa.persistence.NativeResult;
import net.thevpc.upa.persistence.NativeStatement;

/**
* @author Taha BEN SALAH <taha.bensalah@gmail.com>
* @creationdate 12/20/12 2:46 AM
*/
public class NullMarshaller
        extends SimpleTypeMarshaller {

    public Object read(int index, NativeResult resultSet)
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
