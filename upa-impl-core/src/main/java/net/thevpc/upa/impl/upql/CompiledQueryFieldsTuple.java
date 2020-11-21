package net.thevpc.upa.impl.upql;

import net.thevpc.upa.impl.upql.ext.expr.CompiledQueryField;
import net.thevpc.upa.impl.upql.ext.expr.DefaultCompiledExpressionImpl;
import net.thevpc.upa.exceptions.IllegalUPAArgumentException;
import net.thevpc.upa.impl.ext.expressions.CompiledExpressionExt;

import java.util.ArrayList;
import java.util.List;

/**
 * Created by vpc on 6/29/17.
 */
public class CompiledQueryFieldsTuple extends DefaultCompiledExpressionImpl {
    private List<CompiledQueryField> items=new ArrayList<CompiledQueryField>();

    public CompiledQueryFieldsTuple() {
    }

    public void add(CompiledQueryField item){
        items.add(item);
    }

    @Override
    public CompiledExpressionExt copy() {
        throw new IllegalUPAArgumentException("Unsupported. Should I?");
    }

    public CompiledQueryField[] getCompiledQueryFields() {
        return items.toArray(new CompiledQueryField[items.size()]);
    }

    @Override
    public CompiledExpressionExt[] getSubExpressions() {
        throw new IllegalUPAArgumentException("Unsupported. Should I?");
    }

    public List<CompiledQueryField> getItems() {
        return items;
    }

    @Override
    public void setSubExpression(int index, CompiledExpressionExt expression) {
        throw new IllegalUPAArgumentException("Unsupported. Should I?");
    }
}
