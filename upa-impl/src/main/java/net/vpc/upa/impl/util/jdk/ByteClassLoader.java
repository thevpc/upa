/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.util.jdk;

import java.net.URL;
import java.net.URLClassLoader;
import java.util.HashMap;
import java.util.Map;

/**
 *
 * @author vpc
 */
public class ByteClassLoader extends URLClassLoader {

    private final Map<String, byte[]> extraClassDefs = new HashMap<>();

    public ByteClassLoader(URL[] urls, ClassLoader parent) {
        super(urls, parent);
    }

    public boolean isRegistered(String name) {
        return extraClassDefs.containsKey(name);
    }

    public void register(String name, byte[] bytecode) {
        extraClassDefs.put(name, bytecode);
    }

    @Override
    protected Class<?> findClass(final String name) throws ClassNotFoundException {
        byte[] classBytes = this.extraClassDefs.get(name);
        if (classBytes != null) {
           return defineClass(name, classBytes, 0, classBytes.length);
        }
        return super.findClass(name);
    }

}
