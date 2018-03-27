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



namespace Net.Vpc.Upa.Impl.Persistence
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 11/3/12 11:35 PM
     */
    public class DefaultMarshallManager : Net.Vpc.Upa.Impl.Persistence.MarshallManager {

        private readonly System.Collections.Generic.IDictionary<System.Type , Net.Vpc.Upa.Impl.Persistence.TypeMarshaller> typeToMarshallerMap = new System.Collections.Generic.Dictionary<System.Type , Net.Vpc.Upa.Impl.Persistence.TypeMarshaller>();

        private Net.Vpc.Upa.Impl.Persistence.TypeMarshaller nullMarshaller;

        private readonly System.Collections.Generic.IDictionary<System.Type , Net.Vpc.Upa.Impl.Persistence.TypeMarshallerFactory> typeToMarshallerFactory = new System.Collections.Generic.Dictionary<System.Type , Net.Vpc.Upa.Impl.Persistence.TypeMarshallerFactory>();

        public DefaultMarshallManager() {
            this.nullMarshaller = (Net.Vpc.Upa.Impl.Persistence.Shared.TypeMarshallerUtils.NULL);
            SetTypeMarshaller0(typeof(object), new Net.Vpc.Upa.Impl.Persistence.Shared.SerializablePlatformObjectMarshaller());
            SetTypeMarshaller0(typeof(float?), Net.Vpc.Upa.Impl.Persistence.Shared.TypeMarshallerUtils.FLOAT);
            SetTypeMarshaller0(typeof(string), Net.Vpc.Upa.Impl.Persistence.Shared.TypeMarshallerUtils.STRING);
            SetTypeMarshaller0(typeof(char?), Net.Vpc.Upa.Impl.Persistence.Shared.TypeMarshallerUtils.STRING);
            SetTypeMarshaller0(typeof(double?), Net.Vpc.Upa.Impl.Persistence.Shared.TypeMarshallerUtils.DOUBLE);
            SetTypeMarshaller0(typeof(int?), Net.Vpc.Upa.Impl.Persistence.Shared.TypeMarshallerUtils.INTEGER);
            SetTypeMarshaller0(typeof(long?), Net.Vpc.Upa.Impl.Persistence.Shared.TypeMarshallerUtils.LONG);
            SetTypeMarshaller0(typeof(short?), Net.Vpc.Upa.Impl.Persistence.Shared.TypeMarshallerUtils.SHORT);
            SetTypeMarshaller0(typeof(byte?), Net.Vpc.Upa.Impl.Persistence.Shared.TypeMarshallerUtils.BYTE);
            SetTypeMarshaller0(typeof(System.Numerics.BigInteger?), Net.Vpc.Upa.Impl.Persistence.Shared.TypeMarshallerUtils.BIG_INTEGER);
            SetTypeMarshaller0(typeof(System.Decimal?), Net.Vpc.Upa.Impl.Persistence.Shared.TypeMarshallerUtils.BIG_DECIMAL);
            SetTypeMarshaller0(typeof(bool?), Net.Vpc.Upa.Impl.Persistence.Shared.TypeMarshallerUtils.BOOLEAN_FROM_NUMBER);
            SetTypeMarshaller0(typeof(Net.Vpc.Upa.Types.FileData), new Net.Vpc.Upa.Impl.Persistence.Shared.SerializablePlatformObjectMarshaller());
            SetTypeMarshaller0(typeof(float), Net.Vpc.Upa.Impl.Persistence.Shared.TypeMarshallerUtils.FLOAT);
            SetTypeMarshaller0(typeof(char), Net.Vpc.Upa.Impl.Persistence.Shared.TypeMarshallerUtils.STRING);
            SetTypeMarshaller0(typeof(double), Net.Vpc.Upa.Impl.Persistence.Shared.TypeMarshallerUtils.DOUBLE);
            SetTypeMarshaller0(typeof(int), Net.Vpc.Upa.Impl.Persistence.Shared.TypeMarshallerUtils.INTEGER);
            SetTypeMarshaller0(typeof(long), Net.Vpc.Upa.Impl.Persistence.Shared.TypeMarshallerUtils.LONG);
            SetTypeMarshaller0(typeof(short), Net.Vpc.Upa.Impl.Persistence.Shared.TypeMarshallerUtils.SHORT);
            SetTypeMarshaller0(typeof(byte), Net.Vpc.Upa.Impl.Persistence.Shared.TypeMarshallerUtils.BYTE);
            SetTypeMarshaller0(typeof(bool), Net.Vpc.Upa.Impl.Persistence.Shared.TypeMarshallerUtils.BOOLEAN_FROM_NUMBER);
            SetTypeMarshaller0(typeof(Net.Vpc.Upa.Types.Temporal), Net.Vpc.Upa.Impl.Persistence.Shared.TypeMarshallerUtils.UTIL_DATE);
            SetTypeMarshaller0(typeof(Net.Vpc.Upa.Types.Date), Net.Vpc.Upa.Impl.Persistence.Shared.TypeMarshallerUtils.SQL_DATE);
            SetTypeMarshaller0(typeof(Net.Vpc.Upa.Types.Time), Net.Vpc.Upa.Impl.Persistence.Shared.TypeMarshallerUtils.SQL_TIME);
            SetTypeMarshaller0(typeof(Net.Vpc.Upa.Types.Timestamp), Net.Vpc.Upa.Impl.Persistence.Shared.TypeMarshallerUtils.SQL_TIMESTAMP);
            SetTypeMarshaller0(typeof(Net.Vpc.Upa.Types.Date), Net.Vpc.Upa.Impl.Persistence.Shared.TypeMarshallerUtils.DATE);
            SetTypeMarshaller0(typeof(Net.Vpc.Upa.Types.Month), Net.Vpc.Upa.Impl.Persistence.Shared.TypeMarshallerUtils.MONTH_YEAR);
            SetTypeMarshaller0(typeof(Net.Vpc.Upa.Types.Year), Net.Vpc.Upa.Impl.Persistence.Shared.TypeMarshallerUtils.YEAR);
            SetTypeMarshaller0(typeof(Net.Vpc.Upa.Types.Time), Net.Vpc.Upa.Impl.Persistence.Shared.TypeMarshallerUtils.VPC_TIME);
            SetTypeMarshaller0(typeof(Net.Vpc.Upa.Types.DateTime), Net.Vpc.Upa.Impl.Persistence.Shared.TypeMarshallerUtils.DATE_TIME);
            SetTypeMarshaller0(typeof(Net.Vpc.Upa.Types.Timestamp), Net.Vpc.Upa.Impl.Persistence.Shared.TypeMarshallerUtils.TIMESTAMP);
            SetTypeMarshaller0(typeof(byte[]), Net.Vpc.Upa.Impl.Persistence.Shared.TypeMarshallerUtils.BYTES);
            SetTypeMarshaller0(typeof(byte?[]), Net.Vpc.Upa.Impl.Persistence.Shared.TypeMarshallerUtils.BYTE_REFS);
            SetTypeMarshaller0(typeof(char[]), Net.Vpc.Upa.Impl.Persistence.Shared.TypeMarshallerUtils.CHARS);
            SetTypeMarshaller0(typeof(char?[]), Net.Vpc.Upa.Impl.Persistence.Shared.TypeMarshallerUtils.CHAR_REFS);
            SetTypeMarshallerFactory0(typeof(Net.Vpc.Upa.Types.ImageType), new Net.Vpc.Upa.Impl.Persistence.Shared.ConstantDataMarshallerFactory(new Net.Vpc.Upa.Impl.Persistence.Shared.SerializablePlatformObjectMarshaller()));
            SetTypeMarshallerFactory0(typeof(Net.Vpc.Upa.Types.TemporalType), new Net.Vpc.Upa.Impl.Persistence.Shared.TemporalDataMarshallerFactory());
            SetTypeMarshallerFactory0(typeof(Net.Vpc.Upa.Types.FileType), new Net.Vpc.Upa.Impl.Persistence.Shared.ConstantDataMarshallerFactory(new Net.Vpc.Upa.Impl.Persistence.Shared.SerializablePlatformObjectMarshaller()));
            SetTypeMarshallerFactory0(typeof(Net.Vpc.Upa.Types.NumberType), new Net.Vpc.Upa.Impl.Persistence.Shared.NumberDataMarshallerFactory());
            SetTypeMarshallerFactory0(typeof(Net.Vpc.Upa.Types.StringType), Net.Vpc.Upa.Impl.Persistence.Shared.TypeMarshallerUtils.F_STRING);
            SetTypeMarshallerFactory0(typeof(Net.Vpc.Upa.Types.BooleanType), Net.Vpc.Upa.Impl.Persistence.Shared.TypeMarshallerUtils.F_BOOLEAN_FROM_NUMBER);
            SetTypeMarshallerFactory0(typeof(Net.Vpc.Upa.Types.ListType), new Net.Vpc.Upa.Impl.Persistence.Shared.ListDataMarshallerFactory());
            SetTypeMarshallerFactory0(typeof(Net.Vpc.Upa.Types.DataType), Net.Vpc.Upa.Impl.Persistence.Shared.TypeMarshallerUtils.F_OBJECT);
            SetTypeMarshallerFactory0(typeof(Net.Vpc.Upa.Types.SerializableType), Net.Vpc.Upa.Impl.Persistence.Shared.TypeMarshallerUtils.F_OBJECT);
            SetTypeMarshallerFactory0(typeof(Net.Vpc.Upa.Types.EnumType), new Net.Vpc.Upa.Impl.Persistence.Shared.EnumMarshallerFactory());
        }


        public virtual void SetNullMarshaller(Net.Vpc.Upa.Impl.Persistence.TypeMarshaller wrapper) {
            nullMarshaller = wrapper;
        }


        public virtual Net.Vpc.Upa.Impl.Persistence.TypeMarshaller GetNullMarshaller() {
            return nullMarshaller;
        }


        public virtual void SetTypeMarshaller(System.Type platformType, Net.Vpc.Upa.Impl.Persistence.TypeMarshaller wrapper) {
            SetTypeMarshaller0(platformType, wrapper);
        }

        private void SetTypeMarshaller0(System.Type platformType, Net.Vpc.Upa.Impl.Persistence.TypeMarshaller wrapper) {
            wrapper.SetMarshallManager(this);
            typeToMarshallerMap[platformType]=wrapper;
        }


        public virtual void SetTypeMarshallerFactory(System.Type platformType, Net.Vpc.Upa.Impl.Persistence.TypeMarshallerFactory wrapperFactory) {
            SetTypeMarshallerFactory0(platformType, wrapperFactory);
        }

        private void SetTypeMarshallerFactory0(System.Type platformType, Net.Vpc.Upa.Impl.Persistence.TypeMarshallerFactory wrapperFactory) {
            wrapperFactory.SetMarshallManager(this);
            typeToMarshallerFactory[platformType]=wrapperFactory;
        }


        public virtual Net.Vpc.Upa.Impl.Persistence.TypeMarshaller GetTypeMarshaller(System.Type platformType) {
            Net.Vpc.Upa.Impl.Persistence.TypeMarshaller c = (Net.Vpc.Upa.Impl.Persistence.TypeMarshaller) Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<System.Type,Net.Vpc.Upa.Impl.Persistence.TypeMarshaller>(typeToMarshallerMap,platformType);
            if (c != null) {
                return c;
            }
            if ((platformType).IsEnum) {
                return new Net.Vpc.Upa.Impl.Persistence.Shared.EnumAsIntMarshaller(platformType);
            }
            System.Type[] interfaces = platformType.GetInterfaces();
            foreach (System.Type anInterface in interfaces) {
                c = GetTypeMarshaller(anInterface);
                if (c != null) {
                    return c;
                }
            }
            System.Type superClass = (platformType).BaseType;
            if (superClass == null) {
                return null;
            }
            c = GetTypeMarshaller(superClass);
            if (c != null) {
                return c;
            }
            return GetTypeMarshaller(superClass);
        }

        public virtual Net.Vpc.Upa.Impl.Persistence.TypeMarshaller GetTypeMarshaller(Net.Vpc.Upa.Types.DataTypeTransform p) {
            if (p is Net.Vpc.Upa.Impl.Transform.IdentityDataTypeTransform) {
                return GetTypeMarshaller(((Net.Vpc.Upa.Impl.Transform.IdentityDataTypeTransform) p).GetSourceType());
            }
            return new Net.Vpc.Upa.Impl.Persistence.Shared.DataTypeTransformMarshaller(p, GetTypeMarshaller(p.GetTargetType()));
        }


        public virtual Net.Vpc.Upa.Impl.Persistence.TypeMarshaller GetTypeMarshaller(Net.Vpc.Upa.Types.DataType p) {
            return GetTypeMarshallerFactory(p.GetType()).CreateTypeMarshaller(p);
        }


        public virtual Net.Vpc.Upa.Impl.Persistence.TypeMarshallerFactory GetTypeMarshallerFactory(System.Type someClass) {
            Net.Vpc.Upa.Impl.Persistence.TypeMarshallerFactory f = GetTypeMarshallerFactory0(someClass);
            return f == null ? GetTypeMarshallerFactory(typeof(object)) : f;
        }

        private Net.Vpc.Upa.Impl.Persistence.TypeMarshallerFactory GetTypeMarshallerFactory0(System.Type someClass) {
            Net.Vpc.Upa.Impl.Persistence.TypeMarshallerFactory c = (Net.Vpc.Upa.Impl.Persistence.TypeMarshallerFactory) Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<System.Type,Net.Vpc.Upa.Impl.Persistence.TypeMarshallerFactory>(typeToMarshallerFactory,someClass);
            if (c != null) {
                return c;
            }
            System.Type[] interfaces = someClass.GetInterfaces();
            foreach (System.Type anInterface in interfaces) {
                c = GetTypeMarshallerFactory0(anInterface);
                if (c != null) {
                    return c;
                }
            }
            System.Type superClass = (someClass).BaseType;
            if (superClass == null) {
                return null;
            }
            c = GetTypeMarshallerFactory0(superClass);
            if (c != null) {
                return c;
            }
            return GetTypeMarshallerFactory0(superClass);
        }

        public virtual string FormatSqlValue(object @value, Net.Vpc.Upa.Types.DataType datatype) {
            if (@value == null) {
                return nullMarshaller.ToSQLLiteral(null);
            } else {
                return GetTypeMarshaller(@value.GetType()).ToSQLLiteral(@value);
            }
        }


        public virtual string FormatSqlValue(object @value) {
            return FormatSqlValue(@value, null);
        }
    }
}
