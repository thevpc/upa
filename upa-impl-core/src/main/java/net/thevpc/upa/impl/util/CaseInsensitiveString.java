package net.thevpc.upa.impl.util;

import java.util.Objects;

public class CaseInsensitiveString {
    private String value;

    public CaseInsensitiveString(String value) {
        this.value = value;
    }

    @Override
    public String toString() {
        return String.valueOf(value);
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        CaseInsensitiveString that = (CaseInsensitiveString) o;
        return Objects.equals(value.toLowerCase(), that.value.toLowerCase());
    }

    @Override
    public int hashCode() {

        return Objects.hash(value.toLowerCase());
    }
}
