package net.vpc.upa.impl.persistence.specific.interbase;

import net.vpc.upa.PersistenceUnit;
import net.vpc.upa.PortabilityHint;
import net.vpc.upa.Properties;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.impl.persistence.DefaultPersistenceStore;
import net.vpc.upa.persistence.ConnectionProfile;
import net.vpc.upa.persistence.DatabaseProduct;
import net.vpc.upa.persistence.PersistenceNameConfig;

import java.util.LinkedHashSet;
import java.util.Set;

@PortabilityHint(target = "C#", name = "suppress")
public class InterBasePersistenceStore extends DefaultPersistenceStore {

    public void configureStore(){
        super.configureStore();
        Properties map = getStoreParameters();
        map.setBoolean("isComplexSelectSupported", Boolean.FALSE);
        map.setBoolean("isFromClauseInUpdateStatementSupported", Boolean.FALSE);
        map.setBoolean("isFromClauseInDeleteStatementSupported", Boolean.FALSE);
        map.setBoolean("isReferencingSupported", Boolean.FALSE);
        map.setBoolean("isViewSupported", Boolean.FALSE);
        getSqlManager().register(new InterBaseTypeNameSQLProvider());
        getSqlManager().register(new InterBaseSelectSQLProvider());
    }

    @Override
    public int getSupportLevel(ConnectionProfile connectionProfile, Properties parameters) {
        DatabaseProduct p = connectionProfile.getDatabaseProduct();
        if(p==DatabaseProduct.INTERBASE){
            return 10;
        }
        return -1;
    }

    @Override
    public Set<String> getSupportedDrivers() {
        LinkedHashSet<String> valid = new LinkedHashSet<String>();
        return valid;
    }

}
