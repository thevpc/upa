package net.vpc.upa.impl.persistence.shared.sql;

import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.impl.persistence.SQLManager;
import net.vpc.upa.impl.persistence.shared.sql.AbstractSQLProvider;
import net.vpc.upa.impl.uql.ExpressionDeclarationList;
import net.vpc.upa.impl.uql.compiledexpression.*;
import net.vpc.upa.impl.util.PlatformUtils;
import net.vpc.upa.persistence.EntityExecutionContext;

/**
 * Created with IntelliJ IDEA. User: vpc Date: 8/15/12 Time: 11:46 PM To change
 * this template use File | Settings | File Templates.
 */
public class PlusExpressionSQLProvider extends AbstractSQLProvider {

    public PlusExpressionSQLProvider() {
        super(CompiledPlus.class);
    }

    @Override
    public String getSQL(Object oo, EntityExecutionContext qlContext, SQLManager sqlManager, ExpressionDeclarationList declarations) throws UPAException {
        CompiledPlus o = (CompiledPlus) oo;
        DefaultCompiledExpression left = o.getLeft();
        DefaultCompiledExpression right = o.getRight();
        DefaultCompiledExpression left0 = left;
        DefaultCompiledExpression right0 = right;
        while(left0!=null && (left0 instanceof CompiledVar) && ((CompiledVar) left0).getChild()!=null){
            left0=((CompiledVar) left0).getChild();
        }
        while(right0!=null && (right0 instanceof CompiledVar) && ((CompiledVar) right0).getChild()!=null){
            right0=((CompiledVar) right0).getChild();
        }
        Class t1 = left0.getTypeTransform().getTargetType().getPlatformType();
        Class t2 = right0.getTypeTransform().getTargetType().getPlatformType();
        boolean s0 = o.getTypeTransform().getTargetType().getPlatformType().equals(String.class);
        boolean s1 = t1.equals(String.class);
        boolean s2 = t2.equals(String.class);
        if (s0 || s1 || s2) {
            DefaultCompiledExpression c1 = left.copy();
            DefaultCompiledExpression c2 = right.copy();
            c1.setParentExpression(null);
            c2.setParentExpression(null);
            if (!s1) {
                if (PlatformUtils.isAnyInteger(t1)) {
                    c1 = new CompiledI2V(c1.copy());
                } else if (PlatformUtils.isAnyFloat(t1)) {
                    c1 = new CompiledI2V(c1.copy());
                } else {
                    throw new IllegalArgumentException("Unsupported");
                }
            }
            if (!s2) {
                if (PlatformUtils.isAnyInteger(t2)) {
                    c2 = new CompiledI2V(c2.copy());
                } else if (PlatformUtils.isAnyFloat(t2)) {
                    c2 = new CompiledI2V(c2.copy());
                } else {
                    throw new IllegalArgumentException("Unsupported");
                }
            }
            CompiledConcat cc = new CompiledConcat(c1, c2);
            return sqlManager.getSQL(cc, qlContext, declarations);
        }
        String leftValue = left != null ? sqlManager.getSQL(left, qlContext, declarations) : "NULL";
        String rightValue = right != null ? sqlManager.getSQL(right, qlContext, declarations) : "NULL";
        String s = null;
        s = leftValue + " + " + rightValue;
        return "(" + s + ")";
    }
}
