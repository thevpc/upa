/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.thevpc.upa.impl.bulk.sheet;

import net.thevpc.upa.impl.bulk.xml.StackBlockingSAXReader;
import net.thevpc.upa.impl.bulk.xml.StackBlockingSAXReaderFactory;
import net.thevpc.upa.ObjectFactory;

import java.io.IOException;
import java.util.ArrayList;
import java.util.Collections;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.zip.ZipEntry;
import net.thevpc.upa.PortabilityHint;
import org.xml.sax.SAXException;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
@PortabilityHint(target = "C#",name = "suppress")
public class XLSXWorkbookPart extends XLSXPackagePart {
    public XLSXWorkbookPart(XLSXFile container, ZipEntry entry, ObjectFactory factory) {
        super(container, entry, factory);
    }

    public List<XLSXSheetPart> getSheets() throws IOException, SAXException, InterruptedException {
        List<XLSXSheetPart> sheets = new ArrayList<XLSXSheetPart>();
//        for (XLSXPackageRel r : getManyToOneRelationships()) {
//            if (r.getType().endsWith("/worksheet")) {
//                sheets.add((XLSXSheetPart) r.getPart());
//            }
//        }
        
        
            StackBlockingSAXReader reader = StackBlockingSAXReaderFactory.createStackBlockingSAXReader(getInputStream(), 10, new WorkbookProcessor(), factory);
            List<SheetMapping> list = reader.takeList();
            Map<String, SheetMapping> map = new HashMap<String, SheetMapping>();
            for (SheetMapping m : list) {
                map.put(m.rId, m);
            }
            for (XLSXPackageRel r : getRelationships()) {
                SheetMapping m = map.get(r.id);
                if (m != null) {
                    XLSXSheetPart s = (XLSXSheetPart) r.part;
                    s.sheetIndex = m.index;
                    s.sheetName = m.name;
                    s.relationshipId = r.id;
                    sheets.add(s);
                }
            }
            Collections.sort(sheets,new XLSXSheetPartComparator());
        return sheets;
    }

    @Override
    public void compile() {
        try {
            StackBlockingSAXReader reader = StackBlockingSAXReaderFactory.createStackBlockingSAXReader(getInputStream(), 10, new WorkbookProcessor(), factory);
            List<SheetMapping> list = reader.takeList();
            Map<String, SheetMapping> map = new HashMap<String, SheetMapping>();
            for (SheetMapping m : list) {
                map.put(m.rId, m);
            }
            for (XLSXPackageRel r : getRelationships()) {
                SheetMapping m = map.get(r.id);
                if (m != null) {
                    XLSXSheetPart s = (XLSXSheetPart) r.part;
                    s.sheetIndex = m.index;
                    s.sheetName = m.name;
                    s.relationshipId = r.id;
                }
            }
        } catch (Exception ex) {
            throw new RuntimeException(ex);
        }
    }


}
