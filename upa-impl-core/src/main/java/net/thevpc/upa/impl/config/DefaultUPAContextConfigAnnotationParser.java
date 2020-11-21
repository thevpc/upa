/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package net.thevpc.upa.impl.config;

import java.lang.annotation.Annotation;
import java.util.HashMap;
import java.util.Map;

import net.thevpc.upa.persistence.ConnectionConfig;
import net.thevpc.upa.persistence.PersistenceGroupConfig;
import net.thevpc.upa.persistence.PersistenceUnitConfig;
import net.thevpc.upa.config.BoolEnum;
import net.thevpc.upa.config.Config;
import net.thevpc.upa.config.Property;
import net.thevpc.upa.config.ScanConfig;
import net.thevpc.upa.config.ScanFilter;
import net.thevpc.upa.config.UPAContextConfigAnnotationParser;
import net.thevpc.upa.exceptions.IllegalUPAArgumentException;
import net.thevpc.upa.impl.util.PlatformUtils;
import net.thevpc.upa.impl.util.StringUtils;
import net.thevpc.upa.impl.util.UPAUtils;
import net.thevpc.upa.persistence.UPAContextConfig;

/**
 *
 * @author vpc
 */
public class DefaultUPAContextConfigAnnotationParser implements UPAContextConfigAnnotationParser {

    @Override
    public UPAContextConfig parse(Class clazz) {
        UPAContextConfig c = new UPAContextConfig();
        boolean ok = false;
        PersistenceGroupConfig defaultPersistenceGroup = null;

        for (Annotation annotation : clazz.getAnnotations()) {
            if (annotation instanceof Config) {
                ok = true;
                parse((Config) annotation, c);
            }
            if (annotation instanceof net.thevpc.upa.config.PersistenceGroupConfig) {
                ok = true;
                c.getPersistenceGroups().add(parse((net.thevpc.upa.config.PersistenceGroupConfig) annotation));
            }
            if (annotation instanceof net.thevpc.upa.config.PersistenceUnitConfig) {
                ok = true;
                getOrAddDefaultPersistenceGroup(c).addPersistenceUnit(parse((net.thevpc.upa.config.PersistenceUnitConfig) annotation));
            }
            if (annotation instanceof net.thevpc.upa.config.ConnectionConfig) {
                ok = true;
                ConnectionConfig cnx = parse((net.thevpc.upa.config.ConnectionConfig) annotation);
                getOrAddDefaultPersistenceUnit(c).getConnections().add(cnx);
            }
        }
        if (!ok) {
            throw new IllegalUPAArgumentException("Missing config annotation for " + clazz);
        }
        return c;
    }

    private PersistenceGroupConfig getOrAddDefaultPersistenceGroup(UPAContextConfig c) {
        PersistenceGroupConfig defaultPersistenceGroup = null;
        for (PersistenceGroupConfig persistenceGroup : c.getPersistenceGroups()) {
            if (StringUtils.isNullOrEmpty(persistenceGroup.getName())) {
                defaultPersistenceGroup = persistenceGroup;
                break;
            }
        }
        if (defaultPersistenceGroup == null) {
            defaultPersistenceGroup = new PersistenceGroupConfig();
            defaultPersistenceGroup.setConfigOrder(UPAContextConfig.BOOT_TYPE_ORDER);
            c.getPersistenceGroups().add(defaultPersistenceGroup);
        }
        return defaultPersistenceGroup;
    }

    private PersistenceUnitConfig getOrAddDefaultPersistenceUnit(UPAContextConfig c) {
        return getOrAddDefaultPersistenceUnit(getOrAddDefaultPersistenceGroup(c));
    }

    private PersistenceUnitConfig getOrAddDefaultPersistenceUnit(PersistenceGroupConfig c) {
        PersistenceUnitConfig defaultPersistenceUnit = null;
        for (PersistenceUnitConfig pu : c.getPersistenceUnits()) {
            if (StringUtils.isNullOrEmpty(pu.getName())) {
                defaultPersistenceUnit = pu;
                break;
            }
        }
        if (defaultPersistenceUnit == null) {
            defaultPersistenceUnit = new PersistenceUnitConfig();
            defaultPersistenceUnit.setConfigOrder(UPAContextConfig.BOOT_TYPE_ORDER);
            c.getPersistenceUnits().add(defaultPersistenceUnit);
        }
        return defaultPersistenceUnit;
    }

    private void parse(Config c, UPAContextConfig config) {
        if (c != null) {
            Boolean tt = c.autoScan() == BoolEnum.TRUE ? Boolean.TRUE : c.autoScan() == BoolEnum.FALSE ? Boolean.FALSE : null;
            config.setAutoScan(tt);
            for (ScanConfig scanConfig : c.scan()) {
                config.getFilters().add(new ScanFilter(scanConfig.libs(), scanConfig.types(), scanConfig.propagate() == BoolEnum.TRUE ? true : false, UPAContextConfig.BOOT_TYPE_ORDER));
            }
            for (net.thevpc.upa.config.PersistenceGroupConfig persistenceGroup : c.persistenceGroups()) {
                config.getPersistenceGroups().add(parse(persistenceGroup));
            }
            if (c.persistenceUnits().length > 0) {
                PersistenceGroupConfig defaultPersistenceGroup = getOrAddDefaultPersistenceGroup(config);
                for (net.thevpc.upa.config.PersistenceUnitConfig persistenceUnit : c.persistenceUnits()) {
                    defaultPersistenceGroup.addPersistenceUnit(parse(persistenceUnit));
                }
            }
        }
    }

    private PersistenceGroupConfig parse(net.thevpc.upa.config.PersistenceGroupConfig c) {
        PersistenceGroupConfig cc = new PersistenceGroupConfig();
        cc.setConfigOrder(UPAContextConfig.BOOT_TYPE_ORDER);
        cc.setName(c.name());
        cc.setAutoScan(PlatformUtils.toBool(c.autoScan(), null));
        cc.setInheritScanFilters(PlatformUtils.toBool(c.inheritScanFilters(), null));
        for (net.thevpc.upa.config.PersistenceUnitConfig persistenceUnit : c.persistenceUnits()) {
            cc.getPersistenceUnits().add(parse(persistenceUnit));
        }
        for (ScanConfig scan : c.scan()) {
            cc.getFilters().add(parse(scan));
        }

        PersistenceUnitConfig defaultPersistenceUnit = null;
        for (net.thevpc.upa.config.ConnectionConfig cnx : c.connections()) {
            if (defaultPersistenceUnit == null) {
                defaultPersistenceUnit = new PersistenceUnitConfig();
                defaultPersistenceUnit.setConfigOrder(UPAContextConfig.BOOT_TYPE_ORDER);
            }
            defaultPersistenceUnit.getConnections().add(parse(cnx));
        }
        for (net.thevpc.upa.config.ConnectionConfig cnx : c.rootConnections()) {
            if (defaultPersistenceUnit == null) {
                defaultPersistenceUnit = new PersistenceUnitConfig();
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
            m.put(property.name(), UPAUtils.createValue(new net.thevpc.upa.Property(property.name(), property.value(), property.valueType(), property.format())));
        }
        return m;
    }

    private PersistenceUnitConfig parse(net.thevpc.upa.config.PersistenceUnitConfig c) {
        PersistenceUnitConfig cc = new PersistenceUnitConfig();
        cc.setConfigOrder(UPAContextConfig.BOOT_TYPE_ORDER);
        cc.setAutoScan(PlatformUtils.toBool(c.autoScan(), null));
        cc.setInheritScanFilters(PlatformUtils.toBool(c.inheritScanFilters(), null));
        for (net.thevpc.upa.config.ConnectionConfig cnx : c.connections()) {
            cc.getConnections().add(parse(cnx));
        }
        for (net.thevpc.upa.config.ConnectionConfig cnx : c.rootConnections()) {
            cc.getRootConnections().add(parse(cnx));
        }
        cc.setProperties(parse(c.properties()));
        for (ScanConfig scan : c.scan()) {
            cc.addFilter(parse(scan));
        }
        return cc;
    }

    private ConnectionConfig parse(net.thevpc.upa.config.ConnectionConfig c) {
        ConnectionConfig cc = new ConnectionConfig();
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
