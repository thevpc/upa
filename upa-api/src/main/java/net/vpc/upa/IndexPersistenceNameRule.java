package net.vpc.upa;

import net.vpc.upa.persistence.DatabaseProduct;

public class IndexPersistenceNameRule implements PersistenceNameRule{
    private String entityName;
    private String persistenceName;
    private String indexName;
    private DatabaseProduct dbTypeCondition;
    private String dbVersionCondition;
    private String strategyNameCondition;

    public String getPersistenceName() {
        return persistenceName;
    }

    public void setPersistenceName(String persistenceName) {
        this.persistenceName = persistenceName;
    }

    public String getIndexName() {
        return indexName;
    }

    public void setIndexName(String indexName) {
        this.indexName = indexName;
    }

    public String getEntityName() {
        return entityName;
    }

    public void setEntityName(String entityName) {
        this.entityName = entityName;
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
