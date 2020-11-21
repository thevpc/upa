package net.thevpc.upa.impl.ext.persistence;

import net.thevpc.upa.PersistenceUnit;
import net.thevpc.upa.persistence.PersistenceStore;
import net.thevpc.upa.Document;
import net.thevpc.upa.Entity;
import net.thevpc.upa.UpdateQuery;
import net.thevpc.upa.persistence.ContextOperation;
import net.thevpc.upa.persistence.EntityExecutionContext;
import net.thevpc.upa.persistence.EntityOperationManager;

/**
 * Created by vpc on 7/6/17.
 */
public interface EntityExecutionContextExt extends EntityExecutionContext {

    void initPersistenceUnit(PersistenceUnit persistenceUnit, PersistenceStore persistenceStore, ContextOperation contextOperation);

    void initEntity(Entity currentEntity, EntityOperationManager entityOperationManager);

    void setUpdateDocument(Document document);

    void setUpdateQuery(UpdateQuery updateQuery);
}
