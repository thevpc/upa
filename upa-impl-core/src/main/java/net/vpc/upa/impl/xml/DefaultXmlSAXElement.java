package net.vpc.upa.impl.xml;

import net.vpc.upa.PortabilityHint;
import org.xml.sax.Attributes;

@PortabilityHint(target = "C#", name = "suppress")
public class DefaultXmlSAXElement implements XmlSAXElement{
    private String uri;
    private String localName;
    private String qName;
    private org.xml.sax.Attributes attributes;

    public DefaultXmlSAXElement(String uri, String localName, String qName, Attributes attributes) {
        this.uri = uri;
        this.localName = localName;
        this.qName = qName;
        this.attributes = attributes;
    }

    @Override
    public String getName() {
        return qName;
    }

    @Override
    public String getAttributeValue(String t) {
        return attributes.getValue(t);
    }

    @Override
    public int getAttributesCount() {
        return attributes.getLength();
    }

    @Override
    public String getAttributeValueAt(int index) {
        return attributes.getValue(index);
    }

    @Override
    public String getAttributeNameAt(int i) {
        return attributes.getQName(i);
    }
}
