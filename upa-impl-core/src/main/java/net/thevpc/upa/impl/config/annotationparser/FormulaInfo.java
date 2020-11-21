package net.thevpc.upa.impl.config.annotationparser;

import net.thevpc.upa.Formula;
import net.thevpc.upa.config.Decoration;
import net.thevpc.upa.FormulaType;
import net.thevpc.upa.exceptions.UPAException;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 11/15/12 11:47 AM
 */
class FormulaInfo {

    public String expression;
    public String name;
    public Class<Formula> platformType;
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
            String formulaByName = gid.getString("name");
            String formulaByExpr = gid.getString("value");
            Class formulaByType = gid.getType("customType");
            if(AnnotationParserUtils.isAnnotationNullTypeProperty(formulaByType, Formula.class)){
                formulaByType=null;
            }
            int err=(formulaByName.length() > 0 ?1:0)+(formulaByExpr.length() > 0 ?1:0)+(formulaByType!=null?1:0);
            if (err ==0) {
                throw new UPAException("ExpectedFormula",gid);
            }
            if (err !=1) {
                throw new UPAException("InvalidFormula",gid);
            }
            if (formulaByName.length() > 0) {
                this.name = formulaByName;
                expression = null;
                platformType = null;
            }
            if (formulaByExpr.length() > 0) {
                expression = formulaByExpr;
                platformType = null;
                this.name = null;
            }
            if (formulaByType!=null) {
                platformType = formulaByType;
                expression = null;
                this.name = null;
            }
            configOrder = gid.getConfig().getOrder();
        }
    }
}
