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



namespace Net.Vpc.Upa.Expressions
{


    public sealed class Concat : Net.Vpc.Upa.Expressions.FunctionExpression {



        private System.Collections.Generic.List<Net.Vpc.Upa.Expressions.Expression> elements;

        public Concat() {
            elements = new System.Collections.Generic.List<Net.Vpc.Upa.Expressions.Expression>(1);
        }

        public Concat(Net.Vpc.Upa.Expressions.Expression[] expressions) {
            elements = new System.Collections.Generic.List<Net.Vpc.Upa.Expressions.Expression>(expressions.Length);
            foreach (Net.Vpc.Upa.Expressions.Expression expression in expressions) {
                Add(expression);
            }
        }


        public override void SetArgument(int index, Net.Vpc.Upa.Expressions.Expression e) {
            elements[index]=e;
        }

        public Net.Vpc.Upa.Expressions.Concat Clear() {
            elements.Clear();
            return this;
        }

        public Net.Vpc.Upa.Expressions.Concat AddAll(Net.Vpc.Upa.Expressions.Concat other) {
            for (int i = 0; i < other.GetArgumentsCount(); i++) {
                Add((Net.Vpc.Upa.Expressions.Expression) other.GetArgument(i));
            }
            return this;
        }

        public Net.Vpc.Upa.Expressions.Concat Add(Net.Vpc.Upa.Expressions.Expression expression) {
            if (expression == this) {
                throw new System.NullReferenceException();
            } else {
                elements.Add(expression);
                return this;
            }
        }

        public override int GetArgumentsCount() {
            return (elements).Count;
        }

        public override Net.Vpc.Upa.Expressions.Expression GetArgument(int i) {
            return (Net.Vpc.Upa.Expressions.Expression) elements[i];
        }

        public override bool IsValid() {
            int max = GetArgumentsCount();
            bool valid = false;
            for (int i = 0; i < max; i++) {
                Net.Vpc.Upa.Expressions.Expression e = GetArgument(i);
                if (e.IsValid()) {
                    valid = true;
                }
            }
            return valid;
        }


        public override string GetName() {
            return "Concat";
        }


        public override Net.Vpc.Upa.Expressions.Expression Copy() {
            Net.Vpc.Upa.Expressions.Concat o = new Net.Vpc.Upa.Expressions.Concat();
            foreach (Net.Vpc.Upa.Expressions.Expression element in elements) {
                o.Add((element).Copy());
            }
            return o;
        }
    }
}
