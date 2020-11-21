package net.thevpc.upa.tutorial.feature;

import net.thevpc.upa.CustomFormula;
import net.thevpc.upa.CustomFormulaContext;


/**
 * There is no need to add callback annotation as mapping is explicit in the @Formula.custom
 */
public class TotalIncludingTaxExpFormula implements CustomFormula {
    @Override
    public Object getValue(CustomFormulaContext context) {
        return 3;
    }
}
