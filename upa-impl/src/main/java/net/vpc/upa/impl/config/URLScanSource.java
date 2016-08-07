package net.vpc.upa.impl.config;

import java.net.URL;
import java.util.Arrays;
import net.vpc.upa.config.ScanFilter;
import net.vpc.upa.impl.util.classpath.DefaultConfigFilter;
import net.vpc.upa.impl.util.classpath.URLClassIterable;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 9/24/12 3:01 AM
 */
public class URLScanSource extends BaseScanSource {

    private ScanFilter[] filters;
    private URL[] urls;
    private boolean noIgnore;

    public URLScanSource(URL[] urls, ScanFilter[] filters, boolean noIgnore) {
        this.urls = urls;
        this.noIgnore = noIgnore;
        this.filters = filters==null?new ScanFilter[0]:filters;
    }

    public boolean isNoIgnore() {
        return noIgnore;
    }

    public URL[] getUrls() {
        return urls;
    }

    public ScanFilter[] getFilters() {
        return filters;
    }

    @Override
    public String toString() {
        return getClass().getSimpleName() + "{" + Arrays.toString(urls) + "," + Arrays.toString(filters) + "}";
    }

    @Override
    public Iterable<Class> toIterable(Object context) {
        return new URLClassIterable(getUrls(),
                new DefaultConfigFilter(getFilters()),
                null);
    }

}
