package net.vpc.upa.impl.upql.ext.expr;

import net.vpc.upa.types.TypesFactory;

import java.util.LinkedHashMap;
import java.util.List;
import net.vpc.upa.impl.transform.IdentityDataTypeTransform;
import net.vpc.upa.types.DataTypeTransform;

public abstract class DefaultCompiledEntityStatement extends DefaultCompiledExpressionImpl implements CompiledEntityStatement, Cloneable {

    private static final long serialVersionUID = 1L;

    public DefaultCompiledEntityStatement() {
    }

    @Override
    public DataTypeTransform getTypeTransform() {
        return IdentityDataTypeTransform.VOID;
    }

    protected abstract List<CompiledNamedExpression> findEntityDefinitions();

    public LinkedHashMap<String, CompiledNameOrSelect> findEntityDefinitions(LinkedHashMap<String, CompiledNameOrSelect> inherited) {
        LinkedHashMap<String, CompiledNameOrSelect> m = new LinkedHashMap<String, CompiledNameOrSelect>();
        if (inherited != null) {
            m.putAll(inherited);
        }
        List<CompiledNamedExpression> list = findEntityDefinitions();
        if (list != null) {
            for (CompiledNamedExpression objects : list) {
                CompiledNameOrSelect entity = (CompiledNameOrSelect) objects.getExpression();
                String entityAlias = objects.getName();
                if (entity != null) {
                    if (entityAlias == null) {
                        if (entity instanceof CompiledEntityName) {
                            entityAlias = ((CompiledEntityName) entity).getName();
                        }
                    }
                    if (entityAlias != null) {
                        m.put(entityAlias, entity);
                    }
                }
            }
        }
        return m;
    }

}
