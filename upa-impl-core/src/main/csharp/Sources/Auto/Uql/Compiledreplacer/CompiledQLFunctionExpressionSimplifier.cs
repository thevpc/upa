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



namespace Net.TheVpc.Upa.Impl.Uql.Compiledreplacer
{


    /**
     *
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public class CompiledQLFunctionExpressionSimplifier : Net.TheVpc.Upa.Impl.Uql.CompiledExpressionReplacer {

        private Net.TheVpc.Upa.PersistenceUnit persistenceUnit;

        public CompiledQLFunctionExpressionSimplifier(Net.TheVpc.Upa.PersistenceUnit persistenceUnit) {
            this.persistenceUnit = persistenceUnit;
        }

        public virtual Net.TheVpc.Upa.Expressions.CompiledExpression Update(Net.TheVpc.Upa.Expressions.CompiledExpression e) {
            Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledQLFunctionExpression o = (Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledQLFunctionExpression) e;
            int argumentsCount = o.GetArgumentsCount();
            object[] args = new object[argumentsCount];
            for (int i = 0; i < args.Length; i++) {
                args[i] = Eval(o.GetArgument(i));
            }
            object v = o.GetHandler().Eval(new Net.TheVpc.Upa.EvalContext(o.GetName(), args, persistenceUnit));
            if (v != null) {
                if (v is Net.TheVpc.Upa.Expressions.CompiledExpression) {
                    return (Net.TheVpc.Upa.Expressions.CompiledExpression) v;
                }
                if (v is Net.TheVpc.Upa.Expressions.Expression) {
                    throw new System.ArgumentException ("Function should return literals of compiled expressions (CompiledExpression type)");
                }
                return new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledParam(v, null, o.GetTypeTransform(), false);
            } else {
                return new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledLiteral(null, null);
            }
        }

        protected internal virtual object Eval(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression o) {
            if (o == null) {
                return null;
            }
            if (o is Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledQLFunctionExpression) {
                Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledQLFunctionExpression s = (Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledQLFunctionExpression) o;
                int argumentsCount = s.GetArgumentsCount();
                object[] args = new object[argumentsCount];
                for (int i = 0; i < args.Length; i++) {
                    args[i] = Eval(s.GetArgument(i));
                }
                return (s.GetHandler().Eval(new Net.TheVpc.Upa.EvalContext(s.GetName(), args, persistenceUnit)));
            }
            if (o is Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledLiteral) {
                return ((Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledLiteral) o).GetValue();
            }
            if (o is Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledParam) {
                return ((Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledParam) o).GetValue();
            }
            return o;
        }
    }
}
