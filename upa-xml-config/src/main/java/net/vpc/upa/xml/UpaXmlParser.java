package net.vpc.upa.xml;

import org.w3c.dom.*;
import org.xml.sax.SAXException;

import javax.xml.parsers.DocumentBuilder;
import javax.xml.parsers.DocumentBuilderFactory;
import javax.xml.parsers.ParserConfigurationException;
import javax.xml.transform.OutputKeys;
import javax.xml.transform.Transformer;
import javax.xml.transform.TransformerException;
import javax.xml.transform.TransformerFactory;
import javax.xml.transform.dom.DOMSource;
import javax.xml.transform.stream.StreamResult;
import java.io.*;
import java.net.URI;
import java.net.URL;

public class UpaXmlParser {
    public static UpaXml parse(URL url) throws IOException, SAXException, ParserConfigurationException {
        return parse(url, null);
    }

    public static UpaXml parse(URL url, UpaXmlListener visitor) throws IOException, SAXException, ParserConfigurationException {
        InputStream is = null;
        try {
            return parse((is = url.openStream()), visitor);
        } finally {
            if (is != null) {
                is.close();
            }
        }
    }

    public static UpaXml parse(URI uri) throws IOException, SAXException, ParserConfigurationException {
        return parse(uri, null);
    }

    public static UpaXml parse(URI uri, UpaXmlListener visitor) throws IOException, SAXException, ParserConfigurationException {
        DocumentBuilderFactory dbFactory = DocumentBuilderFactory.newInstance();
        DocumentBuilder dBuilder = dbFactory.newDocumentBuilder();
        Document doc = dBuilder.parse(uri.toString());
        return parse(doc, visitor);
    }

    public static UpaXml parse(File file) throws IOException, SAXException, ParserConfigurationException {
        return parse(file, null);
    }

    public static UpaXml parse(File file, UpaXmlListener visitor) throws IOException, SAXException, ParserConfigurationException {
        DocumentBuilderFactory dbFactory = DocumentBuilderFactory.newInstance();
        DocumentBuilder dBuilder = dbFactory.newDocumentBuilder();
        Document doc = dBuilder.parse(file);
        return parse(doc, visitor);
    }

    public static UpaXml parse(InputStream stream) throws IOException, SAXException, ParserConfigurationException {
        return parse(stream, null);
    }

    public static UpaXml parse(InputStream stream, UpaXmlListener visitor) throws IOException, SAXException, ParserConfigurationException {
        DocumentBuilderFactory dbFactory = DocumentBuilderFactory.newInstance();
        DocumentBuilder dBuilder = dbFactory.newDocumentBuilder();
        Document doc = dBuilder.parse(stream);
        return parse(doc, visitor);
    }

    public static UpaXml parse(Document doc) {
        return parse(doc, null);
    }


    public static UpaXml parse(Document doc, UpaXmlListener visitor) {
        doc.getDocumentElement().normalize();
        if (visitor != null) {
            visitor.visitStartDocument(doc);
        }
        UpaXml upaXml = parseUpaXml(doc.getDocumentElement(), visitor);
        if (visitor != null) {
            visitor.visitEndDocument(doc, upaXml);
        }
        return upaXml;
    }

    public static UpaXml parseUpaXml(Element element, UpaXmlListener visitor) {
        UpaXml w = new UpaXml();
        NodeList rootChildList = element.getChildNodes();
        for (int i = 0; i < rootChildList.getLength(); i++) {
            Element elem1 = toElement(rootChildList.item(i));
            if (elem1 != null) {
                switch (elem1.getTagName().toLowerCase()) {
                    case "connection": {
                        w.getConnections().add(parseConnection(elem1, visitor, w));
                        break;
                    }
                    case "rootconnection": {
                        w.getRootConnections().add(parseConnection(elem1, visitor, w));
                        break;
                    }
                    case "connectionstring": {
                        w.getConnections().add(new UpaXml.Connection().setConnectionString(elemToStr(elem1)));
                        break;
                    }
                    case "rootconnectionstring": {
                        w.getRootConnections().add(new UpaXml.Connection().setConnectionString(elemToStr(elem1)));
                        break;
                    }
                    case "include": {
                        w.getIncludes().add(parseInclude(elem1, visitor, w));
                        break;
                    }
                    case "persistencegroup": {
                        w.getPersistenceGroups().add(parsePersistenceGroup(elem1, visitor, w));
                        break;
                    }
                    case "persistenceunit": {
                        w.getPersistenceUnits().add(parsePersistenceUnit(elem1, visitor, w));
                        break;
                    }
                    case "scan": {
                        w.getScans().add(parseScan(elem1, visitor, w));
                        break;
                    }
                    case "property": {
                        w.getProperties().add(parseProperty(elem1, visitor, w));
                        break;
                    }
                }
            }
        }
        return w;
    }

    public static UpaXml.Connection parseConnection(Element element, UpaXmlListener visitor, Object parent) {
        UpaXml.Connection w = new UpaXml.Connection();
        NodeList rootChildList = element.getChildNodes();
        if (visitor != null) {
            visitor.visitStartConnection(element, parent);
        }
        for (int i = 0; i < rootChildList.getLength(); i++) {
            Element elem1 = toElement(rootChildList.item(i));
            if (elem1 != null) {
                for (int j = 0; j < elem1.getAttributes().getLength(); j++) {
                    Attr attr = (Attr) elem1.getAttributes().item(j);
                    switch (attr.getName().toLowerCase()) {
                        case "connectionstring": {
                            w.setConnectionString(elemToStr(elem1));
                            break;
                        }
                        case "enabled": {
                            w.setEnabled(elemToBoolean(elem1));
                            break;
                        }
                        case "password": {
                            w.setPassword(elemToStr(elem1));
                            break;
                        }
                        case "structure": {
                            w.setStructure(elemToStr(elem1));
                            break;
                        }
                        case "username": {
                            w.setUserName(elemToStr(elem1));
                            break;
                        }
                    }
                }
                switch (elem1.getTagName().toLowerCase()) {
                    case "connectionstring": {
                        w.setConnectionString(elemToStr(elem1));
                        break;
                    }
                    case "enabled": {
                        w.setEnabled(elemToBoolean(elem1));
                        break;
                    }
                    case "password": {
                        w.setPassword(elemToStr(elem1));
                        break;
                    }
                    case "structure": {
                        w.setStructure(elemToStr(elem1));
                        break;
                    }
                    case "username": {
                        w.setUserName(elemToStr(elem1));
                        break;
                    }
                    case "property": {
                        w.getProperties().add(parseProperty(elem1, visitor, w));
                        break;
                    }
                }
            }
        }
        if (visitor != null) {
            visitor.visitEndConnection(element, parent, w);
        }
        return w;
    }

    public static UpaXml.PersistenceUnit parsePersistenceUnit(Element element, UpaXmlListener visitor, Object parent) {
        UpaXml.PersistenceUnit w = new UpaXml.PersistenceUnit();
        NodeList rootChildList = element.getChildNodes();
        if (visitor != null) {
            visitor.visitStartPersistenceUnit(element, parent);
        }
        for (int i = 0; i < rootChildList.getLength(); i++) {
            Element elem1 = toElement(rootChildList.item(i));
            if (elem1 != null) {
                for (int j = 0; j < elem1.getAttributes().getLength(); j++) {
                    Attr attr = (Attr) elem1.getAttributes().item(j);
                    switch (attr.getName().toLowerCase()) {
                        case "name": {
                            w.setName(elemToStr(elem1));
                            break;
                        }
                        case "start": {
                            w.setStart(elemToBoolean(elem1));
                            break;
                        }
                        case "autoscan": {
                            w.setAutoScan(elemToBoolean(elem1));
                            break;
                        }
                        case "inheritscanfilters": {
                            w.setInheritScanFilters(elemToBoolean(elem1));
                            break;
                        }
                    }
                }
                switch (elem1.getTagName().toLowerCase()) {
                    case "connectionstring": {
                        w.getConnections().add(new UpaXml.Connection().setConnectionString(elemToStr(elem1)));
                        break;
                    }
                    case "rootconnectionstring": {
                        w.getRootConnections().add(new UpaXml.Connection().setConnectionString(elemToStr(elem1)));
                        break;
                    }
                    case "connection": {
                        w.getConnections().add(parseConnection(elem1, visitor, w));
                        break;
                    }
                    case "rootconnection": {
                        w.getRootConnections().add(parseConnection(elem1, visitor, w));
                        break;
                    }
                    case "scan": {
                        w.getScans().add(parseScan(elem1, visitor, w));
                        break;
                    }
                    case "property": {
                        w.getProperties().add(parseProperty(elem1, visitor, w));
                        break;
                    }
                }
            }
        }
        if (visitor != null) {
            visitor.visitEndPersistenceUnit(element, parent, w);
        }
        return w;
    }

    public static UpaXml.Include parseInclude(Element element, UpaXmlListener visitor, Object parent) {
        UpaXml.Include w = new UpaXml.Include();
        NodeList rootChildList = element.getChildNodes();
        if (visitor != null) {
            visitor.visitStartInclude(element, parent);
        }
        for (int i = 0; i < rootChildList.getLength(); i++) {
            Element elem1 = toElement(rootChildList.item(i));
            if (elem1 != null) {
                for (int j = 0; j < elem1.getAttributes().getLength(); j++) {
                    Attr attr = (Attr) elem1.getAttributes().item(j);
                    switch (attr.getName().toLowerCase()) {
                        case "failSafe": {
                            w.setFailSafe(elemToBoolean(elem1));
                            break;
                        }
                    }
                }
                UpaXml.IncludeItem ii = parseIncludeItem(element, visitor, w, elem1);
                if (ii != null) {
                    w.getItems().add(ii);
                }
            }
        }
        if (visitor != null) {
            visitor.visitEndInclude(element, parent, w);
        }
        return w;
    }

    private static UpaXml.IncludeItem parseIncludeItem(Element element, UpaXmlListener visitor, UpaXml.Include w, Element elem1) {
        switch (elem1.getTagName().toLowerCase()) {
            case "file":
            case "url":
            case "resources": {
                UpaXml.IncludePath f = null;
                switch (elem1.getTagName().toLowerCase()) {
                    case "file": {
                        f = new UpaXml.IncludeFile();
                        break;
                    }
                    case "url": {
                        f = new UpaXml.IncludeURL();
                        break;
                    }
                    case "resources": {
                        f = new UpaXml.IncludeResource();
                        break;
                    }
                }
                if (visitor != null) {
                    visitor.visitStartIncludeItem(element, elem1);
                }
                NodeList elemChildList = elem1.getChildNodes();
                for (int j = 0; j < elemChildList.getLength(); j++) {
                    Element elem2 = toElement(elemChildList.item(j));
                    if (elem2 != null) {
                        for (int k = 0; k < elem2.getAttributes().getLength(); k++) {
                            Attr attr = (Attr) elem2.getAttributes().item(k);
                            switch (attr.getName().toLowerCase()) {
                                case "failSafe": {
                                    f.setFailSafe(elemToBoolean(elem2));
                                    break;
                                }
                                case "skipOthers": {
                                    f.setSkipOthers(elemToBoolean(elem2));
                                    break;
                                }
                                case "value": {
                                    f.setPath(elemToStr(elem2));
                                    break;
                                }
                            }
                        }
                    }
                }
                if (visitor != null) {
                    visitor.visitEndIncludeItem(element, w, f);
                }
                return f;
            }
            case "default": {
                UpaXml.IncludeDefault f = new UpaXml.IncludeDefault();
                if (visitor != null) {
                    visitor.visitStartIncludeItem(element, elem1);
                }
                f.setContent(parseUpaXml(element, visitor));
                if (visitor != null) {
                    visitor.visitEndIncludeItem(element, w, f);
                }
                return f;
            }
        }
        return null;
    }

    public static UpaXml.PersistenceGroup parsePersistenceGroup(Element element, UpaXmlListener visitor, Object parent) {
        UpaXml.PersistenceGroup w = new UpaXml.PersistenceGroup();
        NodeList rootChildList = element.getChildNodes();
        if (visitor != null) {
            visitor.visitStartPersistenceGroup(element, parent);
        }
        for (int i = 0; i < rootChildList.getLength(); i++) {
            Element elem1 = toElement(rootChildList.item(i));
            if (elem1 != null) {
                for (int j = 0; j < elem1.getAttributes().getLength(); j++) {
                    Attr attr = (Attr) elem1.getAttributes().item(j);
                    switch (attr.getName().toLowerCase()) {
                        case "name": {
                            w.setName(elemToStr(elem1));
                            break;
                        }
                        case "autoscan": {
                            w.setAutoScan(elemToBoolean(elem1));
                            break;
                        }
                        case "inheritscanfilters": {
                            w.setInheritScanFilters(elemToBoolean(elem1));
                            break;
                        }
                    }
                }
                switch (elem1.getTagName().toLowerCase()) {
//                    case "connectionstring": {
//                        w.getConnections().add(new UpaXml.Connection().setConnectionString(elemToStr(elem1)));
//                        break;
//                    }
//                    case "rootconnectionstring": {
//                        w.getRootConnections().add(new UpaXml.Connection().setConnectionString(elemToStr(elem1)));
//                        break;
//                    }
//                    case "connection": {
//                        w.getConnections().add(parseConnection(elem1,visitor));
//                        break;
//                    }
//                    case "rootconnection": {
//                        w.getRootConnections().add(parseConnection(elem1,visitor));
//                        break;
//                    }
                    case "persistenceunit": {
                        w.getPersistenceUnits().add(parsePersistenceUnit(elem1, visitor, w));
                        break;
                    }
                    case "scan": {
                        w.getScans().add(parseScan(elem1, visitor, w));
                        break;
                    }
                    case "property": {
                        w.getProperties().add(parseProperty(elem1, visitor, w));
                        break;
                    }
                }
            }
        }
        if (visitor != null) {
            visitor.visitEndPersistenceGroup(element, parent, w);
        }
        return w;
    }

    public static UpaXml.Property parseProperty(Element element, UpaXmlListener visitor, Object parent) {
        if (visitor != null) {
            visitor.visitStartProperty(element, parent);
        }
        UpaXml.Property w = new UpaXml.Property();
        for (int j = 0; j < element.getAttributes().getLength(); j++) {
            Attr attr = (Attr) element.getAttributes().item(j);
            switch (attr.getName().toLowerCase()) {
                case "name": {
                    w.setName(elemToStr(element));
                    break;
                }
                case "value": {
                    w.setValue(elemToStr(element));
                    break;
                }
                case "type": {
                    w.setType(elemToStr(element));
                    break;
                }
                case "format": {
                    w.setFormat(elemToStr(element));
                    break;
                }
            }
        }
        String v = elemToStr(element);
        if (w.getValue() == null || v.length() > 0) {
            w.setValue(v);
        }
        if (visitor != null) {
            visitor.visitEndProperty(element, parent, w);
        }
        return w;
    }

    public static UpaXml.Scan parseScan(Element element, UpaXmlListener visitor, Object parent) {
        if (visitor != null) {
            visitor.visitStartScan(element, parent);
        }
        UpaXml.Scan w = new UpaXml.Scan();
        for (int j = 0; j < element.getAttributes().getLength(); j++) {
            Attr attr = (Attr) element.getAttributes().item(j);
            switch (attr.getName().toLowerCase()) {
                case "libs": {
                    w.setLibs(elemToStr(element));
                    break;
                }
                case "types": {
                    w.setTypes(elemToStr(element));
                    break;
                }
                case "propagate": {
                    w.setPropagate(elemToBoolean(element));
                    break;
                }
            }
        }
        if (visitor != null) {
            visitor.visitEndScan(element, parent, w);
        }
        return w;
    }

    private static String elemToStr(Element ex) {
        return ex.getTextContent() == null ? "" : ex.getTextContent().trim();
    }

    private static Boolean elemToBoolean(Element ex) {
        return ex.getTextContent() == null ? null : ex.getTextContent().trim().isEmpty() ? null : Boolean.parseBoolean(ex.getTextContent().trim());
    }

    private static Element toElement(Node n) {
        if (n instanceof Element) {
            return (Element) n;
        }
        return null;
    }

    private static Element toElement(Node n, String name) {
        if (n instanceof Element) {
            if (((Element) n).getTagName().equals(name)) {
                return (Element) n;
            }
        }
        return null;
    }


    public static Element createNameTextTag(Document doc, String name, String value) {
        Element elem = doc.createElement(name);
        elem.appendChild(doc.createTextNode(value));
        return elem;
    }

    public static void writeDocument(Document doc, File result) throws TransformerException {
        writeDocument(doc, new StreamResult(result));
    }

    public static void writeDocument(Document doc, Writer result) throws TransformerException {
        writeDocument(doc, new StreamResult(result));
    }

    public static void writeDocument(Document doc, OutputStream result) throws TransformerException {
        writeDocument(doc, new StreamResult(result));
    }

    public static void writeDocument(Document doc, StreamResult result) throws TransformerException {
        TransformerFactory transformerFactory = TransformerFactory.newInstance();
        Transformer transformer = transformerFactory.newTransformer();
        transformer.setOutputProperty(OutputKeys.ENCODING, "UTF-8");
        transformer.setOutputProperty(OutputKeys.INDENT, "yes");
        transformer.setOutputProperty("{http://xml.apache.org/xslt}indent-amount", "2");
        DOMSource source = new DOMSource(doc);
        transformer.transform(source, result);
    }

    private static boolean isEmpty(String s) {
        return s == null || s.trim().isEmpty();
    }
}
