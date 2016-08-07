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



namespace Net.Vpc.Upa.Impl.Event
{


    /**
     *
     * @author taha.bensalah@gmail.com
     */
    internal class RelationshipTargetFormulaUpdaterInterceptorSupportBaseInterceptor : Net.Vpc.Upa.Callbacks.UpdateFormulaInterceptor {

        private readonly Net.Vpc.Upa.Callbacks.UpdateRelationshipTargetFormulaInterceptor entityTargetFormulaUpdaterInterceptor;

        public RelationshipTargetFormulaUpdaterInterceptorSupportBaseInterceptor(Net.Vpc.Upa.Callbacks.UpdateRelationshipTargetFormulaInterceptor entityTargetFormulaUpdaterInterceptor) {
            this.entityTargetFormulaUpdaterInterceptor = entityTargetFormulaUpdaterInterceptor;
        }


        public virtual Net.Vpc.Upa.Filters.FieldFilter GetFormulaFields() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return entityTargetFormulaUpdaterInterceptor.GetFormulaFields();
        }


        public virtual Net.Vpc.Upa.Expressions.Expression TranslateExpression(Net.Vpc.Upa.Expressions.Expression e) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return entityTargetFormulaUpdaterInterceptor.TranslateExpression(e);
        }
    }
}
