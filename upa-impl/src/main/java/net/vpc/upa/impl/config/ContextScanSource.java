package net.vpc.upa.impl.config;

import java.net.URL;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;
import net.vpc.upa.PersistenceGroup;
import net.vpc.upa.PersistenceUnit;
import net.vpc.upa.UPAContext;
import net.vpc.upa.config.ScanFilter;
import net.vpc.upa.impl.util.classpath.ClassPathUtils;
import net.vpc.upa.impl.util.classpath.DefaultConfigFilter;
import net.vpc.upa.impl.util.classpath.URLClassIterable;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 9/24/12 3:01 AM
 */
public class ContextScanSource extends BaseScanSource {

    private boolean noIgnore;
    private URL[] urls;

    public ContextScanSource(boolean noIgnore) {
        this.noIgnore = noIgnore;
//        this.staticConfig = staticConfig;
    }

    public boolean isNoIgnore() {
        return noIgnore;
    }

    @Override
    public String toString() {
        StringBuilder s = new StringBuilder(getClass().getSimpleName());
        s.append("[noIgnore=");
        s.append(noIgnore);
        s.append("]");
        return s.toString();
    }

    @Override
    public Iterable<Class> toIterable(Object context) {
        List<ScanFilter> _filters = new ArrayList<ScanFilter>();
        if (context instanceof UPAContext) {
            UPAContext pg = (UPAContext) context;
            _filters.addAll(Arrays.asList(pg.getContextAnnotationStrategyFilters()));
        } else if (context instanceof PersistenceGroup) {
            PersistenceGroup pg = (PersistenceGroup) context;
            for (ScanFilter filter : pg.getContext().getContextAnnotationStrategyFilters()) {
                if (filter.isPropagate()) {
                    _filters.add(filter);
                }
            }
            _filters.addAll(Arrays.asList(pg.getContextAnnotationStrategyFilters()));
        } else if (context instanceof PersistenceUnit) {
            PersistenceUnit pu = (PersistenceUnit) context;
            for (ScanFilter filter : pu.getPersistenceGroup().getContext().getContextAnnotationStrategyFilters()) {
                if (filter.isPropagate()) {
                    _filters.add(filter);
                }
            }
            for (ScanFilter filter : pu.getPersistenceGroup().getContextAnnotationStrategyFilters()) {
                if (filter.isPropagate()) {
                    _filters.add(filter);
                }
            }
            for (ScanFilter filter : pu.getContextAnnotationStrategyFilters()) {
                _filters.add(filter);
            }
        } else {
            throw new IllegalArgumentException("Unsupported context " + context);
        }
        return new URLClassIterable(getUrls(),
                new DefaultConfigFilter(_filters.toArray(new ScanFilter[_filters.size()])),
                null);
    }

    private URL[] getUrls() {
        if(urls==null) {
            urls = ClassPathUtils.resolveClassPathLibs();
        }
        return urls;
    }

}
