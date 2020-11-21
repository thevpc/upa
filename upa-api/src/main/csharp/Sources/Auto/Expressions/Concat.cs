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


    public sealed class Concat : Net.TheVpc.Upa.Expressions.FunctionExpression {



        private System.Collections.Generic.List<Net.TheVpc.Upa.Expressions.Expression> elements;

        public Concat() {
            elements = new System.Collections.Generic.List<Net.TheVpc.Upa.Expressions.Expression>(1);
        }

        public Concat(Net.TheVpc.Upa.Expressions.Expression[] expressions) {
            elements = new System.Collections.Generic.List<Net.TheVpc.Upa.Expressions.Expression>(expressions.Length);
            foreach (Net.TheVpc.Upa.Expressions.Expression expression in expressions) {
                Add(expression);
            }
        }


        public override void SetArgument(int index, Net.TheVpc.Upa.Expressions.Expression e) {
            elements[index]=e;
        }

        public Net.TheVpc.Upa.Expressions.Concat Clear() {
            elements.Clear();
            return this;
        }

        public Net.TheVpc.Upa.Expressions.Concat AddAll(Net.TheVpc.Upa.Expressions.Concat other) {
            for (int i = 0; i < other.GetArgumentsCount(); i++) {
                Add((Net.TheVpc.Upa.Expressions.Expression) other.GetArgument(i));
            }
            return this;
        }

        public Net.TheVpc.Upa.Expressions.Concat Add(Net.TheVpc.Upa.Expressions.Expression expression) {
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

        public override Net.TheVpc.Upa.Expressions.Expression GetArgument(int i) {
            return (Net.TheVpc.Upa.Expressions.Expression) elements[i];
        }

        public override bool IsValid() {
            int max = GetArgumentsCount();
            bool valid = false;
            for (int i = 0; i < max; i++) {
                Net.TheVpc.Upa.Expressions.Expression e = GetArgument(i);
                if (e.IsValid()) {
                    valid = true;
                }
            }
            return valid;
        }


        public override string GetName() {
            return "Concat";
        }


        public override Net.TheVpc.Upa.Expressions.Expression Copy() {
            Net.TheVpc.Upa.Expressions.Concat o = new Net.TheVpc.Upa.Expressions.Concat();
            foreach (Net.TheVpc.Upa.Expressions.Expression element in elements) {
                o.Add((element).Copy());
            }
            return o;
        }
    }
}
