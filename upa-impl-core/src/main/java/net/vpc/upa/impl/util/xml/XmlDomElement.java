package net.vpc.upa.impl.util.xml;

import java.util.List;

public interface XmlDomElement extends XmlDomNode,XmlSAXElement{
    List<XmlDomNode> getChildren();
}
