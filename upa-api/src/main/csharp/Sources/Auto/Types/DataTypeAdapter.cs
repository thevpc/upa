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


    /**
     * Created by vpc on 6/17/16.
     */
    public class DataTypeAdapter : Net.TheVpc.Upa.Types.DataType, System.ICloneable {

        private Net.TheVpc.Upa.Types.DataType dataType;

        public DataTypeAdapter(Net.TheVpc.Upa.Types.DataType dataType) {
            this.dataType = dataType;
        }

        public virtual object GetDefaultUnspecifiedValue() {
            return dataType.GetDefaultUnspecifiedValue();
        }

        public virtual void SetDefaultUnspecifiedValue(object defaultUnspecifiedValue) {
            dataType.SetDefaultUnspecifiedValue(defaultUnspecifiedValue);
        }

        public virtual object GetDefaultValue() {
            return dataType.GetDefaultValue();
        }

        public virtual void SetDefaultValue(object defaultValue) {
            dataType.SetDefaultValue(defaultValue);
        }

        public virtual bool IsNullable() {
            return dataType.IsNullable();
        }

        public virtual void SetNullable(bool enable) {
            dataType.SetNullable(enable);
        }

        public virtual System.Type GetPlatformType() {
            return dataType.GetPlatformType();
        }

        public virtual int GetScale() {
            return dataType.GetScale();
        }

        public virtual int GetPrecision() {
            return dataType.GetPrecision();
        }

        public virtual object Rewrite(object @value, string name, string description) /* throws Net.TheVpc.Upa.Types.ConstraintsException */  {
            return dataType.Rewrite(@value, name, description);
        }

        public virtual void Check(object @value, string name, string description) /* throws Net.TheVpc.Upa.Types.ConstraintsException */  {
            dataType.Check(@value, name, description);
        }

        public virtual System.Collections.Generic.IList<Net.TheVpc.Upa.Types.TypeValueValidator> GetValueValidators() {
            return dataType.GetValueValidators();
        }

        public virtual Net.TheVpc.Upa.Types.DataType AddValueValidator(Net.TheVpc.Upa.Types.TypeValueValidator validator) {
            return dataType.AddValueValidator(validator);
        }

        public virtual Net.TheVpc.Upa.Types.DataType RemoveValueValidator(Net.TheVpc.Upa.Types.TypeValueValidator validator) {
            return dataType.RemoveValueValidator(validator);
        }

        public virtual Net.TheVpc.Upa.Types.DataType AddValueRewriter(Net.TheVpc.Upa.Types.TypeValueRewriter rewriter) {
            return dataType.AddValueRewriter(rewriter);
        }

        public virtual Net.TheVpc.Upa.Types.DataType RemoveValueReWriter(Net.TheVpc.Upa.Types.TypeValueRewriter rewriter) {
            return dataType.RemoveValueReWriter(rewriter);
        }

        public virtual System.Collections.Generic.IList<Net.TheVpc.Upa.Types.TypeValueRewriter> GetValueRewriters() {
            return dataType.GetValueRewriters();
        }

        public virtual string GetUnitName() {
            return dataType.GetUnitName();
        }

        public virtual Net.TheVpc.Upa.Types.DataType SetUnitName(string unitName) {
            return dataType.SetUnitName(unitName);
        }

        public virtual bool IsAssignableFrom(Net.TheVpc.Upa.Types.DataType type) {
            return dataType.IsAssignableFrom(type);
        }

        public virtual bool IsInstance(object @object) {
            return dataType.IsInstance(@object);
        }

        public virtual void Cast(Net.TheVpc.Upa.Types.DataType type) {
            dataType.Cast(type);
        }

        public virtual object Convert(object @value) {
            return dataType.Convert(@value);
        }

        public virtual string GetName() {
            return dataType.GetName();
        }

        public virtual void SetName(string name) {
            dataType.SetName(name);
        }

        public virtual Net.TheVpc.Upa.Properties GetProperties() {
            return dataType.GetProperties();
        }

        public virtual void SetProperties(Net.TheVpc.Upa.Properties properties) {
            dataType.SetProperties(properties);
        }

        public virtual object Copy() {
            try {
                return base.MemberwiseClone();
            } catch (System.Exception ex) {
                throw new Net.TheVpc.Upa.Exceptions.UnexpectedException("Clone Not Supported", ex);
            }
        }


        public override bool Equals(object o) {
            if (this == o) return true;
            if (o == null || GetType() != o.GetType()) return false;
            Net.TheVpc.Upa.Types.DataTypeAdapter that = (Net.TheVpc.Upa.Types.DataTypeAdapter) o;
            return dataType != null ? dataType.Equals(that.dataType) : that.dataType == null;
        }


        public override int GetHashCode() {
            return dataType != null ? dataType.GetHashCode() : 0;
        }


        public virtual Net.TheVpc.Upa.DataTypeInfo GetInfo() {
            return dataType.GetInfo();
        }
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        virtual public object Clone() { return base.MemberwiseClone();}
    }
}
