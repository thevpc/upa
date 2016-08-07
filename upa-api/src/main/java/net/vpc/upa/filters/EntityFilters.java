package net.vpc.upa.filters;

import java.util.Arrays;
import java.util.HashSet;

/**
 * @author taha.bensalah@gmail.com on 7/31/16.
 */
public class EntityFilters {
    private static RichEntityFilter ALL = new EntityAnyFilter();
    private static final RichEntityFilter NONE = ALL.negate();
    public static RichEntityFilter byName(String ... names){
        return new EntityNameFilter(Arrays.asList(names));
    }
    public static RichEntityFilter not(EntityFilter filter){
        return of(filter).negate();
    }
    public static RichEntityFilter all(){
        return ALL;
    }
    public static RichEntityFilter of(EntityFilter filter){
        if(filter instanceof RichEntityFilter){
            return (RichEntityFilter) filter;
        }
        return new RichEntityFilterAdapter(filter);
    }
}
