package net.vpc.upa.impl.persistence;

import net.vpc.upa.config.PersistenceNameType;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 1/8/13 1:53 AM
 */
public class ObjectAndType {

    private Class cls;
    private PersistenceNameType spec;

    ObjectAndType(Class cls, PersistenceNameType type) {
        this.cls = cls;
        this.spec = type;
    }

    public Class getCls() {
        return cls;
    }

    public PersistenceNameType getSpec() {
        return spec;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) {
            return true;
        }
        if (o == null || getClass() != o.getClass()) {
            return false;
        }

        ObjectAndType that = (ObjectAndType) o;

        if (cls != null ? !cls.equals(that.cls) : that.cls != null) {
            return false;
        }
        if (spec != null ? !spec.equals(that.spec) : that.spec != null) {
            return false;
        }

        return true;
    }

    @Override
    public int hashCode() {
        int result = cls != null ? cls.hashCode() : 0;
        result = 31 * result + (spec != null ? spec.hashCode() : 0);
        return result;
    }

    @Override
    public String toString() {
        return "ObjectAndType{"
                + "cls=" + cls
                + ", type='" + spec + '\''
                + '}';
    }
}
