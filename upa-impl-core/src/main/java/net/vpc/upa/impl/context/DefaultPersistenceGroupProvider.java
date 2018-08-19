package net.vpc.upa.impl.context;

import net.vpc.upa.PersistenceGroupProvider;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 9/16/12 7:11 PM
 */
public class DefaultPersistenceGroupProvider implements PersistenceGroupProvider {
    private String persistenceGroup;

    public DefaultPersistenceGroupProvider() {
    }

    @Override
    public String getPersistenceGroup() {
        return persistenceGroup;
    }

    @Override
    public void setPersistenceGroup(String current) {
        this.persistenceGroup = current;
    }
}
