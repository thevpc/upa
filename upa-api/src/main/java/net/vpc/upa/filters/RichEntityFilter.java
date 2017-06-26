package net.vpc.upa.filters;

/**
 * @author taha.bensalah@gmail.com on 7/31/16.
 */
public interface RichEntityFilter extends EntityFilter {
    RichEntityFilter and(EntityFilter filter);

    RichEntityFilter or(EntityFilter filter);

    RichEntityFilter negate();
}
