/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.thevpc.upa.impl.bulk.sheet;

import net.thevpc.upa.impl.bulk.xml.GenericXmlNode;
import net.thevpc.upa.impl.bulk.xml.StackBlockingSAXHandler;
import net.thevpc.upa.impl.bulk.xml.StackBlockingSAXProcessor;

import java.util.logging.Level;
import java.util.logging.Logger;
import net.thevpc.upa.PortabilityHint;


/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
@PortabilityHint(target = "C#",name = "suppress")
public class WorkbookProcessor implements StackBlockingSAXProcessor<SheetMapping> {

    private static final Logger log = Logger.getLogger(WorkbookProcessor.class.getName());
    int sheetPos;

    public void startElement(GenericXmlNode n, StackBlockingSAXHandler<SheetMapping> handler) {
    }

    public void endElement(GenericXmlNode n, StackBlockingSAXHandler<SheetMapping> handler) {
        //<sheets><sheet name="Feuil1" sheetId="1" r:id="rId1"/>
        if (handler.isTopPath("sheets")) {
            sheetPos = 0;
        }
        if (handler.isTopPath("sheets", "sheet")) {
            SheetMapping i = new SheetMapping();
//            i.index = Integer.parseInt(n.getProperties().get("sheetId"));
            sheetPos++;
            i.index = sheetPos;
            i.name = n.getProperties().get("name");
            i.rId = n.getProperties().get("r:id");
            try {
                handler.putValue(i);
            } catch (InterruptedException ex) {
                log.log(Level.SEVERE,null,ex);
            }
        }
    }
}
