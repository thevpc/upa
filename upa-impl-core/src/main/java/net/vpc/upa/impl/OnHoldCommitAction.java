package net.vpc.upa.impl;

import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.persistence.EntityExecutionContext;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 9/9/12 4:19 PM
 */
public interface OnHoldCommitAction extends Comparable<OnHoldCommitAction>{

    void commitModel() throws UPAException;

    void commitStorage(EntityExecutionContext context) throws UPAException;

    int getOrder();
}
