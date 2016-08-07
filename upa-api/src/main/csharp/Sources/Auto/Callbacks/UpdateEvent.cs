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



namespace Net.Vpc.Upa.Callbacks
{


    /**
     *
     * @author taha.bensalah@gmail.com
     */
    public class UpdateEvent : Net.Vpc.Upa.Callbacks.EntityEvent {

        private Net.Vpc.Upa.Record updatesRecord;

        private object updatesObject;

        private Net.Vpc.Upa.Expressions.Expression filterExpression;

        public UpdateEvent(Net.Vpc.Upa.Record updatesRecord, Net.Vpc.Upa.Expressions.Expression filterExpression, Net.Vpc.Upa.Persistence.EntityExecutionContext entityExecutionContext, Net.Vpc.Upa.EventPhase phase)  : base(entityExecutionContext, phase){

            this.updatesRecord = updatesRecord;
            this.filterExpression = filterExpression;
        }

        public virtual Net.Vpc.Upa.Record GetUpdatesRecord() {
            return updatesRecord;
        }

        public virtual object GetUpdatesObject() {
            if (updatesObject == null && updatesRecord != null) {
                updatesObject = GetContext().GetEntity().GetBuilder().RecordToObject<object>(updatesRecord);
            }
            return updatesObject;
        }

        public virtual Net.Vpc.Upa.Expressions.Expression GetFilterExpression() {
            return filterExpression;
        }
    }
}
