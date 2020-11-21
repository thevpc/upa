package net.thevpc.upa.impl.xml;

import java.util.List;

public interface XmlDomElement extends XmlDomNode,XmlSAXElement{
    List<XmlDomNode> getChildren();
}
