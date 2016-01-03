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
     * Created by IntelliJ IDEA.
     * User: root
     * Date: 22 mai 2003
     * Time: 10:07:06
     * To change this template use Options | File Templates.
     */
    public class Decode : Net.Vpc.Upa.Expressions.Function {



        private System.Collections.Generic.List<Net.Vpc.Upa.Expressions.Expression> @params;

        private readonly int EXPECT_CONDITION = 0;

        private readonly int VALID = 2;

        private int state = 0;

        private Decode() {
            @params = new System.Collections.Generic.List<Net.Vpc.Upa.Expressions.Expression>(2);
        }

        public Decode(System.Collections.Generic.IList<Net.Vpc.Upa.Expressions.Expression> expressions) {
            @params = new System.Collections.Generic.List<Net.Vpc.Upa.Expressions.Expression>(expressions);
            state = VALID;
        }

        public Decode(Net.Vpc.Upa.Expressions.Expression expression) {
            @params = new System.Collections.Generic.List<Net.Vpc.Upa.Expressions.Expression>(2);
            Add(expression);
            state = EXPECT_CONDITION;
        }

        public virtual Net.Vpc.Upa.Expressions.Decode Map(Net.Vpc.Upa.Expressions.Expression oldValue, Net.Vpc.Upa.Expressions.Expression newValue) {
            if (state != VALID) {
                Add(oldValue);
                Add(newValue);
                return this;
            } else {
                throw new System.ArgumentException ("No more tokens are expected");
            }
        }

        public virtual Net.Vpc.Upa.Expressions.Decode Otherwise(Net.Vpc.Upa.Expressions.Expression @value) {
            if (state != VALID) {
                Add(@value);
                state = VALID;
                return this;
            } else {
                throw new System.ArgumentException ("Expected a value");
            }
        }

        private void Add(Net.Vpc.Upa.Expressions.Expression expression) {
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


        public override Net.Vpc.Upa.Expressions.Expression GetArgument(int index) {
            return @params[index];
        }


        public override Net.Vpc.Upa.Expressions.Expression Copy() {
            Net.Vpc.Upa.Expressions.Decode o = new Net.Vpc.Upa.Expressions.Decode();
            foreach (Net.Vpc.Upa.Expressions.Expression param in @params) {
                o.@params.Add(param.Copy());
            }
            o.state = state;
            return o;
        }
    }
}
