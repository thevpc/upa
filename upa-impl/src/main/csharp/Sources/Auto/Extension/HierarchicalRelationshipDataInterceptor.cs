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



namespace Net.Vpc.Upa.Impl.Extension
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 1/6/13 12:09 AM
     */
    public class HierarchicalRelationshipDataInterceptor : Net.Vpc.Upa.Callbacks.EntityListenerAdapter {

        private Net.Vpc.Upa.Relationship relation;

        private Net.Vpc.Upa.Impl.Extension.HierarchicalRelationshipSupport support;

        public HierarchicalRelationshipDataInterceptor(Net.Vpc.Upa.Relationship defaultTreeEntityExtensionSupport)  : base(){

            this.relation = defaultTreeEntityExtensionSupport;
            support = (Net.Vpc.Upa.Impl.Extension.HierarchicalRelationshipSupport) relation.GetHierarchyExtension();
        }


        public override void OnPreUpdateFormula(Net.Vpc.Upa.Callbacks.UpdateFormulaEvent @event) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Persistence.EntityExecutionContext executionContext = @event.GetContext();
            Net.Vpc.Upa.Relationship r = relation;
            System.Collections.Generic.IList<Net.Vpc.Upa.Field> fs = r.GetSourceRole().GetFields();
            Net.Vpc.Upa.Expressions.Expression cond = new Net.Vpc.Upa.Expressions.And(new Net.Vpc.Upa.Expressions.Equals(new Net.Vpc.Upa.Expressions.Var(fs[0].GetName()), Net.Vpc.Upa.Expressions.Literal.NULL), @event.GetFilterExpression());
            System.Collections.Generic.IList<object> keys = relation.GetSourceRole().GetEntity().CreateQueryBuilder().SetExpression(cond).GetIdList<object>();
            foreach (object key in keys) {
                support.ValidatePathField(key, executionContext);
                support.ValidateChildren(key, executionContext);
            }
        }


        public override void OnPersist(Net.Vpc.Upa.Callbacks.PersistEvent @event) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Key parent_key = relation.GetKey(@event.GetPersistedRecord());
            object[] parent_id = parent_key == null ? null : parent_key.GetValue();
            string path = support.GetHierarchyPathSeparator() + support.ToStringId(@event.GetPersistedId());
            string pathFieldName = support.GetHierarchyPathField();
            Net.Vpc.Upa.Entity entity = relation.GetSourceRole().GetEntity();
            if (parent_id != null) {
                Net.Vpc.Upa.Record r = entity.CreateQueryBuilder().SetExpression(entity.GetBuilder().IdToExpression(entity.CreateId(parent_id), null)).SetFieldFilter(Net.Vpc.Upa.Filters.Fields.ByName(pathFieldName)).GetRecord();
                if (r != null) {
                    path = r.GetString(pathFieldName) + path;
                }
            }
            @event.GetPersistedRecord().SetString(pathFieldName, path);
            Net.Vpc.Upa.Persistence.EntityExecutionContext executionContext = @event.GetContext();
            Net.Vpc.Upa.Persistence.EntityExecutionContext updateContext = executionContext.GetPersistenceUnit().GetFactory().CreateObject<Net.Vpc.Upa.Persistence.EntityExecutionContext>(typeof(Net.Vpc.Upa.Persistence.EntityExecutionContext));
            updateContext.InitPersistenceUnit(executionContext.GetPersistenceUnit(), executionContext.GetPersistenceStore(), Net.Vpc.Upa.Persistence.ContextOperation.UPDATE);
            Net.Vpc.Upa.Record u2 = entity.GetBuilder().CreateRecord();
            u2.SetString(pathFieldName, path);
            entity.UpdateCore(u2, entity.GetBuilder().IdToExpression(@event.GetPersistedId(), entity.GetName()), updateContext);
        }

        private System.Collections.Generic.IList<Net.Vpc.Upa.Field> GetUpdateTreeFields() {
            Net.Vpc.Upa.Relationship treeRelation = relation;
            System.Collections.Generic.IList<Net.Vpc.Upa.Field> updateTreeFields = new System.Collections.Generic.List<Net.Vpc.Upa.Field>();
            switch(treeRelation.GetSourceRole().GetRelationshipUpdateType()) {
                case Net.Vpc.Upa.RelationshipUpdateType.COMPOSED:
                    {
                        Net.Vpc.Upa.Field f = treeRelation.GetSourceRole().GetEntityField();
                        if (f != null) {
                            updateTreeFields.Add(f);
                        }
                        break;
                    }
                case Net.Vpc.Upa.RelationshipUpdateType.FLAT:
                    {
                        System.Collections.Generic.IList<Net.Vpc.Upa.Field> fields = treeRelation.GetSourceRole().GetFields();
                        if (fields != null) {
                            foreach (Net.Vpc.Upa.Field f in fields) {
                                updateTreeFields.Add(f);
                            }
                        }
                        break;
                    }
            }
            return updateTreeFields;
        }


        public override void OnPreUpdate(Net.Vpc.Upa.Callbacks.UpdateEvent @event) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Persistence.EntityExecutionContext executionContext = @event.GetContext();
            System.Collections.Generic.IList<Net.Vpc.Upa.Field> updateTreeFields = GetUpdateTreeFields();
            Net.Vpc.Upa.Record updates = @event.GetUpdatesRecord();
            if (!updates.IsSet(updateTreeFields[0].GetName())) {
                return;
            }
            object val = updates.GetObject<object>(updateTreeFields[0].GetName());
            if (val is Net.Vpc.Upa.Expressions.Literal) {
                val = ((Net.Vpc.Upa.Expressions.Literal) val).GetValue();
            } else if (val is Net.Vpc.Upa.Expressions.Expression) {
                //                    Log.bug("1232123");
                return;
            }
            if (val != null) {
                Net.Vpc.Upa.Key parent_key = relation.GetKey(updates);
                Net.Vpc.Upa.Entity entity = @event.GetEntity();
                object newKey = (object) entity.GetBuilder().KeyToId(parent_key);
                string k = "recurse";
                if (!executionContext.IsSet(k)) {
                    System.Collections.Generic.IList<object> idList = entity.CreateQueryBuilder().SetExpression(@event.GetFilterExpression()).SetOrder(entity.GetUpdateFormulasOrder()).GetIdList<object>();
                    executionContext.SetObject(k, idList);
                }
                System.Collections.Generic.IList<object> r = (System.Collections.Generic.IList<object>) executionContext.GetObject<System.Collections.Generic.IList<object>>("recurse");
                foreach (object aR in r) {
                    if (support.IsEqualOrIsParent(aR, newKey)) {
                        throw new Net.Vpc.Upa.Exceptions.UPAException("RedundancyProblem");
                    }
                }
            }
        }


        public override void OnUpdate(Net.Vpc.Upa.Callbacks.UpdateEvent @event) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Persistence.EntityExecutionContext executionContext = @event.GetContext();
            //        RelationRole detailRole = defaultTreeEntityExtensionSupport.getTreeRelation().getSourceRole();
            //        if (!map.isSet(detailRole.getField(0).getName())) {
            //            return;
            //        }
            System.Collections.Generic.IList<Net.Vpc.Upa.Field> updateTreeFields = GetUpdateTreeFields();
            if (!@event.GetUpdatesRecord().IsSet(updateTreeFields[0].GetName())) {
                return;
            }
            System.Collections.Generic.IList<object> r = (System.Collections.Generic.IList<object>) executionContext.GetObject<System.Collections.Generic.IList<object>>("recurse");
            if (r != null) {
                foreach (object aR in r) {
                    support.ValidatePathField(aR, executionContext);
                    support.ValidateChildren(aR, executionContext);
                }
            }
        }
    }
}
