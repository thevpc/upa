/*********************************************************
 *********************************************************
 **   DO NOT EDIT                                       **
 **                                                     **
 **   THIS FILE HAS BEEN GENERATED AUTOMATICALLY         **
 **   BY UPA PORTABLE GENERATOR                         **
 **   (c) vpc                                           **
 **                                                     **
 *********************************************************
 ********************************************************/



namespace Net.TheVpc.Upa.Expressions
{


    /**
     * Created by IntelliJ IDEA. User: root Date: 22 mai 2003 Time: 10:07:06 To
     * change this template use Options | File Templates.
     */
    public class If : Net.TheVpc.Upa.Expressions.FunctionExpression {



        private readonly int EXPECT_CONDITION = 0;

        private readonly int EXPECT_VALUE = 1;

        private readonly int VALID = 2;

        private System.Collections.Generic.List<Net.TheVpc.Upa.Expressions.Expression> @params;

        private int state = 0;

        private If() {
            @params = new System.Collections.Generic.List<Net.TheVpc.Upa.Expressions.Expression>(3);
        }

        public If(System.Collections.Generic.IList<Net.TheVpc.Upa.Expressions.Expression> expressions) {
            @params = new System.Collections.Generic.List<Net.TheVpc.Upa.Expressions.Expression>((expressions).Count);
            Net.TheVpc.Upa.FwkConvertUtils.CollectionAddRange(@params, expressions);
            state = VALID;
        }

        public If(Net.TheVpc.Upa.Expressions.Expression[] expressions) {
            @params = new System.Collections.Generic.List<Net.TheVpc.Upa.Expressions.Expression>(expressions.Length);
            Net.TheVpc.Upa.FwkConvertUtils.CollectionAddRange(@params, new System.Collections.Generic.List<Net.TheVpc.Upa.Expressions.Expression>(expressions));
            state = VALID;
        }

        public If(Net.TheVpc.Upa.Expressions.Expression condition) {
            @params = new System.Collections.Generic.List<Net.TheVpc.Upa.Expressions.Expression>(2);
            Add(condition);
            state = EXPECT_VALUE;
        }


        public override void SetArgument(int index, Net.TheVpc.Upa.Expressions.Expression e) {
            @params[index]=e;
            state = VALID;
        }

        public virtual Net.TheVpc.Upa.Expressions.If Then(Net.TheVpc.Upa.Expressions.Expression @value) {
            if (state == EXPECT_VALUE) {
                Add(@value);
                state = EXPECT_CONDITION;
                return this;
            } else if (state == VALID) {
                throw new Net.TheVpc.Upa.Exceptions.UPAIllegalArgumentException("No more tokens are expected");
            } else {
                throw new Net.TheVpc.Upa.Exceptions.UPAIllegalArgumentException("Expected a value");
            }
        }

        public virtual Net.TheVpc.Upa.Expressions.If Else(Net.TheVpc.Upa.Expressions.Expression @value) {
            if (state == EXPECT_CONDITION) {
                Add(@value);
                state = VALID;
                return this;
            } else if (state == VALID) {
                throw new Net.TheVpc.Upa.Exceptions.UPAIllegalArgumentException("No more tokens are expected");
            } else {
                throw new Net.TheVpc.Upa.Exceptions.UPAIllegalArgumentException("Expected a value");
            }
        }

        public virtual Net.TheVpc.Upa.Expressions.If ElseIf(Net.TheVpc.Upa.Expressions.Expression condition) {
            if (state == EXPECT_CONDITION) {
                Add(condition);
                state = EXPECT_VALUE;
                return this;
            } else if (state == VALID) {
                throw new Net.TheVpc.Upa.Exceptions.UPAIllegalArgumentException("No more tokens are expected");
            } else {
                throw new Net.TheVpc.Upa.Exceptions.UPAIllegalArgumentException("Expected a condition");
            }
        }

        private void Add(Net.TheVpc.Upa.Expressions.Expression expression) {
            @params.Add(expression);
        }

        public override bool IsValid() {
            return state == VALID;
        }


        public override string GetName() {
            return "If";
        }


        public override int GetArgumentsCount() {
            return (@params).Count;
        }


        public override Net.TheVpc.Upa.Expressions.Expression GetArgument(int index) {
            return @params[index];
        }


        public override Net.TheVpc.Upa.Expressions.Expression Copy() {
            Net.TheVpc.Upa.Expressions.If o = new Net.TheVpc.Upa.Expressions.If();
            o.state = state;
            foreach (Net.TheVpc.Upa.Expressions.Expression param in @params) {
                o.@params.Add(param.Copy());
            }
            return o;
        }


        public override string ToString() {
            System.Text.StringBuilder s = new System.Text.StringBuilder();
            int i = 0;
            foreach (Net.TheVpc.Upa.Expressions.Expression expression in @params) {
                if (i % 2 == 0) {
                    if (i == 0) {
                        s.Append("if (").Append(expression).Append(") then ");
                    } else if (i < (@params).Count - 1) {
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
