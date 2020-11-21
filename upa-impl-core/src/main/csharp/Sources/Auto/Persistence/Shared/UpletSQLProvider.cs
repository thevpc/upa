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
    public class UpletSQLProvider : Net.TheVpc.Upa.Impl.Persistence.Shared.AbstractSQLProvider {

        public UpletSQLProvider()  : base(typeof(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledUplet)){

        }


        public override string GetSQL(object oo, Net.TheVpc.Upa.Persistence.EntityExecutionContext qlContext, Net.TheVpc.Upa.Impl.Persistence.SQLManager sqlManager, Net.TheVpc.Upa.Impl.Uql.ExpressionDeclarationList declarations) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledUplet o = (Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledUplet) oo;
            //        PersistenceUnitManager queryLanguageManager = qlContext.getPersistenceUnitManager();
            Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression sql;
            Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression[] expressions = o.GetExpressions();
            if (expressions.Length > 1) {
                Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledConcat concat = new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledConcat();
                for (int i = 0; i < expressions.Length; i++) {
                    if (i > 0) {
                        concat.Add(new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledLiteral('~'));
                    }
                    concat.Add(expressions[i]);
                }
                sql = concat;
            } else {
                sql = expressions[0];
            }
            return sqlManager.GetSQL(sql, qlContext, declarations);
        }
    }
}
