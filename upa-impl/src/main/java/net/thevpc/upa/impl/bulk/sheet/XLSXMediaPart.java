/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.thevpc.upa.impl.bulk.sheet;

import java.util.zip.ZipEntry;

import net.thevpc.upa.ObjectFactory;
import net.thevpc.upa.PortabilityHint;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
@PortabilityHint(target = "C#",name = "suppress")
public class XLSXMediaPart extends XLSXPackagePart {

    public XLSXMediaPart(XLSXFile file, ZipEntry entry, ObjectFactory factory) {
        super(file, entry, factory);
    }
}
