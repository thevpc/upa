package net.vpc.upa;

import net.vpc.upa.persistence.DatabaseProduct;

public class RelationshipPersistenceNameRule implements PersistenceNameRule{
    private String relationName;
    private String persistenceName;
    private DatabaseProduct dbTypeCondition;
    private String dbVersionCondition;
    private String strategyNameCondition;

    public String getRelationName() {
        return relationName;
    }

    public String getPersistenceName() {
        return persistenceName;
    }

    public void setPersistenceName(String persistenceName) {
        this.persistenceName = persistenceName;
    }

    public void setRelationName(String relationName) {
        this.relationName = relationName;
    }

    @Override
    public DatabaseProduct getDatabaseProduct() {
        return dbTypeCondition;
    }

    public void setDbTypeCondition(DatabaseProduct dbTypeCondition) {
        this.dbTypeCondition = dbTypeCondition;
    }

    @Override
    public String getDatabaseVersion() {
        return dbVersionCondition;
    }

    public void setDbVersionCondition(String dbVersionCondition) {
        this.dbVersionCondition = dbVersionCondition;
    }

    @Override
    public String getStrategyName() {
        return strategyNameCondition;
    }

    public void setStrategyNameCondition(String strategyNameCondition) {
        this.strategyNameCondition = strategyNameCondition;
    }
}
