/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.bulk.xml;

import net.vpc.upa.PortabilityHint;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
@PortabilityHint(target = "C#", name = "ignore")
public interface StackBlockingSAXProcessor<E> {

    void endElement(GenericXmlNode n, StackBlockingSAXHandler<E> hanlder);

    void startElement(GenericXmlNode n, StackBlockingSAXHandler<E> hanlder);
}
