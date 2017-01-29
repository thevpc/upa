/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.vpc.upa.impl.util.classpath;

import net.vpc.upa.PortabilityHint;
import net.vpc.upa.impl.util.PlatformUtils;

import java.io.File;
import java.net.MalformedURLException;
import java.net.URL;
import java.util.Enumeration;
import java.util.HashSet;
import java.util.Set;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 * @author taha.bensalah@gmail.com
 */
@PortabilityHint(target = "C#", name = "ignore")
public class CommonClassPathUtils {

    private static final Logger log = Logger.getLogger(CommonClassPathUtils.class.getName());

    public static URL[] resolveClassPathLibs(String referenceURL) {

        Set<URL> urls = new HashSet<URL>();
        if (PlatformUtils.isSystemClassLoader()) {
            log.log(Level.FINE, "SystemClassLoader detected. Assuming Standalone Application");
            //simple standalone application
            String javaHome = System.getProperty("java.home");
            for (String s1 : System.getProperty("java.class.path").split(System.getProperty("path.separator"))) {
                if (s1.startsWith(javaHome + "/")) {
                    //ignore
                } else {
                    try {
                        urls.add(new File(s1).toURI().toURL());
                    } catch (MalformedURLException e) {
                        log.log(Level.SEVERE, "Unable to load UPA Context", e);
                    }
                }
            }
        } else {
            ClassLoader threadClassLoader = PlatformUtils.getContextClassLoader();
            if (threadClassLoader == null) {
                //do nothing
                log.log(Level.SEVERE, "Unable to load UPA Context. Class loader is null");
            } else {
                try {
                    //Only Class Path Roots that define META-INF/upa.xml will be parsed
                    Enumeration<URL> upaXmls = threadClassLoader.getResources(referenceURL);
                    while (upaXmls.hasMoreElements()) {
                        URL url = upaXmls.nextElement();
                        urls.add(getClasspathRoot(url, referenceURL));
                    }
                    //now check all other urls
                    for (URL url : java.util.Collections.list(threadClassLoader.getResources("META-INF/MANIFEST.MF"))) {
                        urls.add(getClasspathRoot(url, "META-INF/MANIFEST.MF"));
                    }
                    //for some reason some jar do not have META-INF files
                    for (URL url : java.util.Collections.list(threadClassLoader.getResources("/"))) {
                        urls.add(getClasspathRoot(url, "/"));
                    }
                    //for other bizarre reason some class folders are not listed too
                    for (URL url : java.util.Collections.list(threadClassLoader.getResources(""))) {
                        urls.add(getClasspathRoot(url, ""));
                    }

                } catch (Exception e) {
                    log.log(Level.SEVERE, "Unable to load UPA Context", e);
                }
            }
        }

        return urls.toArray(new URL[urls.size()]);
    }

    public static URL getClasspathRoot(URL url, String resource) throws MalformedURLException {
        URL root;
        String file = url.getFile();
        int resourceLength = resource.length();
        file = file.substring(0, file.length() - (resource.startsWith("/") ? resourceLength : (resourceLength + 1)));
        if (file.endsWith("!")) {
            file = file.substring(0, file.length() - 1);
        }
        String protocol = url.getProtocol();
        boolean unescaped = file.indexOf('%') == -1 && file.indexOf(' ') != -1;
        if ("file".equals(protocol)) {
            root = new File(file).toURI().toURL();
        } else if ("jar".equals(protocol) || "wsjar".equals(protocol)) {
            root = new URL(file);
            if ("file".equals(root.getProtocol())) {
                if (unescaped) {
                    root = new File(root.getFile()).toURI().toURL();
                }
            }
        } else if ("zip".equals(protocol)
                || "code-source".equals(url.getProtocol())) {
            if (unescaped) {
                root = new File(file).toURI().toURL();
            } else {
                root = new File(file).toURI().toURL();//.toURL() ?? why ?
            }
        } else {
            root = url;
        }
        return root;
    }
}


