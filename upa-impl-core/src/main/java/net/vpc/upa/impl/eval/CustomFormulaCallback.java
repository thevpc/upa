package net.vpc.upa.impl.eval;

import net.vpc.upa.Callback;
import net.vpc.upa.CustomFormula;
import net.vpc.upa.CustomFormulaContext;

public class CustomFormulaCallback implements CustomFormula{
    private final Callback callback;

    public CustomFormulaCallback(Callback callback) {
        this.callback = callback;
    }

    @Override
    public Object getValue(CustomFormulaContext context) {
        return callback.invoke(context);
    }
}
