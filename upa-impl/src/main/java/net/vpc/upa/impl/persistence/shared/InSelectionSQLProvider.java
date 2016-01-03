package net.vpc.upa.impl.persistence.shared;

import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.impl.persistence.SQLManager;
import net.vpc.upa.impl.uql.ExpressionDeclarationList;
import net.vpc.upa.impl.uql.compiledexpression.DefaultCompiledExpression;
import net.vpc.upa.impl.uql.compiledexpression.CompiledInSelection;
import net.vpc.upa.impl.uql.compiledexpression.CompiledSelect;
import net.vpc.upa.impl.uql.compiledexpression.CompiledUplet;
import net.vpc.upa.persistence.EntityExecutionContext;

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
        DefaultCompiledExpression[] left = o.getLeft();
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
