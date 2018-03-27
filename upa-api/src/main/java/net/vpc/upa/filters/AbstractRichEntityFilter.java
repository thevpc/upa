package net.vpc.upa.filters;

/**
 * @author taha.bensalah@gmail.com on 7/31/16.
 */
public abstract class AbstractRichEntityFilter implements RichEntityFilter {
    public RichEntityFilter and(EntityFilter filter) {
        EntityAndFilter a = new EntityAndFilter();
        a.and(this);
        a.and(filter);
        return a;
    }

    public RichEntityFilter or(EntityFilter filter) {
        EntityOrFilter a = new EntityOrFilter();
        a.and(this);
        a.and(filter);
        return a;
    }

    @Override
    public RichEntityFilter negate() {
        return new EntityReverseFilter(this);
    }
}
