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


    public class RelationshipSourceFormulaUpdaterInterceptorSupport : Net.TheVpc.Upa.Impl.Event.FormulaUpdaterInterceptorSupport {

        private Net.TheVpc.Upa.Callbacks.UpdateRelationshipSourceFormulaInterceptor entityDetailFormulaUpdaterInterceptor;

        private Net.TheVpc.Upa.Relationship relation;

        public RelationshipSourceFormulaUpdaterInterceptorSupport(Net.TheVpc.Upa.Callbacks.UpdateRelationshipSourceFormulaInterceptor entityDetailFormulaUpdaterInterceptor)  : base(new Net.TheVpc.Upa.Impl.Event.RelationshipSourceFormulaUpdaterInterceptorSupportBaseInterceptor(entityDetailFormulaUpdaterInterceptor)){

            this.entityDetailFormulaUpdaterInterceptor = entityDetailFormulaUpdaterInterceptor;
        }

        public virtual Net.TheVpc.Upa.Relationship GetRelationship(Net.TheVpc.Upa.Callbacks.EntityTriggerContext context) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
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
             * @throws Net.TheVpc.Upa.exceptions.UPAException
             */

        public override bool AcceptPersistRecordHelper(Net.TheVpc.Upa.Callbacks.PersistEvent @event) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return false;
        }


        public override bool AcceptUpdateTableHelper(Net.TheVpc.Upa.Callbacks.UpdateEvent @event) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.Filters.FieldFilter conditionFields = entityDetailFormulaUpdaterInterceptor.GetConditionFields();
            if (conditionFields == null) {
                return true;
            }
            Net.TheVpc.Upa.Entity entityManager = @event.GetEntity();
            foreach (string updatedField in @event.GetUpdatesRecord().KeySet()) {
                if (conditionFields.Accept(entityManager.GetField(updatedField))) {
                    return true;
                }
            }
            return false;
        }


        public override Net.TheVpc.Upa.Expressions.Expression TranslateExpression(Net.TheVpc.Upa.Expressions.Expression e) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return relation.GetSourceCondition(e, relation.GetSourceRole().GetEntity().GetName(), relation.GetTargetRole().GetEntity().GetName());
        }

        public override string ToString() {
            return (GetType()).Name + "(" + entityDetailFormulaUpdaterInterceptor + ")";
        }
    }
}
