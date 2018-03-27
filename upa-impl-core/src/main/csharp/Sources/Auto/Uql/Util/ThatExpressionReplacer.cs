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



namespace Net.Vpc.Upa.Impl.Uql.Util
{


    /**
     * Created by vpc on 7/3/16.
     */
    public class ThatExpressionReplacer : Net.Vpc.Upa.Expressions.ExpressionVisitor {

        private readonly string alias2;

        public ThatExpressionReplacer(string alias2) {
            this.alias2 = alias2;
        }


        public virtual bool Visit(Net.Vpc.Upa.Expressions.Expression expression, Net.Vpc.Upa.Expressions.ExpressionTag tag) {
            if (expression is Net.Vpc.Upa.Expressions.Var) {
                Net.Vpc.Upa.Expressions.Expression v = expression;
                while (v is Net.Vpc.Upa.Expressions.Var && ((Net.Vpc.Upa.Expressions.Var) v).GetApplier() != null) {
                    v = ((Net.Vpc.Upa.Expressions.Var) v).GetApplier();
                }
                if (v is Net.Vpc.Upa.Expressions.Var && ((Net.Vpc.Upa.Expressions.Var) v).GetName().Equals("that")) {
                    ((Net.Vpc.Upa.Expressions.Var) v).SetName(alias2);
                }
            }
            return true;
        }
    }
}
