package net.vpc.upa.impl.persistence.shared.sql;

import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.impl.persistence.SQLManager;
import net.vpc.upa.impl.persistence.shared.sql.AbstractSQLProvider;
import net.vpc.upa.impl.uql.ExpressionDeclarationList;
import net.vpc.upa.impl.uql.compiledexpression.CompiledConcat;
import net.vpc.upa.impl.uql.compiledexpression.CompiledI2V;
import net.vpc.upa.impl.uql.compiledexpression.CompiledPlus;
import net.vpc.upa.impl.uql.compiledexpression.DefaultCompiledExpression;
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
        Class t1 = o.getLeft().getTypeTransform().getTargetType().getPlatformType();
        Class t2 = o.getRight().getTypeTransform().getTargetType().getPlatformType();
        boolean s0 = o.getTypeTransform().getTargetType().getPlatformType().equals(String.class);
        boolean s1 = t1.equals(String.class);
        boolean s2 = t2.equals(String.class);
        if (s0 || s1 || s2) {
            DefaultCompiledExpression c1 = o.getLeft().copy();
            DefaultCompiledExpression c2 = o.getRight().copy();
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
        String leftValue = o.getLeft() != null ? sqlManager.getSQL(o.getLeft(), qlContext, declarations) : "NULL";
        String rightValue = o.getRight() != null ? sqlManager.getSQL(o.getRight(), qlContext, declarations) : "NULL";
        String s = null;
        s = leftValue + " + " + rightValue;
        return "(" + s + ")";
    }
}
