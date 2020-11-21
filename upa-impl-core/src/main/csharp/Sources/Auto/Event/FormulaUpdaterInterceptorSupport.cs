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



namespace Net.TheVpc.Upa.Impl.Event
{


    public class FormulaUpdaterInterceptorSupport : Net.TheVpc.Upa.Impl.Event.ExpressionHelperInterceptorSupport {

        private Net.TheVpc.Upa.Callbacks.UpdateFormulaInterceptor formulas;

        public FormulaUpdaterInterceptorSupport(Net.TheVpc.Upa.Callbacks.UpdateFormulaInterceptor formulas) {
            this.formulas = formulas;
        }

        protected internal virtual Net.TheVpc.Upa.Filters.FieldFilter GetFields(Net.TheVpc.Upa.Entity entity) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return formulas.GetFormulaFields();
        }


        public override Net.TheVpc.Upa.Expressions.Expression TranslateExpression(Net.TheVpc.Upa.Expressions.Expression e) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return formulas.TranslateExpression(e);
        }


        public override void AfterDeleteHelper(Net.TheVpc.Upa.Callbacks.RemoveEvent @event, Net.TheVpc.Upa.Expressions.Expression updatedExpression) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.Entity entity = @event.GetEntity();
            entity.CreateUpdateQuery().Validate(GetFields(entity)).ByExpression(updatedExpression).Execute();
        }


        public override void AfterUpdateHelper(Net.TheVpc.Upa.Callbacks.UpdateEvent @event, Net.TheVpc.Upa.Expressions.Expression updatedExpression) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.Entity entity = @event.GetEntity();
            entity.CreateUpdateQuery().Validate(GetFields(entity)).ByExpression(updatedExpression).Execute();
        }


        public override void AfterPersistHelper(Net.TheVpc.Upa.Callbacks.PersistEvent @event, Net.TheVpc.Upa.Expressions.Expression translatedExpression) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.Entity entity = @event.GetEntity();
            entity.CreateUpdateQuery().Validate(GetFields(entity)).ByExpression(translatedExpression).Execute();
        }
    }
}
