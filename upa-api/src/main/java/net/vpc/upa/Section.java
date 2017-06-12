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

import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.filters.FieldFilter;

import java.util.List;

public interface Section extends EntityPart {

    Field addField(FieldBuilder fieldBuilder) throws UPAException;

    Field addField(FieldDescriptor fieldDescriptor) throws UPAException;

    void addPart(EntityPart child) throws UPAException;

    void addPart(EntityPart child, int index) throws UPAException;

    EntityPart removePartAt(int index) throws UPAException;

    EntityPart removePart(String name) throws UPAException;

    void movePart(int index, int newIndex) throws UPAException;

    void movePart(String itemName, int newIndex) throws UPAException;

    /**
     * @return this section (and it subsequent sub sections) fields
     * @throws UPAException
     */
    List<Field> getFields() throws UPAException;

    List<Field> getFields(FieldFilter fieldFilter) throws UPAException;

    /**
     * @return
     */
    List<Field> getImmediateFields();

    List<Field> getImmediateFields(FieldFilter fieldFilter);

    List<Section> getSections() throws UPAException;

    List<EntityPart> getParts() throws UPAException;

    EntityPart getPart(String name) throws UPAException;

    EntityPart getPartAt(int index) throws UPAException;

    Section getSection(String name) throws UPAException;

    int indexOfPart(EntityPart part) throws UPAException;

    int indexOfPart(String partName) throws UPAException;

    int getPartsCount() throws UPAException;


    Section findSection(String name) throws UPAException;

    Section getSection(String path, MissingStrategy missingStrategy) throws UPAException;

    Section addSection(String name, String parentPath) throws UPAException;

    Section addSection(String name, String parentPath, int index) throws UPAException;

    Section addSection(String name, int index) throws UPAException;

    Section addSection(String name) throws UPAException;
}
