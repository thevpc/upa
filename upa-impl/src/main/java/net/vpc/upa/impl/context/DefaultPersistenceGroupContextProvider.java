package net.vpc.upa.impl.context;

import net.vpc.upa.PersistenceGroup;
import net.vpc.upa.PersistenceGroupContextProvider;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 9/16/12 7:11 PM
 */
public class DefaultPersistenceGroupContextProvider implements PersistenceGroupContextProvider {
    private PersistenceGroup persistenceGroup;

    public DefaultPersistenceGroupContextProvider() {
    }

    @Override
    public PersistenceGroup getPersistenceGroup() {
        return persistenceGroup;
    }

    @Override
    public void setPersistenceGroup(PersistenceGroup current) {
        this.persistenceGroup = current;
    }
}
