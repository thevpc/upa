package net.vpc.upa.impl.persistence;

import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import net.vpc.upa.types.DataType;

public interface TypeMarshaller {

    public void setMarshallManager(MarshallManager marshallManager);

    public Object read(int i, ResultSet resultset) throws SQLException;

    public void write(Object object, int i, ResultSet updatableResultSet) throws SQLException;

    public void write(Object object, int i, PreparedStatement preparedStatement) throws SQLException;

    public String toSQLLiteral(Object object);

    public boolean isLiteralSupported();
    
    public int getSize();

    public String getName(String name, int i);
    
    public DataType getPersistentDataType(DataType datatype);
}
