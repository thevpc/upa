package net.vpc.upa;

import net.vpc.upa.persistence.DatabaseProduct;

public class ColumnPersistenceNameRule implements PersistenceNameRule{
    private String entityName;
    private String fieldName;
    private String tableName;
    /**
     * column name
     */
    private String persistenceName;
    private DatabaseProduct databaseProduct;
    private String databaseVersion;
    private String strategyName;

    public String getEntityName() {
        return entityName;
    }

    public ColumnPersistenceNameRule setEntityName(String entityName) {
        this.entityName = entityName;
        return this;
    }

    public String getFieldName() {
        return fieldName;
    }

    public ColumnPersistenceNameRule setFieldName(String fieldName) {
        this.fieldName = fieldName;
        return this;
    }

    public String getTableName() {
        return tableName;
    }

    public ColumnPersistenceNameRule setTableName(String tableName) {
        this.tableName = tableName;
        return this;
    }

    public String getPersistenceName() {
        return persistenceName;
    }

    public ColumnPersistenceNameRule setPersistenceName(String persistenceName) {
        this.persistenceName = persistenceName;
        return this;
    }

    @Override
    public DatabaseProduct getDatabaseProduct() {
        return databaseProduct;
    }

    public ColumnPersistenceNameRule setDatabaseProduct(DatabaseProduct databaseProduct) {
        this.databaseProduct = databaseProduct;
        return this;
    }

    @Override
    public String getDatabaseVersion() {
        return databaseVersion;
    }

    public ColumnPersistenceNameRule setDatabaseVersion(String databaseVersion) {
        this.databaseVersion = databaseVersion;
        return this;
    }

    @Override
    public String getStrategyName() {
        return strategyName;
    }

    public ColumnPersistenceNameRule setStrategyName(String strategyName) {
        this.strategyName = strategyName;
        return this;
    }
}
