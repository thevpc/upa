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
     * a function ust have a constructor with Expression[] args
     * Created with IntelliJ IDEA. User: vpc Date: 8/16/12 Time: 10:54 PM To change
     * this template use File | Settings | File Templates.
     */
    public abstract class FunctionExpression : Net.TheVpc.Upa.Expressions.DefaultExpression {

        public abstract string GetName();

        public abstract int GetArgumentsCount();

        public abstract Net.TheVpc.Upa.Expressions.Expression GetArgument(int index);

        public abstract void SetArgument(int index, Net.TheVpc.Upa.Expressions.Expression e);

        public virtual Net.TheVpc.Upa.Expressions.Expression[] GetArguments() {
            int max = GetArgumentsCount();
            Net.TheVpc.Upa.Expressions.Expression[] p = new Net.TheVpc.Upa.Expressions.Expression[max];
            for (int i = 0; i < max; i++) {
                p[i] = GetArgument(i);
            }
            return p;
        }


        public override System.Collections.Generic.IList<Net.TheVpc.Upa.Expressions.TaggedExpression> GetChildren() {
            Net.TheVpc.Upa.Expressions.Expression[] arr = GetArguments();
            System.Collections.Generic.IList<Net.TheVpc.Upa.Expressions.TaggedExpression> all = new System.Collections.Generic.List<Net.TheVpc.Upa.Expressions.TaggedExpression>(arr.Length);
            for (int i = 0; i < arr.Length; i++) {
                Net.TheVpc.Upa.Expressions.Expression e = arr[i];
                if (e != null) {
                    all.Add(new Net.TheVpc.Upa.Expressions.TaggedExpression(e, new Net.TheVpc.Upa.Expressions.IndexedTag("arg", i)));
                }
            }
            return all;
        }


        public override void SetChild(Net.TheVpc.Upa.Expressions.Expression e, Net.TheVpc.Upa.Expressions.ExpressionTag tag) {
            int n = ((Net.TheVpc.Upa.Expressions.IndexedTag) tag).GetIndex();
            SetArgument(n, e);
        }


        public override string ToString() {
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

        protected internal static void CheckArgCount(string name, Net.TheVpc.Upa.Expressions.Expression[] args, int count) {
            if (args.Length != count) {
                throw new Net.TheVpc.Upa.Exceptions.UPAIllegalArgumentException("function " + name + " expects " + count + " argument(s) but found " + args.Length);
            }
        }
    }
}
