package net.vpc.upa.impl.ext.persistence;

import net.vpc.upa.PersistenceUnit;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.persistence.ConnectionProfile;
import net.vpc.upa.persistence.PersistenceNameConfig;
import net.vpc.upa.persistence.PersistenceStore;

/**
 * Created by vpc on 7/6/17.
 */
public interface PersistenceStoreExt extends PersistenceStore {
    void init(PersistenceUnit persistenceUnit, boolean readOnly, ConnectionProfile connection, PersistenceNameConfig nameConfig) throws UPAException;
}
