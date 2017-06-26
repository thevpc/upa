package net.vpc.upa.filters;

import net.vpc.upa.Entity;
import net.vpc.upa.exceptions.UPAException;

/**
 * @author taha.bensalah@gmail.com on 7/31/16.
 */
class RichEntityFilterAdapter extends AbstractRichEntityFilter {
    private EntityFilter other;

    public RichEntityFilterAdapter(EntityFilter other) {
        if (other == null) {
            throw new NullPointerException();
        }
        this.other = other;
    }

    @Override
    public boolean accept(Entity entity) throws UPAException {
        return other.accept(entity);
    }
}
