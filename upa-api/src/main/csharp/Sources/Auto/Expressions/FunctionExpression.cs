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
     * a function ust have a constructor with Expression[] args
     * Created with IntelliJ IDEA. User: vpc Date: 8/16/12 Time: 10:54 PM To change
     * this template use File | Settings | File Templates.
     */
    public abstract class FunctionExpression : Net.Vpc.Upa.Expressions.DefaultExpression {

        public abstract string GetName();

        public abstract int GetArgumentsCount();

        public abstract Net.Vpc.Upa.Expressions.Expression GetArgument(int index);

        public abstract void SetArgument(int index, Net.Vpc.Upa.Expressions.Expression e);

        public virtual Net.Vpc.Upa.Expressions.Expression[] GetArguments() {
            int max = GetArgumentsCount();
            Net.Vpc.Upa.Expressions.Expression[] p = new Net.Vpc.Upa.Expressions.Expression[max];
            for (int i = 0; i < max; i++) {
                p[i] = GetArgument(i);
            }
            return p;
        }


        public override System.Collections.Generic.IList<Net.Vpc.Upa.Expressions.TaggedExpression> GetChildren() {
            Net.Vpc.Upa.Expressions.Expression[] arr = GetArguments();
            System.Collections.Generic.IList<Net.Vpc.Upa.Expressions.TaggedExpression> all = new System.Collections.Generic.List<Net.Vpc.Upa.Expressions.TaggedExpression>(arr.Length);
            for (int i = 0; i < arr.Length; i++) {
                Net.Vpc.Upa.Expressions.Expression e = arr[i];
                if (e != null) {
                    all.Add(new Net.Vpc.Upa.Expressions.TaggedExpression(e, new Net.Vpc.Upa.Expressions.IndexedTag("arg", i)));
                }
            }
            return all;
        }


        public override void SetChild(Net.Vpc.Upa.Expressions.Expression e, Net.Vpc.Upa.Expressions.ExpressionTag tag) {
            int n = ((Net.Vpc.Upa.Expressions.IndexedTag) tag).GetIndex();
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

        protected internal static void CheckArgCount(string name, Net.Vpc.Upa.Expressions.Expression[] args, int count) {
            if (args.Length != count) {
                throw new Net.Vpc.Upa.Exceptions.UPAIllegalArgumentException("function " + name + " expects " + count + " argument(s) but found " + args.Length);
            }
        }
    }
}
