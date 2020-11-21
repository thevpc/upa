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
     * Created by vpc on 7/2/16.
     */
    public class SimplifyVarsExpressionTransformer : Net.TheVpc.Upa.Expressions.ExpressionTransformer {

        private System.Collections.Generic.IDictionary<string , object> vars;

        private Net.TheVpc.Upa.PersistenceUnit pu;

        public SimplifyVarsExpressionTransformer(Net.TheVpc.Upa.PersistenceUnit pu, System.Collections.Generic.IDictionary<string , object> vars) {
            this.vars = vars;
            this.pu = pu;
        }

        public virtual Net.TheVpc.Upa.Expressions.ExpressionTransformerResult Transform(Net.TheVpc.Upa.Expressions.Expression expression) {
            if (expression is Net.TheVpc.Upa.Expressions.Var) {
                Net.TheVpc.Upa.Expressions.Expression e = EvalVar((Net.TheVpc.Upa.Expressions.Var) (expression).Copy());
                if (!e.Equals(expression)) {
                    return new Net.TheVpc.Upa.Expressions.ExpressionTransformerResult(e, true, true);
                }
            }
            return null;
        }

        protected internal virtual Net.TheVpc.Upa.Expressions.Expression EvalVar(Net.TheVpc.Upa.Expressions.Var expression) {
            if (expression.GetApplier() == null) {
                //this is the very root
                string name = expression.GetName();
                if (vars.ContainsKey(name)) {
                    return new Net.TheVpc.Upa.Expressions.Literal(Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,object>(vars,name), null);
                }
            } else {
                Net.TheVpc.Upa.Expressions.Expression x = expression.GetApplier();
                // no need for evalVar() in post order DFS
                if (x is Net.TheVpc.Upa.Expressions.Literal) {
                    object v = ((Net.TheVpc.Upa.Expressions.Literal) x).GetValue();
                    if (v == null) {
                        return Net.TheVpc.Upa.Expressions.Literal.NULL;
                    } else if (v is Net.TheVpc.Upa.Record) {
                        Net.TheVpc.Upa.Record r = (Net.TheVpc.Upa.Record) v;
                        return new Net.TheVpc.Upa.Expressions.Literal(r.GetObject<object>(expression.GetName()), null);
                    } else if (v is System.Collections.IDictionary) {
                        System.Collections.IDictionary r = (System.Collections.IDictionary) v;
                        return new Net.TheVpc.Upa.Expressions.Literal(Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue0(r,expression.GetName()), null);
                    } else {
                        Net.TheVpc.Upa.Entity entity = pu.GetEntity(v.GetType());
                        Net.TheVpc.Upa.Field field = entity.GetField(expression.GetName());
                        Net.TheVpc.Upa.Record r = entity.GetBuilder().ObjectToRecord(v);
                        return new Net.TheVpc.Upa.Expressions.Literal(r.GetObject<object>(field.GetName()), null);
                    }
                }
            }
            return expression;
        }
    }
}
