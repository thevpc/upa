package net.thevpc.upa.impl.persistence.shared.sql;

import net.thevpc.upa.UserPrincipal;
import net.thevpc.upa.impl.persistence.SQLManager;
import net.thevpc.upa.impl.upql.ExpressionDeclarationList;
import net.thevpc.upa.impl.upql.ext.expr.CompiledCurrentUser;
import net.thevpc.upa.persistence.EntityExecutionContext;

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
