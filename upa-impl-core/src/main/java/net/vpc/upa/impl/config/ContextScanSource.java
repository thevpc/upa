package net.vpc.upa.impl.config;

import java.net.URL;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;
import net.vpc.upa.PersistenceGroup;
import net.vpc.upa.PersistenceUnit;
import net.vpc.upa.UPAContext;
import net.vpc.upa.config.ScanFilter;
import net.vpc.upa.exceptions.UPAIllegalArgumentException;
import net.vpc.upa.impl.util.classpath.ClassPathUtils;
import net.vpc.upa.impl.util.classpath.DefaultConfigFilter;
import net.vpc.upa.impl.util.classpath.URLClassIterable;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 9/24/12 3:01 AM
 */
public class ContextScanSource extends BaseScanSource {

    private String name;
    private boolean noIgnore;
    private URL[] urls;

    public ContextScanSource(String name,boolean noIgnore) {
        this.name = name;
        this.noIgnore = noIgnore;
//        this.staticConfig = staticConfig;
    }

    @Override
    public String getName() {
        return name;
    }

    public boolean isNoIgnore() {
        return noIgnore;
    }

    @Override
    public String toString() {
        StringBuilder s = new StringBuilder(getClass().getSimpleName());
        s.append("[");
        s.append(name);
        s.append(",noIgnore=");
        s.append(noIgnore);
        s.append("]");
        return s.toString();
    }

    @Override
    public Iterable<Class> toIterable(Object context) {
        List<ScanFilter> _filters = new ArrayList<ScanFilter>();
        String contextString="<unknown>";
        if (context instanceof UPAContext) {
            UPAContext pg = (UPAContext) context;
            _filters.addAll(Arrays.asList(pg.getContextAnnotationStrategyFilters()));
            contextString="UPAContext";
        } else if (context instanceof PersistenceGroup) {
            PersistenceGroup pg = (PersistenceGroup) context;
            for (ScanFilter filter : pg.getContext().getContextAnnotationStrategyFilters()) {
                if (filter.isPropagate()) {
                    _filters.add(filter);
                }
            }
            _filters.addAll(Arrays.asList(pg.getContextAnnotationStrategyFilters()));
            contextString="PersistenceGroup["+pg.getName()+"]";
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
            contextString="PersistenceUnit["+pu.getAbsoluteName()+"]";
        } else {
            throw new UPAIllegalArgumentException("Unsupported context " + context);
        }
        return new URLClassIterable(name+":"+contextString,getUrls(),
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