/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.thevpc.upa.impl.config.decorations;

import net.thevpc.upa.config.Decoration;
import net.thevpc.upa.config.DecorationTarget;
import net.thevpc.upa.config.DecorationSourceType;
import net.thevpc.upa.config.DecorationValue;

import java.util.HashMap;
import java.util.Map;

import net.thevpc.upa.config.ConfigAction;
import net.thevpc.upa.config.ConfigInfo;
import net.thevpc.upa.config.ItemConfig;
import net.thevpc.upa.impl.util.PlatformUtils;

/**
 * @author taha.bensalah@gmail.com
 */
public final class SimpleDecoration extends AbstractDecoration {

    private DecorationSourceType decorationSourceType;
    private DecorationTarget targetType;
    private String locationType;
    private String name;
    private String location;
    private int position;
    private ConfigInfo configInfo;
    private Map<String, DecorationValue> values = null;

    public SimpleDecoration(Class clz, Decoration at, int position) {
        this(clz.getName(), at, position);
        for (Map.Entry<String, DecorationValue> deco : PlatformUtils.getAnnotationDefaultDecorationValues(clz).entrySet()) {
            addAttribute(deco.getKey(), deco.getValue());
        }
    }

    public SimpleDecoration(String name, Decoration at, int position) {
        this(name, at.getDecorationSourceType(),
                at.getTarget(), at.getLocationType(), at.getLocation(), position, ConfigInfo.DEFAULT, null);
    }

    public SimpleDecoration(String name, DecorationSourceType locationType, DecorationTarget targetType, String type, String location, int position, ConfigInfo configInfo, Map<String, DecorationValue> attr) {
        this.name = name;
        this.decorationSourceType = locationType;
        this.targetType = targetType;
        this.locationType = type;
        this.location = location;
        this.configInfo = configInfo;
        this.values = attr == null ? new HashMap<String, DecorationValue>() : new HashMap<String, DecorationValue>(attr);
        this.position = position;
    }

    public String getName() {
        return name;
    }

    public int getPosition() {
        return position;
    }


    protected ConfigInfo getConfigInfo0() {
        if (configInfo == null) {
            Decoration config = getDecoration("config");
            if (config != null) {
                Decoration c = (Decoration) config;
                if (c.getName().equals(ItemConfig.class.getName())) {
                    configInfo = new ConfigInfo(c.getInt("order"),
                            ConfigAction.valueOf(c.getString("action")),
                            c.getString("persistenceGroup"),
                            c.getString("persistenceUnit")
                    );
                }
            }

        }
        return configInfo;
    }

    public String getLocation() {
        return location;
    }

    public DecorationSourceType getDecorationSourceType() {
        return decorationSourceType;
    }

    public DecorationTarget getTarget() {
        return targetType;
    }

    public String getLocationType() {
        return locationType;
    }

    public ConfigInfo getConfig() {
        return configInfo;
    }

    public void copyAttributes(Decoration from, String... names) {
        for (String s : names) {
            if (from.contains(s)) {
                DecorationValue a = from.get(s);
            }
        }
    }

    public void addPrimitiveAttribute(String name, Object value) {
        addAttribute(name, new DecorationPrimitiveValue(value, ConfigInfo.DEFAULT));
    }

    public void addAttribute(String name, DecorationValue value) {
        values.put(name, value);
    }

    protected Map<String, DecorationValue> getAttributes0() {
        return values;
    }

    @Override
    public String toString() {
        StringBuilder b = new StringBuilder();
        b.append("@").append(getName());
        b.append("[");
        if (targetType == null) {
            b.append("EMBEDDED").append(":");
        }
        b.append(locationType);
        if (targetType == DecorationTarget.METHOD || targetType == DecorationTarget.FIELD) {
            b.append(".").append(location);
        }
        if (!getConfig().equals(ConfigInfo.DEFAULT)) {
            b.append(";");
            b.append(getConfig());
        }
        b.append("](");
        String s = getAttributes().toString();
        b.append(s.subSequence(1, s.length() - 1));
        b.append(")");
        return b.toString();
    }

}
