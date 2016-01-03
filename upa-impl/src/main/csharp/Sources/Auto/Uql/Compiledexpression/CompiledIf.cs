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
     * Time: 10:07:06
     * To change this template use Options | File Templates.
     */
    public class CompiledIf : Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledFunction {



        private readonly int EXPECT_CONDITION = 0;

        private readonly int EXPECT_VALUE = 1;

        private readonly int VALID = 2;

        private int state = 0;

        private CompiledIf()  : base("If"){

        }

        public CompiledIf(System.Collections.Generic.IList<Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression> expressions)  : this(){

            foreach (Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression defaultCompiledExpression in expressions) {
                ProtectedAddArgument(defaultCompiledExpression);
            }
            state = VALID;
        }

        public CompiledIf(Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression condition)  : this(){

            condition.GetTypeTransform().GetSourceType().Cast(Net.Vpc.Upa.Types.TypesFactory.BOOLEAN);
            Add(condition);
            state = EXPECT_VALUE;
        }

        public virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledIf Then(Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression @value) {
            if (state == EXPECT_VALUE) {
                Add(@value);
                state = EXPECT_CONDITION;
                return this;
            } else if (state == VALID) {
                throw new System.ArgumentException ("No more tokens are expected");
            } else {
                throw new System.ArgumentException ("Expected a value");
            }
        }

        public virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledIf Else(Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression @value) {
            if (state == EXPECT_CONDITION) {
                Add(@value);
                state = VALID;
                return this;
            } else if (state == VALID) {
                throw new System.ArgumentException ("No more tokens are expected");
            } else {
                throw new System.ArgumentException ("Expected a value");
            }
        }

        public virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledIf ElseIf(Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression condition) {
            if (state == EXPECT_CONDITION) {
                condition.GetTypeTransform().GetSourceType().Cast(Net.Vpc.Upa.Types.TypesFactory.BOOLEAN);
                Add(condition);
                state = EXPECT_VALUE;
                return this;
            } else if (state == VALID) {
                throw new System.ArgumentException ("No more tokens are expected");
            } else {
                throw new System.ArgumentException ("Expected a condition");
            }
        }

        private void Add(Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression expression) {
            ProtectedAddArgument(expression);
        }

        public override bool IsValid() {
            return state == VALID;
        }

        /**
             * 
             * @return type of first value expression
             */

        public override Net.Vpc.Upa.Types.DataTypeTransform GetTypeTransform() {
            return GetArgument(1).GetTypeTransform();
        }


        public override Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression Copy() {
            Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledIf o = new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledIf();
            o.state = state;
            foreach (Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression param in GetArguments()) {
                o.ProtectedAddArgument(param.Copy());
            }
            o.SetDescription(GetDescription());
            o.GetClientParameters().SetAll(GetClientParameters());
            return o;
        }


        public override string ToString() {
            System.Text.StringBuilder s = new System.Text.StringBuilder();
            int i = 0;
            foreach (Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression expression in GetArguments()) {
                if (i % 2 == 0) {
                    if (i == 0) {
                        s.Append("if (").Append(expression).Append(") then ");
                    } else if (i < GetArgumentsCount() - 1) {
                        s.Append(" elseif (").Append(expression).Append(") then ");
                    } else {
                        s.Append(" else (");
                        s.Append(expression);
                        s.Append(")");
                    }
                } else {
                    s.Append(" (").Append(expression).Append(")");
                }
                i++;
            }
            s.Append(" end");
            return s.ToString();
        }
    }
}
