package net.vpc.upa.impl.util.filters;

import net.vpc.upa.FieldModifier;
import net.vpc.upa.Field;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.filters.AbstractFieldFilter;

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
}
