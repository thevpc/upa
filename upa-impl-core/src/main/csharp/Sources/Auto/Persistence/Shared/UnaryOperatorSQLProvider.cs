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
    public class UnaryOperatorSQLProvider : Net.TheVpc.Upa.Impl.Persistence.Shared.AbstractSQLProvider {

        public UnaryOperatorSQLProvider()  : base(typeof(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledUnaryOperator)){

        }


        public override string GetSQL(object oo, Net.TheVpc.Upa.Persistence.EntityExecutionContext qlContext, Net.TheVpc.Upa.Impl.Persistence.SQLManager sqlManager, Net.TheVpc.Upa.Impl.Uql.ExpressionDeclarationList declarations) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledUnaryOperator o = (Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledUnaryOperator) oo;
            return o.GetOperator() + sqlManager.GetSQL(o.GetExpression(), qlContext, declarations);
        }
    }
}
