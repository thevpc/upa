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
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public interface FieldDescriptor {

         string GetName();

         string GetPath();

         object GetDefaultObject();

         object GetUnspecifiedObject();

         Net.TheVpc.Upa.Types.DataType GetDataType();

         Net.TheVpc.Upa.Types.DataTypeTransformConfig[] GetTypeTransform();

         Net.TheVpc.Upa.Formula GetPersistFormula();

         Net.TheVpc.Upa.Formula GetUpdateFormula();

         Net.TheVpc.Upa.Formula GetSelectFormula();

         int GetPersistFormulaOrder();

         int GetUpdateFormulaOrder();

         Net.TheVpc.Upa.FlagSet<Net.TheVpc.Upa.UserFieldModifier> GetModifiers();

         Net.TheVpc.Upa.FlagSet<Net.TheVpc.Upa.UserFieldModifier> GetExcludeModifiers();

         Net.TheVpc.Upa.AccessLevel GetPersistAccessLevel();

         Net.TheVpc.Upa.AccessLevel GetUpdateAccessLevel();

         Net.TheVpc.Upa.AccessLevel GetReadAccessLevel();

         Net.TheVpc.Upa.ProtectionLevel GetPersistProtectionLevel();

         Net.TheVpc.Upa.ProtectionLevel GetUpdateProtectionLevel();

         Net.TheVpc.Upa.ProtectionLevel GetReadProtectionLevel();

         System.Collections.Generic.IDictionary<string , object> GetFieldParams();

         Net.TheVpc.Upa.PropertyAccessType GetPropertyAccessType();

         int GetIndex();
    }
}
