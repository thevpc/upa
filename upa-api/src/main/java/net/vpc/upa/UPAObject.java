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

import net.vpc.upa.types.I18NString;

import java.beans.PropertyChangeListener;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public interface UPAObject {

    String getName();

    void setName(String name);

    /**
     * object preferred position weight in the immediate parent.
     * the higher preferred position is, the later it will be present in 
     * parent's items list
     * @return 
     */
    public int getPreferredPosition();

    public void setPreferredPosition(int preferredProsition);

    String getAbsoluteName();

//    String getPersistenceName();
//
//    void setPersistenceName(String persistenceName);
//
    PersistenceUnit getPersistenceUnit();

    PersistenceGroup getPersistenceGroup();

    /**
     * localized title
     *
     * @return localized title
     * @see #getI18NTitle()
     * @see net.vpc.upa.UPAI18n
     */
    String getTitle();

    /**
     * localized description
     *
     * @return localized description
     * @see #getI18NTitle()
     * @see net.vpc.upa.UPAI18n
     */
    String getDescription();

    I18NString getI18NTitle();

    void setI18NTitle(I18NString title);

    I18NString getI18NDescription();

    void setI18NDescription(I18NString description);

    //--------------------------- PROPERTIES SUPPORT
    Properties getProperties();

    //    void prepare() ;
//    void setStatus(PersistenceState status);
    PersistenceState getPersistenceState();

    void addObjectListener(UPAObjectListener listener);

    void removeObjectListener(UPAObjectListener listener);

    UPAObjectListener[] getObjectListeners();

    void addPropertyChangeListener(String property, EventPhase phase, PropertyChangeListener listener);

    void removePropertyChangeListener(String property, EventPhase phase, PropertyChangeListener listener);

    void addPropertyChangeListener(EventPhase phase, PropertyChangeListener listener);

    void removePropertyChangeListener(EventPhase phase, PropertyChangeListener listener);

    @Override
    boolean equals(Object other);

    @Override
    int hashCode();

    void close();
}
