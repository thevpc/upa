/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.util.classpath;

import java.io.IOException;
import java.net.URL;
import java.util.Iterator;
import java.util.jar.JarInputStream;
import java.util.zip.ZipEntry;
import java.util.zip.ZipInputStream;
import net.vpc.upa.PortabilityHint;

/**
 *
 * @author vpc
 */
public class URLClassPathRootIterator implements Iterator<ClassPathResource> {

    private URL url;
    @PortabilityHint(target = "C#", name = "ignore")
    private ZipInputStream jar;
    @PortabilityHint(target = "C#", name = "ignore")
    private ZipEntry nextEntry;

    public URLClassPathRootIterator(URL url) throws IOException {
        this.url = url;
        /**
         * @PortabilityHint(target = "C#", name = "ignore")
         */
        jar = new JarInputStream(url.openStream());
    }

    public boolean hasNext() {
        /**
         * @PortabilityHint(target = "C#", name = "suppress")
         */
        try {
            nextEntry = jar.getNextEntry();
        } catch (IOException ex) {
            return false;
        }
        return nextEntry != null;
    }

    public ClassPathResource next() {
        return new ZipEntryClassPathResource(nextEntry.getName(), nextEntry, jar);
    }

    public void remove() {
        throw new UnsupportedOperationException("Not supported.");
    }

    @PortabilityHint(target = "C#", name = "ignore")
    @Override
    protected void finalize() throws Throwable {
        if (jar != null) {
            jar.close();
        }
        super.finalize();
    }

}
