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
namespace Net.TheVpc.Upa.Impl.Config.Annotationparser
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 11/15/12 11:50 AM
     */
    internal class FieldInfo : Net.TheVpc.Upa.FieldDescriptor {

        protected internal static System.Diagnostics.TraceSource log = new System.Diagnostics.TraceSource((typeof(Net.TheVpc.Upa.Impl.Config.Annotationparser.FieldInfo)).FullName);

        private System.Collections.Generic.IComparer<System.Reflection.FieldInfo> FIELD_COMPARATOR;

        internal string name;

        internal System.Collections.Generic.IList<System.Reflection.FieldInfo> fields = new System.Collections.Generic.List<System.Reflection.FieldInfo>();

        internal Net.TheVpc.Upa.Impl.Config.Annotationparser.RelationshipInfo foreignInfo;

        internal Net.TheVpc.Upa.Impl.Config.Annotationparser.EntityInfo entityInfo = null;

        internal string fieldPath = null;

        internal object defaultObject = null;

        internal object unspecifiedObject = null;

        internal Net.TheVpc.Upa.Impl.Config.Annotationparser.AnyFormulaInfo anyFormula;

        internal Net.TheVpc.Upa.Types.DataType type;

        internal Net.TheVpc.Upa.Formula persistFormula;

        internal Net.TheVpc.Upa.Formula updateFormula;

        internal Net.TheVpc.Upa.Formula selectFormula;

        internal int persistFormulaOrder;

        internal int updateFormulaOrder;

        internal int selectFormulaOrder;

        internal Net.TheVpc.Upa.FlagSet<Net.TheVpc.Upa.UserFieldModifier> modifiers;

        internal Net.TheVpc.Upa.FlagSet<Net.TheVpc.Upa.UserFieldModifier> excludeModifiers;

        internal Net.TheVpc.Upa.AccessLevel persistAccessLevel;

        internal Net.TheVpc.Upa.AccessLevel updateAccessLevel;

        internal Net.TheVpc.Upa.AccessLevel readAccessLevel;

        internal bool valid = true;

        internal bool buildForeign = false;

        internal Net.TheVpc.Upa.Impl.Config.Annotationparser.OverriddenValue<Net.TheVpc.Upa.Types.DataType> overriddenDataType = new Net.TheVpc.Upa.Impl.Config.Annotationparser.OverriddenValue<Net.TheVpc.Upa.Types.DataType>();

        internal Net.TheVpc.Upa.Impl.Config.Annotationparser.OverriddenValue<Net.TheVpc.Upa.Types.DataTypeTransformConfig[]> overriddenTransform = new Net.TheVpc.Upa.Impl.Config.Annotationparser.OverriddenValue<Net.TheVpc.Upa.Types.DataTypeTransformConfig[]>();

        internal Net.TheVpc.Upa.Impl.Config.Annotationparser.OverriddenValue<Net.TheVpc.Upa.SearchOperator> overriddenSearchOperator = new Net.TheVpc.Upa.Impl.Config.Annotationparser.OverriddenValue<Net.TheVpc.Upa.SearchOperator>();

        internal Net.TheVpc.Upa.Impl.Config.Annotationparser.OverriddenValue<object> overriddenDefaultValue = new Net.TheVpc.Upa.Impl.Config.Annotationparser.OverriddenValue<object>();

        internal Net.TheVpc.Upa.Impl.Config.Annotationparser.OverriddenValue<string> overriddenDefaultValueStr = new Net.TheVpc.Upa.Impl.Config.Annotationparser.OverriddenValue<string>();

        internal Net.TheVpc.Upa.Impl.Config.Annotationparser.OverriddenValue<object> overriddenUnspecifiedValue = new Net.TheVpc.Upa.Impl.Config.Annotationparser.OverriddenValue<object>();

        internal Net.TheVpc.Upa.Impl.Config.Annotationparser.OverriddenValue<string> overriddenUnspecifiedValueStr = new Net.TheVpc.Upa.Impl.Config.Annotationparser.OverriddenValue<string>();

        internal Net.TheVpc.Upa.Impl.Config.Annotationparser.OverriddenValue<Net.TheVpc.Upa.Formula> overriddenPersistFormula = new Net.TheVpc.Upa.Impl.Config.Annotationparser.OverriddenValue<Net.TheVpc.Upa.Formula>();

        internal Net.TheVpc.Upa.Impl.Config.Annotationparser.OverriddenValue<Net.TheVpc.Upa.Formula> overriddenUpdateFormula = new Net.TheVpc.Upa.Impl.Config.Annotationparser.OverriddenValue<Net.TheVpc.Upa.Formula>();

        internal Net.TheVpc.Upa.Impl.Config.Annotationparser.OverriddenValue<System.Type> overriddenNativeType = new Net.TheVpc.Upa.Impl.Config.Annotationparser.OverriddenValue<System.Type>();

        internal Net.TheVpc.Upa.Impl.Config.Annotationparser.OverriddenValue<string> overriddenMinValue = new Net.TheVpc.Upa.Impl.Config.Annotationparser.OverriddenValue<string>();

        internal Net.TheVpc.Upa.Impl.Config.Annotationparser.OverriddenValue<string> overriddenMaxValue = new Net.TheVpc.Upa.Impl.Config.Annotationparser.OverriddenValue<string>();

        internal Net.TheVpc.Upa.Impl.Config.Annotationparser.OverriddenValue<string> overriddenLayout = new Net.TheVpc.Upa.Impl.Config.Annotationparser.OverriddenValue<string>();

        internal Net.TheVpc.Upa.Impl.Config.Annotationparser.OverriddenValue<int?> overriddenScale = new Net.TheVpc.Upa.Impl.Config.Annotationparser.OverriddenValue<int?>();

        internal Net.TheVpc.Upa.Impl.Config.Annotationparser.OverriddenValue<int?> overriddenPrec = new Net.TheVpc.Upa.Impl.Config.Annotationparser.OverriddenValue<int?>();

        internal Net.TheVpc.Upa.Impl.Config.Annotationparser.OverriddenValue<Net.TheVpc.Upa.Config.BoolEnum> overriddenNullable = new Net.TheVpc.Upa.Impl.Config.Annotationparser.OverriddenValue<Net.TheVpc.Upa.Config.BoolEnum>();

        internal Net.TheVpc.Upa.Impl.Config.Annotationparser.OverriddenValue<int?> overriddenPosition = new Net.TheVpc.Upa.Impl.Config.Annotationparser.OverriddenValue<int?>();

        internal Net.TheVpc.Upa.Impl.Config.Annotationparser.OverriddenValue<string> overriddenCharsAccepted = new Net.TheVpc.Upa.Impl.Config.Annotationparser.OverriddenValue<string>();

        internal Net.TheVpc.Upa.Impl.Config.Annotationparser.OverriddenValue<string> overriddenCharsRejected = new Net.TheVpc.Upa.Impl.Config.Annotationparser.OverriddenValue<string>();

        internal Net.TheVpc.Upa.Impl.Config.Annotationparser.OverriddenValue<string> overriddenFormat = new Net.TheVpc.Upa.Impl.Config.Annotationparser.OverriddenValue<string>();

        internal Net.TheVpc.Upa.Impl.Config.Annotationparser.OverriddenValue<string> overriddenPath = new Net.TheVpc.Upa.Impl.Config.Annotationparser.OverriddenValue<string>();

        internal Net.TheVpc.Upa.Impl.Config.Annotationparser.OverriddenValue<Net.TheVpc.Upa.PropertyAccessType> overriddenPropertyAccessType = new Net.TheVpc.Upa.Impl.Config.Annotationparser.OverriddenValue<Net.TheVpc.Upa.PropertyAccessType>();

        internal Net.TheVpc.Upa.Impl.Config.Annotationparser.OverriddenValue<Net.TheVpc.Upa.Types.TemporalOption> overriddenTemporal = new Net.TheVpc.Upa.Impl.Config.Annotationparser.OverriddenValue<Net.TheVpc.Upa.Types.TemporalOption>();

        internal Net.TheVpc.Upa.Impl.Config.Annotationparser.OverriddenValue<Net.TheVpc.Upa.AccessLevel> overriddenPersistAccessLevel = new Net.TheVpc.Upa.Impl.Config.Annotationparser.OverriddenValue<Net.TheVpc.Upa.AccessLevel>();

        internal Net.TheVpc.Upa.Impl.Config.Annotationparser.OverriddenValue<Net.TheVpc.Upa.AccessLevel> overriddenUpdateAccessLevel = new Net.TheVpc.Upa.Impl.Config.Annotationparser.OverriddenValue<Net.TheVpc.Upa.AccessLevel>();

        internal Net.TheVpc.Upa.Impl.Config.Annotationparser.OverriddenValue<Net.TheVpc.Upa.AccessLevel> overriddenRemoveAccessLevel = new Net.TheVpc.Upa.Impl.Config.Annotationparser.OverriddenValue<Net.TheVpc.Upa.AccessLevel>();

        internal Net.TheVpc.Upa.Impl.Config.Annotationparser.OverriddenValue<Net.TheVpc.Upa.AccessLevel> overriddenReadAccessLevel = new Net.TheVpc.Upa.Impl.Config.Annotationparser.OverriddenValue<Net.TheVpc.Upa.AccessLevel>();

        internal System.Collections.Generic.IList<Net.TheVpc.Upa.Property> parameterInfos = new System.Collections.Generic.List<Net.TheVpc.Upa.Property>();

        private System.Type nativeClass;

        internal bool nullableOk = true;

        internal Net.TheVpc.Upa.Impl.Config.Decorations.DecorationRepository repo;

        private System.Collections.Generic.IDictionary<string , object> fieldParams = new System.Collections.Generic.Dictionary<string , object>();

        internal FieldInfo(string name, Net.TheVpc.Upa.Impl.Config.Annotationparser.EntityInfo entityInfo, Net.TheVpc.Upa.Impl.Config.Decorations.DecorationRepository repo) {
            this.name = name;
            this.entityInfo = entityInfo;
            this.repo = repo;
            foreignInfo = new Net.TheVpc.Upa.Impl.Config.Annotationparser.RelationshipInfo(this, repo);
            anyFormula = new Net.TheVpc.Upa.Impl.Config.Annotationparser.AnyFormulaInfo(repo);
            FIELD_COMPARATOR = new Net.TheVpc.Upa.Impl.Config.Annotationparser.FieldComparator(repo);
        }

        public virtual System.Collections.Generic.IDictionary<string , object> GetFieldParams() {
            return fieldParams;
        }

        public virtual void PrepareFieldDesc(System.Collections.Generic.IDictionary<string , object> ctx, string entityName, System.Reflection.FieldInfo javaField) /* throws Net.TheVpc.Upa.Exceptions.UPAException, System.Exception, System.Exception, System.Exception */  {
            try {
                //javaField.SetAccessible(true);
                Net.TheVpc.Upa.Config.FieldDesc fieldDesc = null;
                if (Net.TheVpc.Upa.Impl.Util.PlatformUtils.IsStatic(javaField)) {
                    fieldDesc = (Net.TheVpc.Upa.Config.FieldDesc) javaField.GetValue(null);
                } else {
                    object fieldDescContainerInstance = Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,object>(ctx,"FieldDescContainerInstance." + ((javaField).DeclaringType).FullName);
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
                        fieldDesc = (Net.TheVpc.Upa.Config.FieldDesc) javaField.GetValue(fieldDescContainerInstance);
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
                    Net.TheVpc.Upa.Types.DataType type = fieldDesc.GetDataType();
                    if (type != null) {
                        overriddenDataType.SetBetterValue(type, processOrder);
                    }
                    Net.TheVpc.Upa.Formula _formula = fieldDesc.GetPersistFormula();
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

        public virtual void PrepareBaseDataType(System.Collections.Generic.IDictionary<string , object> ctx, string entityName) /* throws Net.TheVpc.Upa.Exceptions.UPAException, System.Exception, System.Exception, System.Exception */  {
            bool fieldTypeProcessed = false;
            string absoluteName = name;
            if ((nativeClass).IsEnum) {
                overriddenDataType.SetValue(new Net.TheVpc.Upa.Types.EnumType(nativeClass, nullableOk));
                fieldTypeProcessed = true;
            } else if (nativeClass.Equals(typeof(string))) {
                fieldTypeProcessed = true;
                int minInt = (Net.TheVpc.Upa.Impl.Config.Annotationparser.AnnotationParserUtils.ParseInt(overriddenMinValue, 0)).Value;
                int maxInt = (Net.TheVpc.Upa.Impl.Config.Annotationparser.AnnotationParserUtils.ParseInt(overriddenMaxValue, 255)).Value;
                string charsAcceptedOk = (overriddenCharsAccepted.specified && !System.Collections.Generic.EqualityComparer<string>.Default.Equals(overriddenCharsAccepted.@value,null) && (overriddenCharsAccepted.@value).Length > 0) ? overriddenCharsAccepted.@value : null;
                string charsRejectedOk = (overriddenCharsRejected.specified && !System.Collections.Generic.EqualityComparer<string>.Default.Equals(overriddenCharsRejected.@value,null) && (overriddenCharsRejected.@value).Length > 0) ? overriddenCharsRejected.@value : null;
                Net.TheVpc.Upa.Types.StringType s = new Net.TheVpc.Upa.Types.StringType(name, minInt, maxInt, nullableOk);
                if (charsAcceptedOk != null) {
                    s.AddValueValidator(new Net.TheVpc.Upa.Types.StringTypeCharValidator(charsAcceptedOk, true));
                }
                if (charsRejectedOk != null) {
                    s.AddValueValidator(new Net.TheVpc.Upa.Types.StringTypeCharValidator(charsRejectedOk, false));
                }
                overriddenDataType.SetValue(s);
            } else if (Net.TheVpc.Upa.Impl.Util.PlatformUtils.IsInt32(nativeClass)) {
                fieldTypeProcessed = true;
                int? min = Net.TheVpc.Upa.Impl.Config.Annotationparser.AnnotationParserUtils.ParseInt(overriddenMinValue, null);
                int? max = Net.TheVpc.Upa.Impl.Config.Annotationparser.AnnotationParserUtils.ParseInt(overriddenMaxValue, null);
                overriddenDataType.SetValue(new Net.TheVpc.Upa.Types.IntType(absoluteName, min, max, nullableOk, Net.TheVpc.Upa.Impl.Util.PlatformUtils.IsPrimitiveType(nativeClass)));
            } else if (Net.TheVpc.Upa.Impl.Util.PlatformUtils.IsInt8(nativeClass)) {
                fieldTypeProcessed = true;
                byte? min = Net.TheVpc.Upa.Impl.Config.Annotationparser.AnnotationParserUtils.ParseByte(overriddenMinValue, null);
                byte? max = Net.TheVpc.Upa.Impl.Config.Annotationparser.AnnotationParserUtils.ParseByte(overriddenMaxValue, null);
                overriddenDataType.SetValue(new Net.TheVpc.Upa.Types.ByteType(absoluteName, min, max, nullableOk, Net.TheVpc.Upa.Impl.Util.PlatformUtils.IsPrimitiveType(nativeClass)));
            } else if (Net.TheVpc.Upa.Impl.Util.PlatformUtils.IsInt16(nativeClass)) {
                fieldTypeProcessed = true;
                short? min = Net.TheVpc.Upa.Impl.Config.Annotationparser.AnnotationParserUtils.ParseShort(overriddenMinValue, null);
                short? max = Net.TheVpc.Upa.Impl.Config.Annotationparser.AnnotationParserUtils.ParseShort(overriddenMaxValue, null);
                overriddenDataType.SetValue(new Net.TheVpc.Upa.Types.ShortType(absoluteName, min, max, nullableOk, Net.TheVpc.Upa.Impl.Util.PlatformUtils.IsPrimitiveType(nativeClass)));
            } else if (Net.TheVpc.Upa.Impl.Util.PlatformUtils.IsInt64(nativeClass)) {
                fieldTypeProcessed = true;
                long? min = Net.TheVpc.Upa.Impl.Config.Annotationparser.AnnotationParserUtils.ParseLong(overriddenMinValue, null);
                long? max = Net.TheVpc.Upa.Impl.Config.Annotationparser.AnnotationParserUtils.ParseLong(overriddenMaxValue, null);
                overriddenDataType.SetValue(new Net.TheVpc.Upa.Types.LongType(absoluteName, min, max, nullableOk, Net.TheVpc.Upa.Impl.Util.PlatformUtils.IsPrimitiveType(nativeClass)));
            } else if (Net.TheVpc.Upa.Impl.Util.PlatformUtils.IsFloat32(nativeClass)) {
                fieldTypeProcessed = true;
                float? min = Net.TheVpc.Upa.Impl.Config.Annotationparser.AnnotationParserUtils.ParseFloat(overriddenMinValue, null);
                float? max = Net.TheVpc.Upa.Impl.Config.Annotationparser.AnnotationParserUtils.ParseFloat(overriddenMaxValue, null);
                int precOk = System.Int32.MaxValue;
                if (overriddenPrec.specified && (overriddenPrec.@value).Value > 0) {
                    precOk = (overriddenPrec.@value).Value;
                }
                int scaleOk = System.Int32.MaxValue;
                if (overriddenScale.specified && (overriddenScale.@value).Value > 0) {
                    scaleOk = (overriddenScale.@value).Value;
                }
                overriddenDataType.SetValue(new Net.TheVpc.Upa.Types.FloatType(absoluteName, min, max, scaleOk, precOk, nullableOk, Net.TheVpc.Upa.Impl.Util.PlatformUtils.IsPrimitiveType(nativeClass)));
            } else if (Net.TheVpc.Upa.Impl.Util.PlatformUtils.IsFloat64(nativeClass)) {
                fieldTypeProcessed = true;
                double? min = Net.TheVpc.Upa.Impl.Config.Annotationparser.AnnotationParserUtils.ParseDouble(overriddenMinValue, null);
                double? max = Net.TheVpc.Upa.Impl.Config.Annotationparser.AnnotationParserUtils.ParseDouble(overriddenMaxValue, null);
                int precOk = System.Int32.MaxValue;
                if (overriddenPrec.specified && (overriddenPrec.@value).Value > 0) {
                    precOk = (overriddenPrec.@value).Value;
                }
                int scaleOk = System.Int32.MaxValue;
                if (overriddenScale.specified && (overriddenScale.@value).Value > 0) {
                    scaleOk = (overriddenScale.@value).Value;
                }
                overriddenDataType.SetValue(new Net.TheVpc.Upa.Types.DoubleType(absoluteName, min, max, scaleOk, precOk, nullableOk, Net.TheVpc.Upa.Impl.Util.PlatformUtils.IsPrimitiveType(nativeClass)));
            } else if (Net.TheVpc.Upa.Impl.Util.PlatformUtils.IsAnyDate(nativeClass)) {
                fieldTypeProcessed = true;
                System.Type asType = nativeClass;
                if (overriddenTemporal.specified) {
                    asType = Net.TheVpc.Upa.Impl.Util.PlatformUtils.ToTemporalType(overriddenTemporal.@value, asType);
                }
                if (typeof(Net.TheVpc.Upa.Types.Year).IsAssignableFrom(asType)) {
                    try {
                        overriddenDataType.SetValue(new Net.TheVpc.Upa.Types.YearType(absoluteName, nativeClass, (Net.TheVpc.Upa.Types.Year) Net.TheVpc.Upa.Impl.Config.Annotationparser.AnnotationParserUtils.ParseDate(typeof(Net.TheVpc.Upa.Types.Year), overriddenMinValue, overriddenFormat), (Net.TheVpc.Upa.Types.Year) Net.TheVpc.Upa.Impl.Config.Annotationparser.AnnotationParserUtils.ParseDate(typeof(Net.TheVpc.Upa.Types.Year), overriddenMaxValue, overriddenFormat), nullableOk));
                    } catch (System.Exception e) {
                        throw new System.ArgumentException ("IllegalArgumentException", e);
                    }
                } else if (typeof(Net.TheVpc.Upa.Types.Month).IsAssignableFrom(asType)) {
                    try {
                        overriddenDataType.SetValue(new Net.TheVpc.Upa.Types.MonthType(absoluteName, nativeClass, (Net.TheVpc.Upa.Types.Month) Net.TheVpc.Upa.Impl.Config.Annotationparser.AnnotationParserUtils.ParseDate(typeof(Net.TheVpc.Upa.Types.Month), overriddenMinValue, overriddenFormat), (Net.TheVpc.Upa.Types.Month) Net.TheVpc.Upa.Impl.Config.Annotationparser.AnnotationParserUtils.ParseDate(typeof(Net.TheVpc.Upa.Types.Month), overriddenMaxValue, overriddenFormat), nullableOk));
                    } catch (System.Exception e) {
                        throw new System.ArgumentException ("IllegalArgumentException", e);
                    }
                } else if (typeof(Net.TheVpc.Upa.Types.Date).IsAssignableFrom(asType)) {
                    try {
                        overriddenDataType.SetValue(new Net.TheVpc.Upa.Types.DateType(absoluteName, nativeClass, (Net.TheVpc.Upa.Types.Date) Net.TheVpc.Upa.Impl.Config.Annotationparser.AnnotationParserUtils.ParseDate(typeof(Net.TheVpc.Upa.Types.Date), overriddenMinValue, overriddenFormat), (Net.TheVpc.Upa.Types.Date) Net.TheVpc.Upa.Impl.Config.Annotationparser.AnnotationParserUtils.ParseDate(typeof(Net.TheVpc.Upa.Types.Date), overriddenMaxValue, overriddenFormat), nullableOk));
                    } catch (System.Exception e) {
                        throw new System.ArgumentException ("IllegalArgumentException", e);
                    }
                } else if (typeof(Net.TheVpc.Upa.Types.DateTime).IsAssignableFrom(asType)) {
                    try {
                        overriddenDataType.SetValue(new Net.TheVpc.Upa.Types.DateTimeType(absoluteName, nativeClass, (Net.TheVpc.Upa.Types.DateTime) Net.TheVpc.Upa.Impl.Config.Annotationparser.AnnotationParserUtils.ParseDate(typeof(Net.TheVpc.Upa.Types.DateTime), overriddenMinValue, overriddenFormat), (Net.TheVpc.Upa.Types.DateTime) Net.TheVpc.Upa.Impl.Config.Annotationparser.AnnotationParserUtils.ParseDate(typeof(Net.TheVpc.Upa.Types.DateTime), overriddenMaxValue, overriddenFormat), nullableOk));
                    } catch (System.Exception e) {
                        throw new System.ArgumentException ("IllegalArgumentException", e);
                    }
                } else if (typeof(Net.TheVpc.Upa.Types.Timestamp).IsAssignableFrom(asType) || typeof(Net.TheVpc.Upa.Types.Timestamp).IsAssignableFrom(asType)) {
                    try {
                        overriddenDataType.SetValue(new Net.TheVpc.Upa.Types.TimestampType(absoluteName, nativeClass, (Net.TheVpc.Upa.Types.Timestamp) Net.TheVpc.Upa.Impl.Config.Annotationparser.AnnotationParserUtils.ParseDate(typeof(Net.TheVpc.Upa.Types.Timestamp), overriddenMinValue, overriddenFormat), (Net.TheVpc.Upa.Types.Timestamp) Net.TheVpc.Upa.Impl.Config.Annotationparser.AnnotationParserUtils.ParseDate(typeof(Net.TheVpc.Upa.Types.Timestamp), overriddenMaxValue, overriddenFormat), nullableOk));
                    } catch (System.Exception e) {
                        throw new System.ArgumentException ("IllegalArgumentException", e);
                    }
                } else if (typeof(Net.TheVpc.Upa.Types.Time).IsAssignableFrom(asType)) {
                    try {
                        overriddenDataType.SetValue(new Net.TheVpc.Upa.Types.TimeType(absoluteName, nativeClass, (Net.TheVpc.Upa.Types.Time) Net.TheVpc.Upa.Impl.Config.Annotationparser.AnnotationParserUtils.ParseDate(typeof(Net.TheVpc.Upa.Types.Time), overriddenMinValue, overriddenFormat), (Net.TheVpc.Upa.Types.Time) Net.TheVpc.Upa.Impl.Config.Annotationparser.AnnotationParserUtils.ParseDate(typeof(Net.TheVpc.Upa.Types.Time), overriddenMaxValue, overriddenFormat), nullableOk));
                    } catch (System.Exception e) {
                        throw new System.ArgumentException ("IllegalArgumentException", e);
                    }
                } else if (typeof(Net.TheVpc.Upa.Types.Date).IsAssignableFrom(asType)) {
                    try {
                        overriddenDataType.SetValue(new Net.TheVpc.Upa.Types.DateType(absoluteName, nativeClass, (Net.TheVpc.Upa.Types.Date) Net.TheVpc.Upa.Impl.Config.Annotationparser.AnnotationParserUtils.ParseDate(typeof(Net.TheVpc.Upa.Types.Date), overriddenMinValue, overriddenFormat), (Net.TheVpc.Upa.Types.Date) Net.TheVpc.Upa.Impl.Config.Annotationparser.AnnotationParserUtils.ParseDate(typeof(Net.TheVpc.Upa.Types.Date), overriddenMaxValue, overriddenFormat), nullableOk));
                    } catch (System.Exception e) {
                        throw new System.ArgumentException ("IllegalArgumentException", e);
                    }
                } else {
                    try {
                        overriddenDataType.SetValue(new Net.TheVpc.Upa.Types.DateTimeType(absoluteName, nativeClass, (Net.TheVpc.Upa.Types.DateTime) Net.TheVpc.Upa.Impl.Config.Annotationparser.AnnotationParserUtils.ParseDate(typeof(Net.TheVpc.Upa.Types.DateTime), overriddenMinValue, overriddenFormat), (Net.TheVpc.Upa.Types.DateTime) Net.TheVpc.Upa.Impl.Config.Annotationparser.AnnotationParserUtils.ParseDate(typeof(Net.TheVpc.Upa.Types.DateTime), overriddenMaxValue, overriddenFormat), nullableOk));
                    } catch (System.Exception e) {
                        throw new System.ArgumentException ("IllegalArgumentException", e);
                    }
                }
            } else if (typeof(bool).Equals(nativeClass)) {
                fieldTypeProcessed = true;
                overriddenDataType.SetValue(new Net.TheVpc.Upa.Types.BooleanType(absoluteName, nullableOk, true));
            } else if (typeof(bool?).Equals(nativeClass)) {
                fieldTypeProcessed = true;
                overriddenDataType.SetValue(new Net.TheVpc.Upa.Types.BooleanType(absoluteName, nullableOk, false));
            } else if (typeof(Net.TheVpc.Upa.Types.FileData).Equals(nativeClass)) {
                fieldTypeProcessed = true;
                System.Collections.Generic.List<string> extensions = new System.Collections.Generic.List<string>();
                if (overriddenFormat.specified && !System.Collections.Generic.EqualityComparer<string>.Default.Equals(overriddenFormat.@value,null) && (overriddenFormat.@value).Length > 0) {
                    foreach (string ext in System.Text.RegularExpressions.Regex.Split(overriddenFormat.@value,";")) {
                        extensions.Add(ext.Trim());
                    }
                }
                overriddenDataType.SetValue(new Net.TheVpc.Upa.Types.FileType(absoluteName, Net.TheVpc.Upa.Impl.Config.Annotationparser.AnnotationParserUtils.ParseInt(overriddenMaxValue, System.Int32.MaxValue), (extensions.Count==0) ? null : extensions.ToArray(), nullableOk));
            } else if (typeof(byte[]).Equals(nativeClass)) {
                fieldTypeProcessed = true;
                overriddenDataType.SetValue(new Net.TheVpc.Upa.Types.ByteArrayType(absoluteName, false, Net.TheVpc.Upa.Impl.Config.Annotationparser.AnnotationParserUtils.ParseInt(overriddenMaxValue, System.Int32.MaxValue), nullableOk));
            } else if (typeof(byte?[]).Equals(nativeClass)) {
                fieldTypeProcessed = true;
                overriddenDataType.SetValue(new Net.TheVpc.Upa.Types.ByteArrayType(absoluteName, true, Net.TheVpc.Upa.Impl.Config.Annotationparser.AnnotationParserUtils.ParseInt(overriddenMaxValue, System.Int32.MaxValue), nullableOk));
            } else if (typeof(char[]).Equals(nativeClass)) {
                fieldTypeProcessed = true;
                overriddenDataType.SetValue(new Net.TheVpc.Upa.Types.CharArrayType(absoluteName, false, Net.TheVpc.Upa.Impl.Config.Annotationparser.AnnotationParserUtils.ParseInt(overriddenMaxValue, System.Int32.MaxValue), nullableOk));
            } else if (typeof(char?[]).Equals(nativeClass)) {
                fieldTypeProcessed = true;
                overriddenDataType.SetValue(new Net.TheVpc.Upa.Types.CharArrayType(absoluteName, true, Net.TheVpc.Upa.Impl.Config.Annotationparser.AnnotationParserUtils.ParseInt(overriddenMaxValue, System.Int32.MaxValue), nullableOk));
            } else {
                // BigDecimal is ignored because not supported in C#
                if (!fieldTypeProcessed && Net.TheVpc.Upa.Impl.Util.PlatformUtils.IsBigInt(nativeClass)) {
                    fieldTypeProcessed = true;
                    System.Numerics.BigInteger? minBigInteger = Net.TheVpc.Upa.Impl.Config.Annotationparser.AnnotationParserUtils.ParseBigInteger(overriddenMinValue, null);
                    System.Numerics.BigInteger? maxBigInteger = Net.TheVpc.Upa.Impl.Config.Annotationparser.AnnotationParserUtils.ParseBigInteger(overriddenMaxValue, null);
                    overriddenDataType.SetValue(new Net.TheVpc.Upa.Types.BigIntType(absoluteName, minBigInteger, maxBigInteger, nullableOk));
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
                    Net.TheVpc.Upa.Types.SerializableType ttype = new Net.TheVpc.Upa.Types.SerializableType(name, nativeClass, nullableOk);
                    overriddenDataType.SetValue(ttype);
                } else {
                    Net.TheVpc.Upa.Impl.SerializableOrManyToOneType ttype = new Net.TheVpc.Upa.Impl.SerializableOrManyToOneType(name, nativeClass, nullableOk);
                    overriddenDataType.SetValue(ttype);
                }
            }
        }

        public virtual void Prepare(System.Collections.Generic.IDictionary<string , object> ctx, string entityName) /* throws Net.TheVpc.Upa.Exceptions.UPAException, System.Exception, System.Exception, System.Exception */  {
            modifiers = Net.TheVpc.Upa.FlagSets.NoneOf<Net.TheVpc.Upa.UserFieldModifier>();
            excludeModifiers = Net.TheVpc.Upa.FlagSets.NoneOf<Net.TheVpc.Upa.UserFieldModifier>();
            //////////////////////////////////////////////////////
            // Process all fields
            if ((fields).Count > 1) {
                Net.TheVpc.Upa.Impl.FwkConvertUtils.ListSort(fields, FIELD_COMPARATOR);
            }
            foreach (System.Reflection.FieldInfo someField in fields) {
                Net.TheVpc.Upa.Config.Decoration searchDeco = repo.GetFieldDecoration(someField, typeof(Net.TheVpc.Upa.Config.Search));
                if (searchDeco != null) {
                    overriddenSearchOperator.SetBetterValue(System.Collections.Generic.EqualityComparer<Net.TheVpc.Upa.SearchOperator>.Default.Equals(searchDeco.GetEnum<Net.TheVpc.Upa.SearchOperator>("op", typeof(Net.TheVpc.Upa.SearchOperator)),Net.TheVpc.Upa.SearchOperator.DEFAULT) ? Net.TheVpc.Upa.Impl.Util.PlatformUtils.GetUndefinedValue<Net.TheVpc.Upa.SearchOperator>(typeof(Net.TheVpc.Upa.SearchOperator)) : searchDeco.GetEnum<Net.TheVpc.Upa.SearchOperator>("op", typeof(Net.TheVpc.Upa.SearchOperator)), searchDeco.GetConfig().GetOrder());
                }
                foreach (Net.TheVpc.Upa.Config.Index indexAnn in FindIndexAnnotation(someField)) {
                    System.Collections.Generic.IList<string> rr = new System.Collections.Generic.List<string>();
                    rr.Add((someField).Name);
                    Net.TheVpc.Upa.Impl.FwkConvertUtils.ListAddRange(rr, new System.Collections.Generic.List<string>(indexAnn.Fields));
                    entityInfo.AddIndex(indexAnn.Name, rr, indexAnn.Unique, indexAnn.Config.Order);
                }
                Net.TheVpc.Upa.Config.Decoration temporalAnn = repo.GetFieldDecoration(someField, typeof(Net.TheVpc.Upa.Config.Temporal));
                if (temporalAnn != null && temporalAnn.GetConfig().GetOrder() != System.Int32.MinValue) {
                    overriddenTemporal.SetBetterValue(temporalAnn.GetEnum<Net.TheVpc.Upa.Types.TemporalOption>("value", typeof(Net.TheVpc.Upa.Types.TemporalOption)), temporalAnn.GetConfig().GetOrder());
                }
                Net.TheVpc.Upa.Config.Decoration propertyDeco = repo.GetFieldDecoration(someField, typeof(Net.TheVpc.Upa.Config.Property));
                if (propertyDeco != null) {
                    parameterInfos.Add(new Net.TheVpc.Upa.Property(propertyDeco.GetString("name"), propertyDeco.GetString("value"), propertyDeco.GetString("type"), propertyDeco.GetString("format")));
                }
                Net.TheVpc.Upa.Config.Decoration propertiesDeco = repo.GetFieldDecoration(someField, typeof(Net.TheVpc.Upa.Config.Properties));
                if (propertiesDeco != null) {
                    foreach (Net.TheVpc.Upa.Config.DecorationValue p in propertiesDeco.GetArray("value")) {
                        //p of type Net.TheVpc.Upa.config.Property
                        Net.TheVpc.Upa.Config.Decoration pp = (Net.TheVpc.Upa.Config.Decoration) p;
                        parameterInfos.Add(new Net.TheVpc.Upa.Property(pp.GetString("name"), pp.GetString("value"), pp.GetString("type"), pp.GetString("format")));
                    }
                }
                Net.TheVpc.Upa.Config.Decoration pathDeco = repo.GetFieldDecoration(someField, typeof(Net.TheVpc.Upa.Config.Path));
                if (pathDeco != null) {
                    Net.TheVpc.Upa.Impl.Config.Annotationparser.AnnotationParserUtils.ValidStr(pathDeco.GetString("value"), overriddenPath, pathDeco.GetConfig().GetOrder());
                }
                if (someField.GetType().Equals(typeof(Net.TheVpc.Upa.Config.FieldDesc))) {
                    PrepareFieldDesc(ctx, entityName, someField);
                } else {
                    //default configOrder for DAL is 100
                    overriddenNativeType.SetBetterValue(someField.GetType(), 100);
                }
                Net.TheVpc.Upa.Config.Decoration fieldDeco = repo.GetFieldDecoration(someField, typeof(Net.TheVpc.Upa.Config.Field));
                if (fieldDeco != null) {
                    modifiers = modifiers.AddAll(new System.Collections.Generic.List<Net.TheVpc.Upa.UserFieldModifier>(fieldDeco.GetPrimitiveArray<Net.TheVpc.Upa.UserFieldModifier>("modifiers", typeof(Net.TheVpc.Upa.UserFieldModifier))));
                    excludeModifiers = excludeModifiers.AddAll(new System.Collections.Generic.List<Net.TheVpc.Upa.UserFieldModifier>(fieldDeco.GetPrimitiveArray<Net.TheVpc.Upa.UserFieldModifier>("excludeModifiers", typeof(Net.TheVpc.Upa.UserFieldModifier))));
                    int processOrder = fieldDeco.GetConfig().GetOrder();
                    Net.TheVpc.Upa.Impl.Config.Annotationparser.AnnotationParserUtils.ValidClass(fieldDeco.GetType("type"), overriddenNativeType, typeof(object), processOrder);
                    Net.TheVpc.Upa.Impl.Config.Annotationparser.AnnotationParserUtils.ValidStr(fieldDeco.GetString("min"), overriddenMinValue, processOrder);
                    Net.TheVpc.Upa.Impl.Config.Annotationparser.AnnotationParserUtils.ValidStr(fieldDeco.GetString("max"), overriddenMaxValue, processOrder);
                    Net.TheVpc.Upa.Impl.Config.Annotationparser.AnnotationParserUtils.ValidStr(fieldDeco.GetString("layout"), overriddenLayout, processOrder);
                    Net.TheVpc.Upa.Impl.Config.Annotationparser.AnnotationParserUtils.ValidInt(fieldDeco.GetInt("scale"), overriddenScale, -1, processOrder);
                    Net.TheVpc.Upa.Impl.Config.Annotationparser.AnnotationParserUtils.ValidInt(fieldDeco.GetInt("precision"), overriddenPrec, -1, processOrder);
                    if (!System.Collections.Generic.EqualityComparer<Net.TheVpc.Upa.Config.BoolEnum>.Default.Equals(fieldDeco.GetEnum<Net.TheVpc.Upa.Config.BoolEnum>("nullable", typeof(Net.TheVpc.Upa.Config.BoolEnum)),Net.TheVpc.Upa.Config.BoolEnum.UNDEFINED)) {
                        overriddenNullable.SetBetterValue(fieldDeco.GetEnum<Net.TheVpc.Upa.Config.BoolEnum>("nullable", typeof(Net.TheVpc.Upa.Config.BoolEnum)), processOrder);
                    }
                    if (fieldDeco.GetInt("position") != System.Int32.MinValue) {
                        overriddenPosition.SetBetterValue(fieldDeco.GetInt("position"), processOrder);
                    }
                    //                if (fieldDeco.getEnum("end", BoolEnum.class) != BoolEnum.UNDEFINED) {
                    //                    overriddenEnd.setBetterValue(fieldDeco.getEnum("nullable", BoolEnum.class), processOrder);
                    //                }
                    if (!Net.TheVpc.Upa.Impl.Util.PlatformUtils.IsUndefinedValue<Net.TheVpc.Upa.AccessLevel>(typeof(Net.TheVpc.Upa.AccessLevel), fieldDeco.GetEnum<Net.TheVpc.Upa.AccessLevel>("persistAccessLevel", typeof(Net.TheVpc.Upa.AccessLevel)))) {
                        overriddenPersistAccessLevel.SetBetterValue(fieldDeco.GetEnum<Net.TheVpc.Upa.AccessLevel>("persistAccessLevel", typeof(Net.TheVpc.Upa.AccessLevel)), processOrder);
                    }
                    if (!Net.TheVpc.Upa.Impl.Util.PlatformUtils.IsUndefinedValue<Net.TheVpc.Upa.AccessLevel>(typeof(Net.TheVpc.Upa.AccessLevel), fieldDeco.GetEnum<Net.TheVpc.Upa.AccessLevel>("updateAccessLevel", typeof(Net.TheVpc.Upa.AccessLevel)))) {
                        overriddenUpdateAccessLevel.SetBetterValue(fieldDeco.GetEnum<Net.TheVpc.Upa.AccessLevel>("updateAccessLevel", typeof(Net.TheVpc.Upa.AccessLevel)), processOrder);
                    }
                    if (!Net.TheVpc.Upa.Impl.Util.PlatformUtils.IsUndefinedValue<Net.TheVpc.Upa.AccessLevel>(typeof(Net.TheVpc.Upa.AccessLevel), fieldDeco.GetEnum<Net.TheVpc.Upa.AccessLevel>("removeAccessLevel", typeof(Net.TheVpc.Upa.AccessLevel)))) {
                        overriddenRemoveAccessLevel.SetBetterValue(fieldDeco.GetEnum<Net.TheVpc.Upa.AccessLevel>("removeAccessLevel", typeof(Net.TheVpc.Upa.AccessLevel)), processOrder);
                    }
                    if (!Net.TheVpc.Upa.Impl.Util.PlatformUtils.IsUndefinedValue<Net.TheVpc.Upa.AccessLevel>(typeof(Net.TheVpc.Upa.AccessLevel), fieldDeco.GetEnum<Net.TheVpc.Upa.AccessLevel>("readAccessLevel", typeof(Net.TheVpc.Upa.AccessLevel)))) {
                        overriddenReadAccessLevel.SetBetterValue(fieldDeco.GetEnum<Net.TheVpc.Upa.AccessLevel>("readAccessLevel", typeof(Net.TheVpc.Upa.AccessLevel)), processOrder);
                    }
                    Net.TheVpc.Upa.Impl.Config.Annotationparser.AnnotationParserUtils.ValidStr(fieldDeco.GetString("charsAccepted"), overriddenCharsAccepted, processOrder);
                    Net.TheVpc.Upa.Impl.Config.Annotationparser.AnnotationParserUtils.ValidStr(fieldDeco.GetString("charsRejected"), overriddenCharsRejected, processOrder);
                    Net.TheVpc.Upa.Impl.Config.Annotationparser.AnnotationParserUtils.ValidStr(fieldDeco.GetString("format"), overriddenFormat, processOrder);
                    Net.TheVpc.Upa.Impl.Config.Annotationparser.AnnotationParserUtils.ValidStr(fieldDeco.GetString("path"), overriddenPath, processOrder);
                    Net.TheVpc.Upa.Impl.Config.Annotationparser.AnnotationParserUtils.ValidStr(fieldDeco.GetString("defaultValue"), overriddenDefaultValueStr, processOrder);
                    Net.TheVpc.Upa.Impl.Config.Annotationparser.AnnotationParserUtils.ValidStr(fieldDeco.GetString("unspecifiedValue"), overriddenUnspecifiedValueStr, processOrder);
                }
                Net.TheVpc.Upa.Config.Decoration mainDeco = repo.GetFieldDecoration(someField, typeof(Net.TheVpc.Upa.Config.Main));
                if (mainDeco != null) {
                    modifiers = modifiers.Add(Net.TheVpc.Upa.UserFieldModifier.MAIN);
                }
                Net.TheVpc.Upa.Config.Decoration summaryDeco = repo.GetFieldDecoration(someField, typeof(Net.TheVpc.Upa.Config.Summary));
                if (summaryDeco != null) {
                    modifiers = modifiers.Add(Net.TheVpc.Upa.UserFieldModifier.SUMMARY);
                }
                Net.TheVpc.Upa.Config.Decoration uniqueDeco = repo.GetFieldDecoration(someField, typeof(Net.TheVpc.Upa.Config.Unique));
                if (uniqueDeco != null) {
                    modifiers = modifiers.Add(Net.TheVpc.Upa.UserFieldModifier.UNIQUE);
                }
                Net.TheVpc.Upa.Config.Decoration annID = repo.GetFieldDecoration(someField, typeof(Net.TheVpc.Upa.Config.Id));
                if (annID != null) {
                    modifiers = modifiers.Add(Net.TheVpc.Upa.UserFieldModifier.ID);
                }
                Net.TheVpc.Upa.Config.Decoration propertyAccess = repo.GetFieldDecoration(someField, typeof(Net.TheVpc.Upa.PropertyAccess));
                if (propertyAccess != null) {
                    overriddenPropertyAccessType.SetBetterValue(propertyAccess.GetEnum<Net.TheVpc.Upa.PropertyAccessType>("value", typeof(Net.TheVpc.Upa.PropertyAccessType)), propertyAccess.GetConfig().GetOrder());
                }
            }
            nativeClass = overriddenNativeType.GetValue(fields[0].GetType());
            foreach (Net.TheVpc.Upa.Property parameterInfo in parameterInfos) {
                fieldParams[parameterInfo.GetName()]=Net.TheVpc.Upa.Impl.Util.UPAUtils.CreateValue(parameterInfo);
            }
            if (overriddenNullable.specified && (!System.Collections.Generic.EqualityComparer<Net.TheVpc.Upa.Config.BoolEnum>.Default.Equals(overriddenNullable.@value,Net.TheVpc.Upa.Config.BoolEnum.UNDEFINED))) {
                nullableOk = overriddenNullable.@value.Equals(Net.TheVpc.Upa.Config.BoolEnum.TRUE);
            }
            if (!Net.TheVpc.Upa.Impl.Util.PlatformUtils.IsNullableType(nativeClass) || modifiers.Contains(Net.TheVpc.Upa.UserFieldModifier.ID)) {
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
            foreach (System.Collections.Generic.KeyValuePair<Net.TheVpc.Upa.FormulaType , object> ee in new System.Collections.Generic.HashSet<System.Collections.Generic.KeyValuePair<Net.TheVpc.Upa.FormulaType,object>>(anyFormula.all)) {
                PrepareFormula(ctx, entityName, (ee).Key, (ee).Value);
            }
            if (foreignInfo.IsSpecified()) {
                if (foreignInfo.GetTargetEntity() == null && foreignInfo.GetTargetEntityType() == null) {
                    throw new Net.TheVpc.Upa.Exceptions.UPAException("MissingManyToOneTargetEntity", entityInfo.name + "." + name);
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
            if (overriddenPersistAccessLevel.specified && !Net.TheVpc.Upa.Impl.Util.PlatformUtils.IsUndefinedValue<Net.TheVpc.Upa.AccessLevel>(typeof(Net.TheVpc.Upa.AccessLevel), overriddenPersistAccessLevel.@value)) {
                this.persistAccessLevel = overriddenPersistAccessLevel.@value;
            }
            if (overriddenUpdateAccessLevel.specified && !Net.TheVpc.Upa.Impl.Util.PlatformUtils.IsUndefinedValue<Net.TheVpc.Upa.AccessLevel>(typeof(Net.TheVpc.Upa.AccessLevel), overriddenUpdateAccessLevel.@value)) {
                this.updateAccessLevel = overriddenUpdateAccessLevel.@value;
            }
            if (overriddenReadAccessLevel.specified && !Net.TheVpc.Upa.Impl.Util.PlatformUtils.IsUndefinedValue<Net.TheVpc.Upa.AccessLevel>(typeof(Net.TheVpc.Upa.AccessLevel), overriddenReadAccessLevel.@value)) {
                this.readAccessLevel = overriddenReadAccessLevel.@value;
            }
        }

        public virtual void Build(System.Collections.Generic.IDictionary<string , object> ctx, string entityName) {
            if (buildForeign) {
                if (Net.TheVpc.Upa.Impl.Util.UPAUtils.IsSimpleFieldType(nativeClass)) {
                    int length = foreignInfo.GetMappedTo() == null ? 0 : foreignInfo.GetMappedTo().Length;
                    if (length == 1) {
                        Net.TheVpc.Upa.Impl.Config.Annotationparser.FieldInfo f = Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,Net.TheVpc.Upa.Impl.Config.Annotationparser.FieldInfo>(entityInfo.fieldsMap,foreignInfo.GetMappedTo()[0]);
                        if (f == null) {
                            throw new System.ArgumentException ("Field " + foreignInfo.GetMappedTo()[0] + " not found");
                        }
                        if (!f.foreignInfo.IsSpecified()) {
                            Net.TheVpc.Upa.Types.ManyToOneType manyToOneType = new Net.TheVpc.Upa.Types.ManyToOneType(f.name, f.nativeClass, foreignInfo.GetTargetEntity(), false, f.nullableOk);
                            f.overriddenDataType.SetValue(manyToOneType);
                        } else {
                            throw new System.ArgumentException (f.name + " already mapped by " + name + ". Should not define relations on its own.");
                        }
                    } else if (length > 1) {
                        throw new System.ArgumentException ("Illegal mapping for " + name);
                    }
                }
            }
            if (!overriddenDataType.specified || System.Collections.Generic.EqualityComparer<Net.TheVpc.Upa.Types.DataType>.Default.Equals(overriddenDataType.@value,null)) {
                System.Text.StringBuilder err = new System.Text.StringBuilder();
                err.Append("Field Type could not be resolved for field ").Append(name).Append("(entity ").Append(entityName).Append(")\n");
                err.Append("Scope Fields are ").Append(fields).Append("\n");
                log.TraceEvent(System.Diagnostics.TraceEventType.Warning,90,Net.TheVpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter(err.ToString(),null));
                valid = false;
                return;
            }
            if (overriddenDefaultValueStr.specified && (!overriddenDefaultValue.specified || overriddenDefaultValueStr.order > overriddenDefaultValue.order)) {
                try {
                    overriddenDefaultValue.SetBetterValue(Net.TheVpc.Upa.Impl.Config.Annotationparser.AnnotationParserUtils.ParseStringValue(overriddenDefaultValueStr.@value, overriddenDataType.@value, null), overriddenDefaultValue.order);
                } catch (System.Exception e) {
                    throw new System.Exception("Unable to parse default value for " + entityName + "." + name, e);
                }
            }
            if (overriddenDefaultValue.specified) {
                this.defaultObject = (overriddenDefaultValue.@value);
            }
            if (overriddenUnspecifiedValueStr.specified && (!overriddenUnspecifiedValue.specified || overriddenUnspecifiedValueStr.order > overriddenUnspecifiedValue.order)) {
                try {
                    overriddenUnspecifiedValue.SetBetterValue(Net.TheVpc.Upa.Impl.Config.Annotationparser.AnnotationParserUtils.ParseStringValue(overriddenUnspecifiedValueStr.@value, overriddenDataType.@value, Net.TheVpc.Upa.UnspecifiedValue.DEFAULT), overriddenUnspecifiedValue.order);
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

        public virtual Net.TheVpc.Upa.Impl.Config.Annotationparser.RelationshipInfo GetForeignInfo() {
            return foreignInfo;
        }

        public virtual Net.TheVpc.Upa.Impl.Config.Annotationparser.EntityInfo GetEntityInfo() {
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

        public virtual Net.TheVpc.Upa.Impl.Config.Annotationparser.AnyFormulaInfo GetAnyFormula() {
            return anyFormula;
        }

        public virtual Net.TheVpc.Upa.Types.DataType GetDataType() {
            return type;
        }

        public virtual Net.TheVpc.Upa.Formula GetPersistFormula() {
            return persistFormula;
        }

        public virtual Net.TheVpc.Upa.Formula GetUpdateFormula() {
            return updateFormula;
        }

        public virtual Net.TheVpc.Upa.Formula GetSelectFormula() {
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

        public virtual Net.TheVpc.Upa.FlagSet<Net.TheVpc.Upa.UserFieldModifier> GetUserFieldModifiers() {
            return modifiers;
        }

        public virtual Net.TheVpc.Upa.FlagSet<Net.TheVpc.Upa.UserFieldModifier> GetUserExcludeModifiers() {
            return excludeModifiers;
        }

        public virtual Net.TheVpc.Upa.AccessLevel GetPersistAccessLevel() {
            return persistAccessLevel;
        }

        public virtual Net.TheVpc.Upa.AccessLevel GetUpdateAccessLevel() {
            return updateAccessLevel;
        }

        public virtual Net.TheVpc.Upa.AccessLevel GetReadAccessLevel() {
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

        private System.Collections.Generic.IList<Net.TheVpc.Upa.Config.Index> FindIndexAnnotation(System.Reflection.FieldInfo javaField) {
            System.Collections.Generic.IList<Net.TheVpc.Upa.Config.Index> list = new System.Collections.Generic.List<Net.TheVpc.Upa.Config.Index>();
            Net.TheVpc.Upa.Config.Index indexAnn = (Net.TheVpc.Upa.Config.Index) repo.GetFieldDecoration(javaField, typeof(Net.TheVpc.Upa.Config.Index));
            if (indexAnn != null) {
                list.Add(indexAnn);
            }
            Net.TheVpc.Upa.Config.Indexes indexAnnAll = (Net.TheVpc.Upa.Config.Indexes) repo.GetFieldDecoration(javaField, typeof(Net.TheVpc.Upa.Config.Indexes));
            if (indexAnnAll != null) {
                foreach (Net.TheVpc.Upa.Config.Index index in indexAnnAll.Value) {
                    if (indexAnn != null) {
                        list.Add(index);
                    }
                }
            }
            return list;
        }

        public virtual Net.TheVpc.Upa.Types.DataTypeTransformConfig[] GetTypeTransform() {
            if (overriddenTransform.specified) {
                return overriddenTransform.@value;
            }
            return null;
        }


        public override string ToString() {
            return "FieldInfo{" + "name=" + name + ", fields=" + fields + ", type=" + type + '}';
        }

        private void PrepareFormula(System.Collections.Generic.IDictionary<string , object> ctx, string entityName, Net.TheVpc.Upa.FormulaType t, object o) {
            Net.TheVpc.Upa.Formula ff = null;
            int order = 0;
            if (o is Net.TheVpc.Upa.Impl.Config.Annotationparser.FormulaInfo) {
                Net.TheVpc.Upa.Impl.Config.Annotationparser.FormulaInfo formulaInfo = (Net.TheVpc.Upa.Impl.Config.Annotationparser.FormulaInfo) o;
                if (formulaInfo.specified) {
                    if (formulaInfo.type != null) {
                        try {
                            ff = ((Net.TheVpc.Upa.Formula)System.Activator.CreateInstance(formulaInfo.type));
                        } catch (System.Exception e) {
                            throw new System.Exception("RuntimeException", e);
                        }
                    } else if (formulaInfo.expression != null) {
                        ff = (new Net.TheVpc.Upa.ExpressionFormula(formulaInfo.expression));
                    }
                    if (formulaInfo.order != null) {
                        order = (formulaInfo.order).Value;
                    }
                }
            } else if (o is Net.TheVpc.Upa.Impl.Config.Annotationparser.SequenceInfo) {
                Net.TheVpc.Upa.Impl.Config.Annotationparser.SequenceInfo formulaInfo = (Net.TheVpc.Upa.Impl.Config.Annotationparser.SequenceInfo) o;
                if (formulaInfo.specified) {
                    ff = new Net.TheVpc.Upa.Sequence(formulaInfo.strategy == default(Net.TheVpc.Upa.SequenceStrategy) ? Net.TheVpc.Upa.SequenceStrategy.AUTO : formulaInfo.strategy, formulaInfo.initialValue == null ? ((Net.TheVpc.Upa.Formula)(1)) : formulaInfo.initialValue, formulaInfo.allocationSize == null ? ((Net.TheVpc.Upa.Formula)(50)) : formulaInfo.allocationSize, formulaInfo.name, formulaInfo.group, formulaInfo.format);
                }
            }
            switch(t) {
                case Net.TheVpc.Upa.FormulaType.PERSIST:
                    {
                        this.persistFormula = ff;
                        this.persistFormulaOrder = order;
                        break;
                    }
                case Net.TheVpc.Upa.FormulaType.UPDATE:
                    {
                        this.updateFormula = ff;
                        this.updateFormulaOrder = order;
                        break;
                    }
                case Net.TheVpc.Upa.FormulaType.LIVE:
                    {
                        this.selectFormula = ff;
                        this.selectFormulaOrder = order;
                        modifiers = modifiers.Add(Net.TheVpc.Upa.UserFieldModifier.LIVE);
                        break;
                    }
                case Net.TheVpc.Upa.FormulaType.COMPILED:
                    {
                        modifiers = modifiers.Add(Net.TheVpc.Upa.UserFieldModifier.COMPILED);
                        this.selectFormula = ff;
                        this.selectFormulaOrder = order;
                        break;
                    }
            }
        }

        private void PreparePeristentDataType(System.Collections.Generic.IDictionary<string , object> ctx, string entityName) {
            foreach (System.Reflection.FieldInfo javaField in fields) {
                System.Collections.Generic.IList<Net.TheVpc.Upa.Types.DataTypeTransformConfig> transforms = new System.Collections.Generic.List<Net.TheVpc.Upa.Types.DataTypeTransformConfig>();
                Net.TheVpc.Upa.Config.ConfigInfo ci = null;
                foreach (Net.TheVpc.Upa.Config.Decoration fieldDecoration in repo.GetFieldDecorations(javaField)) {
                    if (fieldDecoration.GetName().Equals((typeof(Net.TheVpc.Upa.Config.Password)).FullName)) {
                        if (ci == null) {
                            ci = fieldDecoration.GetConfig();
                        }
                        Net.TheVpc.Upa.PasswordTransformConfig p = new Net.TheVpc.Upa.PasswordTransformConfig();
                        if (System.Collections.Generic.EqualityComparer<Net.TheVpc.Upa.PasswordStrategyType>.Default.Equals(fieldDecoration.GetEnum<Net.TheVpc.Upa.PasswordStrategyType>("strategyType", typeof(Net.TheVpc.Upa.PasswordStrategyType)),Net.TheVpc.Upa.PasswordStrategyType.CUSTOM)) {
                            p.SetCipherStrategy(fieldDecoration.GetString("customStrategy"));
                        } else {
                            p.SetCipherStrategy(fieldDecoration.GetEnum<Net.TheVpc.Upa.PasswordStrategyType>("strategyType", typeof(Net.TheVpc.Upa.PasswordStrategyType)));
                        }
                        string cipherValue = fieldDecoration.GetString("cipherValue");
                        string cipherValueType = fieldDecoration.GetString("cipherValueType");
                        string cipherValueFormat = fieldDecoration.GetString("cipherValueFormat");
                        object cypherValueObj = Net.TheVpc.Upa.Impl.Util.UPAUtils.CreateValue(cipherValue, cipherValueType, cipherValueFormat);
                        p.SetCipherValue(cypherValueObj);
                        transforms.Add(p);
                    } else if (fieldDecoration.GetName().Equals((typeof(Net.TheVpc.Upa.Config.Secret)).FullName)) {
                        if (ci == null) {
                            ci = fieldDecoration.GetConfig();
                        }
                        Net.TheVpc.Upa.Types.SecretTransformConfig s2 = new Net.TheVpc.Upa.Types.SecretTransformConfig();
                        s2.SetSecretStrategy(fieldDecoration.GetString("algorithm"));
                        s2.SetSize(fieldDecoration.GetInt("max"));
                        s2.SetEncodeKey(fieldDecoration.GetString("key"));
                        s2.SetDecodeKey(fieldDecoration.GetString("reverseKey"));
                        transforms.Add(s2);
                    } else if (fieldDecoration.GetName().Equals((typeof(Net.TheVpc.Upa.Config.ToString)).FullName)) {
                        if (ci == null) {
                            ci = fieldDecoration.GetConfig();
                        }
                        Net.TheVpc.Upa.Types.StringEncoderTransformConfig s2 = new Net.TheVpc.Upa.Types.StringEncoderTransformConfig();
                        Net.TheVpc.Upa.Config.StringEncoderType stringStrategyType = fieldDecoration.GetEnum<Net.TheVpc.Upa.Config.StringEncoderType>("value", typeof(Net.TheVpc.Upa.Config.StringEncoderType));
                        if (stringStrategyType == Net.TheVpc.Upa.Config.StringEncoderType.CUSTOM) {
                            s2.SetEncoder(fieldDecoration.GetEnum<Net.TheVpc.Upa.Config.StringEncoderType>("custom", typeof(Net.TheVpc.Upa.Config.StringEncoderType)));
                        } else {
                            s2.SetEncoder(stringStrategyType);
                        }
                        transforms.Add(s2);
                    } else if (fieldDecoration.GetName().Equals((typeof(Net.TheVpc.Upa.Config.ToByteArray)).FullName)) {
                        if (ci == null) {
                            ci = fieldDecoration.GetConfig();
                        }
                        Net.TheVpc.Upa.Types.ByteArrayEncoderTransformConfig s2 = new Net.TheVpc.Upa.Types.ByteArrayEncoderTransformConfig();
                        s2.SetEncoder(fieldDecoration.GetString("value"));
                        transforms.Add(s2);
                    } else if (fieldDecoration.GetName().Equals((typeof(Net.TheVpc.Upa.Config.ToCharArray)).FullName)) {
                        if (ci == null) {
                            ci = fieldDecoration.GetConfig();
                        }
                        Net.TheVpc.Upa.Types.CharArrayEncoderTransformConfig s2 = new Net.TheVpc.Upa.Types.CharArrayEncoderTransformConfig();
                        s2.SetEncoder(fieldDecoration.GetString("value"));
                        transforms.Add(s2);
                    } else if (fieldDecoration.GetName().Equals((typeof(Net.TheVpc.Upa.Config.Converter)).FullName)) {
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
                            Net.TheVpc.Upa.Types.CustomTypeDataTypeTransform s2 = new Net.TheVpc.Upa.Types.CustomTypeDataTypeTransform(type);
                            transforms.Add(s2);
                        } else {
                            Net.TheVpc.Upa.Types.CustomExpressionDataTypeTransform s2 = new Net.TheVpc.Upa.Types.CustomExpressionDataTypeTransform(type);
                            transforms.Add(s2);
                        }
                    }
                }
                if (ci != null) {
                    overriddenTransform.SetBetterValue(transforms.ToArray(), ci.GetOrder());
                }
            }
        }

        public virtual Net.TheVpc.Upa.PropertyAccessType GetPropertyAccessType() {
            return overriddenPropertyAccessType.GetValue(default(Net.TheVpc.Upa.PropertyAccessType));
        }
    }
}
