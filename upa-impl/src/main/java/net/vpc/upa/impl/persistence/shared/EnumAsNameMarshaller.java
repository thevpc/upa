package net.vpc.upa.impl.persistence.shared;

import net.vpc.upa.impl.persistence.SimpleTypeMarshaller;

import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Types;

import net.vpc.upa.impl.util.PlatformUtils;
import net.vpc.upa.types.DataType;
import net.vpc.upa.types.StringType;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 12/20/12 2:47 AM
 */
public class EnumAsNameMarshaller
        extends SimpleTypeMarshaller {

    private Class<? extends Enum> type;
    private Object[] values;
    private StringType persistentDataType;
    public EnumAsNameMarshaller() {
    }

    public EnumAsNameMarshaller(Class<? extends Enum> type) {
        this.type = type;
        try {
            values = PlatformUtils.getEnumValues(type);
            int max=1;
            for (Object object : values) {
                final int x = String.valueOf(object).length();
                if(x>max){
                    max=x;
                }
            }
            persistentDataType=new StringType(type.getName(),0,max,true);
        } catch (Exception e) {
            throw new RuntimeException(e);
        }
    }

    public Object read(int index, ResultSet resultSet)
            throws SQLException {
        String n = resultSet.getString(index);
        if (n == null) {
            return null;
        }
        try {
            return Enum.valueOf(type, n);
        } catch (IllegalArgumentException e) {
            return null;
        }
    }

    @Override
    public void write(Object object, int i, ResultSet updatableResultSet) throws SQLException {
        /**
         * @PortabilityHint(target = "C#",name = "suppress")
         */
        if (object == null) {
            updatableResultSet.updateNull(i);
        } else {
            updatableResultSet.updateString(i, ((Enum) object).name());
        }
    }

    @Override
    public String toSQLLiteral(Object object) {
        if (object == null) {
            return super.toSQLLiteral(object);
        }
        return String.valueOf(((Enum) object).name());
    }

    public void write(Object object, int i, PreparedStatement preparedStatement)
            throws SQLException {
        if (object == null) {
            preparedStatement.setNull(i, Types.VARCHAR);
        } else {
            preparedStatement.setString(i, ((Enum) object).name());
        }
    }

    @Override
    public DataType getPersistentDataType(DataType datatype) {
        return persistentDataType;
    }

    
}
