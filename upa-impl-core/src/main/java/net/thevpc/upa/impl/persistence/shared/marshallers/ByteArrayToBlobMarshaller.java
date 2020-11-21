package net.thevpc.upa.impl.persistence.shared.marshallers;

import java.io.ByteArrayInputStream;

import net.thevpc.upa.exceptions.IllegalUPAArgumentException;
import net.thevpc.upa.impl.persistence.MarshallManager;
import net.thevpc.upa.impl.persistence.SimpleTypeMarshaller;

import java.sql.Types;
import net.thevpc.upa.persistence.NativeResult;
import net.thevpc.upa.persistence.NativeStatement;
import net.thevpc.upa.types.Blob;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 12/20/12 2:48 AM
 */
public class ByteArrayToBlobMarshaller
        extends SimpleTypeMarshaller {

    public Object read(int index, NativeResult resultSet) {
        /**
         * @PortabilityHint(target = "C#",name = "todo")
         */
        if (true) {
            byte[] t = resultSet.getBytes(index);
            return t;
        }
        return null;
    }

    @Override
    public void write(Object object, int i, NativeResult updatableResultSet) {
        /**
         * @PortabilityHint(target = "C#",name = "suppress")
         */
        if (object == null) {
            updatableResultSet.updateBlob(i, (Blob) null);
        } else {
            updatableResultSet.updateBlob(i, new ByteArrayInputStream((byte[]) object));
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

    public ByteArrayToBlobMarshaller(MarshallManager marshallManager) {
        super(marshallManager);
    }
}
