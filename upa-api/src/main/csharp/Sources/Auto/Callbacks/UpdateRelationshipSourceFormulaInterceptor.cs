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



namespace Net.Vpc.Upa.Callbacks
{


    public interface UpdateRelationshipSourceFormulaInterceptor : Net.Vpc.Upa.Callbacks.EntityInterceptor {

         string GetRelationshipName() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.Filters.FieldFilter GetFormulaFields() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.Filters.FieldFilter GetConditionFields() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.Expressions.Expression TranslateExpression(Net.Vpc.Upa.Expressions.Expression e) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;
    }
}
