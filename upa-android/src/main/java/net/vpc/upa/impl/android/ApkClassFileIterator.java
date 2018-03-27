/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.android;

import java.io.IOException;
import java.net.URL;
import java.util.Collections;
import java.util.Iterator;
import java.util.logging.Level;
import java.util.logging.Logger;
import net.vpc.upa.impl.util.PlatformUtils;
import net.vpc.upa.impl.util.classpath.ClassFileIterator;
import net.vpc.upa.impl.util.classpath.ClassFilter;
import net.vpc.upa.impl.util.classpath.ClassPathFilter;
import org.jf.dexlib2.DexFileFactory;
import org.jf.dexlib2.iface.ClassDef;
import org.jf.dexlib2.iface.DexFile;

/**
 *
 * @author vpc
 */
public class ApkClassFileIterator implements ClassFileIterator {

    protected static final Logger log = Logger.getLogger(ApkClassFileIterator.class.getName());

    private ClassPathFilter configFilter;
    private ClassFilter classFilter;
    private ClassLoader contextClassLoader;
    private URL url;
    private Iterator<ClassDef> set;

    public ApkClassFileIterator(URL url, ClassPathFilter configFilter, ClassFilter classFilter, ClassLoader contextClassLoader) {
        this.url = url;
        this.configFilter = configFilter;
        this.classFilter = classFilter;
        this.contextClassLoader = contextClassLoader;
    }

    @Override
    public Class nextClass() {
        if (set == null) {
            try {
                DexFile dexFile = DexFileFactory.loadDexFile(url.getFile(), 19 /*api level*/);
                set = (Iterator) dexFile.getClasses().iterator();
            } catch (IOException ex) {
                set = Collections.emptyIterator();
            }
        }
        while (set.hasNext()) {
            ClassDef r = set.next();
            String className = r.getType();
            className = className.substring(1, className.length() - 1).replace('/', '.');
            if (className.indexOf('$') < 0) {
                if (configFilter == null || configFilter.acceptClassName(url, className)) {
                    Class<?> aClass = null;
                    try {
                        aClass = PlatformUtils.forName(className, false, contextClassLoader);
                    } catch (Throwable e) {
                        if(e instanceof NoClassDefFoundError || e instanceof SecurityException){
                            //ignore
                        }else {
                            log.log(Level.FINEST, "Unable to load class {0} for UPA configuration. Ignored", className);
                        }
                    }
                    if (aClass != null) {
                        if (configFilter == null || configFilter.acceptClass(url, className, aClass)) {
                            if (classFilter == null || classFilter.accept(aClass)) {
                                return (aClass);
                            }
                        }
                    }
                }
            }
        }
        return null;
    }
}
