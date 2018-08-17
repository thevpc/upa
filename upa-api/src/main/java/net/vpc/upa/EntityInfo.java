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

import java.util.List;

public class EntityInfo extends PersistenceUnitPartInfo{
    private List<EntityPartInfo> children;
    private EntityModifier[] modifiers;
    private boolean hierarchical;
    private boolean hasAssociatedView;
    private boolean system;
    private boolean singleton;
    private boolean union;
    private boolean view;
    private String[] manyToOneRelationships;
    private String[] oneToManyRelationships;
    private List<IndexInfo> indexes;
    private String compositionRelationship;
    private String parentEntity;

    public EntityInfo() {
        super("entity");
    }

    public boolean isSingleton() {
        return singleton;
    }

    public void setSingleton(boolean singleton) {
        this.singleton = singleton;
    }

    public boolean isUnion() {
        return union;
    }

    public void setUnion(boolean union) {
        this.union = union;
    }

    public boolean isView() {
        return view;
    }

    public void setView(boolean view) {
        this.view = view;
    }

    public EntityModifier[] getModifiers() {
        return modifiers;
    }

    public void setModifiers(EntityModifier[] modifiers) {
        this.modifiers = modifiers;
    }

    public boolean isHierarchical() {
        return hierarchical;
    }

    public void setHierarchical(boolean hierarchical) {
        this.hierarchical = hierarchical;
    }

    public boolean isHasAssociatedView() {
        return hasAssociatedView;
    }

    public void setHasAssociatedView(boolean hasAssociatedView) {
        this.hasAssociatedView = hasAssociatedView;
    }

    public boolean isSystem() {
        return system;
    }

    public void setSystem(boolean system) {
        this.system = system;
    }

    public String[] getManyToOneRelationships() {
        return manyToOneRelationships;
    }

    public void setManyToOneRelationships(String[] manyToOneRelationships) {
        this.manyToOneRelationships = manyToOneRelationships;
    }

    public String[] getOneToManyRelationships() {
        return oneToManyRelationships;
    }

    public void setOneToManyRelationships(String[] oneToManyRelationships) {
        this.oneToManyRelationships = oneToManyRelationships;
    }

    public List<IndexInfo> getIndexes() {
        return indexes;
    }

    public void setIndexes(List<IndexInfo> indexes) {
        this.indexes = indexes;
    }

    public String getCompositionRelationship() {
        return compositionRelationship;
    }

    public void setCompositionRelationship(String compositionRelationship) {
        this.compositionRelationship = compositionRelationship;
    }

    public String getParentEntity() {
        return parentEntity;
    }

    public void setParentEntity(String parentEntity) {
        this.parentEntity = parentEntity;
    }

    public List<EntityPartInfo> getChildren() {
        return children;
    }

    public void setChildren(List<EntityPartInfo> children) {
        this.children = children;
    }
}
