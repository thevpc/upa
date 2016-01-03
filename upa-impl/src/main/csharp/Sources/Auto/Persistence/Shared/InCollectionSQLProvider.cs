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
    public class InCollectionSQLProvider : Net.Vpc.Upa.Impl.Persistence.Shared.AbstractSQLProvider {

        public InCollectionSQLProvider()  : base(typeof(Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledInCollection)){

        }


        public override string GetSQL(object oo, Net.Vpc.Upa.Persistence.EntityExecutionContext qlContext, Net.Vpc.Upa.Impl.Persistence.SQLManager sqlManager, Net.Vpc.Upa.Impl.Uql.ExpressionDeclarationList declarations) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledInCollection o = (Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledInCollection) oo;
            Net.Vpc.Upa.Persistence.PersistenceStore qlm = qlContext.GetPersistenceStore();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            int mySize = o.GetRightSize();
            if (mySize == 0) {
                sb.Append("1 <> 1");
            } else {
                if (mySize == 1) {
                    sb.Append(sqlManager.GetSQL(o.GetLeft(), qlContext, declarations));
                    Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression e = o.GetRight(0);
                    if (e == null || (e is Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledLiteral && ((Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledLiteral) e).GetValue() == null)) {
                        sb.Append(" Is Null");
                    } else {
                        sb.Append(" = ");
                        sb.Append(sqlManager.GetSQL(e, qlContext, declarations));
                    }
                } else {
                    sb.Append(sqlManager.GetSQL(o.GetLeft(), qlContext, declarations));
                    sb.Append(" In (");
                    for (int i = 0; i < mySize; i++) {
                        if (i > 0) {
                            sb.Append(",");
                        }
                        Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression e = o.GetRight(i);
                        if (e == null) {
                            sb.Append("Null");
                        } else {
                            sb.Append(sqlManager.GetSQL(e, qlContext, declarations));
                        }
                    }
                    sb.Append(")");
                }
            }
            return '(' + sb.ToString() + ')';
        }
    }
}
