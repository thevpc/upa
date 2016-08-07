/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.vpc.upa.impl.config.decorations;

import net.vpc.upa.config.DecorationValue;
import java.util.ArrayList;
import java.util.Collections;
import java.util.List;
import net.vpc.upa.config.ConfigInfo;

/**
 *
 * @author taha.bensalah@gmail.com
 */
public abstract class AbstractDecorationValue implements DecorationValue {

    private List<DecorationValue> alternatives = new ArrayList<DecorationValue>();

    public AbstractDecorationValue() {
        addAlternative(this);
    }

    public void addAlternative(DecorationValue other) {
        alternatives.add(other);
        Collections.sort(alternatives);
    }

    public DecorationValue[] getAlternatives() {
        return alternatives.toArray(new DecorationValue[alternatives.size()]);
    }

    public int compareTo(DecorationValue o) {
        if (o == null) {
            return 1;
        }
        if (o == this) {
            return 0;
        }
        ConfigInfo c1 = this.getConfig();
        ConfigInfo c2 = o.getConfig();
        if (c1 == c2) {
            return 0;
        }
        if (c1 != null) {
            return c1.compareTo(c2);
        }
        return 0;
    }

    public DecorationValue[] shrink(DecorationValue[] alternatives) {
        ArrayList<DecorationValue> ok = new ArrayList<DecorationValue>();
        for (DecorationValue alternative : alternatives) {
            switch (alternative.getConfig().getConfigAction()) {
                case MERGE: {
                    ok.add(alternative);
                    break;
                }
                case DELETE: {
                    ok.clear();
                    break;
                }
                case REPLACE: {
                    ok.clear();
                    ok.add(alternative);
                    break;
                }
            }
        }
        return ok.toArray(new DecorationValue[ok.size()]);
    }

}
