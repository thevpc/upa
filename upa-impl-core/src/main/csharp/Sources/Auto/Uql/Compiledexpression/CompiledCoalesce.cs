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


    public sealed class CompiledCoalesce : Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledFunction {



        public CompiledCoalesce()  : base("Coalesce"){

        }

        public CompiledCoalesce(System.Collections.Generic.IList<Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression> expressions)  : this(){

            foreach (Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression expression in expressions) {
                Add(expression);
            }
        }

        public CompiledCoalesce(params Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression [] expressions)  : this(){

            foreach (Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression expression in expressions) {
                Add(expression);
            }
        }

        public Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledCoalesce Add(object varName) {
            return Add(Net.TheVpc.Upa.Impl.Uql.CompiledExpressionFactory.ToVar(varName));
        }

        public Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledCoalesce Add(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression expression) {
            ProtectedAddArgument(expression);
            return this;
        }

        public override Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression Copy() {
            Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledCoalesce o = new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledCoalesce();
            ProtectedCopyTo(o);
            return o;
        }


        public override Net.TheVpc.Upa.Types.DataTypeTransform GetTypeTransform() {
            foreach (Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression a in GetArguments()) {
                Net.TheVpc.Upa.Types.DataTypeTransform t = a.GetEffectiveDataType();
                if (t != null && !t.GetTargetType().GetPlatformType().Equals(typeof(object))) {
                    return t;
                }
            }
            return base.GetTypeTransform();
        }
    }
}
