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



namespace Net.Vpc.Upa.Expressions
{


    /**
     * Created by IntelliJ IDEA. User: root Date: 22 mai 2003 Time: 10:07:06 To
     * change this template use Options | File Templates.
     */
    public class If : Net.Vpc.Upa.Expressions.FunctionExpression {



        private readonly int EXPECT_CONDITION = 0;

        private readonly int EXPECT_VALUE = 1;

        private readonly int VALID = 2;

        private System.Collections.Generic.List<Net.Vpc.Upa.Expressions.Expression> @params;

        private int state = 0;

        private If() {
            @params = new System.Collections.Generic.List<Net.Vpc.Upa.Expressions.Expression>();
        }

        public If(System.Collections.Generic.IList<Net.Vpc.Upa.Expressions.Expression> expressions) {
            @params = new System.Collections.Generic.List<Net.Vpc.Upa.Expressions.Expression>((expressions).Count);
            Net.Vpc.Upa.FwkConvertUtils.CollectionAddRange(@params, expressions);
            state = VALID;
        }

        public If(Net.Vpc.Upa.Expressions.Expression[] expressions) {
            @params = new System.Collections.Generic.List<Net.Vpc.Upa.Expressions.Expression>(expressions.Length);
            Net.Vpc.Upa.FwkConvertUtils.CollectionAddRange(@params, new System.Collections.Generic.List<Net.Vpc.Upa.Expressions.Expression>(expressions));
            state = VALID;
        }

        public If(Net.Vpc.Upa.Expressions.Expression condition) {
            @params = new System.Collections.Generic.List<Net.Vpc.Upa.Expressions.Expression>(2);
            Add(condition);
            state = EXPECT_VALUE;
        }


        public override void SetArgument(int index, Net.Vpc.Upa.Expressions.Expression e) {
            @params[index]=e;
            state = VALID;
        }

        public virtual Net.Vpc.Upa.Expressions.If Then(Net.Vpc.Upa.Expressions.Expression @value) {
            if (state == EXPECT_VALUE) {
                Add(@value);
                state = EXPECT_CONDITION;
                return this;
            } else if (state == VALID) {
                throw new Net.Vpc.Upa.Exceptions.IllegalArgumentException("No more tokens are expected");
            } else {
                throw new Net.Vpc.Upa.Exceptions.IllegalArgumentException("Expected a value");
            }
        }

        public virtual Net.Vpc.Upa.Expressions.If Else(Net.Vpc.Upa.Expressions.Expression @value) {
            if (state == EXPECT_CONDITION) {
                Add(@value);
                state = VALID;
                return this;
            } else if (state == VALID) {
                throw new Net.Vpc.Upa.Exceptions.IllegalArgumentException("No more tokens are expected");
            } else {
                throw new Net.Vpc.Upa.Exceptions.IllegalArgumentException("Expected a value");
            }
        }

        public virtual Net.Vpc.Upa.Expressions.If ElseIf(Net.Vpc.Upa.Expressions.Expression condition) {
            if (state == EXPECT_CONDITION) {
                Add(condition);
                state = EXPECT_VALUE;
                return this;
            } else if (state == VALID) {
                throw new Net.Vpc.Upa.Exceptions.IllegalArgumentException("No more tokens are expected");
            } else {
                throw new Net.Vpc.Upa.Exceptions.IllegalArgumentException("Expected a condition");
            }
        }

        private void Add(Net.Vpc.Upa.Expressions.Expression expression) {
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


        public override Net.Vpc.Upa.Expressions.Expression GetArgument(int index) {
            return @params[index];
        }


        public override Net.Vpc.Upa.Expressions.Expression Copy() {
            Net.Vpc.Upa.Expressions.If o = new Net.Vpc.Upa.Expressions.If();
            o.state = state;
            foreach (Net.Vpc.Upa.Expressions.Expression param in @params) {
                o.@params.Add(param.Copy());
            }
            return o;
        }


        public override string ToString() {
            System.Text.StringBuilder s = new System.Text.StringBuilder();
            int i = 0;
            foreach (Net.Vpc.Upa.Expressions.Expression expression in @params) {
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
