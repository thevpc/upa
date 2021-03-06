/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 *//*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.thevpc.upa.impl.bulk.xml;

import java.io.File;
import java.io.FileReader;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.io.Reader;
import java.net.URL;
import net.thevpc.upa.PortabilityHint;
import net.thevpc.upa.bulk.DataReader;
import net.thevpc.upa.bulk.XmlParser;
import net.thevpc.upa.exceptions.UPAException;
import net.thevpc.upa.exceptions.IllegalUPAArgumentException;
import net.thevpc.upa.exceptions.UnsupportedUPAFeatureException;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
@PortabilityHint(target = "C#",name = "suppress")
public class DefaultXmlParser extends XmlParser {

    private Reader source;

    public void configure(Object source) throws IOException {
        if (source == null) {
            throw new IllegalUPAArgumentException("Missing configuration");
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
            throw new UnsupportedUPAFeatureException("Unsupported source type " + source.getClass() + ". Expected File|InputStream|URL|Reader");
        }
    }

    public DataReader parse() throws IOException {
        DefaultXmlReader w = new DefaultXmlReader(this, source,getFactory());
        w.setObjectDeserializer(getDataDeserializer());
        return w;
    }

    public void close() {
        if (source != null) {
            try{
                source.close();
            } catch (IOException e) {
                throw new UPAException("IOException",e);
            }
        }
    }
}
