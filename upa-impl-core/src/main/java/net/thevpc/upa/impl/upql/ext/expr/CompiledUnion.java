package net.thevpc.upa.impl.upql.ext.expr;

import net.thevpc.upa.impl.transform.IdentityDataTypeTransform;
import net.thevpc.upa.impl.util.PlatformUtils;
import net.thevpc.upa.impl.ext.expressions.CompiledExpressionExt;

import java.util.ArrayList;
import java.util.List;

import net.thevpc.upa.types.DataTypeTransform;

/**
 * Created with IntelliJ IDEA. User: vpc Date: 8/19/12 Time: 12:34 AM To change
 * this template use File | Settings | File Templates.
 */
public class CompiledUnion extends DefaultCompiledEntityStatement implements CompiledQueryStatement {

    private final List<CompiledSelect> queryStatements = new ArrayList<CompiledSelect>();

    public CompiledUnion() {
    }

    public CompiledUnion(CompiledSelect[] all) {
        for (CompiledSelect select : all) {
            add(select);
        }
    }

    public void add(CompiledSelect s) {
        queryStatements.add(s);
        bindChildren(s);
    }

    public List<CompiledSelect> getQueryStatements() {
        return new ArrayList<CompiledSelect>(queryStatements);
    }

//    @Override
//    public String toSQL(boolean integrated, PersistenceUnitFilter database) {
//        throw new UPAIllegalArgumentException("Unsupported");
//    }
    @Override
    public String getEntityName() {
        return null;
    }

    @Override
    public String getEntityAlias() {
        return null;
    }

    @Override
    public DataTypeTransform getTypeTransform() {
        if (queryStatements.isEmpty()) {
            return IdentityDataTypeTransform.VOID;
        }
        return queryStatements.get(0).getTypeTransform();
    }

    @Override
    public int countFields() {
        return queryStatements.get(0).countFields();
    }

    public List<CompiledQueryField> getFields() {
        return queryStatements.get(0).getFields();
    }

    @Override
    public CompiledQueryField getField(int i) {
        return queryStatements.get(0).getField(i);
    }

    @Override
    public CompiledExpressionExt[] getSubExpressions() {
        return queryStatements.toArray(new CompiledExpressionExt[queryStatements.size()]);
    }

    @Override
    public boolean isValid() {
        if (queryStatements.isEmpty()) {
            return false;
        }
        for (CompiledQueryStatement queryStatement : queryStatements) {
            if (!queryStatement.isValid()) {
                return false;
            }
        }
        return true;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) {
            return true;
        }
        if (o == null || getClass() != o.getClass()) {
            return false;
        }

        CompiledUnion union = (CompiledUnion) o;

        if (queryStatements != null ? !queryStatements.equals(union.queryStatements) : union.queryStatements != null) {
            return false;
        }

        return true;
    }

    @Override
    public int hashCode() {
        return queryStatements != null ? queryStatements.hashCode() : 0;
    }

    @Override
    public CompiledExpressionExt copy() {
        CompiledUnion o = new CompiledUnion();
        o.setDescription(getDescription());
        o.getClientParameters().setAll(getClientParameters());
        for (CompiledQueryStatement queryStatement : queryStatements) {
            o.add((CompiledSelect) queryStatement.copy());
        }
        return o;
    }

    @Override
    public void setSubExpression(int index, CompiledExpressionExt expression) {
        unbindChildren(this.queryStatements.get(index));
        queryStatements.set(index, (CompiledSelect) expression);
        bindChildren(expression);
    }

    @Override
    protected List<CompiledNamedExpression> findEntityDefinitions() {
        return PlatformUtils.emptyList();
    }

}
