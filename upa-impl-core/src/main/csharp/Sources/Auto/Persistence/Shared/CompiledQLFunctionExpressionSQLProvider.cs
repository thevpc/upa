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
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 12/14/12 12:28 AM
     */
    public class CompiledQLFunctionExpressionSQLProvider : Net.TheVpc.Upa.Impl.Persistence.SQLProvider {


        public virtual string GetSQL(object oo, Net.TheVpc.Upa.Persistence.EntityExecutionContext qlContext, Net.TheVpc.Upa.Impl.Persistence.SQLManager sqlManager, Net.TheVpc.Upa.Impl.Uql.ExpressionDeclarationList declarations) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledQLFunctionExpression o = (Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledQLFunctionExpression) oo;
            int argumentsCount = o.GetArgumentsCount();
            object[] args = new object[argumentsCount];
            for (int i = 0; i < args.Length; i++) {
                args[i] = Eval(o.GetArgument(i), qlContext);
            }
            return sqlManager.GetMarshallManager().FormatSqlValue(o.GetHandler().Eval(new Net.TheVpc.Upa.EvalContext(o.GetName(), args, qlContext.GetPersistenceUnit())));
        }

        protected internal virtual object Eval(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression o, Net.TheVpc.Upa.Persistence.EntityExecutionContext qlContext) {
            if (o == null) {
                return null;
            }
            if (o is Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledQLFunctionExpression) {
                Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledQLFunctionExpression s = (Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledQLFunctionExpression) o;
                int argumentsCount = s.GetArgumentsCount();
                object[] args = new object[argumentsCount];
                for (int i = 0; i < args.Length; i++) {
                    args[i] = Eval(s.GetArgument(i), qlContext);
                }
                return (s.GetHandler().Eval(new Net.TheVpc.Upa.EvalContext(s.GetName(), args, qlContext.GetPersistenceUnit())));
            }
            if (o is Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledLiteral) {
                return ((Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledLiteral) o).GetValue();
            }
            if (o is Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledParam) {
                return ((Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledParam) o).GetValue();
            }
            throw new System.ArgumentException ("Unable to evaluate type " + o.GetType() + " :: " + o);
        }


        public virtual System.Type GetExpressionType() {
            return typeof(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledQLFunctionExpression);
        }
    }
}
