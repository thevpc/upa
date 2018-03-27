/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.vpc.upa.impl.config.decorations;

import net.vpc.upa.config.DecorationTarget;
import net.vpc.upa.config.DecorationSourceType;
import net.vpc.upa.config.Decoration;
import net.vpc.upa.config.DecorationValue;
import java.util.Map;
import net.vpc.upa.config.ConfigAction;
import net.vpc.upa.config.ConfigInfo;
import net.vpc.upa.config.ItemConfig;

/**
 *
 * @author taha.bensalah@gmail.com
 */
public final class SimpleDecoration extends AbstractDecoration {

    private DecorationSourceType decorationSourceType;
    private DecorationTarget targetType;
    private String type;
    private String name;
    private String location;
    private int position;
    private ConfigInfo configInfo;
    private Map<String, DecorationValue> values = null;

    public SimpleDecoration(String name, DecorationSourceType locationType, DecorationTarget targetType, String type, String location, int position,ConfigInfo configInfo,Map<String, DecorationValue> attr) {
        this.name = name;
        this.decorationSourceType = locationType;
        this.targetType = targetType;
        this.type = type;
        this.location = location;
        this.configInfo = configInfo;
        this.values = attr;
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
        return type;
    }

    public ConfigInfo getConfig() {
        return configInfo;
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
        b.append(type);
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
