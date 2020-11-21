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
     * Date: 8/15/12
     * Time: 11:46 PM
     * To change this template use File | Settings | File Templates.
     */
    public class CurrentUserSQLProvider : Net.TheVpc.Upa.Impl.Persistence.Shared.AbstractSQLProvider {

        public CurrentUserSQLProvider()  : base(typeof(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledCurrentUser)){

        }


        public override string GetSQL(object o, Net.TheVpc.Upa.Persistence.EntityExecutionContext qlContext, Net.TheVpc.Upa.Impl.Persistence.SQLManager sqlManager, Net.TheVpc.Upa.Impl.Uql.ExpressionDeclarationList declarations) {
            Net.TheVpc.Upa.UserPrincipal user = qlContext.GetPersistenceUnit().GetUserPrincipal();
            return sqlManager.GetMarshallManager().FormatSqlValue(user == null ? "anonymous" : user.GetName());
        }
    }
}
