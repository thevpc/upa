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
     * Date: 8/15/12
     * Time: 11:46 PM
     * To change this template use File | Settings | File Templates.
     */
    public class BetweenSQLProvider : Net.Vpc.Upa.Impl.Persistence.Shared.AbstractSQLProvider {

        public BetweenSQLProvider()  : base(typeof(Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledBetween)){

        }


        public override string GetSQL(object oo, Net.Vpc.Upa.Persistence.EntityExecutionContext qlContext, Net.Vpc.Upa.Impl.Persistence.SQLManager sqlManager, Net.Vpc.Upa.Impl.Uql.ExpressionDeclarationList declarations) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledBetween o = (Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledBetween) oo;
            string s = sqlManager.GetSQL(o.GetLeft(), qlContext, declarations) + " Between " + sqlManager.GetSQL(o.GetMin(), qlContext, declarations) + " And " + sqlManager.GetSQL(o.GetMax(), qlContext, declarations);
            return "(" + s + ")";
        }
    }
}
