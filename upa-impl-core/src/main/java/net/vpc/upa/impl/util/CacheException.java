package net.vpc.upa.impl.util;

import net.vpc.upa.exceptions.UPAException;

/**
* @author Taha BEN SALAH <taha.bensalah@gmail.com>
* @creationdate 1/5/13 9:59 PM
*/
public class CacheException extends UPAException {
    private Throwable error;

    public Throwable getError() {
        return error;
    }


    public CacheException(String msg) {
        this(msg, null);
    }

    public CacheException(Throwable error) {
        this(error.getMessage(), error);
    }

    public CacheException(String msg, Throwable error) {
        super(msg);
    }
}
