package net.thevpc.upa.impl.persistence.shared.marshallers;

import net.thevpc.upa.impl.persistence.MarshallManager;
import net.thevpc.upa.impl.persistence.SimpleTypeMarshaller;

import net.thevpc.upa.persistence.NativeResult;
import net.thevpc.upa.persistence.NativeStatement;

/**
* @author Taha BEN SALAH <taha.bensalah@gmail.com>
* @creationdate 12/20/12 2:46 AM
*/
public class StringMarshaller extends SimpleTypeMarshaller {

    public Object read(int index, NativeResult resultSet)
             {
        /**
         * @PortabilityHint(target = "C#",name = "todo")
         **/
        if(true) {
            return resultSet.getString(index);
        }
        return null;
    }

    public void write(Object object, int i, NativeResult updatableResultSet) {
        /**@PortabilityHint(target = "C#",name = "suppress")*/
        updatableResultSet.updateString(i, (String) object);
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

    public void write(Object object, int i, NativeStatement preparedStatement)
             {
        /**@PortabilityHint(target = "C#",name = "todo")*/
        preparedStatement.setString(i, (String) object);
    }

    public StringMarshaller(MarshallManager marshallManager) {
        super(marshallManager);
    }
}
