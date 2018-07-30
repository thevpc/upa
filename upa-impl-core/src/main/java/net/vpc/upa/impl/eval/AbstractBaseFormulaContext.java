package net.vpc.upa.impl.eval;

import net.vpc.upa.*;
import net.vpc.upa.expressions.Expression;
import net.vpc.upa.impl.persistence.ExecutionContextAdapter;
import net.vpc.upa.persistence.ContextOperation;
import net.vpc.upa.persistence.EntityExecutionContext;
import net.vpc.upa.persistence.PersistenceStore;
import net.vpc.upa.persistence.UConnection;

public class AbstractBaseFormulaContext extends ExecutionContextAdapter implements BaseFormulaContext {

    public AbstractBaseFormulaContext(EntityExecutionContext executionContext) {
        super(executionContext);
    }

    @Override
    public boolean isPersist() {
        return getOperation()==ContextOperation.PERSIST;
    }

    @Override
    public boolean isUpdate() {
        return getOperation()==ContextOperation.UPDATE;
    }
}
