package net.thevpc.upa.impl.persistence.shared.marshallers;

import java.io.ByteArrayInputStream;

import net.thevpc.upa.exceptions.IllegalUPAArgumentException;
import net.thevpc.upa.impl.persistence.MarshallManager;
import net.thevpc.upa.impl.persistence.SimpleTypeMarshaller;

import java.sql.Types;
import net.thevpc.upa.impl.util.IOUtils;
import net.thevpc.upa.persistence.NativeResult;
import net.thevpc.upa.persistence.NativeStatement;
import net.thevpc.upa.types.Blob;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 12/20/12 2:48 AM
 */
public class ByteRefArrayToBlobMarshaller
        extends SimpleTypeMarshaller {

    @Override
    public Object read(int index, NativeResult resultSet) {
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
            updatableResultSet.updateBlob(i, (Blob) null);
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
