package net.thevpc.upa.impl.eval;

import net.thevpc.upa.BaseFormulaContext;
import net.thevpc.upa.impl.persistence.ExecutionContextAdapter;

import net.thevpc.upa.persistence.ContextOperation;
import net.thevpc.upa.persistence.EntityExecutionContext;

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
