/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.thevpc.upa.impl.event;

import net.thevpc.upa.events.UpdateFormulaInterceptor;
import net.thevpc.upa.events.UpdateRelationshipTargetFormulaInterceptor;
import net.thevpc.upa.exceptions.UPAException;
import net.thevpc.upa.expressions.Expression;
import net.thevpc.upa.filters.FieldFilter;

/**
 *
 * @author taha.bensalah@gmail.com
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
