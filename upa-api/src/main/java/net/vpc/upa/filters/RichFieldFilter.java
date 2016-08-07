package net.vpc.upa.filters;

/**
 * @author taha.bensalah@gmail.com on 7/31/16.
 */
public interface RichFieldFilter extends FieldFilter {
    public RichFieldFilter and(FieldFilter filter);
    public RichFieldFilter andNot(FieldFilter filter);
    public RichFieldFilter or(FieldFilter filter);
    public RichFieldFilter orNot(FieldFilter filter);
    public RichFieldFilter negate();
}
