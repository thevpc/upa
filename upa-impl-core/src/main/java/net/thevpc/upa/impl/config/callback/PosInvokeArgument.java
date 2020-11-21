package net.thevpc.upa.impl.config.callback;

/**
 * Created by vpc on 7/25/15.
 */
public final class PosInvokeArgument implements InvokeArgument {
    private String name;
    private Class platformType;
    private int pos;
    private boolean acceptSubClasses;

    public PosInvokeArgument(String name, Class platformType, int pos,boolean acceptSubClasses) {
        this.name = name;
        this.platformType = platformType;
        this.pos = pos;
        this.acceptSubClasses = acceptSubClasses;
    }

    @Override
    public String getName() {
        return name;
    }

    @Override
    public Class getPlatformType() {
        return platformType;
    }

    @Override
    public Object getValue(Object[] arguments) {
        return arguments[pos];
    }

    @Override
    public boolean isAcceptSubClasses() {
        return acceptSubClasses;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;

        PosInvokeArgument that = (PosInvokeArgument) o;

        if (pos != that.pos) return false;
        if (acceptSubClasses != that.acceptSubClasses) return false;
        if (name != null ? !name.equals(that.name) : that.name != null) return false;
        return !(platformType != null ? !platformType.equals(that.platformType) : that.platformType != null);

    }

    @Override
    public int hashCode() {
        int result = name != null ? name.hashCode() : 0;
        result = 31 * result + (platformType != null ? platformType.hashCode() : 0);
        result = 31 * result + pos;
        result = 31 * result + (acceptSubClasses ? 1 : 0);
        return result;
    }
}
