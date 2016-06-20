/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.vpc.upa.impl.util.classpath;

import java.net.URL;

/**
 *
 * @author vpc
 */
public interface ClassPathFilter {

    public boolean acceptLibrary(URL url);

    public boolean acceptClassName(URL url, String className);

    public boolean acceptClass(URL url, String className, Class type);
}
