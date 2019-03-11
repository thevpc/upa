package net.vpc.upa.xml;

import java.util.ArrayList;
import java.util.List;

public class UpaXml {
    private List<Scan> scans=new ArrayList<>();
    private List<Include> includes=new ArrayList<>();
    private List<PersistenceGroup> persistenceGroups=new ArrayList<>();
    private List<PersistenceUnit> persistenceUnits=new ArrayList<>();
    private List<Connection> connections=new ArrayList<>();
    private List<Connection> rootConnections=new ArrayList<>();
    private List<Property> properties=new ArrayList<>();

    public List<Scan> getScans() {
        return scans;
    }

    public UpaXml setScans(List<Scan> scans) {
        this.scans = scans;
        return this;
    }

    public List<Include> getIncludes() {
        return includes;
    }

    public UpaXml setIncludes(List<Include> includes) {
        this.includes = includes;
        return this;
    }

    public List<PersistenceGroup> getPersistenceGroups() {
        return persistenceGroups;
    }

    public UpaXml setPersistenceGroups(List<PersistenceGroup> persistenceGroups) {
        this.persistenceGroups = persistenceGroups;
        return this;
    }

    public List<PersistenceUnit> getPersistenceUnits() {
        return persistenceUnits;
    }

    public UpaXml setPersistenceUnits(List<PersistenceUnit> persistenceUnits) {
        this.persistenceUnits = persistenceUnits;
        return this;
    }

    public List<Connection> getConnections() {
        return connections;
    }

    public UpaXml setConnections(List<Connection> connections) {
        this.connections = connections;
        return this;
    }

    public List<Connection> getRootConnections() {
        return rootConnections;
    }

    public UpaXml setRootConnections(List<Connection> rootConnections) {
        this.rootConnections = rootConnections;
        return this;
    }

    public List<Property> getProperties() {
        return properties;
    }

    public UpaXml setProperties(List<Property> properties) {
        this.properties = properties;
        return this;
    }

    public static class Include {
        private Boolean failSafe;
        private List<IncludeItem> items = new ArrayList<>();

        public Boolean getFailSafe() {
            return failSafe;
        }

        public Include setFailSafe(Boolean failSafe) {
            this.failSafe = failSafe;
            return this;
        }

        public List<IncludeItem> getItems() {
            return items;
        }

        public Include setItems(List<IncludeItem> items) {
            this.items = items;
            return this;
        }
    }

    public static class IncludeItem {

    }


    public static abstract class IncludePath extends IncludeItem {
        private String path;
        private Boolean failSafe;
        private Boolean skipOthers;

        public String getPath() {
            return path;
        }

        public IncludePath setPath(String path) {
            this.path = path;
            return this;
        }

        public Boolean getFailSafe() {
            return failSafe;
        }

        public IncludePath setFailSafe(Boolean failSafe) {
            this.failSafe = failSafe;
            return this;
        }

        public Boolean getSkipOthers() {
            return skipOthers;
        }

        public IncludePath setSkipOthers(Boolean skipOthers) {
            this.skipOthers = skipOthers;
            return this;
        }
    }
    public static class IncludeFile extends IncludePath {

    }

    public static class IncludeResource extends IncludePath {

    }

    public static class IncludeURL extends IncludePath {
    }

    public static class IncludeDefault extends IncludeItem {
        private UpaXml content;

        public UpaXml getContent() {
            return content;
        }

        public IncludeDefault setContent(UpaXml content) {
            this.content = content;
            return this;
        }
    }

    public static class Connection{
        private String connectionString;
        private String userName;
        private String password;
        private String structure;
        private Boolean enabled;
        private List<Property> properties=new ArrayList<>();

        public String getConnectionString() {
            return connectionString;
        }

        public Connection setConnectionString(String connectionString) {
            this.connectionString = connectionString;
            return this;
        }

        public String getUserName() {
            return userName;
        }

        public Connection setUserName(String userName) {
            this.userName = userName;
            return this;
        }

        public String getPassword() {
            return password;
        }

        public Connection setPassword(String password) {
            this.password = password;
            return this;
        }

        public String getStructure() {
            return structure;
        }

        public Connection setStructure(String structure) {
            this.structure = structure;
            return this;
        }

        public Boolean getEnabled() {
            return enabled;
        }

        public Connection setEnabled(Boolean enabled) {
            this.enabled = enabled;
            return this;
        }

        public List<Property> getProperties() {
            return properties;
        }

        public Connection setProperties(List<Property> properties) {
            this.properties = properties;
            return this;
        }
    }

    public static class PersistenceUnit {
        private String name;
        private Boolean start;
        private Boolean autoScan;
        private Boolean inheritScanFilters;
        private List<Connection> connections=new ArrayList<>();
        private List<Connection> rootConnections=new ArrayList<>();
        private List<Property> properties=new ArrayList<>();
        private List<Scan> scans=new ArrayList<>();

        public String getName() {
            return name;
        }

        public PersistenceUnit setName(String name) {
            this.name = name;
            return this;
        }

        public Boolean getStart() {
            return start;
        }

        public PersistenceUnit setStart(Boolean start) {
            this.start = start;
            return this;
        }

        public Boolean getAutoScan() {
            return autoScan;
        }

        public PersistenceUnit setAutoScan(Boolean autoScan) {
            this.autoScan = autoScan;
            return this;
        }

        public Boolean getInheritScanFilters() {
            return inheritScanFilters;
        }

        public PersistenceUnit setInheritScanFilters(Boolean inheritScanFilters) {
            this.inheritScanFilters = inheritScanFilters;
            return this;
        }

        public List<Connection> getConnections() {
            return connections;
        }

        public PersistenceUnit setConnections(List<Connection> connections) {
            this.connections = connections;
            return this;
        }

        public List<Connection> getRootConnections() {
            return rootConnections;
        }

        public PersistenceUnit setRootConnections(List<Connection> rootConnections) {
            this.rootConnections = rootConnections;
            return this;
        }

        public List<Property> getProperties() {
            return properties;
        }

        public PersistenceUnit setProperties(List<Property> properties) {
            this.properties = properties;
            return this;
        }

        public List<Scan> getScans() {
            return scans;
        }

        public PersistenceUnit setScans(List<Scan> scans) {
            this.scans = scans;
            return this;
        }
    }

    public static class PersistenceGroup {
        private String name;
        private Boolean autoScan;
        private Boolean inheritScanFilters;
        private List<PersistenceUnit> persistenceUnits = new ArrayList<>();
        private List<Scan> scans = new ArrayList<>();
        private List<Property> properties = new ArrayList<>();

        public String getName() {
            return name;
        }

        public PersistenceGroup setName(String name) {
            this.name = name;
            return this;
        }

        public Boolean getAutoScan() {
            return autoScan;
        }

        public PersistenceGroup setAutoScan(Boolean autoScan) {
            this.autoScan = autoScan;
            return this;
        }

        public Boolean getInheritScanFilters() {
            return inheritScanFilters;
        }

        public PersistenceGroup setInheritScanFilters(Boolean inheritScanFilters) {
            this.inheritScanFilters = inheritScanFilters;
            return this;
        }

        public List<PersistenceUnit> getPersistenceUnits() {
            return persistenceUnits;
        }

        public PersistenceGroup setPersistenceUnits(List<PersistenceUnit> persistenceUnits) {
            this.persistenceUnits = persistenceUnits;
            return this;
        }

        public List<Scan> getScans() {
            return scans;
        }

        public PersistenceGroup setScans(List<Scan> scans) {
            this.scans = scans;
            return this;
        }

        public List<Property> getProperties() {
            return properties;
        }

        public PersistenceGroup setProperties(List<Property> properties) {
            this.properties = properties;
            return this;
        }
    }

    public static class Scan {
        private String types;
        private String libs;
        private Boolean propagate;

        public String getTypes() {
            return types;
        }

        public Scan setTypes(String types) {
            this.types = types;
            return this;
        }

        public String getLibs() {
            return libs;
        }

        public Scan setLibs(String libs) {
            this.libs = libs;
            return this;
        }

        public Boolean getPropagate() {
            return propagate;
        }

        public Scan setPropagate(Boolean propagate) {
            this.propagate = propagate;
            return this;
        }
    }

    public static class Property {
        private String name;
        private String type;
        private String format;
        private String value;

        public String getName() {
            return name;
        }

        public Property setName(String name) {
            this.name = name;
            return this;
        }

        public String getType() {
            return type;
        }

        public Property setType(String type) {
            this.type = type;
            return this;
        }

        public String getFormat() {
            return format;
        }

        public Property setFormat(String format) {
            this.format = format;
            return this;
        }

        public String getValue() {
            return value;
        }

        public Property setValue(String value) {
            this.value = value;
            return this;
        }
    }
}
