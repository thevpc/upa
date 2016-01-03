/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.bulk;

import net.vpc.upa.bulk.DataColumn;
import net.vpc.upa.bulk.DataRow;
import net.vpc.upa.impl.util.PlatformUtils;
import net.vpc.upa.impl.util.UPAUtils;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class DefaultDataRow implements DataRow {

    private DataColumn[] columns;
    private Object[] values;

    public DefaultDataRow(DataColumn[] columns, Object[] values) {
        this.columns = columns;
        this.values = values;
    }

    public DataColumn[] getColumns() {
        return columns;
    }

    public Object[] getValues() {
        return values;
    }

    @Override
    public String toString() {
        return "DefaultDataRow{" + "columns=" + PlatformUtils.arrayToString(columns) + ", values=" + PlatformUtils.arrayToString(values) + '}';
    }

    @Override
    public int hashCode() {
        int hash = 3;
        hash = 17 * hash;
        for (DataColumn v1 : this.columns) {
            hash = 31 * hash + v1.hashCode();
        }
        for (Object v1 : this.values) {
            hash = 31 * hash + (v1 == null ? 0 : v1.hashCode());
        }
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
        final DefaultDataRow other = (DefaultDataRow) obj;
        
        if (!UPAUtils.equals(this.columns, other.columns)) {
            return false;
        }
        if (!UPAUtils.equals(this.values, other.values)) {
            return false;
        }
        return true;
    }

}
