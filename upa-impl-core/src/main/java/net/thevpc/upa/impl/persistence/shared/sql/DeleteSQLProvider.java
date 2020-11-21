package net.thevpc.upa.impl.persistence.shared.sql;

import net.thevpc.upa.exceptions.UPAException;
import net.thevpc.upa.impl.persistence.SQLManager;
import net.thevpc.upa.impl.upql.ExpressionDeclarationList;
import net.thevpc.upa.impl.upql.ext.expr.CompiledDelete;
import net.thevpc.upa.impl.upql.ext.expr.CompiledEntityName;
import net.thevpc.upa.impl.upql.ext.expr.CompiledVar;
import net.thevpc.upa.persistence.EntityExecutionContext;

/**
 * Created with IntelliJ IDEA.
 * User: vpc
 * Date: 8/17/12
 * Time: 12:52 AM
 * To change this template use File | Settings | File Templates.
 */
public class DeleteSQLProvider extends AbstractSQLProvider {
    public DeleteSQLProvider() {
        super(CompiledDelete.class);
    }


    @Override
    public String getSQL(Object oo, EntityExecutionContext context, SQLManager sqlManager, ExpressionDeclarationList declarations) throws UPAException {
        CompiledDelete o=(CompiledDelete) oo;
//        Entity entity = context.getPersistenceUnit().getEntity(o.getEntity().getName());
        StringBuilder sb = new StringBuilder("Delete From " + sqlManager.getSQL(new CompiledEntityName(o.getEntity().getName()), context, declarations));
        if (o.getEntityAlias() != null) {
            sb.append(" ").append(sqlManager.getSQL(new CompiledVar(o.getEntityAlias()), context, declarations));
        }
        if (o.getCondition()!=null && o.getCondition().isValid()) {
            sb.append(" Where ").append(sqlManager.getSQL(o.getCondition(), context, declarations));
        }
        return sb.toString();
    }


}
