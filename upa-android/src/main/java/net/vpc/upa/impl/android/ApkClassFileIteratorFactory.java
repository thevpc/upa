/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.android;

import java.net.URL;
import net.vpc.upa.impl.util.classpath.ClassFileIterator;
import net.vpc.upa.impl.util.classpath.ClassFileIteratorFactory;
import net.vpc.upa.impl.util.classpath.ClassFilter;
import net.vpc.upa.impl.util.classpath.ClassPathFilter;

/**
 *
 * @author vpc
 */
public class ApkClassFileIteratorFactory implements ClassFileIteratorFactory {

    @Override
    public int accept(URL url) {
        if (url.toString().endsWith(".apk")) {
            return 2;
        }
        return -1;
    }

    @Override
    public ClassFileIterator createClassPathFilter(URL url, ClassPathFilter configFilter, ClassFilter classFilter, ClassLoader contextClassLoader) {
        return new ApkClassFileIterator(url, configFilter, classFilter, contextClassLoader);
    }

}
