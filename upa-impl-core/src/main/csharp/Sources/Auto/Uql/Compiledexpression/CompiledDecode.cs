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
     * Created by IntelliJ IDEA. User: root Date: 22 mai 2003 Time: 10:07:06 To
     * change this template use Options | File Templates.
     */
    public class CompiledDecode : Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledFunction {



        private readonly int EXPECT_CONDITION = 0;

        private readonly int VALID = 2;

        private int state = 0;

        private CompiledDecode()  : base("Decode"){

        }

        public CompiledDecode(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression expression)  : base("Decode"){

            Add(expression);
            state = EXPECT_CONDITION;
            PrepareChildren(expression);
        }

        public virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledDecode Map(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression oldValue, Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression newValue) {
            if (state != VALID) {
                Add(oldValue);
                Add(newValue);
                return this;
            } else {
                throw new System.ArgumentException ("No more tokens are expected");
            }
        }

        public virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledDecode Otherwise(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression @value) {
            if (state != VALID) {
                Add(@value);
                state = VALID;
                return this;
            } else {
                throw new System.ArgumentException ("Expected a value");
            }
        }

        private void Add(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression expression) {
            ProtectedAddArgument(expression);
        }


        public override bool IsValid() {
            return state == VALID;
        }

        /**
             *
             * @return type of first value expression
             */

        public override Net.TheVpc.Upa.Types.DataTypeTransform GetTypeTransform() {
            return GetArgument(1).GetTypeTransform();
        }


        public override Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression Copy() {
            Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledDecode o = new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledDecode();
            foreach (Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression param in GetArguments()) {
                o.ProtectedAddArgument(param.Copy());
            }
            o.state = state;
            o.SetDescription(GetDescription());
            o.GetClientParameters().SetAll(GetClientParameters());
            return o;
        }
    }
}
