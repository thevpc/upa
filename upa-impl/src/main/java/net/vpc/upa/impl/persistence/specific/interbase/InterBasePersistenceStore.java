package net.vpc.upa.impl.persistence.specific.interbase;

import net.vpc.upa.PortabilityHint;
import net.vpc.upa.Properties;
import net.vpc.upa.impl.persistence.DefaultPersistenceStore;

import java.util.LinkedHashSet;
import java.util.Set;

@PortabilityHint(target = "C#", name = "suppress")
public class InterBasePersistenceStore extends DefaultPersistenceStore {

    public InterBasePersistenceStore() {
        Properties map = getProperties();
        map.setBoolean("isComplexSelectSupported", Boolean.FALSE);
        map.setBoolean("isFromClauseInUpdateStatementSupported", Boolean.FALSE);
        map.setBoolean("isFromClauseInDeleteStatementSupported", Boolean.FALSE);
        map.setBoolean("isReferencingSupported", Boolean.FALSE);
        map.setBoolean("isViewSupported", Boolean.FALSE);
        getSqlManager().register(new InterBaseTypeNameSQLProvider());
        getSqlManager().register(new InterBaseSelectSQLProvider());
    }

    @Override
    public Set<String> getSupportedDrivers() {
        LinkedHashSet<String> valid = new LinkedHashSet<String>();
        return valid;
    }

}
