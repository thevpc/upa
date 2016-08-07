package net.vpc.upa.impl.persistence.shared.marshallers;

import net.vpc.upa.impl.persistence.SimpleTypeMarshaller;

import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import net.vpc.upa.impl.persistence.TypeMarshaller;
import net.vpc.upa.types.DataTypeTransform;
import net.vpc.upa.types.DataType;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 12/20/12 2:46 AM
 */
public class DataTypeTransformMarshaller extends SimpleTypeMarshaller {

    private DataTypeTransform dataTypeTransform;
    private TypeMarshaller targetMarshaller;

    public DataTypeTransformMarshaller(DataTypeTransform dataTypeTransform, TypeMarshaller targetMarshaller) {
        this.dataTypeTransform = dataTypeTransform;
        this.targetMarshaller = targetMarshaller;
    }

    public Object read(int index, ResultSet resultSet)
            throws SQLException {
        return dataTypeTransform.reverseTransformValue(targetMarshaller.read(index, resultSet));
    }

    public void write(Object object, int i, ResultSet updatableResultSet) throws SQLException {
        targetMarshaller.write(dataTypeTransform.transformValue(object), i, updatableResultSet);
    }

    @Override
    public String toSQLLiteral(Object object) {
        return targetMarshaller.toSQLLiteral(dataTypeTransform.transformValue(object));
    }

    public void write(Object object, int i, PreparedStatement preparedStatement)
            throws SQLException {
        targetMarshaller.write(dataTypeTransform.transformValue(object), i, preparedStatement);
    }

    @Override
    public DataType getPersistentDataType(DataType datatype) {
        return dataTypeTransform.getTargetType();
    }

}
