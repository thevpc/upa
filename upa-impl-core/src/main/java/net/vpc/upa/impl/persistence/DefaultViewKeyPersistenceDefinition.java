/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.persistence;

import net.vpc.upa.persistence.ViewPersistenceDefinition;

/**
 *
 * @author vpc
 */
public class DefaultViewKeyPersistenceDefinition implements ViewPersistenceDefinition {

    private final String viewName;
    private final String catalogName;
    private final String schemaName;
    private final String viewDefinition;

    public DefaultViewKeyPersistenceDefinition(String viewName, String catalogName, String schemaName, String viewDefinition) {
        this.viewName = viewName;
        this.viewDefinition = viewDefinition;
        this.schemaName = schemaName;
        this.catalogName = catalogName;
    }

    @Override
    public String getViewName() {
        return viewName;
    }

    public String getViewDefinition() {
        return viewDefinition;
    }

    public String getCatalogName() {
        return catalogName;
    }

    public String getSchemaName() {
        return schemaName;
    }

}
