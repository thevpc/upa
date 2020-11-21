package net.thevpc.upa.impl.persistence;

import net.thevpc.upa.persistence.NativeResult;

import net.thevpc.upa.types.DataType;
import net.thevpc.upa.persistence.NativeStatement;

public interface TypeMarshaller {

    void setMarshallManager(MarshallManager marshallManager);

    Object read(int i, NativeResult resultset);

    void write(Object object, int i, NativeResult updatableResultSet);

    void write(Object object, int i, NativeStatement preparedStatement);

    String toSQLLiteral(Object object);

    boolean isLiteralSupported();

    int getSize();

    String getName(String name, int i);

    DataType getPersistentDataType(DataType datatype);
}
