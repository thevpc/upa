package net.thevpc.upa.impl.eval;

import net.thevpc.upa.Callback;
import net.thevpc.upa.CustomFormula;
import net.thevpc.upa.CustomFormulaContext;

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
