/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.vpc.upa.impl.util.classpath;

import java.io.File;
import java.io.IOException;
import java.net.MalformedURLException;
import java.net.URISyntaxException;
import java.net.URL;
import java.util.Collections;
import java.util.Iterator;
import java.util.jar.JarInputStream;
import java.util.logging.Level;
import java.util.logging.Logger;
import java.util.zip.ZipEntry;
import net.vpc.upa.PortabilityHint;
import net.vpc.upa.exceptions.IllegalUPAArgumentException;

/**
 *
 * @author taha.bensalah@gmail.com
 */
public class ClassPathRoot implements Iterable<ClassPathResource> {

    private static final Logger log = Logger.getLogger(ClassPathRoot.class.getName());
    private URL url;
    private File file;

    private static URL toURL(File file) {
        try {
            return file.toURI().toURL();
        } catch (MalformedURLException ex) {
            log.log(Level.SEVERE, null, ex);
            throw new IllegalUPAArgumentException(ex);
        }
    }

    @PortabilityHint(target = "C#", name = "ignore")
    public ClassPathRoot(File file) {
        this(toURL(file));
    }

    public ClassPathRoot(URL url) {
        this.url = url;
        if ("file".equals(url.getProtocol())) {
            File f2;
            try {
                f2 = new File(url.toURI());
                file = f2;
            } catch (URISyntaxException ex) {
                log.log(Level.SEVERE, null, ex);
            }
        }
    }

    public Iterator<ClassPathResource> iterator() {
        if (file != null) {
            if (file.exists()) {
                if (file.isDirectory()) {
                    return new FolderClassPathRootIterator(file);
                }
            } else {
                return Collections.emptyIterator();
            }
        }
        try {
            return new URLClassPathRootIterator(url);
        } catch (IOException ex) {
            throw new RuntimeException(ex);
        }
    }

    public ClassPathResource find(String path) throws IOException {
        if (file != null) {
            if (file.exists()) {
                if (file.isDirectory()) {
                    File f = new File(file, path);
                    if (f.exists()) {
                        return new FileClassPathResource(path, f);
                    }
                    return null;
                }
            } else {
                return null;
            }
        }
        for (ClassPathResource r : this) {
            if (r.getPath().equals(path)) {
                return r;
            }
        }
        return null;
    }

    public boolean contains(String path) throws IOException {
        /**
         * @PortabilityHint(target = "C#",name = "todo") return false;
         *
         */
        {
            if (file != null) {
                if (file.exists()) {
                    if (file.isDirectory()) {
                        File f = new File(file, path);
                        if (f.exists()) {
                            return true;
                        }
                        return false;
                    }
                } else {
                    return false;
                }
            }

            JarInputStream jar = null;
            try {
                jar = new JarInputStream(url.openStream());
                ZipEntry nextEntry;
                while ((nextEntry = jar.getNextEntry()) != null) {
                    String path2 = nextEntry.getName();
                    if (path2.equals(path)) {
                        return true;
                    }
                }
            } finally {
                if (jar != null) {
                    jar.close();
                }
            }
            return false;
        }
    }
}
