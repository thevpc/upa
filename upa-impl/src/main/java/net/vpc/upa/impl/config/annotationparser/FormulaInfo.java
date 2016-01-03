package net.vpc.upa.impl.config.annotationparser;

import net.vpc.upa.config.Formula;
import net.vpc.upa.FormulaType;
import net.vpc.upa.config.Decoration;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 11/15/12 11:47 AM
 */
class FormulaInfo {

    public String expression;
    public Class<net.vpc.upa.Formula> type;
    public Integer order;
    public FormulaType formulaType;
    public boolean specified = false;
    public int configOrder = Integer.MIN_VALUE;

    public void mergeFormula(Decoration gid) {
        if (gid.getConfig().getOrder() >= configOrder) {
            specified = true;
            if (gid.getInt("formulaOrder") != Integer.MIN_VALUE) {
                order = gid.getInt("formulaOrder");
            }
            if (gid.getString("value").length() > 0) {
                expression = gid.getString("value");
                type = null;
            }
            if (!gid.getType("custom").equals(Object.class) && !gid.getType("custom").equals(net.vpc.upa.Formula.class)) {
                expression = null;
                type = gid.getType("custom");
            }
            configOrder = gid.getConfig().getOrder();
        }
    }
}
