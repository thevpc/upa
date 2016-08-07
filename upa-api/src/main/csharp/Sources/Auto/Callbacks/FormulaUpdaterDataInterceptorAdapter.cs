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


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 9/10/12 1:25 AM
     */
    public abstract class FormulaUpdaterDataInterceptorAdapter : Net.Vpc.Upa.Callbacks.UpdateFormulaInterceptor {

        private Net.Vpc.Upa.Filters.FieldFilter formulaFields;

        public FormulaUpdaterDataInterceptorAdapter(Net.Vpc.Upa.Filters.FieldFilter formulaFields) {
            this.formulaFields = formulaFields;
        }


        public virtual Net.Vpc.Upa.Filters.FieldFilter GetFormulaFields() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return formulaFields;
        }
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract Net.Vpc.Upa.Expressions.Expression TranslateExpression(Net.Vpc.Upa.Expressions.Expression arg1);
    }
}
