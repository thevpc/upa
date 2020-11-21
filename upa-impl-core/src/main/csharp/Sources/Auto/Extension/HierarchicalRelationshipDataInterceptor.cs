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



namespace Net.TheVpc.Upa.Impl.Extension
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 1/6/13 12:09 AM
     */
    public class HierarchicalRelationshipDataInterceptor : Net.TheVpc.Upa.Callbacks.EntityListenerAdapter {

        private Net.TheVpc.Upa.Relationship relation;

        private Net.TheVpc.Upa.Impl.Extension.HierarchicalRelationshipSupport support;

        public HierarchicalRelationshipDataInterceptor(Net.TheVpc.Upa.Relationship defaultTreeEntityExtensionSupport)  : base(){

            this.relation = defaultTreeEntityExtensionSupport;
            support = (Net.TheVpc.Upa.Impl.Extension.HierarchicalRelationshipSupport) relation.GetHierarchyExtension();
        }


        public override void OnPreUpdateFormula(Net.TheVpc.Upa.Callbacks.UpdateFormulaEvent @event) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.Persistence.EntityExecutionContext executionContext = @event.GetContext();
            Net.TheVpc.Upa.Relationship r = relation;
            System.Collections.Generic.IList<Net.TheVpc.Upa.Field> fs = r.GetSourceRole().GetFields();
            Net.TheVpc.Upa.Expressions.Expression cond = new Net.TheVpc.Upa.Expressions.Equals(new Net.TheVpc.Upa.Expressions.Var(fs[0].GetName()), Net.TheVpc.Upa.Expressions.Literal.NULL);
            if (@event.GetFilterExpression() != null) {
                cond = new Net.TheVpc.Upa.Expressions.And(cond, @event.GetFilterExpression());
            }
            System.Collections.Generic.IList<object> keys = relation.GetSourceRole().GetEntity().CreateQueryBuilder().ByExpression(cond).GetIdList<K>();
            foreach (object key in keys) {
                support.ValidatePathField(key, executionContext);
                support.ValidateChildren(key, executionContext);
            }
        }


        public override void OnPersist(Net.TheVpc.Upa.Callbacks.PersistEvent @event) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            object parent_id = relation.ExtractId(@event.GetPersistedRecord());
            string path = support.GetHierarchyPathSeparator() + support.ToStringId(@event.GetPersistedId());
            string pathFieldName = support.GetHierarchyPathField();
            Net.TheVpc.Upa.Entity entity = relation.GetSourceRole().GetEntity();
            if (parent_id != null) {
                Net.TheVpc.Upa.Record r = entity.CreateQueryBuilder().ByExpression(entity.GetBuilder().IdToExpression(parent_id, null)).SetFieldFilter(Net.TheVpc.Upa.Filters.Fields.ByName(pathFieldName)).GetRecord();
                if (r != null) {
                    path = r.GetString(pathFieldName) + path;
                }
            }
            @event.GetPersistedRecord().SetString(pathFieldName, path);
            Net.TheVpc.Upa.Persistence.EntityExecutionContext executionContext = @event.GetContext();
            Net.TheVpc.Upa.Persistence.EntityExecutionContext updateContext = executionContext.GetPersistenceUnit().GetFactory().CreateObject<Net.TheVpc.Upa.Persistence.EntityExecutionContext>(typeof(Net.TheVpc.Upa.Persistence.EntityExecutionContext));
            updateContext.InitPersistenceUnit(executionContext.GetPersistenceUnit(), executionContext.GetPersistenceStore(), Net.TheVpc.Upa.Persistence.ContextOperation.UPDATE);
            Net.TheVpc.Upa.Record u2 = entity.GetBuilder().CreateRecord();
            u2.SetString(pathFieldName, path);
            entity.UpdateCore(u2, entity.GetBuilder().IdToExpression(@event.GetPersistedId(), entity.GetName()), updateContext);
        }

        private System.Collections.Generic.IList<Net.TheVpc.Upa.Field> GetUpdateTreeFields() {
            Net.TheVpc.Upa.Relationship treeRelation = relation;
            System.Collections.Generic.IList<Net.TheVpc.Upa.Field> updateTreeFields = new System.Collections.Generic.List<Net.TheVpc.Upa.Field>();
            switch(treeRelation.GetSourceRole().GetRelationshipUpdateType()) {
                case Net.TheVpc.Upa.RelationshipUpdateType.COMPOSED:
                    {
                        Net.TheVpc.Upa.Field f = treeRelation.GetSourceRole().GetEntityField();
                        if (f != null) {
                            updateTreeFields.Add(f);
                        }
                        break;
                    }
                case Net.TheVpc.Upa.RelationshipUpdateType.FLAT:
                    {
                        System.Collections.Generic.IList<Net.TheVpc.Upa.Field> fields = treeRelation.GetSourceRole().GetFields();
                        if (fields != null) {
                            foreach (Net.TheVpc.Upa.Field f in fields) {
                                updateTreeFields.Add(f);
                            }
                        }
                        break;
                    }
            }
            return updateTreeFields;
        }


        public override void OnPreUpdate(Net.TheVpc.Upa.Callbacks.UpdateEvent @event) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.Persistence.EntityExecutionContext executionContext = @event.GetContext();
            System.Collections.Generic.IList<Net.TheVpc.Upa.Field> updateTreeFields = GetUpdateTreeFields();
            Net.TheVpc.Upa.Record updates = @event.GetUpdatesRecord();
            if (!updates.IsSet(updateTreeFields[0].GetName())) {
                return;
            }
            object val = updates.GetObject<T>(updateTreeFields[0].GetName());
            if (val is Net.TheVpc.Upa.Expressions.Literal) {
                val = ((Net.TheVpc.Upa.Expressions.Literal) val).GetValue();
            } else if (val is Net.TheVpc.Upa.Expressions.Expression) {
                //                    Log.bug("1232123");
                return;
            }
            if (val != null) {
                object parentId = relation.ExtractId(updates);
                if (parentId != null) {
                    Net.TheVpc.Upa.Entity entity = @event.GetEntity();
                    string k = "recurse";
                    if (!executionContext.IsSet(k)) {
                        System.Collections.Generic.IList<object> idList = entity.CreateQueryBuilder().ByExpression(@event.GetFilterExpression()).OrderBy(entity.GetUpdateFormulasOrder()).GetIdList<K>();
                        executionContext.SetObject(k, idList);
                    }
                    System.Collections.Generic.IList<object> r = (System.Collections.Generic.IList<object>) executionContext.GetObject<T>("recurse");
                    foreach (object aR in r) {
                        if (support.IsEqualOrIsParent(aR, parentId)) {
                            throw new Net.TheVpc.Upa.Exceptions.UPAException("RedundancyProblem");
                        }
                    }
                }
            }
        }


        public override void OnUpdate(Net.TheVpc.Upa.Callbacks.UpdateEvent @event) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.Persistence.EntityExecutionContext executionContext = @event.GetContext();
            //        RelationRole detailRole = defaultTreeEntityExtensionSupport.getTreeRelation().getSourceRole();
            //        if (!map.isSet(detailRole.getField(0).getName())) {
            //            return;
            //        }
            System.Collections.Generic.IList<Net.TheVpc.Upa.Field> updateTreeFields = GetUpdateTreeFields();
            if (!@event.GetUpdatesRecord().IsSet(updateTreeFields[0].GetName())) {
                return;
            }
            System.Collections.Generic.IList<object> r = (System.Collections.Generic.IList<object>) executionContext.GetObject<T>("recurse");
            if (r != null) {
                foreach (object aR in r) {
                    support.ValidatePathField(aR, executionContext);
                    support.ValidateChildren(aR, executionContext);
                }
            }
        }
    }
}
