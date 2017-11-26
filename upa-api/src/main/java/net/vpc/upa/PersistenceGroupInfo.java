package net.vpc.upa;

import java.util.List;

public class PersistenceGroupInfo extends UPAObjectInfo{
    private List<PersistenceUnitInfo> persistenceUnits;

    public PersistenceGroupInfo() {
        super("persistenceGroup");
    }

    public List<PersistenceUnitInfo> getPersistenceUnits() {
        return persistenceUnits;
    }

    public void setPersistenceUnits(List<PersistenceUnitInfo> persistenceUnits) {
        this.persistenceUnits = persistenceUnits;
    }
}
