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
import net.thevpc.upa.types.DataTypeTransformConfig;

import java.io.Serializable;

/**
 *
 * @author taha.bensalah@gmail.com
 */
public class PasswordTransformConfig implements DataTypeTransformConfig, Serializable {

    public static final Object NO_VALUE = new Object();
    private Object cipherValue;
    private Object cipherStrategy;

    public Object getCipherValue() {
        return cipherValue;
    }

    public void setCipherValue(Object cipherValue) {
        this.cipherValue = cipherValue;
    }

    public Object getCipherStrategy() {
        return cipherStrategy;
    }

    public void setCipherStrategy(String cipherStrategy) {
        this.setObjectCipherStrategy(cipherStrategy);
    }

    public void setCipherStrategy(Class cipherStrategy) {
        this.setObjectCipherStrategy(cipherStrategy);
    }

    public void setCipherStrategy(PasswordStrategy cipherStrategy) {
        this.setObjectCipherStrategy(cipherStrategy);
    }

    public void setCipherStrategy(PasswordStrategyType cipherStrategy) {
        this.setObjectCipherStrategy(cipherStrategy);
    }

    protected void setObjectCipherStrategy(Object cipherStrategy) {
        if (cipherStrategy == null) {
            throw new NullPointerException();
        }
        if (!(cipherStrategy instanceof String || cipherStrategy instanceof Class || cipherStrategy instanceof PasswordStrategy || (cipherStrategy instanceof PasswordStrategyType && !cipherStrategy.equals(PasswordStrategyType.CUSTOM)))) {
            throw new IllegalUPAArgumentException("cipherStrategy should be of type String (as CipherStrategy class name), Class (CipherStrategy implementing class), CipherStrategy (instance), or CipherStrategyType (any value but custom)");
        }
        this.cipherStrategy = cipherStrategy;
    }
}
