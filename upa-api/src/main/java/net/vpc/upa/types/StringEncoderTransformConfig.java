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

import java.io.Serializable;
import net.vpc.upa.config.StringEncoderType;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class StringEncoderTransformConfig implements DataTypeTransformConfig, Serializable {

    private Object encoder;
    private int size;

    public void setEncoder(String stringEncoder) {
        setEncoderObject(stringEncoder);
    }

    public void setEncoder(StringEncoder stringEncoder) {
        setEncoderObject(stringEncoder);
    }

    public void setEncoder(StringEncoderType stringEncoder) {
        setEncoderObject(stringEncoder);
    }

    protected void setEncoderObject(Object stringifyStrategy) {
        if (!(stringifyStrategy == null
                || stringifyStrategy instanceof String
                || stringifyStrategy instanceof Class
                || stringifyStrategy instanceof StringEncoder
                || (stringifyStrategy instanceof StringEncoderType && !stringifyStrategy.equals(StringEncoderType.CUSTOM)))) {
            throw new IllegalArgumentException("secretStrategy shoud be of type String (as SecretStrategy class name), Class (SecretStrategy implementing class) or SecretStrategy (instance)");
        }
        this.encoder = stringifyStrategy;
    }

    public Object getEncoder() {
        return encoder;
    }

    public int getSize() {
        return size;
    }

    public void setSize(int size) {
        this.size = size;
    }

}
