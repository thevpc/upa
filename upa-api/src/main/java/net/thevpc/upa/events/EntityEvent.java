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
package net.thevpc.upa.events;

import net.thevpc.upa.*;
import net.thevpc.upa.Package;
import net.thevpc.upa.persistence.EntityExecutionContext;


/**
 *
 * @author taha.bensalah@gmail.com
 */
public class EntityEvent extends UPAEvent {

    private EntityExecutionContext context;
    private PersistenceUnit persistenceUnit;
    private Entity entity;
    private Package parent;
    private Package oldParent;
    private int index;
    private int oldIndex;
    private EventPhase phase;
    /**
     * actual trigger if this event is fired by a trigger
     */
    private Trigger trigger;

    public EntityEvent(Entity entity, PersistenceUnit persistenceUnit, Package parent, int index, Package oldParent, int oldIndex, EventPhase phase) {
        this.persistenceUnit = persistenceUnit;
        this.entity = entity;
        this.parent = parent;
        this.index = index;
        this.oldParent = oldParent;
        this.oldIndex = oldIndex;
        this.phase = phase;
    }

    public EntityEvent(EntityExecutionContext context, EventPhase phase) {
        this.context = context;
        this.entity = context.getEntity();
        this.parent = entity.getParent();
        this.persistenceUnit = context.getPersistenceUnit();
        this.index = -1;
        this.oldIndex = -1;
        this.phase = phase;
    }

    public EventPhase getPhase() {
        return phase;
    }

    public Trigger getTrigger() {
        return trigger;
    }

    public void setTrigger(Trigger trigger) {
        this.trigger = trigger;
    }

    public Entity getEntity() {
        return entity;
    }

    public PersistenceGroup getPersistenceGroup() {
        return persistenceUnit.getPersistenceGroup();
    }

    public PersistenceUnit getPersistenceUnit() {
        return persistenceUnit;
    }

    public EntityExecutionContext getContext() {
        return context;
    }

    public Package getParent() {
        return parent;
    }

    public Package getOldParent() {
        return oldParent;
    }

    public int getIndex() {
        return index;
    }

    public int getOldIndex() {
        return oldIndex;
    }
}
