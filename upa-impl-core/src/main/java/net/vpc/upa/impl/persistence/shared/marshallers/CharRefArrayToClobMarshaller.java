package net.vpc.upa.impl.persistence.shared.marshallers;

import java.io.CharArrayReader;
import java.sql.Types;

import net.vpc.upa.exceptions.IllegalUPAArgumentException;
import net.vpc.upa.impl.persistence.MarshallManager;
import net.vpc.upa.impl.persistence.SimpleTypeMarshaller;

//import java.sql.Types;
import net.vpc.upa.impl.util.IOUtils;
import net.vpc.upa.persistence.NativeResult;
import net.vpc.upa.persistence.NativeStatement;
import net.vpc.upa.types.Clob;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 12/20/12 2:48 AM
 */
public class CharRefArrayToClobMarshaller
        extends SimpleTypeMarshaller {

    public Object read(int index, net.vpc.upa.persistence.NativeResult resultSet)
             {
        /**
         * @PortabilityHint(target = "C#",name = "todo")
         **/
        if(true) {
            Clob t = resultSet.getClob(index);
            if (t == null) {
                return null;
            }
            try {
                return IOUtils.toCharRefArray(IOUtils.toCharArray(t.getCharacterStream()));
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
            updatableResultSet.updateClob(i, (Clob) null);
        } else {
            updatableResultSet.updateClob(i, new CharArrayReader(IOUtils.toCharArray((Character[]) object)));
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
            preparedStatement.setClob(i, new CharArrayReader(IOUtils.toCharArray((Character[]) object)));
        }
    }

    public CharRefArrayToClobMarshaller(MarshallManager marshallManager) {
        super(marshallManager);
    }
}
