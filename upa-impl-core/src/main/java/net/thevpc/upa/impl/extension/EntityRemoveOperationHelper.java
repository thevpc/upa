package net.thevpc.upa.impl.extension;

import net.thevpc.upa.RemoveOptions;
import net.thevpc.upa.RemoveTrace;
import net.thevpc.upa.Entity;
import net.thevpc.upa.exceptions.UPAException;
import net.thevpc.upa.expressions.Expression;
import net.thevpc.upa.persistence.EntityRemoveOperation;
import net.thevpc.upa.persistence.EntityExecutionContext;

import java.util.List;
import net.thevpc.upa.Query;
import net.thevpc.upa.exceptions.UnsupportedUPAFeatureException;
import net.thevpc.upa.expressions.Delete;

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
    public int remove(Entity entity, EntityExecutionContext context, Expression condition, boolean recurse, RemoveTrace deleteInfo) throws UPAException {
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
        throw new UnsupportedUPAFeatureException("Not supported yet.");
    }
    
}
