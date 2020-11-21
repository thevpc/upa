package net.thevpc.upa.impl.persistence;

import net.thevpc.upa.impl.util.PlatformUtils;
import net.thevpc.upa.impl.util.StringUtils;
import net.thevpc.upa.persistence.DatabaseProduct;
import net.thevpc.upa.persistence.PersistenceNameStrategyCondition;

public class DefaultPersistenceNameStrategyCondition implements PersistenceNameStrategyCondition{
    private DatabaseProduct dbTypeCondition;
    private String dbVersionCondition;
    private String strategyNameCondition;

    public DefaultPersistenceNameStrategyCondition(DatabaseProduct dbTypeCondition, String dbVersionCondition, String strategyNameCondition) {
        this.dbTypeCondition = dbTypeCondition;
        this.dbVersionCondition = dbVersionCondition;
        this.strategyNameCondition = strategyNameCondition;
    }

    @Override
    public boolean accept(DatabaseProduct databaseProduct, String databaseVersion, String strategyName) {
        if (!StringUtils.isNullOrEmpty(getStrategyNameCondition())) {
            if (!getStrategyNameCondition().equals(strategyName)) {
                return false;
            }
        }
        if (!PlatformUtils.isUndefinedEnumValue(DatabaseProduct.class, getDbTypeCondition())) {
            if (databaseProduct != getDbTypeCondition()) {
                return false;
            }
        }
        if (!StringUtils.isNullOrEmpty(getDbVersionCondition())) {
//            if(rule.getDatabaseProduct()!=dbTypeCondition){
//                return false;
//            }
        }

        return true;
    }

    public DatabaseProduct getDbTypeCondition() {
        return dbTypeCondition;
    }

    public String getDbVersionCondition() {
        return dbVersionCondition;
    }

    public String getStrategyNameCondition() {
        return strategyNameCondition;
    }
}
