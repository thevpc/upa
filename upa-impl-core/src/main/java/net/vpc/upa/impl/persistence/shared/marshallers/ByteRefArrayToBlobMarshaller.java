package net.vpc.upa.impl.persistence.shared.marshallers;

import java.io.ByteArrayInputStream;

import net.vpc.upa.exceptions.IllegalUPAArgumentException;
import net.vpc.upa.impl.persistence.MarshallManager;
import net.vpc.upa.impl.persistence.SimpleTypeMarshaller;

import java.sql.Types;
import net.vpc.upa.impl.util.IOUtils;
import net.vpc.upa.persistence.NativeResult;
import net.vpc.upa.persistence.NativeStatement;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 12/20/12 2:48 AM
 */
public class ByteRefArrayToBlobMarshaller
        extends SimpleTypeMarshaller {

    @Override
    public Object read(int index, net.vpc.upa.persistence.NativeResult resultSet) {
        /**
         * @PortabilityHint(target = "C#",name = "todo")
         *
         */
        if (true) {
            byte[] t = resultSet.getBytes(index);
            if (t == null) {
                return null;
            }
            return IOUtils.toByteRefArray(t);
        }
        return null;

    }

    @Override
    public void write(Object object, int i, NativeResult updatableResultSet) {
        /**
         * @PortabilityHint(target = "C#",name = "todo")
         */
        if (object == null) {
            updatableResultSet.updateBlob(i, (net.vpc.upa.types.Blob) null);
        } else {
            updatableResultSet.updateBlob(i, new ByteArrayInputStream(IOUtils.toByteArray((Byte[]) object)));
        }
    }

    @Override
    public String toSQLLiteral(Object object) {
        if (object == null) {
            return super.toSQLLiteral(object);
        }
        throw new IllegalUPAArgumentException("Unsupported");
    }

    public void write(Object object, int i, NativeStatement preparedStatement) {
        /**
         * @PortabilityHint(target = "C#",name = "todo")
         */
        if (object == null) {
            preparedStatement.setNull(i, Types.BLOB);
        } else {
            preparedStatement.setBlob(i, new ByteArrayInputStream((byte[]) object));
        }
    }

    public ByteRefArrayToBlobMarshaller(MarshallManager marshallManager) {
        super(marshallManager);
    }
}
