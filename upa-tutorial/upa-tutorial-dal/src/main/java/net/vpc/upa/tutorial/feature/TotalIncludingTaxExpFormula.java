package net.vpc.upa.tutorial.feature;

import net.vpc.upa.CustomFormula;
import net.vpc.upa.CustomFormulaContext;


/**
 * There is no need to add callback annotation as mapping is explicit in the @Formula.custom
 */
public class TotalIncludingTaxExpFormula implements CustomFormula {
    @Override
    public Object getValue(CustomFormulaContext context) {
        return 3;
    }
}
