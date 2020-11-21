/*
 * To change this license header, choose License Headers in Project Properties.
 *
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
 * @author taha.bensalah@gmail.com
 */
class URLClassIterableIterator implements Iterator<Class> {

    protected static final Logger log = Logger.getLogger(URLClassIterableIterator.class.getName());

    private Class nextType;
    private int urlIndex = 0;
    private ClassFileIterator classPathResources;

    public URL[] urls;
    public ClassPathFilter configFilter;
    public ClassFilter classFilter;
    public int nameStrategyModelConfigOrder = Integer.MIN_VALUE;
    public ClassLoader contextClassLoader;
    public String contextName;

//    private Iterator<ClassPathResource> classPathResources;
    public URLClassIterableIterator(String contextName,URL[] urls, ClassPathFilter configFilter, ClassFilter classFilter, ClassLoader contextClassLoader) {
        this.contextName = contextName;
        this.urls = urls;
        this.configFilter = configFilter;
        this.classFilter = classFilter;
        this.contextClassLoader = contextClassLoader;
    }

    @Override
    public boolean hasNext() {
        while (urlIndex < urls.length) {
            URL jarURL = urls[urlIndex];
            if (classPathResources == null) {
                if (configFilter.acceptLibrary(jarURL)) {
                    log.log(Level.FINE, "{0} : Loading configuration from  url : {1}", new Object[]{contextName,jarURL});
                    classPathResources = PlatformUtils.createClassFileIterator(jarURL, configFilter, classFilter, contextClassLoader);
                } else {
                    urlIndex++;
                    log.log(Level.FINEST, "{0} : Ignoring configuration from url : {1}", new Object[]{contextName,jarURL});
                    continue;
                }
            }
            Class c = classPathResources.nextClass();
            if (c != null) {
                nextType = c;
                return true;
            } else {
                classPathResources = null;
                urlIndex++;
            }
        }
        classPathResources = null;
        return false;
    }

    @Override
    public Class next() {
        return nextType;
    }

    @Override
    public void remove() {

    }

}
