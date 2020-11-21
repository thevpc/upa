package net.thevpc.upa.impl.util;

import java.util.Arrays;

/**
 * Created by vpc on 6/11/16.
 */
public class MethodSignature {
    private String name;
    private Class[] parameterTypes;

    public MethodSignature(String name, Class[] parameterTypes) {
        this.name = name;
        this.parameterTypes = parameterTypes;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (!(o instanceof MethodSignature)) return false;

        MethodSignature that = (MethodSignature) o;

        if (name != null ? !name.equals(that.name) : that.name != null) return false;
        // Probably incorrect - comparing Object[] arrays with Arrays.equals
        return Arrays.equals(parameterTypes, that.parameterTypes);

    }

    @Override
    public int hashCode() {
        int result = name != null ? name.hashCode() : 0;
        result = 31 * result + (parameterTypes != null ? Arrays.hashCode(parameterTypes) : 0);
        return result;
    }
}
