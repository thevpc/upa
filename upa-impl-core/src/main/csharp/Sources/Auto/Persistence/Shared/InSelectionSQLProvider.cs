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
    public class InSelectionSQLProvider : Net.TheVpc.Upa.Impl.Persistence.Shared.AbstractSQLProvider {

        public InSelectionSQLProvider()  : base(typeof(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledInSelection)){

        }


        public override string GetSQL(object oo, Net.TheVpc.Upa.Persistence.EntityExecutionContext qlContext, Net.TheVpc.Upa.Impl.Persistence.SQLManager sqlManager, Net.TheVpc.Upa.Impl.Uql.ExpressionDeclarationList declarations) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledInSelection o = (Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledInSelection) oo;
            Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression[] left = o.GetLeft();
            Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect query = o.GetSelection();
            if (left.Length == 1) {
                string q = sqlManager.GetSQL(left[0], qlContext, declarations) + " in (" + sqlManager.GetSQL(query, qlContext, declarations) + ")";
                return '(' + q + ')';
            }
            Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledUplet uplet = new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledUplet(left);
            System.Text.StringBuilder stringBuffer = new System.Text.StringBuilder(sqlManager.GetSQL(uplet, qlContext, declarations));
            stringBuffer.Append(" In (");
            stringBuffer.Append(sqlManager.GetSQL(query, qlContext, declarations));
            stringBuffer.Append(")");
            return '(' + stringBuffer.ToString() + ')';
        }
    }
}
