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



namespace Net.TheVpc.Upa.Impl.Event
{


    public class RelationshipTargetFormulaUpdaterInterceptorSupport : Net.TheVpc.Upa.Impl.Event.FormulaUpdaterInterceptorSupport {

        private Net.TheVpc.Upa.Callbacks.UpdateRelationshipTargetFormulaInterceptor entityTargetFormulaUpdaterInterceptor;

        private Net.TheVpc.Upa.Relationship relation;

        private Net.TheVpc.Upa.Filters.FieldFilter relationFilter;

        public RelationshipTargetFormulaUpdaterInterceptorSupport(Net.TheVpc.Upa.Callbacks.UpdateRelationshipTargetFormulaInterceptor entityTargetFormulaUpdaterInterceptor)  : base(new Net.TheVpc.Upa.Impl.Event.RelationshipTargetFormulaUpdaterInterceptorSupportBaseInterceptor(entityTargetFormulaUpdaterInterceptor)){

            this.entityTargetFormulaUpdaterInterceptor = entityTargetFormulaUpdaterInterceptor;
        }

        public virtual Net.TheVpc.Upa.Relationship GetRelationship(Net.TheVpc.Upa.Callbacks.EntityTriggerContext context) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            if (relation == null) {
                context.GetEntity().GetPersistenceUnit().GetRelationship(entityTargetFormulaUpdaterInterceptor.GetRelationshipName());
            }
            return relation;
        }


        public override bool AcceptUpdateTableHelper(Net.TheVpc.Upa.Callbacks.UpdateEvent @event) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.Filters.FieldFilter conditionFields = entityTargetFormulaUpdaterInterceptor.GetConditionFields();
            if (conditionFields == null) {
                return true;
            }
            if (relationFilter == null) {
                relationFilter = Net.TheVpc.Upa.Filters.Fields.Regular().And(Net.TheVpc.Upa.Filters.Fields.ByList(relation.GetSourceRole().GetFields()));
            }
            Net.TheVpc.Upa.Filters.FieldFilter actualFilter = Net.TheVpc.Upa.Filters.Fields.As(conditionFields).Or(relationFilter);
            Net.TheVpc.Upa.Entity entityManager = @event.GetEntity();
            foreach (string updatedField in @event.GetUpdatesRecord().KeySet()) {
                if (actualFilter.Accept(entityManager.GetField(updatedField))) {
                    return true;
                }
            }
            return false;
        }


        public override bool AcceptUpdateTableOlderValuesHelper(Net.TheVpc.Upa.Callbacks.UpdateEvent @event) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            if (relationFilter == null) {
                relationFilter = Net.TheVpc.Upa.Filters.Fields.Regular().And(Net.TheVpc.Upa.Filters.Fields.ByList(relation.GetSourceRole().GetFields()));
            }
            Net.TheVpc.Upa.Entity entityManager = @event.GetEntity();
            foreach (string updatedField in @event.GetUpdatesRecord().KeySet()) {
                if (relationFilter.Accept(entityManager.GetField(updatedField))) {
                    return true;
                }
            }
            return false;
        }


        public override Net.TheVpc.Upa.Expressions.Expression TranslateExpression(Net.TheVpc.Upa.Expressions.Expression e) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return relation.GetTargetCondition(e, relation.GetSourceRole().GetEntity().GetName(), relation.GetTargetRole().GetEntity().GetName());
        }


        public override string ToString() {
            return (GetType()).Name + "(" + entityTargetFormulaUpdaterInterceptor + ")";
        }
    }
}
