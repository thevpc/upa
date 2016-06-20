/**
 * ==================================================================== 
 * UPA (Unstructured Persistence API)
 *    Yet another ORM Framework
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
 *
 * Copyright (C) 2014-2015 Taha BEN SALAH
 *
 * This program is free software; you can redistribute it and/or modify it under
 * the terms of the GNU General Public License as published by the Free Software
 * Foundation; either version 2 of the License, or (at your option) any later
 * version.
 *
 * This program is distributed in the hope that it will be useful, but WITHOUT
 * ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS
 * FOR A PARTICULAR PURPOSE. See the GNU General Public License for more
 * details.
 *
 * You should have received a copy of the GNU General Public License along with
 * this program; if not, write to the Free Software Foundation, Inc., 51
 * Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA.
 * ====================================================================
 */
package net.vpc.upa;

import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.filters.ObjectFilter;

import java.lang.reflect.*;
import java.lang.reflect.Field;
import java.util.Map;
import java.util.Set;

/**
 *
 * @author vpc
 */
public interface BeanType {

    public Class getPlatformType();

    public Set<String> getPropertyNames();

    public Set<String> getPropertyNames(Object o, Boolean includeDefaults) ;

    public Object newInstance();

    public boolean containsProperty(String property);

    public Object getProperty(Object instance,String field);

    public boolean setProperty(Object instance,String property, Object value);

    /**
     * sets value for the property, if the property exists
     * @param instance instance to inject into
     * @param property property to inject into
     * @param value new value
     */
    public void inject(Object instance, String property, Object value);

    public Method getMethod(Class type, String name, Class ret, Class... args);

    public java.lang.reflect.Field findField(String name, ObjectFilter<Field> filter) ;

    public boolean resetToDefaultValue(Object instance, String field) ;

    public boolean isDefaultValue(Object instance, String field) ;

    public Map<String, Object> toMap(Object o, Boolean includeDefaults) ;
}
