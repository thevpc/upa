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
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public interface FieldDescriptor {

         string GetName();

         string GetPath();

         object GetDefaultObject();

         object GetUnspecifiedObject();

         Net.Vpc.Upa.Types.DataType GetDataType();

         Net.Vpc.Upa.Types.DataTypeTransformConfig[] GetTypeTransform();

         Net.Vpc.Upa.Formula GetPersistFormula();

         Net.Vpc.Upa.Formula GetUpdateFormula();

         Net.Vpc.Upa.Formula GetSelectFormula();

         int GetPersistFormulaOrder();

         int GetUpdateFormulaOrder();

         Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.UserFieldModifier> GetModifiers();

         Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.UserFieldModifier> GetExcludeModifiers();

         Net.Vpc.Upa.AccessLevel GetPersistAccessLevel();

         Net.Vpc.Upa.AccessLevel GetUpdateAccessLevel();

         Net.Vpc.Upa.AccessLevel GetReadAccessLevel();

         Net.Vpc.Upa.ProtectionLevel GetPersistProtectionLevel();

         Net.Vpc.Upa.ProtectionLevel GetUpdateProtectionLevel();

         Net.Vpc.Upa.ProtectionLevel GetReadProtectionLevel();

         System.Collections.Generic.IDictionary<string , object> GetFieldParams();

         Net.Vpc.Upa.PropertyAccessType GetPropertyAccessType();

         int GetIndex();
    }
}
