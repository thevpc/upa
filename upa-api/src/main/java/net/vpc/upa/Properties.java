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

import java.beans.PropertyChangeListener;
import java.io.Serializable;
import java.math.BigDecimal;
import java.math.BigInteger;
import java.util.Date;
import java.util.Map;
import java.util.Set;

public interface Properties extends Serializable {

    ////////////////////////////////////////
    public boolean containsKey(String key);

    public <T> T getObject(String key);

    public <T> T getObject(String key, T defaultValue);

    public void setObject(String key, Object value);

    public <T> T getSingleObject();
//    public <T> T get(String key, T defaultValue);

    ////////////////////////////////////////
    public int getInt(String key);

    public int getInt(String key, int value);

    public void setInt(String key, int value);

    public int getSingleInt();

    ////////////////////////////////////////
    public long getLong(String key);

    public long getLong(String key, long value);

    public void setLong(String key, long value);

    public long getSingleLong();

    ////////////////////////////////////////
    public double getDouble(String key);

    public double getDouble(String key, double value);

    public void setDouble(String key, double value);

    public double getSingleDouble();

    ////////////////////////////////////////
    public float getFloat(String key);

    public float getFloat(String key, float value);

    public void setFloat(String key, float value);

    public float getSingleFloat();

    ////////////////////////////////////////
    public Date getDate(String key);

    public Date getDate(String key, Date value);

    public void setDate(String key, Date value);

    public Date getSingleDate();

    ////////////////////////////////////////
    public String getString(String key);

    public String getString(String key, String value);

    public void setString(String key, String value);

    public String getSingleString();

    ////////////////////////////////////////
    public boolean getBoolean(String key);

    public boolean getBoolean(String key, boolean value);

    public void setBoolean(String key, boolean value);

    public boolean getSingleBoolean();

    //    ////////////////////////////////////////
    @PortabilityHint(target = "C#", name = "suppress")
    public void setNumber(String key, Number value);

    @PortabilityHint(target = "C#", name = "suppress")
    public Number getNumber(String key, Number value);

    @PortabilityHint(target = "C#", name = "suppress")
    public Number getNumber(String key);

    @PortabilityHint(target = "C#", name = "suppress")
    public Number getSingleNumber();

    ////////////////////////////////////////
    @PortabilityHint(target = "C#", name = "suppress")
    public void setBigDecimal(String key, BigDecimal value);

    @PortabilityHint(target = "C#", name = "suppress")
    public BigDecimal getBigDecimal(String key, BigDecimal value);

    @PortabilityHint(target = "C#", name = "suppress")
    public BigDecimal getBigDecimal(String key);

    @PortabilityHint(target = "C#", name = "suppress")
    public BigDecimal getSingleBigDecimal();

    ////////////////////////////////////////
    public void setBigInteger(String key, BigInteger value);

    public BigInteger getBigInteger(String key, BigInteger value);

    public BigInteger getBigInteger(String key);

    public BigInteger getSingleBigInteger();

    ////////////////////////////////////////
    public Set<String> keySet();

    public int size();

    public Map<String, Object> toMap();

    public void setAll(Map<String, Object> other, String... keys);

    public void setAll(Properties other, String... keys);

    public boolean isSet(String key);

    public void remove(String key);

    public Object eval(String expression);

    public void addPropertyChangeListener(String key, PropertyChangeListener listener);

    public void removePropertyChangeListener(String key, PropertyChangeListener listener);

    public void addPropertyChangeListener(PropertyChangeListener listener);

    public void removePropertyChangeListener(PropertyChangeListener listener);
}
