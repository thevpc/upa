package net.thevpc.upa.impl.ext.persistence;

import java.util.Map;

import net.thevpc.upa.PersistenceUnit;
import net.thevpc.upa.Properties;
import net.thevpc.upa.impl.persistence.QueryExecutor;
import net.thevpc.upa.impl.persistence.SqlTypeName;
import net.thevpc.upa.persistence.PersistenceStore;
import net.thevpc.upa.Entity;
import net.thevpc.upa.exceptions.UPAException;
import net.thevpc.upa.expressions.Expression;
import net.thevpc.upa.filters.FieldFilter;
import net.thevpc.upa.persistence.ConnectionProfile;
import net.thevpc.upa.persistence.EntityExecutionContext;
import net.thevpc.upa.types.DataType;

/**
 * Created by vpc on 7/6/17.
 */
public interface PersistenceStoreExt extends PersistenceStore {

    void init(PersistenceUnit persistenceUnit, boolean readOnly, ConnectionProfile connection) throws UPAException;

    QueryExecutor createDefaultExecutor(
            Expression baseExpression,
            Map<String, Object> parametersByName,
            Map<Integer, Object> parametersByIndex,
            boolean updatable,
            FieldFilter defaultFieldFilter, EntityExecutionContext context) throws UPAException;

    String getCreateImplicitViewStatement(Entity entity, EntityExecutionContext executionContext);

    QueryExecutor createExecutor(
            Expression baseExpression,
            Map<String, Object> parametersByName,
            Map<Integer, Object> parametersByIndex,
            boolean updatable,
            FieldFilter defaultFieldFilter,
            EntityExecutionContext context) throws UPAException;

    int getSupportLevel(ConnectionProfile connectionProfile, Properties parameters);

    SqlTypeName getSqlTypeName(DataType datatype);
}
