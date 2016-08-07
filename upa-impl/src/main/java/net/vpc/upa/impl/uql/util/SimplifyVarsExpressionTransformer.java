package net.vpc.upa.impl.uql.util;

import net.vpc.upa.Entity;
import net.vpc.upa.Field;
import net.vpc.upa.PersistenceUnit;
import net.vpc.upa.Record;
import net.vpc.upa.expressions.*;

import java.util.Map;

/**
 * Created by vpc on 7/2/16.
 */
public class SimplifyVarsExpressionTransformer implements ExpressionTransformer {
    private Map<String, Object> vars;
    private PersistenceUnit pu;

    public SimplifyVarsExpressionTransformer(PersistenceUnit pu, Map<String, Object> vars) {
        this.vars = vars;
        this.pu = pu;
    }

    public ExpressionTransformerResult transform(Expression expression) {
        if (expression instanceof Var) {
            Expression e = evalVar((Var) (expression).copy());
            if (!e.equals(expression)) {
                return new ExpressionTransformerResult(
                        e, true, true
                );
            }
        }
        return null;
    }

    protected Expression evalVar(Var expression) {
        if (expression.getApplier() == null) {
            //this is the very root
            String name = expression.getName();
            if (vars.containsKey(name)) {
                return new Literal(vars.get(name), null);
            }
        } else {
            Expression x = expression.getApplier();// no need for evalVar() in post order DFS
            if (x instanceof Literal) {
                Object v = ((Literal) x).getValue();
                if(v ==null) {
                    return Literal.NULL;
                }else if(v instanceof Record) {
                    Record r = (Record) v;
                    return new Literal(r.<Object>getObject(expression.getName()), null);
                }else if(v instanceof Map){
                    Map r=(Map) v;
                    return new Literal(r.get(expression.getName()), null);
                }else {
                    Entity entity = pu.getEntity(v.getClass());
                    Field field = entity.getField(expression.getName());
                    Record r =entity.getBuilder().objectToRecord(v);
                    return new Literal(r.<Object>getObject(field.getName()), null);
                }
            }
        }
        return expression;
    }
}
