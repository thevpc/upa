/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.persistence;

import net.vpc.upa.persistence.DBConfigModel;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class FixedDBConfigModel implements DBConfigModel {

    private String connectionString;

    public FixedDBConfigModel(String connectionString) {
        this.connectionString = connectionString;
    }

    public String getConnectionString() {
        return connectionString;
    }

    public String[] getConnectionStringArray() {
        return new String[]{connectionString};
    }

    public void setConnectionString(String adapter) {
        //do nothing;
    }

    public void setConnectionStringArray(String[] adapters) {
        //do nothing;
    }
}
