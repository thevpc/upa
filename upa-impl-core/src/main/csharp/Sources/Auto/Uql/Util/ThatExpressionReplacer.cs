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



namespace Net.TheVpc.Upa.Impl.Uql.Util
{


    /**
     * Created by vpc on 7/3/16.
     */
    public class ThatExpressionReplacer : Net.TheVpc.Upa.Expressions.ExpressionVisitor {

        private readonly string alias2;

        public ThatExpressionReplacer(string alias2) {
            this.alias2 = alias2;
        }


        public virtual bool Visit(Net.TheVpc.Upa.Expressions.Expression expression, Net.TheVpc.Upa.Expressions.ExpressionTag tag) {
            if (expression is Net.TheVpc.Upa.Expressions.Var) {
                Net.TheVpc.Upa.Expressions.Expression v = expression;
                while (v is Net.TheVpc.Upa.Expressions.Var && ((Net.TheVpc.Upa.Expressions.Var) v).GetApplier() != null) {
                    v = ((Net.TheVpc.Upa.Expressions.Var) v).GetApplier();
                }
                if (v is Net.TheVpc.Upa.Expressions.Var && ((Net.TheVpc.Upa.Expressions.Var) v).GetName().Equals("that")) {
                    ((Net.TheVpc.Upa.Expressions.Var) v).SetName(alias2);
                }
            }
            return true;
        }
    }
}
