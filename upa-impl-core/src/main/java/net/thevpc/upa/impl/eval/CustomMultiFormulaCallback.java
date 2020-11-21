package net.thevpc.upa.impl.eval;

import net.thevpc.upa.Callback;
import net.thevpc.upa.CustomMultiFormula;
import net.thevpc.upa.CustomMultiFormulaContext;


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
