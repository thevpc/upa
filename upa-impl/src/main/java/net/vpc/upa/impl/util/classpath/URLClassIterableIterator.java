/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.vpc.upa.impl.util.classpath;

import java.net.URL;
import java.util.Iterator;
import java.util.logging.Level;

/**
 *
 * @author taha.bensalah@gmail.com
 */
class URLClassIterableIterator implements Iterator<Class> {
    private final URLClassIterable classIterable;
    private Class nextType;
    private int urlIndex = 0;
    private Iterator<ClassPathResource> classPathResources;

    public URLClassIterableIterator(final URLClassIterable outer) {
        this.classIterable = outer;
    }

    public boolean hasNext() {
        while (urlIndex < classIterable.urls.length) {
            URL jarURL = classIterable.urls[urlIndex];
            if (classPathResources == null) {
                if (classIterable.configFilter.acceptLibrary(jarURL)) {
                    URLClassIterable.log.log(Level.FINE, "configuration from  url : {0}", jarURL);
                    classPathResources = new ClassPathRoot(jarURL).iterator();
                } else {
                    urlIndex++;
                    URLClassIterable.log.log(Level.FINEST, "ignoring configuration from url : {0}", jarURL);
                    continue;
                }
            }
            if (classPathResources.hasNext()) {
                Class c = null;
                try {
                    ClassPathResource cr = classPathResources.next();
                    c = classIterable.configureClassURL(jarURL, cr.getPath());
                } catch (ClassNotFoundException ex) {
                    URLClassIterable.log.log(Level.SEVERE, null, ex);
                }
                if (c != null) {
                    nextType = c;
                    return true;
                }
            } else {
                classPathResources = null;
                urlIndex++;
            }
        }
        classPathResources = null;
        return false;
    }

    public Class next() {
        return nextType;
    }

    @Override
    public void remove() {

    }
}
