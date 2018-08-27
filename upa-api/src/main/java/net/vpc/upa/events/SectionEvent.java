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
package net.vpc.upa.events;

import net.vpc.upa.Entity;
import net.vpc.upa.EventPhase;
import net.vpc.upa.PersistenceUnit;
import net.vpc.upa.Section;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 11/27/12 9:52 PM
 */
public class SectionEvent extends UPAEvent {

    private PersistenceUnit persistenceUnit;
    private int index;
    private int oldIndex;
    private Entity entity;
    private Section item;
    private Section parent;
    private Section oldParent;
    private EventPhase phase;

    public SectionEvent(Section item, PersistenceUnit persistenceUnit, Entity entity, Section parent, int index, Section oldParent, int oldIndex, EventPhase phase) {
        this.persistenceUnit = persistenceUnit;
        this.item = item;
        this.parent = parent;
        this.index = index;
        this.oldParent = oldParent;
        this.oldIndex = oldIndex;
        this.entity = entity;
        this.phase = phase;
    }

    public EventPhase getPhase() {
        return phase;
    }

    public PersistenceUnit getPersistenceUnit() {
        return persistenceUnit;
    }

    public int getIndex() {
        return index;
    }

    public int getOldIndex() {
        return oldIndex;
    }

    public Section getItem() {
        return item;
    }

    public Section getParent() {
        return parent;
    }

    public Section getOldParent() {
        return oldParent;
    }

    public Entity getEntity() {
        return entity;
    }
}
