/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.vpc.upa.impl.bulk.xml;

import java.io.InputStream;
import net.vpc.upa.PortabilityHint;
import org.xml.sax.SAXException;
import org.xml.sax.XMLReader;
import org.xml.sax.helpers.XMLReaderFactory;

/**
 *
 * @author taha.bensalah@gmail.com
 */
@PortabilityHint(target = "C#", name = "suppress")
public class StackBlockingSAXReaderFactory {

    @PortabilityHint(target = "C#", name = "ignore")
    public static StackBlockingSAXReader createStackBlockingSAXReader(final InputStream stream, int bufferSize, StackBlockingSAXProcessor processor) throws SAXException {
        final XMLReader parser = XMLReaderFactory.createXMLReader();
        final StackBlockingSAXHandler handler = new StackBlockingSAXHandler(bufferSize, processor);
        parser.setContentHandler(handler);
        Thread th = new CreateStackBlockingSAXReaderThreadImpl(parser, stream, handler);
        th.start();
        handler.setThread(th);
        return handler;
    }

}
