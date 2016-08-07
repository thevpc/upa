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
namespace Net.Vpc.Upa.Impl.Config.Annotationparser
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 11/15/12 11:50 AM
     */
    internal class FieldInfo : Net.Vpc.Upa.FieldDescriptor {

        protected internal static System.Diagnostics.TraceSource log = new System.Diagnostics.TraceSource((typeof(Net.Vpc.Upa.Impl.Config.Annotationparser.FieldInfo)).FullName);

        private System.Collections.Generic.IComparer<System.Reflection.FieldInfo> FIELD_COMPARATOR;

        internal string name;

        internal System.Collections.Generic.IList<System.Reflection.FieldInfo> fields = new System.Collections.Generic.List<System.Reflection.FieldInfo>();

        internal Net.Vpc.Upa.Impl.Config.Annotationparser.RelationshipInfo foreignInfo;

        internal Net.Vpc.Upa.Impl.Config.Annotationparser.EntityInfo entityInfo = null;

        internal string fieldPath = null;

        internal object defaultObject = null;

        internal object unspecifiedObject = null;

        internal Net.Vpc.Upa.Impl.Config.Annotationparser.AnyFormulaInfo anyFormula;

        internal Net.Vpc.Upa.Types.DataType type;

        internal Net.Vpc.Upa.Formula persistFormula;

        internal Net.Vpc.Upa.Formula updateFormula;

        internal Net.Vpc.Upa.Formula selectFormula;

        internal int persistFormulaOrder;

        internal int updateFormulaOrder;

        internal int selectFormulaOrder;

        internal Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.UserFieldModifier> modifiers;

        internal Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.UserFieldModifier> excludeModifiers;

        internal Net.Vpc.Upa.AccessLevel persistAccessLevel;

        internal Net.Vpc.Upa.AccessLevel updateAccessLevel;

        internal Net.Vpc.Upa.AccessLevel readAccessLevel;

        internal bool valid = true;

        internal bool buildForeign = false;

        internal Net.Vpc.Upa.Impl.Config.Annotationparser.OverriddenValue<Net.Vpc.Upa.Types.DataType> overriddenDataType = new Net.Vpc.Upa.Impl.Config.Annotationparser.OverriddenValue<Net.Vpc.Upa.Types.DataType>();

        internal Net.Vpc.Upa.Impl.Config.Annotationparser.OverriddenValue<Net.Vpc.Upa.Types.DataTypeTransformConfig[]> overriddenTransform = new Net.Vpc.Upa.Impl.Config.Annotationparser.OverriddenValue<Net.Vpc.Upa.Types.DataTypeTransformConfig[]>();

        internal Net.Vpc.Upa.Impl.Config.Annotationparser.OverriddenValue<Net.Vpc.Upa.SearchOperator> overriddenSearchOperator = new Net.Vpc.Upa.Impl.Config.Annotationparser.OverriddenValue<Net.Vpc.Upa.SearchOperator>();

        internal Net.Vpc.Upa.Impl.Config.Annotationparser.OverriddenValue<object> overriddenDefaultValue = new Net.Vpc.Upa.Impl.Config.Annotationparser.OverriddenValue<object>();

        internal Net.Vpc.Upa.Impl.Config.Annotationparser.OverriddenValue<string> overriddenDefaultValueStr = new Net.Vpc.Upa.Impl.Config.Annotationparser.OverriddenValue<string>();

        internal Net.Vpc.Upa.Impl.Config.Annotationparser.OverriddenValue<object> overriddenUnspecifiedValue = new Net.Vpc.Upa.Impl.Config.Annotationparser.OverriddenValue<object>();

        internal Net.Vpc.Upa.Impl.Config.Annotationparser.OverriddenValue<string> overriddenUnspecifiedValueStr = new Net.Vpc.Upa.Impl.Config.Annotationparser.OverriddenValue<string>();

        internal Net.Vpc.Upa.Impl.Config.Annotationparser.OverriddenValue<Net.Vpc.Upa.Formula> overriddenPersistFormula = new Net.Vpc.Upa.Impl.Config.Annotationparser.OverriddenValue<Net.Vpc.Upa.Formula>();

        internal Net.Vpc.Upa.Impl.Config.Annotationparser.OverriddenValue<Net.Vpc.Upa.Formula> overriddenUpdateFormula = new Net.Vpc.Upa.Impl.Config.Annotationparser.OverriddenValue<Net.Vpc.Upa.Formula>();

        internal Net.Vpc.Upa.Impl.Config.Annotationparser.OverriddenValue<System.Type> overriddenNativeType = new Net.Vpc.Upa.Impl.Config.Annotationparser.OverriddenValue<System.Type>();

        internal Net.Vpc.Upa.Impl.Config.Annotationparser.OverriddenValue<string> overriddenMinValue = new Net.Vpc.Upa.Impl.Config.Annotationparser.OverriddenValue<string>();

        internal Net.Vpc.Upa.Impl.Config.Annotationparser.OverriddenValue<string> overriddenMaxValue = new Net.Vpc.Upa.Impl.Config.Annotationparser.OverriddenValue<string>();

        internal Net.Vpc.Upa.Impl.Config.Annotationparser.OverriddenValue<string> overriddenLayout = new Net.Vpc.Upa.Impl.Config.Annotationparser.OverriddenValue<string>();

        internal Net.Vpc.Upa.Impl.Config.Annotationparser.OverriddenValue<int?> overriddenScale = new Net.Vpc.Upa.Impl.Config.Annotationparser.OverriddenValue<int?>();

        internal Net.Vpc.Upa.Impl.Config.Annotationparser.OverriddenValue<int?> overriddenPrec = new Net.Vpc.Upa.Impl.Config.Annotationparser.OverriddenValue<int?>();

        internal Net.Vpc.Upa.Impl.Config.Annotationparser.OverriddenValue<Net.Vpc.Upa.Config.BoolEnum> overriddenNullable = new Net.Vpc.Upa.Impl.Config.Annotationparser.OverriddenValue<Net.Vpc.Upa.Config.BoolEnum>();

        internal Net.Vpc.Upa.Impl.Config.Annotationparser.OverriddenValue<int?> overriddenPosition = new Net.Vpc.Upa.Impl.Config.Annotationparser.OverriddenValue<int?>();

        internal Net.Vpc.Upa.Impl.Config.Annotationparser.OverriddenValue<string> overriddenCharsAccepted = new Net.Vpc.Upa.Impl.Config.Annotationparser.OverriddenValue<string>();

        internal Net.Vpc.Upa.Impl.Config.Annotationparser.OverriddenValue<string> overriddenCharsRejected = new Net.Vpc.Upa.Impl.Config.Annotationparser.OverriddenValue<string>();

        internal Net.Vpc.Upa.Impl.Config.Annotationparser.OverriddenValue<string> overriddenFormat = new Net.Vpc.Upa.Impl.Config.Annotationparser.OverriddenValue<string>();

        internal Net.Vpc.Upa.Impl.Config.Annotationparser.OverriddenValue<string> overriddenPath = new Net.Vpc.Upa.Impl.Config.Annotationparser.OverriddenValue<string>();

        internal Net.Vpc.Upa.Impl.Config.Annotationparser.OverriddenValue<Net.Vpc.Upa.PropertyAccessType> overriddenPropertyAccessType = new Net.Vpc.Upa.Impl.Config.Annotationparser.OverriddenValue<Net.Vpc.Upa.PropertyAccessType>();

        internal Net.Vpc.Upa.Impl.Config.Annotationparser.OverriddenValue<Net.Vpc.Upa.Types.TemporalOption> overriddenTemporal = new Net.Vpc.Upa.Impl.Config.Annotationparser.OverriddenValue<Net.Vpc.Upa.Types.TemporalOption>();

        internal Net.Vpc.Upa.Impl.Config.Annotationparser.OverriddenValue<Net.Vpc.Upa.AccessLevel> overriddenPersistAccessLevel = new Net.Vpc.Upa.Impl.Config.Annotationparser.OverriddenValue<Net.Vpc.Upa.AccessLevel>();

        internal Net.Vpc.Upa.Impl.Config.Annotationparser.OverriddenValue<Net.Vpc.Upa.AccessLevel> overriddenUpdateAccessLevel = new Net.Vpc.Upa.Impl.Config.Annotationparser.OverriddenValue<Net.Vpc.Upa.AccessLevel>();

        internal Net.Vpc.Upa.Impl.Config.Annotationparser.OverriddenValue<Net.Vpc.Upa.AccessLevel> overriddenRemoveAccessLevel = new Net.Vpc.Upa.Impl.Config.Annotationparser.OverriddenValue<Net.Vpc.Upa.AccessLevel>();

        internal Net.Vpc.Upa.Impl.Config.Annotationparser.OverriddenValue<Net.Vpc.Upa.AccessLevel> overriddenReadAccessLevel = new Net.Vpc.Upa.Impl.Config.Annotationparser.OverriddenValue<Net.Vpc.Upa.AccessLevel>();

        internal System.Collections.Generic.IList<Net.Vpc.Upa.Property> parameterInfos = new System.Collections.Generic.List<Net.Vpc.Upa.Property>();

        private System.Type nativeClass;

        internal bool nullableOk = true;

        internal Net.Vpc.Upa.Impl.Config.Decorations.DecorationRepository repo;

        private System.Collections.Generic.IDictionary<string , object> fieldParams = new System.Collections.Generic.Dictionary<string , object>();

        internal FieldInfo(string name, Net.Vpc.Upa.Impl.Config.Annotationparser.EntityInfo entityInfo, Net.Vpc.Upa.Impl.Config.Decorations.DecorationRepository repo) {
            this.name = name;
            this.entityInfo = entityInfo;
            this.repo = repo;
            foreignInfo = new Net.Vpc.Upa.Impl.Config.Annotationparser.RelationshipInfo(this, repo);
            anyFormula = new Net.Vpc.Upa.Impl.Config.Annotationparser.AnyFormulaInfo(repo);
            FIELD_COMPARATOR = new Net.Vpc.Upa.Impl.Config.Annotationparser.FieldComparator(repo);
        }

        public virtual System.Collections.Generic.IDictionary<string , object> GetFieldParams() {
            return fieldParams;
        }

        public virtual void PrepareFieldDesc(System.Collections.Generic.IDictionary<string , object> ctx, string entityName, System.Reflection.FieldInfo javaField) /* throws Net.Vpc.Upa.Exceptions.UPAException, System.Exception, System.Exception, System.Exception */  {
            try {
                //javaField.SetAccessible(true);
                Net.Vpc.Upa.Config.FieldDesc fieldDesc = null;
                if (Net.Vpc.Upa.Impl.Util.PlatformUtils.IsStatic(javaField)) {
                    fieldDesc = (Net.Vpc.Upa.Config.FieldDesc) javaField.GetValue(null);
                } else {
                    object fieldDescContainerInstance = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,object>(ctx,"FieldDescContainerInstance." + ((javaField).DeclaringType).FullName);
                    if (fieldDescContainerInstance == null) {
                        try {
                            fieldDescContainerInstance = System.Activator.CreateInstance(((javaField).DeclaringType));
                        } catch (System.Exception e) {
                            throw new System.ArgumentException ("IllegalArgumentException", e);
                        }
                        ctx["FieldDescContainerInstance" + ((javaField).DeclaringType).FullName]=fieldDescContainerInstance;
                    }
                    //pbm
                    try {
                        fieldDesc = (Net.Vpc.Upa.Config.FieldDesc) javaField.GetValue(fieldDescContainerInstance);
                    } catch (System.Exception e) {
                        throw new System.ArgumentException ("IllegalArgumentException", e);
                    }
                }
                if (fieldDesc != null) {
                    int processOrder = fieldDesc.GetConfigOrder();
                    if (fieldDesc.IsDefaultValueSet()) {
                        overriddenDefaultValue.SetBetterValue(fieldDesc.GetDefaultValue(), processOrder);
                    }
                    if (fieldDesc.IsUnspecifiedValueSet()) {
                        overriddenUnspecifiedValue.SetBetterValue(fieldDesc.GetUnspecifiedValue(), processOrder);
                    }
                    //                                Object n = dd.getFieldUnitName();
                    //                                if (n != null) {
                    //                                    fieldUnitName = (n);
                    //                                }
                    Net.Vpc.Upa.Types.DataType type = fieldDesc.GetDataType();
                    if (type != null) {
                        overriddenDataType.SetBetterValue(type, processOrder);
                    }
                    Net.Vpc.Upa.Formula _formula = fieldDesc.GetPersistFormula();
                    if (_formula != null) {
                        overriddenPersistFormula.SetBetterValue(_formula, processOrder);
                    }
                    _formula = fieldDesc.GetUpdateFormula();
                    if (_formula != null) {
                        overriddenUpdateFormula.SetBetterValue(_formula, processOrder);
                    }
                    if (fieldDesc.GetModifiers() != null) {
                        modifiers.AddAll(fieldDesc.GetModifiers());
                    }
                    if (fieldDesc.GetExcludeModifiers() != null) {
                        excludeModifiers.AddAll(fieldDesc.GetExcludeModifiers());
                    }
                    if (fieldDesc.IsUnspecifiedValueSet()) {
                        overriddenUnspecifiedValue.SetBetterValue(fieldDesc.GetUnspecifiedValue(), processOrder);
                    }
                }
            } catch (System.Exception e) {
                throw new System.ArgumentException ("IllegalArgumentException", e);
            }
        }

        public virtual void PrepareBaseDataType(System.Collections.Generic.IDictionary<string , object> ctx, string entityName) /* throws Net.Vpc.Upa.Exceptions.UPAException, System.Exception, System.Exception, System.Exception */  {
            bool fieldTypeProcessed = false;
            string absoluteName = name;
            if ((nativeClass).IsEnum) {
                overriddenDataType.SetValue(new Net.Vpc.Upa.Types.EnumType(nativeClass, nullableOk));
                fieldTypeProcessed = true;
            } else if (nativeClass.Equals(typeof(string))) {
                fieldTypeProcessed = true;
                int minInt = (Net.Vpc.Upa.Impl.Config.Annotationparser.AnnotationParserUtils.ParseInt(overriddenMinValue, 0)).Value;
                int maxInt = (Net.Vpc.Upa.Impl.Config.Annotationparser.AnnotationParserUtils.ParseInt(overriddenMaxValue, 255)).Value;
                string charsAcceptedOk = (overriddenCharsAccepted.specified && !System.Collections.Generic.EqualityComparer<string>.Default.Equals(overriddenCharsAccepted.@value,null) && (overriddenCharsAccepted.@value).Length > 0) ? overriddenCharsAccepted.@value : null;
                string charsRejectedOk = (overriddenCharsRejected.specified && !System.Collections.Generic.EqualityComparer<string>.Default.Equals(overriddenCharsRejected.@value,null) && (overriddenCharsRejected.@value).Length > 0) ? overriddenCharsRejected.@value : null;
                Net.Vpc.Upa.Types.StringType s = new Net.Vpc.Upa.Types.StringType(name, minInt, maxInt, nullableOk);
                if (charsAcceptedOk != null) {
                    s.AddValueValidator(new Net.Vpc.Upa.Types.StringTypeCharValidator(charsAcceptedOk, true));
                }
                if (charsRejectedOk != null) {
                    s.AddValueValidator(new Net.Vpc.Upa.Types.StringTypeCharValidator(charsRejectedOk, false));
                }
                overriddenDataType.SetValue(s);
            } else if (Net.Vpc.Upa.Impl.Util.PlatformUtils.IsInt32(nativeClass)) {
                fieldTypeProcessed = true;
                int? min = Net.Vpc.Upa.Impl.Config.Annotationparser.AnnotationParserUtils.ParseInt(overriddenMinValue, null);
                int? max = Net.Vpc.Upa.Impl.Config.Annotationparser.AnnotationParserUtils.ParseInt(overriddenMaxValue, null);
                overriddenDataType.SetValue(new Net.Vpc.Upa.Types.IntType(absoluteName, min, max, nullableOk, Net.Vpc.Upa.Impl.Util.PlatformUtils.IsPrimitiveType(nativeClass)));
            } else if (Net.Vpc.Upa.Impl.Util.PlatformUtils.IsInt8(nativeClass)) {
                fieldTypeProcessed = true;
                byte? min = Net.Vpc.Upa.Impl.Config.Annotationparser.AnnotationParserUtils.ParseByte(overriddenMinValue, null);
                byte? max = Net.Vpc.Upa.Impl.Config.Annotationparser.AnnotationParserUtils.ParseByte(overriddenMaxValue, null);
                overriddenDataType.SetValue(new Net.Vpc.Upa.Types.ByteType(absoluteName, min, max, nullableOk, Net.Vpc.Upa.Impl.Util.PlatformUtils.IsPrimitiveType(nativeClass)));
            } else if (Net.Vpc.Upa.Impl.Util.PlatformUtils.IsInt16(nativeClass)) {
                fieldTypeProcessed = true;
                short? min = Net.Vpc.Upa.Impl.Config.Annotationparser.AnnotationParserUtils.ParseShort(overriddenMinValue, null);
                short? max = Net.Vpc.Upa.Impl.Config.Annotationparser.AnnotationParserUtils.ParseShort(overriddenMaxValue, null);
                overriddenDataType.SetValue(new Net.Vpc.Upa.Types.ShortType(absoluteName, min, max, nullableOk, Net.Vpc.Upa.Impl.Util.PlatformUtils.IsPrimitiveType(nativeClass)));
            } else if (Net.Vpc.Upa.Impl.Util.PlatformUtils.IsInt64(nativeClass)) {
                fieldTypeProcessed = true;
                long? min = Net.Vpc.Upa.Impl.Config.Annotationparser.AnnotationParserUtils.ParseLong(overriddenMinValue, null);
                long? max = Net.Vpc.Upa.Impl.Config.Annotationparser.AnnotationParserUtils.ParseLong(overriddenMaxValue, null);
                overriddenDataType.SetValue(new Net.Vpc.Upa.Types.LongType(absoluteName, min, max, nullableOk, Net.Vpc.Upa.Impl.Util.PlatformUtils.IsPrimitiveType(nativeClass)));
            } else if (Net.Vpc.Upa.Impl.Util.PlatformUtils.IsFloat32(nativeClass)) {
                fieldTypeProcessed = true;
                float? min = Net.Vpc.Upa.Impl.Config.Annotationparser.AnnotationParserUtils.ParseFloat(overriddenMinValue, null);
                float? max = Net.Vpc.Upa.Impl.Config.Annotationparser.AnnotationParserUtils.ParseFloat(overriddenMaxValue, null);
                int precOk = System.Int32.MaxValue;
                if (overriddenPrec.specified && (overriddenPrec.@value).Value > 0) {
                    precOk = (overriddenPrec.@value).Value;
                }
                int scaleOk = System.Int32.MaxValue;
                if (overriddenScale.specified && (overriddenScale.@value).Value > 0) {
                    scaleOk = (overriddenScale.@value).Value;
                }
                overriddenDataType.SetValue(new Net.Vpc.Upa.Types.FloatType(absoluteName, min, max, scaleOk, precOk, nullableOk, Net.Vpc.Upa.Impl.Util.PlatformUtils.IsPrimitiveType(nativeClass)));
            } else if (Net.Vpc.Upa.Impl.Util.PlatformUtils.IsFloat64(nativeClass)) {
                fieldTypeProcessed = true;
                double? min = Net.Vpc.Upa.Impl.Config.Annotationparser.AnnotationParserUtils.ParseDouble(overriddenMinValue, null);
                double? max = Net.Vpc.Upa.Impl.Config.Annotationparser.AnnotationParserUtils.ParseDouble(overriddenMaxValue, null);
                int precOk = System.Int32.MaxValue;
                if (overriddenPrec.specified && (overriddenPrec.@value).Value > 0) {
                    precOk = (overriddenPrec.@value).Value;
                }
                int scaleOk = System.Int32.MaxValue;
                if (overriddenScale.specified && (overriddenScale.@value).Value > 0) {
                    scaleOk = (overriddenScale.@value).Value;
                }
                overriddenDataType.SetValue(new Net.Vpc.Upa.Types.DoubleType(absoluteName, min, max, scaleOk, precOk, nullableOk, Net.Vpc.Upa.Impl.Util.PlatformUtils.IsPrimitiveType(nativeClass)));
            } else if (Net.Vpc.Upa.Impl.Util.PlatformUtils.IsAnyDate(nativeClass)) {
                fieldTypeProcessed = true;
                System.Type asType = nativeClass;
                if (overriddenTemporal.specified) {
                    asType = Net.Vpc.Upa.Impl.Util.PlatformUtils.ToTemporalType(overriddenTemporal.@value, asType);
                }
                if (typeof(Net.Vpc.Upa.Types.Year).IsAssignableFrom(asType)) {
                    try {
                        overriddenDataType.SetValue(new Net.Vpc.Upa.Types.YearType(absoluteName, nativeClass, (Net.Vpc.Upa.Types.Year) Net.Vpc.Upa.Impl.Config.Annotationparser.AnnotationParserUtils.ParseDate(typeof(Net.Vpc.Upa.Types.Year), overriddenMinValue, overriddenFormat), (Net.Vpc.Upa.Types.Year) Net.Vpc.Upa.Impl.Config.Annotationparser.AnnotationParserUtils.ParseDate(typeof(Net.Vpc.Upa.Types.Year), overriddenMaxValue, overriddenFormat), nullableOk));
                    } catch (System.Exception e) {
                        throw new System.ArgumentException ("IllegalArgumentException", e);
                    }
                } else if (typeof(Net.Vpc.Upa.Types.Month).IsAssignableFrom(asType)) {
                    try {
                        overriddenDataType.SetValue(new Net.Vpc.Upa.Types.MonthType(absoluteName, nativeClass, (Net.Vpc.Upa.Types.Month) Net.Vpc.Upa.Impl.Config.Annotationparser.AnnotationParserUtils.ParseDate(typeof(Net.Vpc.Upa.Types.Month), overriddenMinValue, overriddenFormat), (Net.Vpc.Upa.Types.Month) Net.Vpc.Upa.Impl.Config.Annotationparser.AnnotationParserUtils.ParseDate(typeof(Net.Vpc.Upa.Types.Month), overriddenMaxValue, overriddenFormat), nullableOk));
                    } catch (System.Exception e) {
                        throw new System.ArgumentException ("IllegalArgumentException", e);
                    }
                } else if (typeof(Net.Vpc.Upa.Types.Date).IsAssignableFrom(asType)) {
                    try {
                        overriddenDataType.SetValue(new Net.Vpc.Upa.Types.DateType(absoluteName, nativeClass, (Net.Vpc.Upa.Types.Date) Net.Vpc.Upa.Impl.Config.Annotationparser.AnnotationParserUtils.ParseDate(typeof(Net.Vpc.Upa.Types.Date), overriddenMinValue, overriddenFormat), (Net.Vpc.Upa.Types.Date) Net.Vpc.Upa.Impl.Config.Annotationparser.AnnotationParserUtils.ParseDate(typeof(Net.Vpc.Upa.Types.Date), overriddenMaxValue, overriddenFormat), nullableOk));
                    } catch (System.Exception e) {
                        throw new System.ArgumentException ("IllegalArgumentException", e);
                    }
                } else if (typeof(Net.Vpc.Upa.Types.DateTime).IsAssignableFrom(asType)) {
                    try {
                        overriddenDataType.SetValue(new Net.Vpc.Upa.Types.DateTimeType(absoluteName, nativeClass, (Net.Vpc.Upa.Types.DateTime) Net.Vpc.Upa.Impl.Config.Annotationparser.AnnotationParserUtils.ParseDate(typeof(Net.Vpc.Upa.Types.DateTime), overriddenMinValue, overriddenFormat), (Net.Vpc.Upa.Types.DateTime) Net.Vpc.Upa.Impl.Config.Annotationparser.AnnotationParserUtils.ParseDate(typeof(Net.Vpc.Upa.Types.DateTime), overriddenMaxValue, overriddenFormat), nullableOk));
                    } catch (System.Exception e) {
                        throw new System.ArgumentException ("IllegalArgumentException", e);
                    }
                } else if (typeof(Net.Vpc.Upa.Types.Timestamp).IsAssignableFrom(asType) || typeof(Net.Vpc.Upa.Types.Timestamp).IsAssignableFrom(asType)) {
                    try {
                        overriddenDataType.SetValue(new Net.Vpc.Upa.Types.TimestampType(absoluteName, nativeClass, (Net.Vpc.Upa.Types.Timestamp) Net.Vpc.Upa.Impl.Config.Annotationparser.AnnotationParserUtils.ParseDate(typeof(Net.Vpc.Upa.Types.Timestamp), overriddenMinValue, overriddenFormat), (Net.Vpc.Upa.Types.Timestamp) Net.Vpc.Upa.Impl.Config.Annotationparser.AnnotationParserUtils.ParseDate(typeof(Net.Vpc.Upa.Types.Timestamp), overriddenMaxValue, overriddenFormat), nullableOk));
                    } catch (System.Exception e) {
                        throw new System.ArgumentException ("IllegalArgumentException", e);
                    }
                } else if (typeof(Net.Vpc.Upa.Types.Time).IsAssignableFrom(asType)) {
                    try {
                        overriddenDataType.SetValue(new Net.Vpc.Upa.Types.TimeType(absoluteName, nativeClass, (Net.Vpc.Upa.Types.Time) Net.Vpc.Upa.Impl.Config.Annotationparser.AnnotationParserUtils.ParseDate(typeof(Net.Vpc.Upa.Types.Time), overriddenMinValue, overriddenFormat), (Net.Vpc.Upa.Types.Time) Net.Vpc.Upa.Impl.Config.Annotationparser.AnnotationParserUtils.ParseDate(typeof(Net.Vpc.Upa.Types.Time), overriddenMaxValue, overriddenFormat), nullableOk));
                    } catch (System.Exception e) {
                        throw new System.ArgumentException ("IllegalArgumentException", e);
                    }
                } else if (typeof(Net.Vpc.Upa.Types.Date).IsAssignableFrom(asType)) {
                    try {
                        overriddenDataType.SetValue(new Net.Vpc.Upa.Types.DateType(absoluteName, nativeClass, (Net.Vpc.Upa.Types.Date) Net.Vpc.Upa.Impl.Config.Annotationparser.AnnotationParserUtils.ParseDate(typeof(Net.Vpc.Upa.Types.Date), overriddenMinValue, overriddenFormat), (Net.Vpc.Upa.Types.Date) Net.Vpc.Upa.Impl.Config.Annotationparser.AnnotationParserUtils.ParseDate(typeof(Net.Vpc.Upa.Types.Date), overriddenMaxValue, overriddenFormat), nullableOk));
                    } catch (System.Exception e) {
                        throw new System.ArgumentException ("IllegalArgumentException", e);
                    }
                } else {
                    try {
                        overriddenDataType.SetValue(new Net.Vpc.Upa.Types.DateTimeType(absoluteName, nativeClass, (Net.Vpc.Upa.Types.DateTime) Net.Vpc.Upa.Impl.Config.Annotationparser.AnnotationParserUtils.ParseDate(typeof(Net.Vpc.Upa.Types.DateTime), overriddenMinValue, overriddenFormat), (Net.Vpc.Upa.Types.DateTime) Net.Vpc.Upa.Impl.Config.Annotationparser.AnnotationParserUtils.ParseDate(typeof(Net.Vpc.Upa.Types.DateTime), overriddenMaxValue, overriddenFormat), nullableOk));
                    } catch (System.Exception e) {
                        throw new System.ArgumentException ("IllegalArgumentException", e);
                    }
                }
            } else if (typeof(bool).Equals(nativeClass)) {
                fieldTypeProcessed = true;
                overriddenDataType.SetValue(new Net.Vpc.Upa.Types.BooleanType(absoluteName, nullableOk, true));
            } else if (typeof(bool?).Equals(nativeClass)) {
                fieldTypeProcessed = true;
                overriddenDataType.SetValue(new Net.Vpc.Upa.Types.BooleanType(absoluteName, nullableOk, false));
            } else if (typeof(Net.Vpc.Upa.Types.FileData).Equals(nativeClass)) {
                fieldTypeProcessed = true;
                System.Collections.Generic.List<string> extensions = new System.Collections.Generic.List<string>();
                if (overriddenFormat.specified && !System.Collections.Generic.EqualityComparer<string>.Default.Equals(overriddenFormat.@value,null) && (overriddenFormat.@value).Length > 0) {
                    foreach (string ext in System.Text.RegularExpressions.Regex.Split(overriddenFormat.@value,";")) {
                        extensions.Add(ext.Trim());
                    }
                }
                overriddenDataType.SetValue(new Net.Vpc.Upa.Types.FileType(absoluteName, Net.Vpc.Upa.Impl.Config.Annotationparser.AnnotationParserUtils.ParseInt(overriddenMaxValue, System.Int32.MaxValue), (extensions.Count==0) ? null : extensions.ToArray(), nullableOk));
            } else if (typeof(byte[]).Equals(nativeClass)) {
                fieldTypeProcessed = true;
                overriddenDataType.SetValue(new Net.Vpc.Upa.Types.ByteArrayType(absoluteName, false, Net.Vpc.Upa.Impl.Config.Annotationparser.AnnotationParserUtils.ParseInt(overriddenMaxValue, System.Int32.MaxValue), nullableOk));
            } else if (typeof(byte?[]).Equals(nativeClass)) {
                fieldTypeProcessed = true;
                overriddenDataType.SetValue(new Net.Vpc.Upa.Types.ByteArrayType(absoluteName, true, Net.Vpc.Upa.Impl.Config.Annotationparser.AnnotationParserUtils.ParseInt(overriddenMaxValue, System.Int32.MaxValue), nullableOk));
            } else if (typeof(char[]).Equals(nativeClass)) {
                fieldTypeProcessed = true;
                overriddenDataType.SetValue(new Net.Vpc.Upa.Types.CharArrayType(absoluteName, false, Net.Vpc.Upa.Impl.Config.Annotationparser.AnnotationParserUtils.ParseInt(overriddenMaxValue, System.Int32.MaxValue), nullableOk));
            } else if (typeof(char?[]).Equals(nativeClass)) {
                fieldTypeProcessed = true;
                overriddenDataType.SetValue(new Net.Vpc.Upa.Types.CharArrayType(absoluteName, true, Net.Vpc.Upa.Impl.Config.Annotationparser.AnnotationParserUtils.ParseInt(overriddenMaxValue, System.Int32.MaxValue), nullableOk));
            } else {
                // BigDecimal is ignored because not supported in C#
                if (!fieldTypeProcessed && Net.Vpc.Upa.Impl.Util.PlatformUtils.IsBigInt(nativeClass)) {
                    fieldTypeProcessed = true;
                    System.Numerics.BigInteger? minBigInteger = Net.Vpc.Upa.Impl.Config.Annotationparser.AnnotationParserUtils.ParseBigInteger(overriddenMinValue, null);
                    System.Numerics.BigInteger? maxBigInteger = Net.Vpc.Upa.Impl.Config.Annotationparser.AnnotationParserUtils.ParseBigInteger(overriddenMaxValue, null);
                    overriddenDataType.SetValue(new Net.Vpc.Upa.Types.BigIntType(absoluteName, minBigInteger, maxBigInteger, nullableOk));
                }
            }
            if (foreignInfo.IsSpecified()) {
                buildForeign = true;
                if (!fieldTypeProcessed) {
                    fieldTypeProcessed = true;
                }
                if (foreignInfo.GetPreferredDataType() != null) {
                    overriddenDataType.SetValue(foreignInfo.GetPreferredDataType());
                }
            }
            if (!fieldTypeProcessed) {
                fieldTypeProcessed = true;
                if ((nativeClass).IsArray || typeof(System.Type).IsAssignableFrom(nativeClass)) {
                    Net.Vpc.Upa.Types.SerializableType ttype = new Net.Vpc.Upa.Types.SerializableType(name, nativeClass, nullableOk);
                    overriddenDataType.SetValue(ttype);
                } else {
                    Net.Vpc.Upa.Impl.SerializableOrManyToOneType ttype = new Net.Vpc.Upa.Impl.SerializableOrManyToOneType(name, nativeClass, nullableOk);
                    overriddenDataType.SetValue(ttype);
                }
            }
        }

        public virtual void Prepare(System.Collections.Generic.IDictionary<string , object> ctx, string entityName) /* throws Net.Vpc.Upa.Exceptions.UPAException, System.Exception, System.Exception, System.Exception */  {
            modifiers = Net.Vpc.Upa.FlagSets.NoneOf<Net.Vpc.Upa.UserFieldModifier>();
            excludeModifiers = Net.Vpc.Upa.FlagSets.NoneOf<Net.Vpc.Upa.UserFieldModifier>();
            //////////////////////////////////////////////////////
            // Process all fields
            if ((fields).Count > 1) {
                Net.Vpc.Upa.Impl.FwkConvertUtils.ListSort(fields, FIELD_COMPARATOR);
            }
            foreach (System.Reflection.FieldInfo someField in fields) {
                Net.Vpc.Upa.Config.Decoration searchDeco = repo.GetFieldDecoration(someField, typeof(Net.Vpc.Upa.Config.Search));
                if (searchDeco != null) {
                    overriddenSearchOperator.SetBetterValue(System.Collections.Generic.EqualityComparer<Net.Vpc.Upa.SearchOperator>.Default.Equals(searchDeco.GetEnum<Net.Vpc.Upa.SearchOperator>("op", typeof(Net.Vpc.Upa.SearchOperator)),Net.Vpc.Upa.SearchOperator.DEFAULT) ? Net.Vpc.Upa.Impl.Util.PlatformUtils.GetUndefinedValue<Net.Vpc.Upa.SearchOperator>(typeof(Net.Vpc.Upa.SearchOperator)) : searchDeco.GetEnum<Net.Vpc.Upa.SearchOperator>("op", typeof(Net.Vpc.Upa.SearchOperator)), searchDeco.GetConfig().GetOrder());
                }
                foreach (Net.Vpc.Upa.Config.Index indexAnn in FindIndexAnnotation(someField)) {
                    System.Collections.Generic.IList<string> rr = new System.Collections.Generic.List<string>();
                    rr.Add((someField).Name);
                    Net.Vpc.Upa.Impl.FwkConvertUtils.ListAddRange(rr, new System.Collections.Generic.List<string>(indexAnn.Fields));
                    entityInfo.AddIndex(indexAnn.Name, rr, indexAnn.Unique, indexAnn.Config.Order);
                }
                Net.Vpc.Upa.Config.Decoration temporalAnn = repo.GetFieldDecoration(someField, typeof(Net.Vpc.Upa.Config.Temporal));
                if (temporalAnn != null && temporalAnn.GetConfig().GetOrder() != System.Int32.MinValue) {
                    overriddenTemporal.SetBetterValue(temporalAnn.GetEnum<Net.Vpc.Upa.Types.TemporalOption>("value", typeof(Net.Vpc.Upa.Types.TemporalOption)), temporalAnn.GetConfig().GetOrder());
                }
                Net.Vpc.Upa.Config.Decoration propertyDeco = repo.GetFieldDecoration(someField, typeof(Net.Vpc.Upa.Config.Property));
                if (propertyDeco != null) {
                    parameterInfos.Add(new Net.Vpc.Upa.Property(propertyDeco.GetString("name"), propertyDeco.GetString("value"), propertyDeco.GetString("type"), propertyDeco.GetString("format")));
                }
                Net.Vpc.Upa.Config.Decoration propertiesDeco = repo.GetFieldDecoration(someField, typeof(Net.Vpc.Upa.Config.Properties));
                if (propertiesDeco != null) {
                    foreach (Net.Vpc.Upa.Config.DecorationValue p in propertiesDeco.GetArray("value")) {
                        //p of type net.vpc.upa.config.Property
                        Net.Vpc.Upa.Config.Decoration pp = (Net.Vpc.Upa.Config.Decoration) p;
                        parameterInfos.Add(new Net.Vpc.Upa.Property(pp.GetString("name"), pp.GetString("value"), pp.GetString("type"), pp.GetString("format")));
                    }
                }
                Net.Vpc.Upa.Config.Decoration pathDeco = repo.GetFieldDecoration(someField, typeof(Net.Vpc.Upa.Config.Path));
                if (pathDeco != null) {
                    Net.Vpc.Upa.Impl.Config.Annotationparser.AnnotationParserUtils.ValidStr(pathDeco.GetString("value"), overriddenPath, pathDeco.GetConfig().GetOrder());
                }
                if (someField.GetType().Equals(typeof(Net.Vpc.Upa.Config.FieldDesc))) {
                    PrepareFieldDesc(ctx, entityName, someField);
                } else {
                    //default configOrder for DAL is 100
                    overriddenNativeType.SetBetterValue(someField.GetType(), 100);
                }
                Net.Vpc.Upa.Config.Decoration fieldDeco = repo.GetFieldDecoration(someField, typeof(Net.Vpc.Upa.Config.Field));
                if (fieldDeco != null) {
                    modifiers = modifiers.AddAll(new System.Collections.Generic.List<Net.Vpc.Upa.UserFieldModifier>(fieldDeco.GetPrimitiveArray<Net.Vpc.Upa.UserFieldModifier>("modifiers", typeof(Net.Vpc.Upa.UserFieldModifier))));
                    excludeModifiers = excludeModifiers.AddAll(new System.Collections.Generic.List<Net.Vpc.Upa.UserFieldModifier>(fieldDeco.GetPrimitiveArray<Net.Vpc.Upa.UserFieldModifier>("excludeModifiers", typeof(Net.Vpc.Upa.UserFieldModifier))));
                    int processOrder = fieldDeco.GetConfig().GetOrder();
                    Net.Vpc.Upa.Impl.Config.Annotationparser.AnnotationParserUtils.ValidClass(fieldDeco.GetType("type"), overriddenNativeType, typeof(object), processOrder);
                    Net.Vpc.Upa.Impl.Config.Annotationparser.AnnotationParserUtils.ValidStr(fieldDeco.GetString("min"), overriddenMinValue, processOrder);
                    Net.Vpc.Upa.Impl.Config.Annotationparser.AnnotationParserUtils.ValidStr(fieldDeco.GetString("max"), overriddenMaxValue, processOrder);
                    Net.Vpc.Upa.Impl.Config.Annotationparser.AnnotationParserUtils.ValidStr(fieldDeco.GetString("layout"), overriddenLayout, processOrder);
                    Net.Vpc.Upa.Impl.Config.Annotationparser.AnnotationParserUtils.ValidInt(fieldDeco.GetInt("scale"), overriddenScale, -1, processOrder);
                    Net.Vpc.Upa.Impl.Config.Annotationparser.AnnotationParserUtils.ValidInt(fieldDeco.GetInt("precision"), overriddenPrec, -1, processOrder);
                    if (!System.Collections.Generic.EqualityComparer<Net.Vpc.Upa.Config.BoolEnum>.Default.Equals(fieldDeco.GetEnum<Net.Vpc.Upa.Config.BoolEnum>("nullable", typeof(Net.Vpc.Upa.Config.BoolEnum)),Net.Vpc.Upa.Config.BoolEnum.UNDEFINED)) {
                        overriddenNullable.SetBetterValue(fieldDeco.GetEnum<Net.Vpc.Upa.Config.BoolEnum>("nullable", typeof(Net.Vpc.Upa.Config.BoolEnum)), processOrder);
                    }
                    if (fieldDeco.GetInt("position") != System.Int32.MinValue) {
                        overriddenPosition.SetBetterValue(fieldDeco.GetInt("position"), processOrder);
                    }
                    //                if (fieldDeco.getEnum("end", BoolEnum.class) != BoolEnum.UNDEFINED) {
                    //                    overriddenEnd.setBetterValue(fieldDeco.getEnum("nullable", BoolEnum.class), processOrder);
                    //                }
                    if (!Net.Vpc.Upa.Impl.Util.PlatformUtils.IsUndefinedValue<Net.Vpc.Upa.AccessLevel>(typeof(Net.Vpc.Upa.AccessLevel), fieldDeco.GetEnum<Net.Vpc.Upa.AccessLevel>("persistAccessLevel", typeof(Net.Vpc.Upa.AccessLevel)))) {
                        overriddenPersistAccessLevel.SetBetterValue(fieldDeco.GetEnum<Net.Vpc.Upa.AccessLevel>("persistAccessLevel", typeof(Net.Vpc.Upa.AccessLevel)), processOrder);
                    }
                    if (!Net.Vpc.Upa.Impl.Util.PlatformUtils.IsUndefinedValue<Net.Vpc.Upa.AccessLevel>(typeof(Net.Vpc.Upa.AccessLevel), fieldDeco.GetEnum<Net.Vpc.Upa.AccessLevel>("updateAccessLevel", typeof(Net.Vpc.Upa.AccessLevel)))) {
                        overriddenUpdateAccessLevel.SetBetterValue(fieldDeco.GetEnum<Net.Vpc.Upa.AccessLevel>("updateAccessLevel", typeof(Net.Vpc.Upa.AccessLevel)), processOrder);
                    }
                    if (!Net.Vpc.Upa.Impl.Util.PlatformUtils.IsUndefinedValue<Net.Vpc.Upa.AccessLevel>(typeof(Net.Vpc.Upa.AccessLevel), fieldDeco.GetEnum<Net.Vpc.Upa.AccessLevel>("removeAccessLevel", typeof(Net.Vpc.Upa.AccessLevel)))) {
                        overriddenRemoveAccessLevel.SetBetterValue(fieldDeco.GetEnum<Net.Vpc.Upa.AccessLevel>("removeAccessLevel", typeof(Net.Vpc.Upa.AccessLevel)), processOrder);
                    }
                    if (!Net.Vpc.Upa.Impl.Util.PlatformUtils.IsUndefinedValue<Net.Vpc.Upa.AccessLevel>(typeof(Net.Vpc.Upa.AccessLevel), fieldDeco.GetEnum<Net.Vpc.Upa.AccessLevel>("readAccessLevel", typeof(Net.Vpc.Upa.AccessLevel)))) {
                        overriddenReadAccessLevel.SetBetterValue(fieldDeco.GetEnum<Net.Vpc.Upa.AccessLevel>("readAccessLevel", typeof(Net.Vpc.Upa.AccessLevel)), processOrder);
                    }
                    Net.Vpc.Upa.Impl.Config.Annotationparser.AnnotationParserUtils.ValidStr(fieldDeco.GetString("charsAccepted"), overriddenCharsAccepted, processOrder);
                    Net.Vpc.Upa.Impl.Config.Annotationparser.AnnotationParserUtils.ValidStr(fieldDeco.GetString("charsRejected"), overriddenCharsRejected, processOrder);
                    Net.Vpc.Upa.Impl.Config.Annotationparser.AnnotationParserUtils.ValidStr(fieldDeco.GetString("format"), overriddenFormat, processOrder);
                    Net.Vpc.Upa.Impl.Config.Annotationparser.AnnotationParserUtils.ValidStr(fieldDeco.GetString("path"), overriddenPath, processOrder);
                    Net.Vpc.Upa.Impl.Config.Annotationparser.AnnotationParserUtils.ValidStr(fieldDeco.GetString("defaultValue"), overriddenDefaultValueStr, processOrder);
                    Net.Vpc.Upa.Impl.Config.Annotationparser.AnnotationParserUtils.ValidStr(fieldDeco.GetString("unspecifiedValue"), overriddenUnspecifiedValueStr, processOrder);
                }
                Net.Vpc.Upa.Config.Decoration mainDeco = repo.GetFieldDecoration(someField, typeof(Net.Vpc.Upa.Config.Main));
                if (mainDeco != null) {
                    modifiers = modifiers.Add(Net.Vpc.Upa.UserFieldModifier.MAIN);
                }
                Net.Vpc.Upa.Config.Decoration summaryDeco = repo.GetFieldDecoration(someField, typeof(Net.Vpc.Upa.Config.Summary));
                if (summaryDeco != null) {
                    modifiers = modifiers.Add(Net.Vpc.Upa.UserFieldModifier.SUMMARY);
                }
                Net.Vpc.Upa.Config.Decoration uniqueDeco = repo.GetFieldDecoration(someField, typeof(Net.Vpc.Upa.Config.Unique));
                if (uniqueDeco != null) {
                    modifiers = modifiers.Add(Net.Vpc.Upa.UserFieldModifier.UNIQUE);
                }
                Net.Vpc.Upa.Config.Decoration annID = repo.GetFieldDecoration(someField, typeof(Net.Vpc.Upa.Config.Id));
                if (annID != null) {
                    modifiers = modifiers.Add(Net.Vpc.Upa.UserFieldModifier.ID);
                }
                Net.Vpc.Upa.Config.Decoration propertyAccess = repo.GetFieldDecoration(someField, typeof(Net.Vpc.Upa.PropertyAccess));
                if (propertyAccess != null) {
                    overriddenPropertyAccessType.SetBetterValue(propertyAccess.GetEnum<Net.Vpc.Upa.PropertyAccessType>("value", typeof(Net.Vpc.Upa.PropertyAccessType)), propertyAccess.GetConfig().GetOrder());
                }
            }
            nativeClass = overriddenNativeType.GetValue(fields[0].GetType());
            foreach (Net.Vpc.Upa.Property parameterInfo in parameterInfos) {
                fieldParams[parameterInfo.GetName()]=Net.Vpc.Upa.Impl.Util.UPAUtils.CreateValue(parameterInfo);
            }
            if (overriddenNullable.specified && (!System.Collections.Generic.EqualityComparer<Net.Vpc.Upa.Config.BoolEnum>.Default.Equals(overriddenNullable.@value,Net.Vpc.Upa.Config.BoolEnum.UNDEFINED))) {
                nullableOk = overriddenNullable.@value.Equals(Net.Vpc.Upa.Config.BoolEnum.TRUE);
            }
            if (!Net.Vpc.Upa.Impl.Util.PlatformUtils.IsNullableType(nativeClass) || modifiers.Contains(Net.Vpc.Upa.UserFieldModifier.ID)) {
                nullableOk = false;
            }
            anyFormula.Parse(fields);
            foreignInfo.Parse(fields, nullableOk);
            //        boolean endOk = false;
            //        if (overriddenEnd.specified && (overriddenEnd.value != BoolEnum.UNDEFINED)) {
            //            endOk = overriddenEnd.value.equals(BoolEnum.TRUE);
            //        }
            if (overriddenNativeType.specified && !overriddenNativeType.@value.Equals(typeof(object)) && (!overriddenDataType.specified || (overriddenDataType.specified && overriddenNativeType.order > overriddenDataType.order))) {
                PrepareBaseDataType(ctx, entityName);
            }
            PreparePeristentDataType(ctx, entityName);
            foreach (System.Collections.Generic.KeyValuePair<Net.Vpc.Upa.FormulaType , object> ee in new System.Collections.Generic.HashSet<System.Collections.Generic.KeyValuePair<Net.Vpc.Upa.FormulaType,object>>(anyFormula.all)) {
                PrepareFormula(ctx, entityName, (ee).Key, (ee).Value);
            }
            if (foreignInfo.IsSpecified()) {
                if (foreignInfo.GetTargetEntity() == null && foreignInfo.GetTargetEntityType() == null) {
                    throw new Net.Vpc.Upa.Exceptions.UPAException("MissingManyToOneTargetEntity", entityInfo.name + "." + name);
                }
                if (foreignInfo.IsProducesRelation()) {
                    entityInfo.relations.Add(foreignInfo);
                }
            }
            if (overriddenUnspecifiedValue.specified) {
                this.unspecifiedObject = (overriddenUnspecifiedValue.@value);
            }
            if (overriddenPath.specified) {
                this.fieldPath = overriddenPath.@value;
            }
            //        if (insertFormula.specified) {
            //            this.formulaupaField.setFormula(insertFormula.value);
            //        }
            if (overriddenDataType.specified) {
                this.type = (overriddenDataType.@value);
            }
            //        if (overriddenTargetType.specified) {
            //            this.targetType = (overriddenTargetType.value);
            //        }
            if (overriddenPersistAccessLevel.specified && !Net.Vpc.Upa.Impl.Util.PlatformUtils.IsUndefinedValue<Net.Vpc.Upa.AccessLevel>(typeof(Net.Vpc.Upa.AccessLevel), overriddenPersistAccessLevel.@value)) {
                this.persistAccessLevel = overriddenPersistAccessLevel.@value;
            }
            if (overriddenUpdateAccessLevel.specified && !Net.Vpc.Upa.Impl.Util.PlatformUtils.IsUndefinedValue<Net.Vpc.Upa.AccessLevel>(typeof(Net.Vpc.Upa.AccessLevel), overriddenUpdateAccessLevel.@value)) {
                this.updateAccessLevel = overriddenUpdateAccessLevel.@value;
            }
            if (overriddenReadAccessLevel.specified && !Net.Vpc.Upa.Impl.Util.PlatformUtils.IsUndefinedValue<Net.Vpc.Upa.AccessLevel>(typeof(Net.Vpc.Upa.AccessLevel), overriddenReadAccessLevel.@value)) {
                this.readAccessLevel = overriddenReadAccessLevel.@value;
            }
        }

        public virtual void Build(System.Collections.Generic.IDictionary<string , object> ctx, string entityName) {
            if (buildForeign) {
                if (Net.Vpc.Upa.Impl.Util.UPAUtils.IsSimpleFieldType(nativeClass)) {
                    int length = foreignInfo.GetMappedTo() == null ? 0 : foreignInfo.GetMappedTo().Length;
                    if (length == 1) {
                        Net.Vpc.Upa.Impl.Config.Annotationparser.FieldInfo f = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,Net.Vpc.Upa.Impl.Config.Annotationparser.FieldInfo>(entityInfo.fieldsMap,foreignInfo.GetMappedTo()[0]);
                        if (f == null) {
                            throw new System.ArgumentException ("Field " + foreignInfo.GetMappedTo()[0] + " not found");
                        }
                        if (!f.foreignInfo.IsSpecified()) {
                            Net.Vpc.Upa.Types.ManyToOneType manyToOneType = new Net.Vpc.Upa.Types.ManyToOneType(f.name, f.nativeClass, foreignInfo.GetTargetEntity(), false, f.nullableOk);
                            f.overriddenDataType.SetValue(manyToOneType);
                        } else {
                            throw new System.ArgumentException (f.name + " already mapped by " + name + ". Should not define relations on its own.");
                        }
                    } else if (length > 1) {
                        throw new System.ArgumentException ("Illegal mapping for " + name);
                    }
                }
            }
            if (!overriddenDataType.specified || System.Collections.Generic.EqualityComparer<Net.Vpc.Upa.Types.DataType>.Default.Equals(overriddenDataType.@value,null)) {
                System.Text.StringBuilder err = new System.Text.StringBuilder();
                err.Append("Field Type could not be resolved for field ").Append(name).Append("(entity ").Append(entityName).Append(")\n");
                err.Append("Scope Fields are ").Append(fields).Append("\n");
                log.TraceEvent(System.Diagnostics.TraceEventType.Warning,90,Net.Vpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter(err.ToString(),null));
                valid = false;
                return;
            }
            if (overriddenDefaultValueStr.specified && (!overriddenDefaultValue.specified || overriddenDefaultValueStr.order > overriddenDefaultValue.order)) {
                try {
                    overriddenDefaultValue.SetBetterValue(Net.Vpc.Upa.Impl.Config.Annotationparser.AnnotationParserUtils.ParseStringValue(overriddenDefaultValueStr.@value, overriddenDataType.@value, null), overriddenDefaultValue.order);
                } catch (System.Exception e) {
                    throw new System.Exception("Unable to parse default value for " + entityName + "." + name, e);
                }
            }
            if (overriddenDefaultValue.specified) {
                this.defaultObject = (overriddenDefaultValue.@value);
            }
            if (overriddenUnspecifiedValueStr.specified && (!overriddenUnspecifiedValue.specified || overriddenUnspecifiedValueStr.order > overriddenUnspecifiedValue.order)) {
                try {
                    overriddenUnspecifiedValue.SetBetterValue(Net.Vpc.Upa.Impl.Config.Annotationparser.AnnotationParserUtils.ParseStringValue(overriddenUnspecifiedValueStr.@value, overriddenDataType.@value, Net.Vpc.Upa.UnspecifiedValue.DEFAULT), overriddenUnspecifiedValue.order);
                } catch (System.Exception e) {
                    throw new System.Exception("Unable to parse unspecified value for " + entityName + "." + name, e);
                }
            }
            if (overriddenDataType.specified) {
                this.type = (overriddenDataType.@value);
            }
        }

        public virtual void RegisterField(System.Reflection.FieldInfo field) {
            fields.Add(field);
        }

        public virtual string GetName() {
            return name;
        }

        public virtual System.Collections.Generic.IList<System.Reflection.FieldInfo> GetFields() {
            return fields;
        }

        public virtual Net.Vpc.Upa.Impl.Config.Annotationparser.RelationshipInfo GetForeignInfo() {
            return foreignInfo;
        }

        public virtual Net.Vpc.Upa.Impl.Config.Annotationparser.EntityInfo GetEntityInfo() {
            return entityInfo;
        }

        public virtual string GetFieldPath() {
            return fieldPath;
        }

        public virtual object GetDefaultObject() {
            return defaultObject;
        }

        public virtual object GetUnspecifiedObject() {
            return unspecifiedObject;
        }

        public virtual Net.Vpc.Upa.Impl.Config.Annotationparser.AnyFormulaInfo GetAnyFormula() {
            return anyFormula;
        }

        public virtual Net.Vpc.Upa.Types.DataType GetDataType() {
            return type;
        }

        public virtual Net.Vpc.Upa.Formula GetPersistFormula() {
            return persistFormula;
        }

        public virtual Net.Vpc.Upa.Formula GetUpdateFormula() {
            return updateFormula;
        }

        public virtual Net.Vpc.Upa.Formula GetSelectFormula() {
            return selectFormula;
        }

        public virtual int GetPersistFormulaOrder() {
            return persistFormulaOrder;
        }

        public virtual int GetUpdateFormulaOrder() {
            return updateFormulaOrder;
        }

        public virtual int GetPosition() {
            int? @value = overriddenPosition.@value;
            if (@value == null) {
                return 0;
            }
            return (@value).Value;
        }

        public virtual int GetSelectFormulaOrder() {
            return selectFormulaOrder;
        }

        public virtual Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.UserFieldModifier> GetUserFieldModifiers() {
            return modifiers;
        }

        public virtual Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.UserFieldModifier> GetUserExcludeModifiers() {
            return excludeModifiers;
        }

        public virtual Net.Vpc.Upa.AccessLevel GetPersistAccessLevel() {
            return persistAccessLevel;
        }

        public virtual Net.Vpc.Upa.AccessLevel GetUpdateAccessLevel() {
            return updateAccessLevel;
        }

        public virtual Net.Vpc.Upa.AccessLevel GetReadAccessLevel() {
            return readAccessLevel;
        }

        public virtual bool IsValid() {
            return valid;
        }

        public virtual bool IsBuildForeign() {
            return buildForeign;
        }

        public virtual System.Type GetNativeClass() {
            return nativeClass;
        }

        public virtual bool IsNullableOk() {
            return nullableOk;
        }

        private System.Collections.Generic.IList<Net.Vpc.Upa.Config.Index> FindIndexAnnotation(System.Reflection.FieldInfo javaField) {
            System.Collections.Generic.IList<Net.Vpc.Upa.Config.Index> list = new System.Collections.Generic.List<Net.Vpc.Upa.Config.Index>();
            Net.Vpc.Upa.Config.Index indexAnn = (Net.Vpc.Upa.Config.Index) repo.GetFieldDecoration(javaField, typeof(Net.Vpc.Upa.Config.Index));
            if (indexAnn != null) {
                list.Add(indexAnn);
            }
            Net.Vpc.Upa.Config.Indexes indexAnnAll = (Net.Vpc.Upa.Config.Indexes) repo.GetFieldDecoration(javaField, typeof(Net.Vpc.Upa.Config.Indexes));
            if (indexAnnAll != null) {
                foreach (Net.Vpc.Upa.Config.Index index in indexAnnAll.Value) {
                    if (indexAnn != null) {
                        list.Add(index);
                    }
                }
            }
            return list;
        }

        public virtual Net.Vpc.Upa.Types.DataTypeTransformConfig[] GetTypeTransform() {
            if (overriddenTransform.specified) {
                return overriddenTransform.@value;
            }
            return null;
        }


        public override string ToString() {
            return "FieldInfo{" + "name=" + name + ", fields=" + fields + ", type=" + type + '}';
        }

        private void PrepareFormula(System.Collections.Generic.IDictionary<string , object> ctx, string entityName, Net.Vpc.Upa.FormulaType t, object o) {
            Net.Vpc.Upa.Formula ff = null;
            int order = 0;
            if (o is Net.Vpc.Upa.Impl.Config.Annotationparser.FormulaInfo) {
                Net.Vpc.Upa.Impl.Config.Annotationparser.FormulaInfo formulaInfo = (Net.Vpc.Upa.Impl.Config.Annotationparser.FormulaInfo) o;
                if (formulaInfo.specified) {
                    if (formulaInfo.type != null) {
                        try {
                            ff = ((Net.Vpc.Upa.Formula)System.Activator.CreateInstance(formulaInfo.type));
                        } catch (System.Exception e) {
                            throw new System.Exception("RuntimeException", e);
                        }
                    } else if (formulaInfo.expression != null) {
                        ff = (new Net.Vpc.Upa.ExpressionFormula(formulaInfo.expression));
                    }
                    if (formulaInfo.order != null) {
                        order = (formulaInfo.order).Value;
                    }
                }
            } else if (o is Net.Vpc.Upa.Impl.Config.Annotationparser.SequenceInfo) {
                Net.Vpc.Upa.Impl.Config.Annotationparser.SequenceInfo formulaInfo = (Net.Vpc.Upa.Impl.Config.Annotationparser.SequenceInfo) o;
                if (formulaInfo.specified) {
                    ff = new Net.Vpc.Upa.Sequence(formulaInfo.strategy == default(Net.Vpc.Upa.SequenceStrategy) ? Net.Vpc.Upa.SequenceStrategy.AUTO : formulaInfo.strategy, formulaInfo.initialValue == null ? ((Net.Vpc.Upa.Formula)(1)) : formulaInfo.initialValue, formulaInfo.allocationSize == null ? ((Net.Vpc.Upa.Formula)(50)) : formulaInfo.allocationSize, formulaInfo.name, formulaInfo.group, formulaInfo.format);
                }
            }
            switch(t) {
                case Net.Vpc.Upa.FormulaType.PERSIST:
                    {
                        this.persistFormula = ff;
                        this.persistFormulaOrder = order;
                        break;
                    }
                case Net.Vpc.Upa.FormulaType.UPDATE:
                    {
                        this.updateFormula = ff;
                        this.updateFormulaOrder = order;
                        break;
                    }
                case Net.Vpc.Upa.FormulaType.LIVE:
                    {
                        this.selectFormula = ff;
                        this.selectFormulaOrder = order;
                        modifiers = modifiers.Add(Net.Vpc.Upa.UserFieldModifier.LIVE);
                        break;
                    }
                case Net.Vpc.Upa.FormulaType.COMPILED:
                    {
                        modifiers = modifiers.Add(Net.Vpc.Upa.UserFieldModifier.COMPILED);
                        this.selectFormula = ff;
                        this.selectFormulaOrder = order;
                        break;
                    }
            }
        }

        private void PreparePeristentDataType(System.Collections.Generic.IDictionary<string , object> ctx, string entityName) {
            foreach (System.Reflection.FieldInfo javaField in fields) {
                System.Collections.Generic.IList<Net.Vpc.Upa.Types.DataTypeTransformConfig> transforms = new System.Collections.Generic.List<Net.Vpc.Upa.Types.DataTypeTransformConfig>();
                Net.Vpc.Upa.Config.ConfigInfo ci = null;
                foreach (Net.Vpc.Upa.Config.Decoration fieldDecoration in repo.GetFieldDecorations(javaField)) {
                    if (fieldDecoration.GetName().Equals((typeof(Net.Vpc.Upa.Config.Password)).FullName)) {
                        if (ci == null) {
                            ci = fieldDecoration.GetConfig();
                        }
                        Net.Vpc.Upa.PasswordTransformConfig p = new Net.Vpc.Upa.PasswordTransformConfig();
                        if (System.Collections.Generic.EqualityComparer<Net.Vpc.Upa.PasswordStrategyType>.Default.Equals(fieldDecoration.GetEnum<Net.Vpc.Upa.PasswordStrategyType>("strategyType", typeof(Net.Vpc.Upa.PasswordStrategyType)),Net.Vpc.Upa.PasswordStrategyType.CUSTOM)) {
                            p.SetCipherStrategy(fieldDecoration.GetString("customStrategy"));
                        } else {
                            p.SetCipherStrategy(fieldDecoration.GetEnum<Net.Vpc.Upa.PasswordStrategyType>("strategyType", typeof(Net.Vpc.Upa.PasswordStrategyType)));
                        }
                        string cipherValue = fieldDecoration.GetString("cipherValue");
                        string cipherValueType = fieldDecoration.GetString("cipherValueType");
                        string cipherValueFormat = fieldDecoration.GetString("cipherValueFormat");
                        object cypherValueObj = Net.Vpc.Upa.Impl.Util.UPAUtils.CreateValue(cipherValue, cipherValueType, cipherValueFormat);
                        p.SetCipherValue(cypherValueObj);
                        transforms.Add(p);
                    } else if (fieldDecoration.GetName().Equals((typeof(Net.Vpc.Upa.Config.Secret)).FullName)) {
                        if (ci == null) {
                            ci = fieldDecoration.GetConfig();
                        }
                        Net.Vpc.Upa.Types.SecretTransformConfig s2 = new Net.Vpc.Upa.Types.SecretTransformConfig();
                        s2.SetSecretStrategy(fieldDecoration.GetString("algorithm"));
                        s2.SetSize(fieldDecoration.GetInt("max"));
                        s2.SetEncodeKey(fieldDecoration.GetString("key"));
                        s2.SetDecodeKey(fieldDecoration.GetString("reverseKey"));
                        transforms.Add(s2);
                    } else if (fieldDecoration.GetName().Equals((typeof(Net.Vpc.Upa.Config.ToString)).FullName)) {
                        if (ci == null) {
                            ci = fieldDecoration.GetConfig();
                        }
                        Net.Vpc.Upa.Types.StringEncoderTransformConfig s2 = new Net.Vpc.Upa.Types.StringEncoderTransformConfig();
                        Net.Vpc.Upa.Config.StringEncoderType stringStrategyType = fieldDecoration.GetEnum<Net.Vpc.Upa.Config.StringEncoderType>("value", typeof(Net.Vpc.Upa.Config.StringEncoderType));
                        if (stringStrategyType == Net.Vpc.Upa.Config.StringEncoderType.CUSTOM) {
                            s2.SetEncoder(fieldDecoration.GetEnum<Net.Vpc.Upa.Config.StringEncoderType>("custom", typeof(Net.Vpc.Upa.Config.StringEncoderType)));
                        } else {
                            s2.SetEncoder(stringStrategyType);
                        }
                        transforms.Add(s2);
                    } else if (fieldDecoration.GetName().Equals((typeof(Net.Vpc.Upa.Config.ToByteArray)).FullName)) {
                        if (ci == null) {
                            ci = fieldDecoration.GetConfig();
                        }
                        Net.Vpc.Upa.Types.ByteArrayEncoderTransformConfig s2 = new Net.Vpc.Upa.Types.ByteArrayEncoderTransformConfig();
                        s2.SetEncoder(fieldDecoration.GetString("value"));
                        transforms.Add(s2);
                    } else if (fieldDecoration.GetName().Equals((typeof(Net.Vpc.Upa.Config.ToCharArray)).FullName)) {
                        if (ci == null) {
                            ci = fieldDecoration.GetConfig();
                        }
                        Net.Vpc.Upa.Types.CharArrayEncoderTransformConfig s2 = new Net.Vpc.Upa.Types.CharArrayEncoderTransformConfig();
                        s2.SetEncoder(fieldDecoration.GetString("value"));
                        transforms.Add(s2);
                    } else if (fieldDecoration.GetName().Equals((typeof(Net.Vpc.Upa.Config.Converter)).FullName)) {
                        if (ci == null) {
                            ci = fieldDecoration.GetConfig();
                        }
                        string type = fieldDecoration.GetString("type");
                        string expression = fieldDecoration.GetString("expression");
                        if ((type).Length > 0 && (expression).Length > 0) {
                            throw new System.ArgumentException ("Invalid Converter definition : both type and expression are mentioned");
                        } else if ((type).Length == 0 && (expression).Length == 0) {
                            throw new System.ArgumentException ("Invalid Converter definition : none of type and expression are mentioned");
                        } else if ((type).Length > 0) {
                            Net.Vpc.Upa.Types.CustomTypeDataTypeTransform s2 = new Net.Vpc.Upa.Types.CustomTypeDataTypeTransform(type);
                            transforms.Add(s2);
                        } else {
                            Net.Vpc.Upa.Types.CustomExpressionDataTypeTransform s2 = new Net.Vpc.Upa.Types.CustomExpressionDataTypeTransform(type);
                            transforms.Add(s2);
                        }
                    }
                }
                if (ci != null) {
                    overriddenTransform.SetBetterValue(transforms.ToArray(), ci.GetOrder());
                }
            }
        }

        public virtual Net.Vpc.Upa.PropertyAccessType GetPropertyAccessType() {
            return overriddenPropertyAccessType.GetValue(default(Net.Vpc.Upa.PropertyAccessType));
        }
    }
}
