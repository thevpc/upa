package net.vpc.upa.impl.uql.compiledexpression;

import java.util.List;

/**
 * Created with IntelliJ IDEA.
 * User: vpc
 * Date: 8/19/12
 * Time: 12:29 AM
 * To change this template use File | Settings | File Templates.
 */
public interface CompiledQueryStatement extends CompiledEntityStatement {
    int countFields();
    List<CompiledQueryField> getFields();
    CompiledQueryField getField(int i);
}
