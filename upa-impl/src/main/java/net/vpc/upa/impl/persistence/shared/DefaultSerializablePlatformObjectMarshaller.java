package net.vpc.upa.impl.persistence.shared;

import net.vpc.upa.impl.persistence.specific.derby.*;
import net.vpc.upa.PortabilityHint;
import net.vpc.upa.impl.persistence.SimpleTypeMarshaller;
import net.vpc.upa.impl.util.IOUtils;

import java.sql.Blob;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;

/**
* @author Taha BEN SALAH <taha.bensalah@gmail.com>
* @creationdate 11/22/12 10:03 PM
*/
@PortabilityHint(target = "C#", name = "suppress")
public class DefaultSerializablePlatformObjectMarshaller
        extends SimpleTypeMarshaller {

    public DefaultSerializablePlatformObjectMarshaller() {
    }

    public Object read(int index, ResultSet resultSet)
            throws SQLException {
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
        if(object==null){
            return super.toSQLLiteral(object);
        }
        throw new RuntimeException("litteral not supported for Objects (" + object + " as " + object.getClass() + ")");
    }

    public void write(Object object, int i, PreparedStatement preparedStatement)
            throws SQLException {
        if (object == null) {
            preparedStatement.setBlob(i, (Blob) null);
        } else {
            preparedStatement.setObject(i, IOUtils.getSerializedFormOf(object));
        }
    }

    public void write(Object object, int i, ResultSet updatableResultSet) throws SQLException {
        /**@PortabilityHint(target = "C#",name = "suppress")*/
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
