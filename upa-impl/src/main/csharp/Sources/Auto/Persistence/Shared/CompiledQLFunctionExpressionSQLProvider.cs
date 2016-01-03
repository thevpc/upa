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
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 12/14/12 12:28 AM
     */
    public class CompiledQLFunctionExpressionSQLProvider : Net.Vpc.Upa.Impl.Persistence.SQLProvider {


        public virtual string GetSQL(object oo, Net.Vpc.Upa.Persistence.EntityExecutionContext qlContext, Net.Vpc.Upa.Impl.Persistence.SQLManager sqlManager, Net.Vpc.Upa.Impl.Uql.ExpressionDeclarationList declarations) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledQLFunctionExpression o = (Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledQLFunctionExpression) oo;
            int argumentsCount = o.GetArgumentsCount();
            object[] args = new object[argumentsCount];
            for (int i = 0; i < args.Length; i++) {
                args[i] = Eval(o.GetArgument(i), qlContext);
            }
            return sqlManager.GetMarshallManager().FormatSqlValue(o.GetHandler().Eval(new Net.Vpc.Upa.EvalContext(o.GetName(), args, qlContext.GetPersistenceUnit())));
        }

        protected internal virtual object Eval(Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression o, Net.Vpc.Upa.Persistence.EntityExecutionContext qlContext) {
            if (o == null) {
                return null;
            }
            if (o is Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledQLFunctionExpression) {
                Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledQLFunctionExpression s = (Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledQLFunctionExpression) o;
                int argumentsCount = s.GetArgumentsCount();
                object[] args = new object[argumentsCount];
                for (int i = 0; i < args.Length; i++) {
                    args[i] = Eval(s.GetArgument(i), qlContext);
                }
                return (s.GetHandler().Eval(new Net.Vpc.Upa.EvalContext(s.GetName(), args, qlContext.GetPersistenceUnit())));
            }
            if (o is Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledLiteral) {
                return ((Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledLiteral) o).GetValue();
            }
            if (o is Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledParam) {
                return ((Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledParam) o).GetObject();
            }
            throw new System.ArgumentException ("Unable to evaluate type " + o.GetType() + " :: " + o);
        }


        public virtual System.Type GetExpressionType() {
            return typeof(Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledQLFunctionExpression);
        }
    }
}
