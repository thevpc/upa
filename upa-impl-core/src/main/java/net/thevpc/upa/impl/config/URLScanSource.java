package net.thevpc.upa.impl.config;

import java.net.URL;
import java.util.Arrays;
import net.thevpc.upa.config.ScanFilter;
import net.thevpc.upa.impl.util.classpath.DefaultConfigFilter;
import net.thevpc.upa.impl.util.classpath.URLClassIterable;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 9/24/12 3:01 AM
 */
public class URLScanSource extends BaseScanSource {

    private ScanFilter[] filters;
    private URL[] urls;

    public URLScanSource(URL[] urls, ScanFilter[] filters) {
        this.urls = urls;
        this.filters = filters==null?new ScanFilter[0]:filters;
    }

    public URL[] getUrls() {
        return urls;
    }

    public ScanFilter[] getFilters() {
        return filters;
    }

    @Override
    public String toString() {
        return getClass().getSimpleName() + "["+getName()+"]{" + Arrays.toString(urls) + "," + Arrays.toString(filters) + "}";
    }

    @Override
    public Iterable<Class> toIterable(Object context) {
        return new URLClassIterable(getName(),getUrls(),
                new DefaultConfigFilter(getFilters()),
                null);
    }

}
