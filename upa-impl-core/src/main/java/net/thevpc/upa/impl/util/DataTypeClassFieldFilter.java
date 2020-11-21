/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.thevpc.upa.impl.util;

import net.thevpc.upa.Field;
import net.thevpc.upa.exceptions.UPAException;
import net.thevpc.upa.filters.AbstractFieldFilter;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class DataTypeClassFieldFilter extends AbstractFieldFilter {

    private Class platformType;

    public DataTypeClassFieldFilter(Class type) {
        this.platformType = type;
    }

    @Override
    public boolean acceptDynamic() throws UPAException {
        return true;
    }

    @Override
    public boolean accept(Field f) throws UPAException {
        return platformType.isAssignableFrom(f.getDataType().getClass());
    }

    @Override
    public int hashCode() {
        int hash = 7;
        hash = 97 * hash + (this.platformType != null ? this.platformType.hashCode() : 0);
        return hash;
    }

    @Override
    public boolean equals(Object obj) {
        if (obj == null) {
            return false;
        }
        if (getClass() != obj.getClass()) {
            return false;
        }
        final DataTypeClassFieldFilter other = (DataTypeClassFieldFilter) obj;
        if (this.platformType != other.platformType && (this.platformType == null || !this.platformType.equals(other.platformType))) {
            return false;
        }
        return true;
    }
}
