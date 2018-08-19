/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.vpc.upa.impl.config;

import net.vpc.upa.config.ScanSource;

/**
 *
 * @author taha.bensalah@gmail.com
 */
public abstract class BaseScanSource implements ScanSource {

    private String name;
    private boolean noIgnore;

    public String getName() {
        return name;
    }

    public ScanSource setName(String name) {
        this.name = name;
        return this;
    }

    public boolean isNoIgnore() {
        return noIgnore;
    }

    public ScanSource setNoIgnore(boolean noIgnore) {
        this.noIgnore = noIgnore;
        return this;
    }

    public abstract Iterable<Class> toIterable(Object context);
}
