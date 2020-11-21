package net.thevpc.upa.impl;

import net.thevpc.upa.impl.sysentities.PrivateSequence;
import net.thevpc.upa.exceptions.UPAException;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 8/27/12 11:59 PM
 */
public interface SequenceManager {

    PrivateSequence getOrCreateSequence(String name, String pattern, int initialValue, int increment) throws UPAException;

    PrivateSequence getSequence(String name, String pattern) throws UPAException;

    PrivateSequence createSequence(String name, String pattern, int initialValue, int increment) throws UPAException;

    boolean isLocked(String name, String pattern) throws UPAException;

    boolean isLockedBySelf(String name, String pattern) throws UPAException;

    boolean isLockedBy(String name, String pattern, String user) throws UPAException;

    int lockValue(String name, String pattern) throws UPAException;

    int getCurrentValue(String name, String pattern) throws UPAException;

    int nextValue(String name, String pattern, int initialValue, int increment) throws UPAException;
    
//    int nextValue(String name, String pattern) throws UPAException;

    int unlock(String name, String pattern) throws UPAException;
}
