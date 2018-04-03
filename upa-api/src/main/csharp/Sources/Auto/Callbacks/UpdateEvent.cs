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
     * @author taha.bensalah@gmail.com
     */
    public class UpdateEvent : Net.Vpc.Upa.Callbacks.EntityEvent {

        private Net.Vpc.Upa.Document updatesDocument;

        private object updatesObject;

        private Net.Vpc.Upa.Expressions.Expression filterExpression;

        public UpdateEvent(Net.Vpc.Upa.Document updatesDocument, Net.Vpc.Upa.Expressions.Expression filterExpression, Net.Vpc.Upa.Persistence.EntityExecutionContext entityExecutionContext, Net.Vpc.Upa.EventPhase phase)  : base(entityExecutionContext, phase){

            this.updatesDocument = updatesDocument;
            this.filterExpression = filterExpression;
        }

        public virtual Net.Vpc.Upa.Document GetUpdatesDocument() {
            return updatesDocument;
        }

        public virtual object GetUpdatesObject() {
            if (updatesObject == null && updatesDocument != null) {
                Net.Vpc.Upa.EntityBuilder builder = GetContext().GetEntity().GetBuilder();
                updatesObject = builder.DocumentToObject<>(updatesDocument);
                if (GetFilterExpression() is Net.Vpc.Upa.Expressions.IdExpression) {
                    object id = ((Net.Vpc.Upa.Expressions.IdExpression) GetFilterExpression()).GetId();
                    builder.SetObjectId(updatesObject, id);
                }
            }
            return updatesObject;
        }

        public virtual Net.Vpc.Upa.Expressions.Expression GetFilterExpression() {
            return filterExpression;
        }

        public virtual void StoreUpdatedIds() {
            System.Collections.Generic.IList<object> @object = (System.Collections.Generic.IList<object>) this.GetContext().GetObject<>("updated_ids_" + this.GetEntity().GetName());
            if (@object != null) {
                //already loaded
                return;
            }
            Net.Vpc.Upa.Expressions.Expression expr = this.GetFilterExpression();
            Net.Vpc.Upa.Entity entity = this.GetEntity();
            if (expr is Net.Vpc.Upa.Expressions.IdEnumerationExpression) {
                Net.Vpc.Upa.Expressions.IdEnumerationExpression k = (Net.Vpc.Upa.Expressions.IdEnumerationExpression) expr;
                expr = new Net.Vpc.Upa.Expressions.IdEnumerationExpression(k.GetIds(), new Net.Vpc.Upa.Expressions.Var("this"));
            }
            Net.Vpc.Upa.PersistenceUnit pu = this.GetPersistenceUnit();
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
