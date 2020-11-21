/*
 * Created by IntelliJ IDEA.
 * User: taha
 * Date: 8 nov. 02
 * Time: 21:57:02
 * To change template for new class use
 * Code Style | Class Templates options (Tools | IDE Options).
 */
package net.thevpc.upa.impl.event;


import net.thevpc.upa.Entity;
import net.thevpc.upa.Relationship;
import net.thevpc.upa.events.UpdateRelationshipSourceFormulaInterceptor;
import net.thevpc.upa.events.EntityTriggerContext;
import net.thevpc.upa.events.PersistEvent;
import net.thevpc.upa.events.UpdateEvent;
import net.thevpc.upa.exceptions.UPAException;
import net.thevpc.upa.expressions.Expression;
import net.thevpc.upa.filters.FieldFilter;

public class RelationshipSourceFormulaUpdaterInterceptorSupport extends FormulaUpdaterInterceptorSupport {
    private UpdateRelationshipSourceFormulaInterceptor entityDetailFormulaUpdaterInterceptor;
    private Relationship relation;


    public RelationshipSourceFormulaUpdaterInterceptorSupport(final UpdateRelationshipSourceFormulaInterceptor entityDetailFormulaUpdaterInterceptor) {
        super(new RelationshipSourceFormulaUpdaterInterceptorSupportBaseInterceptor(entityDetailFormulaUpdaterInterceptor));
        this.entityDetailFormulaUpdaterInterceptor = entityDetailFormulaUpdaterInterceptor;
    }

    public Relationship getRelationship(EntityTriggerContext context)throws UPAException{
        if(relation==null){
            context.getEntity().getPersistenceUnit().getRelationship(entityDetailFormulaUpdaterInterceptor.getRelationshipName());
        }
        return relation;
    }

    /**
     * if master created no validation is needed for details
     *
     *
     *
     * @return
     * @throws UPAException
     */
    @Override
    public boolean acceptPersistDocumentHelper(PersistEvent event) throws UPAException {
        return false;
    }

    @Override
    public boolean acceptUpdateTableHelper(UpdateEvent event) throws UPAException {
        FieldFilter conditionFields = entityDetailFormulaUpdaterInterceptor.getConditionFields();
        if (conditionFields == null) {
            return true;
        }
        Entity entity = event.getEntity();
        for (String updatedField : event.getUpdatesDocument().keySet()) {
            if (conditionFields.accept(entity.getField(updatedField))) {
                return true;
            }
        }
        return false;
    }

    @Override
    public Expression translateExpression(Expression e) throws UPAException{
        return relation.getSourceCondition(e, relation.getSourceRole().getEntity().getName(), relation.getTargetRole().getEntity().getName());
    }

    public String toString() {
        return getClass().getSimpleName() + "(" + entityDetailFormulaUpdaterInterceptor + ")";
    }

}
