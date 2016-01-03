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

         System.Collections.Generic.IList<Net.Vpc.Upa.Relationship> GetRelationships();

         void SetFormula(string formula);

         void SetFormula(Net.Vpc.Upa.Formula formula);

         void SetInsertFormula(string formula);

         void SetInsertFormula(Net.Vpc.Upa.Formula formula);

         Net.Vpc.Upa.Formula GetInsertFormula();

         int GetInsertFormulaOrder();

         void SetFormulaOrder(int order);

         void SetInsertFormulaOrder(int order);

         Net.Vpc.Upa.Formula GetUpdateFormula();

         int GetUpdateFormulaOrder();

         void SetUpdateFormula(string formula);

         void SetUpdateFormula(Net.Vpc.Upa.Formula formula);

         void SetUpdateFormulaOrder(int order);

         Net.Vpc.Upa.Formula GetSelectFormula();

         void SetSelectFormula(string formula);

         void SetSelectFormula(Net.Vpc.Upa.Formula formula);

         Net.Vpc.Upa.Types.DataType GetDataType();

         Net.Vpc.Upa.AccessLevel GetInsertAccessLevel();

         Net.Vpc.Upa.AccessLevel GetUpdateAccessLevel();

         Net.Vpc.Upa.AccessLevel GetSelectAccessLevel();

         void SetInsertAccessLevel(Net.Vpc.Upa.AccessLevel accessLevel);

         void SetUpdateAccessLevel(Net.Vpc.Upa.AccessLevel accessLevel);

         void SetSelectAccessLevel(Net.Vpc.Upa.AccessLevel accessLevel);

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
         void AddTargetRelationship(Net.Vpc.Upa.Relationship r);

         Net.Vpc.Upa.Relationship[] GetTargetRelationships();

         Net.Vpc.Upa.SearchOperator GetSearchOperator();

         void SetSearchOperator(Net.Vpc.Upa.SearchOperator @operator);

         void SetTypeTransform(Net.Vpc.Upa.Types.DataTypeTransform transform);

         Net.Vpc.Upa.Types.DataTypeTransform GetTypeTransform();
    }
}
