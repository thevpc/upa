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



namespace Net.TheVpc.Upa.Callbacks
{


    public interface UpdateRelationshipTargetFormulaInterceptor : Net.TheVpc.Upa.Callbacks.EntityInterceptor {

         string GetRelationshipName();

         Net.TheVpc.Upa.Filters.FieldFilter GetFormulaFields();

         Net.TheVpc.Upa.Filters.FieldFilter GetConditionFields();

         Net.TheVpc.Upa.Expressions.Expression TranslateExpression(Net.TheVpc.Upa.Expressions.Expression e) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;
    }
}
