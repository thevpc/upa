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



namespace Net.TheVpc.Upa.Impl.Persistence.Shared
{


    /**
     * Created with IntelliJ IDEA.
     * User: vpc
     * Date: 8/16/12
     * Time: 10:20 PM
     * To change this template use File | Settings | File Templates.
     */
    public abstract class AbstractSQLProvider : Net.TheVpc.Upa.Impl.Persistence.SQLProvider {

        private System.Type type;

        public AbstractSQLProvider(System.Type type) {
            this.type = type;
        }


        public virtual System.Type GetExpressionType() {
            return type;
        }
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract string GetSQL(object arg1, Net.TheVpc.Upa.Persistence.EntityExecutionContext arg2, Net.TheVpc.Upa.Impl.Persistence.SQLManager arg3, Net.TheVpc.Upa.Impl.Uql.ExpressionDeclarationList arg4);
    }
}
