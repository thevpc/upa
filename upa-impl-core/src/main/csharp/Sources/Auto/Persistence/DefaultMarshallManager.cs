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



namespace Net.TheVpc.Upa.Impl.Persistence
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 11/3/12 11:35 PM
     */
    public class DefaultMarshallManager : Net.TheVpc.Upa.Impl.Persistence.MarshallManager {

        private readonly System.Collections.Generic.IDictionary<System.Type , Net.TheVpc.Upa.Impl.Persistence.TypeMarshaller> typeToMarshallerMap = new System.Collections.Generic.Dictionary<System.Type , Net.TheVpc.Upa.Impl.Persistence.TypeMarshaller>();

        private Net.TheVpc.Upa.Impl.Persistence.TypeMarshaller nullMarshaller;

        private readonly System.Collections.Generic.IDictionary<System.Type , Net.TheVpc.Upa.Impl.Persistence.TypeMarshallerFactory> typeToMarshallerFactory = new System.Collections.Generic.Dictionary<System.Type , Net.TheVpc.Upa.Impl.Persistence.TypeMarshallerFactory>();

        public DefaultMarshallManager() {
            this.nullMarshaller = (Net.TheVpc.Upa.Impl.Persistence.Shared.TypeMarshallerUtils.NULL);
            SetTypeMarshaller0(typeof(object), new Net.TheVpc.Upa.Impl.Persistence.Shared.SerializablePlatformObjectMarshaller());
            SetTypeMarshaller0(typeof(float?), Net.TheVpc.Upa.Impl.Persistence.Shared.TypeMarshallerUtils.FLOAT);
            SetTypeMarshaller0(typeof(string), Net.TheVpc.Upa.Impl.Persistence.Shared.TypeMarshallerUtils.STRING);
            SetTypeMarshaller0(typeof(char?), Net.TheVpc.Upa.Impl.Persistence.Shared.TypeMarshallerUtils.STRING);
            SetTypeMarshaller0(typeof(double?), Net.TheVpc.Upa.Impl.Persistence.Shared.TypeMarshallerUtils.DOUBLE);
            SetTypeMarshaller0(typeof(int?), Net.TheVpc.Upa.Impl.Persistence.Shared.TypeMarshallerUtils.INTEGER);
            SetTypeMarshaller0(typeof(long?), Net.TheVpc.Upa.Impl.Persistence.Shared.TypeMarshallerUtils.LONG);
            SetTypeMarshaller0(typeof(short?), Net.TheVpc.Upa.Impl.Persistence.Shared.TypeMarshallerUtils.SHORT);
            SetTypeMarshaller0(typeof(byte?), Net.TheVpc.Upa.Impl.Persistence.Shared.TypeMarshallerUtils.BYTE);
            SetTypeMarshaller0(typeof(System.Numerics.BigInteger?), Net.TheVpc.Upa.Impl.Persistence.Shared.TypeMarshallerUtils.BIG_INTEGER);
            SetTypeMarshaller0(typeof(System.Decimal?), Net.TheVpc.Upa.Impl.Persistence.Shared.TypeMarshallerUtils.BIG_DECIMAL);
            SetTypeMarshaller0(typeof(bool?), Net.TheVpc.Upa.Impl.Persistence.Shared.TypeMarshallerUtils.BOOLEAN_FROM_NUMBER);
            SetTypeMarshaller0(typeof(Net.TheVpc.Upa.Types.FileData), new Net.TheVpc.Upa.Impl.Persistence.Shared.SerializablePlatformObjectMarshaller());
            SetTypeMarshaller0(typeof(float), Net.TheVpc.Upa.Impl.Persistence.Shared.TypeMarshallerUtils.FLOAT);
            SetTypeMarshaller0(typeof(char), Net.TheVpc.Upa.Impl.Persistence.Shared.TypeMarshallerUtils.STRING);
            SetTypeMarshaller0(typeof(double), Net.TheVpc.Upa.Impl.Persistence.Shared.TypeMarshallerUtils.DOUBLE);
            SetTypeMarshaller0(typeof(int), Net.TheVpc.Upa.Impl.Persistence.Shared.TypeMarshallerUtils.INTEGER);
            SetTypeMarshaller0(typeof(long), Net.TheVpc.Upa.Impl.Persistence.Shared.TypeMarshallerUtils.LONG);
            SetTypeMarshaller0(typeof(short), Net.TheVpc.Upa.Impl.Persistence.Shared.TypeMarshallerUtils.SHORT);
            SetTypeMarshaller0(typeof(byte), Net.TheVpc.Upa.Impl.Persistence.Shared.TypeMarshallerUtils.BYTE);
            SetTypeMarshaller0(typeof(bool), Net.TheVpc.Upa.Impl.Persistence.Shared.TypeMarshallerUtils.BOOLEAN_FROM_NUMBER);
            SetTypeMarshaller0(typeof(Net.TheVpc.Upa.Types.Temporal), Net.TheVpc.Upa.Impl.Persistence.Shared.TypeMarshallerUtils.UTIL_DATE);
            SetTypeMarshaller0(typeof(Net.TheVpc.Upa.Types.Date), Net.TheVpc.Upa.Impl.Persistence.Shared.TypeMarshallerUtils.SQL_DATE);
            SetTypeMarshaller0(typeof(Net.TheVpc.Upa.Types.Time), Net.TheVpc.Upa.Impl.Persistence.Shared.TypeMarshallerUtils.SQL_TIME);
            SetTypeMarshaller0(typeof(Net.TheVpc.Upa.Types.Timestamp), Net.TheVpc.Upa.Impl.Persistence.Shared.TypeMarshallerUtils.SQL_TIMESTAMP);
            SetTypeMarshaller0(typeof(Net.TheVpc.Upa.Types.Date), Net.TheVpc.Upa.Impl.Persistence.Shared.TypeMarshallerUtils.DATE);
            SetTypeMarshaller0(typeof(Net.TheVpc.Upa.Types.Month), Net.TheVpc.Upa.Impl.Persistence.Shared.TypeMarshallerUtils.MONTH_YEAR);
            SetTypeMarshaller0(typeof(Net.TheVpc.Upa.Types.Year), Net.TheVpc.Upa.Impl.Persistence.Shared.TypeMarshallerUtils.YEAR);
            SetTypeMarshaller0(typeof(Net.TheVpc.Upa.Types.Time), Net.TheVpc.Upa.Impl.Persistence.Shared.TypeMarshallerUtils.VPC_TIME);
            SetTypeMarshaller0(typeof(Net.TheVpc.Upa.Types.DateTime), Net.TheVpc.Upa.Impl.Persistence.Shared.TypeMarshallerUtils.DATE_TIME);
            SetTypeMarshaller0(typeof(Net.TheVpc.Upa.Types.Timestamp), Net.TheVpc.Upa.Impl.Persistence.Shared.TypeMarshallerUtils.TIMESTAMP);
            SetTypeMarshaller0(typeof(byte[]), Net.TheVpc.Upa.Impl.Persistence.Shared.TypeMarshallerUtils.BYTES);
            SetTypeMarshaller0(typeof(byte?[]), Net.TheVpc.Upa.Impl.Persistence.Shared.TypeMarshallerUtils.BYTE_REFS);
            SetTypeMarshaller0(typeof(char[]), Net.TheVpc.Upa.Impl.Persistence.Shared.TypeMarshallerUtils.CHARS);
            SetTypeMarshaller0(typeof(char?[]), Net.TheVpc.Upa.Impl.Persistence.Shared.TypeMarshallerUtils.CHAR_REFS);
            SetTypeMarshallerFactory0(typeof(Net.TheVpc.Upa.Types.ImageType), new Net.TheVpc.Upa.Impl.Persistence.Shared.ConstantDataMarshallerFactory(new Net.TheVpc.Upa.Impl.Persistence.Shared.SerializablePlatformObjectMarshaller()));
            SetTypeMarshallerFactory0(typeof(Net.TheVpc.Upa.Types.TemporalType), new Net.TheVpc.Upa.Impl.Persistence.Shared.TemporalDataMarshallerFactory());
            SetTypeMarshallerFactory0(typeof(Net.TheVpc.Upa.Types.FileType), new Net.TheVpc.Upa.Impl.Persistence.Shared.ConstantDataMarshallerFactory(new Net.TheVpc.Upa.Impl.Persistence.Shared.SerializablePlatformObjectMarshaller()));
            SetTypeMarshallerFactory0(typeof(Net.TheVpc.Upa.Types.NumberType), new Net.TheVpc.Upa.Impl.Persistence.Shared.NumberDataMarshallerFactory());
            SetTypeMarshallerFactory0(typeof(Net.TheVpc.Upa.Types.StringType), Net.TheVpc.Upa.Impl.Persistence.Shared.TypeMarshallerUtils.F_STRING);
            SetTypeMarshallerFactory0(typeof(Net.TheVpc.Upa.Types.BooleanType), Net.TheVpc.Upa.Impl.Persistence.Shared.TypeMarshallerUtils.F_BOOLEAN_FROM_NUMBER);
            SetTypeMarshallerFactory0(typeof(Net.TheVpc.Upa.Types.ListType), new Net.TheVpc.Upa.Impl.Persistence.Shared.ListDataMarshallerFactory());
            SetTypeMarshallerFactory0(typeof(Net.TheVpc.Upa.Types.DataType), Net.TheVpc.Upa.Impl.Persistence.Shared.TypeMarshallerUtils.F_OBJECT);
            SetTypeMarshallerFactory0(typeof(Net.TheVpc.Upa.Types.SerializableType), Net.TheVpc.Upa.Impl.Persistence.Shared.TypeMarshallerUtils.F_OBJECT);
            SetTypeMarshallerFactory0(typeof(Net.TheVpc.Upa.Types.EnumType), new Net.TheVpc.Upa.Impl.Persistence.Shared.EnumMarshallerFactory());
        }


        public virtual void SetNullMarshaller(Net.TheVpc.Upa.Impl.Persistence.TypeMarshaller wrapper) {
            nullMarshaller = wrapper;
        }


        public virtual Net.TheVpc.Upa.Impl.Persistence.TypeMarshaller GetNullMarshaller() {
            return nullMarshaller;
        }


        public virtual void SetTypeMarshaller(System.Type platformType, Net.TheVpc.Upa.Impl.Persistence.TypeMarshaller wrapper) {
            SetTypeMarshaller0(platformType, wrapper);
        }

        private void SetTypeMarshaller0(System.Type platformType, Net.TheVpc.Upa.Impl.Persistence.TypeMarshaller wrapper) {
            wrapper.SetMarshallManager(this);
            typeToMarshallerMap[platformType]=wrapper;
        }


        public virtual void SetTypeMarshallerFactory(System.Type platformType, Net.TheVpc.Upa.Impl.Persistence.TypeMarshallerFactory wrapperFactory) {
            SetTypeMarshallerFactory0(platformType, wrapperFactory);
        }

        private void SetTypeMarshallerFactory0(System.Type platformType, Net.TheVpc.Upa.Impl.Persistence.TypeMarshallerFactory wrapperFactory) {
            wrapperFactory.SetMarshallManager(this);
            typeToMarshallerFactory[platformType]=wrapperFactory;
        }


        public virtual Net.TheVpc.Upa.Impl.Persistence.TypeMarshaller GetTypeMarshaller(System.Type platformType) {
            Net.TheVpc.Upa.Impl.Persistence.TypeMarshaller c = (Net.TheVpc.Upa.Impl.Persistence.TypeMarshaller) Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<System.Type,Net.TheVpc.Upa.Impl.Persistence.TypeMarshaller>(typeToMarshallerMap,platformType);
            if (c != null) {
                return c;
            }
            if ((platformType).IsEnum) {
                return new Net.TheVpc.Upa.Impl.Persistence.Shared.EnumAsIntMarshaller(platformType);
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

        public virtual Net.TheVpc.Upa.Impl.Persistence.TypeMarshaller GetTypeMarshaller(Net.TheVpc.Upa.Types.DataTypeTransform p) {
            if (p is Net.TheVpc.Upa.Impl.Transform.IdentityDataTypeTransform) {
                return GetTypeMarshaller(((Net.TheVpc.Upa.Impl.Transform.IdentityDataTypeTransform) p).GetSourceType());
            }
            return new Net.TheVpc.Upa.Impl.Persistence.Shared.DataTypeTransformMarshaller(p, GetTypeMarshaller(p.GetTargetType()));
        }


        public virtual Net.TheVpc.Upa.Impl.Persistence.TypeMarshaller GetTypeMarshaller(Net.TheVpc.Upa.Types.DataType p) {
            return GetTypeMarshallerFactory(p.GetType()).CreateTypeMarshaller(p);
        }


        public virtual Net.TheVpc.Upa.Impl.Persistence.TypeMarshallerFactory GetTypeMarshallerFactory(System.Type someClass) {
            Net.TheVpc.Upa.Impl.Persistence.TypeMarshallerFactory f = GetTypeMarshallerFactory0(someClass);
            return f == null ? GetTypeMarshallerFactory(typeof(object)) : f;
        }

        private Net.TheVpc.Upa.Impl.Persistence.TypeMarshallerFactory GetTypeMarshallerFactory0(System.Type someClass) {
            Net.TheVpc.Upa.Impl.Persistence.TypeMarshallerFactory c = (Net.TheVpc.Upa.Impl.Persistence.TypeMarshallerFactory) Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<System.Type,Net.TheVpc.Upa.Impl.Persistence.TypeMarshallerFactory>(typeToMarshallerFactory,someClass);
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

        public virtual string FormatSqlValue(object @value, Net.TheVpc.Upa.Types.DataType datatype) {
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
