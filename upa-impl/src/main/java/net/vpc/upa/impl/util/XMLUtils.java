/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.util;

import java.util.HashMap;
import java.util.Map;
import java.util.logging.Logger;
import org.w3c.dom.Element;
import org.w3c.dom.NamedNodeMap;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class XMLUtils {

    private static final Logger log = Logger.getLogger(XMLUtils.class.getName());

    public static Map<String, String> getAttributes(Element e, XmlAttrListFilter names) {
        Map<String, String> values = new HashMap<String, String>();
        /**
         * @PortabilityHint(target="C#",name="todo")
         */
        {
            NamedNodeMap attr = e.getAttributes();
            for (int i = 0; i < attr.getLength(); i++) {
                org.w3c.dom.Node a = attr.item(i);
                String n = uniformName(a.getNodeName());
                String n2 = names.acceptAndConvert(n);
                if (n2 != null) {
                    values.put(n2, a.getNodeValue());
                } else {
                    throw new IllegalArgumentException("Unsupported atribute " + n + " for tag " + e.getTagName());
                }
            }
        }
        return values;
    }

    public static String uniformName(String s) {
        return s.toLowerCase();
    }

    public static boolean equalsUniform(String s1, String s2) {
        return uniformName(s1).equals(uniformName(s2));
    }

}
