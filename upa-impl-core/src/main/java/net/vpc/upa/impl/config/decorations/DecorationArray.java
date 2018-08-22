/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.vpc.upa.impl.config.decorations;

import net.vpc.upa.config.DecorationValue;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;
import net.vpc.upa.config.ConfigAction;
import net.vpc.upa.config.ConfigInfo;

/**
 *
 * @author taha.bensalah@gmail.com
 */
public class DecorationArray extends AbstractDecorationValue implements DecorationValue {

    public DecorationValue[] values;
    public ConfigInfo configInfo;

    public DecorationArray(DecorationValue[] values, ConfigInfo info) {
        this.values = values;
        this.configInfo = info;
    }

    public ConfigInfo getConfig() {
        return configInfo;
    }

    public DecorationValue[] getValues() {
        return values;
    }

    @Override
    public String toString() {
        if (!getConfig().equals(ConfigInfo.DEFAULT)) {
            StringBuilder b = new StringBuilder("Array");
            b.append("[");
            b.append(getConfig());
            b.append("]");
            b.append(Arrays.asList(values));
            return b.toString();
        }
        return String.valueOf(Arrays.asList(values));
    }

    public void merge() {
        List<Object> ok = new ArrayList<Object>();
        DecorationValue[] alternatives = getAlternatives();
        for (DecorationValue alternative : alternatives) {
            DecorationArray d = (DecorationArray) alternative;
            switch (d.getConfig().getConfigAction()) {
                case REMOVE: {
                    ok.clear();
                    break;
                }
                case MERGE:
                case REPLACE: {
                    ok.clear();
                    ok.add(d.getValues());
                    break;
                }
            }
        }
        DecorationValue last = alternatives[alternatives.length - 1];
        if (ok.isEmpty()) {
            values = null;
            configInfo = new ConfigInfo(last.getConfig().getOrder(),
                    ConfigAction.REMOVE, last.getConfig().getPersistenceGroup(), last.getConfig().getPersistenceUnit());
        } else {
            values = (DecorationValue[]) ok.get(ok.size() - 1);
            configInfo = new ConfigInfo(last.getConfig().getOrder(),
                    ConfigAction.MERGE, last.getConfig().getPersistenceGroup(), last.getConfig().getPersistenceUnit());
        }
    }

}
