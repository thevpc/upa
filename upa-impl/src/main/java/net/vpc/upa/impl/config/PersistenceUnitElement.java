package net.vpc.upa.impl.config;

import java.util.ArrayList;
import java.util.List;
import net.vpc.upa.Property;
import net.vpc.upa.impl.util.VarContext;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 1/7/13 2:24 AM
 */
public class PersistenceUnitElement {

    String name;
    PersistenceGroupElement parent;
    boolean start = true;
    boolean autoScan = true;
    boolean hasConfigElement;
    List<ConnectionElement> connectionElements = new ArrayList<ConnectionElement>();
    List<ConnectionElement> rootConnectionElements = new ArrayList<ConnectionElement>();
    List<Property> properties = new ArrayList<Property>();
    List<ScanElement> scanElements = new ArrayList<ScanElement>();

//    public ConfigurationStrategy getConfigurationStrategy() {
//        LinkedHashSet<ContextAnnotationStrategyFilter> filters = new LinkedHashSet<ContextAnnotationStrategyFilter>();
//        for (ConfigureElement configureElement : configElements) {
//            filters.add(new ContextAnnotationStrategyFilter(configureElement.libs, configureElement.types,configureElement.propagate));
//        }
//        return (new ContextAnnotationStrategy(filters.toArray(new ContextAnnotationStrategyFilter[filters.size()])));
//    }

    public List<ScanElement> getScanElements() {
        return scanElements;
    }
}
