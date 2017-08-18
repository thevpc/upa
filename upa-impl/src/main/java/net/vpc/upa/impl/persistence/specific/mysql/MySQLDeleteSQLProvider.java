package net.vpc.upa.impl.persistence.specific.mysql;

import net.vpc.upa.Entity;
import net.vpc.upa.PortabilityHint;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.impl.persistence.SQLManager;
import net.vpc.upa.impl.persistence.shared.sql.AbstractSQLProvider;
import net.vpc.upa.impl.uql.ExpressionDeclarationList;
import net.vpc.upa.impl.uql.compiledexpression.CompiledDelete;
import net.vpc.upa.impl.uql.compiledexpression.CompiledEntityName;
import net.vpc.upa.impl.uql.compiledexpression.CompiledVar;
import net.vpc.upa.persistence.EntityExecutionContext;

/**
 * Created with IntelliJ IDEA.
 * User: vpc
 * Date: 8/17/12
 * Time: 12:52 AM
 * To change this template use File | Settings | File Templates.
 */
@PortabilityHint(target = "C#", name = "suppress")
public class MySQLDeleteSQLProvider extends AbstractSQLProvider {
    public MySQLDeleteSQLProvider() {
        super(CompiledDelete.class);
    }


    @Override
    public String getSQL(Object oo, EntityExecutionContext context, SQLManager sqlManager, ExpressionDeclarationList declarations) throws UPAException {
        CompiledDelete o=(CompiledDelete) oo;
        StringBuilder sb = new StringBuilder("Delete");
        sb.append(" From ").append(sqlManager.getSQL(new CompiledEntityName(o.getEntity().getName()), context, declarations));
        if(o.getEntityAlias()!=null) {
            String aliasSQL = sqlManager.getSQL(new CompiledVar(o.getEntityAlias()), context, declarations);
            if (o.getEntityAlias() != null) {
                sb.append(" ").append(aliasSQL);
            }
        }
        if (o.getCondition()!=null && o.getCondition().isValid()) {
            sb.append(" Where ").append(sqlManager.getSQL(o.getCondition(), context, declarations));
        }
        return sb.toString();
    }


}
