package net.vpc.upa.impl.config;


import java.util.ArrayList;
import java.util.LinkedHashMap;
import java.util.List;
import net.vpc.upa.Property;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 1/7/13 2:24 AM
 */
public class PersistenceGroupElement {

    String name;
    ContextElement parent;
    boolean autoScan=true;
    boolean inheritScanFilters=true;
    List<Property> properties = new ArrayList<Property>();
    private List<ScanElement> scanElements = new ArrayList<ScanElement>();
    private LinkedHashMap<String, PersistenceUnitElement> persistenceUnitElements = new LinkedHashMap<String, PersistenceUnitElement>();

    public void addScanElement(ScanElement e) {
        scanElements.add(e);
    }

    public List<ScanElement> getScanElements() {
        return scanElements;
    }

    public PersistenceUnitElement getOrAddPersistenceUnitElement(String name) {
        PersistenceUnitElement v = persistenceUnitElements.get(name);
        if (v == null) {
            v = new PersistenceUnitElement();
            v.name = name;
            v.parent = this;
            persistenceUnitElements.put(name, v);
        }
        return v;
    }
    
    public List<PersistenceUnitElement> getPersistenceUnitElements(){
        return new ArrayList<PersistenceUnitElement>(persistenceUnitElements.values());
    }
}
