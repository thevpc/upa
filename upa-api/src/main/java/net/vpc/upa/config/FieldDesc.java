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
package net.vpc.upa.config;

import net.vpc.upa.FlagSet;
import net.vpc.upa.FlagSets;
import net.vpc.upa.UnspecifiedValue;
import net.vpc.upa.UserFieldModifier;
import net.vpc.upa.types.DataType;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 8/28/12 10:42 PM
 */
public class FieldDesc {

    private int configOrder = 100;
    private String name;
    private DataType dataType;
    private FlagSet<UserFieldModifier> modifiers = FlagSets.noneOf(UserFieldModifier.class);
    private FlagSet<UserFieldModifier> excludeModifiers = FlagSets.noneOf(UserFieldModifier.class);
    private net.vpc.upa.Formula persistFormula;
    private net.vpc.upa.Formula updateFormula;
    private boolean persistFormulaSet;
    private boolean updateFormulaSet;
    private Object defaultValue;
    private boolean defaultValueSet;
    private Object unspecifiedValue = UnspecifiedValue.DEFAULT;
    private boolean unspecifiedValueSet;

    public String getName() {
        return name;
    }

    public boolean isPersistFormulaSet() {
        return persistFormulaSet;
    }

    public FieldDesc setPersistFormulaSet(boolean persistFormulaSet) {
        this.persistFormulaSet = persistFormulaSet;
        if (!persistFormulaSet) {
            persistFormula = null;
        }
        return this;
    }

    public boolean isUpdateFormulaSet() {
        return updateFormulaSet;
    }

    public FieldDesc setUpdateFormulaSet(boolean updateFormulaSet) {
        this.updateFormulaSet = updateFormulaSet;
        if (!updateFormulaSet) {
            updateFormula = null;
        }
        return this;
    }

    public boolean isDefaultValueSet() {
        return defaultValueSet;
    }

    public FieldDesc setDefaultValueSet(boolean defaultValueSet) {
        this.defaultValueSet = defaultValueSet;
        if (!defaultValueSet) {
            defaultValue = null;
        }
        return this;
    }

    public boolean isUnspecifiedValueSet() {
        return unspecifiedValueSet;
    }

    public FieldDesc setUnspecifiedValueSet(boolean unspecifiedValueSet) {
        this.unspecifiedValueSet = unspecifiedValueSet;
        if (!unspecifiedValueSet) {
            unspecifiedValue = UnspecifiedValue.DEFAULT;
        }
        return this;
    }

    public FieldDesc setName(String name) {
        this.name = name;
        return this;
    }

    public FlagSet<UserFieldModifier> getModifiers() {
        return modifiers;
    }

    public FieldDesc setModifiers(FlagSet<UserFieldModifier> modifiers) {
        this.modifiers = modifiers;
        return this;
    }

    public FlagSet<UserFieldModifier> getExcludeModifiers() {
        return excludeModifiers;
    }

    public FieldDesc setExcludeModifiers(FlagSet<UserFieldModifier> modifiers) {
        this.excludeModifiers = modifiers;
        return this;
    }

    public FieldDesc addModifiers(FlagSet<UserFieldModifier> modifiers) {
        return setModifiers(getModifiers().addAll(modifiers));
    }

    public FieldDesc removeModifiers(FlagSet<UserFieldModifier> modifiers) {
        return setModifiers(getModifiers().removeAll(modifiers));
    }

    public FieldDesc addExcludeModifiers(FlagSet<UserFieldModifier> modifiers) {
        return setExcludeModifiers(getExcludeModifiers().addAll(modifiers));
    }

    public FieldDesc removeExcludeModifiers(FlagSet<UserFieldModifier> modifiers) {
        return setExcludeModifiers(getExcludeModifiers().removeAll(modifiers));
    }

    public net.vpc.upa.Formula getPersistFormula() {
        return persistFormula;
    }

    public net.vpc.upa.Formula getUpdateFormula() {
        return updateFormula;
    }

    public FieldDesc setFormula(net.vpc.upa.Formula formula) {
        setPersistFormula(formula);
        setUpdateFormula(formula);
        return this;
    }

    public FieldDesc setPersistFormula(net.vpc.upa.Formula persistFormula) {
        this.persistFormula = persistFormula;
        this.persistFormulaSet = true;
        return this;
    }

    public FieldDesc setUpdateFormula(net.vpc.upa.Formula updateFormula) {
        this.updateFormula = updateFormula;
        this.updateFormulaSet = true;
        return this;
    }

    public Object getDefaultValue() {
        return defaultValue;
    }

    public FieldDesc setDefaultValue(Object defaultValue) {
        this.defaultValue = defaultValue;
        this.defaultValueSet = true;
        return this;
    }

    public DataType getDataType() {
        return dataType;
    }

    public FieldDesc setDataType(DataType type) {
        this.dataType = type;
        return this;
    }

    public Object getUnspecifiedValue() {
        return unspecifiedValue;
    }

    public void setUnspecifiedValue(Object unspecifiedValue) {
        this.unspecifiedValue = unspecifiedValue;
        this.unspecifiedValueSet = true;
    }

    public int getConfigOrder() {
        return configOrder;
    }

    public void setConfigOrder(int configOrder) {
        this.configOrder = configOrder;
    }
}
