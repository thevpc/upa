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
public class DrawingProcessor implements StackBlockingSAXProcessor<XLSXDrawingPicture> {
    private static final Logger log = Logger.getLogger(DrawingProcessor.class.getName());

    public void startElement(GenericXmlNode n, StackBlockingSAXHandler<XLSXDrawingPicture> handler) {
        if (handler.isTopPath("xdr:twoCellAnchor")) {
            n.setUserObject(new XLSXDrawingPicture());
        }
    }

    public void endElement(GenericXmlNode n, StackBlockingSAXHandler<XLSXDrawingPicture> handler) {
        if (handler.isTopPath("xdr:twoCellAnchor")) {
            try {
                handler.putValue((XLSXDrawingPicture) n.getUserObject());
            } catch (InterruptedException ex) {
                log.log(Level.SEVERE, null, ex);
            }
        } else if (handler.isTopPath("xdr:twoCellAnchor", "xdr:pic", "xdr:blipFill", "a:blip")) {
            XLSXDrawingPicture p = (XLSXDrawingPicture) handler.peek(3).getUserObject();
            p.setrId(handler.peek(0).getProperties().get("r:embed"));
        } else if (handler.isTopPath("xdr:twoCellAnchor", "xdr:from", "xdr:col")) {
            XLSXDrawingPicture p = (XLSXDrawingPicture) handler.peek(2).getUserObject();
            p.setFromCol(Integer.parseInt(n.getContent().get(0)));
        } else if (handler.isTopPath("xdr:twoCellAnchor", "xdr:from", "xdr:row")) {
            XLSXDrawingPicture p = (XLSXDrawingPicture) handler.peek(2).getUserObject();
            p.setFromRow(Integer.parseInt(n.getContent().get(0)));
        } else if (handler.isTopPath("xdr:twoCellAnchor", "xdr:to", "xdr:col")) {
            XLSXDrawingPicture p = (XLSXDrawingPicture) handler.peek(2).getUserObject();
            p.setToCol(Integer.parseInt(n.getContent().get(0)));
        } else if (handler.isTopPath("xdr:twoCellAnchor", "xdr:to", "xdr:row")) {
            XLSXDrawingPicture p = (XLSXDrawingPicture) handler.peek(2).getUserObject();
            p.setToRow(Integer.parseInt(n.getContent().get(0)));
        }
    }
}
