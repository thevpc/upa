/*********************************************************
 *********************************************************
 **   DO NOT EDIT                                       **
 **                                                     **
 **   THIS FILE AS BEEN GENERATED AUTOMATICALLY         **
 **   BY UPA PORTABLE GENERATOR                         **
 **   (c) vpc                                           **
 **                                                     **
 *********************************************************
 ********************************************************/



namespace Net.Vpc.Upa.Types
{


    public sealed class TypesFactory {

        public static readonly Net.Vpc.Upa.Types.DataType OBJECT = new Net.Vpc.Upa.Types.SerializableType("OBJECT", typeof(object), true);

        public static readonly Net.Vpc.Upa.Types.BooleanType BOOLEAN = Net.Vpc.Upa.Types.BooleanType.BOOLEAN_REF;

        public static readonly Net.Vpc.Upa.Types.DataType VOID = new Net.Vpc.Upa.Types.SerializableType("VOID", typeof(void), true);

        public static readonly Net.Vpc.Upa.Types.BigIntType BIGINT = Net.Vpc.Upa.Types.BigIntType.DEFAULT;

        public static readonly Net.Vpc.Upa.Types.IntType INT = Net.Vpc.Upa.Types.IntType.DEFAULT;

        public static readonly Net.Vpc.Upa.Types.LongType LONG = Net.Vpc.Upa.Types.LongType.DEFAULT;

        public static readonly Net.Vpc.Upa.Types.ByteType BYTE = Net.Vpc.Upa.Types.ByteType.DEFAULT;

        public static readonly Net.Vpc.Upa.Types.DoubleType DOUBLE = Net.Vpc.Upa.Types.DoubleType.DEFAULT;

        public static readonly Net.Vpc.Upa.Types.FloatType FLOAT = Net.Vpc.Upa.Types.FloatType.DEFAULT;

        public static readonly Net.Vpc.Upa.Types.ShortType SHORT = Net.Vpc.Upa.Types.ShortType.DEFAULT;

        public static readonly Net.Vpc.Upa.Types.DateType DATE = Net.Vpc.Upa.Types.DateType.DEFAULT;

        public static readonly Net.Vpc.Upa.Types.TimeType TIME = Net.Vpc.Upa.Types.TimeType.DEFAULT;

        public static readonly Net.Vpc.Upa.Types.DateTimeType DATETIME = Net.Vpc.Upa.Types.DateTimeType.DEFAULT;

        public static readonly Net.Vpc.Upa.Types.TimestampType TIMESTAMP = Net.Vpc.Upa.Types.TimestampType.DEFAULT;

        public static readonly Net.Vpc.Upa.Types.StringType STRING = Net.Vpc.Upa.Types.StringType.DEFAULT;

        public static readonly Net.Vpc.Upa.Types.MonthType MONTH = Net.Vpc.Upa.Types.MonthType.DEFAULT;

        public static readonly Net.Vpc.Upa.Types.YearType YEAR = Net.Vpc.Upa.Types.YearType.DEFAULT;















        public static readonly Net.Vpc.Upa.Types.FileType FILE = Net.Vpc.Upa.Types.FileType.DEFAULT;

        public static readonly Net.Vpc.Upa.Types.FileType IMAGE = Net.Vpc.Upa.Types.ImageType.DEFAULT;

        public static readonly Net.Vpc.Upa.Types.ByteArrayType BYTES = Net.Vpc.Upa.Types.ByteArrayType.BYTES;

        public static readonly Net.Vpc.Upa.Types.ByteArrayType BYTE_REFS = Net.Vpc.Upa.Types.ByteArrayType.BYTE_REFS;

        public static readonly Net.Vpc.Upa.Types.CharArrayType CHARS = Net.Vpc.Upa.Types.CharArrayType.CHARS;

        public static readonly Net.Vpc.Upa.Types.CharArrayType CHAR_REFS = Net.Vpc.Upa.Types.CharArrayType.CHAR_REFS;

        private static System.Collections.Generic.IDictionary<System.Type , Net.Vpc.Upa.Types.DataType> defaultMapping = new System.Collections.Generic.Dictionary<System.Type , Net.Vpc.Upa.Types.DataType>();

        private static readonly System.Collections.Generic.IDictionary<System.Type , string> typeNames = new System.Collections.Generic.Dictionary<System.Type , string>();

        static TypesFactory(){
            System.Collections.Generic.IDictionary<System.Type , string> typeNames0 = typeNames;
            typeNames0[typeof(string)]="string";
            typeNames0[typeof(int?)]="int";
            typeNames0[typeof(int)]="int";
            typeNames0[typeof(short?)]="short";
            typeNames0[typeof(short)]="short";
            typeNames0[typeof(byte?)]="byte";
            typeNames0[typeof(byte)]="byte";
            typeNames0[typeof(long?)]="long";
            typeNames0[typeof(long)]="long";
            typeNames0[typeof(float?)]="float";
            typeNames0[typeof(float)]="float";
            typeNames0[typeof(double?)]="double";
            typeNames0[typeof(double)]="double";
            typeNames0[typeof(bool?)]="boolean";
            typeNames0[typeof(bool)]="boolean";
            typeNames0[typeof(Net.Vpc.Upa.Types.Temporal)]="datetime";
            typeNames0[typeof(Net.Vpc.Upa.Types.Date)]="date";
            typeNames0[typeof(Net.Vpc.Upa.Types.Time)]="time";
            typeNames0[typeof(Net.Vpc.Upa.Types.Timestamp)]="timestamp";
            typeNames0[typeof(Net.Vpc.Upa.Types.DateTime)]="datetime";
            typeNames0[typeof(Net.Vpc.Upa.Types.Date)]="date";
            typeNames0[typeof(Net.Vpc.Upa.Types.Time)]="time";
            typeNames0[typeof(Net.Vpc.Upa.Types.Timestamp)]="timestamp";
            typeNames0[typeof(Net.Vpc.Upa.Types.Year)]="year";
            typeNames0[typeof(Net.Vpc.Upa.Types.Month)]="month";
            typeNames0[typeof(System.Numerics.BigInteger?)]="bigint";
            typeNames0[typeof(object)]="object";
            typeNames0[typeof(byte[])]="blob";
            typeNames0[typeof(byte?[])]="rblob";
            typeNames0[typeof(char[])]="clob";
            typeNames0[typeof(char?[])]="rclob";
            Register(typeof(int?), INT);
            Register(typeof(int), INT);
            Register(typeof(double?), DOUBLE);
            Register(typeof(double), DOUBLE);
            Register(typeof(System.Numerics.BigInteger?), BIGINT);
            Register(typeof(byte?), BYTE);
            Register(typeof(byte), BYTE);
            Register(typeof(float?), FLOAT);
            Register(typeof(float), FLOAT);
            Register(typeof(long?), LONG);
            Register(typeof(long), LONG);
            Register(typeof(short?), SHORT);
            Register(typeof(short), SHORT);
            Register(typeof(string), Net.Vpc.Upa.Types.StringType.DEFAULT);
            Register(typeof(Net.Vpc.Upa.Types.Date), DATE);
            Register(typeof(Net.Vpc.Upa.Types.Month), MONTH);
            Register(typeof(Net.Vpc.Upa.Types.Year), YEAR);
            Register(typeof(Net.Vpc.Upa.Types.Time), TIME);
            Register(typeof(bool?), Net.Vpc.Upa.Types.BooleanType.BOOLEAN_REF);
            Register(typeof(bool), Net.Vpc.Upa.Types.BooleanType.BOOLEAN);
            Register(typeof(Net.Vpc.Upa.Types.FileData), FILE);
            Register(typeof(byte[]), BYTES);
            Register(typeof(char[]), CHARS);
            Register(typeof(byte?[]), BYTE_REFS);
            Register(typeof(char?[]), CHAR_REFS);
            //All the of the following types are not supported in C#
        }

        private TypesFactory() {
        }

        public static void Register(System.Type clazz, Net.Vpc.Upa.Types.DataType dataType) {
            defaultMapping[clazz]=dataType;
        }

        public static Net.Vpc.Upa.Types.DataType ForPlatformType(System.Type clazz) {
            Net.Vpc.Upa.Types.DataType o = Net.Vpc.Upa.FwkConvertUtils.GetMapValue<System.Type,Net.Vpc.Upa.Types.DataType>(defaultMapping,clazz);
            if (o != null) {
                return o;
            }
            if ((clazz).IsEnum) {
                return new Net.Vpc.Upa.Types.EnumType(clazz, true);
            }
            return OBJECT;
        }

        public static Net.Vpc.Upa.Types.ListType ForList(string name, System.Collections.Generic.IList<object> v, Net.Vpc.Upa.Types.DataType eltClass, bool nullable) {
            return new Net.Vpc.Upa.Types.ListType(name, v, eltClass, nullable);
        }

        public static string GetTypeName(System.Type clazz) {
            return Net.Vpc.Upa.FwkConvertUtils.GetMapValue<System.Type,string>(typeNames,clazz);
        }
    }
}
