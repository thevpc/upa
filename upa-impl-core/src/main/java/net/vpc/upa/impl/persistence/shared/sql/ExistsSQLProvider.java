package net.vpc.upa.impl.persistence.shared.sql;

import net.vpc.upa.impl.upql.ext.expr.CompiledExists;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.impl.persistence.SQLManager;
import net.vpc.upa.impl.upql.ExpressionDeclarationList;
import net.vpc.upa.persistence.EntityExecutionContext;

/**
 * Created with IntelliJ IDEA.
 * User: vpc
 * Date: 8/15/12
 * Time: 11:46 PM
 * To change this template use File | Settings | File Templates.
 */
public class ExistsSQLProvider extends AbstractSQLProvider {
    public ExistsSQLProvider() {
        super(CompiledExists.class);
    }

    @Override
    public String getSQL(Object oo, EntityExecutionContext qlContext, SQLManager sqlManager, ExpressionDeclarationList declarations) throws UPAException{
        CompiledExists o=(CompiledExists) oo;
        StringBuilder stringBuffer=new StringBuilder("exists(");
        stringBuffer.append(sqlManager.getSQL(o.getQuery(),qlContext, declarations));
        stringBuffer.append(")");
        return stringBuffer.toString();
    }
}
