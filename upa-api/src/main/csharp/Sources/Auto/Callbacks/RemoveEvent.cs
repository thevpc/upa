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
    public class RemoveEvent : Net.Vpc.Upa.Callbacks.EntityEvent {

        private Net.Vpc.Upa.Expressions.Expression filterExpression;

        public RemoveEvent(Net.Vpc.Upa.Expressions.Expression filterExpression, Net.Vpc.Upa.Persistence.EntityExecutionContext entityExecutionContext, Net.Vpc.Upa.EventPhase phase)  : base(entityExecutionContext, phase){

            this.filterExpression = filterExpression;
        }

        public virtual Net.Vpc.Upa.Expressions.Expression GetFilterExpression() {
            return filterExpression;
        }
    }
}
