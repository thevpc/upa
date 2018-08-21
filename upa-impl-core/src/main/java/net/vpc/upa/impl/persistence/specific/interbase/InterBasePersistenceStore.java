package net.vpc.upa.impl.persistence.specific.interbase;

import net.vpc.upa.PortabilityHint;
import net.vpc.upa.Properties;
import net.vpc.upa.impl.persistence.DefaultPersistenceStore;
import net.vpc.upa.persistence.ConnectionProfile;
import net.vpc.upa.persistence.DatabaseProduct;

import java.util.LinkedHashSet;
import java.util.Set;

@PortabilityHint(target = "C#", name = "suppress")
public class InterBasePersistenceStore extends DefaultPersistenceStore {

    public void configureStore(){
        super.configureStore();
        Properties map = getStoreParameters();
        map.setBoolean(PARAM_IS_COMPLEX_SELECT_SUPPORTED, Boolean.FALSE);
        map.setBoolean(PARAM_IS_FROM_CLAUSE_IN_UPDATE_STATMENT_SUPPORTED, Boolean.FALSE);
        map.setBoolean(PARAM_IS_FROM_CLAUSE_IN_DELETE_STATMENT_SUPPORTED, Boolean.FALSE);
        map.setBoolean(PARAM_IS_REFERENCING_SUPPORTED, Boolean.FALSE);
        map.setBoolean(PARAM_IS_VIEW_SUPPORTED, Boolean.FALSE);
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
