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
/*
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
package net.thevpc.upa.persistence;

import net.thevpc.upa.*;

import net.thevpc.upa.types.DataType;

import java.util.List;
import java.util.Map;

public interface EntityExecutionContext extends Properties {

    /**
     * Contextual Persistence Unit
     * equivalent to getExecutionContext().getPersistenceUnit()
     * @return Contextual Persistence Unit
     */
    PersistenceUnit getPersistenceUnit();

    /**
     * Current Connection to Store
     * equivalent to getExecutionContext().getConnection()
     * @return Current Connection to Store
     */
    UConnection getConnection();

    /**
     * Current Session
     * equivalent to getExecutionContext().getSession()
     * @return Current Session
     */
    Session getSession();

    /**
     * Current Persistence Store
     * equivalent to getExecutionContext().getPersistenceStore()
     * @return Persistence Store
     */
    PersistenceStore getPersistenceStore();

    ContextOperation getOperation();

    /**
     * Current document values to use for the current formula.
     * @return Current document values to use for the current formula.
     */
    Document getUpdateDocument();

    /**
     * Current update query expression
     * @return Current update query expression
     */
    UpdateQuery getUpdateQuery();

    /**
     * Current Entity to be updated by formula.
     * @return Current Entity to be updated by formula
     */
    Entity getEntity();

    Map<String, Object> getValues();

    Map<String, Object> getHints();

    Object getHint(String hintName);

    Object getHint(String hintName, Object defaultValue);

    EntityExecutionContext resetHints();

    /**
     * add or remove (if value is null) hint
     *
     * @param name
     * @param value
     */
    EntityExecutionContext setHint(String name, Object value);

    /**
     * merges hints
     *
     * @param hints
     */
    EntityExecutionContext setHints(Map<String, Object> hints);

    EntityOperationManager getEntityOperationManager();

    void addGeneratedValue(String name, DataType type);

    void removeGeneratedValue(Parameter parameter);

    List<Parameter> getGeneratedValues();

    Parameter getGeneratedValue(String name);
}
