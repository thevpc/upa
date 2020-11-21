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
    public class Decode : Net.TheVpc.Upa.Expressions.FunctionExpression {



        private System.Collections.Generic.List<Net.TheVpc.Upa.Expressions.Expression> @params;

        private readonly int EXPECT_CONDITION = 0;

        private readonly int VALID = 2;

        private int state = 0;

        private Decode() {
            @params = new System.Collections.Generic.List<Net.TheVpc.Upa.Expressions.Expression>(2);
        }

        public Decode(Net.TheVpc.Upa.Expressions.Expression[] expressions) {
            @params = new System.Collections.Generic.List<Net.TheVpc.Upa.Expressions.Expression>(new System.Collections.Generic.List<Net.TheVpc.Upa.Expressions.Expression>(expressions));
            state = VALID;
        }

        public Decode(System.Collections.Generic.IList<Net.TheVpc.Upa.Expressions.Expression> expressions) {
            @params = new System.Collections.Generic.List<Net.TheVpc.Upa.Expressions.Expression>(expressions);
            state = VALID;
        }

        public Decode(Net.TheVpc.Upa.Expressions.Expression expression) {
            @params = new System.Collections.Generic.List<Net.TheVpc.Upa.Expressions.Expression>(2);
            Add(expression);
            state = EXPECT_CONDITION;
        }


        public override void SetArgument(int index, Net.TheVpc.Upa.Expressions.Expression e) {
            @params[index]=e;
            state = VALID;
        }

        public virtual Net.TheVpc.Upa.Expressions.Decode Map(Net.TheVpc.Upa.Expressions.Expression oldValue, Net.TheVpc.Upa.Expressions.Expression newValue) {
            if (state != VALID) {
                Add(oldValue);
                Add(newValue);
                return this;
            } else {
                throw new Net.TheVpc.Upa.Exceptions.UPAIllegalArgumentException("No more tokens are expected");
            }
        }

        public virtual Net.TheVpc.Upa.Expressions.Decode Otherwise(Net.TheVpc.Upa.Expressions.Expression @value) {
            if (state != VALID) {
                Add(@value);
                state = VALID;
                return this;
            } else {
                throw new Net.TheVpc.Upa.Exceptions.UPAIllegalArgumentException("Expected a value");
            }
        }

        private void Add(Net.TheVpc.Upa.Expressions.Expression expression) {
            @params.Add(expression);
        }


        public override bool IsValid() {
            return state == VALID;
        }


        public override string GetName() {
            return "Decode";
        }


        public override int GetArgumentsCount() {
            return (@params).Count;
        }


        public override Net.TheVpc.Upa.Expressions.Expression GetArgument(int index) {
            return @params[index];
        }


        public override Net.TheVpc.Upa.Expressions.Expression Copy() {
            Net.TheVpc.Upa.Expressions.Decode o = new Net.TheVpc.Upa.Expressions.Decode();
            foreach (Net.TheVpc.Upa.Expressions.Expression param in @params) {
                o.@params.Add(param.Copy());
            }
            o.state = state;
            return o;
        }
    }
}
