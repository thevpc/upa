package net.vpc.upa.filters;

/**
 * @author taha.bensalah@gmail.com on 7/31/16.
 */
public interface RichFieldFilter extends FieldFilter {
    RichFieldFilter and(FieldFilter filter);
    RichFieldFilter andNot(FieldFilter filter);
    RichFieldFilter or(FieldFilter filter);
    RichFieldFilter orNot(FieldFilter filter);
    RichFieldFilter negate();
}
