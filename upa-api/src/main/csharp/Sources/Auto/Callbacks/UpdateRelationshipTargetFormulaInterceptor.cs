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



namespace Net.Vpc.Upa.Callbacks
{


    public interface UpdateRelationshipTargetFormulaInterceptor : Net.Vpc.Upa.Callbacks.EntityInterceptor {

         string GetRelationshipName();

         Net.Vpc.Upa.Filters.FieldFilter GetFormulaFields();

         Net.Vpc.Upa.Filters.FieldFilter GetConditionFields();

         Net.Vpc.Upa.Expressions.Expression TranslateExpression(Net.Vpc.Upa.Expressions.Expression e) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;
    }
}
