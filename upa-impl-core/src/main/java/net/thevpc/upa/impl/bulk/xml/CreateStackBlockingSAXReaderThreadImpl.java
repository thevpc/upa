/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.thevpc.upa.impl.bulk.xml;

import java.io.InputStream;
import java.util.logging.Level;
import java.util.logging.Logger;

import net.thevpc.upa.ObjectFactory;
import net.thevpc.upa.PortabilityHint;
import net.thevpc.upa.impl.XmlFactory;

/**
 *
 * @author taha.bensalah@gmail.com
 */
@PortabilityHint(target = "C#", name = "ignore")
class CreateStackBlockingSAXReaderThreadImpl extends Thread {
    private static final Logger log = Logger.getLogger(CreateStackBlockingSAXReaderThreadImpl.class.getName());
    private final InputStream stream;
    private final StackBlockingSAXHandler handler;
    private final ObjectFactory factory;

    public CreateStackBlockingSAXReaderThreadImpl(InputStream stream, StackBlockingSAXHandler handler,ObjectFactory factory) {
        this.stream = stream;
        this.handler = handler;
        this.factory = factory;
    }

    @Override
    public void run() {
        try {
            factory.createObject(XmlFactory.class).parse(stream,handler);
        } catch (Throwable ex) {
            log.log(Level.SEVERE, null, ex);
            try {
                handler.putThrowable(ex);
            } catch (InterruptedException ex1) {
                log.log(Level.SEVERE, null, ex1);
            }
        }
    }
    
}
