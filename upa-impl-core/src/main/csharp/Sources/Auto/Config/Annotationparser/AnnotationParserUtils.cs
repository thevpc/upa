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



namespace Net.TheVpc.Upa.Impl.Config.Annotationparser
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 11/15/12 11:53 AM
     */
    public class AnnotationParserUtils {

        internal static string ValidStr(string c, string oldVal) {
            if (c != null) {
                c = c.Trim();
                if ((c).Length > 0) {
                    return c;
                }
            }
            return oldVal;
        }

        internal static void ValidInt(int c, Net.TheVpc.Upa.Impl.Config.Annotationparser.OverriddenValue<int?> oldVal, int nullVal, int processOrder) {
            if (c != nullVal) {
                oldVal.SetBetterValue(c, processOrder);
            }
        }

        internal static void ValidStr(string c, Net.TheVpc.Upa.Impl.Config.Annotationparser.OverriddenValue<string> oldVal, int processOrder) {
            if (c != null) {
                c = c.Trim();
                if ((c).Length > 0) {
                    oldVal.SetBetterValue(c, processOrder);
                }
            }
        }

        internal static System.Type ValidClass(System.Type c, System.Type oldVal, System.Type type) {
            if (c != null && !c.Equals(typeof(void))) {
                if (type.IsAssignableFrom(c)) {
                    return c;
                } else {
                    throw new System.ArgumentException ("Expected type " + type);
                }
            }
            return oldVal;
        }

        internal static void ValidClass(System.Type c, Net.TheVpc.Upa.Impl.Config.Annotationparser.OverriddenValue<System.Type> oldVal, System.Type type, int processOrder) {
            if (c != null && !c.Equals(typeof(void))) {
                if (type.IsAssignableFrom(c)) {
                    oldVal.SetBetterValue(c, processOrder);
                } else {
                    throw new System.ArgumentException ("Expected type " + type);
                }
            }
        }

        internal static int ParseInt(string s, int def) {
            if (s == null) {
                s = "";
            }
            s = s.Trim();
            if ((s).Length != 0) {
                return System.Convert.ToInt32(s);
            }
            return def;
        }

        internal static System.Numerics.BigInteger? ParseBigInteger(Net.TheVpc.Upa.Impl.Config.Annotationparser.OverriddenValue<string> val, System.Numerics.BigInteger? def) {
            if (val.specified) {
                string s = val.@value;
                if (s == null) {
                    s = "";
                }
                s = s.Trim();
                if ((s).Length != 0) {
                    return Net.TheVpc.Upa.Impl.FwkConvertUtils.CreateBigInteger(s);
                }
            }
            return def;
        }



        internal static int? ParseInt(Net.TheVpc.Upa.Impl.Config.Annotationparser.OverriddenValue<string> val, int? def) {
            if (val.specified) {
                string s = val.@value;
                if (s == null) {
                    s = "";
                }
                s = s.Trim();
                if ((s).Length != 0) {
                    if (char.IsLetter(s[0])) {
                        if ("max".Equals(s,System.StringComparison.InvariantCultureIgnoreCase) || "maximum".Equals(s) || "max_value".Equals(s)) {
                            return System.Int32.MaxValue;
                        }
                        if ("min".Equals(s,System.StringComparison.InvariantCultureIgnoreCase) || "min".Equals(s) || "min_value".Equals(s)) {
                            return System.Int32.MinValue;
                        }
                    }
                    return System.Convert.ToInt32(s);
                }
            }
            return def;
        }

        internal static byte? ParseByte(Net.TheVpc.Upa.Impl.Config.Annotationparser.OverriddenValue<string> val, byte? def) {
            if (val.specified) {
                string s = val.@value;
                if (s == null) {
                    s = "";
                }
                s = s.Trim();
                if ((s).Length != 0) {
                    return System.Convert.ToByte(s);
                }
            }
            return def;
        }

        internal static short? ParseShort(Net.TheVpc.Upa.Impl.Config.Annotationparser.OverriddenValue<string> val, short? def) {
            if (val.specified) {
                string s = val.@value;
                if (s == null) {
                    s = "";
                }
                s = s.Trim();
                if ((s).Length != 0) {
                    if (char.IsLetter(s[0])) {
                        if ("max".Equals(s,System.StringComparison.InvariantCultureIgnoreCase) || "maximum".Equals(s) || "max_value".Equals(s)) {
                            return System.Int16.MaxValue;
                        }
                        if ("min".Equals(s,System.StringComparison.InvariantCultureIgnoreCase) || "min".Equals(s) || "min_value".Equals(s)) {
                            return System.Int16.MinValue;
                        }
                    }
                    return System.Convert.ToInt16(s);
                }
            }
            return def;
        }

        internal static long? ParseLong(Net.TheVpc.Upa.Impl.Config.Annotationparser.OverriddenValue<string> val, long? def) {
            if (val.specified) {
                string s = val.@value;
                if (s == null) {
                    s = "";
                }
                s = s.Trim();
                if ((s).Length != 0) {
                    if (char.IsLetter(s[0])) {
                        if ("max".Equals(s,System.StringComparison.InvariantCultureIgnoreCase) || "maximum".Equals(s) || "max_value".Equals(s)) {
                            return System.Int64.MaxValue;
                        }
                        if ("min".Equals(s,System.StringComparison.InvariantCultureIgnoreCase) || "min".Equals(s) || "min_value".Equals(s)) {
                            return System.Int64.MinValue;
                        }
                    }
                    return System.Convert.ToInt64(s);
                }
            }
            return def;
        }

        internal static double? ParseDouble(Net.TheVpc.Upa.Impl.Config.Annotationparser.OverriddenValue<string> val, double? def) {
            if (val.specified) {
                string s = val.@value;
                if (s == null) {
                    s = "";
                }
                s = s.Trim();
                if ((s).Length != 0) {
                    if (char.IsLetter(s[0])) {
                        if ("max".Equals(s,System.StringComparison.InvariantCultureIgnoreCase) || "maximum".Equals(s) || "max_value".Equals(s)) {
                            return System.Double.MaxValue;
                        }
                        if ("min".Equals(s,System.StringComparison.InvariantCultureIgnoreCase) || "min".Equals(s) || "min_value".Equals(s)) {
                            return System.Double.MinValue;
                        }
                    }
                    return System.Convert.ToDouble(s);
                }
            }
            return def;
        }

        internal static float? ParseFloat(Net.TheVpc.Upa.Impl.Config.Annotationparser.OverriddenValue<string> val, float? def) {
            if (val.specified) {
                string s = val.@value;
                if (s == null) {
                    s = "";
                }
                s = s.Trim();
                if ((s).Length != 0) {
                    if (char.IsLetter(s[0])) {
                        if ("max".Equals(s,System.StringComparison.InvariantCultureIgnoreCase) || "maximum".Equals(s) || "max_value".Equals(s)) {
                            return System.Single.MaxValue;
                        }
                        if ("min".Equals(s,System.StringComparison.InvariantCultureIgnoreCase) || "min".Equals(s) || "min_value".Equals(s)) {
                            return System.Single.MinValue;
                        }
                    }
                    return System.Convert.ToSingle(s);
                }
            }
            return def;
        }

        internal static string CreateDateFormatString(System.Type type1) {
            if (typeof(Net.TheVpc.Upa.Types.Date).Equals(type1)) {
                return "yyyy-MM-dd HH:mm:ss.SSS";
            } else if (typeof(Net.TheVpc.Upa.Types.Date).Equals(type1)) {
                return "yyyy-MM-dd HH:mm:ss.SSS";
            } else if (typeof(Net.TheVpc.Upa.Types.Time).Equals(type1)) {
                return "HH:mm:ss.SSS";
            } else if (typeof(Net.TheVpc.Upa.Types.Time).Equals(type1)) {
                return "HH:mm:ss.SSS";
            } else if (typeof(Net.TheVpc.Upa.Types.DateTime).Equals(type1)) {
                return "yyyy-MM-dd HH:mm:ss.SSS";
            } else if (typeof(Net.TheVpc.Upa.Types.Date).Equals(type1)) {
                return "yyyy-MM-dd";
            } else if (typeof(Net.TheVpc.Upa.Types.Month).Equals(type1)) {
                return "yyyy-MM";
            } else if (typeof(Net.TheVpc.Upa.Types.Year).Equals(type1)) {
                return "yyyy";
            } else if (typeof(Net.TheVpc.Upa.Types.Timestamp).Equals(type1)) {
                return "yyyy-MM-dd HH:mm:ss.SSS";
            } else {
                return "yyyy-MM-dd HH:mm:ss.SSS";
            }
        }

        internal static Net.TheVpc.Upa.Types.Temporal ParseDate(System.Type type1, Net.TheVpc.Upa.Impl.Config.Annotationparser.OverriddenValue<string> @value, Net.TheVpc.Upa.Impl.Config.Annotationparser.OverriddenValue<string> format) /* throws System.Exception */  {
            return ParseDate(type1, @value, format, false);
        }

        internal static Net.TheVpc.Upa.Types.Temporal ParseDate(System.Type type1, Net.TheVpc.Upa.Impl.Config.Annotationparser.OverriddenValue<string> @value, Net.TheVpc.Upa.Impl.Config.Annotationparser.OverriddenValue<string> format, bool end) /* throws System.Exception */  {
            string svalue = @value.specified ? @value.@value : null;
            if (svalue == null) {
                svalue = "";
            }
            svalue = svalue.Trim();
            if ((svalue).Length == 0) {
                return null;
            }
            string sformat = format.specified ? format.@value : null;
            if (sformat == null || (sformat.Trim()).Length == 0) {
                sformat = CreateDateFormatString(type1);
            }
            Net.TheVpc.Upa.Types.Temporal s = Net.TheVpc.Upa.Impl.Util.DateUtils.ParseDateTime(svalue, sformat);
            if (type1.Equals(typeof(Net.TheVpc.Upa.Types.Date))) {
                return new Net.TheVpc.Upa.Types.Date(s.GetTime());
            } else if (type1.Equals(typeof(Net.TheVpc.Upa.Types.Date))) {
                return new Net.TheVpc.Upa.Types.Date(s.GetTime());
            } else if (type1.Equals(typeof(Net.TheVpc.Upa.Types.Time))) {
                return new Net.TheVpc.Upa.Types.Time(s);
            } else if (type1.Equals(typeof(Net.TheVpc.Upa.Types.Time))) {
                return new Net.TheVpc.Upa.Types.Time(s.GetTime());
            } else if (type1.Equals(typeof(Net.TheVpc.Upa.Types.DateTime))) {
                return new Net.TheVpc.Upa.Types.DateTime(s);
            } else if (type1.Equals(typeof(Net.TheVpc.Upa.Types.Timestamp))) {
                return new Net.TheVpc.Upa.Types.Timestamp(s.GetTime());
            } else if (type1.Equals(typeof(Net.TheVpc.Upa.Types.Timestamp))) {
                return new Net.TheVpc.Upa.Types.Timestamp(s.GetTime());
            } else if (type1.Equals(typeof(Net.TheVpc.Upa.Types.Month))) {
                return new Net.TheVpc.Upa.Types.Month(s.GetTime());
            } else if (type1.Equals(typeof(Net.TheVpc.Upa.Types.Year))) {
                return new Net.TheVpc.Upa.Types.Year(s.GetTime());
            } else {
                return s;
            }
        }

        public static object ParseStringValue(string s, Net.TheVpc.Upa.Types.DataType dataType, object defaultValue) /* throws System.Exception */  {
            if (s == null || (s).Length == 0) {
                return defaultValue;
            }
            System.Type c = dataType.GetPlatformType();
            if (typeof(string).Equals(c)) {
                return s;
            } else if (typeof(char?).Equals(c)) {
                return s[0];
            } else if (Net.TheVpc.Upa.Impl.Util.PlatformUtils.IsInt32(c)) {
                return System.Convert.ToInt32(s);
            } else if (Net.TheVpc.Upa.Impl.Util.PlatformUtils.IsInt64(c)) {
                return System.Convert.ToInt64(s);
            } else if (Net.TheVpc.Upa.Impl.Util.PlatformUtils.IsInt16(c)) {
                return System.Convert.ToInt16(s);
            } else if (Net.TheVpc.Upa.Impl.Util.PlatformUtils.IsInt8(c)) {
                return System.Convert.ToByte(s);
            } else if (Net.TheVpc.Upa.Impl.Util.PlatformUtils.IsFloat64(c)) {
                return System.Convert.ToDouble(s);
            } else if (Net.TheVpc.Upa.Impl.Util.PlatformUtils.IsFloat32(c)) {
                return System.Convert.ToSingle(s);
            } else if (Net.TheVpc.Upa.Impl.Util.PlatformUtils.IsBigInt(c)) {
                return Net.TheVpc.Upa.Impl.FwkConvertUtils.CreateBigInteger(s);
            } else if (Net.TheVpc.Upa.Impl.Util.PlatformUtils.IsAnyDate(c)) {
                Net.TheVpc.Upa.Impl.Config.Annotationparser.OverriddenValue<string> vv = new Net.TheVpc.Upa.Impl.Config.Annotationparser.OverriddenValue<string>();
                vv.SetValue(s);
                return ParseDate(c, vv, new Net.TheVpc.Upa.Impl.Config.Annotationparser.OverriddenValue<string>(), false);
            } else if (Net.TheVpc.Upa.Impl.Util.PlatformUtils.IsBool(c)) {
                return System.Convert.ToBoolean(s);
            }
            return null;
        }

        public static bool IsEmptyString(string s) {
            return s == null || (s.Trim()).Length == 0;
        }
    }
}
