package net.vpc.upa.impl.eval;

import net.vpc.upa.*;

public class CustomMultiFormulaCallback implements CustomMultiFormula {
    private final Callback callback;

    public CustomMultiFormulaCallback(Callback callback) {
        this.callback = callback;
    }

    @Override
    public void updateFormulas(CustomMultiFormulaContext context) {
        callback.invoke(context);
    }
}
