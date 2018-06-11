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



namespace Net.Vpc.Upa
{


    /**
     * Created by vpc on 6/9/17.
     */
    public interface FieldBuilder {

         string GetName();

         Net.Vpc.Upa.FieldBuilder SetName(string name);

         string GetPath();

         Net.Vpc.Upa.FieldBuilder SetPath(string fieldPath);

         object GetDefaultObject();

         Net.Vpc.Upa.FieldBuilder SetDefaultObject(object defaultObject);

         object GetUnspecifiedObject();

         Net.Vpc.Upa.FieldBuilder SetUnspecifiedObject(object unspecifiedObject);

         Net.Vpc.Upa.Types.DataType GetDataType();

         Net.Vpc.Upa.FieldBuilder SetDataType(Net.Vpc.Upa.Types.DataType dataType);

         Net.Vpc.Upa.Types.DataTypeTransformConfig[] GetTypeTransform();

         Net.Vpc.Upa.FieldBuilder SetTypeTransform(Net.Vpc.Upa.Types.DataTypeTransformConfig[] typeTransform);

         Net.Vpc.Upa.Formula GetPersistFormula();

         Net.Vpc.Upa.FieldBuilder SetPersistFormula(string persistFormula);

         Net.Vpc.Upa.FieldBuilder SetPersistFormula(Net.Vpc.Upa.Formula persistFormula);

         Net.Vpc.Upa.Formula GetUpdateFormula();

         Net.Vpc.Upa.FieldBuilder SetUpdateFormula(string updateFormula);

         Net.Vpc.Upa.FieldBuilder SetUpdateFormula(Net.Vpc.Upa.Formula updateFormula);

         Net.Vpc.Upa.Formula GetSelectFormula();

         Net.Vpc.Upa.FieldBuilder SetSelectFormula(Net.Vpc.Upa.Formula selectFormula);

         Net.Vpc.Upa.FieldBuilder SetSelectFormula(string selectFormula);

         Net.Vpc.Upa.FieldBuilder SetLiveSelectFormula(string selectFormula);

         Net.Vpc.Upa.FieldBuilder SetCompiledSelectFormula(string selectFormula);

         Net.Vpc.Upa.FieldBuilder SetFormula(string formula);

         Net.Vpc.Upa.FieldBuilder SetFormula(Net.Vpc.Upa.Formula formula);

         Net.Vpc.Upa.FieldBuilder SetLiveSelectFormula(Net.Vpc.Upa.Formula selectFormula);

         Net.Vpc.Upa.FieldBuilder SetCompiledSelectFormula(Net.Vpc.Upa.Formula selectFormula);

         int GetPersistFormulaOrder();

         Net.Vpc.Upa.FieldBuilder SetPersistFormulaOrder(int persistFormulaOrder);

         int GetUpdateFormulaOrder();

         Net.Vpc.Upa.FieldBuilder SetUpdateFormulaOrder(int updateFormulaOrder);

         Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.UserFieldModifier> GetModifiers();

         Net.Vpc.Upa.FieldBuilder SetModifiers(Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.UserFieldModifier> userModifiers);

         Net.Vpc.Upa.FieldBuilder AddModifier(Net.Vpc.Upa.UserFieldModifier userModifiers);

         Net.Vpc.Upa.FieldBuilder RemoveModifier(Net.Vpc.Upa.UserFieldModifier userModifiers);

         Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.UserFieldModifier> GetExcludeModifiers();

         Net.Vpc.Upa.FieldBuilder SetExcludeModifiers(Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.UserFieldModifier> userExcludeModifiers);

         Net.Vpc.Upa.FieldBuilder AddExcludeModifier(Net.Vpc.Upa.UserFieldModifier userModifiers);

         Net.Vpc.Upa.FieldBuilder RemoveExcludeModifier(Net.Vpc.Upa.UserFieldModifier userModifiers);

         Net.Vpc.Upa.FieldBuilder SetAccessLevel(Net.Vpc.Upa.AccessLevel accessLevel);

         Net.Vpc.Upa.AccessLevel GetPersistAccessLevel();

         Net.Vpc.Upa.FieldBuilder SetPersistAccessLevel(Net.Vpc.Upa.AccessLevel persistAccessLevel);

         Net.Vpc.Upa.AccessLevel GetUpdateAccessLevel();

         Net.Vpc.Upa.FieldBuilder SetUpdateAccessLevel(Net.Vpc.Upa.AccessLevel updateAccessLevel);

         Net.Vpc.Upa.AccessLevel GetReadAccessLevel();

         Net.Vpc.Upa.FieldBuilder SetReadAccessLevel(Net.Vpc.Upa.AccessLevel readAccessLevel);

         Net.Vpc.Upa.FieldBuilder SetProtectionLevel(Net.Vpc.Upa.ProtectionLevel protectionLevel);

         Net.Vpc.Upa.ProtectionLevel GetPersistProtectionLevel();

         Net.Vpc.Upa.FieldBuilder SetPersistProtectionLevel(Net.Vpc.Upa.ProtectionLevel persistProtectionLevel);

         Net.Vpc.Upa.ProtectionLevel GetUpdateProtectionLevel();

         Net.Vpc.Upa.FieldBuilder SetUpdateProtectionLevel(Net.Vpc.Upa.ProtectionLevel updateProtectionLevel);

         Net.Vpc.Upa.ProtectionLevel GetReadProtectionLevel();

         Net.Vpc.Upa.FieldBuilder SetReadProtectionLevel(Net.Vpc.Upa.ProtectionLevel readProtectionLevel);

         System.Collections.Generic.IDictionary<string , object> GetFieldParams();

         Net.Vpc.Upa.FieldBuilder SetFieldParams(System.Collections.Generic.IDictionary<string , object> fieldParams);

         Net.Vpc.Upa.PropertyAccessType GetPropertyAccessType();

         Net.Vpc.Upa.FieldBuilder SetPropertyAccessType(Net.Vpc.Upa.PropertyAccessType propertyAccessType);

         int GetIndex();

         Net.Vpc.Upa.FieldBuilder SetIndex(int position);

         Net.Vpc.Upa.FieldDescriptor Build();
    }
}
