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

    void setPropertyAccessType(PropertyAccessType value);

    PropertyAccessType getPropertyAccessType();

    void setUnspecifiedValue(Object o);

    Object getUnspecifiedValue();

    /**
     * should return a valid value of UnspecifiedValue. Actually, if
     * getUnspecifiedValue() returns UnspecifiedValue.DEFAULT. this method would
     * return type's default value.
     *
     * @return
     */
    Object getUnspecifiedValueDecoded();

    boolean isUnspecifiedValue(Object value);

    void setDefaultObject(Object o);

    Object getDefaultValue();

    Object getDefaultObject();

    List<Relationship> getManyToOneRelationships();

    void setFormula(String formula);

    void setFormula(Formula formula);

    void setPersistFormula(String formula);

    void setPersistFormula(Formula formula);

    Formula getPersistFormula();

    int getPersistFormulaOrder();

    void setFormulaOrder(int order);

    void setPersistFormulaOrder(int order);

    Formula getUpdateFormula();

    int getUpdateFormulaOrder();

    void setUpdateFormula(String formula);

    void setUpdateFormula(Formula formula);

    void setUpdateFormulaOrder(int order);

    Formula getSelectFormula();

    void setSelectFormula(String formula);

    void setSelectFormula(Formula formula);

    //    boolean isRequired() throws UPAException;
    DataType getDataType();

    AccessLevel getPersistAccessLevel();

    AccessLevel getUpdateAccessLevel();

    AccessLevel getReadAccessLevel();

    void setPersistAccessLevel(AccessLevel accessLevel);

    void setUpdateAccessLevel(AccessLevel accessLevel);

    void setReadAccessLevel(AccessLevel accessLevel);

    void setAccessLevel(AccessLevel accessLevel);

    FlagSet<UserFieldModifier> getUserModifiers();

    void setUserModifiers(FlagSet<UserFieldModifier> modifiers);

    FlagSet<UserFieldModifier> getUserExcludeModifiers();

    void setUserExcludeModifiers(FlagSet<UserFieldModifier> modifiers);

    FlagSet<FieldModifier> getModifiers();

//    void setEffectiveModifiers(FlagSet<FieldModifier> modifiers);
    boolean isId() throws UPAException;

    boolean isGeneratedId() throws UPAException;

    boolean isMain() throws UPAException;

    boolean isSummary() throws UPAException;

    boolean is(FieldFilter filter) throws UPAException;

    //    boolean is(long modifier);
    void setDataType(DataType datatype);

    SearchOperator getSearchOperator();

    void setSearchOperator(SearchOperator operator);

    void setTypeTransform(DataTypeTransform transform);

    DataTypeTransform getTypeTransform();

    /**
     * value of the field for the given instance
     * @param instance object instance
     * @return value of the field
     */
    Object getValue(Object instance);
    
    /**
     * calls getValue, if the value returned is an Entity will calls getMainValue o the entity. If not will return the result of getValue
     * @param instance instance to get value on
     * @return displayable value
     */
    Object getMainValue(Object instance);

    void setValue(Object instance, Object value);

    void check(Object value);

    int getPreferredIndex();
    void setPreferredIndex(int preferredIndex);
}
