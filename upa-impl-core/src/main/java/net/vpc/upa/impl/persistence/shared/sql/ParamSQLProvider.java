package net.vpc.upa.impl.persistence.shared.sql;

import net.vpc.upa.impl.persistence.SQLManager;
import net.vpc.upa.impl.persistence.shared.sql.AbstractSQLProvider;
import net.vpc.upa.impl.uql.ExpressionDeclarationList;
import net.vpc.upa.impl.uql.compiledexpression.CompiledParam;
import net.vpc.upa.persistence.EntityExecutionContext;

/**
 * Created with IntelliJ IDEA.
 * User: vpc
 * Date: 8/17/12
 * Time: 12:52 AM
 * To change this template use File | Settings | File Templates.
 */
public class ParamSQLProvider extends AbstractSQLProvider {
    public ParamSQLProvider() {
        super(CompiledParam.class);
    }


    @Override
    public String getSQL(Object o, EntityExecutionContext qlContext, SQLManager sqlManager, ExpressionDeclarationList declarations) {
        return "?";
    }


}
