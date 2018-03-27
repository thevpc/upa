/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.vpc.upa.impl.bulk.xml;

import java.io.InputStream;

import net.vpc.upa.ObjectFactory;

/**
 *
 * @author taha.bensalah@gmail.com
 */
public class StackBlockingSAXReaderFactory {

    public static StackBlockingSAXReader createStackBlockingSAXReader(final InputStream stream, int bufferSize, StackBlockingSAXProcessor processor, ObjectFactory factory){
        final StackBlockingSAXHandler handler = new StackBlockingSAXHandler(bufferSize, processor);
        Thread th = new CreateStackBlockingSAXReaderThreadImpl(stream, handler,factory);
        th.start();
        handler.setThread(th);
        return handler;
    }

}
