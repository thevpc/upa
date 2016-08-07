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
     * Result of transformation
     * Holds information about the transformed expression or the initial expression if not modified
     * reports about whether or not the expression has ben updated (content change) or replaced (reference change)
     * Created by vpc on 7/2/16.
     */
    public class ExpressionTransformerResult {

        private Net.Vpc.Upa.Expressions.Expression expression;

        private bool replaced;

        private bool updated;

        public ExpressionTransformerResult(Net.Vpc.Upa.Expressions.Expression expression, bool replaced, bool updated) {
            this.expression = expression;
            this.replaced = replaced;
            this.updated = updated;
        }

        public virtual Net.Vpc.Upa.Expressions.Expression GetExpression() {
            return expression;
        }

        public virtual bool IsChanged() {
            return replaced || updated;
        }

        public virtual bool IsReplaced() {
            return replaced;
        }

        public virtual bool IsUpdated() {
            return updated;
        }
    }
}
