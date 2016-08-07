/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.vpc.upa.impl.bulk.xml;

import java.io.IOException;
import java.util.logging.Level;
import java.util.logging.Logger;
import net.vpc.upa.PortabilityHint;

/**
 *
 * @author taha.bensalah@gmail.com
 */
@PortabilityHint(target = "C#",name = "suppress")
class DefaultXmlReaderThreadImpl extends Thread {
    private final DefaultXmlReader outer;
    private static final Logger log = Logger.getLogger(DefaultXmlReaderThreadImpl.class.getName());

    public DefaultXmlReaderThreadImpl(final DefaultXmlReader outer) {
        this.outer = outer;
    }

    @Override
    public void run() {
        try {
            outer.readXml();
        } catch (IOException ex) {
            log.log(Level.SEVERE, null, ex);
            try {
                outer.queue2.put(new BlockingVal(BlockingVal.TYPE_THROWABLE, ex));
            } catch (InterruptedException ex1) {
                log.log(Level.SEVERE, null, ex1);
            }
        }
    }
    
}
