package net.vpc.upa;

import net.vpc.upa.persistence.DatabaseProduct;

public class TablePersistenceNameRule implements PersistenceNameRule{
    private String entityName;
    /**
     * table name
     */
    private String persistenceName;
    private String shortPersistenceNamePrefix;
    private String pkPersistenceName;
    private String viewPersistenceName;
    private String catalog;
    private String schema;
    private DatabaseProduct databaseProduct;
    private String databaseVersion;
    private String strategyName;

    public String getEntityName() {
        return entityName;
    }

    public TablePersistenceNameRule setEntityName(String entityName) {
        this.entityName = entityName;
        return this;
    }

    public String getPersistenceName() {
        return persistenceName;
    }

    public TablePersistenceNameRule setPersistenceName(String persistenceName) {
        this.persistenceName = persistenceName;
        return this;
    }

    public String getShortPersistenceNamePrefix() {
        return shortPersistenceNamePrefix;
    }

    public TablePersistenceNameRule setShortPersistenceNamePrefix(String shortPersistenceNamePrefix) {
        this.shortPersistenceNamePrefix = shortPersistenceNamePrefix;
        return this;
    }

    public String getPkPersistenceName() {
        return pkPersistenceName;
    }

    public TablePersistenceNameRule setPkPersistenceName(String pkPersistenceName) {
        this.pkPersistenceName = pkPersistenceName;
        return this;
    }

    public String getViewPersistenceName() {
        return viewPersistenceName;
    }

    public TablePersistenceNameRule setViewPersistenceName(String viewPersistenceName) {
        this.viewPersistenceName = viewPersistenceName;
        return this;
    }

    public String getCatalog() {
        return catalog;
    }

    public TablePersistenceNameRule setCatalog(String catalog) {
        this.catalog = catalog;
        return this;
    }

    public String getSchema() {
        return schema;
    }

    public TablePersistenceNameRule setSchema(String schema) {
        this.schema = schema;
        return this;
    }

    public DatabaseProduct getDatabaseProduct() {
        return databaseProduct;
    }

    public TablePersistenceNameRule setDatabaseProduct(DatabaseProduct databaseProduct) {
        this.databaseProduct = databaseProduct;
        return this;
    }

    public String getDatabaseVersion() {
        return databaseVersion;
    }

    public TablePersistenceNameRule setDatabaseVersion(String databaseVersion) {
        this.databaseVersion = databaseVersion;
        return this;
    }

    public String getStrategyName() {
        return strategyName;
    }

    public TablePersistenceNameRule setStrategyName(String strategyName) {
        this.strategyName = strategyName;
        return this;
    }
}
