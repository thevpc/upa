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


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 9/10/12 1:25 AM
     */
    public abstract class FormulaUpdaterDataInterceptorAdapter : Net.TheVpc.Upa.Callbacks.UpdateFormulaInterceptor {

        private Net.TheVpc.Upa.Filters.FieldFilter formulaFields;

        public FormulaUpdaterDataInterceptorAdapter(Net.TheVpc.Upa.Filters.FieldFilter formulaFields) {
            this.formulaFields = formulaFields;
        }


        public virtual Net.TheVpc.Upa.Filters.FieldFilter GetFormulaFields() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return formulaFields;
        }
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract Net.TheVpc.Upa.Expressions.Expression TranslateExpression(Net.TheVpc.Upa.Expressions.Expression arg1);
    }
}
