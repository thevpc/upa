package net.vpc.upa.impl.config;

import net.vpc.upa.impl.util.*;
import net.vpc.upa.types.I18NString;
import net.vpc.upa.*;
import net.vpc.upa.exceptions.UPAException;
import org.w3c.dom.Document;
import org.w3c.dom.Element;
import org.w3c.dom.Node;
import org.w3c.dom.NodeList;
import org.xml.sax.SAXException;

import javax.xml.parsers.DocumentBuilder;
import javax.xml.parsers.DocumentBuilderFactory;
import javax.xml.parsers.ParserConfigurationException;
import java.io.File;
import java.io.IOException;
import java.net.URL;
import java.util.*;
import java.util.logging.Level;
import java.util.logging.Logger;
import net.vpc.upa.config.ScanFilter;
import net.vpc.upa.persistence.ConnectionConfig;
import net.vpc.upa.persistence.PersistenceGroupConfig;
import net.vpc.upa.persistence.PersistenceUnitConfig;
import net.vpc.upa.persistence.StructureStrategy;
import net.vpc.upa.persistence.UPAContextConfig;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 9/30/12 3:03 AM
 */
public class DefaultUPAContextLoader {

    protected static final Logger log = Logger.getLogger(DefaultUPAContextLoader.class.getName());
    private static XmlAttrListFilter includeElementFilter = new DefaultXmlAttrListFilter("url", "file", "resource");
    private static XmlAttrListFilter scanElementFilter = new DefaultXmlAttrListFilter("types", "libs");
    private static XmlAttrListFilter persistenceUnitElementFilter = new DefaultXmlAttrListFilter("name", "start", "autoscan");
    private static XmlAttrListFilter propertyElementFilter = new DefaultXmlAttrListFilter("type", "name", "value", "format");
    private static XmlAttrListFilter persistenceGroupElementFilter = new DefaultXmlAttrListFilter("name", "autoscan");
    private static XmlAttrListFilter connectionElementFilter = new DefaultXmlAttrListFilter("connectionstring", "username", "password", "structure", "enabled");


    public UPAContextConfig parse() throws UPAException {
        log.log(Level.FINE, "Loading UPAContext");
        ContextElement contextElement = new ContextElement();
        try {
            parseResource("META-INF/upa.xml", contextElement);
            return parseContextConfig(contextElement);
        } catch (UPAException e) {
            throw e;
        } catch (Exception e) {
            throw new UPAException(e, new I18NString("UPAContextLoaderFailed"));
        }
    }

    public UPAContextConfig parseContextConfig(ContextElement contextElement) {
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
            PersistenceGroupConfig gc = new PersistenceGroupConfig(UPAContextConfig.XML_ORDER);
            gc.setName(e.name);
            gc.setAutoScan(e.autoScan);

            filters = new LinkedHashSet<ScanFilter>();
            for (ScanElement scanElement : e.getScanElements()) {
                filters.add(new ScanFilter(scanElement.libs, scanElement.types, scanElement.propagate, UPAContextConfig.XML_ORDER));
            }
            gc.setContextAnnotationStrategyFilters(new ArrayList<ScanFilter>(filters));
            Map<String, Object> parameters = gc.getProperties();
            if (parameters == null) {
                parameters = new HashMap<String, Object>();
            }
            for (Property property : e.properties) {
                parameters.put(property.getName(), UPAUtils.createValue(property));
            }
            c.getPersistenceGroups().add(gc);
            for (PersistenceUnitElement pue : e.getPersistenceUnitElements()) {
                PersistenceUnitConfig pu = new PersistenceUnitConfig();
                pu.setName(pue.name);
                pu.setAutoStart(pue.start);
                pu.setAutoScan(pue.autoScan);

                filters = new LinkedHashSet<ScanFilter>();
                for (ScanElement scanElement : pue.getScanElements()) {
                    filters.add(new ScanFilter(scanElement.libs, scanElement.types, scanElement.propagate, UPAContextConfig.XML_ORDER));
                }
                pu.setContextAnnotationStrategyFilters(new ArrayList<ScanFilter>(filters));

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
                    cc.setStructureStrategy(Strings.isNullOrEmpty(ce.structure) ? PlatformUtils.getUndefinedValue(StructureStrategy.class) : StructureStrategy.valueOf(ce.structure.toUpperCase()));
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
                    cc.setStructureStrategy(Strings.isNullOrEmpty(ce.structure) ? PlatformUtils.getUndefinedValue(StructureStrategy.class) : StructureStrategy.valueOf(ce.structure.toUpperCase()));
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

    private void parseResource(String resource, ContextElement context) throws UPAException, SAXException, IOException, ParserConfigurationException {

        /**@PortabilityHint(target = "C#",name = "ignore")*/
        {
            Enumeration<URL> upaXmls = Thread.currentThread().getContextClassLoader().getResources(resource);

            while (upaXmls.hasMoreElements()) {
                URL url = upaXmls.nextElement();
                parseURL(url, context);
            }
        }
    }

    private void parseURL(URL url, ContextElement contextElement) throws UPAException, SAXException, IOException, ParserConfigurationException {
        log.log(Level.FINE, "Loading Context URL {0}", url);

        /**@PortabilityHint(target = "C#",name = "ignore")*/
        {
            DocumentBuilderFactory dbf = DocumentBuilderFactory.newInstance();

            //Using factory get an instance of document builder
            DocumentBuilder db = dbf.newDocumentBuilder();

            //parse using builder to get DOM representation of the XML file
            Document dom = db.parse(url.openStream());
            Element docEle = dom.getDocumentElement();

            NodeList nl = docEle.getChildNodes();
            if (nl != null && nl.getLength() > 0) {
                for (int i = 0; i < nl.getLength(); i++) {
                    Node item = nl.item(i);
                    if (item instanceof Element) {
                        Element el = (Element) item;
                        String tagName = el.getTagName();
                        if (XMLUtils.equalsUniform(tagName, "include")) {
                            parseInclude(el, contextElement, url);
                        } else if (XMLUtils.equalsUniform(tagName, "persistenceGroup")) {
                            parsePersistenceGroup(el, contextElement);
                        } else if (XMLUtils.equalsUniform(tagName, "persistenceUnit")) {
                            PersistenceGroupElement pg = contextElement.getOrAddPersistenceGroupElement("");
                            parsePersistenceUnit(el, pg);
                        } else if (XMLUtils.equalsUniform(tagName, "scan")) {
                            contextElement.addScanElement(parseScan(el));
                        } else if (XMLUtils.equalsUniform(tagName, "connection")) {
                            PersistenceGroupElement pg = contextElement.getOrAddPersistenceGroupElement("");
                            PersistenceUnitElement pu = pg.getOrAddPersistenceUnitElement("");
                            pu.connectionElements.add(parseConnection(el));
                        } else if (XMLUtils.equalsUniform(tagName, "rootConnection")) {
                            PersistenceGroupElement pg = contextElement.getOrAddPersistenceGroupElement("");
                            PersistenceUnitElement pu = pg.getOrAddPersistenceUnitElement("");
                            pu.rootConnectionElements.add(parseConnection(el));
                        } else if (XMLUtils.equalsUniform(tagName, "property")) {
                            PersistenceGroupElement pg = contextElement.getOrAddPersistenceGroupElement("");
                            pg.properties.add(parseProperty(el));
                        } else {
                            throw new IllegalArgumentException("Unsupported tag " + tagName + " for " + docEle.getTagName() + ". valid tags are "
                                    + "include, persistenceGroup, persistenceUnit, "
                                    + "scan, connection, rootConnection, property");
                        }
                    }
                }
            }
        }
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

    private void parseInclude(Element e, ContextElement contextElement, URL url) throws UPAException, SAXException, IOException, ParserConfigurationException {
        Map<String, String> attrs = XMLUtils.getAttributes(e, includeElementFilter);
        String urlString = nullify(attrs.get("url"));
        if (urlString != null) {
            parseURL(url, contextElement);
        }
        String file = nullify(attrs.get("file"));
        if (file != null) {
            parseURL(new File(file).toURI().toURL(), contextElement);
        }
        String resource = nullify(attrs.get("resource"));
        if (resource != null) {
            parseResource(resource, contextElement);
        }
    }


    private PersistenceGroupElement parsePersistenceGroup(Element e, ContextElement context) {
        Map<String, String> attrs = XMLUtils.getAttributes(e, persistenceGroupElementFilter);
        String name = nullify(attrs.get("name"));
        PersistenceGroupElement c = context.getOrAddPersistenceGroupElement(name);
        c.autoScan = parseBoolean(attrs.get("autoscan"), c.autoScan);
        NodeList nl = e.getChildNodes();
        if (nl != null && nl.getLength() > 0) {
            for (int i = 0; i < nl.getLength(); i++) {
                Node item = nl.item(i);
                if (item instanceof Element) {
                    Element el = (Element) item;
                    String tagName = el.getTagName();
                    if (XMLUtils.equalsUniform(tagName, "persistenceUnit")) {
                        parsePersistenceUnit(el, c);
                    } else if (XMLUtils.equalsUniform(tagName, "scan")) {
                        c.addScanElement(parseScan(el));
                    } else if (XMLUtils.equalsUniform(tagName, "property")) {
                        c.properties.add(parseProperty(el));
                    } else {
                        throw new IllegalArgumentException("Unsupported tag " + tagName + " for PersistenceGroup. "
                                + "valid tags are persistenceUnit, scan, property");
                    }
                }
            }
        }
        return c;
    }

    private boolean parseBoolean(String v, boolean defaultValue) {
        v = nullify(v);
        if (v != null) {
            return Boolean.parseBoolean(v);
        }
        return defaultValue;
    }

    private ScanElement parseScan(Element e) {
        ScanElement c = new ScanElement();
        Map<String, String> attrs = XMLUtils.getAttributes(e, scanElementFilter);
        c.types = nullify(attrs.get("types"));
        c.libs = nullify(attrs.get("libs"));
        c.propagate = parseBoolean(attrs.get("propagate"), true);
        return c;
    }

    private PersistenceUnitElement parsePersistenceUnit(Element e, PersistenceGroupElement persistenceGroupElement) {
        Map<String, String> attrs = XMLUtils.getAttributes(e, persistenceUnitElementFilter);
        String name = nullify(attrs.get("name"));
        PersistenceUnitElement s = persistenceGroupElement.getOrAddPersistenceUnitElement(name);
        s.start = parseBoolean(attrs.get("start"), s.start);
        s.autoScan = parseBoolean(attrs.get("autoScan"), s.autoScan);

        NodeList nl = e.getChildNodes();
        if (nl != null && nl.getLength() > 0) {
            for (int i = 0; i < nl.getLength(); i++) {

                Node item = nl.item(i);
                if (item instanceof Element) {
                    Element el = (Element) item;
                    //add it to list
                    String tagName = el.getTagName();
                    if (XMLUtils.equalsUniform(tagName, "connection")) {
                        s.connectionElements.add(parseConnection(el));
                    } else if (XMLUtils.equalsUniform(tagName, "rootConnection")) {
                        s.rootConnectionElements.add(parseConnection(el));
                    } else if (XMLUtils.equalsUniform(tagName, "property")) {
                        s.properties.add(parseProperty(el));
                    } else if (XMLUtils.equalsUniform(tagName, "scan")) {
                        s.scanElements.add(parseScan(el));
                    } else {
                        throw new IllegalArgumentException("Unsupported tag " + tagName + " for PersistenceUnit. "
                                + "valid tags are connection, rootConnection, property, scan");
                    }
                } else {
//                    System.out.println(item);
                }
            }
        }
        return s;
    }

    private Property parseProperty(Element e) {
        Map<String, String> attrs = XMLUtils.getAttributes(e, propertyElementFilter);
        String name = attrs.get("name");
        String className = attrs.get("type");
        String format = attrs.get("format");
        String value = attrs.get("value");
        String value2 = e.getFirstChild() != null ? e.getFirstChild().getNodeValue() : null;
        if (value == null) {
            value = value2;
        }
        return (new Property(name, value, className, format));
    }

    private ConnectionElement parseConnection(Element e) {
        ConnectionElement s = new ConnectionElement();
        final Map<String, String> attrs = XMLUtils.getAttributes(e, connectionElementFilter);
        s.connectionString = trimToNull(attrs.get("connectionstring"));
        s.userName = trimToNull(attrs.get("username"));
        s.password = trimToNull(attrs.get("password"));
        s.structure = trimToNull(attrs.get("structure"));
        if (attrs.containsKey("enabled")) {
            s.properties.put("enabled", trimToNull(attrs.get("enabled")));
        }
        NodeList nl = e.getChildNodes();
        if (nl != null && nl.getLength() > 0) {
            for (int i = 0; i < nl.getLength(); i++) {

                Node item = nl.item(i);
                if (item instanceof Element) {
                    Element el = (Element) item;
                    //add it to list
                    String tagName = el.getTagName();
                    if (XMLUtils.equalsUniform(tagName,"connectionString")) {
                        s.connectionString = trimToNull(el.getFirstChild().getNodeValue());
                    } else if (XMLUtils.equalsUniform(tagName,"userName")) {
                        s.userName = trimToNull(el.getFirstChild().getNodeValue());
                    } else if (XMLUtils.equalsUniform(tagName,"password")) {
                        s.password = trimToNull(el.getFirstChild().getNodeValue());
                    } else if (XMLUtils.equalsUniform(tagName,"structure")) {
                        s.structure = trimToNull(el.getFirstChild().getNodeValue());
                    } else if (XMLUtils.equalsUniform(tagName,"enabled")) {
                        s.properties.put(tagName, trimToNull(el.getFirstChild().getNodeValue()));
                    } else if (XMLUtils.equalsUniform(tagName,"property")) {
                        Property p = parseProperty(el);
                        Object t = UPAUtils.createValue(p);
                        s.properties.put(p.getName(), t == null ? null : String.valueOf(t));
                    } else {
                        throw new IllegalArgumentException("Unsupported tag " + tagName + " for Connection and RootConnection. "
                                + "valid tags are connectionString, userName, password, "
                                + "structure, enabled, property");
                    }
                } else {
//                    System.out.println(item);
                }
            }
        }
        return s;
    }
    private String trimToNull(String s){
        if(s!=null){
            s=s.trim();
            if(s.isEmpty()){
                return null;
            }
        }
        return s;
    }

}
