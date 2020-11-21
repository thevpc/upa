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
import net.thevpc.upa.events.EntityTriggerContext;
import net.thevpc.upa.events.UpdateRelationshipTargetFormulaInterceptor;
import net.thevpc.upa.events.UpdateEvent;
import net.thevpc.upa.exceptions.UPAException;
import net.thevpc.upa.expressions.Expression;
import net.thevpc.upa.filters.FieldFilter;
import net.thevpc.upa.filters.FieldFilters;

public class RelationshipTargetFormulaUpdaterInterceptorSupport extends FormulaUpdaterInterceptorSupport {
    private UpdateRelationshipTargetFormulaInterceptor entityTargetFormulaUpdaterInterceptor;
    private Relationship relation;
    private FieldFilter relationFilter;
//    private String[] conditions;

    public RelationshipTargetFormulaUpdaterInterceptorSupport(final UpdateRelationshipTargetFormulaInterceptor entityTargetFormulaUpdaterInterceptor) {
        super(new RelationshipTargetFormulaUpdaterInterceptorSupportBaseInterceptor(entityTargetFormulaUpdaterInterceptor));
        this.entityTargetFormulaUpdaterInterceptor = entityTargetFormulaUpdaterInterceptor;
    }

    public Relationship getRelationship(EntityTriggerContext context)throws UPAException{
        if(relation==null){
            context.getEntity().getPersistenceUnit().getRelationship(entityTargetFormulaUpdaterInterceptor.getRelationshipName());
        }
      return relation;
    }

    @Override
    public boolean acceptUpdateTableHelper(UpdateEvent event) throws UPAException {
        FieldFilter conditionFields = entityTargetFormulaUpdaterInterceptor.getConditionFields();
        if (conditionFields == null) {
            return true;
        }
        if(relationFilter==null){
            relationFilter= FieldFilters.regular().and(FieldFilters.byList(relation.getSourceRole().getFields()));
        }
        FieldFilter actualFilter= FieldFilters.as(conditionFields).or(relationFilter);
        Entity entity = event.getEntity();
        for (String updatedField : event.getUpdatesDocument().keySet()) {
            if (actualFilter.accept(entity.getField(updatedField))) {
                return true;
            }
        }
        return false;
    }

    @Override
    public boolean acceptUpdateTableOlderValuesHelper(UpdateEvent event) throws UPAException {
        if(relationFilter==null){
            relationFilter= FieldFilters.regular().and(FieldFilters.byList(relation.getSourceRole().getFields()));
        }
        Entity entity = event.getEntity();
        for (String updatedField : event.getUpdatesDocument().keySet()) {
            if (relationFilter.accept(entity.getField(updatedField))) {
                return true;
            }
        }
        return false;
    }

    @Override
    public Expression translateExpression(Expression e) throws UPAException{
        return relation.getTargetCondition(e, relation.getSourceRole().getEntity().getName(), relation.getTargetRole().getEntity().getName());
    }

    @Override
    public String toString() {
        return getClass().getSimpleName() + "(" + entityTargetFormulaUpdaterInterceptor + ")";
    }

    
}
