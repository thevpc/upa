package net.vpc.upa.impl;

import net.vpc.upa.extensions.EntityExtensionDefinition;
import net.vpc.upa.persistence.EntityExtension;

/**
* @author Taha BEN SALAH <taha.bensalah@gmail.com>
* @creationdate 1/5/13 9:47 PM
*/
class ExtensionSupportInfo {
    private Class<? extends EntityExtensionDefinition> entityExtensionDefinitionType;
    private EntityExtensionDefinition extension;
    private EntityExtension support;

    ExtensionSupportInfo(Class<? extends EntityExtensionDefinition> entityExtensionDefinitionType, EntityExtensionDefinition extension, EntityExtension support) {
        this.setEntityExtensionDefinitionType(entityExtensionDefinitionType);
        this.setExtension(extension);
        this.setSupport(support);
    }

    public Class<? extends EntityExtensionDefinition> getEntityExtensionDefinitionType() {
        return entityExtensionDefinitionType;
    }

    public void setEntityExtensionDefinitionType(Class<? extends EntityExtensionDefinition> entityExtensionDefinitionType) {
        this.entityExtensionDefinitionType = entityExtensionDefinitionType;
    }

    public EntityExtensionDefinition getExtension() {
        return extension;
    }

    public void setExtension(EntityExtensionDefinition extension) {
        this.extension = extension;
    }

    public EntityExtension getSupport() {
        return support;
    }

    public void setSupport(EntityExtension support) {
        this.support = support;
    }
}
