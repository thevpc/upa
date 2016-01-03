/*********************************************************
 *********************************************************
 **   DO NOT EDIT                                       **
 **                                                     **
 **   THIS FILE AS BEEN GENERATED AUTOMATICALLY         **
 **   BY UPA PORTABLE GENERATOR                         **
 **   (c) vpc                                           **
 **                                                     **
 *********************************************************
 ********************************************************/



namespace Net.Vpc.Upa.Impl.Event
{


    public class RelationshipTargetFormulaUpdaterInterceptorSupport : Net.Vpc.Upa.Impl.Event.FormulaUpdaterInterceptorSupport {

        private Net.Vpc.Upa.Callbacks.UpdateRelationshipTargetFormulaInterceptor entityTargetFormulaUpdaterInterceptor;

        private Net.Vpc.Upa.Relationship relation;

        private Net.Vpc.Upa.Filters.FieldFilter relationFilter;

        public RelationshipTargetFormulaUpdaterInterceptorSupport(Net.Vpc.Upa.Callbacks.UpdateRelationshipTargetFormulaInterceptor entityTargetFormulaUpdaterInterceptor)  : base(new Net.Vpc.Upa.Impl.Event.RelationshipTargetFormulaUpdaterInterceptorSupportBaseInterceptor(entityTargetFormulaUpdaterInterceptor)){

            this.entityTargetFormulaUpdaterInterceptor = entityTargetFormulaUpdaterInterceptor;
        }

        public virtual Net.Vpc.Upa.Relationship GetRelationship(Net.Vpc.Upa.Callbacks.EntityTriggerContext context) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (relation == null) {
                context.GetEntity().GetPersistenceUnit().GetRelationship(entityTargetFormulaUpdaterInterceptor.GetRelationshipName());
            }
            return relation;
        }


        public override bool AcceptUpdateTableHelper(Net.Vpc.Upa.Callbacks.UpdateEvent @event) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Filters.FieldFilter conditionFields = entityTargetFormulaUpdaterInterceptor.GetConditionFields();
            if (conditionFields == null) {
                return true;
            }
            if (relationFilter == null) {
                relationFilter = Net.Vpc.Upa.Filters.Fields.Regular().And(Net.Vpc.Upa.Filters.Fields.ByList(relation.GetSourceRole().GetFields()));
            }
            Net.Vpc.Upa.Filters.FieldFilter actualFilter = Net.Vpc.Upa.Filters.Fields.As(conditionFields).Or(relationFilter);
            Net.Vpc.Upa.Entity entityManager = @event.GetEntity();
            foreach (string updatedField in @event.GetUpdatesRecord().KeySet()) {
                if (actualFilter.Accept(entityManager.GetField(updatedField))) {
                    return true;
                }
            }
            return false;
        }


        public override bool AcceptUpdateTableOlderValuesHelper(Net.Vpc.Upa.Callbacks.UpdateEvent @event) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (relationFilter == null) {
                relationFilter = Net.Vpc.Upa.Filters.Fields.Regular().And(Net.Vpc.Upa.Filters.Fields.ByList(relation.GetSourceRole().GetFields()));
            }
            Net.Vpc.Upa.Entity entityManager = @event.GetEntity();
            foreach (string updatedField in @event.GetUpdatesRecord().KeySet()) {
                if (relationFilter.Accept(entityManager.GetField(updatedField))) {
                    return true;
                }
            }
            return false;
        }


        public override Net.Vpc.Upa.Expressions.Expression TranslateExpression(Net.Vpc.Upa.Expressions.Expression e) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return relation.GetTargetCondition(e, relation.GetSourceRole().GetEntity().GetName(), relation.GetTargetRole().GetEntity().GetName());
        }


        public override string ToString() {
            return (GetType()).Name + "(" + entityTargetFormulaUpdaterInterceptor + ")";
        }
    }
}
