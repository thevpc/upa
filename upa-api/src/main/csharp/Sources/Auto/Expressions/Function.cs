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
     * Created with IntelliJ IDEA. User: vpc Date: 8/16/12 Time: 10:54 PM To change
     * this template use File | Settings | File Templates.
     */
    public abstract class Function : Net.Vpc.Upa.Expressions.DefaultExpression {

        public abstract string GetName();

        public abstract int GetArgumentsCount();

        public abstract Net.Vpc.Upa.Expressions.Expression GetArgument(int index);

        public virtual Net.Vpc.Upa.Expressions.Expression[] GetArguments() {
            int max = GetArgumentsCount();
            Net.Vpc.Upa.Expressions.Expression[] p = new Net.Vpc.Upa.Expressions.Expression[max];
            for (int i = 0; i < max; i++) {
                p[i] = GetArgument(i);
            }
            return p;
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
    }
}
