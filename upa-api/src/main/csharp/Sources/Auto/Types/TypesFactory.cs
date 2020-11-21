/*********************************************************
 *********************************************************
 **   DO NOT EDIT                                       **
 **                                                     **
 **   THIS FILE HAS BEEN GENERATED AUTOMATICALLY         **
 **   BY UPA PORTABLE GENERATOR                         **
 **   (c) vpc                                           **
 **                                                     **
 *********************************************************
 ********************************************************/



namespace Net.TheVpc.Upa.Types
{


    public sealed class TypesFactory {

        public static readonly Net.TheVpc.Upa.Types.DataType OBJECT = new Net.TheVpc.Upa.Types.SerializableType("OBJECT", typeof(object), true);

        public static readonly Net.TheVpc.Upa.Types.BooleanType BOOLEAN = Net.TheVpc.Upa.Types.BooleanType.BOOLEAN_REF;

        public static readonly Net.TheVpc.Upa.Types.DataType VOID = new Net.TheVpc.Upa.Types.SerializableType("VOID", typeof(void), true);

        public static readonly Net.TheVpc.Upa.Types.BigIntType BIGINT = Net.TheVpc.Upa.Types.BigIntType.DEFAULT;

        public static readonly Net.TheVpc.Upa.Types.IntType INT = Net.TheVpc.Upa.Types.IntType.DEFAULT;

        public static readonly Net.TheVpc.Upa.Types.LongType LONG = Net.TheVpc.Upa.Types.LongType.DEFAULT;

        public static readonly Net.TheVpc.Upa.Types.ByteType BYTE = Net.TheVpc.Upa.Types.ByteType.DEFAULT;

        public static readonly Net.TheVpc.Upa.Types.DoubleType DOUBLE = Net.TheVpc.Upa.Types.DoubleType.DEFAULT;

        public static readonly Net.TheVpc.Upa.Types.FloatType FLOAT = Net.TheVpc.Upa.Types.FloatType.DEFAULT;

        public static readonly Net.TheVpc.Upa.Types.ShortType SHORT = Net.TheVpc.Upa.Types.ShortType.DEFAULT;

        public static readonly Net.TheVpc.Upa.Types.DateType DATE = Net.TheVpc.Upa.Types.DateType.DEFAULT;

        public static readonly Net.TheVpc.Upa.Types.TimeType TIME = Net.TheVpc.Upa.Types.TimeType.DEFAULT;

        public static readonly Net.TheVpc.Upa.Types.DateTimeType DATETIME = Net.TheVpc.Upa.Types.DateTimeType.DEFAULT;

        public static readonly Net.TheVpc.Upa.Types.TimestampType TIMESTAMP = Net.TheVpc.Upa.Types.TimestampType.DEFAULT;

        public static readonly Net.TheVpc.Upa.Types.StringType STRING = Net.TheVpc.Upa.Types.StringType.DEFAULT;

        public static readonly Net.TheVpc.Upa.Types.MonthType MONTH = Net.TheVpc.Upa.Types.MonthType.DEFAULT;

        public static readonly Net.TheVpc.Upa.Types.YearType YEAR = Net.TheVpc.Upa.Types.YearType.DEFAULT;















        public static readonly Net.TheVpc.Upa.Types.FileType FILE = Net.TheVpc.Upa.Types.FileType.DEFAULT;

        public static readonly Net.TheVpc.Upa.Types.FileType IMAGE = Net.TheVpc.Upa.Types.ImageType.DEFAULT;

        public static readonly Net.TheVpc.Upa.Types.ByteArrayType BYTES = Net.TheVpc.Upa.Types.ByteArrayType.BYTES;

        public static readonly Net.TheVpc.Upa.Types.ByteArrayType BYTE_REFS = Net.TheVpc.Upa.Types.ByteArrayType.BYTE_REFS;

        public static readonly Net.TheVpc.Upa.Types.CharArrayType CHARS = Net.TheVpc.Upa.Types.CharArrayType.CHARS;

        public static readonly Net.TheVpc.Upa.Types.CharArrayType CHAR_REFS = Net.TheVpc.Upa.Types.CharArrayType.CHAR_REFS;

        private static System.Collections.Generic.IDictionary<System.Type , Net.TheVpc.Upa.Types.DataType> defaultMapping = new System.Collections.Generic.Dictionary<System.Type , Net.TheVpc.Upa.Types.DataType>();

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
            typeNames0[typeof(Net.TheVpc.Upa.Types.Temporal)]="datetime";
            typeNames0[typeof(Net.TheVpc.Upa.Types.Date)]="date";
            typeNames0[typeof(Net.TheVpc.Upa.Types.Time)]="time";
            typeNames0[typeof(Net.TheVpc.Upa.Types.Timestamp)]="timestamp";
            typeNames0[typeof(Net.TheVpc.Upa.Types.DateTime)]="datetime";
            typeNames0[typeof(Net.TheVpc.Upa.Types.Date)]="date";
            typeNames0[typeof(Net.TheVpc.Upa.Types.Time)]="time";
            typeNames0[typeof(Net.TheVpc.Upa.Types.Timestamp)]="timestamp";
            typeNames0[typeof(Net.TheVpc.Upa.Types.Year)]="year";
            typeNames0[typeof(Net.TheVpc.Upa.Types.Month)]="month";
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
            Register(typeof(string), STRING);
            Register(typeof(Net.TheVpc.Upa.Types.Date), DATE);
            Register(typeof(Net.TheVpc.Upa.Types.Month), MONTH);
            Register(typeof(Net.TheVpc.Upa.Types.Year), YEAR);
            Register(typeof(Net.TheVpc.Upa.Types.Time), TIME);
            Register(typeof(bool?), Net.TheVpc.Upa.Types.BooleanType.BOOLEAN_REF);
            Register(typeof(bool), Net.TheVpc.Upa.Types.BooleanType.BOOLEAN);
            Register(typeof(Net.TheVpc.Upa.Types.FileData), FILE);
            Register(typeof(byte[]), BYTES);
            Register(typeof(char[]), CHARS);
            Register(typeof(byte?[]), BYTE_REFS);
            Register(typeof(char?[]), CHAR_REFS);
            Register(typeof(void), VOID);
            Register(typeof(void), VOID);
            //All the of the following types are not supported in C#
        }

        private TypesFactory() {
        }

        public static void Register(System.Type clazz, Net.TheVpc.Upa.Types.DataType dataType) {
            defaultMapping[clazz]=dataType;
        }

        public static Net.TheVpc.Upa.Types.DataType ForPlatformType(System.Type clazz) {
            Net.TheVpc.Upa.Types.DataType o = Net.TheVpc.Upa.FwkConvertUtils.GetMapValue<System.Type,Net.TheVpc.Upa.Types.DataType>(defaultMapping,clazz);
            if (o != null) {
                return o;
            }
            if ((clazz).IsEnum) {
                Net.TheVpc.Upa.Types.EnumType @value = new Net.TheVpc.Upa.Types.EnumType(clazz, true);
                defaultMapping[clazz]=@value;
                return @value;
            }
            return OBJECT;
        }

        public static Net.TheVpc.Upa.Types.ListType ForList(string name, System.Collections.Generic.IList<object> v, Net.TheVpc.Upa.Types.DataType eltClass, bool nullable) {
            return new Net.TheVpc.Upa.Types.ListType(name, v, eltClass, nullable);
        }

        public static string GetTypeName(System.Type clazz) {
            return Net.TheVpc.Upa.FwkConvertUtils.GetMapValue<System.Type,string>(typeNames,clazz);
        }
    }
}
