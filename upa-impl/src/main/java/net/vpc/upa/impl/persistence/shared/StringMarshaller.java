package net.vpc.upa.impl.persistence.shared;

import net.vpc.upa.impl.persistence.SimpleTypeMarshaller;

import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;

/**
* @author Taha BEN SALAH <taha.bensalah@gmail.com>
* @creationdate 12/20/12 2:46 AM
*/
public class StringMarshaller extends SimpleTypeMarshaller {

    public Object read(int index, ResultSet resultSet)
            throws SQLException {
        return resultSet.getString(index);
    }

    public void write(Object object, int i, ResultSet updatableResultSet) throws SQLException {
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

    public void write(Object object, int i, PreparedStatement preparedStatement)
            throws SQLException {
        preparedStatement.setString(i, (String) object);
    }

    public StringMarshaller() {
    }
}
