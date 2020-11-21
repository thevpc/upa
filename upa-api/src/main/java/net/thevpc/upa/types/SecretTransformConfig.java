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
package net.thevpc.upa.types;

import net.thevpc.upa.exceptions.IllegalUPAArgumentException;
import net.thevpc.upa.SecretStrategy;
import net.thevpc.upa.SecretStrategyType;

import java.io.Serializable;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class SecretTransformConfig implements DataTypeTransformConfig, Serializable {

    private Object secretStrategy;
    private String encodeKey;
    private String decodeKey;
    private int size;

    public Object getSecretStrategy() {
        return secretStrategy;
    }

    public void setSecretStrategy(String cipherStrategy) {
        this.setSecretStrategyObject(cipherStrategy);
    }

    public void setSecretStrategy(Class cipherStrategy) {
        this.setSecretStrategyObject(cipherStrategy);
    }

    public void setSecretStrategy(SecretStrategy secretStrategy) {
        this.setSecretStrategyObject(secretStrategy);
    }

    public void setSecretStrategy(SecretStrategyType secretStrategy) {
        this.setSecretStrategyObject(secretStrategy);
    }

    protected void setSecretStrategyObject(Object secretStrategy) {
        if (secretStrategy == null) {
            throw new NullPointerException();
        }
        if (!(secretStrategy instanceof String || secretStrategy instanceof Class || secretStrategy instanceof SecretStrategy || (secretStrategy instanceof SecretStrategyType && !secretStrategy.equals(SecretStrategyType.CUSTOM)))) {
            throw new IllegalUPAArgumentException("secretStrategy should be of type String (as SecretStrategy class name), Class (SecretStrategy implementing class) or SecretStrategy (instance)");
        }
        this.secretStrategy = secretStrategy;
    }

    public int getSize() {
        return size;
    }

    public void setSize(int size) {
        this.size = size;
    }

    public String getEncodeKey() {
        return encodeKey;
    }

    public void setEncodeKey(String encodeKey) {
        this.encodeKey = encodeKey;
    }

    public String getDecodeKey() {
        return decodeKey;
    }

    public void setDecodeKey(String decodeKey) {
        this.decodeKey = decodeKey;
    }

    @Override
    public String toString() {
        return "SecretConfig{" + "secretStrategy=" + secretStrategy + '}';
    }

}
