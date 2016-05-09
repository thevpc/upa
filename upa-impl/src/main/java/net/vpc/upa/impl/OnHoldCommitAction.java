package net.vpc.upa.impl;

import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.persistence.EntityExecutionContext;
import net.vpc.upa.persistence.PersistenceStore;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 9/9/12 4:19 PM
 */
public interface OnHoldCommitAction extends Comparable<OnHoldCommitAction>{

    public void commitModel() throws UPAException;

    public void commitStorage(EntityExecutionContext context) throws UPAException;

    public int getOrder();
}
