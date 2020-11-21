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



namespace Net.TheVpc.Upa.Impl.Event
{


    /**
     *
     * @author taha.bensalah@gmail.com
     */
    internal class RelationshipSourceFormulaUpdaterInterceptorSupportBaseInterceptor : Net.TheVpc.Upa.Callbacks.UpdateFormulaInterceptor {

        private readonly Net.TheVpc.Upa.Callbacks.UpdateRelationshipSourceFormulaInterceptor entityDetailFormulaUpdaterInterceptor;

        public RelationshipSourceFormulaUpdaterInterceptorSupportBaseInterceptor(Net.TheVpc.Upa.Callbacks.UpdateRelationshipSourceFormulaInterceptor entityDetailFormulaUpdaterInterceptor) {
            this.entityDetailFormulaUpdaterInterceptor = entityDetailFormulaUpdaterInterceptor;
        }


        public virtual Net.TheVpc.Upa.Filters.FieldFilter GetFormulaFields() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return entityDetailFormulaUpdaterInterceptor.GetFormulaFields();
        }


        public virtual Net.TheVpc.Upa.Expressions.Expression TranslateExpression(Net.TheVpc.Upa.Expressions.Expression e) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return entityDetailFormulaUpdaterInterceptor.TranslateExpression(e);
        }
    }
}
