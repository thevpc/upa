package net.vpc.upa.impl.extension;

import net.vpc.upa.RemoveOptions;
import net.vpc.upa.RemoveTrace;
import net.vpc.upa.Entity;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.expressions.Expression;
import net.vpc.upa.persistence.EntityRemoveOperation;
import net.vpc.upa.persistence.EntityExecutionContext;

import java.util.List;
import net.vpc.upa.Query;
import net.vpc.upa.expressions.Delete;

/**
* @author Taha BEN SALAH <taha.bensalah@gmail.com>
* @creationdate 1/7/13 2:00 AM
*/
class EntityRemoveOperationHelper implements EntityRemoveOperation {
    private DefaultUnionEntityExtension defaultUnionEntityExtensionSupport;
    private List<Entity> updatableTables;

    public EntityRemoveOperationHelper(DefaultUnionEntityExtension defaultUnionEntityExtensionSupport, List<Entity> updatableTables) {
        this.defaultUnionEntityExtensionSupport = defaultUnionEntityExtensionSupport;
        this.updatableTables = updatableTables;
    }

    @Override
    public int delete(Entity entity, EntityExecutionContext context, Expression condition, boolean recurse, RemoveTrace deleteInfo) throws UPAException {
        for (int i = 0; i < updatableTables.size(); i++) {
            updatableTables.get(i).remove(RemoveOptions
                    .forExpression(defaultUnionEntityExtensionSupport.getViewElementExpressionAt(i, condition))
                    .setFollowLinks(recurse)
                    .setSimulate(false)
                    .setRemoveTrace(deleteInfo)
            );
        }
        return 0;
    }

    public Query createQuery(Entity e, Delete query, EntityExecutionContext context) throws UPAException {
        throw new UnsupportedOperationException("Not supported yet.");
    }
    
}
