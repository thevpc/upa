/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.bulk.sheet;

import java.io.IOException;
import java.util.ArrayList;
import java.util.List;
import java.util.zip.ZipEntry;

import net.vpc.upa.ObjectFactory;
import net.vpc.upa.PortabilityHint;
import org.xml.sax.SAXException;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
@PortabilityHint(target = "C#",name = "suppress")
public class XLSXSheetPart extends XLSXPackagePart {

    int sheetIndex;
    String sheetName;
    String relationshipId;

    public XLSXSheetPart(XLSXFile file, ZipEntry entry, ObjectFactory factory) {
        super(file, entry, factory);
    }

    public List<XLSXDrawingPart> getDrawings() throws IOException, SAXException, InterruptedException {
        List<XLSXDrawingPart> all = new ArrayList<XLSXDrawingPart>();
        for (XLSXPackageRel xLSXPackageRel : getRelationships()) {
            if (xLSXPackageRel.getItemType().endsWith("/drawing")) {
                if (xLSXPackageRel.part == null) {
                    // System.out.println("");
                } else {
                    all.add((XLSXDrawingPart) xLSXPackageRel.part);
                }
            }
        }
        return all;
    }

    public String getRelationshipId() {
        return relationshipId;
    }

    public int getSheetIndex() {
        return sheetIndex;
    }

    public String getSheetName() {
        return sheetName;
    }
}
