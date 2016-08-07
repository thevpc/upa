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
    public class UpletSQLProvider : Net.Vpc.Upa.Impl.Persistence.Shared.AbstractSQLProvider {

        public UpletSQLProvider()  : base(typeof(Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledUplet)){

        }


        public override string GetSQL(object oo, Net.Vpc.Upa.Persistence.EntityExecutionContext qlContext, Net.Vpc.Upa.Impl.Persistence.SQLManager sqlManager, Net.Vpc.Upa.Impl.Uql.ExpressionDeclarationList declarations) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledUplet o = (Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledUplet) oo;
            //        PersistenceUnitManager queryLanguageManager = qlContext.getPersistenceUnitManager();
            Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression sql;
            Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression[] expressions = o.GetExpressions();
            if (expressions.Length > 1) {
                Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledConcat concat = new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledConcat();
                for (int i = 0; i < expressions.Length; i++) {
                    if (i > 0) {
                        concat.Add(new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledLiteral('~'));
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
