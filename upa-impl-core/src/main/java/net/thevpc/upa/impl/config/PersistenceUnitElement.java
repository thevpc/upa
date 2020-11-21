package net.thevpc.upa.impl.config;

import java.util.ArrayList;
import java.util.List;
import net.thevpc.upa.Property;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 1/7/13 2:24 AM
 */
public class PersistenceUnitElement {

    String name;
    PersistenceGroupElement parent;
    boolean start = true;
    boolean autoScan = true;
    boolean inheritScanFilters = true;
    boolean hasConfigElement;
    List<ConnectionElement> connectionElements = new ArrayList<ConnectionElement>();
    List<ConnectionElement> rootConnectionElements = new ArrayList<ConnectionElement>();
    List<Property> properties = new ArrayList<Property>();
    List<ScanElement> scanElements = new ArrayList<ScanElement>();

    public List<ScanElement> getScanElements() {
        return scanElements;
    }
}
