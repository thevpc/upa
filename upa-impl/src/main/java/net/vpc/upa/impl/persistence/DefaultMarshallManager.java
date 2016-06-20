package net.vpc.upa.impl.persistence;

import net.vpc.upa.impl.persistence.shared.*;
import net.vpc.upa.types.*;

import java.math.BigDecimal;
import java.math.BigInteger;
import java.util.HashMap;
import java.util.Map;
import net.vpc.upa.impl.transform.IdentityDataTypeTransform;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 11/3/12 11:35 PM
 */
public class DefaultMarshallManager implements MarshallManager {

    private final Map<Class, TypeMarshaller> typeToMarshallerMap = new HashMap<Class, TypeMarshaller>();
    private TypeMarshaller nullMarshaller;
    //    private ConnectionManager connectionManager;
    //    public static final DataWrapper JAVA_OBJECT = new JavaObjectWrapper();
    private final Map<Class, TypeMarshallerFactory> typeToMarshallerFactory = new HashMap<Class, TypeMarshallerFactory>();

    public DefaultMarshallManager() {
        this.nullMarshaller = (TypeMarshallerUtils.NULL);
        setTypeMarshaller0(Object.class, new SerializablePlatformObjectMarshaller());
        setTypeMarshaller0(Float.class, TypeMarshallerUtils.FLOAT);
        setTypeMarshaller0(String.class, TypeMarshallerUtils.STRING);
        setTypeMarshaller0(Character.class, TypeMarshallerUtils.STRING);
        setTypeMarshaller0(Double.class, TypeMarshallerUtils.DOUBLE);
        setTypeMarshaller0(Integer.class, TypeMarshallerUtils.INTEGER);
        setTypeMarshaller0(Long.class, TypeMarshallerUtils.LONG);
        setTypeMarshaller0(Short.class, TypeMarshallerUtils.SHORT);
        setTypeMarshaller0(Byte.class, TypeMarshallerUtils.BYTE);
        setTypeMarshaller0(BigInteger.class, TypeMarshallerUtils.BIG_INTEGER);
        setTypeMarshaller0(BigDecimal.class, TypeMarshallerUtils.BIG_DECIMAL);
        setTypeMarshaller0(Boolean.class, TypeMarshallerUtils.BOOLEAN_FROM_NUMBER);
        setTypeMarshaller0(FileData.class, new SerializablePlatformObjectMarshaller());

        setTypeMarshaller0(Float.TYPE, TypeMarshallerUtils.FLOAT);
        setTypeMarshaller0(Character.TYPE, TypeMarshallerUtils.STRING);
        setTypeMarshaller0(Double.TYPE, TypeMarshallerUtils.DOUBLE);
        setTypeMarshaller0(Integer.TYPE, TypeMarshallerUtils.INTEGER);
        setTypeMarshaller0(Long.TYPE, TypeMarshallerUtils.LONG);
        setTypeMarshaller0(Short.TYPE, TypeMarshallerUtils.SHORT);
        setTypeMarshaller0(Byte.TYPE, TypeMarshallerUtils.BYTE);
        setTypeMarshaller0(Boolean.TYPE, TypeMarshallerUtils.BOOLEAN_FROM_NUMBER);

        setTypeMarshaller0(java.util.Date.class, TypeMarshallerUtils.UTIL_DATE);
        setTypeMarshaller0(java.sql.Date.class, TypeMarshallerUtils.SQL_DATE);
        setTypeMarshaller0(java.sql.Time.class, TypeMarshallerUtils.SQL_TIME);
        setTypeMarshaller0(java.sql.Timestamp.class, TypeMarshallerUtils.SQL_TIMESTAMP);

        setTypeMarshaller0(Date.class, TypeMarshallerUtils.DATE);
        setTypeMarshaller0(Month.class, TypeMarshallerUtils.MONTH_YEAR);
        setTypeMarshaller0(Year.class, TypeMarshallerUtils.YEAR);
        setTypeMarshaller0(Time.class, TypeMarshallerUtils.VPC_TIME);
        setTypeMarshaller0(DateTime.class, TypeMarshallerUtils.DATE_TIME);
        setTypeMarshaller0(Timestamp.class, TypeMarshallerUtils.TIMESTAMP);

        setTypeMarshaller0(byte[].class, TypeMarshallerUtils.BYTES);
        setTypeMarshaller0(Byte[].class, TypeMarshallerUtils.BYTE_REFS);

        setTypeMarshaller0(char[].class, TypeMarshallerUtils.CHARS);
        setTypeMarshaller0(Character[].class, TypeMarshallerUtils.CHAR_REFS);

        setTypeMarshallerFactory0(ImageType.class, new ConstantDataMarshallerFactory(new SerializablePlatformObjectMarshaller()));
        setTypeMarshallerFactory0(TemporalType.class, new TemporalDataMarshallerFactory());
        setTypeMarshallerFactory0(FileType.class, new ConstantDataMarshallerFactory(new SerializablePlatformObjectMarshaller()));
        setTypeMarshallerFactory0(NumberType.class, new NumberDataMarshallerFactory());
        setTypeMarshallerFactory0(StringType.class, TypeMarshallerUtils.F_STRING);
        setTypeMarshallerFactory0(BooleanType.class, TypeMarshallerUtils.F_BOOLEAN_FROM_NUMBER);
        setTypeMarshallerFactory0(ListType.class, new ListDataMarshallerFactory());
        setTypeMarshallerFactory0(DataType.class, TypeMarshallerUtils.F_OBJECT);
        setTypeMarshallerFactory0(SerializableType.class, TypeMarshallerUtils.F_OBJECT);
        setTypeMarshallerFactory0(EnumType.class, new EnumMarshallerFactory());
    }

    @Override
    public void setNullMarshaller(TypeMarshaller wrapper) {
        nullMarshaller = wrapper;
    }

    @Override
    public TypeMarshaller getNullMarshaller() {
        return nullMarshaller;
    }

    @Override
    public void setTypeMarshaller(Class platformType, TypeMarshaller wrapper) {
        setTypeMarshaller0(platformType, wrapper);
    }

    private void setTypeMarshaller0(Class platformType, TypeMarshaller wrapper) {
        wrapper.setMarshallManager(this);
        typeToMarshallerMap.put(platformType, wrapper);
    }

    @Override
    public void setTypeMarshallerFactory(Class platformType, TypeMarshallerFactory wrapperFactory) {
        setTypeMarshallerFactory0(platformType, wrapperFactory);
    }

    private void setTypeMarshallerFactory0(Class platformType, TypeMarshallerFactory wrapperFactory) {
        wrapperFactory.setMarshallManager(this);
        typeToMarshallerFactory.put(platformType, wrapperFactory);
    }

    @Override
    public TypeMarshaller getTypeMarshaller(Class platformType) {
        TypeMarshaller c = (TypeMarshaller) typeToMarshallerMap.get(platformType);
        if (c != null) {
            return c;
        }
        if (platformType.isEnum()) {
            return new EnumAsIntMarshaller(platformType);
        }
        Class[] interfaces = platformType.getInterfaces();
        for (Class anInterface : interfaces) {
            c = getTypeMarshaller(anInterface);
            if (c != null) {
                return c;
            }
        }
        Class superClass = platformType.getSuperclass();
        if (superClass == null) {
            return null;
        }
        c = getTypeMarshaller(superClass);
        if (c != null) {
            return c;
        }
        return getTypeMarshaller(superClass);
    }

    public TypeMarshaller getTypeMarshaller(DataTypeTransform p) {
        if (p instanceof IdentityDataTypeTransform) {
            return getTypeMarshaller(((IdentityDataTypeTransform) p).getSourceType());
        }
        return new DataTypeTransformMarshaller(p, getTypeMarshaller(p.getTargetType()));
    }

    @Override
    public TypeMarshaller getTypeMarshaller(DataType p) {
        return getTypeMarshallerFactory(p.getClass()).createTypeMarshaller(p);
    }

    @Override
    public TypeMarshallerFactory getTypeMarshallerFactory(Class someClass) {
        TypeMarshallerFactory f = getTypeMarshallerFactory0(someClass);
        return f == null ? getTypeMarshallerFactory(Object.class) : f;
    }

    private TypeMarshallerFactory getTypeMarshallerFactory0(Class someClass) {
        TypeMarshallerFactory c = (TypeMarshallerFactory) typeToMarshallerFactory.get(someClass);
        if (c != null) {
            return c;
        }
        Class[] interfaces = someClass.getInterfaces();
        for (Class anInterface : interfaces) {
            c = getTypeMarshallerFactory0(anInterface);
            if (c != null) {
                return c;
            }
        }
        Class superClass = someClass.getSuperclass();
        if (superClass == null) {
            return null;
        }
        c = getTypeMarshallerFactory0(superClass);
        if (c != null) {
            return c;
        }
        return getTypeMarshallerFactory0(superClass);
    }

    public String formatSqlValue(Object value, DataType datatype) {
        if (value == null) {
            return nullMarshaller.toSQLLiteral(null);
        } else {
            return getTypeMarshaller(value.getClass()).toSQLLiteral(value);
        }
    }

    @Override
    public String formatSqlValue(Object value) {
        return formatSqlValue(value, null);
    }

}
