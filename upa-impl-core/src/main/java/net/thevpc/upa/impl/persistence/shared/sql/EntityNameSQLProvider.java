package net.thevpc.upa.impl.persistence.shared.sql;

import net.thevpc.upa.Entity;
import net.thevpc.upa.config.PersistenceNameType;
import net.thevpc.upa.exceptions.UPAException;
import net.thevpc.upa.impl.persistence.SQLManager;
import net.thevpc.upa.impl.upql.ExpressionDeclarationList;
import net.thevpc.upa.impl.upql.ext.expr.CompiledEntityName;
import net.thevpc.upa.persistence.EntityExecutionContext;
import net.thevpc.upa.persistence.PersistenceStore;

/**
 * Created with IntelliJ IDEA.
 * User: vpc
 * Date: 8/15/12
 * Time: 11:46 PM
 * To change this template use File | Settings | File Templates.
 */
public class EntityNameSQLProvider extends AbstractSQLProvider {
    public EntityNameSQLProvider() {
        super(CompiledEntityName.class);
    }

    @Override
    public String getSQL(Object oo, EntityExecutionContext context, SQLManager sqlManager, ExpressionDeclarationList declarations) throws UPAException{
        CompiledEntityName o=(CompiledEntityName) oo;
        PersistenceStore persistenceStore = context.getPersistenceStore();
        String entityName = o.getName();

        Entity e = context.getPersistenceUnit().getEntity(entityName);
        if (o.isUseView() && e.hasAssociatedView() && persistenceStore.isViewSupported()) {
            return persistenceStore.getValidIdentifier(persistenceStore.getPersistenceName(e, PersistenceNameType.IMPLICIT_VIEW));
        } else {
            return persistenceStore.getValidIdentifier(persistenceStore.getPersistenceName(e));
        }
    }
}
