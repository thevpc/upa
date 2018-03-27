package net.vpc.upa.impl.persistence.shared.sql;

import net.vpc.upa.impl.uql.parser.FunctionSQLProvider;

/**
 * Created by IntelliJ IDEA.
 * User: root
 * Date: 22 mai 2003
 * Time: 17:17:34
 * To change this template use Options | File Templates.
 */
public abstract class ANSIFunctionSQLProvider extends FunctionSQLProvider {
    protected ANSIFunctionSQLProvider(Class expressionType) {
        super(expressionType);
    }
}