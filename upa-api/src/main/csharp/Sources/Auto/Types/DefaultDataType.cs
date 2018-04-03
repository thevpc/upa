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

        protected internal object defaultValue;

        protected internal object defaultUnspecifiedValue;

        protected internal bool defaultValueUserDefined;

        protected internal bool defaultUnspecifiedValueUserDefined;

        protected internal System.Type platformType;

        protected internal int scale;

        protected internal int precision;

        protected internal System.Collections.Generic.IList<Net.Vpc.Upa.Types.TypeValueValidator> valueValidators = new System.Collections.Generic.List<Net.Vpc.Upa.Types.TypeValueValidator>(1);

        protected internal System.Collections.Generic.IList<Net.Vpc.Upa.Types.TypeValueRewriter> valueRewriters = new System.Collections.Generic.List<Net.Vpc.Upa.Types.TypeValueRewriter>(1);

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
            ReevaluateCachedValues();
        }

        protected internal virtual void ReevaluateCachedValues() {
            if (!this.defaultValueUserDefined) {
                this.defaultValue = nullable ? Net.Vpc.Upa.FwkConvertUtils.GetMapValue<System.Type,object>(NULLABLE_DEFAULT_VALUES,platformType) : Net.Vpc.Upa.FwkConvertUtils.GetMapValue<System.Type,object>(NON_NULLABLE_DEFAULT_VALUES,platformType);
            }
            if (!this.defaultUnspecifiedValueUserDefined) {
                this.defaultUnspecifiedValue = nullable ? null : Net.Vpc.Upa.FwkConvertUtils.GetMapValue<System.Type,object>(NULLABLE_DEFAULT_VALUES,platformType);
            }
        }


        public virtual object GetDefaultUnspecifiedValue() {
            return defaultUnspecifiedValue;
        }


        public virtual void SetDefaultUnspecifiedValue(object defaultUnspecifiedValue) {
            this.defaultUnspecifiedValue = defaultUnspecifiedValue;
            this.defaultUnspecifiedValueUserDefined = true;
        }


        public virtual object GetDefaultValue() {
            return defaultValue;
        }


        public virtual void SetDefaultValue(object defaultValue) {
            this.defaultValue = defaultValue;
            this.defaultValueUserDefined = true;
        }


        public virtual bool IsNullable() {
            return nullable;
        }


        public virtual void SetNullable(bool enable) {
            nullable = enable;
            ReevaluateCachedValues();
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
                throw new Net.Vpc.Upa.Types.ConstraintsException("IllegalNull", name, description, null);
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


        public override bool Equals(object o) {
            if (this == o) return true;
            if (o == null || GetType() != o.GetType()) return false;
            Net.Vpc.Upa.Types.DefaultDataType that = (Net.Vpc.Upa.Types.DefaultDataType) o;
            if (nullable != that.nullable) return false;
            if (defaultValueUserDefined != that.defaultValueUserDefined) return false;
            if (defaultUnspecifiedValueUserDefined != that.defaultUnspecifiedValueUserDefined) return false;
            if (scale != that.scale) return false;
            if (precision != that.precision) return false;
            if (unitName != null ? !unitName.Equals(that.unitName) : that.unitName != null) return false;
            if (name != null ? !name.Equals(that.name) : that.name != null) return false;
            if (properties != null ? !properties.Equals(that.properties) : that.properties != null) return false;
            if (defaultValue != null ? !defaultValue.Equals(that.defaultValue) : that.defaultValue != null) return false;
            if (defaultUnspecifiedValue != null ? !defaultUnspecifiedValue.Equals(that.defaultUnspecifiedValue) : that.defaultUnspecifiedValue != null) return false;
            if (platformType != null ? !platformType.Equals(that.platformType) : that.platformType != null) return false;
            if (valueValidators != null ? !valueValidators.Equals(that.valueValidators) : that.valueValidators != null) return false;
            return valueRewriters != null ? valueRewriters.Equals(that.valueRewriters) : that.valueRewriters == null;
        }


        public override int GetHashCode() {
            int result = unitName != null ? unitName.GetHashCode() : 0;
            result = 31 * result + (name != null ? name.GetHashCode() : 0);
            result = 31 * result + (nullable ? 1 : 0);
            result = 31 * result + (properties != null ? properties.GetHashCode() : 0);
            result = 31 * result + (defaultValue != null ? defaultValue.GetHashCode() : 0);
            result = 31 * result + (defaultUnspecifiedValue != null ? defaultUnspecifiedValue.GetHashCode() : 0);
            result = 31 * result + (defaultValueUserDefined ? 1 : 0);
            result = 31 * result + (defaultUnspecifiedValueUserDefined ? 1 : 0);
            result = 31 * result + (platformType != null ? platformType.GetHashCode() : 0);
            result = 31 * result + scale;
            result = 31 * result + precision;
            result = 31 * result + (valueValidators != null ? valueValidators.GetHashCode() : 0);
            result = 31 * result + (valueRewriters != null ? valueRewriters.GetHashCode() : 0);
            return result;
        }


        public virtual Net.Vpc.Upa.DataTypeInfo GetInfo() {
            Net.Vpc.Upa.DataTypeInfo d = new Net.Vpc.Upa.DataTypeInfo();
            d.SetName(GetName());
            d.SetType((GetType()).FullName);
            d.SetPlatformType((GetPlatformType()).FullName);
            d.SetUnitName(GetUnitName());
            System.Collections.Generic.IDictionary<string , string> p = new System.Collections.Generic.Dictionary<string , string>();
            d.SetProperties(p);
            return d;
        }
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        virtual public object Clone() { return base.MemberwiseClone();}
    }
}
