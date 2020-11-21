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

/**
 * 
 * @author vpc
 */
public abstract class FieldInfo extends EntityItemInfo {
    private DataTypeInfo dataType;
    private final String kind;
    private PropertyAccessType propertyAccessType;
    private AccessLevel persistAccessLevel;
    private AccessLevel updateAccessLevel;
    private AccessLevel readAccessLevel;
    private ProtectionLevel persistProtectionLevel;
    private ProtectionLevel updateProtectionLevel;
    private ProtectionLevel readProtectionLevel;
    private AccessLevel effectivePersistAccessLevel;
    private AccessLevel effectiveUpdateAccessLevel;
    private AccessLevel effectiveReadAccessLevel;
    private FieldModifier[] modifiers;
    private boolean id;
    private boolean main;
    private boolean system;
    private boolean summary;
    private boolean manyToOne;
    private boolean generatedId;
    private String manyToOneRelationship;

    public FieldInfo(String kind) {
        super("field");
        this.kind=kind;
    }

    public String getKind() {
        return kind;
    }

    public void setKind(String kind) {
    }

    public DataTypeInfo getDataType() {
        return dataType;
    }

    public void setDataType(DataTypeInfo dataType) {
        this.dataType = dataType;
    }

    public PropertyAccessType getPropertyAccessType() {
        return propertyAccessType;
    }

    public void setPropertyAccessType(PropertyAccessType propertyAccessType) {
        this.propertyAccessType = propertyAccessType;
    }

    public AccessLevel getPersistAccessLevel() {
        return persistAccessLevel;
    }

    public void setPersistAccessLevel(AccessLevel persistAccessLevel) {
        this.persistAccessLevel = persistAccessLevel;
    }

    public AccessLevel getUpdateAccessLevel() {
        return updateAccessLevel;
    }

    public void setUpdateAccessLevel(AccessLevel updateAccessLevel) {
        this.updateAccessLevel = updateAccessLevel;
    }

    public AccessLevel getReadAccessLevel() {
        return readAccessLevel;
    }

    public void setReadAccessLevel(AccessLevel readAccessLevel) {
        this.readAccessLevel = readAccessLevel;
    }

    public FieldModifier[] getModifiers() {
        return modifiers;
    }

    public void setModifiers(FieldModifier[] modifiers) {
        this.modifiers = modifiers;
    }

    public boolean isId() {
        return id;
    }

    public void setId(boolean id) {
        this.id = id;
    }

    public boolean isMain() {
        return main;
    }

    public void setMain(boolean main) {
        this.main = main;
    }

    public boolean isSummary() {
        return summary;
    }

    public void setSummary(boolean summary) {
        this.summary = summary;
    }

    public boolean isManyToOne() {
        return manyToOne;
    }

    public void setManyToOne(boolean manyToOne) {
        this.manyToOne = manyToOne;
    }

    public boolean isGeneratedId() {
        return generatedId;
    }

    public void setGeneratedId(boolean generatedId) {
        this.generatedId = generatedId;
    }

    public String getManyToOneRelationship() {
        return manyToOneRelationship;
    }

    public void setManyToOneRelationship(String manyToOneRelationship) {
        this.manyToOneRelationship = manyToOneRelationship;
    }

    public ProtectionLevel getPersistProtectionLevel() {
        return persistProtectionLevel;
    }

    public void setPersistProtectionLevel(ProtectionLevel persistProtectionLevel) {
        this.persistProtectionLevel = persistProtectionLevel;
    }

    public ProtectionLevel getUpdateProtectionLevel() {
        return updateProtectionLevel;
    }

    public void setUpdateProtectionLevel(ProtectionLevel updateProtectionLevel) {
        this.updateProtectionLevel = updateProtectionLevel;
    }

    public ProtectionLevel getReadProtectionLevel() {
        return readProtectionLevel;
    }

    public void setReadProtectionLevel(ProtectionLevel readProtectionLevel) {
        this.readProtectionLevel = readProtectionLevel;
    }

    public AccessLevel getEffectivePersistAccessLevel() {
        return effectivePersistAccessLevel;
    }

    public void setEffectivePersistAccessLevel(AccessLevel effectivePersistAccessLevel) {
        this.effectivePersistAccessLevel = effectivePersistAccessLevel;
    }

    public AccessLevel getEffectiveUpdateAccessLevel() {
        return effectiveUpdateAccessLevel;
    }

    public void setEffectiveUpdateAccessLevel(AccessLevel effectiveUpdateAccessLevel) {
        this.effectiveUpdateAccessLevel = effectiveUpdateAccessLevel;
    }

    public AccessLevel getEffectiveReadAccessLevel() {
        return effectiveReadAccessLevel;
    }

    public void setEffectiveReadAccessLevel(AccessLevel effectiveReadAccessLevel) {
        this.effectiveReadAccessLevel = effectiveReadAccessLevel;
    }

    public boolean isSystem() {
        return system;
    }

    public void setSystem(boolean system) {
        this.system = system;
    }
}
