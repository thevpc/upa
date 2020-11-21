/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.thevpc.upa.impl.util.classpath;

import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;
import java.io.InputStream;

/**
 *
 * @author taha.bensalah@gmail.com
 */
public class FileClassPathResource implements ClassPathResource {

    private String path;
    private File file;

    public FileClassPathResource(String path, File file) {
        this.file = file;
        this.path = path;
    }

    public InputStream open() throws IOException {
        return new FileInputStream(file);
    }

    public String getPath() {
        return path;
    }

    @Override
    public String toString() {
        return path;
    }

}
