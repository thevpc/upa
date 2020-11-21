package net.thevpc.upa.impl.context;

import net.thevpc.upa.PersistenceUnit;

/**
* @author Taha BEN SALAH <taha.bensalah@gmail.com>
* @creationdate 1/8/13 1:55 AM
*/
class PersistenceUnitKey {

    private PersistenceUnit persistenceUnit;
    private String key;

    public PersistenceUnitKey(PersistenceUnit persistenceUnit, String key) {
        this.persistenceUnit = persistenceUnit;
        this.key = key;
    }

    public PersistenceUnit getPersistenceUnit() {
        return persistenceUnit;
    }

    public String getKey() {
        return key;
    }

    @Override
    public String toString() {
        return "PUKey{" +
                persistenceUnit +
                ", '" + key + '\'' +
                '}';
    }

    @Override
    public int hashCode() {
        int hash = 5;
        hash = 71 * hash + (this.persistenceUnit != null ? this.persistenceUnit.hashCode() : 0);
        hash = 71 * hash + (this.key != null ? this.key.hashCode() : 0);
        return hash;
    }

    @Override
    public boolean equals(Object obj) {
        if (obj == null) {
            return false;
        }
        if (getClass() != obj.getClass()) {
            return false;
        }
        final PersistenceUnitKey other = (PersistenceUnitKey) obj;
        if (this.persistenceUnit != other.persistenceUnit && (this.persistenceUnit == null || !this.persistenceUnit.equals(other.persistenceUnit))) {
            return false;
        }
        if ((this.key == null) ? (other.key != null) : !this.key.equals(other.key)) {
            return false;
        }
        return true;
    }
}
