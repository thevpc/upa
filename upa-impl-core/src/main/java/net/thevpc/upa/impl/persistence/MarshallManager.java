package net.thevpc.upa.impl.persistence;

import net.thevpc.upa.types.DataType;
import net.thevpc.upa.types.DataTypeTransform;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 11/5/12 12:40 AM
 */
public interface MarshallManager {
    TypeMarshaller getNullMarshaller();

    void setNullMarshaller(TypeMarshaller wrapper);

    void setTypeMarshaller(Class platformType, TypeMarshaller wrapper);

    void setTypeMarshallerFactory(Class dataType, TypeMarshallerFactory wrapperFactory);

    TypeMarshaller getTypeMarshaller(DataTypeTransform someClass);

    TypeMarshaller getTypeMarshaller(String someClass);

    TypeMarshaller getTypeMarshaller(Class someClass);

    TypeMarshaller getTypeMarshaller(DataType p);

    TypeMarshallerFactory getTypeMarshallerFactory(Class someClass);

    String formatSqlValue(Object value);
}
