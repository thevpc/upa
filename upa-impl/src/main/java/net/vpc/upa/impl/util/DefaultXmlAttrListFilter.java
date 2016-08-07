/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.vpc.upa.impl.util;

import java.util.HashSet;
import java.util.Set;

/**
 *
 * @author taha.bensalah@gmail.com
 */
public class DefaultXmlAttrListFilter implements XmlAttrListFilter {

    private final Set<String> names = new HashSet<String>();

    public DefaultXmlAttrListFilter(String... names) {
        for (String name : names) {
            this.names.add(checkUniformName(name));
        }
    }

    @Override
    public String acceptAndConvert(String s) {
        String n = XMLUtils.uniformName(s);
        if (names.contains(n)) {
            return n;
        }
        return null;
    }

    private String checkUniformName(String s) {
        if (!s.equals(XMLUtils.uniformName(s))) {
            throw new IllegalArgumentException("Expected Uniform Name " + s + " ==> " + XMLUtils.uniformName(s));
        }
        return s;
    }

}
