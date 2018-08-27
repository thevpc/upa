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
package net.vpc.upa;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.LinkedHashSet;
import java.util.List;
import java.util.Map;
import java.util.Set;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 * @author vpc
 */
public abstract class AbstractObjectFactory implements ObjectFactory {

    private static Logger log = Logger.getLogger(AbstractObjectFactory.class.getName());

    protected final HashMap<String, Object> singletons = new HashMap<String, Object>();
    private final Map<Class, Set> alternatives = new HashMap<Class, Set>();

    @Override
    public <T> T getSingleton(Class<T> type) {
        String typeName = type.getName();
        if (singletons.containsKey(typeName)) {
            return (T) singletons.get(typeName);
        }
        synchronized (singletons) {
            if (singletons.containsKey(typeName)) {
                return (T) singletons.get(typeName);
            }
            T o = createObject(type);
            singletons.put(typeName, o);
            return o;
        }
    }

    @Override
    public <T> T getSingleton(String typeName) {
        if (singletons.containsKey(typeName)) {
            return (T) singletons.get(typeName);
        }
        synchronized (singletons) {
            if (singletons.containsKey(typeName)) {
                return (T) singletons.get(typeName);
            }
            T o = createObject(typeName);
            singletons.put(typeName, o);
            return o;
        }
    }

    @Override
    public <T> T createObject(String typeName, String name) {
        Class<?> c;
        try {
            c = Class.forName(typeName);
        } catch (ClassNotFoundException ex) {
            log.log(Level.SEVERE, null, ex);
            throw new RuntimeException(typeName);
        }
        return (T) createObject(c, name);
    }

    @Override
    public <T> T createObject(Class<T> type) {
        return createObject(type, null);
    }

    @Override
    public <T> T createObject(String typeName) {
        try {
            return (T) createObject(Class.forName(typeName));
        } catch (ClassNotFoundException ex) {
            log.log(Level.SEVERE, null, ex);
            throw new RuntimeException(ex);
        }
    }

    @Override
    public <T> Class[] getAlternatives(Class<T> type) {
        List<Class> all = new ArrayList<Class>();
        Set found = alternatives.get(type);
        if (found != null) {
            all.addAll(found);
        }
        return all.toArray(new Class[all.size()]);
    }

    final
    @Override
    public <T> void addAlternative(Class<T> type, Class<? extends T> impl) {
        Set found = alternatives.get(type);
        if (found == null) {
            found = new LinkedHashSet();
            alternatives.put(type, found);
        }
        found.add(impl);
    }

    @Override
    public void register(Class contract, Object instance) {
        singletons.put(contract.getName(), instance);
    }


}
