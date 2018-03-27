package net.vpc.upa.impl.persistence;

import net.vpc.upa.Action;
import net.vpc.upa.Entity;

import java.util.Map;

/**
 * Created by vpc on 6/17/16.
 */
class FindByIdAction implements Action<Object> {
    private final Entity e;
    private final Object id;
    private final Map<String,Object> hints;

    public FindByIdAction(Entity e, Object id, Map<String,Object> hints) {
        this.e = e;
        this.id = id;
        this.hints = hints;
    }

    @Override
    public Object run() {
        return e.createQueryBuilder().byId(id).setHints(hints).getFirstResultOrNull();
    }
}
