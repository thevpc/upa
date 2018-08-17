/**
 * ====================================================================
 * UPA (Unstructured Persistence API)
 * Yet another ORM Framework
 * ++++++++++++++++++++++++++++++++++
 * Unstructured Persistence API, referred to as UPA, is a genuine effort
 * to raise programming language frameworks managing relational data in
 * applications using Java Platform, Standard Edition and Java Platform,
 * Enterprise Edition and Dot Net Framework equally to the next level of
 * handling ORM for mutable data structures. UPA is intended to provide
 * a solid reflection mechanisms to the mapped data structures while
 * affording to make changes at runtime of those data structures.
 * Besides, UPA has learned considerably of the leading ORM
 * (JPA, Hibernate/NHibernate, MyBatis and Entity Framework to name a few)
 * failures to satisfy very common even known to be trivial requirement in
 * enterprise applications.
 * <p>
 * Copyright (C) 2014-2015 Taha BEN SALAH
 * <p>
 * This program is free software; you can redistribute it and/or modify it under
 * the terms of the GNU General Public License as published by the Free Software
 * Foundation; either version 2 of the License, or (at your option) any later
 * version.
 * <p>
 * This program is distributed in the hope that it will be useful, but WITHOUT
 * ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS
 * FOR A PARTICULAR PURPOSE. See the GNU General Public License for more
 * details.
 * <p>
 * You should have received a copy of the GNU General Public License along with
 * this program; if not, write to the Free Software Foundation, Inc., 51
 * Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA.
 * ====================================================================
 */
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
