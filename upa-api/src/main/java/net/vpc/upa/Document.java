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
package net.vpc.upa;


import java.beans.PropertyChangeListener;
import java.io.Serializable;
import java.math.BigDecimal;
import java.math.BigInteger;
import java.util.Date;
import java.util.Map;
import java.util.Set;

public interface Document extends Serializable {

//    public static final Document[] EMPTY_ARRAY = new Document[0];

//    public Key getKey();
//
//    public Document removeKey();

    ////////////////////////////////////////
    public <T> T getObject(String key);

    public <T> T getObject(String key, T defaultValue);

    public void setObject(String key, Object value);

    public <T> T getSingleResult();
//    public <T> T get(String key, T defaultValue);

    ////////////////////////////////////////
    public int getInt(String key);

    public int getInt(String key, int value);

    public void setInt(String key, int value);

    public int getInt();

    ////////////////////////////////////////
    public long getLong(String key);

    public long getLong(String key, long value);

    public void setLong(String key, long value);

    public long getLong();

    ////////////////////////////////////////
    public double getDouble(String key);

    public double getDouble(String key, double value);

    public void setDouble(String key, double value);

    public double getDouble();

    ////////////////////////////////////////
    public float getFloat(String key);

    public float getFloat(String key, float value);

    public void setFloat(String key, float value);

    public float getFloat();

    ////////////////////////////////////////
    public Date getDate(String key);

    public Date getDate(String key, Date value);

    public void setDate(String key, Date value);

    public Date getDate();

    ////////////////////////////////////////
    public String getString(String key);

    public String getString(String key, String value);

    public void setString(String key, String value);

    public String getString();

    ////////////////////////////////////////
    public boolean getBoolean(String key);

    public boolean getBoolean(String key, boolean value);

    public void setBoolean(String key, boolean value);

    public boolean getBoolean();

    ////////////////////////////////////////
    public void setNumber(String key, Number value);

    public Number getNumber(String key, Number value);

    public Number getNumber(String key);

    public Number getNumber();

    ////////////////////////////////////////
    @PortabilityHint(target = "C#", name = "suppress")
    public void setBigDecimal(String key, BigDecimal value);

    @PortabilityHint(target = "C#", name = "suppress")
    public BigDecimal getBigDecimal(String key, BigDecimal value);

    @PortabilityHint(target = "C#", name = "suppress")
    public BigDecimal getBigDecimal(String key);

    @PortabilityHint(target = "C#", name = "suppress")
    public BigDecimal getBigDecimal();

    ////////////////////////////////////////
    public void setBigInteger(String key, BigInteger value);

    public BigInteger getBigInteger(String key, BigInteger value);

    public BigInteger getBigInteger(String key);

    public BigInteger getBigInteger();

    ////////////////////////////////////////

    public Set<String> keySet();

    public int size();

    public Map<String, Object> toMap();
    
    public Set<Map.Entry<String, Object>> entrySet();

    public void setAll(Map<String, Object> other);

    public void setAll(Map<String, Object> other, String... keys);

    public void setAll(Document other);

    public void setAll(Document other, String... keys);

    public boolean isSet(String key);

    public void remove(String key);

    public boolean retainAll(Set<String> keys);

    public void addPropertyChangeListener(String key, PropertyChangeListener listener);

    public void removePropertyChangeListener(String key, PropertyChangeListener listener);

    public void addPropertyChangeListener(PropertyChangeListener listener);

    public void removePropertyChangeListener(PropertyChangeListener listener);

    public boolean isEmpty();

    public Document copy();

}
