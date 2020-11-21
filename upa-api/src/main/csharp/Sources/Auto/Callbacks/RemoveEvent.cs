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
    public class RemoveEvent : Net.TheVpc.Upa.Callbacks.EntityEvent {

        private Net.TheVpc.Upa.Expressions.Expression filterExpression;

        public RemoveEvent(Net.TheVpc.Upa.Expressions.Expression filterExpression, Net.TheVpc.Upa.Persistence.EntityExecutionContext entityExecutionContext, Net.TheVpc.Upa.EventPhase phase)  : base(entityExecutionContext, phase){

            this.filterExpression = filterExpression;
        }

        public virtual Net.TheVpc.Upa.Expressions.Expression GetFilterExpression() {
            return filterExpression;
        }
    }
}
