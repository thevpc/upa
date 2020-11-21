package net.thevpc.upa.impl.xml;

import net.thevpc.upa.PortabilityHint;
import org.w3c.dom.Node;

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
