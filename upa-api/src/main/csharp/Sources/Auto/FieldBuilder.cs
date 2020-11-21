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



namespace Net.TheVpc.Upa
{


    /**
     * Created by vpc on 6/9/17.
     */
    public interface FieldBuilder {

         string GetName();

         Net.TheVpc.Upa.FieldBuilder SetName(string name);

         string GetPath();

         Net.TheVpc.Upa.FieldBuilder SetPath(string fieldPath);

         object GetDefaultObject();

         Net.TheVpc.Upa.FieldBuilder SetDefaultObject(object defaultObject);

         object GetUnspecifiedObject();

         Net.TheVpc.Upa.FieldBuilder SetUnspecifiedObject(object unspecifiedObject);

         Net.TheVpc.Upa.Types.DataType GetDataType();

         Net.TheVpc.Upa.FieldBuilder SetDataType(Net.TheVpc.Upa.Types.DataType dataType);

         Net.TheVpc.Upa.Types.DataTypeTransformConfig[] GetTypeTransform();

         Net.TheVpc.Upa.FieldBuilder SetTypeTransform(Net.TheVpc.Upa.Types.DataTypeTransformConfig[] typeTransform);

         Net.TheVpc.Upa.Formula GetPersistFormula();

         Net.TheVpc.Upa.FieldBuilder SetPersistFormula(string persistFormula);

         Net.TheVpc.Upa.FieldBuilder SetPersistFormula(Net.TheVpc.Upa.Formula persistFormula);

         Net.TheVpc.Upa.Formula GetUpdateFormula();

         Net.TheVpc.Upa.FieldBuilder SetUpdateFormula(string updateFormula);

         Net.TheVpc.Upa.FieldBuilder SetUpdateFormula(Net.TheVpc.Upa.Formula updateFormula);

         Net.TheVpc.Upa.Formula GetSelectFormula();

         Net.TheVpc.Upa.FieldBuilder SetSelectFormula(Net.TheVpc.Upa.Formula selectFormula);

         Net.TheVpc.Upa.FieldBuilder SetSelectFormula(string selectFormula);

         Net.TheVpc.Upa.FieldBuilder SetLiveSelectFormula(string selectFormula);

         Net.TheVpc.Upa.FieldBuilder SetCompiledSelectFormula(string selectFormula);

         Net.TheVpc.Upa.FieldBuilder SetFormula(string formula);

         Net.TheVpc.Upa.FieldBuilder SetFormula(Net.TheVpc.Upa.Formula formula);

         Net.TheVpc.Upa.FieldBuilder SetLiveSelectFormula(Net.TheVpc.Upa.Formula selectFormula);

         Net.TheVpc.Upa.FieldBuilder SetCompiledSelectFormula(Net.TheVpc.Upa.Formula selectFormula);

         int GetPersistFormulaOrder();

         Net.TheVpc.Upa.FieldBuilder SetPersistFormulaOrder(int persistFormulaOrder);

         int GetUpdateFormulaOrder();

         Net.TheVpc.Upa.FieldBuilder SetUpdateFormulaOrder(int updateFormulaOrder);

         Net.TheVpc.Upa.FlagSet<Net.TheVpc.Upa.UserFieldModifier> GetModifiers();

         Net.TheVpc.Upa.FieldBuilder SetModifiers(Net.TheVpc.Upa.FlagSet<Net.TheVpc.Upa.UserFieldModifier> userModifiers);

         Net.TheVpc.Upa.FieldBuilder AddModifier(Net.TheVpc.Upa.UserFieldModifier userModifiers);

         Net.TheVpc.Upa.FieldBuilder RemoveModifier(Net.TheVpc.Upa.UserFieldModifier userModifiers);

         Net.TheVpc.Upa.FlagSet<Net.TheVpc.Upa.UserFieldModifier> GetExcludeModifiers();

         Net.TheVpc.Upa.FieldBuilder SetExcludeModifiers(Net.TheVpc.Upa.FlagSet<Net.TheVpc.Upa.UserFieldModifier> userExcludeModifiers);

         Net.TheVpc.Upa.FieldBuilder AddExcludeModifier(Net.TheVpc.Upa.UserFieldModifier userModifiers);

         Net.TheVpc.Upa.FieldBuilder RemoveExcludeModifier(Net.TheVpc.Upa.UserFieldModifier userModifiers);

         Net.TheVpc.Upa.FieldBuilder SetAccessLevel(Net.TheVpc.Upa.AccessLevel accessLevel);

         Net.TheVpc.Upa.AccessLevel GetPersistAccessLevel();

         Net.TheVpc.Upa.FieldBuilder SetPersistAccessLevel(Net.TheVpc.Upa.AccessLevel persistAccessLevel);

         Net.TheVpc.Upa.AccessLevel GetUpdateAccessLevel();

         Net.TheVpc.Upa.FieldBuilder SetUpdateAccessLevel(Net.TheVpc.Upa.AccessLevel updateAccessLevel);

         Net.TheVpc.Upa.AccessLevel GetReadAccessLevel();

         Net.TheVpc.Upa.FieldBuilder SetReadAccessLevel(Net.TheVpc.Upa.AccessLevel readAccessLevel);

         Net.TheVpc.Upa.FieldBuilder SetProtectionLevel(Net.TheVpc.Upa.ProtectionLevel protectionLevel);

         Net.TheVpc.Upa.ProtectionLevel GetPersistProtectionLevel();

         Net.TheVpc.Upa.FieldBuilder SetPersistProtectionLevel(Net.TheVpc.Upa.ProtectionLevel persistProtectionLevel);

         Net.TheVpc.Upa.ProtectionLevel GetUpdateProtectionLevel();

         Net.TheVpc.Upa.FieldBuilder SetUpdateProtectionLevel(Net.TheVpc.Upa.ProtectionLevel updateProtectionLevel);

         Net.TheVpc.Upa.ProtectionLevel GetReadProtectionLevel();

         Net.TheVpc.Upa.FieldBuilder SetReadProtectionLevel(Net.TheVpc.Upa.ProtectionLevel readProtectionLevel);

         System.Collections.Generic.IDictionary<string , object> GetFieldParams();

         Net.TheVpc.Upa.FieldBuilder SetFieldParams(System.Collections.Generic.IDictionary<string , object> fieldParams);

         Net.TheVpc.Upa.PropertyAccessType GetPropertyAccessType();

         Net.TheVpc.Upa.FieldBuilder SetPropertyAccessType(Net.TheVpc.Upa.PropertyAccessType propertyAccessType);

         int GetIndex();

         Net.TheVpc.Upa.FieldBuilder SetIndex(int position);

         Net.TheVpc.Upa.FieldDescriptor Build();
    }
}
