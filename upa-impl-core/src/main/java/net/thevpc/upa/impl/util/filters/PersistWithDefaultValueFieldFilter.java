package net.thevpc.upa.impl.util.filters;

import net.thevpc.upa.FieldModifier;
import net.thevpc.upa.Field;
import net.thevpc.upa.FlagSet;
import net.thevpc.upa.exceptions.UPAException;
import net.thevpc.upa.filters.AbstractFieldFilter;

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

    @Override
    public String toString() {
        return "PersistWithDefaultValueFieldFilter";
    }
}
