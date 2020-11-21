package net.thevpc.upa.impl.xml;

import net.thevpc.upa.PortabilityHint;
import org.w3c.dom.Element;
import org.w3c.dom.Node;
import org.w3c.dom.NodeList;
import org.w3c.dom.Text;

import java.util.ArrayList;
import java.util.List;

@PortabilityHint(target = "C#", name = "suppress")
public class DefaultXmlDomElement implements XmlDomElement {
    private Element element;

    public DefaultXmlDomElement(Element element) {
        this.element = element;
    }

    @Override
    public String getName() {
        return element.getTagName();
    }

    public List<XmlDomNode> getChildren() {
        ArrayList<XmlDomNode> xmlDomNodes = new ArrayList<>();
        NodeList nl = element.getChildNodes();
        if (nl != null && nl.getLength() > 0) {

            for (int i = 0; i < nl.getLength(); i++) {
                Node item = nl.item(i);
                if(item instanceof Element){
                    xmlDomNodes.add(new DefaultXmlDomElement((Element) item));
                }else if(item instanceof Text){
                    xmlDomNodes.add(new DefaultXmlDomText(item));
                }else {
                    //System.out.println("Ignored ... "+item);
                }
            }
        }
        return xmlDomNodes;
    }

    @Override
    public int getAttributesCount() {
        return element.getAttributes().getLength();
    }

    @Override
    public String getAttributeValue(String t) {
        return element.getAttribute(t);
    }

    @Override
    public String getAttributeValueAt(int index) {
        return element.getAttributes().item(index).getNodeValue();
    }

    @Override
    public String getAttributeNameAt(int index) {
        return element.getAttributes().item(index).getNodeName();
    }
}
