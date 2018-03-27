package net.vpc.upa.impl.persistence;

import net.vpc.upa.persistence.NativeResult;

import net.vpc.upa.types.DataType;
import net.vpc.upa.persistence.NativeStatement;

public interface TypeMarshaller {

    void setMarshallManager(MarshallManager marshallManager);

    Object read(int i, net.vpc.upa.persistence.NativeResult resultset);

    void write(Object object, int i, NativeResult updatableResultSet);

    void write(Object object, int i, NativeStatement preparedStatement);

    String toSQLLiteral(Object object);

    boolean isLiteralSupported();

    int getSize();

    String getName(String name, int i);

    DataType getPersistentDataType(DataType datatype);
}
