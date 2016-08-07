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



    public abstract partial class DefaultDataType : Net.Vpc.Upa.Types.DataType {

        private static readonly System.Collections.Generic.IDictionary<System.Type , object> NULLABLE_DEFAULT_VALUES = new System.Collections.Generic.Dictionary<System.Type , object>();

        private static readonly System.Collections.Generic.IDictionary<System.Type , object> NON_NULLABLE_DEFAULT_VALUES = new System.Collections.Generic.Dictionary<System.Type , object>();

        static DefaultDataType(){
            NULLABLE_DEFAULT_VALUES[typeof(short)]=(short) ((short)0);
            NULLABLE_DEFAULT_VALUES[typeof(long)]=0L;
            NULLABLE_DEFAULT_VALUES[typeof(int)]=0;
            NULLABLE_DEFAULT_VALUES[typeof(double)]=0.0;
            NULLABLE_DEFAULT_VALUES[typeof(float)]=0.0f;
            NULLABLE_DEFAULT_VALUES[typeof(byte)]=(byte) ((byte)0);
            NULLABLE_DEFAULT_VALUES[typeof(char)]=(char) ((char)0);
            NON_NULLABLE_DEFAULT_VALUES[typeof(short)]=(short) ((short)0);
            NON_NULLABLE_DEFAULT_VALUES[typeof(long)]=0L;
            NON_NULLABLE_DEFAULT_VALUES[typeof(int)]=0;
            NON_NULLABLE_DEFAULT_VALUES[typeof(double)]=0.0;
            NON_NULLABLE_DEFAULT_VALUES[typeof(float)]=0.0f;
            NON_NULLABLE_DEFAULT_VALUES[typeof(byte)]=(byte) ((byte)0);
            NON_NULLABLE_DEFAULT_VALUES[typeof(char)]=(char) ((char)0);
            NON_NULLABLE_DEFAULT_VALUES[typeof(short?)]=(short) ((short)0);
            NON_NULLABLE_DEFAULT_VALUES[typeof(long?)]=0L;
            NON_NULLABLE_DEFAULT_VALUES[typeof(int?)]=0;
            NON_NULLABLE_DEFAULT_VALUES[typeof(double?)]=0.0;
            NON_NULLABLE_DEFAULT_VALUES[typeof(float?)]=0.0f;
            NON_NULLABLE_DEFAULT_VALUES[typeof(byte?)]=(byte) ((byte)0);
            NON_NULLABLE_DEFAULT_VALUES[typeof(char?)]=(char) ((char)0);
        }

        public string unitName;

        public string name;

        protected internal bool nullable;

        protected internal Net.Vpc.Upa.Properties properties;

        protected internal object defaultNonNullValue;

        protected internal object defaultValue;

        protected internal object defaultUnspecifiedValue;

        protected internal System.Type platformType;

        protected internal int scale;

        protected internal int precision;

        protected internal System.Collections.Generic.IList<Net.Vpc.Upa.Types.TypeValueValidator> valueValidators = new System.Collections.Generic.List<Net.Vpc.Upa.Types.TypeValueValidator>();

        protected internal System.Collections.Generic.IList<Net.Vpc.Upa.Types.TypeValueRewriter> valueRewriters = new System.Collections.Generic.List<Net.Vpc.Upa.Types.TypeValueRewriter>();

        public DefaultDataType(string name, System.Type platformType)  : this(name, platformType, 0, 0, false){

        }

        public DefaultDataType(string name, System.Type platformType, bool nullable)  : this(name, platformType, 0, 0, nullable){

        }

        public DefaultDataType(string name, System.Type platformType, int scale, int precision, bool nullable) {
            this.name = name;
            this.nullable = nullable;
            this.platformType = platformType;
            this.scale = scale;
            this.precision = precision;
            this.defaultValue = nullable ? Net.Vpc.Upa.FwkConvertUtils.GetMapValue<System.Type,object>(NULLABLE_DEFAULT_VALUES,platformType) : Net.Vpc.Upa.FwkConvertUtils.GetMapValue<System.Type,object>(NON_NULLABLE_DEFAULT_VALUES,platformType);
            this.defaultUnspecifiedValue = Net.Vpc.Upa.FwkConvertUtils.GetMapValue<System.Type,object>(NULLABLE_DEFAULT_VALUES,platformType);
            this.defaultNonNullValue = this.defaultValue;
        }


        public virtual object GetDefaultUnspecifiedValue() {
            return defaultUnspecifiedValue;
        }


        public virtual void SetDefaultUnspecifiedValue(object defaultUnspecifiedValue) {
            this.defaultUnspecifiedValue = defaultUnspecifiedValue;
        }


        public virtual object GetDefaultValue() {
            return defaultValue;
        }


        public virtual void SetDefaultValue(object defaultValue) {
            this.defaultValue = defaultValue;
        }


        public virtual object GetDefaultNonNullValue() {
            return defaultNonNullValue;
        }


        public virtual void SetDefaultNonNullValue(object defaultNonNullValue) {
            this.defaultNonNullValue = defaultNonNullValue;
        }


        public virtual bool IsNullable() {
            return nullable;
        }


        public virtual void SetNullable(bool enable) {
            nullable = enable;
        }


        public virtual System.Type GetPlatformType() {
            return platformType;
        }


        public virtual int GetScale() {
            return scale;
        }


        public virtual int GetPrecision() {
            return precision;
        }


        public virtual object Rewrite(object @value, string name, string description) /* throws Net.Vpc.Upa.Types.ConstraintsException */  {
            foreach (Net.Vpc.Upa.Types.TypeValueRewriter typeValidator in valueRewriters) {
                @value = typeValidator.RewriteValue(@value, name, description, this);
            }
            return @value;
        }


        public virtual void Check(object @value, string name, string description) /* throws Net.Vpc.Upa.Types.ConstraintsException */  {
            if (@value == null && !IsNullable()) {
                throw new Net.Vpc.Upa.Types.ConstraintsException("IllegalNull", name, description, @value);
            }
            foreach (Net.Vpc.Upa.Types.TypeValueValidator typeValueValidator in valueValidators) {
                typeValueValidator.ValidateValue(@value, name, description, this);
            }
        }


        public virtual object Copy() {
            try {
                Net.Vpc.Upa.Types.DefaultDataType cloned = (Net.Vpc.Upa.Types.DefaultDataType) base.MemberwiseClone();
                cloned.valueValidators = new System.Collections.Generic.List<Net.Vpc.Upa.Types.TypeValueValidator>(valueValidators);
                cloned.valueRewriters = new System.Collections.Generic.List<Net.Vpc.Upa.Types.TypeValueRewriter>(valueRewriters);
                return cloned;
            } catch (System.Exception ex) {
                throw new Net.Vpc.Upa.Exceptions.UnexpectedException("Clone Not Supported", ex);
            }
        }


        public virtual System.Collections.Generic.IList<Net.Vpc.Upa.Types.TypeValueValidator> GetValueValidators() {
            return new System.Collections.Generic.List<Net.Vpc.Upa.Types.TypeValueValidator>(valueValidators);
        }


        public virtual Net.Vpc.Upa.Types.DataType AddValueValidator(Net.Vpc.Upa.Types.TypeValueValidator validator) {
            valueValidators.Add(validator);
            return this;
        }


        public virtual Net.Vpc.Upa.Types.DataType RemoveValueValidator(Net.Vpc.Upa.Types.TypeValueValidator validator) {
            valueValidators.Remove(validator);
            return this;
        }


        public virtual Net.Vpc.Upa.Types.DataType AddValueRewriter(Net.Vpc.Upa.Types.TypeValueRewriter rewriter) {
            valueRewriters.Add(rewriter);
            return this;
        }


        public virtual Net.Vpc.Upa.Types.DataType RemoveValueReWriter(Net.Vpc.Upa.Types.TypeValueRewriter rewriter) {
            valueRewriters.Remove(rewriter);
            return this;
        }


        public virtual System.Collections.Generic.IList<Net.Vpc.Upa.Types.TypeValueRewriter> GetValueRewriters() {
            return new System.Collections.Generic.List<Net.Vpc.Upa.Types.TypeValueRewriter>(valueRewriters);
        }


        public virtual string GetUnitName() {
            return unitName;
        }


        public virtual Net.Vpc.Upa.Types.DataType SetUnitName(string unitName) {
            this.unitName = unitName;
            return this;
        }


        public virtual bool IsAssignableFrom(Net.Vpc.Upa.Types.DataType type) {
            return this.GetType().IsAssignableFrom(type.GetType());
        }


        public virtual bool IsInstance(object @object) {
            if (@object == null) {
                return true;
            }
            return IsAssignableFrom(Net.Vpc.Upa.Types.TypesFactory.ForPlatformType(@object.GetType()));
        }


        public virtual void Cast(Net.Vpc.Upa.Types.DataType type) {
            if (!IsAssignableFrom(type)) {
                throw new System.InvalidCastException("Expected an expression of type " + this + " but got " + type);
            }
        }



        public virtual object Convert(object @value) {
            return @value;
        }


        public virtual string GetName() {
            return name;
        }


        public virtual void SetName(string name) {
            this.name = name;
        }


        public virtual Net.Vpc.Upa.Properties GetProperties() {
            return properties;
        }


        public virtual void SetProperties(Net.Vpc.Upa.Properties properties) {
            this.properties = properties;
        }
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        virtual public object Clone() { return base.MemberwiseClone();}
    }
}
