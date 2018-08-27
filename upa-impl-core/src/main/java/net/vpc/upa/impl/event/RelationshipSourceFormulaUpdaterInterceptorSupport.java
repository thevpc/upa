/*
 * Created by IntelliJ IDEA.
 * User: taha
 * Date: 8 nov. 02
 * Time: 21:57:02
 * To change template for new class use
 * Code Style | Class Templates options (Tools | IDE Options).
 */
package net.vpc.upa.impl.event;


import net.vpc.upa.Entity;
import net.vpc.upa.Relationship;
import net.vpc.upa.events.UpdateRelationshipSourceFormulaInterceptor;
import net.vpc.upa.events.EntityTriggerContext;
import net.vpc.upa.events.PersistEvent;
import net.vpc.upa.events.UpdateEvent;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.expressions.Expression;
import net.vpc.upa.filters.FieldFilter;

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
     * @throws net.vpc.upa.exceptions.UPAException
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
