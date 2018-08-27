/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.spring;

import net.vpc.upa.ObjectFactory;
import net.vpc.upa.ObjectFactoryConfigurator;

/**
 *
 * @author vpc
 */
public class SpringObjectFactoryConfigurator implements ObjectFactoryConfigurator {

    @Override
    public void configure(ObjectFactory factory) {

    }

    @Override
    public int getContextSupportLevel() {
        return 1;
    }

}
