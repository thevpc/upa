/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.util;

import net.vpc.upa.Field;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.filters.AbstractFieldFilter;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class DataTypeClassFieldFilter extends AbstractFieldFilter {

    private Class type;

    public DataTypeClassFieldFilter(Class type) {
        this.type = type;
    }

    @Override
    public boolean acceptDynamic() throws UPAException {
        return true;
    }

    @Override
    public boolean accept(Field f) throws UPAException {
        return type.isAssignableFrom(f.getDataType().getClass());
    }

    @Override
    public int hashCode() {
        int hash = 7;
        hash = 97 * hash + (this.type != null ? this.type.hashCode() : 0);
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
        if (this.type != other.type && (this.type == null || !this.type.equals(other.type))) {
            return false;
        }
        return true;
    }
}
