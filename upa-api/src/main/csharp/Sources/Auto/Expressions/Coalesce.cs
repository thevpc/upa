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


    public sealed class Coalesce : Net.TheVpc.Upa.Expressions.FunctionExpression {



        private System.Collections.Generic.List<Net.TheVpc.Upa.Expressions.Expression> elements;

        public Coalesce() {
            elements = new System.Collections.Generic.List<Net.TheVpc.Upa.Expressions.Expression>(1);
        }

        public Coalesce(Net.TheVpc.Upa.Expressions.Expression[] expressions)  : this(new System.Collections.Generic.List<Net.TheVpc.Upa.Expressions.Expression>(expressions)){

        }

        public Coalesce(System.Collections.Generic.IList<Net.TheVpc.Upa.Expressions.Expression> expressions) {
            elements = new System.Collections.Generic.List<Net.TheVpc.Upa.Expressions.Expression>((expressions).Count);
            foreach (Net.TheVpc.Upa.Expressions.Expression expression in expressions) {
                Add(expression);
            }
        }


        public override void SetArgument(int index, Net.TheVpc.Upa.Expressions.Expression e) {
            elements[index]=e;
        }

        public Coalesce(Net.TheVpc.Upa.Expressions.Expression expression1, Net.TheVpc.Upa.Expressions.Expression expression2)  : this(){

            Add(expression1);
            Add(expression2);
        }

        public Coalesce(Net.TheVpc.Upa.Expressions.Expression expression1, Net.TheVpc.Upa.Expressions.Expression expression2, Net.TheVpc.Upa.Expressions.Expression expression3)  : this(){

            Add(expression1);
            Add(expression2);
            Add(expression3);
        }

        public Net.TheVpc.Upa.Expressions.Coalesce Clear() {
            elements.Clear();
            return this;
        }

        public Net.TheVpc.Upa.Expressions.Coalesce Add(object varName) {
            return Add(Net.TheVpc.Upa.Expressions.ExpressionFactory.ToVar(varName));
        }

        public Net.TheVpc.Upa.Expressions.Coalesce Add(Net.TheVpc.Upa.Expressions.Expression expression) {
            elements.Add(expression);
            return this;
        }

        public int Size() {
            return (elements).Count;
        }

        public Net.TheVpc.Upa.Expressions.Expression Get(int i) {
            return elements[i];
        }

        public override bool IsValid() {
            int max = Size();
            bool valid = false;
            for (int i = 0; i < max; i++) {
                Net.TheVpc.Upa.Expressions.Expression e = Get(i);
                if (e.IsValid()) {
                    valid = true;
                }
            }
            return valid;
        }

        public override Net.TheVpc.Upa.Expressions.Expression Copy() {
            Net.TheVpc.Upa.Expressions.Coalesce o = new Net.TheVpc.Upa.Expressions.Coalesce();
            o.elements = new System.Collections.Generic.List<Net.TheVpc.Upa.Expressions.Expression>((elements).Count);
            foreach (Net.TheVpc.Upa.Expressions.Expression element in elements) {
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


        public override Net.TheVpc.Upa.Expressions.Expression GetArgument(int index) {
            return elements[index];
        }
    }
}
