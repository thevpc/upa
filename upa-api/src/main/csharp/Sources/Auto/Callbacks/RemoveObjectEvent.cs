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



namespace Net.TheVpc.Upa.Callbacks
{


    /**
     *
     * @author taha.bensalah@gmail.com
     */
    public class RemoveObjectEvent : Net.TheVpc.Upa.Callbacks.RemoveEvent {

        private object objectId;

        public RemoveObjectEvent(object objectId, Net.TheVpc.Upa.Expressions.Expression filterExpression, Net.TheVpc.Upa.Persistence.EntityExecutionContext entityExecutionContext, Net.TheVpc.Upa.EventPhase phase)  : base(filterExpression, entityExecutionContext, phase){

            this.objectId = objectId;
        }

        public virtual object GetObjectId() {
            return objectId;
        }
    }
}
