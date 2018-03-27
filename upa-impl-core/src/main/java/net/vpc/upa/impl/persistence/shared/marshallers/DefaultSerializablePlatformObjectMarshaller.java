package net.vpc.upa.impl.persistence.shared.marshallers;

import net.vpc.upa.impl.persistence.MarshallManager;
import net.vpc.upa.PortabilityHint;
import net.vpc.upa.impl.persistence.SimpleTypeMarshaller;
import net.vpc.upa.impl.util.IOUtils;

import net.vpc.upa.persistence.NativeResult;
import net.vpc.upa.persistence.NativeStatement;
import net.vpc.upa.types.Blob;

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
    public Object read(int index, net.vpc.upa.persistence.NativeResult resultSet) {
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
            updatableResultSet.updateBlob(i, (net.vpc.upa.types.Blob) null);
        } else {
            updatableResultSet.updateObject(i, IOUtils.getSerializedFormOf(object));
        }
    }

    @Override
    public boolean isLiteralSupported() {
        return false;
    }
}
