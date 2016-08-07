package net.vpc.upa.impl.persistence;

import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;

import net.vpc.upa.types.DataType;

public interface TypeMarshaller {

    void setMarshallManager(MarshallManager marshallManager);

    Object read(int i, ResultSet resultset) throws SQLException;

    void write(Object object, int i, ResultSet updatableResultSet) throws SQLException;

    void write(Object object, int i, PreparedStatement preparedStatement) throws SQLException;

    String toSQLLiteral(Object object);

    boolean isLiteralSupported();
    
    int getSize();

    String getName(String name, int i);
    
    DataType getPersistentDataType(DataType datatype);
}
