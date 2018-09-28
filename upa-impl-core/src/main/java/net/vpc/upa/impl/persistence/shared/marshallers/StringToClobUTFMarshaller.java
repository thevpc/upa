package net.vpc.upa.impl.persistence.shared.marshallers;

import java.io.StringReader;
import java.sql.Types;
import net.vpc.upa.impl.persistence.MarshallManager;
import net.vpc.upa.impl.persistence.SimpleTypeMarshaller;

import net.vpc.upa.persistence.NativeResult;
import net.vpc.upa.persistence.NativeStatement;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 12/20/12 2:46 AM
 */
public class StringToClobUTFMarshaller extends SimpleTypeMarshaller {

    @Override
    public Object read(int index, net.vpc.upa.persistence.NativeResult resultSet) {
        return resultSet.getString(index);
//            return b==null?null:new String(b);
    }

    @Override
    public void write(Object object, int i, NativeResult updatableResultSet) {
        if (object == null) {
            updatableResultSet.updateNull(i);
        } else {
            updatableResultSet.updateClob(i, new StringReader(((String) object)));
        }
    }

    @Override
    public String toSQLLiteral(Object object) {
        if (object == null) {
            return super.toSQLLiteral(object);
        }
        StringBuilder s = new StringBuilder();
        s.append('\'');
        for (char c : object.toString().toCharArray()) {
            switch (c) {
                case '\'': {
                    s.append("''");
                    break;
                }
                default: {
                    s.append(c);
                    break;
                }
            }
        }
        s.append('\'');
        return s.toString();
    }

    @Override
    public void write(Object object, int i, NativeStatement preparedStatement) {
        if (object == null) {
            preparedStatement.setNull(i, Types.CLOB);
        } else {
            preparedStatement.setClob(i, ((String) object));
        }
    }

    public StringToClobUTFMarshaller(MarshallManager marshallManager) {
        super(marshallManager);
    }
}
