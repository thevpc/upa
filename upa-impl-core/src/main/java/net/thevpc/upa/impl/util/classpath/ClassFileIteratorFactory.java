/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package net.thevpc.upa.impl.util.classpath;

import java.net.URL;

/**
 *
 * @author vpc
 */
public interface ClassFileIteratorFactory {

    int accept(URL url);

    ClassFileIterator createClassPathFilter(URL url, ClassPathFilter configFilter, ClassFilter classFilter, ClassLoader contextClassLoader);
}
