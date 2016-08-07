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



namespace Net.Vpc.Upa.Impl.Persistence.Shared
{


    /**
     * Created with IntelliJ IDEA.
     * User: vpc
     * Date: 8/16/12
     * Time: 10:20 PM
     * To change this template use File | Settings | File Templates.
     */
    public abstract class AbstractSQLProvider : Net.Vpc.Upa.Impl.Persistence.SQLProvider {

        private System.Type type;

        public AbstractSQLProvider(System.Type type) {
            this.type = type;
        }


        public virtual System.Type GetExpressionType() {
            return type;
        }
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract string GetSQL(object arg1, Net.Vpc.Upa.Persistence.EntityExecutionContext arg2, Net.Vpc.Upa.Impl.Persistence.SQLManager arg3, Net.Vpc.Upa.Impl.Uql.ExpressionDeclarationList arg4);
    }
}
