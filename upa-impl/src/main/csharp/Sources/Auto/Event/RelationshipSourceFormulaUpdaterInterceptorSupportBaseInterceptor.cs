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
     * @author vpc
     */
    internal class RelationshipSourceFormulaUpdaterInterceptorSupportBaseInterceptor : Net.Vpc.Upa.Callbacks.UpdateFormulaInterceptor {

        private readonly Net.Vpc.Upa.Callbacks.UpdateRelationshipSourceFormulaInterceptor entityDetailFormulaUpdaterInterceptor;

        public RelationshipSourceFormulaUpdaterInterceptorSupportBaseInterceptor(Net.Vpc.Upa.Callbacks.UpdateRelationshipSourceFormulaInterceptor entityDetailFormulaUpdaterInterceptor) {
            this.entityDetailFormulaUpdaterInterceptor = entityDetailFormulaUpdaterInterceptor;
        }


        public virtual Net.Vpc.Upa.Filters.FieldFilter GetFormulaFields() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return entityDetailFormulaUpdaterInterceptor.GetFormulaFields();
        }


        public virtual Net.Vpc.Upa.Expressions.Expression TranslateExpression(Net.Vpc.Upa.Expressions.Expression e) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return entityDetailFormulaUpdaterInterceptor.TranslateExpression(e);
        }
    }
}
