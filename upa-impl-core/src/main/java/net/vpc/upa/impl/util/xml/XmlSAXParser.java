package net.vpc.upa.impl.util.xml;

public interface XmlSAXParser {

    void startElement(XmlSAXElement element);

    void characters(String chars);

    void endElement(XmlSAXElement element);

    void endDocument();

    void startDocument();

}
