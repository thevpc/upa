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



namespace Net.Vpc.Upa
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public interface FieldDescriptor {

         string GetName();

         string GetFieldPath();

         object GetDefaultObject();

         object GetUnspecifiedObject();

         Net.Vpc.Upa.Types.DataType GetDataType();

         Net.Vpc.Upa.Types.DataTypeTransformConfig[] GetTypeTransform();

         Net.Vpc.Upa.Formula GetInsertFormula();

         Net.Vpc.Upa.Formula GetUpdateFormula();

         Net.Vpc.Upa.Formula GetSelectFormula();

         int GetInsertFormulaOrder();

         int GetUpdateFormulaOrder();

         Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.UserFieldModifier> GetUserFieldModifiers();

         Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.UserFieldModifier> GetUserExcludeModifiers();

         Net.Vpc.Upa.AccessLevel GetInsertAccessLevel();

         Net.Vpc.Upa.AccessLevel GetUpdateAccessLevel();

         Net.Vpc.Upa.AccessLevel GetSelectAccessLevel();

         System.Collections.Generic.IDictionary<string , object> GetFieldParams();

         Net.Vpc.Upa.PropertyAccessType GetPropertyAccessType();

         int GetPosition();
    }
}
