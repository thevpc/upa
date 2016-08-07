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
     * @creationdate 8/29/12 11:32 PM
     */
    public class HierarchicalRelationshipSupport : Net.Vpc.Upa.Extensions.HierarchyExtension {

        private string hierarchySeparator;

        private string hierarchyPathField;

        private Net.Vpc.Upa.Relationship treeRelation;

        public HierarchicalRelationshipSupport(Net.Vpc.Upa.Relationship treeRelation) {
            this.treeRelation = treeRelation;
        }

        public virtual string GetHierarchyPathSeparator() {
            return hierarchySeparator;
        }

        public virtual void SetHierarchyPathSeparator(string hierarchySeparator) {
            this.hierarchySeparator = hierarchySeparator;
        }

        public virtual string GetHierarchyPathField() {
            return hierarchyPathField;
        }

        public virtual void SetHierarchyPathField(string hierarchyPathField) {
            this.hierarchyPathField = hierarchyPathField;
        }

        private Net.Vpc.Upa.Entity GetEntity() {
            return treeRelation.GetSourceRole().GetEntity();
        }

        public virtual bool IsParent(object parentId, object childId) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            string p = ToStringId(parentId);
            string c = ToStringId(childId);
            return GetEntity().GetEntityCount(new Net.Vpc.Upa.Expressions.And(new Net.Vpc.Upa.Expressions.Or(new Net.Vpc.Upa.Expressions.Like(new Net.Vpc.Upa.Expressions.Var(GetHierarchyPathField()), new Net.Vpc.Upa.Expressions.Param("isParentParam", "%/" + p + "/%/" + c)), new Net.Vpc.Upa.Expressions.Like(new Net.Vpc.Upa.Expressions.Var(GetHierarchyPathField()), new Net.Vpc.Upa.Expressions.Param("isParentParam", "%/" + p + "/" + c))), GetEntity().GetBuilder().IdToExpression(childId, null))) > 0;
        }

        public virtual bool IsEqualOrIsParent(object parentId, object childId) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            string p = ToStringId(parentId);
            //        String c = getPathPartFromId(childId);
            return GetEntity().GetEntityCount(new Net.Vpc.Upa.Expressions.And(new Net.Vpc.Upa.Expressions.Or(new Net.Vpc.Upa.Expressions.Like(new Net.Vpc.Upa.Expressions.Var(GetHierarchyPathField()), new Net.Vpc.Upa.Expressions.Param("isEqualOrIsParentParam1", "%/" + p + "/%")), new Net.Vpc.Upa.Expressions.Like(new Net.Vpc.Upa.Expressions.Var(GetHierarchyPathField()), new Net.Vpc.Upa.Expressions.Param("isEqualOrIsParentParam2", "%/" + p))), GetEntity().GetBuilder().IdToExpression(childId, null))) > 0;
        }

        public static Net.Vpc.Upa.Relationship GetTreeRelationName(Net.Vpc.Upa.Entity e) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Relationship r = null;
            foreach (Net.Vpc.Upa.Relationship relation in e.GetPersistenceUnit().GetRelationshipsBySource(e)) {
                if (relation.GetTargetRole().GetEntity().Equals(e)) {
                    if (r != null) {
                        throw new System.Exception("Ambiguity in resolving tree relation");
                    }
                    r = relation;
                }
            }
            return r;
        }

        public virtual Net.Vpc.Upa.Relationship GetTreeRelationship() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return treeRelation;
        }

        public virtual Net.Vpc.Upa.Expressions.Expression CreateFindRootsExpression(string alias) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Expressions.Var v = new Net.Vpc.Upa.Expressions.Var(alias == null ? null : new Net.Vpc.Upa.Expressions.Var(alias), GetHierarchyPathField());
            return new Net.Vpc.Upa.Expressions.Equals(v, new Net.Vpc.Upa.Expressions.Concat(new Net.Vpc.Upa.Expressions.Expression[] { new Net.Vpc.Upa.Expressions.Literal(GetHierarchyPathField()), v }));
        }

        public virtual Net.Vpc.Upa.Expressions.Expression CreateFindDeepChildrenExpression(string alias, object id, bool includeId) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Expressions.Expression v = null;
            if (alias == null) {
                v = new Net.Vpc.Upa.Expressions.Var(GetHierarchyPathField());
            } else {
                Net.Vpc.Upa.Expressions.Expression r = GetEntity().GetPersistenceUnit().GetExpressionManager().ParseExpression(alias);
                if (!(r is Net.Vpc.Upa.Expressions.Var)) {
                    throw new System.ArgumentException ("Only var expressions are supported");
                }
                v = new Net.Vpc.Upa.Expressions.Var((Net.Vpc.Upa.Expressions.Var) r, GetHierarchyPathField());
            }
            if (includeId) {
                return new Net.Vpc.Upa.Expressions.Or(new Net.Vpc.Upa.Expressions.Like(v, new Net.Vpc.Upa.Expressions.Literal("%" + GetHierarchyPathSeparator() + id)), new Net.Vpc.Upa.Expressions.Like(v, new Net.Vpc.Upa.Expressions.Literal("%" + GetHierarchyPathSeparator() + id + GetHierarchyPathSeparator() + "%")));
            } else {
                return new Net.Vpc.Upa.Expressions.Like(v, new Net.Vpc.Upa.Expressions.Literal("%" + GetHierarchyPathSeparator() + id + GetHierarchyPathSeparator() + "%"));
            }
        }

        public virtual Net.Vpc.Upa.Expressions.Expression CreateFindImmediateChildrenExpression(string alias, object id) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            System.Collections.Generic.IList<Net.Vpc.Upa.Field> parentFields = GetTreeRelationship().GetSourceRole().GetFields();
            Net.Vpc.Upa.Expressions.Expression a = null;
            Net.Vpc.Upa.Key key = GetEntity().GetBuilder().IdToKey(id);
            for (int i = 0; i < (parentFields).Count; i++) {
                Net.Vpc.Upa.Field field = parentFields[i];
                Net.Vpc.Upa.Expressions.Var v = new Net.Vpc.Upa.Expressions.Var(alias == null ? null : new Net.Vpc.Upa.Expressions.Var(alias), field.GetName());
                Net.Vpc.Upa.Expressions.Expression e = (new Net.Vpc.Upa.Expressions.Equals(v, new Net.Vpc.Upa.Expressions.Literal(key.GetObjectAt(i), field.GetDataType())));
                a = a == null ? ((Net.Vpc.Upa.Expressions.Expression)(e)) : new Net.Vpc.Upa.Expressions.And(a, e);
            }
            return a;
        }

        public virtual string ToStringId(object id) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return ToStringKey(GetEntity().GetBuilder().IdToKey(id));
        }

        public virtual string ToStringKey(Net.Vpc.Upa.Key key) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (key == null) {
                return "";
            }
            System.Text.StringBuilder s = new System.Text.StringBuilder();
            object[] kvalue = key.GetValue();
            for (int i = 0; i < kvalue.Length; i++) {
                if (i > 0) {
                    s.Append(GetHierarchyPathSeparator());
                }
                s.Append(kvalue[i].ToString());
            }
            return s.ToString();
        }

        private System.Collections.Generic.IList<Net.Vpc.Upa.Field> GetUpdateTreeFields() {
            Net.Vpc.Upa.Relationship treeRelation = GetTreeRelationship();
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

        protected internal virtual void ValidatePathField(object id, Net.Vpc.Upa.Persistence.EntityExecutionContext executionContext) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            System.Collections.Generic.IList<Net.Vpc.Upa.Field> lfs = GetTreeRelationship().GetSourceRole().GetFields();
            object[] parent_id = new object[(lfs).Count];
            Net.Vpc.Upa.Record values = GetEntity().CreateQueryBuilder().ByExpression(GetEntity().GetBuilder().IdToExpression(id, null)).SetFieldFilter(Net.Vpc.Upa.Filters.Fields.Regular().And(Net.Vpc.Upa.Filters.Fields.ByList(lfs))).GetRecord();
            if (values == null) {
                parent_id = null;
            } else {
                for (int i = 0; i < parent_id.Length; i++) {
                    Net.Vpc.Upa.Field field = lfs[i];
                    parent_id[i] = values.GetObject<T>(field.GetName());
                    if (parent_id[i] != null) {
                        continue;
                    }
                    parent_id = null;
                    break;
                }
            }
            string path = ToStringId(id);
            if (parent_id != null) {
                Net.Vpc.Upa.Record r = GetEntity().CreateQueryBuilder().ByExpression(GetEntity().GetBuilder().IdToExpression(GetEntity().CreateId(parent_id), null)).SetFieldFilter(Net.Vpc.Upa.Filters.Fields.ByName(GetHierarchyPathField())).GetRecord();
                if (r != null) {
                    path = r.GetString(GetHierarchyPathField()) + GetHierarchyPathSeparator() + path;
                }
            }
            Net.Vpc.Upa.Record r2 = GetEntity().GetBuilder().CreateRecord();
            r2.SetString(GetHierarchyPathField(), path);
            GetEntity().UpdateCore(r2, GetEntity().GetBuilder().IdToExpression(id, GetEntity().GetName()), executionContext);
        }

        protected internal virtual void ValidateChildren(object key, Net.Vpc.Upa.Persistence.EntityExecutionContext executionContext) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Record r = GetEntity().CreateQueryBuilder().ByExpression(GetEntity().GetBuilder().IdToExpression(key, null)).SetFieldFilter(Net.Vpc.Upa.Filters.Fields.ByName(GetHierarchyPathField())).GetRecord();
            System.Collections.Generic.IList<Net.Vpc.Upa.Field> lfs = GetTreeRelationship().GetSourceRole().GetFields();
            Net.Vpc.Upa.Expressions.Concat concat = new Net.Vpc.Upa.Expressions.Concat();
            concat.Add(new Net.Vpc.Upa.Expressions.Literal(r.GetString(GetHierarchyPathField()), GetEntity().GetField(GetHierarchyPathField()).GetDataType()));
            System.Collections.Generic.IList<Net.Vpc.Upa.Field> primaryFields = GetEntity().GetPrimaryFields();
            foreach (Net.Vpc.Upa.Field f in primaryFields) {
                concat.Add(new Net.Vpc.Upa.Expressions.Literal(GetHierarchyPathSeparator()));
                Net.Vpc.Upa.Types.DataType t = f.GetDataType();
                Net.Vpc.Upa.Expressions.Var var = new Net.Vpc.Upa.Expressions.Var(f.GetName());
                Net.Vpc.Upa.Expressions.Expression svar = null;
                if (t is Net.Vpc.Upa.Types.StringType) {
                    svar = var;
                } else if (t is Net.Vpc.Upa.Types.IntType) {
                    svar = new Net.Vpc.Upa.Expressions.I2V(var);
                } else if (t is Net.Vpc.Upa.Types.LongType) {
                    svar = new Net.Vpc.Upa.Expressions.I2V(var);
                } else if (t is Net.Vpc.Upa.Types.DoubleType) {
                    svar = new Net.Vpc.Upa.Expressions.D2V(var);
                } else if (t is Net.Vpc.Upa.Types.FloatType) {
                    svar = new Net.Vpc.Upa.Expressions.D2V(var);
                } else {
                    throw new System.ArgumentException ("Unsupported ");
                }
                concat.Add(svar);
            }
            Net.Vpc.Upa.Record s = GetEntity().GetBuilder().CreateRecord();
            s.SetObject(GetHierarchyPathField(), concat);
            Net.Vpc.Upa.Expressions.Expression p = null;
            Net.Vpc.Upa.Relationship rel = GetTreeRelationship();
            object[] kvalue = GetEntity().GetBuilder().IdToKey(key).GetValue();
            for (int i = 0; i < rel.Size(); i++) {
                Net.Vpc.Upa.Field field = lfs[i];
                Net.Vpc.Upa.Expressions.Expression e = (new Net.Vpc.Upa.Expressions.Equals(new Net.Vpc.Upa.Expressions.Var(field.GetName()), new Net.Vpc.Upa.Expressions.Literal(kvalue[i], field.GetDataType())));
                p = p == null ? ((Net.Vpc.Upa.Expressions.Expression)(e)) : new Net.Vpc.Upa.Expressions.And(p, e);
            }
            GetEntity().UpdateCore(s, p, executionContext);
            System.Collections.Generic.IList<object> children = GetEntity().CreateQueryBuilder().ByExpression(p).GetIdList<K>();
            foreach (object aChildren in children) {
                ValidateChildren(aChildren, executionContext);
            }
        }

        public virtual object FindEntityByMainPath(string mainFieldPath) {
            Net.Vpc.Upa.Entity entity = GetEntity();
            return entity.CreateQueryBuilder().ByExpression(CreateFindEntityByMainPathExpression(mainFieldPath, null)).GetEntity<R>();
        }

        public virtual object FindEntityByIdPath(object[] idPath) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Entity entity = GetEntity();
            return entity.CreateQueryBuilder().ByExpression(CreateFindEntityByIdPathExpression(idPath, null)).GetEntity<R>();
        }

        public virtual object FindEntityByKeyPath(Net.Vpc.Upa.Key[] keyPath) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Entity entity = GetEntity();
            return entity.CreateQueryBuilder().ByExpression(CreateFindEntityByKeyPathExpression(keyPath, null)).GetEntity<R>();
        }

        public virtual Net.Vpc.Upa.Expressions.Expression CreateFindEntityByIdPathExpression(object[] idPath, string entityAlias) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Entity entity = GetEntity();
            if (entityAlias == null) {
                entityAlias = entity.GetName();
            }
            System.Text.StringBuilder b = new System.Text.StringBuilder();
            foreach (object o in idPath) {
                b.Append(GetHierarchyPathSeparator());
                b.Append(ToStringId(o));
            }
            return new Net.Vpc.Upa.Expressions.Equals(new Net.Vpc.Upa.Expressions.Var(new Net.Vpc.Upa.Expressions.Var(entityAlias), GetHierarchyPathField()), new Net.Vpc.Upa.Expressions.Param(entityAlias + "_ebip", b.ToString()));
        }

        public virtual Net.Vpc.Upa.Expressions.Expression CreateFindEntityByKeyPathExpression(Net.Vpc.Upa.Key[] keyPath, string entityAlias) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Entity entity = GetEntity();
            if (entityAlias == null) {
                entityAlias = entity.GetName();
            }
            System.Text.StringBuilder b = new System.Text.StringBuilder();
            foreach (Net.Vpc.Upa.Key o in keyPath) {
                b.Append(GetHierarchyPathSeparator());
                b.Append(ToStringKey(o));
            }
            return new Net.Vpc.Upa.Expressions.Equals(new Net.Vpc.Upa.Expressions.Var(new Net.Vpc.Upa.Expressions.Var(entityAlias), GetHierarchyPathField()), new Net.Vpc.Upa.Expressions.Param(entityAlias + "_ebip", b.ToString()));
        }

        public virtual Net.Vpc.Upa.Expressions.Expression CreateFindEntityByMainPathExpression(string mainFieldPath, string entityAlias) {
            Net.Vpc.Upa.Entity entity = GetEntity();
            Net.Vpc.Upa.RelationshipRole detailRole = GetTreeRelationship().GetSourceRole();
            if (Net.Vpc.Upa.Impl.Util.StringUtils.IsNullOrEmpty(mainFieldPath)) {
                return null;
            }
            string mainFieldName = entity.GetMainField().GetName();
            object mainFieldValue = null;
            object parent = null;
            string[] parentAndName = Net.Vpc.Upa.Impl.Util.StringUtils.Split(mainFieldPath, GetHierarchyPathSeparator()[0], false);
            if (parentAndName != null) {
                parent = FindEntityByMainPath(parentAndName[0]);
                mainFieldValue = parentAndName[1];
            } else {
                mainFieldValue = mainFieldPath;
            }
            Net.Vpc.Upa.Expressions.Expression expr = null;
            if (entityAlias == null) {
                entityAlias = entity.GetName();
            }
            expr = new Net.Vpc.Upa.Expressions.Equals(new Net.Vpc.Upa.Expressions.Var(new Net.Vpc.Upa.Expressions.Var(entityAlias), mainFieldName), mainFieldValue);
            Net.Vpc.Upa.Key entityToKey = parent == null ? null : entity.GetBuilder().ObjectToKey(parent);
            System.Collections.Generic.IList<Net.Vpc.Upa.Field> primaryFields = detailRole.GetFields();
            for (int index = 0; index < (primaryFields).Count; index++) {
                Net.Vpc.Upa.Field field = primaryFields[index];
                expr = new Net.Vpc.Upa.Expressions.And(expr, new Net.Vpc.Upa.Expressions.Equals(new Net.Vpc.Upa.Expressions.Var(new Net.Vpc.Upa.Expressions.Var(entityAlias), field.GetName()), entityToKey == null ? null : entityToKey.GetObjectAt(index)));
            }
            return expr;
        }

        public virtual  System.Collections.Generic.IList<T> FindDeepChildrenEntityList<T>(object id, bool includeId) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return treeRelation.GetPersistenceUnit().CreateQueryBuilder(GetEntity().GetName()).ByExpression(CreateFindDeepChildrenExpression(GetEntity().GetName(), id, includeId)).GetEntityList<R>();
        }

        public virtual  System.Collections.Generic.IList<T> FindImmediateChildrenEntityList<T>(object id) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return treeRelation.GetPersistenceUnit().CreateQueryBuilder(GetEntity().GetName()).ByExpression(CreateFindImmediateChildrenExpression(GetEntity().GetName(), id)).GetEntityList<R>();
        }

        public virtual  System.Collections.Generic.IList<T> FindRootsEntityList<T>() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return treeRelation.GetPersistenceUnit().CreateQueryBuilder(GetEntity().GetName()).ByExpression(CreateFindRootsExpression(GetEntity().GetName())).GetEntityList<R>();
        }
    }
}
