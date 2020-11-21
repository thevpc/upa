/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package net.thevpc.upa.impl.android;

import net.thevpc.upa.impl.util.classpath.ClassFileIteratorFactory;
import net.thevpc.upa.persistence.PersistenceStore;
import net.thevpc.upa.ObjectFactory;
import net.thevpc.upa.ObjectFactoryConfigurator;

/**
 *
 * @author vpc
 */
public class AndroidObjectFactoryConfigurator implements ObjectFactoryConfigurator {

    @Override
    public void configure(ObjectFactory factory) {
        LogHelper.configure();
        factory.addAlternative(ClassFileIteratorFactory.class, ApkClassFileIteratorFactory.class);
        factory.addAlternative(PersistenceStore.class, AndroidSqlitePersistenceStore.class);
    }

    @Override
    public int getContextSupportLevel() {
        return 1;
    }

}
