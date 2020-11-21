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
    public class UpdateFormulaEvent : Net.TheVpc.Upa.Callbacks.EntityEvent {

        private Net.TheVpc.Upa.Document updates;

        private Net.TheVpc.Upa.Expressions.Expression filterExpression;

        public UpdateFormulaEvent(Net.TheVpc.Upa.Document updates, Net.TheVpc.Upa.Expressions.Expression filterExpression, Net.TheVpc.Upa.Persistence.EntityExecutionContext entityExecutionContext, Net.TheVpc.Upa.EventPhase phase)  : base(entityExecutionContext, phase){

            this.updates = updates;
            this.filterExpression = filterExpression;
        }

        public virtual Net.TheVpc.Upa.Document GetUpdates() {
            return updates;
        }

        public virtual Net.TheVpc.Upa.Expressions.Expression GetFilterExpression() {
            return filterExpression;
        }
    }
}
