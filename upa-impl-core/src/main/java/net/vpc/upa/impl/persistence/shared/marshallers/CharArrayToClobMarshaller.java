package net.vpc.upa.impl.persistence.shared.marshallers;

import java.io.CharArrayReader;

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
public class CharArrayToClobMarshaller
        extends SimpleTypeMarshaller {

    public Object read(int index, net.vpc.upa.persistence.NativeResult resultSet)
             {
        /**
         * @PortabilityHint(target = "C#",name = "todo")
         **/
        if(true) {
            net.vpc.upa.types.Clob t = resultSet.getClob(index);
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
    public void write(Object object, int i, NativeResult updatableResultSet)  {
        /**
         * @PortabilityHint(target = "C#",name = "suppress")
         */
        if (object == null) {
            updatableResultSet.updateClob(i, (net.vpc.upa.types.Clob) null);
        } else {
            updatableResultSet.updateClob(i, new CharArrayReader((char[]) object));
        }
    }

    @Override
    public String toSQLLiteral(Object object) {
        if(object==null){
            return super.toSQLLiteral(object);
        }
        throw new IllegalUPAArgumentException("Unsupported");
    }

    public void write(Object object, int i, NativeStatement preparedStatement)
             {
        /**@PortabilityHint(target = "C#",name = "todo")*/
        if (object == null) {
            preparedStatement.setNull(i, Types.CLOB);
        } else {
            preparedStatement.setClob(i, new CharArrayReader((char[]) object));
        }
    }

    public CharArrayToClobMarshaller(MarshallManager marshallManager) {
        super(marshallManager);
    }
}
