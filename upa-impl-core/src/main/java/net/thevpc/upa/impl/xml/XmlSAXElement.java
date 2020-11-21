package net.thevpc.upa.impl.xml;

public interface XmlSAXElement {
    String getName();

    int getAttributesCount();

    String getAttributeValue(String t);

    String getAttributeValueAt(int index);

    String getAttributeNameAt(int i);
}
