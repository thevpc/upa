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
    public interface Field : Net.TheVpc.Upa.EntityPart {

         Net.TheVpc.Upa.PropertyAccessType GetPropertyAccessType();

         void SetPropertyAccessType(Net.TheVpc.Upa.PropertyAccessType @value);

         object GetUnspecifiedValue();

         void SetUnspecifiedValue(object o);

        /**
             * should return a valid value of UnspecifiedValue. Actually, if
             * getUnspecifiedValue() returns UnspecifiedValue.DEFAULT. this method would
             * return type's default value.
             *
             * @return
             */
         object GetUnspecifiedValueDecoded();

         bool IsUnspecifiedValue(object @value);

         object GetDefaultValue();

         object GetDefaultObject();

         void SetDefaultObject(object o);

         System.Collections.Generic.IList<Net.TheVpc.Upa.Relationship> GetManyToOneRelationships();

         void SetFormula(string formula);

         void SetFormula(Net.TheVpc.Upa.Formula formula);

         void SetPersistFormula(string formula);

         Net.TheVpc.Upa.Formula GetPersistFormula();

         void SetPersistFormula(Net.TheVpc.Upa.Formula formula);

         int GetPersistFormulaOrder();

         void SetPersistFormulaOrder(int order);

         void SetFormulaOrder(int order);

         Net.TheVpc.Upa.Formula GetUpdateFormula();

         void SetUpdateFormula(Net.TheVpc.Upa.Formula formula);

         void SetUpdateFormula(string formula);

         int GetUpdateFormulaOrder();

         void SetUpdateFormulaOrder(int order);

         Net.TheVpc.Upa.Formula GetSelectFormula();

         void SetSelectFormula(Net.TheVpc.Upa.Formula formula);

         void SetSelectFormula(string formula);

         Net.TheVpc.Upa.Types.DataType GetDataType();

         void SetDataType(Net.TheVpc.Upa.Types.DataType datatype);

         Net.TheVpc.Upa.AccessLevel GetPersistAccessLevel();

         void SetPersistAccessLevel(Net.TheVpc.Upa.AccessLevel accessLevel);

         Net.TheVpc.Upa.AccessLevel GetUpdateAccessLevel();

         void SetUpdateAccessLevel(Net.TheVpc.Upa.AccessLevel accessLevel);

         Net.TheVpc.Upa.AccessLevel GetReadAccessLevel();

         void SetReadAccessLevel(Net.TheVpc.Upa.AccessLevel accessLevel);

         void SetAccessLevel(Net.TheVpc.Upa.AccessLevel accessLevel);

         Net.TheVpc.Upa.ProtectionLevel GetPersistProtectionLevel();

         void SetPersistProtectionLevel(Net.TheVpc.Upa.ProtectionLevel protectionLevel);

         Net.TheVpc.Upa.ProtectionLevel GetUpdateProtectionLevel();

         void SetUpdateProtectionLevel(Net.TheVpc.Upa.ProtectionLevel protectionLevel);

         Net.TheVpc.Upa.ProtectionLevel GetReadProtectionLevel();

         void SetReadProtectionLevel(Net.TheVpc.Upa.ProtectionLevel protectionLevel);

         void SetProtectionLevel(Net.TheVpc.Upa.ProtectionLevel protectionLevel);

         Net.TheVpc.Upa.FlagSet<Net.TheVpc.Upa.UserFieldModifier> GetUserModifiers();

         void SetUserModifiers(Net.TheVpc.Upa.FlagSet<Net.TheVpc.Upa.UserFieldModifier> modifiers);

         Net.TheVpc.Upa.FlagSet<Net.TheVpc.Upa.UserFieldModifier> GetUserExcludeModifiers();

         void SetUserExcludeModifiers(Net.TheVpc.Upa.FlagSet<Net.TheVpc.Upa.UserFieldModifier> modifiers);

         Net.TheVpc.Upa.FlagSet<Net.TheVpc.Upa.FieldModifier> GetModifiers();

         bool IsId();

         bool IsGeneratedId();

         bool IsSystem();

         bool IsMain();

         bool IsSummary();

         bool Is(Net.TheVpc.Upa.Filters.FieldFilter filter);

         Net.TheVpc.Upa.SearchOperator GetSearchOperator();

         void SetSearchOperator(Net.TheVpc.Upa.SearchOperator @operator);

         Net.TheVpc.Upa.Types.DataTypeTransform GetTypeTransform();

         void SetTypeTransform(Net.TheVpc.Upa.Types.DataTypeTransform transform);

        /**
             * value of the field for the given instance
             *
             * @param instance object instance
             * @return value of the field
             */
         object GetValue(object instance);

        /**
             * calls getValue, if the value returned is an Entity will calls getMainValue o the entity. If not will return the result of getValue
             *
             * @param instance instance to get value on
             * @return displayable value
             */
         object GetMainValue(object instance);

         void SetValue(object instance, object @value);

         void Check(object @value);

         int GetPreferredIndex();

         void SetPreferredIndex(int preferredIndex);

         bool IsManyToOne();

         Net.TheVpc.Upa.Relationship GetManyToOneRelationship();

         Net.TheVpc.Upa.ProtectionLevel GetProtectionLevel(Net.TheVpc.Upa.AccessMode mode);

         Net.TheVpc.Upa.AccessLevel GetAccessLevel(Net.TheVpc.Upa.AccessMode mode);

         Net.TheVpc.Upa.AccessLevel GetEffectiveAccessLevel(Net.TheVpc.Upa.AccessMode mode);

         Net.TheVpc.Upa.AccessLevel GetEffectivePersistAccessLevel();

         Net.TheVpc.Upa.AccessLevel GetEffectiveUpdateAccessLevel();

         Net.TheVpc.Upa.AccessLevel GetEffectiveReadAccessLevel();

         Net.TheVpc.Upa.FieldInfo GetInfo();
    }
}
