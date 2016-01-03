/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.bulk.xml;

import net.vpc.upa.PortabilityHint;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
@PortabilityHint(target = "C#",name = "suppress")
public class BlockingVal {

    public static final int TYPE_VALUE = 0;
    public static final int TYPE_EOF = 1;
    public static final int TYPE_THROWABLE = 2;
    int blockingValType;
    Object value;

    public BlockingVal(int blockingValType, Object value) {
        this.blockingValType = blockingValType;
        this.value = value;
    }

    public int getBlockingValType() {
        return blockingValType;
    }

    public Object getValue() {
        return value;
    }
}
