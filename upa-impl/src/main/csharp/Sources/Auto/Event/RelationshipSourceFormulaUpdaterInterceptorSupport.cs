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


    public class RelationshipSourceFormulaUpdaterInterceptorSupport : Net.Vpc.Upa.Impl.Event.FormulaUpdaterInterceptorSupport {

        private Net.Vpc.Upa.Callbacks.UpdateRelationshipSourceFormulaInterceptor entityDetailFormulaUpdaterInterceptor;

        private Net.Vpc.Upa.Relationship relation;

        public RelationshipSourceFormulaUpdaterInterceptorSupport(Net.Vpc.Upa.Callbacks.UpdateRelationshipSourceFormulaInterceptor entityDetailFormulaUpdaterInterceptor)  : base(new Net.Vpc.Upa.Impl.Event.RelationshipSourceFormulaUpdaterInterceptorSupportBaseInterceptor(entityDetailFormulaUpdaterInterceptor)){

            this.entityDetailFormulaUpdaterInterceptor = entityDetailFormulaUpdaterInterceptor;
        }

        public virtual Net.Vpc.Upa.Relationship GetRelationship(Net.Vpc.Upa.Callbacks.EntityTriggerContext context) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (relation == null) {
                context.GetEntity().GetPersistenceUnit().GetRelationship(entityDetailFormulaUpdaterInterceptor.GetRelationshipName());
            }
            return relation;
        }

        /**
             * if master created no validation is needed for details
             *
             *
             *
             * @param context
             * @param key
             * @param record
             * @return
             * @throws net.vpc.upa.exceptions.UPAException
             */

        public override bool AcceptPersistRecordHelper(Net.Vpc.Upa.Callbacks.PersistEvent @event) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return false;
        }


        public override bool AcceptUpdateTableHelper(Net.Vpc.Upa.Callbacks.UpdateEvent @event) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Filters.FieldFilter conditionFields = entityDetailFormulaUpdaterInterceptor.GetConditionFields();
            if (conditionFields == null) {
                return true;
            }
            Net.Vpc.Upa.Entity entityManager = @event.GetEntity();
            foreach (string updatedField in @event.GetUpdatesRecord().KeySet()) {
                if (conditionFields.Accept(entityManager.GetField(updatedField))) {
                    return true;
                }
            }
            return false;
        }


        public override Net.Vpc.Upa.Expressions.Expression TranslateExpression(Net.Vpc.Upa.Expressions.Expression e) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return relation.GetSourceCondition(e, relation.GetSourceRole().GetEntity().GetName(), relation.GetTargetRole().GetEntity().GetName());
        }

        public override string ToString() {
            return (GetType()).Name + "(" + entityDetailFormulaUpdaterInterceptor + ")";
        }
    }
}
