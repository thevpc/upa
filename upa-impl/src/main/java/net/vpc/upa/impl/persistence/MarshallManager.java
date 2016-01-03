package net.vpc.upa.impl.persistence;

import net.vpc.upa.types.DataType;
import net.vpc.upa.types.DataTypeTransform;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 11/5/12 12:40 AM
 */
public interface MarshallManager {

    void setNullMarshaller(TypeMarshaller wrapper);

    TypeMarshaller getNullMarshaller();

    void setTypeMarshaller(Class platformType, TypeMarshaller wrapper);

    void setTypeMarshallerFactory(Class platformType, TypeMarshallerFactory wrapperFactory);

    TypeMarshaller getTypeMarshaller(DataTypeTransform someClass);

    TypeMarshaller getTypeMarshaller(Class someClass);

    TypeMarshaller getTypeMarshaller(DataType p);

    TypeMarshallerFactory getTypeMarshallerFactory(Class someClass);

    String formatSqlValue(Object value);
}
