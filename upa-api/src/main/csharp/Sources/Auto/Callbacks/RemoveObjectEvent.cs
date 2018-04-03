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
    public class RemoveObjectEvent : Net.Vpc.Upa.Callbacks.RemoveEvent {

        private object objectId;

        public RemoveObjectEvent(object objectId, Net.Vpc.Upa.Expressions.Expression filterExpression, Net.Vpc.Upa.Persistence.EntityExecutionContext entityExecutionContext, Net.Vpc.Upa.EventPhase phase)  : base(filterExpression, entityExecutionContext, phase){

            this.objectId = objectId;
        }

        public virtual object GetObjectId() {
            return objectId;
        }
    }
}
