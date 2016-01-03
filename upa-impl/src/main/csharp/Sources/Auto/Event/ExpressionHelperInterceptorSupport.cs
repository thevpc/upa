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


    public abstract class ExpressionHelperInterceptorSupport : Net.Vpc.Upa.Callbacks.EntityListenerAdapter {

        public ExpressionHelperInterceptorSupport() {
        }

        public abstract Net.Vpc.Upa.Expressions.Expression TranslateExpression(Net.Vpc.Upa.Expressions.Expression e) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

        public abstract void AfterDeleteHelper(Net.Vpc.Upa.Callbacks.RemoveEvent @event, Net.Vpc.Upa.Expressions.Expression updatedExpression) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

        public abstract void AfterUpdateHelper(Net.Vpc.Upa.Callbacks.UpdateEvent @event, Net.Vpc.Upa.Expressions.Expression updatedExpression) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

        public abstract void AfterInsertHelper(Net.Vpc.Upa.Callbacks.PersistEvent @event, Net.Vpc.Upa.Expressions.Expression translatedExpression) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

        public virtual bool AcceptDeleteTableHelper(Net.Vpc.Upa.Callbacks.RemoveEvent @event) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return true;
        }

        public virtual bool AcceptUpdateTableHelper(Net.Vpc.Upa.Callbacks.UpdateEvent @event) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return true;
        }

        public virtual bool AcceptUpdateTableOlderValuesHelper(Net.Vpc.Upa.Callbacks.UpdateEvent @event) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return false;
        }

        public virtual bool AcceptInsertRecordHelper(Net.Vpc.Upa.Callbacks.PersistEvent @event) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return true;
        }


        public override sealed void OnPreRemove(Net.Vpc.Upa.Callbacks.RemoveEvent @event) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Persistence.EntityExecutionContext executionContext = @event.GetContext();
            if (AcceptDeleteTableHelper(@event)) {
                executionContext.SetObject(@event.GetTrigger().GetName() + ":toDelete", CreateUpdatedCollection(@event.GetEntity(), @event.GetFilterExpression()));
            }
        }


        public override sealed void OnRemove(Net.Vpc.Upa.Callbacks.RemoveEvent @event) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Persistence.EntityExecutionContext executionContext = @event.GetContext();
            string name = @event.GetTrigger().GetName();
            System.Collections.Generic.ICollection<Net.Vpc.Upa.Key> collection = (System.Collections.Generic.ICollection<Net.Vpc.Upa.Key>) executionContext.GetObject<System.Collections.Generic.ICollection<Net.Vpc.Upa.Key>>(name + ":toDelete");
            if (collection == null) {
                return;
            }
            executionContext.Remove(name + ":toDelete");
            if (!(collection.Count==0)) {
                AfterDeleteHelper(@event, CreateInCollection(@event.GetEntity(), collection));
            }
        }


        public override sealed void OnPreUpdate(Net.Vpc.Upa.Callbacks.UpdateEvent @event) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            string name = @event.GetTrigger().GetName();
            Net.Vpc.Upa.Persistence.EntityExecutionContext executioncontext = @event.GetContext();
            if (AcceptUpdateTableHelper(@event)) {
                System.Collections.Generic.ICollection<Net.Vpc.Upa.Key> v = CreateUpdatedCollection(@event.GetEntity(), @event.GetFilterExpression());
                if (!(v.Count==0)) {
                    executioncontext.SetObject(name + ":toUpdate", v);
                }
            }
        }


        public override sealed void OnUpdate(Net.Vpc.Upa.Callbacks.UpdateEvent @event) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            // validate old references
            Net.Vpc.Upa.Persistence.EntityExecutionContext executioncontext = @event.GetContext();
            string name = @event.GetTrigger().GetName();
            System.Collections.Generic.ICollection<Net.Vpc.Upa.Key> collection = executioncontext.GetObject<System.Collections.Generic.ICollection<Net.Vpc.Upa.Key>>(name + ":toUpdate");
            if (collection == null) {
                return;
            }
            executioncontext.Remove(name + ":toUpdate");
            Net.Vpc.Upa.Impl.Uql.Expression.KeyCollectionExpression inColl = null;
            if (!(collection.Count==0)) {
                inColl = CreateInCollection(@event.GetEntity(), collection);
                AfterUpdateHelper(@event, inColl);
            }
            // validate old references
            if (AcceptUpdateTableOlderValuesHelper(@event)) {
                Net.Vpc.Upa.Expressions.Expression newUpdates = null;
                if (inColl != null) {
                    Net.Vpc.Upa.Expressions.Expression translated = TranslateExpression(@event.GetFilterExpression());
                    if (translated != null) {
                        newUpdates = new Net.Vpc.Upa.Expressions.And(new Net.Vpc.Upa.Expressions.Not(inColl), translated);
                    } else {
                        newUpdates = new Net.Vpc.Upa.Expressions.Not(inColl);
                    }
                } else {
                    newUpdates = TranslateExpression(@event.GetFilterExpression());
                }
                AfterUpdateHelper(@event, newUpdates);
            }
        }

        private System.Collections.Generic.ICollection<Net.Vpc.Upa.Key> CreateUpdatedCollection(Net.Vpc.Upa.Entity entity, Net.Vpc.Upa.Expressions.Expression expression) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return entity.CreateQueryBuilder().SetExpression(TranslateExpression(expression)).GetKeyList();
        }

        private Net.Vpc.Upa.Impl.Uql.Expression.KeyCollectionExpression CreateInCollection(Net.Vpc.Upa.Entity entity, System.Collections.Generic.ICollection<Net.Vpc.Upa.Key> collection) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            System.Collections.Generic.IList<Net.Vpc.Upa.Field> pfs = entity.GetPrimaryFields();
            Net.Vpc.Upa.Expressions.Var[] v = new Net.Vpc.Upa.Expressions.Var[(pfs).Count];
            for (int i = 0; i < (pfs).Count; i++) {
                v[i] = new Net.Vpc.Upa.Expressions.Var(new Net.Vpc.Upa.Expressions.Var(pfs[i].GetEntity().GetName()), pfs[i].GetName());
            }
            if ((pfs).Count == 1) {
                Net.Vpc.Upa.Impl.Uql.Expression.KeyCollectionExpression inColl = new Net.Vpc.Upa.Impl.Uql.Expression.KeyCollectionExpression(v[0]);
                //inColl.setClientProperty(DefaultEntity.EXPRESSION_SURELY_EXISTS, true);
                foreach (Net.Vpc.Upa.Key k in collection) {
                    inColl.Add(new Net.Vpc.Upa.Expressions.Literal(k.GetObject(), pfs[0].GetDataType()));
                }
                return inColl;
            } else {
                Net.Vpc.Upa.Impl.Uql.Expression.KeyCollectionExpression inColl = new Net.Vpc.Upa.Impl.Uql.Expression.KeyCollectionExpression(v);
                //inColl.setClientProperty(DefaultEntity.EXPRESSION_SURELY_EXISTS, true);
                foreach (Net.Vpc.Upa.Key k in collection) {
                    Net.Vpc.Upa.Expressions.Literal[] l = new Net.Vpc.Upa.Expressions.Literal[(pfs).Count];
                    for (int j = 0; j < (pfs).Count; j++) {
                        l[j] = new Net.Vpc.Upa.Expressions.Literal(k.GetObjectAt(j), pfs[j].GetDataType());
                    }
                    inColl.Add(l);
                }
                return inColl;
            }
        }


        public override sealed void OnPersist(Net.Vpc.Upa.Callbacks.PersistEvent @event) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (AcceptInsertRecordHelper(@event)) {
                AfterInsertHelper(@event, TranslateExpression(@event.GetEntity().GetBuilder().IdToExpression(@event.GetPersistedId(), null)));
            }
        }
    }
}
