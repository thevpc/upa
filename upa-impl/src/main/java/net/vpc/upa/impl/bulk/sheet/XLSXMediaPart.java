/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.bulk.sheet;

import java.util.zip.ZipEntry;

import net.vpc.upa.ObjectFactory;
import net.vpc.upa.PortabilityHint;

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
