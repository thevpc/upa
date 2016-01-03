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



namespace Net.Vpc.Upa.Impl.Uql.Compiledexpression
{


    /**
     * Created by IntelliJ IDEA.
     * User: root
     * Date: 22 mai 2003
     * Time: 12:07:34
     * To change this template use Options | File Templates.
     */
    public class CompiledQLFunctionExpression : Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledFunction {



        private Net.Vpc.Upa.Function handler;

        public CompiledQLFunctionExpression(string name, Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression[] arguments, Net.Vpc.Upa.Types.DataTypeTransform type, Net.Vpc.Upa.Function handler)  : base(name){

            foreach (Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression a in arguments) {
                ProtectedAddArgument(a);
            }
            this.handler = handler;
            SetDataType(type);
        }


        public override Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression Copy() {
            Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression[] arguments = GetArguments();
            for (int i = 0; i < arguments.Length; i++) {
                arguments[i] = arguments[i].Copy();
            }
            Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledQLFunctionExpression o = new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledQLFunctionExpression(GetName(), arguments, GetTypeTransform(), handler);
            o.SetDescription(GetDescription());
            o.GetClientParameters().SetAll(GetClientParameters());
            return o;
        }

        public virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression Expand(Net.Vpc.Upa.PersistenceUnit persistenceUnit) {
            int argumentsCount = GetArgumentsCount();
            object[] args = new object[argumentsCount];
            for (int i = 0; i < args.Length; i++) {
                args[i] = Eval(GetArgument(i), persistenceUnit);
            }
            object v = GetHandler().Eval(new Net.Vpc.Upa.EvalContext(GetName(), args, persistenceUnit));
            return new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledParam(v, null, GetTypeTransform(), false);
        }

        protected internal virtual object Eval(Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression o, Net.Vpc.Upa.PersistenceUnit persistenceUnit) {
            if (o == null) {
                return null;
            }
            if (o is Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledQLFunctionExpression) {
                Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledQLFunctionExpression s = (Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledQLFunctionExpression) o;
                int argumentsCount = s.GetArgumentsCount();
                object[] args = new object[argumentsCount];
                for (int i = 0; i < args.Length; i++) {
                    args[i] = Eval(s.GetArgument(i), persistenceUnit);
                }
                return (s.GetHandler().Eval(new Net.Vpc.Upa.EvalContext(s.GetName(), args, persistenceUnit)));
            }
            if (o is Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledLiteral) {
                return ((Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledLiteral) o).GetValue();
            }
            if (o is Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledParam) {
                return ((Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledParam) o).GetObject();
            }
            throw new System.ArgumentException ("Unable to evaluate type " + o.GetType() + " :: " + o);
        }

        public virtual Net.Vpc.Upa.Function GetHandler() {
            return handler;
        }
    }
}
