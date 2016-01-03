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
    public class RemoveObjectEvent : Net.Vpc.Upa.Callbacks.RemoveEvent {

        private object objectId;

        public RemoveObjectEvent(object objectId, Net.Vpc.Upa.Expressions.Expression filterExpression, Net.Vpc.Upa.Persistence.EntityExecutionContext entityExecutionContext)  : base(filterExpression, entityExecutionContext){

            this.objectId = objectId;
        }

        public virtual object GetObjectId() {
            return objectId;
        }
    }
}
