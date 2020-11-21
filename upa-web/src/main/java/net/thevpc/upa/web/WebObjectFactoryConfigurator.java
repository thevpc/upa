/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package net.thevpc.upa.web;

import net.thevpc.upa.ObjectFactory;
import net.thevpc.upa.ObjectFactoryConfigurator;
import net.thevpc.upa.PersistenceGroupProvider;
import net.thevpc.upa.PersistenceUnitProvider;
import net.thevpc.upa.UPAContextProvider;

/**
 *
 * @author vpc
 */
public class WebObjectFactoryConfigurator implements ObjectFactoryConfigurator {

    @Override
    public void configure(ObjectFactory factory) {
        factory.register(UPAContextProvider.class, WebUPAContextProvider.class);
        factory.register(PersistenceUnitProvider.class, WebSessionPersistenceUnitProvider.class);
        factory.register(PersistenceGroupProvider.class, WebPersistenceGroupProvider.class);
    }

    @Override
    public int getContextSupportLevel() {
        return 1;
    }

}
