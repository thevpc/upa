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

import java.io.Serializable;

/**
 * UnspecifiedValue is used to identify the "unspecified value" of fields of an entity
 * when dealing with unstructured records or Prototype records (Find by example).
 * Each field has has a unique value that is defined as "unspecified value",
 * if the field value is equal to that value, the field is supposed not to be explicitly
 * mentioned by user so that in "query by example" object for instance, that value is not
 * used in the where clause, and in update, that field is not updated either.
 * "Unspecified Value" is modified using "Field.setUnspecifiedValue".
 * If the value passed to that method corresponds to UnspecifiedValue.DEFAULT (which is the
 * default by the way), the unspecified value is the field's default type value ie
 * <code>null</code> for references, <code>0 (zero)</code> for numbers and <code>false</code>
 * for boolean.
 * <pre>
 *     PersistenceUnit s=UPAContext.getPersistenceUnit();
 *     //if the id field is numeric, zero is considered as the default value
 *     s.getEntity(Client.class).getField("id").setUnspecifiedValue(UnspecifiedValue.DEFAULT);
 *     //We suppose that Client has 2 attributes id of type int with default value 0
 *     //and name of type String and with default value null
 *     Client c=new Client();
 *     c.setName("Hammadi");
 *
 *     //this will list all Client name="Hammadi"
 *     //even though id=0, that value will not be used in where clause
 *     List&lt;Client> found=s.find(new QueryBuilder().setPrototype(c)).getEntityList();
 *
 *
 *     //if the id field is numeric, zero is considered as the default value
 *     s.getEntity(Client.class).getField("id").setUnspecifiedValue(-1);
 *
 *     //this will list all Client having id=0 and name="Hammadi"
 *     List&lt;Client> found2=s.find(new QueryBuilder().setPrototype(c)).getEntityList();
 * </pre>
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 9/29/12 2:44 AM
 */
public final class UnspecifiedValue implements Serializable {
    public static UnspecifiedValue DEFAULT = new UnspecifiedValue();

    private UnspecifiedValue() {
    }

    @Override
    public int hashCode() {
        return 731;
    }

    @Override
    protected Object clone() throws CloneNotSupportedException {
        return this;
    }

    @Override
    public String toString() {
        return "<UnspecifiedValue>";
    }

    @Override
    public boolean equals(Object obj) {
        return obj instanceof UnspecifiedValue;
    }
}
