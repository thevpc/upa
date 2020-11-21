/**
 * ====================================================================
 * UPA (Unstructured Persistence API)
 * Yet another ORM Framework
 * ++++++++++++++++++++++++++++++++++
 * Unstructured Persistence API, referred to as UPA, is a genuine effort
 * to raise programming language frameworks managing relational data in
 * applications using Java Platform, Standard Edition and Java Platform,
 * Enterprise Edition and Dot Net Framework equally to the next level of
 * handling ORM for mutable data structures. UPA is intended to provide
 * a solid reflection mechanisms to the mapped data structures while
 * affording to make changes at runtime of those data structures.
 * Besides, UPA has learned considerably of the leading ORM
 * (JPA, Hibernate/NHibernate, MyBatis and Entity Framework to name a few)
 * failures to satisfy very common even known to be trivial requirement in
 * enterprise applications.
 * <p>
 * Copyright (C) 2014-2015 Taha BEN SALAH
 * <p>
 * This program is free software; you can redistribute it and/or modify it under
 * the terms of the GNU General Public License as published by the Free Software
 * Foundation; either version 2 of the License, or (at your option) any later
 * version.
 * <p>
 * This program is distributed in the hope that it will be useful, but WITHOUT
 * ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS
 * FOR A PARTICULAR PURPOSE. See the GNU General Public License for more
 * details.
 * <p>
 * You should have received a copy of the GNU General Public License along with
 * this program; if not, write to the Free Software Foundation, Inc., 51
 * Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA.
 * ====================================================================
 */
package net.thevpc.upa;

import net.thevpc.upa.exceptions.UnexpectedException;

import java.util.ArrayList;
import java.util.Collections;
import java.util.List;
import java.util.ServiceLoader;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 * Lazy holder for ObjectFactory creation. ObjectFactory is created according to
 * the following procedure :
 * <ul>
 * <li>Look for System.getProperty("net.thevpc.upa.ObjectFactory") and create root
 * Factory, If not Found look for net.thevpc.upa.RootObjectFactory</li>
 * <li>Look for ServiceLoader.load(ObjectFactory.class) to find for extension
 * Factories</li>
 * <li>Sort extensions instances according to their
 * "getContextSupportLevel()"</li>
 * <li>Chain Factories (Each one becomes the father of the previous) and define
 * user Factory as leaf one (with min contextSupportLevel)</li>
 * <li>Bind root factory (as parent) to the very ancestor of the Factories
 * Chain</li>
 * </ul>
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 1/2/13 12:53 PM
 */
@PortabilityHint(target = "C#", name = "partial")
class BootstrapObjectFactoryLazyHolder {

    static ObjectFactory INSTANCE = create();

    @PortabilityHint(target = "C#", name = "ignore")
    static ObjectFactory create() {
        ObjectFactory factory = null;
        try {

            ServiceLoader<ObjectFactory> objectFactoryServiceLoader = ServiceLoader.load(ObjectFactory.class);
            ServiceLoader<ObjectFactoryConfigurator> objectFactoryConfServiceLoader = ServiceLoader.load(ObjectFactoryConfigurator.class);
            List<ObjectFactory> found = new ArrayList<ObjectFactory>();
            for (ObjectFactory foundFactory : objectFactoryServiceLoader) {
                found.add(foundFactory);
            }
            if (found.size() > 1) {
                Collections.sort(found, ObjectFactoryComparator.getInstance());
            }
            for (int i = found.size() - 1; i > 1; i--) {
                found.get(i).setParentFactory(found.get(i - 1));
            }
            if (found.size() > 0) {
                factory = found.get(found.size() - 1);
            }
            String key = "net.thevpc.upa.ObjectFactory";
            Logger log = Logger.getLogger(UPA.class.getName());
            log.log(Level.FINE, "Bootstrapping UPA...");
            String objectFactoryType = UPA.getBootstrap().getProperties().getString("net.thevpc.upa.ObjectFactory");
            if (objectFactoryType == null) {
                objectFactoryType = "net.thevpc.upa.RootObjectFactory";
                /**
                 * Any default implementation of UPA must define this class
                 * "net.thevpc.upa.RootObjectFactory" RootObjectFactory should be a
                 * general purpose implementation that may be overridden by
                 * domain specific usages (i.e. web context, mobile context,
                 * ...) by ServiceLoader Mechanism. ServiceLoader Mechanism is
                 * provided for User Extensions only and should not handle
                 * DefaultTypedFactory instantiation DefaultTypedFactory must
                 * return return 0 ContextSupportLevel
                 */
                log.log(Level.FINE, "Using default factory "+objectFactoryType);
            }else{
                log.log(Level.FINE, "Using root factory "+objectFactoryType);
            }
            ObjectFactory rootFactory = null;
            ClassLoader contextClassLoader = Thread.currentThread().getContextClassLoader();
            Class<ObjectFactory> loadedClass = (Class<ObjectFactory>) Class.forName(objectFactoryType, true, contextClassLoader);
            rootFactory = loadedClass.getDeclaredConstructor().newInstance();
            if (factory == null) {
                factory = rootFactory;
            } else {
                found.get(0).setParentFactory(rootFactory);
            }

            List<ObjectFactoryConfigurator> confs = new ArrayList<ObjectFactoryConfigurator>();
            for (ObjectFactoryConfigurator objectFactoryConfigurator : objectFactoryConfServiceLoader) {
                confs.add(objectFactoryConfigurator);
            }
            Collections.sort(confs, ObjectFactoryConfiguratorComparator.getInstance());
            for (ObjectFactoryConfigurator conf : confs) {
                conf.configure(factory);
            }
        } catch (Exception e) {
            throw new UnexpectedException("Unable to load net.thevpc.upa.RootObjectFactory. Most likely a valid UPA Implementation is missing (up-impl for instance)", e);
        }
        return factory;
    }

}
