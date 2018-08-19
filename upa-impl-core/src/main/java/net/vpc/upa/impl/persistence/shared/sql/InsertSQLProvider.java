package net.vpc.upa.impl.persistence.shared.sql;

import net.vpc.upa.Entity;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.impl.persistence.SQLManager;
import net.vpc.upa.impl.persistence.shared.sql.AbstractSQLProvider;
import net.vpc.upa.impl.upql.ExpressionDeclarationList;
import net.vpc.upa.impl.upql.ext.expr.CompiledInsert;
import net.vpc.upa.persistence.EntityExecutionContext;

/**
 * Created with IntelliJ IDEA.
 * User: vpc
 * Date: 8/17/12
 * Time: 12:52 AM
 * To change this template use File | Settings | File Templates.
 */
public class InsertSQLProvider extends AbstractSQLProvider {
    public InsertSQLProvider() {
        super(CompiledInsert.class);
    }


    @Override
    public String getSQL(Object oo, EntityExecutionContext context, SQLManager sqlManager, ExpressionDeclarationList declarations) throws UPAException{
        CompiledInsert o=(CompiledInsert) oo;
//        PersistenceUnitManager persistenceManager = context.getPersistenceStore();
        Entity entity = context.getPersistenceUnit().getEntity(o.getEntity().getName());
        String n = context.getPersistenceStore().getValidIdentifier(context.getPersistenceStore().getPersistenceName(entity));
        StringBuilder sb = new StringBuilder("Insert Into " + n);
        sb.append("(");
        StringBuilder sbVals = new StringBuilder();
        boolean isFirst = true;
        int max = o.countFields();
        for (int i = 0; i < max; i++) {
            if (isFirst) {
                isFirst = false;
            } else {
                sb.append(", ");
                sbVals.append(", ");
            }
            sb.append(sqlManager.getSQL(o.getField(i), context, declarations));
            sbVals.append(sqlManager.getSQL(o.getFieldValue(i), context, declarations));
        }

        return sb.append(") Values (").append(sbVals).append(")").toString();
    }


}
