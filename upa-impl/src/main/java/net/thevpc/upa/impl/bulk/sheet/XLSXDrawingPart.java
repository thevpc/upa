/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.thevpc.upa.impl.bulk.sheet;

import net.thevpc.upa.impl.bulk.xml.StackBlockingSAXReader;
import net.thevpc.upa.impl.bulk.xml.StackBlockingSAXReaderFactory;
import net.thevpc.upa.ObjectFactory;

import java.io.EOFException;
import java.io.IOException;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.logging.Level;
import java.util.logging.Logger;
import java.util.zip.ZipEntry;
import net.thevpc.upa.PortabilityHint;
import org.xml.sax.SAXException;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
@PortabilityHint(target = "C#",name = "suppress")
public class XLSXDrawingPart extends XLSXPackagePart {

    private static final Logger log = Logger.getLogger(XLSXDrawingPart.class.getName());
    public XLSXDrawingPart(XLSXFile file, ZipEntry entry, ObjectFactory factory) {
        super(file, entry, factory);
    }

    public List<XLSXDrawingPicture> getPictures() throws SAXException, IOException, InterruptedException {
        StackBlockingSAXReader<XLSXDrawingPicture> drawingReader = StackBlockingSAXReaderFactory.createStackBlockingSAXReader(getInputStream(), 10, new DrawingProcessor(), factory);
//                        List<PicInfo> drawingList = drawingReader.takeList();
        Map<String, XLSXDrawingPicture> drawingMap = new HashMap<String, XLSXDrawingPicture>();
        List<XLSXDrawingPicture> drawingList2 = new ArrayList<XLSXDrawingPicture>();
        while (true) {
            try {
                XLSXDrawingPicture t = drawingReader.take();
                drawingMap.put(t.getrId(), t);
            } catch (EOFException ex) {
                break;
            }
        }

        for (XLSXPackageRel y : getRelationships()) {
            if (y.getItemType().endsWith("/image")) {
                XLSXDrawingPicture pic = drawingMap.get(y.getId());
                if (pic != null) {
                    pic.setPicturePath(y.getPath());
                    drawingList2.add(pic);
                } else {
                    log.log(Level.SEVERE, "Unable to resolve media {0} in {1} in {2}, ignored!", new Object[]{y.getId(), y, getContainer()});
                }
            }
        }
        return drawingList2;

    }
}
