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


    public abstract class ExpressionHelperInterceptorSupport : Net.TheVpc.Upa.Callbacks.EntityListenerAdapter {

        public ExpressionHelperInterceptorSupport() {
        }

        public abstract Net.TheVpc.Upa.Expressions.Expression TranslateExpression(Net.TheVpc.Upa.Expressions.Expression e) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

        public abstract void AfterDeleteHelper(Net.TheVpc.Upa.Callbacks.RemoveEvent @event, Net.TheVpc.Upa.Expressions.Expression updatedExpression) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

        public abstract void AfterUpdateHelper(Net.TheVpc.Upa.Callbacks.UpdateEvent @event, Net.TheVpc.Upa.Expressions.Expression updatedExpression) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

        public abstract void AfterPersistHelper(Net.TheVpc.Upa.Callbacks.PersistEvent @event, Net.TheVpc.Upa.Expressions.Expression translatedExpression) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

        public virtual bool AcceptDeleteTableHelper(Net.TheVpc.Upa.Callbacks.RemoveEvent @event) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return true;
        }

        public virtual bool AcceptUpdateTableHelper(Net.TheVpc.Upa.Callbacks.UpdateEvent @event) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return true;
        }

        public virtual bool AcceptUpdateTableOlderValuesHelper(Net.TheVpc.Upa.Callbacks.UpdateEvent @event) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return false;
        }

        /**
             *
             * @param event
             * @return
             * @throws UPAException
             */
        public virtual bool AcceptPersistRecordHelper(Net.TheVpc.Upa.Callbacks.PersistEvent @event) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return true;
        }


        public override sealed void OnPreRemove(Net.TheVpc.Upa.Callbacks.RemoveEvent @event) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.Persistence.EntityExecutionContext executionContext = @event.GetContext();
            if (AcceptDeleteTableHelper(@event)) {
                executionContext.SetObject(@event.GetTrigger().GetName() + ":toDelete", CreateUpdatedCollection(@event.GetEntity(), @event.GetFilterExpression()));
            }
        }


        public override sealed void OnRemove(Net.TheVpc.Upa.Callbacks.RemoveEvent @event) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.Persistence.EntityExecutionContext executionContext = @event.GetContext();
            string name = @event.GetTrigger().GetName();
            System.Collections.Generic.ICollection<Net.TheVpc.Upa.Key> collection = (System.Collections.Generic.ICollection<Net.TheVpc.Upa.Key>) executionContext.GetObject<T>(name + ":toDelete");
            if (collection == null) {
                return;
            }
            executionContext.Remove(name + ":toDelete");
            if (!(collection.Count==0)) {
                AfterDeleteHelper(@event, CreateInCollection(@event.GetEntity(), collection));
            }
        }


        public override sealed void OnPreUpdate(Net.TheVpc.Upa.Callbacks.UpdateEvent @event) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            string name = @event.GetTrigger().GetName();
            Net.TheVpc.Upa.Persistence.EntityExecutionContext executioncontext = @event.GetContext();
            if (AcceptUpdateTableHelper(@event)) {
                System.Collections.Generic.ICollection<Net.TheVpc.Upa.Key> v = CreateUpdatedCollection(@event.GetEntity(), @event.GetFilterExpression());
                if (!(v.Count==0)) {
                    executioncontext.SetObject(name + ":toUpdate", v);
                }
            }
        }


        public override sealed void OnUpdate(Net.TheVpc.Upa.Callbacks.UpdateEvent @event) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            // validate old references
            Net.TheVpc.Upa.Persistence.EntityExecutionContext executioncontext = @event.GetContext();
            string name = @event.GetTrigger().GetName();
            System.Collections.Generic.ICollection<Net.TheVpc.Upa.Key> collection = executioncontext.GetObject<T>(name + ":toUpdate");
            if (collection == null) {
                return;
            }
            executioncontext.Remove(name + ":toUpdate");
            Net.TheVpc.Upa.Expressions.IdCollectionExpression inColl = null;
            if (!(collection.Count==0)) {
                inColl = CreateInCollection(@event.GetEntity(), collection);
                AfterUpdateHelper(@event, inColl);
            }
            // validate old references
            if (AcceptUpdateTableOlderValuesHelper(@event)) {
                Net.TheVpc.Upa.Expressions.Expression newUpdates = null;
                if (inColl != null) {
                    Net.TheVpc.Upa.Expressions.Expression translated = TranslateExpression(@event.GetFilterExpression());
                    if (translated != null) {
                        newUpdates = new Net.TheVpc.Upa.Expressions.And(new Net.TheVpc.Upa.Expressions.Not(inColl), translated);
                    } else {
                        newUpdates = new Net.TheVpc.Upa.Expressions.Not(inColl);
                    }
                } else {
                    newUpdates = TranslateExpression(@event.GetFilterExpression());
                }
                AfterUpdateHelper(@event, newUpdates);
            }
        }

        private System.Collections.Generic.ICollection<Net.TheVpc.Upa.Key> CreateUpdatedCollection(Net.TheVpc.Upa.Entity entity, Net.TheVpc.Upa.Expressions.Expression expression) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return entity.CreateQueryBuilder().ByExpression(TranslateExpression(expression)).GetKeyList();
        }

        private Net.TheVpc.Upa.Expressions.IdCollectionExpression CreateInCollection(Net.TheVpc.Upa.Entity entity, System.Collections.Generic.ICollection<Net.TheVpc.Upa.Key> collection) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            System.Collections.Generic.IList<Net.TheVpc.Upa.Field> pfs = entity.GetPrimaryFields();
            Net.TheVpc.Upa.Expressions.Var[] v = new Net.TheVpc.Upa.Expressions.Var[(pfs).Count];
            for (int i = 0; i < (pfs).Count; i++) {
                v[i] = new Net.TheVpc.Upa.Expressions.Var(new Net.TheVpc.Upa.Expressions.Var(pfs[i].GetEntity().GetName()), pfs[i].GetName());
            }
            if ((pfs).Count == 1) {
                Net.TheVpc.Upa.Expressions.IdCollectionExpression inColl = new Net.TheVpc.Upa.Expressions.IdCollectionExpression(v[0]);
                //inColl.setClientProperty(DefaultEntity.EXPRESSION_SURELY_EXISTS, true);
                foreach (Net.TheVpc.Upa.Key k in collection) {
                    inColl.Add(new Net.TheVpc.Upa.Expressions.Literal(k.GetObject(), pfs[0].GetDataType()));
                }
                return inColl;
            } else {
                Net.TheVpc.Upa.Expressions.IdCollectionExpression inColl = new Net.TheVpc.Upa.Expressions.IdCollectionExpression(v);
                //inColl.setClientProperty(DefaultEntity.EXPRESSION_SURELY_EXISTS, true);
                foreach (Net.TheVpc.Upa.Key k in collection) {
                    Net.TheVpc.Upa.Expressions.Literal[] l = new Net.TheVpc.Upa.Expressions.Literal[(pfs).Count];
                    for (int j = 0; j < (pfs).Count; j++) {
                        l[j] = new Net.TheVpc.Upa.Expressions.Literal(k.GetObjectAt(j), pfs[j].GetDataType());
                    }
                    inColl.Add(l);
                }
                return inColl;
            }
        }


        public override sealed void OnPersist(Net.TheVpc.Upa.Callbacks.PersistEvent @event) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            if (AcceptPersistRecordHelper(@event)) {
                AfterPersistHelper(@event, TranslateExpression(@event.GetEntity().GetBuilder().IdToExpression(@event.GetPersistedId(), null)));
            }
        }
    }
}
