package net.thevpc.upa.impl;

import net.thevpc.upa.Formula;
import net.thevpc.upa.NamedFormulaDefinition;

public class DefaultNamedFormulaDefinition implements NamedFormulaDefinition{
    private String name;
    private Formula formula;

    public DefaultNamedFormulaDefinition(String name, Formula formula) {
        this.name = name;
        this.formula = formula;
    }

    @Override
    public String getName() {
        return name;
    }

    @Override
    public Formula getFormula() {
        return formula;
    }

    @Override
    public String toString() {
        return "NamedFormulaDefinition{" +
                "name='" + name + '\'' +
                ", formula=" + formula +
                '}';
    }
}
