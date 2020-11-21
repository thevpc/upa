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
     * @author taha.bensalah@gmail.com
     */
    public class UpdateEvent : Net.TheVpc.Upa.Callbacks.EntityEvent {

        private Net.TheVpc.Upa.Document updatesDocument;

        private object updatesObject;

        private Net.TheVpc.Upa.Expressions.Expression filterExpression;

        public UpdateEvent(Net.TheVpc.Upa.Document updatesDocument, Net.TheVpc.Upa.Expressions.Expression filterExpression, Net.TheVpc.Upa.Persistence.EntityExecutionContext entityExecutionContext, Net.TheVpc.Upa.EventPhase phase)  : base(entityExecutionContext, phase){

            this.updatesDocument = updatesDocument;
            this.filterExpression = filterExpression;
        }

        public virtual Net.TheVpc.Upa.Document GetUpdatesDocument() {
            return updatesDocument;
        }

        public virtual object GetUpdatesObject() {
            if (updatesObject == null && updatesDocument != null) {
                Net.TheVpc.Upa.EntityBuilder builder = GetContext().GetEntity().GetBuilder();
                updatesObject = builder.DocumentToObject<>(updatesDocument);
                if (GetFilterExpression() is Net.TheVpc.Upa.Expressions.IdExpression) {
                    object id = ((Net.TheVpc.Upa.Expressions.IdExpression) GetFilterExpression()).GetId();
                    builder.SetObjectId(updatesObject, id);
                }
            }
            return updatesObject;
        }

        public virtual Net.TheVpc.Upa.Expressions.Expression GetFilterExpression() {
            return filterExpression;
        }

        public virtual void StoreUpdatedIds() {
            System.Collections.Generic.IList<object> @object = (System.Collections.Generic.IList<object>) this.GetContext().GetObject<>("updated_ids_" + this.GetEntity().GetName());
            if (@object != null) {
                //already loaded
                return;
            }
            Net.TheVpc.Upa.Expressions.Expression expr = this.GetFilterExpression();
            Net.TheVpc.Upa.Entity entity = this.GetEntity();
            if (expr is Net.TheVpc.Upa.Expressions.IdEnumerationExpression) {
                Net.TheVpc.Upa.Expressions.IdEnumerationExpression k = (Net.TheVpc.Upa.Expressions.IdEnumerationExpression) expr;
                expr = new Net.TheVpc.Upa.Expressions.IdEnumerationExpression(k.GetIds(), new Net.TheVpc.Upa.Expressions.Var("this"));
            }
            Net.TheVpc.Upa.PersistenceUnit pu = this.GetPersistenceUnit();
            System.Collections.Generic.IList<object> old = pu.CreateQueryBuilder(entity.GetName()).ByExpression(expr).GetIdList<>();
            int sise = (old).Count;
            //force load!
            this.GetContext().SetObject("updated_ids_" + entity.GetName(), old);
        }

        public virtual  System.Collections.Generic.IList<T> LoadUpdatedIds<T>() {
            System.Collections.Generic.IList<T> @object = (System.Collections.Generic.IList<T>) this.GetContext().GetObject<System.Collections.Generic.IList<T>>("updated_ids_" + this.GetEntity().GetName());
            if (@object == null) {
                throw new System.ArgumentException ("storeUpdatedIds should be called in preUpdate");
            }
            return @object;
        }
    }
}
