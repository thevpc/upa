/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.util;

import java.net.URL;
import net.vpc.upa.impl.util.classpath.ClassFileIterator;
import net.vpc.upa.impl.util.classpath.ClassFileIteratorFactory;
import net.vpc.upa.impl.util.classpath.ClassFilter;
import net.vpc.upa.impl.util.classpath.ClassPathFilter;
import net.vpc.upa.impl.util.classpath.JarOrFolderClassFileIterator;

/**
 *
 * @author vpc
 */
public class JarAndFolderClassFileIteratorFactory implements ClassFileIteratorFactory {

    @Override
    public int accept(URL url) {
        return 1;
    }

    @Override
    public ClassFileIterator createClassPathFilter(URL url, ClassPathFilter configFilter, ClassFilter classFilter, ClassLoader contextClassLoader) {
        return new JarOrFolderClassFileIterator(url, configFilter, classFilter, contextClassLoader);
    }

}
