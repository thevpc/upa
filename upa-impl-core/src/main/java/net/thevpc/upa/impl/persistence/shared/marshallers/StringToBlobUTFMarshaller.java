package net.thevpc.upa.impl.persistence.shared.marshallers;

import java.sql.Types;
import net.thevpc.upa.impl.persistence.MarshallManager;
import net.thevpc.upa.impl.persistence.SimpleTypeMarshaller;

import net.thevpc.upa.persistence.NativeResult;
import net.thevpc.upa.persistence.NativeStatement;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 12/20/12 2:46 AM
 */
public class StringToBlobUTFMarshaller extends SimpleTypeMarshaller {

    @Override
    public Object read(int index, NativeResult resultSet) {
        /**
         * @PortabilityHint(target = "C#",name = "todo")
         *
         */
        if (true) {
            byte[] b = resultSet.getBytes(index);
            return b == null ? null : new String(b);
        }
        return null;
    }

    @Override
    public void write(Object object, int i, NativeResult updatableResultSet) {
        if (object == null) {
            updatableResultSet.updateNull(i);
        } else {
            /**
             * @PortabilityHint(target = "C#",name = "suppress")
             */
            updatableResultSet.updateBytes(i, ((String) object).getBytes());
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

    public void write(Object object, int i, NativeStatement preparedStatement) {
        /**
         * @PortabilityHint(target = "C#",name = "todo")
         */
        if (object == null) {
            preparedStatement.setNull(i, Types.BLOB);
        } else {
            preparedStatement.setBytes(i, ((String) object).getBytes());
        }
    }

    public StringToBlobUTFMarshaller(MarshallManager marshallManager) {
        super(marshallManager);
    }
}
