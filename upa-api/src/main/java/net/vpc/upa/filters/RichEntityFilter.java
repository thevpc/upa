package net.vpc.upa.filters;

/**
 * @author taha.bensalah@gmail.com on 7/31/16.
 */
public interface RichEntityFilter extends EntityFilter {
    public RichEntityFilter and(EntityFilter filter);
    public RichEntityFilter or(EntityFilter filter);
    public RichEntityFilter negate();
}
