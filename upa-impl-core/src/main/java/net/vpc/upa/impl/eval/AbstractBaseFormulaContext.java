package net.vpc.upa.impl.eval;

import net.vpc.upa.*;
import net.vpc.upa.expressions.Expression;
import net.vpc.upa.persistence.ContextOperation;
import net.vpc.upa.persistence.EntityExecutionContext;
import net.vpc.upa.persistence.PersistenceStore;
import net.vpc.upa.persistence.UConnection;

public class AbstractBaseFormulaContext implements BaseFormulaContext {
    EntityExecutionContext executionContext;

    public AbstractBaseFormulaContext(EntityExecutionContext executionContext) {
        this.executionContext = executionContext;
    }

    @Override
    public PersistenceUnit getPersistenceUnit() {
        return getExecutionContext().getPersistenceUnit();
    }

    @Override
    public UConnection getConnection() {
        return getExecutionContext().getConnection();
    }

    @Override
    public Session getSession() {
        return getExecutionContext().getSession();
    }

    @Override
    public PersistenceStore getPersistenceStore() {
        return getExecutionContext().getPersistenceStore();
    }

    @Override
    public boolean isPersist() {
        return getExecutionContext().getOperation()==ContextOperation.PERSIST;
    }

    @Override
    public boolean isUpdate() {
        return getExecutionContext().getOperation()==ContextOperation.UPDATE;
    }

    @Override
    public Document getUpdateDocument() {
        return getExecutionContext().getUpdateDocument();
    }

    @Override
    public UpdateQuery getUpdateQuery() {
        return getExecutionContext().getUpdateQuery();
    }

    @Override
    public EntityExecutionContext getExecutionContext() {
        return executionContext;
    }

    @Override
    public Entity getEntity() {
        return getExecutionContext().getEntity();
    }
}
