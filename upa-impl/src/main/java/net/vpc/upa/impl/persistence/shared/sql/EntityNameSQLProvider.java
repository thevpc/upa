package net.vpc.upa.impl.persistence.shared.sql;

import net.vpc.upa.Entity;
import net.vpc.upa.impl.persistence.shared.sql.AbstractSQLProvider;
import net.vpc.upa.persistence.PersistenceNameType;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.impl.persistence.SQLManager;
import net.vpc.upa.impl.uql.ExpressionDeclarationList;
import net.vpc.upa.impl.uql.compiledexpression.CompiledEntityName;
import net.vpc.upa.persistence.EntityExecutionContext;
import net.vpc.upa.persistence.PersistenceStore;

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
        if (o.isUseView() && e.needsView() && persistenceStore.isViewSupported()) {
            return persistenceStore.getValidIdentifier(persistenceStore.getPersistenceName(e, PersistenceNameType.IMPLICIT_VIEW));
        } else {
            return persistenceStore.getValidIdentifier(persistenceStore.getPersistenceName(e));
        }
    }
}
