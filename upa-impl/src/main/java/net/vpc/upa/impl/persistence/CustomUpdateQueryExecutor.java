package net.vpc.upa.impl.persistence;

import net.vpc.upa.Entity;
import net.vpc.upa.EntityBuilder;
import net.vpc.upa.Field;
import net.vpc.upa.Document;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.expressions.Expression;
import net.vpc.upa.expressions.Select;
import net.vpc.upa.expressions.Update;
import net.vpc.upa.expressions.VarVal;
import net.vpc.upa.filters.FieldFilter;
import net.vpc.upa.impl.uql.util.UQLUtils;
import net.vpc.upa.persistence.EntityExecutionContext;
import net.vpc.upa.persistence.QueryResult;
import net.vpc.upa.persistence.ResultMetaData;
import net.vpc.upa.persistence.UConnection;

import java.util.List;
import java.util.Map;

/**
 * Created by vpc on 7/1/16.
 */
class CustomUpdateQueryExecutor implements QueryExecutor {
    private DefaultPersistenceStore defaultPersistenceStore;
    private final Map<String, Object> finalHints;
    private final Update baseExpression;
    private final Map<String, Object> parametersByName;
    private final Map<Integer, Object> parametersByIndex;
    private final boolean updatable;
    private final FieldFilter defaultFieldFilter;
    private final EntityExecutionContext context;
    private final List<VarVal> complexVals;
    private final Entity entity;
    private final String entityName;
    private final ResultMetaData metadata;
    private int resultCount;
    private UConnection connection;

    public CustomUpdateQueryExecutor(DefaultPersistenceStore defaultPersistenceStore, Map<String, Object> finalHints, Update baseExpression, Map<String, Object> parametersByName, Map<Integer, Object> parametersByIndex, boolean updatable, FieldFilter defaultFieldFilter, EntityExecutionContext context, List<VarVal> complexVals, Entity entity, String entityName, ResultMetaData metadata) {
        this.defaultPersistenceStore = defaultPersistenceStore;
        this.finalHints = finalHints;
        this.baseExpression = baseExpression;
        this.parametersByName = parametersByName;
        this.parametersByIndex = parametersByIndex;
        this.updatable = updatable;
        this.defaultFieldFilter = defaultFieldFilter;
        this.context = context;
        this.complexVals = complexVals;
        this.entity = entity;
        this.entityName = entityName;
        this.metadata = metadata;
        this.connection = context.getConnection();
    }

    @Override
    public QueryResult getQueryResult() {
        return null;
    }

    @Override
    public Map<String, Object> getHints() {
        return finalHints;
    }

    @Override
    public int getResultCount() {
        return resultCount;
    }

    @Override
    public QueryExecutor execute() throws UPAException {
        int c1 = 0;
        int c2 = 0;
        String oldAlias = baseExpression.getEntityAlias();
        if (oldAlias == null) {
            oldAlias = UQLUtils.THIS;//entity.getName();
        }
        boolean replaceThis = !UQLUtils.THIS.equals(oldAlias);
        if (baseExpression.countFields() > 0) {
//            if (replaceThis) {
//                UQLUtils.replaceThisVar(baseExpression, oldAlias, context.getPersistenceUnit());
//            }
            c1 = defaultPersistenceStore.createDefaultExecutor(baseExpression, parametersByName, parametersByIndex, updatable, defaultFieldFilter, context)
                    .execute().getResultCount();
        }
        if (complexVals.size() > 0) {
            Select q = new Select();
            for (Field primaryField : entity.getPrimaryFields()) {
                q.field(primaryField.getName());
            }
            for (VarVal f : complexVals) {
                Expression fieldExpression = f.getVal();
                if (replaceThis) {
                    UQLUtils.replaceThisVar(fieldExpression, oldAlias, context.getPersistenceUnit());
                }
                q.field(fieldExpression, f.getVar().getName());
            }
            q.from(entity.getName(), oldAlias);
            Expression cond = baseExpression.getCondition();
            q.setWhere(cond == null ? null : cond.copy());

            EntityBuilder eb = entity.getBuilder();

            for (Document document : entity.getPersistenceUnit().createQuery(q).getDocumentList()) {
                Update u2 = new Update();
                u2.entity(entityName);
                for (VarVal f : complexVals) {
                    String fname = f.getVar().getName();
                    u2.set(fname, document.getObject(fname));
                }
                Expression exprId = eb.objectToIdExpression(document, oldAlias);
                u2.where(exprId);
                c2 += defaultPersistenceStore.createDefaultExecutor(u2, parametersByName, parametersByIndex, updatable, defaultFieldFilter, context)
                        .execute()
                        .getResultCount();
            }
        }
        resultCount = Math.max(c1, c2);
        return this;
    }

    @Override
    public ResultMetaData getMetaData() {
        return metadata;
    }

    @Override
    public NativeField[] getFields() {
        return new NativeField[0];
    }

    @Override
    public UConnection getConnection() {
        return connection;
    }
}
