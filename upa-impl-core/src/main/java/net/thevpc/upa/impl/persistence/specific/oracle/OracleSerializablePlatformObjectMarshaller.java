package net.thevpc.upa.impl.persistence.specific.oracle;

import net.thevpc.upa.PortabilityHint;
import net.thevpc.upa.exceptions.UPAException;
import net.thevpc.upa.impl.persistence.MarshallManager;
import net.thevpc.upa.impl.persistence.SimpleTypeMarshaller;
import net.thevpc.upa.impl.util.IOUtils;
import net.thevpc.upa.persistence.NativeResult;
import net.thevpc.upa.persistence.NativeStatement;
import net.thevpc.upa.types.Blob;

//import java.sql.Blob;


/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 1/8/13 1:52 AM
 */
@PortabilityHint(target = "C#", name = "suppress")
public class OracleSerializablePlatformObjectMarshaller
        extends SimpleTypeMarshaller {

    public OracleSerializablePlatformObjectMarshaller(MarshallManager marshallManager) {
        super(marshallManager);
    }

    public Object read(int index, NativeResult resultSet) {
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
                throw new UPAException(e);
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

    @Override
    public String toSQLLiteral(Object object) {
        if (object == null) {
            return super.toSQLLiteral(object);
        }
        throw new RuntimeException("litteral not supported for Objects (" + object + " as " + object.getClass() + ")");
    }

    @Override
    public void write(Object object, int i, NativeStatement preparedStatement) {
        if (object == null) {
            preparedStatement.setObject(i, null);
        } else {
            preparedStatement.setObject(i, IOUtils.getSerializedFormOf(object));
        }
    }

    @Override
    public void write(Object object, int i, NativeResult updatableResultSet) {
        /**
         * @PortabilityHint(target = "C#",name = "suppress")
         */
        if (object == null) {
            updatableResultSet.updateNull(i);
        } else {
            updatableResultSet.updateObject(i, IOUtils.getSerializedFormOf(object));
        }
    }

    @Override
    public boolean isLiteralSupported() {
        return false;
    }

    @Override
    public void setMarshallManager(MarshallManager marshallManager) {

    }

}
