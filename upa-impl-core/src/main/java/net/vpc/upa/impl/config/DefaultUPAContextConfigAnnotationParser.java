/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.config;

import java.lang.annotation.Annotation;
import java.util.HashMap;
import java.util.Map;
import net.vpc.upa.config.BoolEnum;
import net.vpc.upa.config.Config;
import net.vpc.upa.config.ConnectionConfig;
import net.vpc.upa.config.PersistenceGroupConfig;
import net.vpc.upa.config.PersistenceUnitConfig;
import net.vpc.upa.config.Property;
import net.vpc.upa.config.ScanConfig;
import net.vpc.upa.config.ScanFilter;
import net.vpc.upa.config.UPAContextConfigAnnotationParser;
import net.vpc.upa.exceptions.UPAIllegalArgumentException;
import net.vpc.upa.impl.util.PlatformUtils;
import net.vpc.upa.impl.util.UPAUtils;
import net.vpc.upa.persistence.UPAContextConfig;

/**
 *
 * @author vpc
 */
public class DefaultUPAContextConfigAnnotationParser implements UPAContextConfigAnnotationParser {

    @Override
    public UPAContextConfig parse(Class clazz) {
        UPAContextConfig c = new UPAContextConfig();
        boolean ok = false;
        net.vpc.upa.persistence.PersistenceUnitConfig defaultPersistenceUnit=null;
        net.vpc.upa.persistence.PersistenceGroupConfig defaultPersistenceGroup=null;
        
        for (Annotation annotation : clazz.getAnnotations()) {
            if (annotation instanceof Config) {
                ok = true;
                parse((Config) annotation, c);
            }
            if (annotation instanceof PersistenceGroupConfig) {
                ok = true;
                c.getPersistenceGroups().add(parse((PersistenceGroupConfig) annotation));
            }
            if (annotation instanceof PersistenceUnitConfig) {
                ok = true;
                if (defaultPersistenceGroup == null) {
                    defaultPersistenceGroup = new net.vpc.upa.persistence.PersistenceGroupConfig();
                    defaultPersistenceGroup.setConfigOrder(UPAContextConfig.BOOT_TYPE_ORDER);
                    c.getPersistenceGroups().add(defaultPersistenceGroup);
                }
                parse((PersistenceUnitConfig) annotation);
            }
            if (annotation instanceof ConnectionConfig) {
                ok = true;
                if (defaultPersistenceGroup == null) {
                    defaultPersistenceGroup = new net.vpc.upa.persistence.PersistenceGroupConfig();
                    defaultPersistenceGroup.setConfigOrder(UPAContextConfig.BOOT_TYPE_ORDER);
                    c.getPersistenceGroups().add(defaultPersistenceGroup);
                }
                if (defaultPersistenceUnit == null) {
                    defaultPersistenceUnit = new net.vpc.upa.persistence.PersistenceUnitConfig();
                    defaultPersistenceUnit.setConfigOrder(UPAContextConfig.BOOT_TYPE_ORDER);
                    defaultPersistenceGroup.getPersistenceUnits().add(defaultPersistenceUnit);
                }
                net.vpc.upa.persistence.ConnectionConfig cnx = parse((ConnectionConfig) annotation);
                defaultPersistenceUnit.getConnections().add(cnx);
            }
        }
        if (!ok) {
            throw new UPAIllegalArgumentException("Missing config annotation for " + clazz);
        }
        return c;
    }

    private void parse(Config c, UPAContextConfig config) {
        if (c != null) {
            config.setAutoScan(c.autoScan() == BoolEnum.TRUE ? true : c.autoScan() == BoolEnum.FALSE ? false : null);
            for (ScanConfig scanConfig : c.scan()) {
                config.getFilters().add(new ScanFilter(scanConfig.libs(), scanConfig.types(), scanConfig.propagate() == BoolEnum.TRUE ? true : false, UPAContextConfig.BOOT_TYPE_ORDER));
            }
            for (PersistenceGroupConfig persistenceGroup : c.persistenceGroups()) {
                config.getPersistenceGroups().add(parse(persistenceGroup));
            }
        }
    }

    private net.vpc.upa.persistence.PersistenceGroupConfig parse(PersistenceGroupConfig c) {
        net.vpc.upa.persistence.PersistenceGroupConfig cc = new net.vpc.upa.persistence.PersistenceGroupConfig();
        cc.setConfigOrder(UPAContextConfig.BOOT_TYPE_ORDER);
        cc.setName(c.name());
        cc.setAutoScan(PlatformUtils.toBool(c.autoScan(), null));
        for (PersistenceUnitConfig persistenceUnit : c.persistenceUnits()) {
            cc.getPersistenceUnits().add(parse(persistenceUnit));
        }
        for (ScanConfig scan : c.scan()) {
            cc.getFilters().add(parse(scan));
        }

        net.vpc.upa.persistence.PersistenceUnitConfig defaultPersistenceUnit = null;
        for (ConnectionConfig cnx : c.connections()) {
            if (defaultPersistenceUnit == null) {
                defaultPersistenceUnit = new net.vpc.upa.persistence.PersistenceUnitConfig();
                defaultPersistenceUnit.setConfigOrder(UPAContextConfig.BOOT_TYPE_ORDER);
            }
            defaultPersistenceUnit.getConnections().add(parse(cnx));
        }
        for (ConnectionConfig cnx : c.rootConnections()) {
            if (defaultPersistenceUnit == null) {
                defaultPersistenceUnit = new net.vpc.upa.persistence.PersistenceUnitConfig();
                defaultPersistenceUnit.setConfigOrder(UPAContextConfig.BOOT_TYPE_ORDER);
            }
            defaultPersistenceUnit.getRootConnections().add(parse(cnx));
        }
        cc.setProperties(parse(c.properties()));
        return cc;
    }

    private ScanFilter parse(ScanConfig scan) {
        return new ScanFilter(scan.libs(), scan.types(), PlatformUtils.toBool(scan.propagate(), true), UPAContextConfig.BOOT_TYPE_ORDER);
    }

    private Map<String, Object> parse(Property[] properties) {
        Map<String, Object> m = new HashMap<>();
        for (Property property : properties) {
            m.put(property.name(), UPAUtils.createValue(new net.vpc.upa.Property(property.name(), property.value(), property.valueType(), property.format())));
        }
        return m;
    }

    private net.vpc.upa.persistence.PersistenceUnitConfig parse(PersistenceUnitConfig c) {
        net.vpc.upa.persistence.PersistenceUnitConfig cc = new net.vpc.upa.persistence.PersistenceUnitConfig();
        cc.setConfigOrder(UPAContextConfig.BOOT_TYPE_ORDER);
        cc.setAutoScan(PlatformUtils.toBool(c.autoScan(), null));
        for (ConnectionConfig cnx : c.connections()) {
            cc.getConnections().add(parse(cnx));
        }
        for (ConnectionConfig cnx : c.rootConnections()) {
            cc.getRootConnections().add(parse(cnx));
        }
        cc.setProperties(parse(c.properties()));
        for (ScanConfig scan : c.scan()) {
            cc.addFilter(parse(scan));
        }
        return cc;
    }

    private net.vpc.upa.persistence.ConnectionConfig parse(ConnectionConfig c) {
        net.vpc.upa.persistence.ConnectionConfig cc = new net.vpc.upa.persistence.ConnectionConfig();
        cc.setConnectionString(c.connexionString());
        cc.setPassword(c.password());
        cc.setStructureStrategy(c.structureStrategy());
        cc.setUserName(c.userName());
        Map<String, Object> m = parse(c.properties());
        Map<String, String> ms = new HashMap<>();
        for (String k : m.keySet()) {
            ms.put(k, String.valueOf(m.get(k)));
        }
        cc.setProperties(ms);
        return cc;
    }

}
