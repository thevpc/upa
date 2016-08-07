package net.vpc.upa.impl.persistence.shared.marshallers;

import java.io.CharArrayReader;
import java.sql.Clob;
import net.vpc.upa.impl.persistence.SimpleTypeMarshaller;

import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Types;
import net.vpc.upa.impl.util.IOUtils;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 12/20/12 2:48 AM
 */
public class CharArrayToClobMarshaller
        extends SimpleTypeMarshaller {

    public Object read(int index, ResultSet resultSet)
            throws SQLException {
        /**
         * @PortabilityHint(target = "C#",name = "todo")
         **/
        if(true) {
            Clob t = resultSet.getClob(index);
            if (t == null) {
                return null;
            }
            try {
                return IOUtils.toCharArray(t.getCharacterStream());
            } catch (Exception e) {
//                    Log.bug(e);
                return null;
            }
        }
        return null;
    }

    @Override
    public void write(Object object, int i, ResultSet updatableResultSet) throws SQLException {
        /**
         * @PortabilityHint(target = "C#",name = "suppress")
         */
        if (object == null) {
            updatableResultSet.updateClob(i, (Clob) null);
        } else {
            updatableResultSet.updateClob(i, new CharArrayReader((char[]) object));
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
        /**@PortabilityHint(target = "C#",name = "todo")*/
        if (object == null) {
            preparedStatement.setNull(i, Types.CLOB);
        } else {
            preparedStatement.setClob(i, new CharArrayReader((char[]) object));
        }
    }

    public CharArrayToClobMarshaller() {
    }
}
