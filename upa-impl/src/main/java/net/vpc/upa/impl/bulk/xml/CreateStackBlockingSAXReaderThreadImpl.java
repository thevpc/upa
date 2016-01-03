/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.bulk.xml;

import net.vpc.upa.impl.bulk.xml.StackBlockingSAXHandler;
import java.io.InputStream;
import java.util.logging.Level;
import java.util.logging.Logger;
import net.vpc.upa.PortabilityHint;
import org.xml.sax.InputSource;
import org.xml.sax.XMLReader;

/**
 *
 * @author vpc
 */
@PortabilityHint(target = "C#", name = "ignore")
class CreateStackBlockingSAXReaderThreadImpl extends Thread {
    private static final Logger log = Logger.getLogger(CreateStackBlockingSAXReaderThreadImpl.class.getName());
    private final XMLReader parser;
    private final InputStream stream;
    private final StackBlockingSAXHandler handler;

    public CreateStackBlockingSAXReaderThreadImpl(XMLReader parser, InputStream stream, StackBlockingSAXHandler handler) {
        this.parser = parser;
        this.stream = stream;
        this.handler = handler;
    }

    @Override
    public void run() {
        try {
            parser.parse(new InputSource(stream));
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
