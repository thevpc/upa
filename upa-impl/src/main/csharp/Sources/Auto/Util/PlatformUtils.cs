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



using System.Linq;
namespace Net.Vpc.Upa.Impl.Util
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 1/5/13 11:29 PM
     */

    public partial class PlatformUtils {

        private static readonly System.Diagnostics.TraceSource log = new System.Diagnostics.TraceSource((typeof(Net.Vpc.Upa.Impl.Util.PlatformUtils)).FullName);

        public static readonly System.Collections.Generic.IDictionary<System.Type , object> DEFAULT_VALUES_BY_TYPE = new System.Collections.Generic.Dictionary<System.Type , object>();

        public static readonly System.Collections.Generic.IDictionary<System.Type , System.Type> PRIMITIVE_TO_REF_TYPES = new System.Collections.Generic.Dictionary<System.Type , System.Type>();

        public static readonly System.Collections.Generic.IDictionary<System.Type , System.Type> REF_TO_PRIMITIVE_TYPES = new System.Collections.Generic.Dictionary<System.Type , System.Type>();

        public static readonly Net.Vpc.Upa.Types.Temporal MIN_DATE = new Net.Vpc.Upa.Types.DateTime(0);

        private static readonly System.Collections.Generic.IDictionary<System.Type , string> typeNames = new System.Collections.Generic.Dictionary<System.Type , string>();

        private static Net.Vpc.Upa.Impl.Util.PlatformTypeProxy proxyFactory;

        static PlatformUtils(){
            Net.Vpc.Upa.Impl.Util.PlatformUtils.DEFAULT_VALUES_BY_TYPE[typeof(short)]=(short) ((short)0);
            Net.Vpc.Upa.Impl.Util.PlatformUtils.DEFAULT_VALUES_BY_TYPE[typeof(long)]=0L;
            Net.Vpc.Upa.Impl.Util.PlatformUtils.DEFAULT_VALUES_BY_TYPE[typeof(int)]=0;
            Net.Vpc.Upa.Impl.Util.PlatformUtils.DEFAULT_VALUES_BY_TYPE[typeof(double)]=0.0;
            Net.Vpc.Upa.Impl.Util.PlatformUtils.DEFAULT_VALUES_BY_TYPE[typeof(float)]=0.0f;
            Net.Vpc.Upa.Impl.Util.PlatformUtils.DEFAULT_VALUES_BY_TYPE[typeof(byte)]=(byte) ((byte)0);
            Net.Vpc.Upa.Impl.Util.PlatformUtils.DEFAULT_VALUES_BY_TYPE[typeof(char)]=(char) ((char)0);
            Net.Vpc.Upa.Impl.Util.PlatformUtils.PRIMITIVE_TO_REF_TYPES[typeof(short)]=typeof(short?);
            Net.Vpc.Upa.Impl.Util.PlatformUtils.PRIMITIVE_TO_REF_TYPES[typeof(long)]=typeof(long?);
            Net.Vpc.Upa.Impl.Util.PlatformUtils.PRIMITIVE_TO_REF_TYPES[typeof(int)]=typeof(int?);
            Net.Vpc.Upa.Impl.Util.PlatformUtils.PRIMITIVE_TO_REF_TYPES[typeof(double)]=typeof(double?);
            Net.Vpc.Upa.Impl.Util.PlatformUtils.PRIMITIVE_TO_REF_TYPES[typeof(float)]=typeof(float?);
            Net.Vpc.Upa.Impl.Util.PlatformUtils.PRIMITIVE_TO_REF_TYPES[typeof(byte)]=typeof(byte?);
            Net.Vpc.Upa.Impl.Util.PlatformUtils.PRIMITIVE_TO_REF_TYPES[typeof(char)]=typeof(char?);
            Net.Vpc.Upa.Impl.Util.PlatformUtils.REF_TO_PRIMITIVE_TYPES[typeof(short?)]=typeof(short);
            Net.Vpc.Upa.Impl.Util.PlatformUtils.REF_TO_PRIMITIVE_TYPES[typeof(long?)]=typeof(long);
            Net.Vpc.Upa.Impl.Util.PlatformUtils.REF_TO_PRIMITIVE_TYPES[typeof(int?)]=typeof(int);
            Net.Vpc.Upa.Impl.Util.PlatformUtils.REF_TO_PRIMITIVE_TYPES[typeof(double?)]=typeof(double);
            Net.Vpc.Upa.Impl.Util.PlatformUtils.REF_TO_PRIMITIVE_TYPES[typeof(float?)]=typeof(float);
            Net.Vpc.Upa.Impl.Util.PlatformUtils.REF_TO_PRIMITIVE_TYPES[typeof(byte?)]=typeof(byte);
            Net.Vpc.Upa.Impl.Util.PlatformUtils.REF_TO_PRIMITIVE_TYPES[typeof(char?)]=typeof(char);
            typeNames[typeof(string)]="string";
            typeNames[typeof(int?)]="int";
            typeNames[typeof(int)]="int";
            typeNames[typeof(short?)]="short";
            typeNames[typeof(short)]="short";
            typeNames[typeof(byte?)]="byte";
            typeNames[typeof(byte)]="byte";
            typeNames[typeof(long?)]="long";
            typeNames[typeof(long)]="long";
            typeNames[typeof(float?)]="float";
            typeNames[typeof(float)]="float";
            typeNames[typeof(double?)]="double";
            typeNames[typeof(double)]="double";
            typeNames[typeof(bool?)]="boolean";
            typeNames[typeof(bool)]="boolean";
            typeNames[typeof(Net.Vpc.Upa.Types.Temporal)]="datetime";
            typeNames[typeof(Net.Vpc.Upa.Types.Date)]="date";
            typeNames[typeof(Net.Vpc.Upa.Types.Time)]="time";
            typeNames[typeof(Net.Vpc.Upa.Types.Timestamp)]="timestamp";
            typeNames[typeof(Net.Vpc.Upa.Types.DateTime)]="datetime";
            typeNames[typeof(Net.Vpc.Upa.Types.Date)]="date";
            typeNames[typeof(Net.Vpc.Upa.Types.Time)]="time";
            typeNames[typeof(Net.Vpc.Upa.Types.Timestamp)]="timestamp";
            typeNames[typeof(Net.Vpc.Upa.Types.Year)]="year";
            typeNames[typeof(Net.Vpc.Upa.Types.Month)]="month";
            typeNames[typeof(System.Numerics.BigInteger?)]="bigint";
            typeNames[typeof(object)]="object";
            typeNames[typeof(byte[])]="blob";
            typeNames[typeof(byte?[])]="rblob";
            typeNames[typeof(char[])]="clob";
            typeNames[typeof(char?[])]="rclob";
        }

        public static System.Type ToRefType(System.Type type) {
            System.Type t = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<System.Type,System.Type>(PRIMITIVE_TO_REF_TYPES,type);
            if (t != null) {
                return t;
            }
            return type;
        }

        public static System.Type ToPrimitiveType(System.Type type) {
            System.Type t = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<System.Type,System.Type>(REF_TO_PRIMITIVE_TYPES,type);
            if (t != null) {
                return t;
            }
            return type;
        }

        public static System.Type GetExprNumberType(System.Type numberClass1, System.Type numberClass2) {
            bool nullable = !(numberClass1).IsPrimitive || !(numberClass2).IsPrimitive;
            if (IsAnyInteger(numberClass1) && IsAnyInteger(numberClass2)) {
                int w1 = GetIntWeight(numberClass1);
                int w2 = GetIntWeight(numberClass2);
                System.Type t = (w1 >= w2) ? numberClass1 : numberClass2;
                return nullable ? ToRefType(t) : ToPrimitiveType(t);
            } else if (IsAnyInteger(numberClass1) && IsAnyFloat(numberClass2)) {
                numberClass1 = IsInt8(numberClass1) ? ((System.Type)(typeof(float?))) : IsInt16(numberClass1) ? ((System.Type)(typeof(float?))) : IsInt32(numberClass1) ? ((System.Type)(typeof(float?))) : IsInt64(numberClass1) ? typeof(double?) : IsBigInt(numberClass1) ? typeof(System.Decimal?) : typeof(System.Decimal?);
                return GetExprNumberType(numberClass1, numberClass2);
            } else if (IsAnyFloat(numberClass1) && IsAnyInteger(numberClass2)) {
                return GetExprNumberType(numberClass2, numberClass1);
            } else if (IsAnyFloat(numberClass1) && IsAnyFloat(numberClass2)) {
                int w1 = GetFloatWeight(numberClass1);
                int w2 = GetFloatWeight(numberClass2);
                System.Type t = (w1 >= w2) ? numberClass1 : numberClass2;
                return nullable ? ToRefType(t) : ToPrimitiveType(t);
            }
            throw new System.ArgumentException ("Invalid Number Expr " + numberClass1 + " , " + numberClass2);
        }

        public static int GetIntWeight(System.Type clazz) {
            int pos = 0;
            pos++;
            if (IsInt8(clazz)) {
                return pos;
            }
            pos++;
            if (IsInt16(clazz)) {
                return pos;
            }
            pos++;
            if (IsInt32(clazz)) {
                return pos;
            }
            pos++;
            if (IsInt64(clazz)) {
                return pos;
            }
            pos++;
            if (IsInt64(clazz)) {
                return pos;
            }
            pos++;
            if (IsBigInt(clazz)) {
                return pos;
            }
            throw new System.ArgumentException ("Not an integer");
        }

        public static int GetFloatWeight(System.Type clazz) {
            int pos = 0;
            pos++;
            if (IsFloat32(clazz)) {
                return pos;
            }
            pos++;
            if (IsFloat64(clazz)) {
                return pos;
            }
            pos++;
            if (IsBigFloat(clazz)) {
                return pos;
            }
            throw new System.ArgumentException ("Not an integer");
        }

        public static bool IsTime(System.Type clazz) {
            return typeof(Net.Vpc.Upa.Types.Time).IsAssignableFrom(clazz) || typeof(Net.Vpc.Upa.Types.Time).IsAssignableFrom(clazz);
        }

        public static bool IsDateOnly(System.Type clazz) {
            return typeof(Net.Vpc.Upa.Types.Date).IsAssignableFrom(clazz) || typeof(Net.Vpc.Upa.Types.Date).IsAssignableFrom(clazz);
        }

        public static bool IsDateTime(System.Type clazz) {
            return typeof(Net.Vpc.Upa.Types.Temporal).Equals(clazz) || typeof(Net.Vpc.Upa.Types.DateTime).IsAssignableFrom(clazz);
        }

        public static bool IsTimestamp(System.Type clazz) {
            return typeof(Net.Vpc.Upa.Types.Timestamp).IsAssignableFrom(clazz) || typeof(Net.Vpc.Upa.Types.Timestamp).IsAssignableFrom(clazz);
        }

        public static bool IsMonth(System.Type clazz) {
            return typeof(Net.Vpc.Upa.Types.Month).IsAssignableFrom(clazz);
        }

        public static bool IsYear(System.Type clazz) {
            return typeof(Net.Vpc.Upa.Types.Year).IsAssignableFrom(clazz);
        }

        public static bool IsAnyDate(System.Type clazz) {
            return typeof(Net.Vpc.Upa.Types.Temporal).IsAssignableFrom(clazz);
        }

        public static bool IsInt64(System.Type clazz) {
            return typeof(long?).Equals(clazz) || typeof(long).Equals(clazz);
        }

        public static bool IsInt32(System.Type clazz) {
            return typeof(int?).Equals(clazz) || typeof(int).Equals(clazz);
        }

        public static bool IsInt16(System.Type clazz) {
            return typeof(short?).Equals(clazz) || typeof(short).Equals(clazz);
        }

        public static bool IsInt8(System.Type clazz) {
            return typeof(byte?).Equals(clazz) || typeof(byte).Equals(clazz);
        }

        public static bool IsBigInt(System.Type clazz) {
            return typeof(System.Numerics.BigInteger?).Equals(clazz);
        }

        public static bool IsBigFloat(System.Type clazz) {
            return typeof(System.Decimal?).Equals(clazz);
        }

        public static bool IsFloat32(System.Type clazz) {
            return typeof(float?).Equals(clazz) || typeof(float).Equals(clazz);
        }

        public static bool IsFloat64(System.Type clazz) {
            return typeof(double?).Equals(clazz) || typeof(double).Equals(clazz);
        }

        public static bool IsBool(System.Type clazz) {
            return typeof(bool?).Equals(clazz) || typeof(bool).Equals(clazz);
        }

        public static bool IsAnyNumber(System.Type clazz) {
            return typeof(object).IsAssignableFrom(clazz);
        }

        public static bool IsAnyInteger(System.Type clazz) {
            return typeof(int?).Equals(clazz) || typeof(int).Equals(clazz) || typeof(long?).Equals(clazz) || typeof(long).Equals(clazz) || typeof(short?).Equals(clazz) || typeof(short).Equals(clazz) || typeof(byte?).Equals(clazz) || typeof(byte).Equals(clazz) || typeof(System.Numerics.BigInteger?).Equals(clazz);
        }

        public static bool IsAnyFloat(System.Type clazz) {
            return typeof(float?).Equals(clazz) || typeof(float).Equals(clazz) || typeof(double?).Equals(clazz) || typeof(double).Equals(clazz) || typeof(System.Decimal?).Equals(clazz);
        }

        public static bool IsNumber(System.Type clazz) {
            return (typeof(object)).IsAssignableFrom(clazz);
        }

        public static System.Type ForName(string name) /* throws System.Exception */  {
            return System.Type.GetType (name, true);
        }

        public static  T Convert<T>(object @value, System.Type to) {
            if (@value == null || to.IsInstanceOfType(@value)) {
                return (T) @value;
            }
            if ((to).IsEnum) {
                if (@value is string) {
                    return (T) System.Enum.Parse((System.Type) to,(string) @value);
                } else if (@value is int?) {
                    return (T) GetEnumValues(to)[(int?) @value];
                }
            }
            return System.Convert.ChangeType(@value,to);
        }

        public static bool IsNullableType(System.Type type) {
            return !(type).IsPrimitive;
        }

        public static bool IsPrimitiveType(System.Type type) {
            return (type).IsPrimitive;
        }

        public static System.Type ToTemporalType(Net.Vpc.Upa.Types.TemporalOption option, System.Type baseType) {
            System.Type upaBaseType = typeof(Net.Vpc.Upa.Types.Temporal);
            System.Type osBaseType = typeof(Net.Vpc.Upa.Types.Temporal);
            System.Type upaType = null;
            System.Type osType = null;
            switch(option) {
                case Net.Vpc.Upa.Types.TemporalOption.TIME:
                    {
                        upaType = typeof(Net.Vpc.Upa.Types.Time);
                        osType = typeof(Net.Vpc.Upa.Types.Time);
                        break;
                    }
                case Net.Vpc.Upa.Types.TemporalOption.DATE:
                    {
                        upaType = typeof(Net.Vpc.Upa.Types.Date);
                        osType = typeof(Net.Vpc.Upa.Types.Date);
                        break;
                    }
                case Net.Vpc.Upa.Types.TemporalOption.DATETIME:
                    {
                        upaType = typeof(Net.Vpc.Upa.Types.DateTime);
                        osType = typeof(Net.Vpc.Upa.Types.Timestamp);
                        break;
                    }
                case Net.Vpc.Upa.Types.TemporalOption.TIMESTAMP:
                    {
                        upaType = typeof(Net.Vpc.Upa.Types.Timestamp);
                        osType = typeof(Net.Vpc.Upa.Types.Timestamp);
                        break;
                    }
                case Net.Vpc.Upa.Types.TemporalOption.MONTH:
                    {
                        upaType = typeof(Net.Vpc.Upa.Types.Month);
                        osType = typeof(Net.Vpc.Upa.Types.Date);
                        break;
                    }
                case Net.Vpc.Upa.Types.TemporalOption.YEAR:
                    {
                        upaType = typeof(Net.Vpc.Upa.Types.Year);
                        osType = typeof(Net.Vpc.Upa.Types.Date);
                        break;
                    }
                case Net.Vpc.Upa.Types.TemporalOption.DEFAULT:
                    {
                        upaType = typeof(Net.Vpc.Upa.Types.DateTime);
                        osType = typeof(Net.Vpc.Upa.Types.Timestamp);
                        break;
                    }
                default:
                    {
                        throw new System.ArgumentException ("Unsupported Temperal " + option);
                    }
            }
            if (baseType == null) {
                return upaType;
            }
            if (osType.IsAssignableFrom(baseType)) {
                return osType;
            }
            if (osBaseType.Equals(baseType)) {
                return upaType;
            }
            if (upaBaseType.Equals(baseType)) {
                return upaType;
            }
            return upaType;
        }

        public static string GetTypeName(System.Type clazz) {
            return Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<System.Type,string>(typeNames,clazz);
        }

        public static bool IsVoid(System.Type c) {
            return c.Equals(typeof(void)) || c.Equals(typeof(void));
        }

        public static  System.Collections.Generic.IList<T> EmptyList<T>() {
            return new System.Collections.Generic.List<T>();
        }

        public static  System.Collections.Generic.IList<object> TypedListToObjectList<T>(System.Collections.Generic.IList<T> anyList) {
            if (anyList == null) {
                return null;
            }
            System.Collections.Generic.List<object> list = new System.Collections.Generic.List<object>();
            foreach (T i in anyList) {
                list.Add(i);
            }
            return list;
        }

        public static System.Collections.Generic.IList<object> AnyObjectToObjectList(object anyList) {
            if (anyList == null) {
                return null;
            }
            System.Collections.Generic.List<object> list = new System.Collections.Generic.List<object>();
            foreach (object i in (System.Collections.Generic.IList<object>) anyList) {
                list.Add(i);
            }
            return list;
        }



        public static  System.Collections.Generic.IList<T> UnmodifiableList<T>(System.Collections.Generic.IList<T> list) {
            return new System.Collections.Generic.List<T>(list);
        }

        public static  System.Collections.Generic.IDictionary<K , T> UnmodifiableMap<K, T>(System.Collections.Generic.IDictionary<K , T> map) {
            return new System.Collections.Generic.Dictionary<K , T>(map);
        }

        public static  void AddAll<T>(System.Collections.Generic.IList<T> list, T[] arr) {
            Net.Vpc.Upa.Impl.FwkConvertUtils.ListAddRange(list, new System.Collections.Generic.List<T>(arr));
        }

        public static string ArrayToString(object[] arr) {
            if (arr == null) {
                return "null";
            }
            System.Text.StringBuilder sb = new System.Text.StringBuilder("[");
            for (int i = 0; i < arr.Length; i++) {
                if (i > 0) {
                    sb.Append(", ");
                }
                sb.Append(System.Convert.ToString(arr[i]));
            }
            sb.Append("]");
            return sb.ToString();
        }

        public static object NewInstance(System.Type clazz) {
            try {
                return System.Activator.CreateInstance(clazz);
            } catch (System.Exception ex) {
                log.TraceEvent(System.Diagnostics.TraceEventType.Error,100,Net.Vpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter(null,ex));
                throw new Net.Vpc.Upa.Exceptions.UPAException(ex, new Net.Vpc.Upa.Types.I18NString("InstantationError"));
            }
        }

        public static object[] GetEnumValues(System.Type enumType) {
            return (object[])System.Enum.GetValues(enumType);
        }

        public static Net.Vpc.Upa.Config.Decoration GetDecoration(System.Type type, System.Type annotationClass, string persistenceGroup, string persistenceUnit, Net.Vpc.Upa.Impl.Config.Decorations.DecorationRepository repository) {
            Net.Vpc.Upa.Config.Decoration a = repository.GetTypeDecoration(type, annotationClass);
            if (a != null && AcceptAnnotation(a, persistenceGroup, persistenceUnit)) {
                return a;
            }
            return null;
        }

        private static bool AcceptAnnotation(Net.Vpc.Upa.Config.Decoration a, string persistenceGroup, string persistenceUnit) {
            if (a == null) {
                return false;
            }
            Net.Vpc.Upa.Config.Decoration configObject = a.GetDecoration("config");
            if (configObject != null) {
                string v = Net.Vpc.Upa.Impl.Util.StringUtils.Trim(configObject.GetString("persistenceGroup"));
                if (!Net.Vpc.Upa.Impl.Util.StringUtils.MatchesSimpleExpression(persistenceGroup, v, Net.Vpc.Upa.Impl.Util.PatternType.DOT_PATH)) {
                    return false;
                }
                v = Net.Vpc.Upa.Impl.Util.StringUtils.Trim(configObject.GetString("persistenceUnit"));
                if (!Net.Vpc.Upa.Impl.Util.StringUtils.MatchesSimpleExpression(persistenceUnit, v, Net.Vpc.Upa.Impl.Util.PatternType.DOT_PATH)) {
                    return false;
                }
            }
            return true;
        }

        public static System.Reflection.FieldInfo FindField(System.Type clz, string name, Net.Vpc.Upa.Filters.ObjectFilter<System.Reflection.FieldInfo> filter) {
            System.Type r = clz;
            while (r != null) {
                System.Reflection.FieldInfo f = null;
                try {
                    f = r.GetField(name, System.Reflection.BindingFlags.Default|System.Reflection.BindingFlags.Public|System.Reflection.BindingFlags.NonPublic|System.Reflection.BindingFlags.Static|System.Reflection.BindingFlags.Instance);
                } catch (System.Exception ex) {
                }
                //ignore
                if (f != null && (filter == null || filter.Accept(f))) {
                    return f;
                }
                r = (r).BaseType;
            }
            return null;
        }

        public static System.Collections.Generic.IList<System.Reflection.FieldInfo> FindFields(System.Type clz, string name) {
            System.Collections.Generic.IList<System.Reflection.FieldInfo> all = new System.Collections.Generic.List<System.Reflection.FieldInfo>();
            System.Type r = clz;
            while (r != null) {
                System.Reflection.FieldInfo f = null;
                try {
                    f = r.GetField(name, System.Reflection.BindingFlags.Default|System.Reflection.BindingFlags.Public|System.Reflection.BindingFlags.NonPublic|System.Reflection.BindingFlags.Static|System.Reflection.BindingFlags.Instance);
                } catch (System.Exception ex) {
                }
                //ignore
                if (f != null) {
                    all.Add(f);
                }
                r = (r).BaseType;
            }
            return all;
        }

        public static string GetterName(string name, System.Type type) {
            if (typeof(bool).Equals(type)) {
                return "is" + Suffix(name);
            }
            return "get" + Suffix(name);
        }

        public static string ToCamelCase(string name) {
            return ToUpperCamelCase(name, false);
        }

        public static string ToUpperCamelCase(string name, bool processWhites) {
            switch((name).Length) {
                case 0:
                    {
                        return name;
                    }
                case 1:
                    {
                        return name.ToUpper();
                    }
                default:
                    {
                        char[] chars = name.ToCharArray();
                        System.Text.StringBuilder sb = new System.Text.StringBuilder();
                        bool wasSpace = true;
                        int i = 0;
                        while (i < chars.Length) {
                            char c = chars[i];
                            bool isSpace = (processWhites && (char.IsWhiteSpace(c) || c == '_'));
                            if (!isSpace) {
                                if (wasSpace) {
                                    sb.Append(char.ToUpper(c));
                                } else {
                                    sb.Append(c);
                                }
                            } else if (i == 0 && c == '_') {
                                sb.Append(c);
                            }
                            wasSpace = isSpace;
                            i++;
                        }
                        return sb.ToString();
                    }
            }
        }

        public static string ToUpperCamelCase(string name) {
            return ToUpperCamelCase(name, false);
        }

        public static string ToLowerCamelCase(string name) {
            return ToLowerCamelCase(name, false);
        }

        public static string ToLowerCamelCase(string name, bool processWhites) {
            switch((name).Length) {
                case 0:
                    {
                        return name;
                    }
                case 1:
                    {
                        return name.ToUpper();
                    }
                default:
                    {
                        char[] chars = name.ToCharArray();
                        System.Text.StringBuilder sb = new System.Text.StringBuilder();
                        bool wasSpace = true;
                        int i = 0;
                        while (i < chars.Length) {
                            char c = chars[i];
                            bool isSpace = (processWhites && (char.IsWhiteSpace(c) || c == '_'));
                            if (!isSpace) {
                                if (wasSpace) {
                                    if (char.IsUpper(c) && i + 1 < chars.Length && char.IsUpper(chars[i + 1])) {
                                        sb.Append(c);
                                    } else if (i == 0) {
                                        sb.Append(char.ToLower(c));
                                    } else {
                                        sb.Append(char.ToUpper(c));
                                    }
                                } else {
                                    sb.Append(c);
                                }
                            } else if (i == 0 && c == '_') {
                                sb.Append(c);
                            }
                            wasSpace = isSpace;
                            i++;
                        }
                        return sb.ToString();
                    }
            }
        }

        public static string SetterName(string name) {
            //Class<?> type = field.getDataType();
            return "set" + Suffix(name);
        }

        private static string Suffix(string s) {
            char[] chars = s.ToCharArray();
            chars[0] = char.ToUpper(chars[0]);
            return new string(chars);
        }

        public static bool IsStatic(System.Reflection.MethodInfo method) {
            return (((Net.Vpc.Upa.Impl.FwkConvertUtils.GetMethodModifiers(method)) & Net.Vpc.Upa.Impl.FwkConvertUtils.STATIC) != 0);
        }

        public static bool IsAbstract(System.Reflection.MethodInfo method) {
            return (((Net.Vpc.Upa.Impl.FwkConvertUtils.GetMethodModifiers(method)) & Net.Vpc.Upa.Impl.FwkConvertUtils.ABSTRACT) != 0);
        }

        public static bool IsAbstract(System.Type type) {
            return (((Net.Vpc.Upa.Impl.FwkConvertUtils.GetClassModifiers(type)) & Net.Vpc.Upa.Impl.FwkConvertUtils.STATIC) != 0);
        }

        public static bool IsInterface(System.Type type) {
            return (type).IsInterface;
        }

        public static bool IsStatic(System.Reflection.FieldInfo m) {
            return (((Net.Vpc.Upa.Impl.FwkConvertUtils.GetFieldModifiers(m)) & Net.Vpc.Upa.Impl.FwkConvertUtils.STATIC) != 0);
        }

        public static bool IsTransient(System.Reflection.FieldInfo m) {
            return (((Net.Vpc.Upa.Impl.FwkConvertUtils.GetFieldModifiers(m)) & Net.Vpc.Upa.Impl.FwkConvertUtils.TRANSIENT) != 0);
        }

        public static System.Reflection.MethodInfo[] GetConcreteMethods(System.Type clz) {
            return GetDeclaredMethods(clz, false, false);
        }

        public static System.Reflection.MethodInfo[] GetAllConcreteMethods(System.Type clz) {
            return GetDeclaredMethods(clz, true, false);
        }

        public static System.Reflection.MethodInfo[] GetDeclaredMethods(System.Type clz, bool includeInherited, bool includeAbstract) {
            if (!includeInherited) {
                System.Reflection.MethodInfo[] declaredMethods = clz.GetMethods(System.Reflection.BindingFlags.Default);
                if (includeAbstract) {
                    return declaredMethods;
                }
                System.Collections.Generic.List<System.Reflection.MethodInfo> m = new System.Collections.Generic.List<System.Reflection.MethodInfo>();
                foreach (System.Reflection.MethodInfo m1 in declaredMethods) {
                    if (!IsAbstract(m1)) {
                        m.Add(m1);
                    }
                }
                return m.ToArray();
            } else {
                System.Collections.Generic.List<System.Reflection.MethodInfo> curr = new System.Collections.Generic.List<System.Reflection.MethodInfo>();
                Net.Vpc.Upa.Impl.FwkConvertUtils.CollectionAddRange(curr, new System.Collections.Generic.List<System.Reflection.MethodInfo>(GetDeclaredMethods(clz, false, includeAbstract)));
                System.Type sc = (clz).BaseType;
                if (sc != null) {
                    Net.Vpc.Upa.Impl.FwkConvertUtils.CollectionAddRange(curr, new System.Collections.Generic.List<System.Reflection.MethodInfo>(GetDeclaredMethods(sc, includeInherited, includeAbstract)));
                }
                if (includeAbstract) {
                    foreach (System.Type aInterface in clz.GetInterfaces()) {
                        Net.Vpc.Upa.Impl.FwkConvertUtils.CollectionAddRange(curr, new System.Collections.Generic.List<System.Reflection.MethodInfo>(GetDeclaredMethods(aInterface, includeInherited, includeAbstract)));
                    }
                    //now remove duplicates
                    System.Collections.Generic.Dictionary<string , System.Reflection.MethodInfo> noDuplicates = new System.Collections.Generic.Dictionary<string , System.Reflection.MethodInfo>();
                    foreach (System.Reflection.MethodInfo c in curr) {
                        string ms = GetMethodSignature(c);
                        System.Reflection.MethodInfo old = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,System.Reflection.MethodInfo>(noDuplicates,ms);
                        if (old == null || IsAbstract(c)) {
                            noDuplicates[ms]=c;
                        }
                    }
                    return (noDuplicates).Values.ToArray();
                }
                return curr.ToArray();
            }
        }

        public static string GetMethodSignature(System.Reflection.MethodInfo method) {
            System.Text.StringBuilder types = new System.Text.StringBuilder();
            foreach (System.Type parameterType in Net.Vpc.Upa.Impl.FwkConvertUtils.GetMethodParameterTypes(method)) {
                if ((types).Length > 0) {
                    types.Append(",");
                }
                types.Append((parameterType).FullName);
            }
            return (method).Name + "(" + types + ")";
        }

        public static bool IsSerializable(System.Type type) {
            return type.IsSerializable;
        }

        public static string GetSystemLineSeparator() {
            return "\r\n";
        }

        public static System.Collections.Generic.IDictionary<string , string> GetSystemProperties() {
            System.Collections.Generic.IDictionary<string , string> m = new System.Collections.Generic.Dictionary<string , string>();
            return m;
        }

        public static int GetHashCode(object[] a) {
            if (a == null) return 0;
            int result = 1;
            foreach (object element in a) result = 31 * result + (element == null ? 0 : element.GetHashCode());
            return result;
        }

        public static  bool IsUndefinedValue<T>(System.Type type, T @value) {
            return value == default(T);
        }

        public static  T GetUndefinedValue<T>(System.Type type) {
            return ResolveUndefinedValue<T>(type);
        }

        public static  T ResolveUndefinedValue<T>(System.Type type) {
            return default(T);
        }

        public static Net.Vpc.Upa.Impl.Util.PlatformTypeProxy GetProxyFactory() {
            if (proxyFactory == null) {
                return new Net.Vpc.Upa.Impl.Util.PlatformTypeProxyCsharp();
            }
            return proxyFactory;
        }

        public static  T CreateObjectInterceptor<T>(System.Type type, Net.Vpc.Upa.Impl.Util.PlatformMethodProxy<T> methodProxy) {
            return GetProxyFactory().Create<T>(type, methodProxy);
        }

        public static string ReplaceNoDollarVars(string str, Net.Vpc.Upa.Impl.Util.Converter<string , string> varConverter) {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            {
                bool javaExprSupported = true;
                if (javaExprSupported) {
                    Net.Vpc.Upa.Impl.Util.Regexp.PortablePattern p = new Net.Vpc.Upa.Impl.Util.Regexp.PortablePattern("\\{[^\\{\\}]*\\}");
                    Net.Vpc.Upa.Impl.Util.Regexp.PortablePatternMatcher m = p.Matcher(str == null ? "" : str);
                    while (m.Find()) {
                        string g = m.Group(0);
                        string v = g.Substring(1, (g).Length - 1);
                        sb.Append(m.Replace(varConverter.Convert(v)));
                    }
                    sb.Append(m.Tail());
                    return sb.ToString();
                }
            }
            int i = 0;
            while (i >= 0 && i < (str).Length) {
                int j = str.IndexOf("{", i);
                if (j < 0) {
                    sb.Append(str.Substring(i));
                    i = -1;
                } else {
                    sb.Append(str.Substring(i, j));
                    int k = str.IndexOf("}", j + 1);
                    if (k < 0) {
                        sb.Append(varConverter.Convert(str.Substring(j + 1)));
                        i = -1;
                    } else {
                        sb.Append(varConverter.Convert(str.Substring(j + 1, k)));
                        i = k + 1;
                    }
                }
            }
            return sb.ToString();
        }

        public static bool IsInt32(string s) {
            try {
                System.Convert.ToInt32(s);
                return true;
            } catch (System.Exception e) {
                return false;
            }
        }

        public static  X[] AddToArray<X>(X[] arr, X x) {
            X[] arr2 = default(X[]);
            arr2 = new X[arr.Length + 1];
            System.Array.Copy(arr, 0, arr2, 0, arr.Length);
            arr2[arr.Length] = x;
            return arr2;
        }

        public static System.Exception CreateRuntimeException(System.Exception t) {
            if ((t).InnerException != null) {
                return CreateRuntimeException((t).InnerException);
            }
            if (t is System.Exception) {
                return (System.Exception) t;
            }
            return new System.Exception("RuntimeException", t);
        }
    }
}
