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

    public class Var : Net.Vpc.Upa.Expressions.DefaultExpression {



        public const char DOT = '.';

        private Net.Vpc.Upa.Expressions.Var parent;

        private string name;

        public Var(string field)  : this(null, field){

        }

        public Var(Net.Vpc.Upa.Expressions.Var parent, string name) {
            this.parent = parent;
            this.name = name;
        }

        public virtual Net.Vpc.Upa.Expressions.Var GetParent() {
            return parent;
        }

        public virtual string GetName() {
            return name;
        }


        public override Net.Vpc.Upa.Expressions.Expression Copy() {
            Net.Vpc.Upa.Expressions.Var o = new Net.Vpc.Upa.Expressions.Var(parent, name);
            return o;
        }


        public override string ToString() {
            if (parent != null) {
                return parent.ToString() + "." + Net.Vpc.Upa.Expressions.ExpressionHelper.EscapeIdentifier(GetName());
            }
            return Net.Vpc.Upa.Expressions.ExpressionHelper.EscapeIdentifier(GetName());
        }
    }
}
