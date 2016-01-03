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



namespace Net.Vpc.Upa.Impl.Event
{


    public class FormulaUpdaterInterceptorSupport : Net.Vpc.Upa.Impl.Event.ExpressionHelperInterceptorSupport {

        private Net.Vpc.Upa.Callbacks.UpdateFormulaInterceptor formulas;

        public FormulaUpdaterInterceptorSupport(Net.Vpc.Upa.Callbacks.UpdateFormulaInterceptor formulas) {
            this.formulas = formulas;
        }

        protected internal virtual Net.Vpc.Upa.Filters.FieldFilter GetFields(Net.Vpc.Upa.Entity entity) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return formulas.GetFormulaFields();
        }


        public override Net.Vpc.Upa.Expressions.Expression TranslateExpression(Net.Vpc.Upa.Expressions.Expression e) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return formulas.TranslateExpression(e);
        }


        public override void AfterDeleteHelper(Net.Vpc.Upa.Callbacks.RemoveEvent @event, Net.Vpc.Upa.Expressions.Expression updatedExpression) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Entity entity = @event.GetEntity();
            entity.UpdateFormulasCore(GetFields(entity), updatedExpression, @event.GetContext());
        }


        public override void AfterUpdateHelper(Net.Vpc.Upa.Callbacks.UpdateEvent @event, Net.Vpc.Upa.Expressions.Expression updatedExpression) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Entity entity = @event.GetEntity();
            entity.UpdateFormulasCore(GetFields(entity), updatedExpression, @event.GetContext());
        }


        public override void AfterInsertHelper(Net.Vpc.Upa.Callbacks.PersistEvent @event, Net.Vpc.Upa.Expressions.Expression translatedExpression) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Entity entity = @event.GetEntity();
            entity.UpdateFormulasCore(GetFields(entity), translatedExpression, @event.GetContext());
        }
    }
}
