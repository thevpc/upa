package net.vpc.upa.impl.config;


import java.util.ArrayList;
import java.util.LinkedHashMap;
import java.util.List;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 1/7/13 2:22 AM
 */
public class ContextElement {

    boolean autoScan = true;
    private LinkedHashMap<String, PersistenceGroupElement> persistenceGroups = new LinkedHashMap<String, PersistenceGroupElement>();
    private List<ScanElement> scanElements = new ArrayList<ScanElement>();

//    public ContextAnnotationStrategy getConfigurationStrategy() {
//        LinkedHashSet<ContextAnnotationStrategyFilter> filters = new LinkedHashSet<ContextAnnotationStrategyFilter>();
//        for (ConfigureElement configureElement : configElements) {
//            filters.add(new ContextAnnotationStrategyFilter(configureElement.libs, configureElement.types, configureElement.propagate));
//        }
//        return (new ContextAnnotationStrategy(filters.toArray(new ContextAnnotationStrategyFilter[filters.size()])));
//    }

    public void addScanElement(ScanElement e) {
        scanElements.add(e);
    }

    public List<ScanElement> getScanElements() {
        return scanElements;
    }
    

    public void addPersistenceGroupElement(PersistenceGroupElement e) {
        persistenceGroups.put(e.name, e);
        e.parent = this;
    }

    public PersistenceGroupElement getPersistenceGroupElement(String name) {
        return persistenceGroups.get(name);
    }

    public PersistenceGroupElement getOrAddPersistenceGroupElement(String name) {
        PersistenceGroupElement v = getPersistenceGroupElement(name);
        if (v == null) {
            v = new PersistenceGroupElement();
            v.name = name;
            v.parent = this;
            persistenceGroups.put(name, v);
        }
        return v;
    }

    public List<PersistenceGroupElement> getPersistenceGroupElements() {
        return new ArrayList<PersistenceGroupElement>(persistenceGroups.values());
    }

    
}
