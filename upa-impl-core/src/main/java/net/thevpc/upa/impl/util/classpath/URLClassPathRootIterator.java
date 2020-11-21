/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.thevpc.upa.impl.util.classpath;

import java.io.IOException;
import java.net.URL;
import java.util.Iterator;
import java.util.jar.JarInputStream;
import java.util.zip.ZipEntry;
import java.util.zip.ZipInputStream;
import net.thevpc.upa.PortabilityHint;
import net.thevpc.upa.exceptions.UnsupportedUPAFeatureException;

/**
 *
 * @author taha.bensalah@gmail.com
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
         * @PortabilityHint(target = "C#", name = "todo")
         * return false;
         */
        {
            try {
                nextEntry = jar.getNextEntry();
            } catch (IOException ex) {
                return false;
            }
            return nextEntry != null;
        }
    }

    public ClassPathResource next() {
        /**
         * @PortabilityHint(target = "C#", name = "todo")
         * return null;
         */
        return new ZipEntryClassPathResource(nextEntry.getName(), nextEntry, jar);
    }

    public void remove() {
        throw new UnsupportedUPAFeatureException("Not supported.");
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
