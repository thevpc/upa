/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.event;

import net.vpc.upa.callbacks.UpdateFormulaInterceptor;
import net.vpc.upa.callbacks.UpdateRelationshipTargetFormulaInterceptor;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.expressions.Expression;
import net.vpc.upa.filters.FieldFilter;

/**
 *
 * @author vpc
 */
class RelationshipTargetFormulaUpdaterInterceptorSupportBaseInterceptor implements UpdateFormulaInterceptor {
    private final UpdateRelationshipTargetFormulaInterceptor entityTargetFormulaUpdaterInterceptor;

    public RelationshipTargetFormulaUpdaterInterceptorSupportBaseInterceptor(UpdateRelationshipTargetFormulaInterceptor entityTargetFormulaUpdaterInterceptor) {
        this.entityTargetFormulaUpdaterInterceptor = entityTargetFormulaUpdaterInterceptor;
    }

    @Override
    public FieldFilter getFormulaFields() throws UPAException {
        return entityTargetFormulaUpdaterInterceptor.getFormulaFields();
    }

    @Override
    public Expression translateExpression(Expression e) throws UPAException {
        return entityTargetFormulaUpdaterInterceptor.translateExpression(e);
    }
    
}
