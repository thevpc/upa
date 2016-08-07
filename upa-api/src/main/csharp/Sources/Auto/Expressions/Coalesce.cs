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


    public sealed class Coalesce : Net.Vpc.Upa.Expressions.FunctionExpression {



        private System.Collections.Generic.List<Net.Vpc.Upa.Expressions.Expression> elements;

        public Coalesce() {
            elements = new System.Collections.Generic.List<Net.Vpc.Upa.Expressions.Expression>(1);
        }

        public Coalesce(Net.Vpc.Upa.Expressions.Expression[] expressions)  : this(new System.Collections.Generic.List<Net.Vpc.Upa.Expressions.Expression>(expressions)){

        }

        public Coalesce(System.Collections.Generic.IList<Net.Vpc.Upa.Expressions.Expression> expressions) {
            elements = new System.Collections.Generic.List<Net.Vpc.Upa.Expressions.Expression>((expressions).Count);
            foreach (Net.Vpc.Upa.Expressions.Expression expression in expressions) {
                Add(expression);
            }
        }


        public override void SetArgument(int index, Net.Vpc.Upa.Expressions.Expression e) {
            elements[index]=e;
        }

        public Coalesce(Net.Vpc.Upa.Expressions.Expression expression1, Net.Vpc.Upa.Expressions.Expression expression2)  : this(){

            Add(expression1);
            Add(expression2);
        }

        public Coalesce(Net.Vpc.Upa.Expressions.Expression expression1, Net.Vpc.Upa.Expressions.Expression expression2, Net.Vpc.Upa.Expressions.Expression expression3)  : this(){

            Add(expression1);
            Add(expression2);
            Add(expression3);
        }

        public Net.Vpc.Upa.Expressions.Coalesce Clear() {
            elements.Clear();
            return this;
        }

        public Net.Vpc.Upa.Expressions.Coalesce Add(object varName) {
            return Add(Net.Vpc.Upa.Expressions.ExpressionFactory.ToVar(varName));
        }

        public Net.Vpc.Upa.Expressions.Coalesce Add(Net.Vpc.Upa.Expressions.Expression expression) {
            elements.Add(expression);
            return this;
        }

        public int Size() {
            return (elements).Count;
        }

        public Net.Vpc.Upa.Expressions.Expression Get(int i) {
            return elements[i];
        }

        public override bool IsValid() {
            int max = Size();
            bool valid = false;
            for (int i = 0; i < max; i++) {
                Net.Vpc.Upa.Expressions.Expression e = Get(i);
                if (e.IsValid()) {
                    valid = true;
                }
            }
            return valid;
        }

        public override Net.Vpc.Upa.Expressions.Expression Copy() {
            Net.Vpc.Upa.Expressions.Coalesce o = new Net.Vpc.Upa.Expressions.Coalesce();
            o.elements = new System.Collections.Generic.List<Net.Vpc.Upa.Expressions.Expression>();
            foreach (Net.Vpc.Upa.Expressions.Expression element in elements) {
                o.Add(element.Copy());
            }
            return o;
        }


        public override string GetName() {
            return "Coalesce";
        }


        public override int GetArgumentsCount() {
            return (elements).Count;
        }


        public override Net.Vpc.Upa.Expressions.Expression GetArgument(int index) {
            return elements[index];
        }
    }
}
