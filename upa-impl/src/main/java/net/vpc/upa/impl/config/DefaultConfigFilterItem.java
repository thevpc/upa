/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.config;

import net.vpc.upa.impl.util.classpath.PatternListClassNameFilter;
import net.vpc.upa.impl.util.classpath.PatternListLibNameFilter;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class DefaultConfigFilterItem {

    private PatternListClassNameFilter typeFilter;
    private PatternListLibNameFilter libFilter;

    public DefaultConfigFilterItem(PatternListLibNameFilter libFilter, PatternListClassNameFilter typeFilter) {
        this.typeFilter = typeFilter;
        this.libFilter = libFilter;
    }

    public PatternListClassNameFilter getTypeFilter() {
        return typeFilter;
    }

    public PatternListLibNameFilter getLibFilter() {
        return libFilter;
    }
}
