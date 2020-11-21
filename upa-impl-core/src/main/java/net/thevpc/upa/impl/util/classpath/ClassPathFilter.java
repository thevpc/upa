/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.thevpc.upa.impl.util.classpath;

import java.net.URL;

/**
 *
 * @author taha.bensalah@gmail.com
 */
public interface ClassPathFilter {

    boolean acceptLibrary(URL url);

    boolean acceptClassName(URL url, String className);

    boolean acceptClass(URL url, String className, Class type);
}
