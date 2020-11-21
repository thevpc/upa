package net.thevpc.upa.impl.util.filters;

import net.thevpc.upa.FieldModifier;
import net.thevpc.upa.Field;
import net.thevpc.upa.exceptions.UPAException;
import net.thevpc.upa.filters.AbstractFieldFilter;

/**
* Created by vpc on 12/23/13.
*/
public class PersistNonNullableFieldFilter extends AbstractFieldFilter {
    @Override
    public boolean acceptDynamic() throws UPAException {
        return false;
    }

    @Override
    public boolean accept(Field f) throws UPAException {
        return f.getModifiers().contains(FieldModifier.PERSIST)
                && !f.getModifiers().contains(FieldModifier.ID)
                && !f.getDataType().isNullable();
    }

    @Override
    public String toString() {
        return "PersistNonNullableFieldFilter";
    }
}
