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

import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.types.I18NString;

import java.beans.PropertyChangeListener;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public interface UPAObject {

    public String getName();

    public String getAbsoluteName();

    public void setName(String name);

    public String getPersistenceName();

    public void setPersistenceName(String persistenceName);

    public PersistenceUnit getPersistenceUnit();

    public I18NString getTitle();

    public void setTitle(I18NString title);

    public I18NString getDescription();

    public void setDescription(I18NString description);

    public I18NString getI18NString();

    public void setI18NString(I18NString i18NString);

    //--------------------------- PROPERTIES SUPPORT
    public Properties getProperties();

    //    public void prepare() throws UPAException;
//    public void setStatus(PersistenceState status);
    public PersistenceState getPersistenceState();

    public void addObjectListener(UPAObjectListener listener);

    public void removeObjectListener(UPAObjectListener listener);

    public UPAObjectListener[] getObjectListeners();

    public void addPropertyChangeListener(String property, PropertyChangeListener listener);

    public void removePropertyChangeListener(String property, PropertyChangeListener listener);

    public void addPropertyChangeListener(PropertyChangeListener listener);

    public void removePropertyChangeListener(PropertyChangeListener listener);

    @Override
    public boolean equals(Object other);

    @Override
    public int hashCode();

    public void close() throws UPAException;
}
