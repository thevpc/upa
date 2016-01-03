/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.util.classpath;

import java.net.URL;
import java.util.logging.Logger;

/**
 *
 * @author vpc
 */
public class ClassPathUtils {

    private static final Logger log = Logger.getLogger(ClassPathUtils.class.getName());

//    public static List<URL> getClasspathRoots(String resource) throws IOException {
//        List<URL> urls = new ArrayList<URL>();
//        Enumeration<URL> upaXmls = Thread.currentThread().getContextClassLoader().getResources("META-INF/upa.xml");
//        while (upaXmls.hasMoreElements()) {
//            URL url = upaXmls.nextElement();
//            urls.add(getClasspathRoot(url, "META-INF/upa.xml"));
//        }
//        return urls;
//    }
    public static URL[] resolveClassPathLibs() {
        return CommonClassPathUtils.resolveClassPathLibs("META-INF/upa.xml");
    }

}
