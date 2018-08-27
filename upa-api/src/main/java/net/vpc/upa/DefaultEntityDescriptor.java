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

import java.util.ArrayList;
import java.util.HashMap;

import java.util.List;
import java.util.Map;

/**
 * Created by vpc on 7/20/15.
 */
public class DefaultEntityDescriptor implements EntityDescriptor {

    private String name;

    private String shortName;

    private Class idType;

    private Class entityType;

    private FlagSet<EntityModifier> modifiers;

    private FlagSet<EntityModifier> excludeModifiers;

    private String packagePath;

    private String listOrder;

    private String archivingOrder;

    private int position;

    private List<EntityExtensionDefinition> entityExtensions;

    private Object source;

    public List<FieldDescriptor> fieldDescriptors;

    public List<IndexDescriptor> indexDescriptors;

    public List<RelationshipDescriptor> relationshipDescriptors;

    public Map<String, Object> properties;

    public DefaultEntityDescriptor() {

    }

    public DefaultEntityDescriptor(EntityDescriptor other) {
        copyFrom(other);
    }

    public DefaultEntityDescriptor copyFrom(EntityDescriptor other) {
        if (other != null) {
            setName(other.getName());
            setArchivingOrder(other.getArchivingOrder());
            setListOrder(other.getListOrder());
            setPackagePath(other.getPackagePath());
            setShortName(other.getShortName());
            setEntityType(other.getEntityType());
            setIdType(other.getIdType());
            setModifiers(other.getModifiers());
            setPosition(other.getPosition());
            setSource(other.getSource());

            List<EntityExtensionDefinition> e = other.getEntityExtensions();
            if (e != null) {
                for (EntityExtensionDefinition item : e) {
                    addEntityExtension(item);
                }
            }
            List<IndexDescriptor> il = other.getIndexDescriptors();
            if (il != null) {
                for (IndexDescriptor item : il) {
                    addIndexDescriptor(new DefaultIndexDescriptor(item));
                }
            }
            List<FieldDescriptor> fl = other.getFieldDescriptors();
            if (fl != null) {
                for (FieldDescriptor item : fl) {
                    addFieldDescriptor(new DefaultFieldDescriptor(item));
                }
            }
            List<RelationshipDescriptor> rl = other.getRelationshipDescriptors();
            if (rl != null) {
                for (RelationshipDescriptor item : rl) {
                    addRelationshipDescriptor(new DefaultRelationshipDescriptor(item));
                }
            }
            Map<String, Object> p = other.getProperties();
            if (p != null) {
                addProperties(p);
            }
        }
        return this;
    }

    public String getName() {
        return name;
    }

    public DefaultEntityDescriptor setName(String name) {
        this.name = name;
        return this;
    }

    public String getShortName() {
        return shortName;
    }

    public DefaultEntityDescriptor setShortName(String shortName) {
        this.shortName = shortName;
        return this;
    }

    public Class getIdType() {
        return idType;
    }

    public DefaultEntityDescriptor setIdType(Class idType) {
        this.idType = idType;
        return this;
    }

    public Class getEntityType() {
        return entityType;
    }

    public DefaultEntityDescriptor setEntityType(Class entityType) {
        this.entityType = entityType;
        return this;
    }

    public FlagSet<EntityModifier> getModifiers() {
        return modifiers;
    }

    public DefaultEntityDescriptor setModifiers(FlagSet<EntityModifier> modifiers) {
        this.modifiers = modifiers;
        return this;
    }

    public FlagSet<EntityModifier> getExcludeModifiers() {
        return excludeModifiers;
    }

    public DefaultEntityDescriptor setExcludeModifiers(FlagSet<EntityModifier> excludeModifiers) {
        this.excludeModifiers = excludeModifiers;
        return this;
    }

    public String getPackagePath() {
        return packagePath;
    }

    public DefaultEntityDescriptor setPackagePath(String packagePath) {
        this.packagePath = packagePath;
        return this;
    }

    public int getPosition() {
        return position;
    }

    public DefaultEntityDescriptor setPosition(int position) {
        this.position = position;
        return this;
    }

    public List<EntityExtensionDefinition> getEntityExtensions() {
        return entityExtensions;
    }

    public DefaultEntityDescriptor setEntityExtensions(List<EntityExtensionDefinition> entityExtensions) {
        this.entityExtensions = entityExtensions;
        return this;
    }

    public DefaultEntityDescriptor addEntityExtension(EntityExtensionDefinition d) {
        if (d != null) {
            if (this.entityExtensions == null) {
                this.entityExtensions = new ArrayList<EntityExtensionDefinition>();
            }
            this.entityExtensions.add(d);
        }
        return this;
    }

    public DefaultEntityDescriptor removeAllEntityExtensions() {
        if (this.entityExtensions != null) {
            this.entityExtensions.clear();
        }
        return this;
    }

    public DefaultEntityDescriptor removeEntityExtension(EntityExtensionDefinition d) {
        if (d != null) {
            if (this.entityExtensions != null) {
                this.entityExtensions.remove(d);
            }
        }
        return this;
    }

    public Object getSource() {
        return source;
    }

    public DefaultEntityDescriptor setSource(Object source) {
        this.source = source;
        return this;
    }

    public List<FieldDescriptor> getFieldDescriptors() {
        return fieldDescriptors;
    }

    public DefaultEntityDescriptor setFieldDescriptors(List<FieldDescriptor> fieldDescriptors) {
        this.fieldDescriptors = fieldDescriptors;
        return this;
    }

    public DefaultEntityDescriptor addFieldDescriptor(FieldDescriptor field) {
        if (field != null) {
            if (this.fieldDescriptors == null) {
                this.fieldDescriptors = new ArrayList<FieldDescriptor>();
            }
            this.fieldDescriptors.add(field);
        }
        return this;
    }

    public DefaultEntityDescriptor removeFieldDescriptor(FieldDescriptor field) {
        if (field != null) {
            if (this.fieldDescriptors != null) {
                this.fieldDescriptors.remove(field);
            }
        }
        return this;
    }

    public DefaultEntityDescriptor removeAllsFieldDescriptors() {
        if (this.fieldDescriptors != null) {
            this.fieldDescriptors.clear();
        }
        return this;
    }

    public List<IndexDescriptor> getIndexDescriptors() {
        return indexDescriptors;
    }

    public DefaultEntityDescriptor setIndexDescriptors(List<IndexDescriptor> indexDescriptors) {
        this.indexDescriptors = indexDescriptors;
        return this;
    }

    public DefaultEntityDescriptor addIndexDescriptor(IndexDescriptor index) {
        if (index != null) {
            if (this.indexDescriptors == null) {
                this.indexDescriptors = new ArrayList<IndexDescriptor>();
            }
            this.indexDescriptors.add(index);
        }
        return this;
    }

    public DefaultEntityDescriptor removeIndexDescriptor(IndexDescriptor index) {
        if (index != null) {
            if (this.indexDescriptors != null) {
                this.indexDescriptors.remove(index);
            }
        }
        return this;
    }

    public DefaultEntityDescriptor removeAllIndexDescriptors() {
        if (this.indexDescriptors != null) {
            this.indexDescriptors.clear();
        }
        return this;
    }

    public List<RelationshipDescriptor> getRelationshipDescriptors() {
        return relationshipDescriptors;
    }

    public DefaultEntityDescriptor setRelationshipDescriptors(List<RelationshipDescriptor> relationshipDescriptors) {
        this.relationshipDescriptors = relationshipDescriptors;
        return this;
    }

    public DefaultEntityDescriptor addRelationshipDescriptor(RelationshipDescriptor relationship) {
        if (relationship != null) {
            if (this.relationshipDescriptors == null) {
                this.relationshipDescriptors = new ArrayList<RelationshipDescriptor>();
            }
            this.relationshipDescriptors.add(relationship);
        }
        return this;
    }

    public DefaultEntityDescriptor removeRelationshipDescriptor(RelationshipDescriptor relationship) {
        if (relationship != null) {
            if (this.relationshipDescriptors != null) {
                this.relationshipDescriptors.remove(relationship);
            }
        }
        return this;
    }

    public DefaultEntityDescriptor removeAllRelationshipDescriptors() {
        if (this.relationshipDescriptors != null) {
            this.relationshipDescriptors.clear();
        }
        return this;
    }

    @Override
    public String getListOrder() {
        return listOrder;
    }

    public DefaultEntityDescriptor setListOrder(String listOrder) {
        this.listOrder = listOrder;
        return this;
    }

    public String getArchivingOrder() {
        return archivingOrder;
    }

    public DefaultEntityDescriptor setArchivingOrder(String archivingOrder) {
        this.archivingOrder = archivingOrder;
        return this;
    }

    public Map<String, Object> getProperties() {
        return properties;
    }

    public DefaultEntityDescriptor addProperties(Map<String, Object> other) {
        if (other != null) {
            if (properties == null) {
                properties = new HashMap<String, Object>();
            }
            properties.putAll(other);
        }
        return this;
    }

    public DefaultEntityDescriptor setProperties(Map<String, Object> properties) {
        this.properties = properties;
        return this;
    }

    @Override
    public String toString() {
        return "DefaultEntityDescriptor{"
                + "name='" + name + '\''
                + ", idType=" + idType
                + ", entityType=" + entityType
                + ", source=" + source
                + ", packagePath='" + packagePath + '\''
                + ", modifiers=" + modifiers
                + '}';
    }
}
