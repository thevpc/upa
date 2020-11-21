/*
 * Created by IntelliJ IDEA.
 * User: taha
 * Date: 15 nov. 02
 * Time: 13:25:09
 * To change template for new class use
 * Code Style | Class Templates options (Tools | IDE Options).
 */
package net.thevpc.upa.impl.event;

import net.thevpc.upa.Entity;
import net.thevpc.upa.events.UpdateFormulaInterceptor;
import net.thevpc.upa.events.PersistEvent;
import net.thevpc.upa.events.RemoveEvent;
import net.thevpc.upa.events.UpdateEvent;
import net.thevpc.upa.exceptions.UPAException;
import net.thevpc.upa.expressions.Expression;
import net.thevpc.upa.filters.FieldFilter;

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
        entity.createUpdateQuery().updateFormulas(getFields(entity)).byExpression(updatedExpression).execute();
    }

    @Override
    public void afterUpdateHelper(UpdateEvent event, Expression updatedExpression) throws UPAException {
        Entity entity = event.getEntity();
        entity.createUpdateQuery().updateFormulas(getFields(entity)).byExpression(updatedExpression).execute();
    }

    @Override
    public void afterPersistHelper(PersistEvent event, Expression translatedExpression) throws UPAException {
        Entity entity = event.getEntity();
        entity.createUpdateQuery().updateFormulas(getFields(entity)).byExpression(translatedExpression).execute();
    }

}
