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
package net.vpc.upa.types;

import net.vpc.upa.PortabilityHint;

/**
 * User: taha Date: 16 juin 2003 Time: 15:47:42
 */
public class CharArrayType extends LOBType {
    @PortabilityHint(target = "C#", name = "new")
    public static final CharArrayType CHARS = new CharArrayType("FILE", false, null, true);
    public static final CharArrayType CHAR_REFS = new CharArrayType("FILE", true, null, true);
    private Integer maxSize;

    public CharArrayType(String name, Integer maxSize, boolean nullable) {
        this(name, false, maxSize, nullable);
    }

    public CharArrayType(String name, boolean ref, Integer maxSize, boolean nullable) {
        super(name, ref ? Character[].class : char[].class, nullable);
        this.maxSize = maxSize;
    }

    @Override
    public void check(Object value, String name, String description)
            throws ConstraintsException {
        super.check(value, name, description);
        if (value == null) {
            return;
        }
        if (value instanceof char[]) {
            if (getMaxSize() > 0 && getMaxSize() < ((char[]) value).length) {
                throw new ConstraintsException("ArraySizeTooLong", name, description, value, maxSize);
            }
        } else if (value instanceof Character[]) {
            if (getMaxSize() > 0 && getMaxSize() < ((Character[]) value).length) {
                throw new ConstraintsException("ArraySizeTooShort", name, description, value, maxSize);
            }
        }else{
            throw new ConstraintsException("InvalidCast", name, description, value, maxSize);
        }
    }

    public Integer getMaxSize() {
        return maxSize;
    }

    public void setMaxSize(Integer maxSize) {
        this.maxSize = maxSize;
    }
}
