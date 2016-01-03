package net.vpc.upa.impl.persistence.shared;

import net.vpc.upa.impl.persistence.TypeMarshaller;
import net.vpc.upa.impl.persistence.TypeMarshallerFactory;

/**
 * User: taha Date: 18 juin 2003 Time: 17:46:53
 */
public class TypeMarshallerUtils {

    public static final TypeMarshaller OBJECT = new ObjectMarshaller();
    public static final TypeMarshaller STRING = new StringMarshaller();
    public static final TypeMarshaller DOUBLE = new DoubleMarshaller();
    public static final TypeMarshaller INTEGER = new IntegerMarshaller();
    public static final TypeMarshaller LONG = new LongMarshaller();
    public static final TypeMarshaller SHORT = new ShortMarshaller();
    public static final TypeMarshaller BYTE = new ByteMarshaller();
    public static final TypeMarshaller BIG_INTEGER = new BigIntegerMarshaller();
    public static final TypeMarshaller BIG_DECIMAL = new BigDecimalMarshaller();
    public static final TypeMarshaller FLOAT = new FloatMarshaller();
    public static final TypeMarshaller SQL_DATE = new SqlDateMarshaller();
    public static final TypeMarshaller UTIL_DATE = new UtilDateMarshaller();
    public static final TypeMarshaller DATE = new DateOnlyMarshaller();
    public static final TypeMarshaller DATE_END = new DateOnlyMarshaller();
    public static final TypeMarshaller MONTH_YEAR = new MonthYearMarshaller();
    public static final TypeMarshaller MONTH_YEAR_END = new MonthYearMarshaller();
    public static final TypeMarshaller YEAR = new YearMarshaller();
    public static final TypeMarshaller YEAR_END = new YearMarshaller();
    public static final TypeMarshaller DATE_TIME = new DateTimeMarshaller();
    public static final TypeMarshaller TIMESTAMP = new TimestampMarshaller();
    public static final TypeMarshaller VPC_TIME = new VpcTimeMarshaller();
    public static final TypeMarshaller SQL_TIME = new SqlTimeMarshaller();
    public static final TypeMarshaller SQL_TIMESTAMP = new TimeStampMarshaller();
    public static final TypeMarshaller BOOLEAN_FROM_NUMBER = new BooleanFromNumberMarshaller();
    public static final TypeMarshaller NULL = new NullMarshaller();
    public static final TypeMarshallerFactory F_BOOLEAN_FROM_NUMBER = new ConstantDataMarshallerFactory(BOOLEAN_FROM_NUMBER);
    public static final TypeMarshallerFactory F_STRING = new ConstantDataMarshallerFactory(STRING);
    public static final TypeMarshallerFactory F_OBJECT = new ConstantDataMarshallerFactory(OBJECT);
    public static final TypeMarshaller BYTES = new ByteArrayToBlobMarshaller();
    public static final TypeMarshaller BYTE_REFS = new ByteRefArrayToBlobMarshaller();
    public static final TypeMarshaller CHARS = new CharArrayToClobMarshaller();
    public static final TypeMarshaller CHAR_REFS = new CharRefArrayToClobMarshaller();
}
