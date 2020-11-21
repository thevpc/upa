/**
 * ====================================================================
 *                        vpc-commons library
 *
 * Description: <start><end>
 *
 * Copyright (C) 2006-2008 Taha BEN SALAH
 *
 * This program is free software; you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation; either version 2 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License along
 * with this program; if not, write to the Free Software Foundation, Inc.,
 * 51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA.
 * ====================================================================
 */
package net.thevpc.upa.impl.util;

import java.util.*;

/**
 * @author Taha BEN SALAH (taha.bensalah@gmail.com)
 * @creationtime  13 juil. 2006 22:14:21
 */
public class ClassMap<V> {
    private Map<Class, V> data = new HashMap<Class, V>();
    private Map<Class, V> cache = new HashMap<Class, V>();

    public ClassMap() {
    }

    public V put(Class key, V value) {
        cache.clear();
        return data.put(key, value);
    }

    public V remove(Class key) {
        cache.clear();
        return data.remove(key);
    }

    public V get(Class clazz) {
        V v1 = cache.get(clazz);
        if(v1!=null){
            return v1;
        }
        HashSet<Class> visited = new HashSet<Class>();
        List<Class> s = new ArrayList<Class>();
        s.add(clazz);
        while (!s.isEmpty()) {
            Class c = s.get(0);
            s.remove(0);
            if (!visited.contains(c)) {
                visited.add(c);

                V v = cache.get(c);
                if(v!=null){
                    return v;
                }
                v=data.get(c);
                if(v!=null){
                    cache.put(clazz,v);
                    return v;
                }
                Class superclass = c.getSuperclass();
                if (superclass != null) {
                    s.add(superclass);
                }
                for (Class<?> i : c.getInterfaces()) {
                    s.add(i);
                }
            }
        }
        if(!visited.contains(Object.class)){
            visited.add(Object.class);
            V v = cache.get(Object.class);
            if(v!=null){
                cache.put(clazz,v);
                return v;
            }
        }
        return null;
    }
}
