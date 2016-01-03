/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl;

import net.vpc.upa.exceptions.NoSuchPersistenceUnitException;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.persistence.PersistenceStore;
import net.vpc.upa.persistence.StructureStrategy;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
class CreateStorageOnHoldCommitAction implements OnHoldCommitAction {

    public CreateStorageOnHoldCommitAction() {
    }

    @Override
    public void commitModel() throws UPAException {
        //do nothing
    }

    @Override
    public void commitStorage(PersistenceStore persistenceStore) throws UPAException {
        StructureStrategy option = persistenceStore.getConnectionProfile().getStructureStrategy();
        switch (option) {
            case DROP: {
                if (!persistenceStore.isCreatedStorage()) {
                    persistenceStore.createStorage();
                } else {
                    persistenceStore.dropStorage();
                    persistenceStore.dropStorage();
                    persistenceStore.createStorage();
                }
                break;
            }
            case CREATE:
            case SYNCHRONIZE: {
                if (!persistenceStore.isCreatedStorage()) {
                    persistenceStore.createStorage();
                }
                break;
            }
            case MANDATORY: {
                if (!persistenceStore.isCreatedStorage()) {
                    throw new NoSuchPersistenceUnitException(persistenceStore.getPersistenceUnit().getName());
                }
                //                        if (!isValidPersistenceUnit()) {
                //                            throw new NoSuchPersistenceUnitException(getName(), null);
                //                        }
                break;
            }
            case IGNORE: {
                //do nothing
                break;
            }
        }
    }

    @Override
    public int getOrder() {
        return 0;
    }

    @Override
    public int compareTo(OnHoldCommitAction o) {
        int i1 = getOrder();
        int i2 = o.getOrder();
        int i = i1 - i2;
        if (i != 0) {
            return i;
        }
        if (this == o) {
            return 0;
        }
        return i;
    }

    @Override
    public String toString() {
        return "CreateStorage(order="+getOrder()+")";
    }
    
}
