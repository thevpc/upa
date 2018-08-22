package net.vpc.upa.impl.ext.persistence;

import java.util.Map;

import net.vpc.upa.Entity;
import net.vpc.upa.PersistenceUnit;
import net.vpc.upa.Properties;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.expressions.Expression;
import net.vpc.upa.filters.FieldFilter;
import net.vpc.upa.impl.persistence.QueryExecutor;
import net.vpc.upa.impl.persistence.SqlTypeName;
import net.vpc.upa.persistence.ConnectionProfile;
import net.vpc.upa.persistence.EntityExecutionContext;
import net.vpc.upa.persistence.PersistenceStore;
import net.vpc.upa.types.DataType;

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
