/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.thevpc.upa.impl.event;

import net.thevpc.upa.events.UpdateFormulaInterceptor;
import net.thevpc.upa.events.UpdateRelationshipSourceFormulaInterceptor;
import net.thevpc.upa.exceptions.UPAException;
import net.thevpc.upa.expressions.Expression;
import net.thevpc.upa.filters.FieldFilter;

/**
 *
 * @author taha.bensalah@gmail.com
 */
class RelationshipSourceFormulaUpdaterInterceptorSupportBaseInterceptor implements UpdateFormulaInterceptor {
    private final UpdateRelationshipSourceFormulaInterceptor entityDetailFormulaUpdaterInterceptor;

    public RelationshipSourceFormulaUpdaterInterceptorSupportBaseInterceptor(UpdateRelationshipSourceFormulaInterceptor entityDetailFormulaUpdaterInterceptor) {
        this.entityDetailFormulaUpdaterInterceptor = entityDetailFormulaUpdaterInterceptor;
    }

    @Override
    public FieldFilter getFormulaFields() throws UPAException {
        return entityDetailFormulaUpdaterInterceptor.getFormulaFields();
    }

    @Override
    public Expression translateExpression(Expression e) throws UPAException {
        return entityDetailFormulaUpdaterInterceptor.translateExpression(e);
    }
    
}
