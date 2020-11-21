/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package net.thevpc.upa.impl.util.classpath;

import java.net.URL;
import java.util.Iterator;
import java.util.logging.Level;
import java.util.logging.Logger;
import net.thevpc.upa.impl.util.PlatformUtils;

/**
 *
 * @author vpc
 */
public class JarOrFolderClassFileIterator implements ClassFileIterator {

    protected static final Logger log = Logger.getLogger(JarOrFolderClassFileIterator.class.getName());

    private Iterator<ClassPathResource> classPathResources;
    private ClassPathFilter configFilter;
    private ClassFilter classFilter;
    private ClassLoader contextClassLoader;
    private URL url;

    public JarOrFolderClassFileIterator(URL url, ClassPathFilter configFilter, ClassFilter classFilter, ClassLoader contextClassLoader) {
        this.url = url;
        this.classPathResources = new ClassPathRoot(url).iterator();
        this.configFilter = configFilter;
        this.classFilter = classFilter;
        this.contextClassLoader = contextClassLoader;
    }

    @Override
    public Class nextClass() {
        while (true) {
            if (classPathResources.hasNext()) {
                Class c = null;
                try {
                    ClassPathResource cr = classPathResources.next();
                    c = configureClassURL(url, cr.getPath());
                } catch (ClassNotFoundException ex) {
                    log.log(Level.SEVERE, null, ex);
                }
                if (c != null) {
                    return c;
                }
            } else {
                return null;
            }
        }
    }

    private Class configureClassURL(URL src, String path) throws ClassNotFoundException {
        if (path.startsWith("/")) {
            path = path.substring(1);
        }
//        URL url = contextClassLoader.getResource(path);
        if (path.endsWith(".class")) {
            String cls = path.substring(0, path.length() - ".class".length()).replace('/', '.');
            String pck = null;
            int endIndex = cls.lastIndexOf('.');
            if (endIndex > 0) {
                pck = cls.substring(0, endIndex);
            }
            int dollar = cls.indexOf('$');
            boolean anonymousClass = false;
            boolean innerClass = false;
            if (dollar >= 0) {
                innerClass = true;
                //special class
                if (dollar + 1 < cls.length()) {
                    String subName = cls.substring(dollar + 1);
                    if (subName != null && subName.length() > 0 && Character.isDigit(subName.charAt(0))) {
                        anonymousClass = true;
                    }
                }
            }
            if (!anonymousClass) {
                if (configFilter.acceptClassName(src, cls)) {
                    Class<?> aClass = null;
                    try {
                        aClass = PlatformUtils.forName(cls, false, contextClassLoader);
                    } catch (Throwable e) {
                        //NoClassDefFoundError if in 3rd party jars
                        //SecurityException if in sealed package
                        //example java.lang.SecurityException: sealing violation: package org.apache.derby.shared.common.error is sealed
                        if(e instanceof NoClassDefFoundError || e instanceof SecurityException){
                            //ignore
                        }else {
                            log.log(Level.FINEST, "Unable to load class {0} for UPA configuration. Ignored", cls);
                        }
                    }
                    if (aClass != null) {
                        if (configFilter.acceptClass(src, cls, aClass)) {
                            if (classFilter == null || classFilter.accept(aClass)) {
                                return (aClass);
                            }
                        }
                    }
                } else {
//                      System.out.println(path);
//                      System.out.println("\tSOURCE  " + src);
//                      System.out.println("\tSYS URL " + sysURL);
//                      System.out.println("\tAPP URL " + url);
//                      System.out.println("\tPKG   " + (pck==null?"":Package.getPackage(pck)));
//                      System.out.println("\tCLASS " + Class.forName(cls,false,contextClassLoader));
                }
            }
        }
        return null;
    }

}
