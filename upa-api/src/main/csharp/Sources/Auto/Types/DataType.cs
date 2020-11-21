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
    public interface DataType : System.ICloneable {

         object GetDefaultUnspecifiedValue();

         void SetDefaultUnspecifiedValue(object defaultUnspecifiedValue);

         object GetDefaultValue();

         void SetDefaultValue(object defaultValue);

         bool IsNullable();

         void SetNullable(bool enable);

         System.Type GetPlatformType();

         int GetScale();

         int GetPrecision();

         object Rewrite(object @value, string name, string description) /* throws Net.TheVpc.Upa.Types.ConstraintsException */ ;

         void Check(object @value, string name, string description) /* throws Net.TheVpc.Upa.Types.ConstraintsException */ ;

         object Copy();

         System.Collections.Generic.IList<Net.TheVpc.Upa.Types.TypeValueValidator> GetValueValidators();

         Net.TheVpc.Upa.Types.DataType AddValueValidator(Net.TheVpc.Upa.Types.TypeValueValidator validator);

         Net.TheVpc.Upa.Types.DataType RemoveValueValidator(Net.TheVpc.Upa.Types.TypeValueValidator validator);

         Net.TheVpc.Upa.Types.DataType AddValueRewriter(Net.TheVpc.Upa.Types.TypeValueRewriter rewriter);

         Net.TheVpc.Upa.Types.DataType RemoveValueReWriter(Net.TheVpc.Upa.Types.TypeValueRewriter rewriter);

         System.Collections.Generic.IList<Net.TheVpc.Upa.Types.TypeValueRewriter> GetValueRewriters();

         string GetUnitName();

         Net.TheVpc.Upa.Types.DataType SetUnitName(string unitName);

         bool IsAssignableFrom(Net.TheVpc.Upa.Types.DataType type);

         bool IsInstance(object @object);

         void Cast(Net.TheVpc.Upa.Types.DataType type);

         object Convert(object @value);

         string GetName();

         void SetName(string name);

         Net.TheVpc.Upa.Properties GetProperties();

         void SetProperties(Net.TheVpc.Upa.Properties properties);

         Net.TheVpc.Upa.DataTypeInfo GetInfo();
    }
}
