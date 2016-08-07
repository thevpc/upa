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
    public interface Field : Net.Vpc.Upa.EntityPart {

         void SetPropertyAccessType(Net.Vpc.Upa.PropertyAccessType @value);

         Net.Vpc.Upa.PropertyAccessType GetPropertyAccessType();

         void SetUnspecifiedValue(object o);

         object GetUnspecifiedValue();

        /**
             * should return a valid value of UnspecifiedValue. Actually, if
             * getUnspecifiedValue() returns UnspecifiedValue.DEFAULT. this method would
             * return type's default value.
             *
             * @return
             */
         object GetUnspecifiedValueDecoded();

         bool IsUnspecifiedValue(object @value);

         void SetDefaultObject(object o);

         object GetDefaultValue();

         object GetDefaultObject();

         System.Collections.Generic.IList<Net.Vpc.Upa.Relationship> GetManyToOneRelationships();

         void SetFormula(string formula);

         void SetFormula(Net.Vpc.Upa.Formula formula);

         void SetPersistFormula(string formula);

         void SetPersistFormula(Net.Vpc.Upa.Formula formula);

         Net.Vpc.Upa.Formula GetPersistFormula();

         int GetPersistFormulaOrder();

         void SetFormulaOrder(int order);

         void SetPersistFormulaOrder(int order);

         Net.Vpc.Upa.Formula GetUpdateFormula();

         int GetUpdateFormulaOrder();

         void SetUpdateFormula(string formula);

         void SetUpdateFormula(Net.Vpc.Upa.Formula formula);

         void SetUpdateFormulaOrder(int order);

         Net.Vpc.Upa.Formula GetSelectFormula();

         void SetSelectFormula(string formula);

         void SetSelectFormula(Net.Vpc.Upa.Formula formula);

         Net.Vpc.Upa.Types.DataType GetDataType();

         Net.Vpc.Upa.AccessLevel GetPersistAccessLevel();

         Net.Vpc.Upa.AccessLevel GetUpdateAccessLevel();

         Net.Vpc.Upa.AccessLevel GetReadAccessLevel();

         void SetPersistAccessLevel(Net.Vpc.Upa.AccessLevel accessLevel);

         void SetUpdateAccessLevel(Net.Vpc.Upa.AccessLevel accessLevel);

         void SetReadAccessLevel(Net.Vpc.Upa.AccessLevel accessLevel);

         void SetAccessLevel(Net.Vpc.Upa.AccessLevel accessLevel);

         Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.UserFieldModifier> GetUserModifiers();

         void SetUserModifiers(Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.UserFieldModifier> modifiers);

         Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.UserFieldModifier> GetUserExcludeModifiers();

         void SetUserExcludeModifiers(Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.UserFieldModifier> modifiers);

         Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.FieldModifier> GetModifiers();

         bool IsId() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         bool IsMain() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         bool IsSummary() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         bool Is(Net.Vpc.Upa.Filters.FieldFilter ff) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void SetDataType(Net.Vpc.Upa.Types.DataType datatype);

        /**
             * check is this is target or source!!!
             *
             * @param r
             */
         Net.Vpc.Upa.SearchOperator GetSearchOperator();

         void SetSearchOperator(Net.Vpc.Upa.SearchOperator @operator);

         void SetTypeTransform(Net.Vpc.Upa.Types.DataTypeTransform transform);

         Net.Vpc.Upa.Types.DataTypeTransform GetTypeTransform();

        /**
             * value of the field for the given instance
             * @param instance object instance
             * @return value of the field
             */
         object GetValue(object instance);

        /**
             * calls getValue, if the value returned is an Entity will calls getMainValue o the entity. If not will return the result of getValue
             * @param instance instance to get value on
             * @return displayable value
             */
         object GetMainValue(object instance);

         void SetValue(object instance, object @value);

         void Check(object @value);
    }
}
