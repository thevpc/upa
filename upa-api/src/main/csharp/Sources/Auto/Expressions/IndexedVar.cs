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

    /**
     * Created with IntelliJ IDEA. User: vpc Date: 8/16/12 Time: 10:54 PM To change
     * this template use File | Settings | File Templates.
     */
    public class IndexedVar : Net.Vpc.Upa.Expressions.Var {

        private Net.Vpc.Upa.Expressions.Expression[] arguments;

        public IndexedVar(string field, params Net.Vpc.Upa.Expressions.Expression [] arguments)  : this(null, field, arguments){

        }

        public IndexedVar(Net.Vpc.Upa.Expressions.Expression parent, string name, params Net.Vpc.Upa.Expressions.Expression [] arguments)  : base(parent, name){

            this.arguments = arguments;
        }


        public override Net.Vpc.Upa.Expressions.Expression Copy() {
            Net.Vpc.Upa.Expressions.IndexedVar o = new Net.Vpc.Upa.Expressions.IndexedVar(GetApplier(), GetName(), GetArguments());
            return o;
        }

        public virtual int GetArgumentsCount() {
            return arguments.Length;
        }

        public virtual Net.Vpc.Upa.Expressions.Expression GetArgument(int index) {
            return arguments[index];
        }

        public virtual Net.Vpc.Upa.Expressions.Expression[] GetArguments() {
            int max = GetArgumentsCount();
            Net.Vpc.Upa.Expressions.Expression[] p = new Net.Vpc.Upa.Expressions.Expression[max];
            for (int i = 0; i < max; i++) {
                p[i] = GetArgument(i);
            }
            return p;
        }


        public override string ToString() {
            if (GetApplier() != null) {
                return GetApplier().ToString() + "." + GetName();
            }
            System.Text.StringBuilder s = new System.Text.StringBuilder(GetName()).Append("(");
            for (int i = 0; i < GetArgumentsCount(); i++) {
                if (i > 0) {
                    s.Append(",");
                }
                s.Append(GetArgument(i));
            }
            s.Append(")");
            return s.ToString();
        }
    }
}
