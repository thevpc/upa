package net.vpc.upa.impl.util.xml;

import org.xml.sax.Attributes;
import org.xml.sax.helpers.DefaultHandler;

public class XmlSAXParserHandlerAdapter extends DefaultHandler {
    private XmlSAXParser parser;

    public XmlSAXParserHandlerAdapter(XmlSAXParser parser) {
        this.parser = parser;
    }

    public void startElement(String uri, String localName, String qName, Attributes attributes) {
        parser.startElement(new DefaultXmlSAXElement(uri, localName, qName, attributes));
    }

    public void characters(char ch[], int start, int length) {
        parser.characters(new String(ch, start, length));
    }

    public void endElement(String uri, String localName, String qName) {
        parser.endElement(new DefaultXmlSAXElement(uri, localName, qName, null));
    }

    public void endDocument() {
        parser.endDocument();
    }
}
