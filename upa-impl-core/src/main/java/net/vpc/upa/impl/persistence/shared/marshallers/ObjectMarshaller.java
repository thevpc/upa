package net.vpc.upa.impl.persistence.shared.marshallers;

import net.vpc.upa.impl.persistence.MarshallManager;
import net.vpc.upa.impl.persistence.SimpleTypeMarshaller;
import net.vpc.upa.impl.persistence.TypeMarshaller;

import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import net.vpc.upa.persistence.NativeResult;
import net.vpc.upa.persistence.NativeStatement;

/**
* @author Taha BEN SALAH <taha.bensalah@gmail.com>
* @creationdate 12/20/12 2:49 AM
*/
public class ObjectMarshaller
        extends SimpleTypeMarshaller {

    public Object read(int index, net.vpc.upa.persistence.NativeResult resultSet)
            {
        /**
         * @PortabilityHint(target = "C#",name = "todo")
         **/
        if(true) {
            return resultSet.getObject(index);
        }
        return null;
    }

    public String toSQLLiteral(Object object) {
        TypeMarshaller wrapper = getMarshallManager().getTypeMarshaller(object.getClass());
        if (wrapper != null && wrapper.getClass() != getClass()) {
            return wrapper.toSQLLiteral(object);
        }
        throw new RuntimeException("literal not supported for Objects");
    }

    public void write(Object object, int i, NativeStatement preparedStatement)
            {
        /**@PortabilityHint(target = "C#",name = "todo")*/
        preparedStatement.setObject(i, object);
    }

    @Override
    public void write(Object object, int i, NativeResult updatableResultSet) {
        /**@PortabilityHint(target = "C#",name = "suppress")*/
        updatableResultSet.updateObject(i, object);
    }

    public boolean isLiteralSupported() {
        return true;
    }

    public ObjectMarshaller(MarshallManager marshallManager) {
        super(marshallManager);
    }
}
