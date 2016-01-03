/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.config;

import net.vpc.upa.config.ScanSource;

/**
 *
 * @author vpc
 */
public abstract class BaseScanSource implements ScanSource{
    public abstract Iterable<Class> toIterable(Object context);
}
