package net.thevpc.upa.impl.persistence.shared.sql;

import net.thevpc.upa.impl.upql.ext.expr.CompiledUnion;
import net.thevpc.upa.impl.upql.ext.expr.CompiledSelect;
import net.thevpc.upa.exceptions.UPAException;
import net.thevpc.upa.impl.persistence.SQLManager;
import net.thevpc.upa.impl.upql.ExpressionDeclarationList;
import net.thevpc.upa.persistence.EntityExecutionContext;

/**
 * Created with IntelliJ IDEA.
 * User: vpc
 * Date: 8/15/12
 * Time: 11:46 PM
 * To change this template use File | Settings | File Templates.
 */
public class UnionSQLProvider extends AbstractSQLProvider {
    public UnionSQLProvider() {
        super(CompiledUnion.class);
    }

    @Override
    public String getSQL(Object oo, EntityExecutionContext qlContext, SQLManager sqlManager, ExpressionDeclarationList declarations) throws UPAException{
        CompiledUnion o=(CompiledUnion) oo;
        StringBuilder sb=new StringBuilder();
        for (CompiledSelect queryStatement : o.getQueryStatements()) {
            if(sb.length()>0){
                sb.append(" union ");
            }
            sb.append(sqlManager.getSQL(queryStatement,qlContext, declarations));
        }
        return sb.toString();
//        return "("+sb.toString()+")";
    }
}
