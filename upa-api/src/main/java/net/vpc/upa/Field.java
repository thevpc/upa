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

import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.filters.FieldFilter;
import net.vpc.upa.types.DataTypeTransform;
import net.vpc.upa.types.DataType;

import java.util.List;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public interface Field extends EntityPart {

    public void setPropertyAccessType(PropertyAccessType value);

    public PropertyAccessType getPropertyAccessType();

    public void setUnspecifiedValue(Object o);

    public Object getUnspecifiedValue();

    /**
     * should return a valid value of UnspecifiedValue. Actually, if
     * getUnspecifiedValue() returns UnspecifiedValue.DEFAULT. this method would
     * return type's default value.
     *
     * @return
     */
    public Object getUnspecifiedValueDecoded();

    public boolean isUnspecifiedValue(Object value);

    public void setDefaultObject(Object o);

    public Object getDefaultValue();

    public Object getDefaultObject();

    public List<Relationship> getManyToOneRelationships();

    public void setFormula(String formula);

    public void setFormula(Formula formula);

    public void setPersistFormula(String formula);

    public void setPersistFormula(Formula formula);

    public Formula getPersistFormula();

    public int getPersistFormulaOrder();

    public void setFormulaOrder(int order);

    public void setPersistFormulaOrder(int order);

    public Formula getUpdateFormula();

    public int getUpdateFormulaOrder();

    public void setUpdateFormula(String formula);

    public void setUpdateFormula(Formula formula);

    public void setUpdateFormulaOrder(int order);

    public Formula getSelectFormula();

    public void setSelectFormula(String formula);

    public void setSelectFormula(Formula formula);

    //    public boolean isRequired() throws UPAException;
    public DataType getDataType();

    public AccessLevel getPersistAccessLevel();

    public AccessLevel getUpdateAccessLevel();

    public AccessLevel getReadAccessLevel();

    public void setPersistAccessLevel(AccessLevel accessLevel);

    public void setUpdateAccessLevel(AccessLevel accessLevel);

    public void setReadAccessLevel(AccessLevel accessLevel);

    public void setAccessLevel(AccessLevel accessLevel);

    public FlagSet<UserFieldModifier> getUserModifiers();

    public void setUserModifiers(FlagSet<UserFieldModifier> modifiers);

    public FlagSet<UserFieldModifier> getUserExcludeModifiers();

    public void setUserExcludeModifiers(FlagSet<UserFieldModifier> modifiers);

    public FlagSet<FieldModifier> getModifiers();

//    public void setEffectiveModifiers(FlagSet<FieldModifier> modifiers);
    public boolean isId() throws UPAException;

    public boolean isMain() throws UPAException;

    public boolean isSummary() throws UPAException;

    public boolean is(FieldFilter ff) throws UPAException;

    //    public boolean is(long modifier);
    void setDataType(DataType datatype);

    /**
     * check is this is target or source!!!
     *
     * @param r
     */


    public SearchOperator getSearchOperator();

    public void setSearchOperator(SearchOperator operator);

    public void setTypeTransform(DataTypeTransform transform);

    public DataTypeTransform getTypeTransform();

    /**
     * value of the field for the given instance
     * @param instance object instance
     * @return value of the field
     */
    public Object getValue(Object instance);
    
    /**
     * calls getValue, if the value returned is an Entity will calls getMainValue o the entity. If not will return the result of getValue
     * @param instance instance to get value on
     * @return displayable value
     */
    public Object getMainValue(Object instance);

    public void setValue(Object instance, Object value);

    public void check(Object value);
}
