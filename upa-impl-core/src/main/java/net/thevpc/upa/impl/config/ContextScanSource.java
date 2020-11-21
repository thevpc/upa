package net.thevpc.upa.impl.config;

import java.net.URL;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

import net.thevpc.upa.PersistenceUnit;
import net.thevpc.upa.PersistenceGroup;
import net.thevpc.upa.UPAContext;
import net.thevpc.upa.config.ScanFilter;
import net.thevpc.upa.exceptions.UnsupportedUPAFeatureException;
import net.thevpc.upa.impl.util.classpath.ClassPathUtils;
import net.thevpc.upa.impl.util.classpath.DefaultConfigFilter;
import net.thevpc.upa.impl.util.classpath.URLClassIterable;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 9/24/12 3:01 AM
 */
public class ContextScanSource extends BaseScanSource {
    private URL[] urls;
    public ContextScanSource() {
    }

    @Override
    public String toString() {
        StringBuilder s = new StringBuilder(getClass().getSimpleName());
        s.append("[");
        s.append(getName());
        s.append(",noIgnore=");
        s.append(isNoIgnore());
        s.append("]");
        return s.toString();
    }

    @Override
    public Iterable<Class> toIterable(Object context) {
        List<ScanFilter> _filters = new ArrayList<ScanFilter>();
        String contextString = "<unknown>";
        if (context instanceof UPAContext) {
            UPAContext pg = (UPAContext) context;
            _filters.addAll(Arrays.asList(pg.getScanFilters()));
            contextString = "UPAContext";
        } else if (context instanceof PersistenceGroup) {
            PersistenceGroup pg = (PersistenceGroup) context;
            if (pg.isInheritScanFilters()) {
                for (ScanFilter filter : pg.getContext().getScanFilters()) {
                    if (filter.isPropagate()) {
                        _filters.add(filter);
                    }
                }
            }
            _filters.addAll(Arrays.asList(pg.getScanFilters()));
            contextString = "PersistenceGroup[" + pg.getName() + "]";
        } else if (context instanceof PersistenceUnit) {
            PersistenceUnit pu = (PersistenceUnit) context;
            if (pu.isInheritScanFilters()) {
                if (pu.getPersistenceGroup().isInheritScanFilters()) {
                    for (ScanFilter filter : pu.getPersistenceGroup().getContext().getScanFilters()) {
                        if (filter.isPropagate()) {
                            _filters.add(filter);
                        }
                    }
                }
                for (ScanFilter filter : pu.getPersistenceGroup().getScanFilters()) {
                    if (filter.isPropagate()) {
                        _filters.add(filter);
                    }
                }
            }
            for (ScanFilter filter : pu.getScanFilters()) {
                _filters.add(filter);
            }
            contextString = "PersistenceUnit[" + pu.getAbsoluteName() + "]";
        } else {
            throw new UnsupportedUPAFeatureException("Unsupported context " + context);
        }
        return new URLClassIterable(getName() + ":" + contextString, getUrls(),
                new DefaultConfigFilter(_filters.toArray(new ScanFilter[_filters.size()])),
                null);
    }

    private URL[] getUrls() {
        if (urls == null) {
            urls = ClassPathUtils.resolveClassPathLibs();
        }
        return urls;
    }

}
