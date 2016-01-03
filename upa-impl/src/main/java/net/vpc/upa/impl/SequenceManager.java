package net.vpc.upa.impl;

import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.persistence.EntityExecutionContext;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 8/27/12 11:59 PM
 */
public interface SequenceManager {

    public PrivateSequence getOrCreateSequence(String name, String pattern, int initialValue, int increment) throws UPAException;

    public PrivateSequence getSequence(String name, String pattern) throws UPAException;

    void createSequence(String name, String pattern, int initialValue, int increment) throws UPAException;

    boolean isLocked(String name, String pattern) throws UPAException;

    boolean isLockedBySelf(String name, String pattern) throws UPAException;

    boolean isLockedBy(String name, String pattern, String user) throws UPAException;

    int lockValue(String name, String pattern) throws UPAException;

    int getCurrentValue(String name, String pattern) throws UPAException;

    int nextValue(String name, String pattern, int initialValue, int increment) throws UPAException;
    
//    int nextValue(String name, String pattern) throws UPAException;

    int unlock(String name, String pattern) throws UPAException;
}
