/*********************************************************
 *********************************************************
 **   DO NOT EDIT                                       **
 **                                                     **
 **   THIS FILE HAS BEEN GENERATED AUTOMATICALLY         **
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
    public class UpdateObjectEvent : Net.Vpc.Upa.Callbacks.UpdateEvent {

        private object objectId;

        public UpdateObjectEvent(object objectId, Net.Vpc.Upa.Document updatesDocument, Net.Vpc.Upa.Expressions.Expression filterExpression, Net.Vpc.Upa.Persistence.EntityExecutionContext entityExecutionContext, Net.Vpc.Upa.EventPhase phase)  : base(updatesDocument, filterExpression, entityExecutionContext, phase){

            this.objectId = objectId;
        }

        public virtual object GetObjectId() {
            return objectId;
        }
    }
}
