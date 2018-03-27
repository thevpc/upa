/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.vpc.upa.impl.transform;

import net.vpc.upa.types.ByteArrayEncoder;

/**
 *
 * @author taha.bensalah@gmail.com
 */
public class ChainByteArrayEncoder implements ByteArrayEncoder {

    private ByteArrayEncoder a;
    private ByteArrayEncoder b;

    public ChainByteArrayEncoder(ByteArrayEncoder a, ByteArrayEncoder b) {
        this.a = a;
        this.b = b;
    }

    public byte[] encode(Object bytes) {
        return b.encode(a.encode(bytes));
    }

    public Object decode(byte[] value) {
        return a.decode((byte[]) b.decode(value));
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;

        ChainByteArrayEncoder that = (ChainByteArrayEncoder) o;

        if (a != null ? !a.equals(that.a) : that.a != null) return false;
        return b != null ? b.equals(that.b) : that.b == null;
    }

    @Override
    public int hashCode() {
        int result = a != null ? a.hashCode() : 0;
        result = 31 * result + (b != null ? b.hashCode() : 0);
        return result;
    }
}
