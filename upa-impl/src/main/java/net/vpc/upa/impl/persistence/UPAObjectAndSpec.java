package net.vpc.upa.impl.persistence;

import net.vpc.upa.persistence.PersistenceNameType;

/**
* @author Taha BEN SALAH <taha.bensalah@gmail.com>
* @creationdate 1/8/13 1:54 AM
*/
public class UPAObjectAndSpec {

    private Object object;
    private PersistenceNameType spec;

    UPAObjectAndSpec(Object object, PersistenceNameType spec) {
        this.object = object;
        this.spec = spec;
    }

    public Object getObject() {
        return object;
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

        UPAObjectAndSpec that = (UPAObjectAndSpec) o;

        if (object != null ? !object.equals(that.object) : that.object != null) {
            return false;
        }
        if (spec != null ? !spec.equals(that.spec) : that.spec != null) {
            return false;
        }

        return true;
    }

    @Override
    public int hashCode() {
        int result = object != null ? object.hashCode() : 0;
        result = 31 * result + (spec != null ? spec.hashCode() : 0);
        return result;
    }
}
