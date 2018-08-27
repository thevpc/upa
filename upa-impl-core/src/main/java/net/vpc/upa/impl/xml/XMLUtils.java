/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.xml;

import net.vpc.upa.exceptions.IllegalUPAArgumentException;

import java.util.HashMap;
import java.util.Map;
import java.util.logging.Logger;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class XMLUtils {

    private static final Logger log = Logger.getLogger(XMLUtils.class.getName());

    public static Map<String, String> getAttributes(XmlSAXElement e, XmlAttrListFilter names) {
        Map<String, String> values = new HashMap<String, String>();
        int count = e.getAttributesCount();
        for (int i = 0; i < count; i++) {
            String n = uniformName(e.getAttributeNameAt(i));
            String n2 = names.acceptAndConvert(n);
            if (n2 != null) {
                values.put(n2, e.getAttributeValueAt(i));
            } else {
                throw new IllegalUPAArgumentException("Unsupported attribute " + n + " for tag " + e.getName());
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
