package net.vpc.upa.impl.xml;

import net.vpc.upa.PortabilityHint;
import org.w3c.dom.Element;
import org.w3c.dom.Node;
import org.w3c.dom.NodeList;

import java.util.ArrayList;
import java.util.List;

@PortabilityHint(target = "C#", name = "suppress")
public class DefaultXmlDomText implements XmlDomText {
    private Node element;

    public DefaultXmlDomText(Node element) {
        this.element = element;
    }

    @Override
    public String getText() {
        return element.getNodeValue();
    }
}
