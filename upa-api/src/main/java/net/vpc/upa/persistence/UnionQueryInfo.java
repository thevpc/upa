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
package net.vpc.upa.persistence;

import java.io.Serializable;
import java.util.ArrayList;
import java.util.List;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 8/28/12 2:44 AM
 */
public class UnionQueryInfo implements Serializable {
    private List<String> entities;
    private List<String> fields;
    private String discriminator;
    private String[][] mapping;

    public UnionQueryInfo(List<String> entities, List<String> fields, String discriminator, String[][] mapping) {
        this.entities = entities;
        this.fields = fields;
        this.discriminator = discriminator;
        this.mapping = mapping;
    }

    public List<String> getEntities() {
        return new ArrayList<String>(entities);
    }

    public List<String> getFields() {
        return new ArrayList<String>(fields);
    }

    public String getDiscriminator() {
        return discriminator;
    }

    public String getFieldName(String entityName, String fieldName, int entityIndex, int fieldIndex) {
        return mapping[entityIndex][fieldIndex];
    }
}
