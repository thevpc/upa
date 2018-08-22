/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.vpc.upa.impl.config.decorations;

import net.vpc.upa.config.DecorationValue;
import java.util.ArrayList;
import java.util.List;
import net.vpc.upa.config.ConfigAction;
import net.vpc.upa.config.ConfigInfo;

/**
 *
 * @author taha.bensalah@gmail.com
 */
public class DecorationPrimitiveValue extends AbstractDecorationValue implements DecorationValue {

    private Object value;
    private ConfigInfo configInfo;

    public DecorationPrimitiveValue(Object value, ConfigInfo configInfo) {
        this.value = value;
        this.configInfo = configInfo;
    }

    public ConfigInfo getConfig() {
        return configInfo;
    }

    public Object getValue() {
        return value;
    }

    public void merge() {
        List<Object> ok = new ArrayList<Object>();
        DecorationValue[] alternatives = getAlternatives();
        for (DecorationValue alternative : alternatives) {
            DecorationPrimitiveValue d = (DecorationPrimitiveValue) alternative;
            switch (d.getConfig().getConfigAction()) {
                case REMOVE: {
                    ok.clear();
                    break;
                }
                case MERGE:
                case REPLACE: {
                    ok.clear();
                    ok.add(d.getValue());
                    break;
                }
            }
        }
        DecorationValue last = alternatives[alternatives.length - 1];
        if (ok.isEmpty()) {
            value = null;
            configInfo = new ConfigInfo(last.getConfig().getOrder(),
                    ConfigAction.REMOVE, last.getConfig().getPersistenceGroup(), last.getConfig().getPersistenceUnit());
        } else {
            value = ok.get(ok.size() - 1);
            configInfo = new ConfigInfo(last.getConfig().getOrder(),
                    ConfigAction.MERGE, last.getConfig().getPersistenceGroup(), last.getConfig().getPersistenceUnit());
        }
    }

    @Override
    public String toString() {
        if (!getConfig().equals(ConfigInfo.DEFAULT)) {
            StringBuilder b = new StringBuilder("Value");
            b.append("[");
            b.append(getConfig());
            b.append("]");
            b.append("(");
            b.append(format(value));
            b.append(")");
            return b.toString();
        }
        return format(value);
    }

    private String format(Object o) {
        if (o == null) {
            return "null";
        }
        if (o instanceof String) {
            return "\"" + o + "\"";
        }
        if (o instanceof Class) {
            return ((Class) o).getName();
        }
        return String.valueOf(o);
    }

}
