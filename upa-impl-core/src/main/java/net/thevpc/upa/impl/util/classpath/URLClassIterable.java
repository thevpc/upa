package net.thevpc.upa.impl.util.classpath;

import net.thevpc.upa.PortabilityHint;
import net.thevpc.upa.impl.util.PlatformUtils;

import java.net.URL;
import java.util.Iterator;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 12/16/12 1:00 PM
 */
@PortabilityHint(target = "C#", name = "partial")
public class URLClassIterable implements Iterable<Class> {

    public URL[] urls;
    public ClassPathFilter configFilter;
    public ClassFilter classFilter;
    public ClassLoader contextClassLoader;
    public String contextName;

    public URLClassIterable(String contextName,URL[] urls, ClassPathFilter configFilter, ClassFilter classFilter) {
        this.contextName = contextName;
        this.urls = urls;
        this.configFilter = configFilter;
        this.classFilter = classFilter;
        this.contextClassLoader = PlatformUtils.getContextClassLoader();
    }

    @Override
    public Iterator<Class> iterator() {
        return new URLClassIterableIterator(contextName,urls, configFilter, classFilter, contextClassLoader);
    }
}
