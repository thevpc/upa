package net.thevpc.upa.impl.persistence.shared.sql;

import net.thevpc.upa.exceptions.UPAException;
import net.thevpc.upa.impl.persistence.SQLManager;
import net.thevpc.upa.impl.upql.ExpressionDeclarationList;
import net.thevpc.upa.impl.ext.expressions.CompiledExpressionExt;
import net.thevpc.upa.impl.upql.ext.expr.CompiledInSelection;
import net.thevpc.upa.impl.upql.ext.expr.CompiledSelect;
import net.thevpc.upa.impl.upql.ext.expr.CompiledUplet;
import net.thevpc.upa.persistence.EntityExecutionContext;

/**
 * Created with IntelliJ IDEA.
 * User: vpc
 * Date: 8/15/12
 * Time: 11:46 PM
 * To change this template use File | Settings | File Templates.
 */
public class InSelectionSQLProvider extends AbstractSQLProvider {
    public InSelectionSQLProvider() {
        super(CompiledInSelection.class);
    }

    @Override
    public String getSQL(Object oo, EntityExecutionContext qlContext, SQLManager sqlManager, ExpressionDeclarationList declarations) throws UPAException{
        CompiledInSelection o=(CompiledInSelection) oo;
        CompiledExpressionExt[] left = o.getLeft();
        CompiledSelect query = o.getSelection();
        if (left.length == 1) {
            String q = sqlManager.getSQL(left[0],qlContext, declarations) + " in (" + sqlManager.getSQL(query,qlContext, declarations) + ")";
            return '(' + q + ')' ;
        }
        CompiledUplet uplet=new CompiledUplet(left);
        StringBuilder stringBuffer=new StringBuilder(sqlManager.getSQL(uplet,qlContext, declarations));
        stringBuffer.append(" In (");
        stringBuffer.append(sqlManager.getSQL(query,qlContext, declarations));
        stringBuffer.append(")");
        return '(' + stringBuffer.toString() + ')';
    }
}
