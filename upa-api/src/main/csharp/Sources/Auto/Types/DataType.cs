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


    /**
     * Created by vpc on 6/17/16.
     */
    public interface DataType : System.ICloneable {

         object GetDefaultUnspecifiedValue();

         void SetDefaultUnspecifiedValue(object defaultUnspecifiedValue);

         object GetDefaultValue();

         void SetDefaultValue(object defaultValue);

         object GetDefaultNonNullValue();

         void SetDefaultNonNullValue(object defaultNonNullValue);

         bool IsNullable();

         void SetNullable(bool enable);

         System.Type GetPlatformType();

         int GetScale();

         int GetPrecision();

         object Rewrite(object @value, string name, string description) /* throws Net.Vpc.Upa.Types.ConstraintsException */ ;

         void Check(object @value, string name, string description) /* throws Net.Vpc.Upa.Types.ConstraintsException */ ;

         object Copy();

         System.Collections.Generic.IList<Net.Vpc.Upa.Types.TypeValueValidator> GetValueValidators();

         Net.Vpc.Upa.Types.DataType AddValueValidator(Net.Vpc.Upa.Types.TypeValueValidator validator);

         Net.Vpc.Upa.Types.DataType RemoveValueValidator(Net.Vpc.Upa.Types.TypeValueValidator validator);

         Net.Vpc.Upa.Types.DataType AddValueRewriter(Net.Vpc.Upa.Types.TypeValueRewriter rewriter);

         Net.Vpc.Upa.Types.DataType RemoveValueReWriter(Net.Vpc.Upa.Types.TypeValueRewriter rewriter);

         System.Collections.Generic.IList<Net.Vpc.Upa.Types.TypeValueRewriter> GetValueRewriters();

         string GetUnitName();

         Net.Vpc.Upa.Types.DataType SetUnitName(string unitName);

         bool IsAssignableFrom(Net.Vpc.Upa.Types.DataType type);

         bool IsInstance(object @object);

         void Cast(Net.Vpc.Upa.Types.DataType type);

         object Convert(object @value);

         string GetName();

         void SetName(string name);

         Net.Vpc.Upa.Properties GetProperties();

         void SetProperties(Net.Vpc.Upa.Properties properties);
    }
}
