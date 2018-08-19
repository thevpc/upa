package net.vpc.upa.impl.persistence.shared.sql;

import net.vpc.upa.impl.upql.ext.expr.CompiledConcat;
import net.vpc.upa.impl.upql.ext.expr.CompiledPlus;
import net.vpc.upa.impl.upql.ext.expr.CompiledVar;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.exceptions.UPAIllegalArgumentException;
import net.vpc.upa.impl.ext.expressions.CompiledExpressionExt;
import net.vpc.upa.impl.persistence.SQLManager;
import net.vpc.upa.impl.upql.ExpressionDeclarationList;
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
        CompiledExpressionExt left = o.getLeft();
        CompiledExpressionExt right = o.getRight();
        CompiledExpressionExt left0 = left;
        CompiledExpressionExt right0 = right;
        while(left0!=null && (left0 instanceof CompiledVar) && ((CompiledVar) left0).getChild()!=null){
            left0=((CompiledVar) left0).getChild();
        }
        while(right0!=null && (right0 instanceof CompiledVar) && ((CompiledVar) right0).getChild()!=null){
            right0=((CompiledVar) right0).getChild();
        }
        Class t1 = left0.getTypeTransform().getTargetType().getPlatformType();
        Class t2 = right0.getTypeTransform().getTargetType().getPlatformType();
        boolean s0 = PlatformUtils.isString(o.getTypeTransform().getTargetType().getPlatformType());
        boolean s1 = PlatformUtils.isString(t1);
        boolean s2 = PlatformUtils.isString(t2);
        if (s0 || s1 || s2) {
            return sqlManager.getSQL(new CompiledConcat(left.copy(), right.copy()), qlContext, declarations);
        }
        String leftValue = left != null ? sqlManager.getSQL(left, qlContext, declarations) : "NULL";
        String rightValue = right != null ? sqlManager.getSQL(right, qlContext, declarations) : "NULL";
        String s = null;
        s = leftValue + " + " + rightValue;
        return "(" + s + ")";
    }
}
