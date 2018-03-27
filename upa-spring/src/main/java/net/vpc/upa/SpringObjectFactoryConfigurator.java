/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa;

import net.vpc.upa.impl.context.DefaultPersistenceUnitProvider;
import net.vpc.upa.impl.util.classpath.ClassFileIteratorFactory;
import net.vpc.upa.persistence.PersistenceStore;

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
