package net.thevpc.upa.impl.bulk.sheet;

import net.thevpc.upa.impl.util.IOUtils;
import net.thevpc.upa.exceptions.IllegalUPAArgumentException;

import java.io.File;
import java.io.IOException;
import java.io.InputStream;
import java.net.URL;
import net.thevpc.upa.PortabilityHint;
import net.thevpc.upa.bulk.DataReader;
import net.thevpc.upa.bulk.SheetParser;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
@PortabilityHint(target = "C#", name = "suppress")
public class DefaultSheetParser extends SheetParser {

    private File file;
    private File created;

    public void configure(Object source) throws IOException {
        if (source == null) {
            throw new IllegalUPAArgumentException("Missing configuration");
        }
        if (source instanceof File) {
            this.file = (File) source;
            this.created = null;
        } else if (source instanceof InputStream) {
            File f = File.createTempFile("upa-", ".xlsx");
            IOUtils.copyToFile(((InputStream) source), f, 1024);
            this.file = f;
            this.created = f;
        } else if (source instanceof URL) {
            File f = File.createTempFile("upa-", ".xlsx");
            IOUtils.copyToFile((((URL) source)).openStream(), f, 1024);
            this.file = f;
            this.created = f;
        } else {
            throw new IllegalUPAArgumentException("Unsupported source type " + source.getClass() + ". Expected File|InputStream|URL");
        }
    }

    public void configure(InputStream inputStream) throws IOException {

        File f = File.createTempFile("upa-", ".xlsx");
        IOUtils.copyToFile(inputStream, f, 1024);
        configure(f);
    }

    public DataReader parse(File file) throws IOException {
        return new DefaultSheetSAXReader(this, file, getFactory());
//        return parse(new FileInputStream(file));
    }

    public void configure(URL url) throws IOException {
        configure(url.openStream());
    }

    @Override
    public DataReader parse() throws IOException {
        if (file == null) {
            throw new IllegalUPAArgumentException("Missing configuration");
        }
        DefaultSheetSAXReader w = new DefaultSheetSAXReader(this, file, getFactory());
        w.setObjectDeserializer(getDataDeserializer());
        return w;
    }

    @Override
    public String[] getSheetNames() throws IOException {
        return getFactory().createObject(ExternalFormatHelper.class).getXLSFileSheetNames(file, getFactory());
    }

    public void close() {
        if (created != null) {
            created.delete();
        }
    }

}
