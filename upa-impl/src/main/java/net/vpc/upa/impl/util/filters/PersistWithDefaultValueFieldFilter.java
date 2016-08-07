package net.vpc.upa.impl.util.filters;

import net.vpc.upa.FieldModifier;
import net.vpc.upa.Field;
import net.vpc.upa.FlagSet;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.filters.AbstractFieldFilter;

/**
* Created by vpc on 12/23/13.
*/
public class PersistWithDefaultValueFieldFilter extends AbstractFieldFilter {
    @Override
    public boolean acceptDynamic() throws UPAException {
        return false;
    }

    @Override
    public boolean accept(Field f) throws UPAException {
        FlagSet<FieldModifier> effectiveModifiers = f.getModifiers();
        return effectiveModifiers.contains(FieldModifier.PERSIST)
                && !effectiveModifiers.contains(FieldModifier.ID)
                && !effectiveModifiers.contains(FieldModifier.PERSIST_SEQUENCE) //                    && f.getDefaultObject() != null
                ;
    }
}
