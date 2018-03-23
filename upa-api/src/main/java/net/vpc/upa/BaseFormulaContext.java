package net.vpc.upa;

import net.vpc.upa.persistence.ContextOperation;
import net.vpc.upa.persistence.EntityExecutionContext;
import net.vpc.upa.persistence.PersistenceStore;
import net.vpc.upa.persistence.UConnection;

/**
 * return and evaluation of the field's "field" value of the entity identified by "id"
 *
 * @param field            field holding the formula
 * @param id               entity id
 * @param executionContext executionContext
 * @return formula evaluated value
 */
public interface BaseFormulaContext {

    Entity getEntity();

    PersistenceUnit getPersistenceUnit();

    UConnection getConnection();

    Session getSession();

    PersistenceStore getPersistenceStore();

    boolean isPersist();
    boolean isUpdate();

    /**
     * @return persist document is getOperation() is ContextOperation.PERSIST
     */
    Document getUpdateDocument();

    /**
     * @return update query is getOperation() is ContextOperation.UPDATE
     */
    UpdateQuery getUpdateQuery();

    EntityExecutionContext getExecutionContext();
}
