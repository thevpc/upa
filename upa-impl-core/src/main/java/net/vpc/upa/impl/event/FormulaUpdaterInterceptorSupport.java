/*
 * Created by IntelliJ IDEA.
 * User: taha
 * Date: 15 nov. 02
 * Time: 13:25:09
 * To change template for new class use
 * Code Style | Class Templates options (Tools | IDE Options).
 */
package net.vpc.upa.impl.event;

import net.vpc.upa.Entity;
import net.vpc.upa.events.UpdateFormulaInterceptor;
import net.vpc.upa.events.PersistEvent;
import net.vpc.upa.events.RemoveEvent;
import net.vpc.upa.events.UpdateEvent;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.expressions.Expression;
import net.vpc.upa.filters.FieldFilter;

public class FormulaUpdaterInterceptorSupport extends ExpressionHelperInterceptorSupport {

    private UpdateFormulaInterceptor formulas;

    public FormulaUpdaterInterceptorSupport(UpdateFormulaInterceptor formulas) {
        this.formulas = formulas;
    }

    protected FieldFilter getFields(Entity entity) throws UPAException {
        return formulas.getFormulaFields();
    }

    @Override
    public Expression translateExpression(Expression e) throws UPAException {
        return formulas.translateExpression(e);
    }

    @Override
    public void afterDeleteHelper(RemoveEvent event, Expression updatedExpression) throws UPAException {
        Entity entity = event.getEntity();
        entity.createUpdateQuery().validate(getFields(entity)).byExpression(updatedExpression).execute();
    }

    @Override
    public void afterUpdateHelper(UpdateEvent event, Expression updatedExpression) throws UPAException {
        Entity entity = event.getEntity();
        entity.createUpdateQuery().validate(getFields(entity)).byExpression(updatedExpression).execute();
    }

    @Override
    public void afterPersistHelper(PersistEvent event, Expression translatedExpression) throws UPAException {
        Entity entity = event.getEntity();
        entity.createUpdateQuery().validate(getFields(entity)).byExpression(translatedExpression).execute();
    }

}
