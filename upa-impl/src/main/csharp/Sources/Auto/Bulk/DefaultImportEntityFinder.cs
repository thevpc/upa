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



namespace Net.Vpc.Upa.Impl.Bulk
{


    /**
     *
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public class DefaultImportEntityFinder : Net.Vpc.Upa.Bulk.ImportEntityFinder, Net.Vpc.Upa.Bulk.ImportEntityMapper {

        public virtual System.Collections.Generic.IDictionary<string , object> ValueToMap(Net.Vpc.Upa.Entity entity, object @value) {
            System.Collections.Generic.IList<Net.Vpc.Upa.Extensions.HierarchyExtension> c = new System.Collections.Generic.List<Net.Vpc.Upa.Extensions.HierarchyExtension>();
            foreach (Net.Vpc.Upa.Relationship relation in entity.GetRelationships()) {
                if (relation.GetHierarchyExtension() != null) {
                    c.Add(relation.GetHierarchyExtension());
                }
            }
            if ((c.Count==0)) {
                System.Collections.Generic.IList<Net.Vpc.Upa.Index> indexes = entity.GetIndexes(true);
                if ((indexes.Count==0)) {
                    throw new System.ArgumentException ("No Index found for entity " + entity);
                }
                foreach (Net.Vpc.Upa.Index index in indexes) {
                    string[] indexedFieldNames = index.GetFieldNames();
                    if (indexedFieldNames.Length == 1) {
                        System.Collections.Generic.IDictionary<string , object> m = new System.Collections.Generic.Dictionary<string , object>();
                        m[indexedFieldNames[0]]=@value;
                        return m;
                    }
                }
                throw new System.ArgumentException ("Unsupported Multiple Field Index on import");
            } else {
                System.Collections.Generic.IDictionary<string , object> map = new System.Collections.Generic.Dictionary<string , object>();
                string v = System.Convert.ToString(@value == null ? ((object)("")) : @value);
                if (v.StartsWith("/")) {
                    v = v.Substring(1);
                }
                if (v.Contains("/")) {
                    int i = v.LastIndexOf('/');
                    map[entity.GetMainField().GetName()]=v.Substring(i + 1);
                    map[c[0].GetTreeRelationship().GetSourceRole().GetEntityField().GetName()]=v.Substring(0,(i)-(0));
                } else {
                    map[entity.GetMainField().GetName()]=@value;
                }
                return map;
            }
        }

        public virtual object FindEntity(Net.Vpc.Upa.Entity entity, System.Collections.Generic.IDictionary<string , object> values) {
            System.Collections.Generic.IList<Net.Vpc.Upa.Extensions.HierarchyExtension> c = new System.Collections.Generic.List<Net.Vpc.Upa.Extensions.HierarchyExtension>();
            foreach (Net.Vpc.Upa.Relationship relation in entity.GetRelationships()) {
                if (relation.GetHierarchyExtension() != null) {
                    c.Add(relation.GetHierarchyExtension());
                }
            }
            if ((c.Count==0)) {
                System.Collections.Generic.IList<Net.Vpc.Upa.Index> indexes = entity.GetIndexes(true);
                foreach (Net.Vpc.Upa.Index index in indexes) {
                    Net.Vpc.Upa.Expressions.Expression expr = null;
                    string[] indexedFieldNames = index.GetFieldNames();
                    foreach (string f in indexedFieldNames) {
                        Net.Vpc.Upa.Expressions.Equals e = new Net.Vpc.Upa.Expressions.Equals(new Net.Vpc.Upa.Expressions.Var(new Net.Vpc.Upa.Expressions.Var(entity.GetName()), f), Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,object>(values,f));
                        expr = (expr == null) ? ((Net.Vpc.Upa.Expressions.Expression)(e)) : new Net.Vpc.Upa.Expressions.And(expr, e);
                    }
                    return entity.CreateQueryBuilder().SetExpression(expr).GetEntity<object>();
                }
                return null;
            } else {
                Net.Vpc.Upa.Extensions.HierarchyExtension extension = c[0];
                Net.Vpc.Upa.RelationshipRole detailRole = extension.GetTreeRelationship().GetSourceRole();
                string parentFieldName = detailRole.GetEntityField().GetName();
                object parent = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,object>(values,parentFieldName);
                string mainFieldName = entity.GetMainField().GetName();
                if (parent != null && (parent is string)) {
                    parent = extension.FindEntityByMainPath(System.Convert.ToString(parent));
                }
                Net.Vpc.Upa.Expressions.Expression expr = null;
                expr = new Net.Vpc.Upa.Expressions.Equals(new Net.Vpc.Upa.Expressions.Var(new Net.Vpc.Upa.Expressions.Var(entity.GetName()), mainFieldName), Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,object>(values,mainFieldName));
                Net.Vpc.Upa.Key entityToKey = parent == null ? null : entity.GetBuilder().EntityToKey(parent);
                System.Collections.Generic.IList<Net.Vpc.Upa.Field> primaryFields = detailRole.GetFields();
                for (int index = 0; index < (primaryFields).Count; index++) {
                    Net.Vpc.Upa.Field field = primaryFields[index];
                    expr = new Net.Vpc.Upa.Expressions.And(expr, new Net.Vpc.Upa.Expressions.Equals(new Net.Vpc.Upa.Expressions.Var(new Net.Vpc.Upa.Expressions.Var(entity.GetName()), field.GetName()), entityToKey == null ? null : entityToKey.GetObjectAt(index)));
                }
                return entity.CreateQueryBuilder().SetExpression(expr).GetEntity<object>();
            }
        }

        public virtual bool Accept(Net.Vpc.Upa.Entity entity) {
            return true;
        }
    }
}
