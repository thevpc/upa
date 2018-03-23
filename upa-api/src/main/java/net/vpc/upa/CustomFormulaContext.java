package net.vpc.upa;

import net.vpc.upa.persistence.ContextOperation;
import net.vpc.upa.persistence.EntityExecutionContext;
import net.vpc.upa.persistence.PersistenceStore;
import net.vpc.upa.persistence.UConnection;

/**
 * return and evaluation of the field's "field" value of the entity identified by "id"
 * @param field field holding the formula
 * @param id entity id
 * @param executionContext executionContext
 * @return formula evaluated value
 */
public interface CustomFormulaContext extends BaseFormulaContext{
    Field getField();
    Object getObjectId();
}
