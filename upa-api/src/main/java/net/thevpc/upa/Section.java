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

import net.thevpc.upa.filters.FieldFilter;

import java.util.List;

public interface Section extends EntityItem {

    Field addField(FieldBuilder fieldBuilder);

    Field addField(FieldDescriptor fieldDescriptor);

    void addItem(EntityItem child);

    EntityItem removeItemAt(int index);

    EntityItem removeItem(String name);

    void moveItem(int index, int newIndex);

    void moveItem(String itemName, int newIndex);

    /**
     * @return this section (and it subsequent sub sections) fields
     * @
     */
    List<Field> getFields();
    
    List<Field> getFields(boolean includeAll);

    List<Field> getFields(FieldFilter fieldFilter);

    /**
     * @return
     */
    List<Field> getImmediateFields();

    List<Field> getImmediateFields(FieldFilter fieldFilter);

    List<Section> getSections();

    List<Section> getSections(boolean includeSubSections);

    List<EntityItem> getItems();

    EntityItem getItem(String name);

    EntityItem getItemAt(int index);

    Section getSection(String name);

    int indexOfItem(EntityItem part);

    int indexOfItem(String partName);

    int getItemsCount();

    Section findSection(String path);

    Section getSection(String path, MissingStrategy missingStrategy);

    Section addSection(String path, int index);

    Section addSection(String path);

    SectionInfo getInfo();
}
