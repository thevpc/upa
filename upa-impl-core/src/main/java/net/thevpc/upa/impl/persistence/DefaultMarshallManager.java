package net.thevpc.upa.impl.persistence;

import net.thevpc.upa.exceptions.NoSuchUPAElementException;
import net.thevpc.upa.impl.persistence.shared.marshallers.*;
import net.thevpc.upa.types.*;
import net.thevpc.upa.impl.persistence.shared.marshallers.*;
import net.thevpc.upa.impl.cache.LRUMap;
import net.thevpc.upa.types.*;

import java.math.BigDecimal;
import java.math.BigInteger;
import java.util.HashMap;
import java.util.Map;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 11/3/12 11:35 PM
 */
public class DefaultMarshallManager implements MarshallManager {

    private final Map<Class, TypeMarshaller> typeToMarshallerMap = new HashMap<Class, TypeMarshaller>();
    private final Map<String, TypeMarshaller> idToMarshallerMap = new HashMap<String, TypeMarshaller>();

    private TypeMarshaller nullMarshaller;
    //    private ConnectionManager connectionManager;
    //    public static final DataWrapper JAVA_OBJECT = new JavaObjectWrapper();
    private final Map<Class, TypeMarshallerFactory> typeToMarshallerFactory = new HashMap<Class, TypeMarshallerFactory>();
    private final Map<DataTypeTransform, TypeMarshaller> dataTypeTransformToMarshaller = new LRUMap<DataTypeTransform, TypeMarshaller>(200);

    public DefaultMarshallManager() {
        this.nullMarshaller = new NullMarshaller(this);
        setTypeMarshaller0(TypeMarshallerNames.STRING_TO_BLOB, new StringToBlobUTFMarshaller(this));
        setTypeMarshaller0(TypeMarshallerNames.STRING_TO_CLOB, new StringToClobUTFMarshaller(this));
        setTypeMarshaller0(TypeMarshallerNames.BOOLEAN_TO_INTEGER, new BooleanToNumberMarshaller(this));
        setTypeMarshaller0(TypeMarshallerNames.SERIALIZABLE, new SerializablePlatformObjectMarshaller(this));

        setTypeMarshaller0(TypeMarshallerNames.STRING, String.class, new StringMarshaller(this));
        setTypeMarshaller0(TypeMarshallerNames.OBJECT, new Class[]{Object.class, FileData.class}, TypeMarshallerNames.SERIALIZABLE);
        setTypeMarshaller0(TypeMarshallerNames.FLOAT, new Class[]{Float.class, Float.TYPE}, new FloatMarshaller(this));
        setTypeMarshaller0(TypeMarshallerNames.CHARACTER, new Class[]{Character.class, Character.TYPE}, TypeMarshallerNames.STRING);
        setTypeMarshaller0(TypeMarshallerNames.DOUBLE, new Class[]{Double.class, Double.TYPE}, new DoubleMarshaller(this));
        setTypeMarshaller0(TypeMarshallerNames.INTEGER, new Class[]{Integer.class, Integer.TYPE}, new IntegerMarshaller(this));
        setTypeMarshaller0(TypeMarshallerNames.LONG, new Class[]{Long.class, Long.TYPE}, new LongMarshaller(this));
        setTypeMarshaller0(TypeMarshallerNames.SHORT, new Class[]{Short.class, Short.TYPE}, new ShortMarshaller(this));
        setTypeMarshaller0(TypeMarshallerNames.BYTE, new Class[]{Byte.class, Byte.TYPE}, new ByteMarshaller(this));
        setTypeMarshaller0(TypeMarshallerNames.BOOLEAN, new Class[]{Boolean.class, Boolean.TYPE}, TypeMarshallerNames.BOOLEAN_TO_INTEGER);

        setTypeMarshaller0(TypeMarshallerNames.BIG_INTEGER, BigInteger.class, new BigIntegerMarshaller(this));
        setTypeMarshaller0(TypeMarshallerNames.BIG_DECIMAL, BigDecimal.class, new BigDecimalMarshaller(this));

        setTypeMarshaller0(TypeMarshallerNames.UTIL_DATE, java.util.Date.class, new UtilDateMarshaller(this));
        setTypeMarshaller0(TypeMarshallerNames.SQL_DATE, java.sql.Date.class, new SqlDateMarshaller(this));
        setTypeMarshaller0(TypeMarshallerNames.SQL_TIME, java.sql.Time.class, new SqlTimeMarshaller(this));
        setTypeMarshaller0(TypeMarshallerNames.SQL_TIMESTAMP, java.sql.Timestamp.class, new TimeStampMarshaller(this));

        setTypeMarshaller0(TypeMarshallerNames.DATE, Date.class, new DateOnlyMarshaller(this));
        setTypeMarshaller0(TypeMarshallerNames.MONTH, Month.class, new MonthYearMarshaller(this));
        setTypeMarshaller0(TypeMarshallerNames.YEAR, Year.class, new YearMarshaller(this));
        setTypeMarshaller0(TypeMarshallerNames.TIME, Time.class, new VpcTimeMarshaller(this));
        setTypeMarshaller0(TypeMarshallerNames.DATETIME, DateTime.class, new DateTimeMarshaller(this));
        setTypeMarshaller0(TypeMarshallerNames.TIMESTAMP, Timestamp.class, new TimestampMarshaller(this));
        setTypeMarshaller0(TypeMarshallerNames.BYTES, byte[].class, new ByteArrayToBlobMarshaller(this));
        setTypeMarshaller0(TypeMarshallerNames.BYTE_REFS, Byte[].class, new ByteRefArrayToBlobMarshaller(this));
        setTypeMarshaller0(TypeMarshallerNames.CHARS, char[].class, new CharArrayToClobMarshaller(this));
        setTypeMarshaller0(TypeMarshallerNames.CHAR_REFS, Character[].class, new CharRefArrayToClobMarshaller(this));

        setTypeMarshallerFactory0(StringType.class, new ConstantDataMarshallerFactory(this, TypeMarshallerNames.STRING));
        setTypeMarshallerFactory0(BooleanType.class, new ConstantDataMarshallerFactory(this, TypeMarshallerNames.BOOLEAN));
        setTypeMarshallerFactory0(DataType.class, new ConstantDataMarshallerFactory(this, TypeMarshallerNames.OBJECT));
        setTypeMarshallerFactory0(SerializableType.class, new ConstantDataMarshallerFactory(this, TypeMarshallerNames.SERIALIZABLE));

        setTypeMarshallerFactory0(ImageType.class, new ConstantDataMarshallerFactory(this, TypeMarshallerNames.SERIALIZABLE));
        setTypeMarshallerFactory0(FileType.class, new ConstantDataMarshallerFactory(this, TypeMarshallerNames.SERIALIZABLE));
        setTypeMarshallerFactory0(TemporalType.class, new TemporalDataMarshallerFactory(this));
        setTypeMarshallerFactory0(NumberType.class, new NumberDataMarshallerFactory(this));
        setTypeMarshallerFactory0(ListType.class, new ListDataMarshallerFactory(this));
        setTypeMarshallerFactory0(EnumType.class, new EnumMarshallerFactory(this));
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
    public void setTypeMarshaller(Class platformType, TypeMarshaller typeMarshaller) {
        setTypeMarshaller0(null, platformType, typeMarshaller);
    }

    private void setTypeMarshaller0(String id, Class platformType, String fromId) {
        setTypeMarshaller0(id, platformType, getTypeMarshaller(fromId));
    }

    private void setTypeMarshaller0(String id, TypeMarshaller typeMarshaller) {
        typeMarshaller.setMarshallManager(this);
        if (id != null) {
            idToMarshallerMap.put(id, typeMarshaller);
        }
    }

    private void setTypeMarshaller0(String id, Class[] platformType, String typeMarshallerId) {
        setTypeMarshaller0(id, platformType, getTypeMarshaller(typeMarshallerId));
    }

    private void setTypeMarshaller0(String id, Class[] platformType, TypeMarshaller wrapper) {
        wrapper.setMarshallManager(this);
        if (id != null) {
            idToMarshallerMap.put(id, wrapper);
        }
        if (platformType != null) {
            for (Class atype : platformType) {
                typeToMarshallerMap.put(atype, wrapper);
            }
        }
    }

    private void setTypeMarshaller0(String id, Class platformType, TypeMarshaller wrapper) {
        wrapper.setMarshallManager(this);
        if (id != null) {
            idToMarshallerMap.put(id, wrapper);
        }
        if (platformType != null) {
            typeToMarshallerMap.put(platformType, wrapper);
        }
    }

    @Override
    public void setTypeMarshallerFactory(Class dataType, TypeMarshallerFactory wrapperFactory) {
        setTypeMarshallerFactory0(dataType, wrapperFactory);
    }

    private void setTypeMarshallerFactory0(Class platformType, TypeMarshallerFactory wrapperFactory) {
        wrapperFactory.setMarshallManager(this);
        typeToMarshallerFactory.put(platformType, wrapperFactory);
    }

    public TypeMarshaller getTypeMarshaller0(Class platformType) {
        TypeMarshaller c = typeToMarshallerMap.get(platformType);
        if (c != null) {
            return c;
        }
        throw new NoSuchUPAElementException("NuSuchTypeMarshallerForType", platformType.getName());
    }

    @Override
    public TypeMarshaller getTypeMarshaller(String typeMarshallerId) {
        TypeMarshaller c = idToMarshallerMap.get(typeMarshallerId);
        if (c != null) {
            return c;
        }
        throw new NoSuchUPAElementException("NoSuchTypeMarshaller", typeMarshallerId);
    }

    @Override
    public TypeMarshaller getTypeMarshaller(Class platformType) {
        TypeMarshaller c = typeToMarshallerMap.get(platformType);
        if (c != null) {
            return c;
        }
        if (platformType.isEnum()) {
            return EnumMarshallerFactory.getSharedTypeMarshaller(platformType, this);
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

    @Override
    public TypeMarshaller getTypeMarshaller(DataTypeTransform p) {
        TypeMarshaller mm = dataTypeTransformToMarshaller.get(p);
        if (mm == null) {
            mm = new DataTypeTransformMarshaller(this, p, getTypeMarshaller(p.getTargetType()));
            dataTypeTransformToMarshaller.put(p, mm);
        }
        return mm;
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
        TypeMarshallerFactory c = typeToMarshallerFactory.get(someClass);
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
