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
    public class InSelectionSQLProvider : Net.Vpc.Upa.Impl.Persistence.Shared.AbstractSQLProvider {

        public InSelectionSQLProvider()  : base(typeof(Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledInSelection)){

        }


        public override string GetSQL(object oo, Net.Vpc.Upa.Persistence.EntityExecutionContext qlContext, Net.Vpc.Upa.Impl.Persistence.SQLManager sqlManager, Net.Vpc.Upa.Impl.Uql.ExpressionDeclarationList declarations) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledInSelection o = (Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledInSelection) oo;
            Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression[] left = o.GetLeft();
            Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect query = o.GetSelection();
            if (left.Length == 1) {
                string q = sqlManager.GetSQL(left[0], qlContext, declarations) + " in (" + sqlManager.GetSQL(query, qlContext, declarations) + ")";
                return '(' + q + ')';
            }
            Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledUplet uplet = new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledUplet(left);
            System.Text.StringBuilder stringBuffer = new System.Text.StringBuilder(sqlManager.GetSQL(uplet, qlContext, declarations));
            stringBuffer.Append(" In (");
            stringBuffer.Append(sqlManager.GetSQL(query, qlContext, declarations));
            stringBuffer.Append(")");
            return '(' + stringBuffer.ToString() + ')';
        }
    }
}
