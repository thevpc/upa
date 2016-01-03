package net.vpc.upa.impl.persistence.shared;

import java.io.ByteArrayInputStream;
import java.sql.Blob;
import net.vpc.upa.impl.persistence.SimpleTypeMarshaller;
import net.vpc.upa.impl.util.DateUtils;

import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Types;
import net.vpc.upa.impl.util.IOUtils;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 12/20/12 2:48 AM
 */
public class ByteRefArrayToBlobMarshaller
        extends SimpleTypeMarshaller {

    public Object read(int index, ResultSet resultSet)
            throws SQLException {
        Blob t = resultSet.getBlob(index);
        if (t == null) {
            return null;
        }
        try {
            return IOUtils.toByteRefArray(IOUtils.toByteArray(t.getBinaryStream()));
        } catch (Exception e) {
//                    Log.bug(e);
            return null;
        }
    }

    @Override
    public void write(Object object, int i, ResultSet updatableResultSet) throws SQLException {
        /**
         * @PortabilityHint(target = "C#",name = "suppress")
         */
        if (object == null) {
            updatableResultSet.updateBlob(i, (Blob)null);
        } else {
            updatableResultSet.updateBlob(i, new ByteArrayInputStream(IOUtils.toByteArray((Byte[])object)));
        }
    }

    @Override
    public String toSQLLiteral(Object object) {
        if(object==null){
            return super.toSQLLiteral(object);
        }
        throw new IllegalArgumentException("Unsupported");
    }

    public void write(Object object, int i, PreparedStatement preparedStatement)
            throws SQLException {
        if (object == null) {
            preparedStatement.setNull(i, Types.BLOB);
        } else {
            preparedStatement.setBlob(i, new ByteArrayInputStream((byte[])object));
        }
    }

    public ByteRefArrayToBlobMarshaller() {
    }
}
