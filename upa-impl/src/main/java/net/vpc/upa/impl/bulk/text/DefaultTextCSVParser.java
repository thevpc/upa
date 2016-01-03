/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 *//*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.bulk.text;

import java.io.File;
import java.io.FileReader;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.io.Reader;
import java.net.URL;
import net.vpc.upa.PortabilityHint;
import net.vpc.upa.bulk.DataReader;
import net.vpc.upa.bulk.TextCSVParser;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
@PortabilityHint(target = "C#",name = "suppress")
public class DefaultTextCSVParser extends TextCSVParser {

    private Reader source;

    public void configure(Object source) throws IOException {
        if (source == null) {
            throw new IllegalArgumentException("Missing configuration");
        }
        if (source instanceof File) {
            this.source = new FileReader((File) source);
        } else if (source instanceof InputStream) {
            this.source = new InputStreamReader((InputStream) source);
        } else if (source instanceof URL) {
            this.source = new InputStreamReader(((URL) source).openStream());
        } else if (source instanceof Reader) {
            this.source = ((Reader) source);
        } else {
            throw new IllegalArgumentException("Unsupported source type " + source.getClass() + ". Expected File|InputStream|URL|Reader");
        }
    }

    public DataReader parse() throws IOException {
        DefaultTextCSVReader w = new DefaultTextCSVReader(this, source);
        w.setObjectDeserializer(getDataDeserializer());
        return w;
    }

    public void close() throws Exception {
        if (source != null) {
            source.close();
        }
    }

}
