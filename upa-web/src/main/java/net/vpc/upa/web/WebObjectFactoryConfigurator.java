/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.web;

import net.vpc.upa.ObjectFactory;
import net.vpc.upa.ObjectFactoryConfigurator;
import net.vpc.upa.PersistenceGroupProvider;
import net.vpc.upa.PersistenceUnitProvider;
import net.vpc.upa.UPAContextProvider;

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
