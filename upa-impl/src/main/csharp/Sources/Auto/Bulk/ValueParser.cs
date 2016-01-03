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



namespace Net.Vpc.Upa.Impl.Bulk
{


    /**
     *
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public class ValueParser {

        public static object Parse(object @value, Net.Vpc.Upa.Types.DataType type) {
            if (type.GetPlatformType().IsInstanceOfType(@value)) {
                type.Check(@value, null, null);
                return @value;
            }
            if (type is Net.Vpc.Upa.Types.StringType) {
                Net.Vpc.Upa.Types.StringType t = (Net.Vpc.Upa.Types.StringType) type;
                if (@value != null) {
                    @value = System.Convert.ToString(@value);
                }
                t.Check(@value, null, null);
                return @value;
            }
            if (type is Net.Vpc.Upa.Types.EnumType) {
                Net.Vpc.Upa.Types.EnumType t = (Net.Vpc.Upa.Types.EnumType) type;
                if (@value != null) {
                    @value = System.Enum.Parse(t.GetPlatformType(),System.Convert.ToString(@value));
                }
                t.Check(@value, null, null);
                return @value;
            }
            if (type is Net.Vpc.Upa.Types.IntType) {
                Net.Vpc.Upa.Types.IntType t = (Net.Vpc.Upa.Types.IntType) type;
                if (@value != null) {
                    if (!(@value is int?)) {
                        if (@value is string) {
                            @value = System.Convert.ToInt32(System.Convert.ToString(@value).Trim());
                        } else if (typeof(object).IsAssignableFrom(@value.GetType())) {
                            @value = (System.Convert.ToInt32(((object) (@value))));
                        } else {
                            throw new System.ArgumentException ("Unsupported Convertion from " + @value.GetType() + " to " + type);
                        }
                    }
                }
                t.Check(@value, null, null);
                return @value;
            }
            if (type is Net.Vpc.Upa.Types.LongType) {
                Net.Vpc.Upa.Types.LongType t = (Net.Vpc.Upa.Types.LongType) type;
                if (@value != null) {
                    if (!(@value is long?)) {
                        if (@value is string) {
                            @value = System.Convert.ToInt64(System.Convert.ToString(@value).Trim());
                        } else if (typeof(object).IsAssignableFrom(@value.GetType())) {
                            @value = (System.Convert.ToInt32(((object) (@value))));
                        } else {
                            throw new System.ArgumentException ("Unsupported Convertion from " + @value.GetType() + " to " + type);
                        }
                    }
                }
                t.Check(@value, null, null);
                return @value;
            }
            if (type is Net.Vpc.Upa.Types.ShortType) {
                Net.Vpc.Upa.Types.ShortType t = (Net.Vpc.Upa.Types.ShortType) type;
                if (@value != null) {
                    if (!(@value is short?)) {
                        if (@value is string) {
                            @value = System.Convert.ToInt16(System.Convert.ToString(@value).Trim());
                        } else if (typeof(object).IsAssignableFrom(@value.GetType())) {
                            @value = (System.Convert.ToInt16(((object) (@value))));
                        } else {
                            throw new System.ArgumentException ("Unsupported Convertion from " + @value.GetType() + " to " + type);
                        }
                    }
                }
                t.Check(@value, null, null);
                return @value;
            }
            if (type is Net.Vpc.Upa.Types.ByteType) {
                Net.Vpc.Upa.Types.ByteType t = (Net.Vpc.Upa.Types.ByteType) type;
                if (@value != null) {
                    if (!(@value is byte?)) {
                        if (@value is string) {
                            @value = System.Convert.ToByte(System.Convert.ToString(@value).Trim());
                        } else if (typeof(object).IsAssignableFrom(@value.GetType())) {
                            @value = (System.Convert.ToByte(((object) (@value))));
                        } else {
                            throw new System.ArgumentException ("Unsupported Convertion from " + @value.GetType() + " to " + type);
                        }
                    }
                }
                t.Check(@value, null, null);
                return @value;
            }
            if (type is Net.Vpc.Upa.Types.FloatType) {
                Net.Vpc.Upa.Types.FloatType t = (Net.Vpc.Upa.Types.FloatType) type;
                if (@value != null) {
                    if (!(@value is float?)) {
                        if (@value is string) {
                            @value = System.Convert.ToSingle(System.Convert.ToString(@value).Trim());
                        } else if (typeof(object).IsAssignableFrom(@value.GetType())) {
                            @value = (System.Convert.ToSingle(((object) (@value))));
                        } else {
                            throw new System.ArgumentException ("Unsupported Convertion from " + @value.GetType() + " to " + type);
                        }
                    }
                }
                t.Check(@value, null, null);
                return @value;
            }
            if (type is Net.Vpc.Upa.Types.DoubleType) {
                Net.Vpc.Upa.Types.DoubleType t = (Net.Vpc.Upa.Types.DoubleType) type;
                if (@value != null) {
                    if (!(@value is double?)) {
                        if (@value is string) {
                            @value = System.Convert.ToDouble(System.Convert.ToString(@value).Trim());
                        } else if (typeof(object).IsAssignableFrom(@value.GetType())) {
                            @value = (System.Convert.ToSingle(((object) (@value))));
                        } else {
                            throw new System.ArgumentException ("Unsupported Convertion from " + @value.GetType() + " to " + type);
                        }
                    }
                }
                t.Check(@value, null, null);
                return @value;
            }
            if (type is Net.Vpc.Upa.Types.TemporalType) {
                Net.Vpc.Upa.Types.TemporalType t = (Net.Vpc.Upa.Types.TemporalType) type;
                if (@value != null) {
                    if (!(@value is Net.Vpc.Upa.Types.Temporal)) {
                        if (@value is string) {
                            if (t is Net.Vpc.Upa.Types.DateType) {
                                @value = Net.Vpc.Upa.Impl.Util.DateUtils.ParseUniversalDate(System.Convert.ToString(@value).Trim());
                            } else if (t is Net.Vpc.Upa.Types.DateTimeType) {
                                @value = Net.Vpc.Upa.Impl.Util.DateUtils.ParseUniversalDateTime(System.Convert.ToString(@value).Trim());
                            } else if (t is Net.Vpc.Upa.Types.TimeType) {
                                @value = Net.Vpc.Upa.Impl.Util.DateUtils.ParseUniversalTime(System.Convert.ToString(@value).Trim());
                            } else if (t is Net.Vpc.Upa.Types.TimestampType) {
                                @value = Net.Vpc.Upa.Impl.Util.DateUtils.ParseUniversalTimestamp(System.Convert.ToString(@value).Trim());
                            } else if (t is Net.Vpc.Upa.Types.YearType) {
                                @value = Net.Vpc.Upa.Impl.Util.DateUtils.ParseUniversalYear(System.Convert.ToString(@value).Trim());
                            } else if (t is Net.Vpc.Upa.Types.MonthType) {
                                @value = Net.Vpc.Upa.Impl.Util.DateUtils.ParseUniversalMonth(System.Convert.ToString(@value).Trim());
                            } else {
                                throw new System.ArgumentException ("Unsupported Convertion from " + @value.GetType() + " to " + type);
                            }
                            @value = type.Convert(@value);
                        } else {
                            throw new System.ArgumentException ("Unsupported Convertion from " + @value.GetType() + " to " + type);
                        }
                    } else {
                        @value = t.Convert(@value);
                    }
                }
                t.Check(@value, null, null);
                return @value;
            }
            if (type is Net.Vpc.Upa.Types.BooleanType) {
                Net.Vpc.Upa.Types.BooleanType t = (Net.Vpc.Upa.Types.BooleanType) type;
                if (@value != null) {
                    if (!(@value is bool?)) {
                        if (@value is string) {
                            @value = System.Convert.ToBoolean(System.Convert.ToString(@value).Trim());
                        } else if (@value is object) {
                            @value = System.Convert.ToDouble(((object) @value)) != 0;
                        } else {
                            throw new System.ArgumentException ("Unsupported Convertion from " + @value.GetType() + " to " + type);
                        }
                    } else {
                        @value = t.Convert(@value);
                    }
                }
                t.Check(@value, null, null);
                return @value;
            }
            throw new System.ArgumentException ("UnsupportedType from " + (@value == null ? "null" : (@value.GetType()).FullName) + " to " + type);
        }
    }
}
