package net.vpc.upa.impl;

import net.vpc.upa.extensions.EntityExtensionDefinition;
import net.vpc.upa.persistence.EntityExtension;

import java.util.*;
import net.vpc.upa.impl.util.PlatformUtils;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 8/29/12 10:52 PM
 */
public class DefaultEntityExtensionManager {
    private Map<Class<? extends EntityExtensionDefinition>, List<ExtensionSupportInfo>> extensionsMap = new HashMap<Class<? extends EntityExtensionDefinition>, List<ExtensionSupportInfo>>();
    private Map<Class<? extends EntityExtension>, List<ExtensionSupportInfo>> extensionsSupportMap = new HashMap<Class<? extends EntityExtension>, List<ExtensionSupportInfo>>();
    private Map<EntityExtensionDefinition, ExtensionSupportInfo> objectMap = new HashMap<EntityExtensionDefinition, ExtensionSupportInfo>();

    public void addEntityExtension(Class<? extends EntityExtensionDefinition> specType, Class<? extends EntityExtension> supportType, EntityExtensionDefinition specObject, EntityExtension extensionSupport) {

        ExtensionSupportInfo tss = new ExtensionSupportInfo(specType, specObject, extensionSupport);
        objectMap.put(specObject, tss);

        List<ExtensionSupportInfo> list = extensionsMap.get(specType);
        if (list == null) {
            list = new ArrayList<ExtensionSupportInfo>();
            extensionsMap.put(specType, list);
        }
        list.add(tss);

        List<ExtensionSupportInfo> list2 = extensionsSupportMap.get(supportType);
        if (list2 == null) {
            list2 = new ArrayList<ExtensionSupportInfo>();
            extensionsSupportMap.put(supportType, list2);
        }
        list2.add(tss);
    }

    public void removeEntityExtension(Class<? extends EntityExtensionDefinition> specType, EntityExtensionDefinition specObject) {
        objectMap.remove(specObject);
        List<ExtensionSupportInfo> list = extensionsMap.get(specType);
        if (list != null) {
            for (int i = list.size();i>=0; i--) {
                ExtensionSupportInfo tss = list.get(i);
                if (tss.getExtension().equals(specObject)) {
                    list.remove(i);
                }
            }
        }
        for (Map.Entry<Class<? extends EntityExtension>, List<ExtensionSupportInfo>> e : new HashMap<Class<? extends EntityExtension>, List<ExtensionSupportInfo>>(extensionsSupportMap).entrySet()) {
            List<ExtensionSupportInfo> tss2 = e.getValue();
            for (int i2 = tss2.size(); i2>=0; i2--) {
                ExtensionSupportInfo tss3 = tss2.get(i2);
                if (tss3.getExtension().equals(specObject)) {
                    tss2.remove(i2);
                }
            }
            if (tss2.isEmpty()) {
                extensionsSupportMap.remove(e.getKey());
            }
        }

        for (Iterator<Map.Entry<Class<? extends EntityExtension>, List<ExtensionSupportInfo>>> i = extensionsSupportMap.entrySet().iterator(); i.hasNext(); ) {
        }
    }

    public List<EntityExtensionDefinition> getEntityExtensions() {
        ArrayList<EntityExtensionDefinition> list = new ArrayList<EntityExtensionDefinition>();
        for (List<ExtensionSupportInfo> entitySpecs : extensionsMap.values()) {
            for (ExtensionSupportInfo tss : entitySpecs) {
                list.add(tss.getExtension());
            }
        }
        return list;
    }

    public List<EntityExtension> getEntityExtensionSupports() {
        ArrayList<EntityExtension> list = new ArrayList<EntityExtension>();
        for (List<ExtensionSupportInfo> entitySpecs : extensionsSupportMap.values()) {
            for (ExtensionSupportInfo tss : entitySpecs) {
                list.add(tss.getSupport());
            }
        }
        return list;
    }

    public <S extends EntityExtensionDefinition> List<S> getEntityExtensions(Class<S> type) {
        List<S> list = new ArrayList<S>();
        List<ExtensionSupportInfo> entitySpecs = extensionsMap.get(type);
        if (entitySpecs == null) {
            return PlatformUtils.emptyList();
        }
        for (ExtensionSupportInfo tss : entitySpecs) {
            list.add((S) tss.getExtension());
        }
        return list;
    }

    public <S extends EntityExtension> List<S> getEntityExtensionSupports(Class<S> type) {
        List<S> list = new ArrayList<S>();
        List<ExtensionSupportInfo> entitySpecs = extensionsSupportMap.get(type);
        if (entitySpecs == null) {
            return PlatformUtils.emptyList();
        }
        for (ExtensionSupportInfo tss : entitySpecs) {
            list.add((S) tss.getSupport());
        }
        return list;
    }


}
