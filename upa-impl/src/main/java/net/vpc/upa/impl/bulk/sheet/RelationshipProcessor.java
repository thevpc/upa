/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.bulk.sheet;

import net.vpc.upa.impl.bulk.xml.GenericXmlNode;
import net.vpc.upa.impl.bulk.xml.StackBlockingSAXHandler;
import net.vpc.upa.impl.bulk.xml.StackBlockingSAXProcessor;
import java.util.logging.Level;
import java.util.logging.Logger;
import net.vpc.upa.PortabilityHint;
import net.vpc.upa.impl.util.classpath.PatternListPathFilter;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
@PortabilityHint(target = "C#",name = "suppress")
public class RelationshipProcessor implements StackBlockingSAXProcessor<XLSXPackageRel> {

    private static final Logger log = Logger.getLogger(RelationshipProcessor.class.getName());

    private PatternListPathFilter filter;
    private String cwd;

    public RelationshipProcessor(String type, String cwd) {
        this.filter = new PatternListPathFilter(new String[]{type});
        this.cwd = cwd;
    }

    public void startElement(GenericXmlNode n, StackBlockingSAXHandler<XLSXPackageRel> handler) {
        //<Relationship Id="rId1" Type="http://schemas.openxmlformats.org/officeDocument/2006/relationships/image" Target="../media/image1.png"/>
        if (handler.isTopPath("Relationship")) {
            if (filter == null || filter.accept(n.getProperties().get("Type"))) {
                String target = n.getProperties().get("Target");
                if (!target.startsWith("/")) {
//                    try {
//                        target = new File(cwd + "/" + target).getCanonicalPath();
//                    } catch (IOException ex) {
//                        throw new UPAIllegalArgumentException("");
//                    }
                    target = cwd + "/" + target;
                }

                String type = n.getProperties().get("Type");
                String i = n.getProperties().get("Id");
                try {
                    handler.putValue(new XLSXPackageRel(i, type, target));
                } catch (InterruptedException ex) {
                    log.log(Level.SEVERE, null, ex);
                }
            }
        }
    }

    public void endElement(GenericXmlNode n, StackBlockingSAXHandler<XLSXPackageRel> handler) {
    }
}
