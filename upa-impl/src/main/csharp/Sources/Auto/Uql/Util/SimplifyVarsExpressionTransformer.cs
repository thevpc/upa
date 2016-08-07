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
     * Created by vpc on 7/2/16.
     */
    public class SimplifyVarsExpressionTransformer : Net.Vpc.Upa.Expressions.ExpressionTransformer {

        private System.Collections.Generic.IDictionary<string , object> vars;

        private Net.Vpc.Upa.PersistenceUnit pu;

        public SimplifyVarsExpressionTransformer(Net.Vpc.Upa.PersistenceUnit pu, System.Collections.Generic.IDictionary<string , object> vars) {
            this.vars = vars;
            this.pu = pu;
        }

        public virtual Net.Vpc.Upa.Expressions.ExpressionTransformerResult Transform(Net.Vpc.Upa.Expressions.Expression expression) {
            if (expression is Net.Vpc.Upa.Expressions.Var) {
                Net.Vpc.Upa.Expressions.Expression e = EvalVar((Net.Vpc.Upa.Expressions.Var) (expression).Copy());
                if (!e.Equals(expression)) {
                    return new Net.Vpc.Upa.Expressions.ExpressionTransformerResult(e, true, true);
                }
            }
            return null;
        }

        protected internal virtual Net.Vpc.Upa.Expressions.Expression EvalVar(Net.Vpc.Upa.Expressions.Var expression) {
            if (expression.GetApplier() == null) {
                //this is the very root
                string name = expression.GetName();
                if (vars.ContainsKey(name)) {
                    return new Net.Vpc.Upa.Expressions.Literal(Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,object>(vars,name), null);
                }
            } else {
                Net.Vpc.Upa.Expressions.Expression x = expression.GetApplier();
                // no need for evalVar() in post order DFS
                if (x is Net.Vpc.Upa.Expressions.Literal) {
                    object v = ((Net.Vpc.Upa.Expressions.Literal) x).GetValue();
                    if (v == null) {
                        return Net.Vpc.Upa.Expressions.Literal.NULL;
                    } else if (v is Net.Vpc.Upa.Record) {
                        Net.Vpc.Upa.Record r = (Net.Vpc.Upa.Record) v;
                        return new Net.Vpc.Upa.Expressions.Literal(r.GetObject<object>(expression.GetName()), null);
                    } else if (v is System.Collections.IDictionary) {
                        System.Collections.IDictionary r = (System.Collections.IDictionary) v;
                        return new Net.Vpc.Upa.Expressions.Literal(Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue0(r,expression.GetName()), null);
                    } else {
                        Net.Vpc.Upa.Entity entity = pu.GetEntity(v.GetType());
                        Net.Vpc.Upa.Field field = entity.GetField(expression.GetName());
                        Net.Vpc.Upa.Record r = entity.GetBuilder().ObjectToRecord(v);
                        return new Net.Vpc.Upa.Expressions.Literal(r.GetObject<object>(field.GetName()), null);
                    }
                }
            }
            return expression;
        }
    }
}
