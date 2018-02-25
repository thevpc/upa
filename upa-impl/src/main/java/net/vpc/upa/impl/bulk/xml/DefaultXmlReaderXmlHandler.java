/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.vpc.upa.impl.bulk.xml;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.logging.Level;
import java.util.logging.Logger;
import net.vpc.upa.PortabilityHint;
import org.xml.sax.Attributes;
import org.xml.sax.SAXException;
import org.xml.sax.helpers.DefaultHandler;

/**
 *
 * @author taha.bensalah@gmail.com
 */
@PortabilityHint(target = "C#",name = "suppress")
class DefaultXmlReaderXmlHandler extends DefaultHandler {

    private static final Logger log = Logger.getLogger(DefaultXmlReaderXmlHandler.class.getName());
    private final List<String> header;
    private final DefaultXmlReader xmlReader;
    boolean expectHeader = true;
    private String name = null;
    private String value = null;
    Map<String, String> line = new HashMap<String, String>();

    public DefaultXmlReaderXmlHandler(List<String> header, DefaultXmlReader xmlReader) {
        this.xmlReader = xmlReader;
        this.header = header;
    }

    private boolean doStop() {
        return xmlReader.status == DefaultXmlReader.STOPPED;
        //                    if (!multiThreaded) {
        //                        return status == STOPPED;
        //                    }
        //                    while (queue.size() > 0) {
        //                        if (status == STOPPED) {
        //                            return true;
        //                        }
        //                        try {
        //                            Thread.sleep(500);
        //                        } catch (InterruptedException ex) {
        //                            Logger.getLogger(ImportSourceCustomXml.class.getName()).log(Level.SEVERE, null, ex);
        //                        }
        //                    }
        //                    return false;
    }

    @Override
    public void startElement(String uri, String localName, String qName, Attributes attributes) throws SAXException {
        if (doStop()) {
            return;
        }
        xmlReader.currentDepth++;
        name = null;
        if (xmlReader.currentDepth == 1 /*rootNodeName.equals(qName)*/) {
        } else if (xmlReader.currentDepth == 2 /*lineNodeName.equals(qName)*/) {
            line = new HashMap<String, String>();
        } else if (xmlReader.currentDepth == 3) {
            if (expectHeader) {
                header.add(qName);
            }
            name = qName;
            value = "";
            line.put(qName, value);
        }
    }

    public void characters(char[] ch, int start, int length) throws SAXException {
        if (doStop()) {
            return;
        }
        if (name != null) {
            value = line.get(name);
            value = value + new String(ch, start, length);
            line.put(name, value);
        }
    }

    public void endElement(String uri, String localName, String qName) throws SAXException {
        try {
            if (doStop()) {
                return;
            }
            if (xmlReader.currentDepth == 2 /*lineNodeName.equals(qName)*/) {
                if (expectHeader) {
                    xmlReader.queue2.put(new BlockingVal(BlockingVal.TYPE_VALUE, header));
                    expectHeader = false;
                }
                ArrayList<String> s = new ArrayList<String>();
                for (String h : header) {
                    String v = line.get(h);
                    s.add(v == null ? "" : v.trim());
                }
                xmlReader.queue2.put(new BlockingVal(BlockingVal.TYPE_VALUE, s));
            }
            xmlReader.currentDepth--;
        } catch (InterruptedException ex) {
            log.log(Level.SEVERE, null, ex);
        }
    }

    @Override
    public void endDocument() throws SAXException {
        try {
            xmlReader.queue2.put(new BlockingVal(BlockingVal.TYPE_EOF, null));
        } catch (InterruptedException ex) {
            log.log(Level.SEVERE, null, ex);
        }
    }

}
