package net.thevpc.upa.impl.persistence.shared.marshallers;

import net.thevpc.upa.impl.persistence.MarshallManager;
import net.thevpc.upa.PortabilityHint;
import net.thevpc.upa.impl.persistence.SimpleTypeMarshaller;
import net.thevpc.upa.impl.util.IOUtils;

import net.thevpc.upa.persistence.NativeResult;
import net.thevpc.upa.persistence.NativeStatement;
import net.thevpc.upa.types.Blob;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 11/22/12 10:03 PM
 */
@PortabilityHint(target = "C#", name = "suppress")
public class DefaultSerializablePlatformObjectMarshaller
        extends SimpleTypeMarshaller {

    public DefaultSerializablePlatformObjectMarshaller(MarshallManager marshallManager) {
        super(marshallManager);
    }

    @Override
    public Object read(int index, NativeResult resultSet) {
        /**
         * @PortabilityHint(target = "C#",name = "todo")
         *
         */
        if (true) {
            Object val = resultSet.getObject(index);
            if (val == null) {
                return null;
            }
            if (val instanceof Blob) {
                Blob blob = (Blob) val;
                try {
                    return IOUtils.getObjectFromSerializedForm(blob.getBinaryStream());
                } catch (ClassNotFoundException e) {
//                    Log.bug(e);
                    return null;
                } catch (Exception e) {
//                    Log.bug(e);
                    return null;
                }
            } else if (val instanceof byte[]) {
                try {
                    return IOUtils.getObjectFromSerializedForm((byte[]) val);
                } catch (ClassNotFoundException e) {
//                    Log.bug(e);
                    return null;
                }
            } else {
                return val;
            }
        }
        return null;

    }

    @Override
    public String toSQLLiteral(Object object) {
        if (object == null) {
            return super.toSQLLiteral(object);
        }
        throw new RuntimeException("litteral not supported for Objects (" + object + " as " + object.getClass() + ")");
    }

    public void write(Object object, int i, NativeStatement preparedStatement) {
        /**
         * @PortabilityHint(target = "C#",name = "todo")
         */
        if (object == null) {
            preparedStatement.setBlob(i, (Blob) null);
        } else {
            preparedStatement.setObject(i, IOUtils.getSerializedFormOf(object));
        }
    }

    public void write(Object object, int i, NativeResult updatableResultSet) {
        /**
         * @PortabilityHint(target = "C#",name = "suppress")
         */
        if (object == null) {
            updatableResultSet.updateBlob(i, (Blob) null);
        } else {
            updatableResultSet.updateObject(i, IOUtils.getSerializedFormOf(object));
        }
    }

    @Override
    public boolean isLiteralSupported() {
        return false;
    }
}
