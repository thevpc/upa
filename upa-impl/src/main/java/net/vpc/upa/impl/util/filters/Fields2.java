package net.vpc.upa.impl.util.filters;

import net.vpc.upa.AccessLevel;
import net.vpc.upa.FieldModifier;
import net.vpc.upa.filters.FieldFilter;
import net.vpc.upa.filters.FieldFilters;

/**
 * Created by vpc on 7/3/16.
 */
public class Fields2 {
    public static final FieldFilter VIEW = FieldFilters.byModifiersAnyOf(FieldModifier.SELECT_COMPILED);
    public static final FieldFilter PERSIST_FORMULA = FieldFilters
            .byModifiersAnyOf(FieldModifier.PERSIST_FORMULA)
            .and(FieldFilters.byModifiersNotAllOf(FieldModifier.PERSIST_SEQUENCE));
    public static final FieldFilter UPDATE_FORMULA = FieldFilters.regular().and(FieldFilters.byModifiersAnyOf(FieldModifier.UPDATE_FORMULA)).and(FieldFilters.byModifiersNoneOf(FieldModifier.UPDATE_SEQUENCE));
    public static final FieldFilter COPY_ON_CLONE = FieldFilters.regular().and(FieldFilters.byModifiersNoneOf(FieldModifier.PERSIST_FORMULA, FieldModifier.UPDATE_FORMULA, FieldModifier.TRANSIENT));
    public static final FieldFilter COPY_ON_RENAME = FieldFilters.regular().and(FieldFilters.byModifiersNoneOf(FieldModifier.PERSIST_FORMULA, FieldModifier.UPDATE_FORMULA, FieldModifier.TRANSIENT));
    public static final FieldFilter PERSIST = FieldFilters.byModifiersAllOf(FieldModifier.PERSIST);
    public static final FieldFilter PERSISTENT_NON_FORMULA = FieldFilters.byModifiersNoneOf(FieldModifier.PERSIST_FORMULA, FieldModifier.UPDATE_FORMULA, FieldModifier.TRANSIENT);
    public static final FieldFilter UPDATE = FieldFilters.byModifiersAllOf(FieldModifier.UPDATE);

    public static final FieldFilter READ = FieldFilters.regular().and(
            FieldFilters.byModifiersAnyOf(FieldModifier.SELECT_DEFAULT,
                    FieldModifier.SELECT_COMPILED,
                    FieldModifier.SELECT_LIVE))
                    .andNot(FieldFilters.byAllAccessLevel(AccessLevel.PRIVATE));

//    private static final FieldFilter READABLE_NON_ENTITY = Fields.regular().and(
//            Fields.byModifiersAnyOf(FieldModifier.SELECT_DEFAULT,
//                    FieldModifier.SELECT_COMPILED,
//                    FieldModifier.SELECT_LIVE)).andNot(Fields.byEntityType());

}
