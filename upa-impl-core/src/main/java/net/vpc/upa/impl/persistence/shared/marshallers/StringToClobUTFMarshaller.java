package net.vpc.upa.impl.persistence.shared.marshallers;

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
    public Object read(int index, net.vpc.upa.persistence.NativeResult resultSet){
            byte[] b = resultSet.getBytes(index);
            return b==null?null:new String(b);
    }

    @Override
    public void write(Object object, int i, NativeResult updatableResultSet)  {
        updatableResultSet.updateBytes(i, object==null?null:((String) object).getBytes());
    }

    @Override
    public String toSQLLiteral(Object object) {
        if(object==null){
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
    public void write(Object object, int i, NativeStatement preparedStatement){
        preparedStatement.setClob(i, ((String) object));
    }

    public StringToClobUTFMarshaller(MarshallManager marshallManager) {
        super(marshallManager);
    }
}
