/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.bulk.xml;

import java.io.EOFException;
import java.util.concurrent.ArrayBlockingQueue;
import java.util.concurrent.BlockingQueue;
import net.vpc.upa.PortabilityHint;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
@PortabilityHint(target = "C#",name = "suppress")
public class BlockingValQueue<E> {

    private BlockingQueue<BlockingVal> queue;

    public BlockingValQueue(int capacity) {
        queue = new ArrayBlockingQueue<BlockingVal>(capacity);
    }

    public void putEOF() throws InterruptedException {
        queue.put(new BlockingVal(BlockingVal.TYPE_EOF, null));
    }

    public void putThrowable(Throwable th) throws InterruptedException {
        queue.put(new BlockingVal(BlockingVal.TYPE_THROWABLE, th));
    }

    public E takeOrError() throws InterruptedException, Throwable {
        BlockingVal take = queue.take();
        switch (take.getBlockingValType()) {
            case BlockingVal.TYPE_EOF: {
                throw new EOFException();
            }
            case BlockingVal.TYPE_THROWABLE: {
                throw (Throwable) take.getValue();
            }
        }
        return (E) take.getValue();
    }
    
    public E takeOrNull() throws InterruptedException, Throwable {
        BlockingVal take = queue.take();
        switch (take.getBlockingValType()) {
            case BlockingVal.TYPE_EOF: {
                return null;
            }
            case BlockingVal.TYPE_THROWABLE: {
                throw (Throwable) take.getValue();
            }
        }
        return (E) take.getValue();
    }
}
