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
     * @author vpc
     */
    public class UpdateObjectEvent : Net.Vpc.Upa.Callbacks.UpdateEvent {

        private object objectId;

        public UpdateObjectEvent(object objectId, Net.Vpc.Upa.Record updatesRecord, Net.Vpc.Upa.Expressions.Expression filterExpression, Net.Vpc.Upa.Persistence.EntityExecutionContext entityExecutionContext)  : base(updatesRecord, filterExpression, entityExecutionContext){

            this.objectId = objectId;
        }

        public virtual object GetObjectId() {
            return objectId;
        }
    }
}
