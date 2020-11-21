package net.thevpc.upa.events;

///**
// * ====================================================================
// * UPA (Unstructured Persistence API)
// *    Yet another ORM Framework
// * ++++++++++++++++++++++++++++++++++
// * Unstructured Persistence API, referred to as UPA, is a genuine effort
// * to raise programming language frameworks managing relational data in
// * applications using Java Platform, Standard Edition and Java Platform,
// * Enterprise Edition and Dot Net Framework equally to the next level of
// * handling ORM for mutable data structures. UPA is intended to provide
// * a solid reflection mechanisms to the mapped data structures while
// * affording to make changes at runtime of those data structures.
// * Besides, UPA has learned considerably of the leading ORM
// * (JPA, Hibernate/NHibernate, MyBatis and Entity Framework to name a few)
// * failures to satisfy very common even known to be trivial requirement in
// * enterprise applications.
// *
// * Copyright (C) 2014-2015 Taha BEN SALAH
// *
// * This program is free software; you can redistribute it and/or modify it under
// * the terms of the GNU General Public License as published by the Free Software
// * Foundation; either version 2 of the License, or (at your option) any later
// * version.
// *
// * This program is distributed in the hope that it will be useful, but WITHOUT
// * ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS
// * FOR A PARTICULAR PURPOSE. See the GNU General Public License for more
// * details.
// *
// * You should have received a copy of the GNU General Public License along with
// * this program; if not, write to the Free Software Foundation, Inc., 51
// * Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA.
// * ====================================================================
// */
//package net.thevpc.upa.callback;
//
//import net.thevpc.upa.PersistenceUnit;
//
//
///**
// * @author Taha BEN SALAH <taha.bensalah@gmail.com>
// * @creationdate 11/27/12 9:52 PM
// */
//public class DefinitionEvent<I, P> extends UPAEvent{
//    private PersistenceUnit persistenceUnit;
//    private int index;
//    private int oldIndex;
//    private boolean before;
//    private I item;
//    private P parent;
//    private P oldParent;
//
//    public DefinitionEvent(PersistenceUnit persistenceUnit, I item, P parent, int index, P oldParent, int oldIndex, boolean before) {
//        this.persistenceUnit = persistenceUnit;
//        this.item = item;
//        this.parent = parent;
//        this.index = index;
//        this.oldParent = oldParent;
//        this.oldIndex = oldIndex;
//        this.before = before;
//    }
//
//    public PersistenceUnit getPersistenceUnit() {
//        return persistenceUnit;
//    }
//
//    public int getIndex() {
//        return index;
//    }
//
//    public int getOldIndex() {
//        return oldIndex;
//    }
//
//    public boolean isBefore() {
//        return before;
//    }
//
//    public I getItem() {
//        return item;
//    }
//
//    public P getParent() {
//        return parent;
//    }
//
//    public P getOldParent() {
//        return oldParent;
//    }
//}
