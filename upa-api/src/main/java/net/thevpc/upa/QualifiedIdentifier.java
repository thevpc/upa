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


import net.thevpc.upa.exceptions.IllegalUPAArgumentException;

import java.util.List;

public class QualifiedIdentifier {
    private Object id;
    private Entity entity;

    public QualifiedIdentifier(Entity entity, Object id) {
        this.id = id;
        this.entity = entity;
    }

    public Key getKey()  {
        return entity.getBuilder().idToKey(id);
    }

    public Object getId() {
        return id;
    }

    public Entity getEntity() {
        return entity;
    }

    public Object getValue(String fieldName)  {
        List<Field> f = entity.getIdFields();
        Key uKey = getKey();
        for (int i = 0; i < f.size(); i++) {
            if (f.get(i).getName().equals(fieldName)) {
                return uKey.getObjectAt(i);
            }
        }
        throw new IllegalUPAArgumentException("Either key " + toString() + " or fieldName " + fieldName + " does not refer to entity " + entity.getName());
    }

}
