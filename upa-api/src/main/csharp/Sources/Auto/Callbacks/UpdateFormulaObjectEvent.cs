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
    public class UpdateFormulaObjectEvent : Net.Vpc.Upa.Callbacks.UpdateFormulaEvent {

        private object objectId;

        public UpdateFormulaObjectEvent(object objectId, Net.Vpc.Upa.Record updates, Net.Vpc.Upa.Expressions.Expression filterExpression, Net.Vpc.Upa.Persistence.EntityExecutionContext entityExecutionContext)  : base(updates, filterExpression, entityExecutionContext){

            this.objectId = objectId;
        }

        public virtual object GetObjectId() {
            return objectId;
        }
    }
}
