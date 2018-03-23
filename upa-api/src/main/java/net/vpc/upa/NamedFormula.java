package net.vpc.upa;

import java.util.Objects;

public final class NamedFormula implements Formula{
    private String name;

    public NamedFormula(String name) {
        this.name = name;
    }

    public String getName() {
        return name;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        NamedFormula that = (NamedFormula) o;
        return Objects.equals(name, that.name);
    }

    @Override
    public int hashCode() {

        return Objects.hash(name);
    }
}
