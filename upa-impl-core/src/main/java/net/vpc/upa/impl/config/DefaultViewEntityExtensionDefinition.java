/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.config;

import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.expressions.Expression;
import net.vpc.upa.expressions.QueryStatement;
import net.vpc.upa.ViewEntityExtensionDefinition;

/**
 *
 * @author vpc
 */
public class DefaultViewEntityExtensionDefinition implements ViewEntityExtensionDefinition {
    
    private final String query;

    public DefaultViewEntityExtensionDefinition(String query) {
        this.query = query;
    }

    @Override
    public QueryStatement getQuery(net.vpc.upa.Entity entity) {
        Expression ex = entity.getPersistenceUnit().getExpressionManager().parseExpression(query);
        if (ex instanceof QueryStatement) {
            return (QueryStatement) ex;
        }
        throw new UPAException("InvalidViewQuery", entity.getName(), query);
    }
    
}
