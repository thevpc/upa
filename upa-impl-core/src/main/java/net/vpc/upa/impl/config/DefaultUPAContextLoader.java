package net.vpc.upa.impl.config;

import net.vpc.upa.impl.xml.XmlDomNode;
import net.vpc.upa.impl.xml.XMLUtils;
import net.vpc.upa.impl.xml.XmlDomElement;
import net.vpc.upa.impl.xml.XmlAttrListFilter;
import net.vpc.upa.impl.xml.XmlDomText;
import net.vpc.upa.impl.XmlFactory;
import net.vpc.upa.impl.DefaultXmlFactory;
import net.vpc.upa.Property;
import net.vpc.upa.config.ScanFilter;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.exceptions.IllegalUPAArgumentException;
import net.vpc.upa.impl.util.*;
import net.vpc.upa.persistence.*;
import net.vpc.upa.types.I18NString;

import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;
import java.io.InputStream;
import java.net.URL;
import java.util.*;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 9/30/12 3:03 AM
 */
public class DefaultUPAContextLoader {

    protected static final Logger log = Logger.getLogger(DefaultUPAContextLoader.class.getName());
    static XmlAttrListFilter emptyElementFilter = new DefaultXmlAttrListFilter();
    //    private static XmlAttrListFilter includeElementFilter = new DefaultXmlAttrListFilter("url", "file", "resource", "ignoreonerror");
    static XmlAttrListFilter scanElementFilter = new DefaultXmlAttrListFilter("types", "libs", "propagate");
    static XmlAttrListFilter includeFilter = new DefaultXmlAttrListFilter("failSafe");
    static XmlAttrListFilter includeElementFilter = new DefaultXmlAttrListFilter("path", "failSafe");
    static XmlAttrListFilter persistenceUnitElementFilter = new DefaultXmlAttrListFilter("name", "start", "autoScan");
    static XmlAttrListFilter propertyElementFilter = new DefaultXmlAttrListFilter("valueType", "name", "value", "format");
    static XmlAttrListFilter persistenceGroupElementFilter = new DefaultXmlAttrListFilter("name", "autoScan");
    static XmlAttrListFilter connectionElementFilter = new DefaultXmlAttrListFilter("connectionString", "userName", "password", "structure", "enabled");
    private VarContext varContext;

    public DefaultUPAContextLoader(VarContext context) {
        this.varContext = context;
    }

    public UPAContextConfig parse() throws UPAException {
        ContextElement contextElement = new ContextElement();
        try {
            parseResource("META-INF/upa.xml", contextElement, varContext);
            return parseContextConfig(contextElement, varContext);
        } catch (UPAException e) {
            throw e;
        } catch (Exception e) {
            throw new UPAException(e, new I18NString("UPAContextLoaderFailed"));
        }
    }

    public UPAContextConfig parseContextConfig(ContextElement contextElement, VarContext varContext) {
        UPAContextConfig c = new UPAContextConfig();
        LinkedHashSet<ScanFilter> filters = new LinkedHashSet<ScanFilter>();
        for (ScanElement scanElement : contextElement.getScanElements()) {
            filters.add(new ScanFilter(scanElement.libs, scanElement.types, scanElement.propagate, UPAContextConfig.XML_ORDER));
        }
        if (filters.isEmpty() && contextElement.autoScan) {
            filters.add(new ScanFilter(null, null, true, UPAContextConfig.XML_ORDER));
        }
        c.setAutoScan(contextElement.autoScan);
        c.setFilters(new ArrayList<ScanFilter>(filters));
        c.setPersistenceGroups(new ArrayList<PersistenceGroupConfig>());
        for (PersistenceGroupElement e : contextElement.getPersistenceGroupElements()) {
            PersistenceGroupConfig gc = new PersistenceGroupConfig();
            gc.setConfigOrder(UPAContextConfig.XML_ORDER);
            gc.setName(e.name);
            gc.setAutoScan(e.autoScan);
            gc.setAutoScan(e.inheritScanFilters);

            filters = new LinkedHashSet<ScanFilter>();
            for (ScanElement scanElement : e.getScanElements()) {
                filters.add(new ScanFilter(scanElement.libs, scanElement.types, scanElement.propagate, UPAContextConfig.XML_ORDER));
            }
            gc.setScanFilters(new ArrayList<ScanFilter>(filters));
            Map<String, Object> parameters = gc.getProperties();
            if (parameters == null) {
                parameters = new HashMap<String, Object>();
            }
            for (Property property : e.properties) {
                parameters.put(property.getName(), UPAUtils.createValue(property));
            }
            c.setProperties(parameters);
            c.getPersistenceGroups().add(gc);
            for (PersistenceUnitElement pue : e.getPersistenceUnitElements()) {
                PersistenceUnitConfig pu = new PersistenceUnitConfig();
                pu.setName(pue.name);
                pu.setAutoStart(pue.start);
                pu.setAutoScan(pue.autoScan);
                pu.setInheritScanFilters(pue.inheritScanFilters);

                filters = new LinkedHashSet<ScanFilter>();
                for (ScanElement scanElement : pue.getScanElements()) {
                    filters.add(new ScanFilter(scanElement.libs, scanElement.types, scanElement.propagate, UPAContextConfig.XML_ORDER));
                }
                pu.setFilters(new ArrayList<ScanFilter>(filters));

                //pu.setModel(null);
                parameters = pu.getProperties();
                if (parameters == null) {
                    parameters = new HashMap<String, Object>();
                }
                for (Property property : pue.properties) {
                    parameters.put(property.getName(), UPAUtils.createValue(property));
                }
                pu.setPersistenceGroup(e.name);
                pu.setProperties(parameters);
                for (ConnectionElement ce : pue.connectionElements) {
                    ConnectionConfig cc = new ConnectionConfig();
                    cc.setConnectionString(ce.connectionString);
                    cc.setUserName(ce.userName);
                    cc.setPassword(ce.password);
                    cc.setStructureStrategy(StringUtils.isNullOrEmpty(ce.structure) ? PlatformUtils.getUndefinedValue(StructureStrategy.class) : StructureStrategy.valueOf(ce.structure.toUpperCase()));
                    cc.setProperties(new LinkedHashMap<String, String>());
                    for (Map.Entry<String, String> x : ce.properties.entrySet()) {
                        cc.getProperties().put(x.getKey(), x.getValue());
                    }
                    pu.getConnections().add(cc);
                }
                for (ConnectionElement ce : pue.rootConnectionElements) {
                    ConnectionConfig cc = new ConnectionConfig();
                    cc.setConnectionString(ce.connectionString);
                    cc.setUserName(ce.userName);
                    cc.setPassword(ce.password);
                    cc.setStructureStrategy(StringUtils.isNullOrEmpty(ce.structure) ? PlatformUtils.getUndefinedValue(StructureStrategy.class) : StructureStrategy.valueOf(ce.structure.toUpperCase()));
                    cc.setProperties(new LinkedHashMap<String, String>());
                    for (Map.Entry<String, String> x : ce.properties.entrySet()) {
                        cc.getProperties().put(x.getKey(), x.getValue());
                    }
                    pu.getRootConnections().add(cc);
                }
                gc.getPersistenceUnits().add(pu);
            }

        }
        return c;

//        List<PersistenceUnitConfig> all = new ArrayList<PersistenceUnitConfig>();
//        for (PersistenceGroupElement persistenceGroupElement : persistenceGroups.values()) {
//            for (PersistenceUnitElement persistenceUnitElement : persistenceGroupElement.getPersistenceUnitElements()) {
//                PersistenceUnitConfig c = new PersistenceUnitConfig();
//                c.setName(persistenceUnitElement.name);
//                c.setPersistenceGroup(persistenceGroupElement.name);
//                c.setAutoStart(persistenceUnitElement.start);
//                for (Map.Entry<String, String> entry : persistenceUnitElement.properties.entrySet()) {
//                    c.getProperties().put(entry.getKey(), entry.getValue());
//                }
//                for (int i = 0; i < persistenceUnitElement.connectionElements.size(); i++) {
//                    ConnectionElement connectionElement = persistenceUnitElement.connectionElements.get(i);
//                    if (connectionElement != null) {
//                        String cnxPrefix = UPA.CONNECTION_STRING + (i == 0 ? "" : "[" + (i - 1) + "]");
//                        if (connectionElement.connectionString != null) {
//                            c.getProperties().put(cnxPrefix, connectionElement.connectionString);
//                        }
//                        if (connectionElement.userName != null) {
//                            c.getProperties().put(cnxPrefix + ".userName", connectionElement.userName);
//                        }
//                        if (connectionElement.password != null) {
//                            c.getProperties().put(cnxPrefix + ".password", connectionElement.password);
//                        }
//                        if (connectionElement.structure != null) {
//                            c.getProperties().put(cnxPrefix + ".structure", connectionElement.structure);
//                        }
//                        for (Map.Entry<String, String> ee : connectionElement.properties.entrySet()) {
//                            c.getProperties().put(cnxPrefix + "." + ee.getKey(), ee.getValue());
//                        }
//                    }
//                }
//                for (int i = 0; i < persistenceUnitElement.rootConnectionElements.size(); i++) {
//                    ConnectionElement connectionElement = persistenceUnitElement.rootConnectionElements.get(i);
//                    if (connectionElement != null) {
//                        String cnxPrefix = UPA.ROOT_CONNECTION_STRING + (i == 0 ? "" : "[" + (i - 1) + "]");
//                        if (connectionElement.connectionString != null) {
//                            c.getProperties().put(cnxPrefix, connectionElement.connectionString);
//                        }
//                        if (connectionElement.userName != null) {
//                            c.getProperties().put(cnxPrefix + ".userName", connectionElement.userName);
//                        }
//                        if (connectionElement.userName != null) {
//                            c.getProperties().put(cnxPrefix + ".password", connectionElement.password);
//                        }
//                        for (Map.Entry<String, String> ee : connectionElement.properties.entrySet()) {
//                            c.getProperties().put(cnxPrefix + "." + ee.getKey(), ee.getValue());
//                        }
//                    }
//                }
//                all.add(c);
//            }
//        }
//        return all;
    }

    public boolean parseResource(String resource, ContextElement context, VarContext varContext) throws UPAException, IOException {

        boolean someInclusion = false;
        for (URL url : PlatformUtils.listURLs(resource)) {
            someInclusion |= parseURL(url, context, varContext);
        }
        return someInclusion;
    }

    public boolean parseURL(URL url, ContextElement contextElement, VarContext varContext) throws UPAException, IOException {
        log.log(Level.FINE, "Parsing upa.xml URL at {0}", url);
        InputStream is = url.openStream();
        boolean someInclusion = false;
        try {
            someInclusion = parseStream(is, contextElement, varContext);
        } finally {
            if (is != null) {
                is.close();
            }
        }
        return someInclusion;
    }

    private boolean parseStream(InputStream is, ContextElement contextElement, VarContext varContext) throws UPAException, IOException {
        boolean someContent = false;
        if (is == null) {
            return false;
        }

        //no factory yet!!
        if (is != null) {
            XmlFactory factory = new DefaultXmlFactory();
            XmlDomElement node = factory.parse(is);
            someContent = parseDocElement(node, contextElement, varContext);
        }
        return someContent;
    }

    private boolean parseDocElement(XmlDomElement docEle, ContextElement contextElement, VarContext varContext) throws UPAException, IOException {
        boolean someContent = false;
        /**
         * @PortabilityHint(target = "C#",name = "ignore")
         */
        {
            for (XmlDomNode item : docEle.getChildren()) {
                if (item instanceof XmlDomElement) {
                    XmlDomElement el = (XmlDomElement) item;
                    String tagName = el.getName();
                    if (XMLUtils.equalsUniform(tagName, "include")) {
                        someContent |= parseInclude(el, contextElement, varContext);
                    } else if (XMLUtils.equalsUniform(tagName, "persistenceGroup")) {
                        someContent = true;
                        parsePersistenceGroup(el, contextElement, varContext);
                    } else if (XMLUtils.equalsUniform(tagName, "persistenceUnit")) {
                        someContent = true;
                        PersistenceGroupElement pg = contextElement.getOrAddPersistenceGroupElement("");
                        parsePersistenceUnit(el, pg, varContext);
                    } else if (XMLUtils.equalsUniform(tagName, "scan")) {
                        someContent = true;
                        contextElement.addScanElement(parseScan(el, varContext));
                    } else if (XMLUtils.equalsUniform(tagName, "connection")) {
                        someContent = true;
                        PersistenceGroupElement pg = contextElement.getOrAddPersistenceGroupElement("");
                        PersistenceUnitElement pu = pg.getOrAddPersistenceUnitElement("");
                        pu.connectionElements.add(parseConnection(el, varContext));
                    } else if (XMLUtils.equalsUniform(tagName, "connectionString")) {
                        someContent = true;
                        PersistenceGroupElement pg = contextElement.getOrAddPersistenceGroupElement("");
                        PersistenceUnitElement pu = pg.getOrAddPersistenceUnitElement("");
                        ConnectionElement c = new ConnectionElement();
                        final Map<String, String> attrs = XMLUtils.getAttributes(el, connectionElementFilter);
                        c.connectionString = trimToNull(parseXmlTextContent(el));
                        pu.connectionElements.add(c);
                    } else if (XMLUtils.equalsUniform(tagName, "rootconnectionString")) {
                        someContent = true;
                        PersistenceGroupElement pg = contextElement.getOrAddPersistenceGroupElement("");
                        PersistenceUnitElement pu = pg.getOrAddPersistenceUnitElement("");
                        ConnectionElement c = new ConnectionElement();
                        final Map<String, String> attrs = XMLUtils.getAttributes(el, connectionElementFilter);
                        c.connectionString = trimToNull(parseXmlTextContent(el));
                        pu.rootConnectionElements.add(c);
                    } else if (XMLUtils.equalsUniform(tagName, "rootConnection")) {
                        someContent = true;
                        PersistenceGroupElement pg = contextElement.getOrAddPersistenceGroupElement("");
                        PersistenceUnitElement pu = pg.getOrAddPersistenceUnitElement("");
                        pu.rootConnectionElements.add(parseConnection(el, varContext));
                    } else if (XMLUtils.equalsUniform(tagName, "property")) {
                        someContent = true;
                        PersistenceGroupElement pg = contextElement.getOrAddPersistenceGroupElement("");
                        Property p = parseProperty(el, varContext);
                        Object t = UPAUtils.createValue(p);
                        String svalue = t == null ? null : String.valueOf(t);
                        varContext.declare(p.getName(), svalue);
                        pg.properties.add(p);
                    } else {
                        throw new IllegalUPAArgumentException("Unsupported tag " + tagName + " for " + docEle.getName() + ". valid tags are "
                                + "include, persistenceGroup, persistenceUnit, "
                                + "scan, connection, rootConnection, property");
                    }
                }
            }

        }
        return someContent;
    }

    private String nullify(String s) {
        if (s == null) {
            return s;
        }
        s = s.trim();
        if (s.length() == 0) {
            return null;
        }
        return s;
    }

    private boolean parseInclude(XmlDomElement docEle, ContextElement contextElement, VarContext varContext) throws UPAException, IOException {
        List<XmlDomNode> nl = docEle.getChildren();
        boolean someContent = false;
        Map<String, String> attrs0 = XMLUtils.getAttributes(docEle, includeFilter);
        boolean failSafe0 = parseBoolean(attrs0.get(XMLUtils.uniformName("failSafe")), true, varContext);
        boolean defaultVisited = false;

        for (XmlDomNode item : nl) {
            if (item instanceof XmlDomElement) {
                XmlDomElement el = (XmlDomElement) item;
                String tagName = el.getName();
                if (defaultVisited) {
                    throw new IllegalUPAArgumentException("XmlParseError.DefaultTagMustBeLast");
                }
                if (XMLUtils.equalsUniform(tagName, "url")) {
                    Map<String, String> attrs = XMLUtils.getAttributes(el, includeElementFilter);
                    String value = nullify(varContext.eval(attrs.get(XMLUtils.uniformName("path"))));
                    boolean failSafe = parseBoolean(attrs.get(XMLUtils.uniformName("failSafe")), true, varContext);
                    boolean skipOthers = parseBoolean(attrs.get(XMLUtils.uniformName("skipOthers")), true, varContext);
                    Exception error = null;
                    if (StringUtils.isNullOrEmpty(value)) {
                        error = new IllegalUPAArgumentException("XmlParseError.EmptyURL");
                    } else {
                        try {
                            URL url = new URL(value);
                            someContent |= parseURL(url, contextElement, varContext);
                        } catch (Exception ex) {
                            error = ex;
                        }
                    }
                    if (error != null) {
                        if (failSafe) {
                            log.log(Level.WARNING, "Unable to include URL {0}", value);
                        } else {
                            log.log(Level.SEVERE, "Unable to include URL " + value, error);
                            throw new IllegalUPAArgumentException("XmlParseError.InvalidInclude", value);
                        }
                    } else {
                        if (skipOthers) {
                            break;
                        }
                    }
                } else if (XMLUtils.equalsUniform(tagName, "file")) {
                    Map<String, String> attrs = XMLUtils.getAttributes(el, includeElementFilter);
                    String value = nullify(varContext.eval(attrs.get(XMLUtils.uniformName("path"))));
                    boolean failSafe = parseBoolean(attrs.get(XMLUtils.uniformName("failSafe")), false, varContext);
                    boolean skipOthers = parseBoolean(attrs.get(XMLUtils.uniformName("skipOthers")), true, varContext);
                    Exception error = null;
                    if (StringUtils.isNullOrEmpty(value)) {
                        error = new IllegalUPAArgumentException("XmlParseError.EmptyFile");
                    }
                    File fileObj = IOUtils.createFile(value.trim());
                    if (!fileObj.isFile() || !fileObj.exists()) {
                        error = new IllegalUPAArgumentException("XmlParseError.FileDoesNotExist", value);
                    } else {
                        FileInputStream is = null;
                        try {
                            try {
                                is = new FileInputStream(fileObj);
                                someContent |= parseStream(is, contextElement, varContext);
                            } finally {
                                if (is != null) {
                                    is.close();
                                }
                            }
                        } catch (Exception ex) {
                            error = ex;
                        }
                    }

                    if (error != null) {
                        if (failSafe) {
                            log.log(Level.WARNING, "Unable to include File {0}", value);
                        } else {
                            log.log(Level.SEVERE, "Unable to include File " + value, error);
                            throw new IllegalUPAArgumentException("XmlParseError.InvalidInclude", value);
                        }
                    } else {
                        if (skipOthers) {
                            break;
                        }
                    }
                } else if (XMLUtils.equalsUniform(tagName, "resource")) {
                    Map<String, String> attrs = XMLUtils.getAttributes(el, includeElementFilter);
                    String value = nullify(varContext.eval(attrs.get(XMLUtils.uniformName("path"))));
                    boolean failSafe = parseBoolean(attrs.get(XMLUtils.uniformName("failSafe")), false, varContext);
                    boolean skipOthers = parseBoolean(attrs.get(XMLUtils.uniformName("skipOthers")), true, varContext);
                    Exception error = null;
                    if (StringUtils.isNullOrEmpty(value)) {
                        error = new IllegalUPAArgumentException("XmlParseError.EmptyResource", value);
                    } else {
                        try {
                            someContent |= parseURL(new URL(value), contextElement, varContext);
                        } catch (Exception ex) {
                            error = ex;
                        }
                    }

                    if (error != null) {
                        if (failSafe) {
                            log.log(Level.WARNING, "Unable to include Resource {0}", value);
                        } else {
                            log.log(Level.SEVERE, "Unable to include Resource " + value, error);
                            throw new IllegalUPAArgumentException("XmlParseError.InvalidInclude", value);
                        }
                    } else {
                        if (skipOthers) {
                            break;
                        }
                    }
                } else if (XMLUtils.equalsUniform(tagName, "default")) {
                    if (!someContent) {
                        someContent |= parseDocElement(el, contextElement, varContext);
                    }
                    defaultVisited = true;
                } else {
                    log.log(Level.SEVERE, "Unsupported tag " + tagName + " for " + docEle.getName() + ". valid tags are "
                            + "file, url, resource, default");
                    throw new IllegalUPAArgumentException("XmlParseError.UnsupportedTag", tagName, docEle.getName());
                }
            }
        }

        if (!someContent) {
            if (!failSafe0) {
                log.log(Level.SEVERE, "Unable to include elements");
                throw new UPAException("InvalidInclude");
            } else {
                log.log(Level.WARNING, "Nothing to include");
            }
        }

        return someContent;
    }

    private PersistenceGroupElement parsePersistenceGroup(XmlDomElement e, ContextElement context, VarContext varContext) {
        VarContext gvarContext = new DefaultVarContext(varContext);
        Map<String, String> attrs = XMLUtils.getAttributes(e, persistenceGroupElementFilter);
        String name = nullify(attrs.get(XMLUtils.uniformName("name")));
        PersistenceGroupElement c = context.getOrAddPersistenceGroupElement(name);
        c.autoScan = parseBoolean(attrs.get(XMLUtils.uniformName("autoScan")), c.autoScan, gvarContext);
        c.inheritScanFilters = parseBoolean(attrs.get(XMLUtils.uniformName("inheritScanFilters")), c.autoScan, gvarContext);
        List<XmlDomNode> nl = e.getChildren();
        for (XmlDomNode item : nl) {
            if (item instanceof XmlDomElement) {
                XmlDomElement el = (XmlDomElement) item;
                String tagName = el.getName();
                if (XMLUtils.equalsUniform(tagName, "persistenceUnit")) {
                    parsePersistenceUnit(el, c, varContext);
                } else if (XMLUtils.equalsUniform(tagName, "scan")) {
                    c.addScanElement(parseScan(el, gvarContext));
                } else if (XMLUtils.equalsUniform(tagName, "property")) {
                    Property p = parseProperty(el, gvarContext);
                    Object t = UPAUtils.createValue(p);
                    String svalue = t == null ? null : String.valueOf(t);
                    gvarContext.declare(p.getName(), svalue);
                    c.properties.add(p);
                } else {
                    throw new IllegalUPAArgumentException("Unsupported tag " + tagName + " for PersistenceGroup. "
                            + "valid tags are persistenceUnit, scan, property");
                }
            }
        }
        return c;
    }

    private boolean parseBoolean(String v, boolean defaultValue, VarContext varContext) {
        v = nullify(varContext.eval(v));
        if (v != null) {
            return Boolean.parseBoolean(v);
        }
        return defaultValue;
    }

    private ScanElement parseScan(XmlDomElement e, VarContext varContext) {
        ScanElement c = new ScanElement();
        Map<String, String> attrs = XMLUtils.getAttributes(e, scanElementFilter);
        c.types = nullify(varContext.eval(attrs.get(XMLUtils.uniformName("types"))));
        c.libs = nullify(varContext.eval(attrs.get(XMLUtils.uniformName("libs"))));
        c.propagate = parseBoolean(attrs.get(XMLUtils.uniformName("propagate")), true, varContext);
        return c;
    }

    private PersistenceUnitElement parsePersistenceUnit(XmlDomElement e, PersistenceGroupElement persistenceGroupElement, VarContext varContext) {
        VarContext uvarContext = new DefaultVarContext(varContext);
        Map<String, String> attrs = XMLUtils.getAttributes(e, persistenceUnitElementFilter);
        String name = nullify(attrs.get(XMLUtils.uniformName("name")));
        PersistenceUnitElement s = persistenceGroupElement.getOrAddPersistenceUnitElement(name);
        s.start = parseBoolean(attrs.get(XMLUtils.uniformName("start")), s.start, uvarContext);
        s.autoScan = parseBoolean(attrs.get(XMLUtils.uniformName("autoScan")), s.autoScan, uvarContext);
        s.inheritScanFilters = parseBoolean(attrs.get(XMLUtils.uniformName("inheritScanFilters")), s.inheritScanFilters, uvarContext);

        List<XmlDomNode> nl = e.getChildren();
        for (XmlDomNode item : nl) {

            if (item instanceof XmlDomElement) {
                XmlDomElement el = (XmlDomElement) item;
                //add it to list
                String tagName = el.getName();
                if (XMLUtils.equalsUniform(tagName, "connection")) {
                    s.connectionElements.add(parseConnection(el, uvarContext));
                } else if (XMLUtils.equalsUniform(tagName, "rootConnection")) {
                    s.rootConnectionElements.add(parseConnection(el, uvarContext));
                } else if (XMLUtils.equalsUniform(tagName, "connectionString")) {
                    ConnectionElement c = new ConnectionElement();
                    final Map<String, String> attrs2 = XMLUtils.getAttributes(el, connectionElementFilter);
                    c.connectionString = trimToNull(attrs2.get("connectionString"));
                    s.connectionElements.add(parseConnection(el, uvarContext));
                } else if (XMLUtils.equalsUniform(tagName, "rootConnectionString")) {
                    s.rootConnectionElements.add(parseConnection(el, uvarContext));
                } else if (XMLUtils.equalsUniform(tagName, "property")) {
                    Property p = parseProperty(el, uvarContext);
                    Object t = UPAUtils.createValue(p);
                    String svalue = t == null ? null : String.valueOf(t);
                    uvarContext.declare(p.getName(), svalue);
                    s.properties.add(p);
                } else if (XMLUtils.equalsUniform(tagName, "scan")) {
                    s.scanElements.add(parseScan(el, uvarContext));
                } else {
                    throw new IllegalUPAArgumentException("Unsupported tag " + tagName + " for PersistenceUnit. "
                            + "valid tags are connection, rootConnection, property, scan");
                }
            } else {
//                    System.out.println(item);
            }
        }

        return s;
    }

    private String parseXmlTextContent(XmlDomElement e) {
        List<XmlDomNode> children = e.getChildren();
        if (children.size() > 0) {
            XmlDomNode n = children.get(0);
            if (n instanceof XmlDomText) {
                return ((XmlDomText) n).getText();
            }
        }
        return null;
    }

    private Property parseProperty(XmlDomElement e, VarContext varContext) {
        Map<String, String> attrs = XMLUtils.getAttributes(e, propertyElementFilter);
        String name = varContext.eval(attrs.get(XMLUtils.uniformName("name")));
        String className = varContext.eval(attrs.get(XMLUtils.uniformName("type")));
        String format = varContext.eval(attrs.get(XMLUtils.uniformName("format")));
        String value = varContext.eval(attrs.get(XMLUtils.uniformName("value")));
        String value2 = parseXmlTextContent(e);
        if (value == null) {
            value = value2;
        } else if (value2 != null) {
            value = value2;
            log.severe("Both attribute 'value' and content value are defined for property " + name + " . attribute will be ignored.");
        }
        return (new Property(name, value, className, format));
    }

    private ConnectionElement parseConnection(XmlDomElement e, VarContext varContext) {
        VarContext varContext2 = new DefaultVarContext(varContext);
        ConnectionElement s = new ConnectionElement();
        final Map<String, String> attrs = XMLUtils.getAttributes(e, connectionElementFilter);
        s.connectionString = trimToNull(attrs.get(XMLUtils.uniformName("connectionString")));
        s.userName = trimToNull(attrs.get(XMLUtils.uniformName("username")));
        s.password = trimToNull(attrs.get(XMLUtils.uniformName("password")));
        s.structure = trimToNull(attrs.get(XMLUtils.uniformName("structure")));
        if (attrs.containsKey(XMLUtils.uniformName("enabled"))) {
            s.properties.put("enabled", trimToNull(attrs.get(XMLUtils.uniformName("enabled"))));
        }
        List<XmlDomNode> nl = e.getChildren();

        for (XmlDomNode item : nl) {

            if (item instanceof XmlDomElement) {
                XmlDomElement el = (XmlDomElement) item;
                //add it to list
                String tagName = el.getName();
                if (XMLUtils.equalsUniform(tagName, "connectionString")) {
                    s.connectionString = trimToNull(parseXmlTextContent(el));
                } else if (XMLUtils.equalsUniform(tagName, "userName")) {
                    s.userName = trimToNull(parseXmlTextContent(el));
                } else if (XMLUtils.equalsUniform(tagName, "password")) {
                    s.password = trimToNull(parseXmlTextContent(el));
                } else if (XMLUtils.equalsUniform(tagName, "structure")) {
                    s.structure = trimToNull(parseXmlTextContent(el));
                } else if (XMLUtils.equalsUniform(tagName, "enabled")) {
                    s.properties.put(tagName, trimToNull(parseXmlTextContent(el)));
                } else if (XMLUtils.equalsUniform(tagName, "property")) {
                    Property p = parseProperty(el, varContext2);
                    Object t = UPAUtils.createValue(p);
                    String svalue = t == null ? null : String.valueOf(t);
                    varContext2.declare(p.getName(), svalue);
                    s.properties.put(p.getName(), svalue);
                } else {
                    throw new IllegalUPAArgumentException("Unsupported tag " + tagName + " for Connection and RootConnection. "
                            + "valid tags are connectionString, userName, password, "
                            + "structure, enabled, property");
                }
            } else {
//                    System.out.println(item);
            }
        }

        return s;
    }

    private String trimToNull(String s) {
        if (s != null) {
            s = s.trim();
            if (s.isEmpty()) {
                return null;
            }
        }
        return s;
    }

}
