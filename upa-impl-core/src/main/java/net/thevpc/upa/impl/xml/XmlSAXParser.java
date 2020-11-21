package net.thevpc.upa.impl.xml;

public interface XmlSAXParser {

    void startElement(XmlSAXElement element);

    void characters(String chars);

    void endElement(XmlSAXElement element);

    void endDocument();

    void startDocument();

}
