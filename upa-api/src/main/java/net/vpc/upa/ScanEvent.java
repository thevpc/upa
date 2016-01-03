/**
 * ==================================================================== UPA
 * (Unstructured Persistence API) Yet another ORM Framework
 * ++++++++++++++++++++++++++++++++++ Unstructured Persistence API, referred to
 * as UPA, is a genuine effort to raise programming language frameworks managing
 * relational data in applications using Java Platform, Standard Edition and
 * Java Platform, Enterprise Edition and Dot Net Framework equally to the next
 * level of handling ORM for mutable data structures. UPA is intended to provide
 * a solid reflection mechanisms to the mapped data structures while affording
 * to make changes at runtime of those data structures. Besides, UPA has learned
 * considerably of the leading ORM (JPA, Hibernate/NHibernate, MyBatis and
 * Entity Framework to name a few) failures to satisfy very common even known to
 * be trivial requirement in enterprise applications.
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

import net.vpc.upa.config.Decoration;
import java.lang.reflect.Method;

/**
 *
 * @author vpc
 */
public class ScanEvent {

    private UPAContext context;
    private PersistenceGroup persistenceGroup;
    private PersistenceUnit persistenceUnit;
    private Class contract;
    private Class visitedType;
    private Method visitedMethod;
    private Field visitedField;
    private Decoration visitedDecoration;
    private Object userObject;

    public ScanEvent(UPAContext context, PersistenceGroup persistenceGroup, PersistenceUnit persistenceUnit, Class contract, Class type, Method method, Field field, Decoration decoration, Object instance) {
        this.context = context;
        this.persistenceGroup = persistenceGroup;
        this.persistenceUnit = persistenceUnit;
        this.contract = contract;
        this.visitedType = type;
        this.visitedMethod = method;
        this.visitedField = field;
        this.visitedDecoration = decoration;
        this.userObject = instance;
    }

    public ScanEvent(UPAContext context, PersistenceGroup persistenceGroup, PersistenceUnit persistenceUnit, Class contract, Class type, Object instance) {
        this.context = context;
        this.persistenceGroup = persistenceGroup;
        this.persistenceUnit = persistenceUnit;
        this.contract = contract;
        this.visitedType = type;
        this.userObject = instance;
    }

    public Object getUserObject() {
        return userObject;
    }

    public UPAContext getContext() {
        return context;
    }

    public PersistenceGroup getPersistenceGroup() {
        return persistenceGroup;
    }

    public PersistenceUnit getPersistenceUnit() {
        return persistenceUnit;
    }

    public Class getContract() {
        return contract;
    }

    public Class getVisitedType() {
        return visitedType;
    }

    public Method getVisitedMethod() {
        return visitedMethod;
    }

    public Field getVisitedField() {
        return visitedField;
    }

    public Decoration getVisitedDecoration() {
        return visitedDecoration;
    }

}
