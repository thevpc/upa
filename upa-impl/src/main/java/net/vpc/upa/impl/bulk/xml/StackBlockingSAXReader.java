/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.bulk.xml;

import java.io.EOFException;
import java.io.IOException;
import java.util.List;
import java.util.NoSuchElementException;
import java.util.concurrent.TimeUnit;
import net.vpc.upa.PortabilityHint;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
@PortabilityHint(target = "C#", name = "ignore")
public interface StackBlockingSAXReader<E> {

    /**
     * Retrieves and removes the head of this queue, waiting if necessary until
     * an element becomes available.
     *
     * @return the head of this queue
     * @throws InterruptedException if interrupted while waiting
     */
    E take() throws InterruptedException, IOException;

    /**
     * Retrieves and removes the head of this queue, waiting up to the specified
     * wait time if necessary for an element to become available.
     *
     * @param timeout how long to wait before giving up, in units of
     * <tt>unit</tt>
     * @param unit a <tt>TimeUnit</tt> determining how to interpret the
     * <tt>timeout</tt> parameter
     * @return the head of this queue, or <tt>null</tt> if the specified waiting
     * time elapses before an element is available
     * @throws InterruptedException if interrupted while waiting
     */
    E poll(long timeout, TimeUnit unit) throws InterruptedException, IOException;

    /**
     * Retrieves and removes the head of this queue. This method differs from
     * {@link #poll poll} only in that it throws an exception if this queue is
     * empty.
     *
     * @return the head of this queue
     * @throws NoSuchElementException if this queue is empty
     */
    E remove() throws IOException;

    /**
     * Retrieves and removes the head of this queue, or returns <tt>null</tt> if
     * this queue is empty.
     *
     * @return the head of this queue, or <tt>null</tt> if this queue is empty
     */
    E poll() throws IOException;

    List<E> takeList() throws InterruptedException, IOException;
}
