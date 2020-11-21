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


import java.beans.PropertyChangeListener;
import java.io.Serializable;
import java.math.BigDecimal;
import java.math.BigInteger;
import java.util.Date;
import java.util.Map;
import java.util.Set;

public interface Document extends Serializable {

//    static final Document[] EMPTY_ARRAY = new Document[0];

//    Key getKey();
//
//    Document removeKey();

    ////////////////////////////////////////
    <T> T get(String key);

    <T> T getObject(String key);

    <T> T getObject(String key, T defaultValue);

    void setObject(String key, Object value);

    void set(String key, Object value) ;

    <T> T getSingleResult();
//    <T> T get(String key, T defaultValue);

    ////////////////////////////////////////
    int getInt(String key);

    int getInt(String key, int value);

    void setInt(String key, int value);

    int getInt();

    ////////////////////////////////////////
    long getLong(String key);

    long getLong(String key, long value);

    void setLong(String key, long value);

    long getLong();

    ////////////////////////////////////////
    double getDouble(String key);

    double getDouble(String key, double value);

    void setDouble(String key, double value);

    double getDouble();

    ////////////////////////////////////////
    float getFloat(String key);

    float getFloat(String key, float value);

    void setFloat(String key, float value);

    float getFloat();

    ////////////////////////////////////////
    Date getDate(String key);

    Date getDate(String key, Date value);

    void setDate(String key, Date value);

    Date getDate();

    ////////////////////////////////////////
    String getString(String key);

    String getString(String key, String value);

    void setString(String key, String value);

    String getString();

    ////////////////////////////////////////
    boolean getBoolean(String key);

    boolean getBoolean(String key, boolean value);

    void setBoolean(String key, boolean value);

    boolean getBoolean();

    ////////////////////////////////////////
    void setNumber(String key, Number value);

    Number getNumber(String key, Number value);

    Number getNumber(String key);

    Number getNumber();

    ////////////////////////////////////////
    @PortabilityHint(target = "C#", name = "suppress")
    void setBigDecimal(String key, BigDecimal value);

    @PortabilityHint(target = "C#", name = "suppress")
    BigDecimal getBigDecimal(String key, BigDecimal value);

    @PortabilityHint(target = "C#", name = "suppress")
    BigDecimal getBigDecimal(String key);

    @PortabilityHint(target = "C#", name = "suppress")
    BigDecimal getBigDecimal();

    ////////////////////////////////////////
    void setBigInteger(String key, BigInteger value);

    BigInteger getBigInteger(String key, BigInteger value);

    BigInteger getBigInteger(String key);

    BigInteger getBigInteger();

    ////////////////////////////////////////

    Set<String> keySet();

    int size();

    Map<String, Object> toMap();

    Set<Map.Entry<String, Object>> entrySet();

    void setAll(Map<String, Object> other);

    void setAll(Map<String, Object> other, String... keys);

    void setAll(Document other);

    void setAll(Document other, String... keys);

    boolean isSet(String key);

    void remove(String key);

    boolean retainAll(Set<String> keys);

    void addPropertyChangeListener(String key, PropertyChangeListener listener);

    void removePropertyChangeListener(String key, PropertyChangeListener listener);

    void addPropertyChangeListener(PropertyChangeListener listener);

    void removePropertyChangeListener(PropertyChangeListener listener);

    boolean isEmpty();

    Document copy();

}
