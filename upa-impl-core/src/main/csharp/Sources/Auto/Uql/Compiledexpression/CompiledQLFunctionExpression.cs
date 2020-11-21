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



namespace Net.TheVpc.Upa.Impl.Uql.Compiledexpression
{


    /**
     * Created by IntelliJ IDEA.
     * User: root
     * Date: 22 mai 2003
     * Time: 12:07:34
     * To change this template use Options | File Templates.
     */
    public class CompiledQLFunctionExpression : Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledFunction {



        private Net.TheVpc.Upa.Function handler;

        public CompiledQLFunctionExpression(string name, Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression[] arguments, Net.TheVpc.Upa.Types.DataTypeTransform type, Net.TheVpc.Upa.Function handler)  : base(name){

            foreach (Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression a in arguments) {
                ProtectedAddArgument(a);
            }
            this.handler = handler;
            SetTypeTransform(type);
        }


        public override Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression Copy() {
            Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression[] arguments = GetArguments();
            for (int i = 0; i < arguments.Length; i++) {
                arguments[i] = arguments[i].Copy();
            }
            Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledQLFunctionExpression o = new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledQLFunctionExpression(GetName(), arguments, GetTypeTransform(), handler);
            o.SetDescription(GetDescription());
            o.GetClientParameters().SetAll(GetClientParameters());
            return o;
        }

        public virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression Expand(Net.TheVpc.Upa.PersistenceUnit persistenceUnit) {
            int argumentsCount = GetArgumentsCount();
            object[] args = new object[argumentsCount];
            for (int i = 0; i < args.Length; i++) {
                args[i] = Eval(GetArgument(i), persistenceUnit);
            }
            object v = GetHandler().Eval(new Net.TheVpc.Upa.EvalContext(GetName(), args, persistenceUnit));
            return new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledParam(v, null, GetTypeTransform(), false);
        }

        protected internal virtual object Eval(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression o, Net.TheVpc.Upa.PersistenceUnit persistenceUnit) {
            if (o == null) {
                return null;
            }
            if (o is Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledQLFunctionExpression) {
                Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledQLFunctionExpression s = (Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledQLFunctionExpression) o;
                int argumentsCount = s.GetArgumentsCount();
                object[] args = new object[argumentsCount];
                for (int i = 0; i < args.Length; i++) {
                    args[i] = Eval(s.GetArgument(i), persistenceUnit);
                }
                return (s.GetHandler().Eval(new Net.TheVpc.Upa.EvalContext(s.GetName(), args, persistenceUnit)));
            }
            if (o is Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledLiteral) {
                return ((Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledLiteral) o).GetValue();
            }
            if (o is Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledParam) {
                return ((Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledParam) o).GetValue();
            }
            throw new System.ArgumentException ("Unable to evaluate type " + o.GetType() + " :: " + o);
        }

        public virtual Net.TheVpc.Upa.Function GetHandler() {
            return handler;
        }
    }
}
