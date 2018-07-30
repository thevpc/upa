package net.vpc.upa;

import net.vpc.upa.persistence.ContextOperation;
import net.vpc.upa.persistence.EntityExecutionContext;
import net.vpc.upa.persistence.PersistenceStore;
import net.vpc.upa.persistence.UConnection;

/**
 * Formula context base interface for {@link CustomFormulaContext} and {@link CustomMultiFormulaContext} interfaces.
 * Such interfaces are to be used as a single param in  methods annotated with @NamedFormula annotations.
 * Named formulas are convenient ways to implement a custom formula in Java/C# instead of UPQL.
 */
public interface BaseFormulaContext extends EntityExecutionContext{

    /**
     * Current operation.
     * @return true if formula is being invoked in persist operation
     */
    boolean isPersist();

    /**
     * Current operation.
     * @return true if formula is being invoked in update operation
     */
    boolean isUpdate();

}
