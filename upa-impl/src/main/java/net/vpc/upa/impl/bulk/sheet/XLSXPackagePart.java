/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.bulk.sheet;

import net.vpc.upa.impl.bulk.xml.StackBlockingSAXReader;
import java.io.IOException;
import java.io.InputStream;
import java.util.List;
import java.util.NoSuchElementException;
import java.util.logging.Level;
import java.util.logging.Logger;
import java.util.zip.ZipEntry;
import net.vpc.upa.PortabilityHint;
import net.vpc.upa.impl.bulk.xml.StackBlockingSAXReaderFactory;
import net.vpc.upa.impl.util.PlatformUtils;
import net.vpc.upa.impl.util.Strings;
import org.xml.sax.SAXException;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
@PortabilityHint(target = "C#",name = "suppress")
public class XLSXPackagePart {
    private static final Logger log = Logger.getLogger(XLSXPackagePart.class.getName());

    private ZipEntry entry;
    private XLSXFile container;
    private String path;

    public XLSXPackagePart(XLSXFile file, ZipEntry entry) {
        this.container = file;
        this.entry = entry;
        this.path = "/" + entry.getName();
    }

    public String getPath() {
        return path;
    }

    public XLSXFile getContainer() {
        return container;
    }

    public InputStream getInputStream() throws IOException {
        return container.zip.getInputStream(entry);
    }

    public List<XLSXPackageRel> getRelationships() throws IOException, SAXException, InterruptedException {
        XLSXPackagePart relationshipPart = getRelationshipPart();
        if (relationshipPart != null) {
            StackBlockingSAXReader reader = StackBlockingSAXReaderFactory.createStackBlockingSAXReader(relationshipPart.getInputStream(), 10, new RelationshipProcessor(null, Strings.split(path, '/', false)[0]));
            List<XLSXPackageRel> t = reader.takeList();
            for (XLSXPackageRel r : t) {
                try {
                    r.part = container.getEntry(r.path);
                } catch (NoSuchElementException e) {
                    log.log(Level.FINE, "Unable to resolve path {0} in {1}, ignored!", new Object[]{r.path, container});
                }
            }
            return t;
        }
        return PlatformUtils.emptyList();
    }

    public XLSXPackagePart getRelationshipPart() {
        return container.findEntry(getRelationshipPartPath());
    }

    public String getRelationshipPartPath() {
        String[] f = Strings.split("/" + entry.getName(),'/',false);
        String p = f[0];
        String n = f[1];
        return p + "/_rels/" + n + ".rels";
    }

    @Override
    public String toString() {
        return getClass().getSimpleName() + "{" + "path=" + path + '}';
    }

    public void compile() {

    }
}
