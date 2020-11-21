package net.thevpc.upa.impl.persistence.shared.marshallers;

import net.thevpc.upa.impl.persistence.MarshallManager;
import net.thevpc.upa.impl.persistence.SimpleTypeMarshaller;

import net.thevpc.upa.impl.persistence.TypeMarshaller;
import net.thevpc.upa.persistence.NativeResult;
import net.thevpc.upa.types.DataTypeTransform;
import net.thevpc.upa.types.DataType;
import net.thevpc.upa.persistence.NativeStatement;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 12/20/12 2:46 AM
 */
public class DataTypeTransformMarshaller extends SimpleTypeMarshaller {

    private DataTypeTransform dataTypeTransform;
    private TypeMarshaller targetMarshaller;

    public DataTypeTransformMarshaller(MarshallManager marshallManager,DataTypeTransform dataTypeTransform, TypeMarshaller targetMarshaller) {
        super(marshallManager);
        this.dataTypeTransform = dataTypeTransform;
        this.targetMarshaller = targetMarshaller;
    }

    public Object read(int index, NativeResult resultSet)
            {
        return dataTypeTransform.reverseTransformValue(targetMarshaller.read(index, resultSet));
    }

    public void write(Object object, int i, NativeResult updatableResultSet)  {
        targetMarshaller.write(dataTypeTransform.transformValue(object), i, updatableResultSet);
    }

    @Override
    public String toSQLLiteral(Object object) {
        return targetMarshaller.toSQLLiteral(dataTypeTransform.transformValue(object));
    }

    public void write(Object object, int i, NativeStatement preparedStatement)
             {
        targetMarshaller.write(dataTypeTransform.transformValue(object), i, preparedStatement);
    }

    @Override
    public DataType getPersistentDataType(DataType datatype) {
        return dataTypeTransform.getTargetType();
    }

    @Override
    public String toString() {
        return "DataTypeTransformMarshaller{" +
                "dataTypeTransform=" + dataTypeTransform +
                ", targetMarshaller=" + targetMarshaller +
                '}';
    }
}
