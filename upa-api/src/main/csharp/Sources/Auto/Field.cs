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
    public interface Field : Net.Vpc.Upa.EntityPart {

         Net.Vpc.Upa.PropertyAccessType GetPropertyAccessType();

         void SetPropertyAccessType(Net.Vpc.Upa.PropertyAccessType @value);

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

         System.Collections.Generic.IList<Net.Vpc.Upa.Relationship> GetManyToOneRelationships();

         void SetFormula(string formula);

         void SetFormula(Net.Vpc.Upa.Formula formula);

         void SetPersistFormula(string formula);

         Net.Vpc.Upa.Formula GetPersistFormula();

         void SetPersistFormula(Net.Vpc.Upa.Formula formula);

         int GetPersistFormulaOrder();

         void SetPersistFormulaOrder(int order);

         void SetFormulaOrder(int order);

         Net.Vpc.Upa.Formula GetUpdateFormula();

         void SetUpdateFormula(Net.Vpc.Upa.Formula formula);

         void SetUpdateFormula(string formula);

         int GetUpdateFormulaOrder();

         void SetUpdateFormulaOrder(int order);

         Net.Vpc.Upa.Formula GetSelectFormula();

         void SetSelectFormula(Net.Vpc.Upa.Formula formula);

         void SetSelectFormula(string formula);

         Net.Vpc.Upa.Types.DataType GetDataType();

         void SetDataType(Net.Vpc.Upa.Types.DataType datatype);

         Net.Vpc.Upa.AccessLevel GetPersistAccessLevel();

         void SetPersistAccessLevel(Net.Vpc.Upa.AccessLevel accessLevel);

         Net.Vpc.Upa.AccessLevel GetUpdateAccessLevel();

         void SetUpdateAccessLevel(Net.Vpc.Upa.AccessLevel accessLevel);

         Net.Vpc.Upa.AccessLevel GetReadAccessLevel();

         void SetReadAccessLevel(Net.Vpc.Upa.AccessLevel accessLevel);

         void SetAccessLevel(Net.Vpc.Upa.AccessLevel accessLevel);

         Net.Vpc.Upa.ProtectionLevel GetPersistProtectionLevel();

         void SetPersistProtectionLevel(Net.Vpc.Upa.ProtectionLevel protectionLevel);

         Net.Vpc.Upa.ProtectionLevel GetUpdateProtectionLevel();

         void SetUpdateProtectionLevel(Net.Vpc.Upa.ProtectionLevel protectionLevel);

         Net.Vpc.Upa.ProtectionLevel GetReadProtectionLevel();

         void SetReadProtectionLevel(Net.Vpc.Upa.ProtectionLevel protectionLevel);

         void SetProtectionLevel(Net.Vpc.Upa.ProtectionLevel protectionLevel);

         Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.UserFieldModifier> GetUserModifiers();

         void SetUserModifiers(Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.UserFieldModifier> modifiers);

         Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.UserFieldModifier> GetUserExcludeModifiers();

         void SetUserExcludeModifiers(Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.UserFieldModifier> modifiers);

         Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.FieldModifier> GetModifiers();

         bool IsId();

         bool IsGeneratedId();

         bool IsSystem();

         bool IsMain();

         bool IsSummary();

         bool Is(Net.Vpc.Upa.Filters.FieldFilter filter);

         Net.Vpc.Upa.SearchOperator GetSearchOperator();

         void SetSearchOperator(Net.Vpc.Upa.SearchOperator @operator);

         Net.Vpc.Upa.Types.DataTypeTransform GetTypeTransform();

         void SetTypeTransform(Net.Vpc.Upa.Types.DataTypeTransform transform);

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

         Net.Vpc.Upa.Relationship GetManyToOneRelationship();

         Net.Vpc.Upa.ProtectionLevel GetProtectionLevel(Net.Vpc.Upa.AccessMode mode);

         Net.Vpc.Upa.AccessLevel GetAccessLevel(Net.Vpc.Upa.AccessMode mode);

         Net.Vpc.Upa.AccessLevel GetEffectiveAccessLevel(Net.Vpc.Upa.AccessMode mode);

         Net.Vpc.Upa.AccessLevel GetEffectivePersistAccessLevel();

         Net.Vpc.Upa.AccessLevel GetEffectiveUpdateAccessLevel();

         Net.Vpc.Upa.AccessLevel GetEffectiveReadAccessLevel();

         Net.Vpc.Upa.FieldInfo GetInfo();
    }
}
