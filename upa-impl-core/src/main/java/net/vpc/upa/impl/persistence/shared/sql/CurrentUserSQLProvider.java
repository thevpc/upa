package net.vpc.upa.impl.persistence.shared.sql;

import net.vpc.upa.UserPrincipal;
import net.vpc.upa.impl.persistence.SQLManager;
import net.vpc.upa.impl.persistence.shared.sql.AbstractSQLProvider;
import net.vpc.upa.impl.upql.ExpressionDeclarationList;
import net.vpc.upa.impl.upql.ext.expr.CompiledCurrentUser;
import net.vpc.upa.persistence.EntityExecutionContext;

/**
 * Created with IntelliJ IDEA.
 * User: vpc
 * Date: 8/15/12
 * Time: 11:46 PM
 * To change this template use File | Settings | File Templates.
 */
public class CurrentUserSQLProvider extends AbstractSQLProvider {
    public CurrentUserSQLProvider() {
        super(CompiledCurrentUser.class);
    }

    @Override
    public String getSQL(Object o, EntityExecutionContext qlContext, SQLManager sqlManager, ExpressionDeclarationList declarations) {
        UserPrincipal user = qlContext.getPersistenceUnit().getUserPrincipal();
        return sqlManager.getMarshallManager().formatSqlValue(user==null?"anonymous":user.getName());
    }
}
