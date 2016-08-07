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


    public sealed class CompiledCoalesce : Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledFunction {



        public CompiledCoalesce()  : base("Coalesce"){

        }

        public CompiledCoalesce(System.Collections.Generic.IList<Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression> expressions)  : this(){

            foreach (Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression expression in expressions) {
                Add(expression);
            }
        }

        public CompiledCoalesce(params Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression [] expressions)  : this(){

            foreach (Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression expression in expressions) {
                Add(expression);
            }
        }

        public Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledCoalesce Add(object varName) {
            return Add(Net.Vpc.Upa.Impl.Uql.CompiledExpressionFactory.ToVar(varName));
        }

        public Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledCoalesce Add(Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression expression) {
            ProtectedAddArgument(expression);
            return this;
        }

        public override Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression Copy() {
            Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledCoalesce o = new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledCoalesce();
            ProtectedCopyTo(o);
            return o;
        }


        public override Net.Vpc.Upa.Types.DataTypeTransform GetTypeTransform() {
            foreach (Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression a in GetArguments()) {
                Net.Vpc.Upa.Types.DataTypeTransform t = a.GetEffectiveDataType();
                if (t != null && !t.GetTargetType().GetPlatformType().Equals(typeof(object))) {
                    return t;
                }
            }
            return base.GetTypeTransform();
        }
    }
}
