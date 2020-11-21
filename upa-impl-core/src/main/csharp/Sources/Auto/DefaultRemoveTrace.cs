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



using System.Linq;
namespace Net.TheVpc.Upa.Impl
{


    public class DefaultRemoveTrace : Net.TheVpc.Upa.RemoveTrace {

        private System.Collections.Generic.IDictionary<Net.TheVpc.Upa.RelationshipType , System.Collections.Generic.IDictionary<string , long?>> infos;

        private System.Collections.Generic.IList<string> stackTrace;

        public DefaultRemoveTrace() {
            infos = new System.Collections.Generic.Dictionary<Net.TheVpc.Upa.RelationshipType , System.Collections.Generic.IDictionary<string , long?>>(1);
            stackTrace = new System.Collections.Generic.List<string>(1);
        }

        public virtual void AddTrace(string trace) {
            stackTrace.Add(trace);
        }

        public virtual void Add(Net.TheVpc.Upa.RelationshipType type, Net.TheVpc.Upa.Entity entity, long count) {
            Add(type, entity.GetName(), count);
        }

        private void Add(Net.TheVpc.Upa.RelationshipType type, string table, long count) {
            System.Collections.Generic.IDictionary<string , long?> tabInfos = Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<Net.TheVpc.Upa.RelationshipType,System.Collections.Generic.IDictionary<string , long?>>(infos,type);
            if (tabInfos == null) {
                tabInfos = new System.Collections.Generic.Dictionary<string , long?>();
                infos[type]=tabInfos;
            }
            long? l = Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,long?>(tabInfos,table);
            if (l == null) {
                tabInfos[table]=count;
            } else {
                tabInfos[table]=l + count;
            }
        }

        public virtual void Add(Net.TheVpc.Upa.RemoveTrace other) {
            foreach (Net.TheVpc.Upa.DeletionTraceElement dependencyElement in other.GetTrace()) {
                Add(dependencyElement.GetRelationshipType(), dependencyElement.GetEntityName(), dependencyElement.GetCount());
            }
        }

        public virtual Net.TheVpc.Upa.DeletionTraceElement[] GetTrace(Net.TheVpc.Upa.RelationshipType type) {
            System.Collections.Generic.IDictionary<string , long?> m = Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<Net.TheVpc.Upa.RelationshipType,System.Collections.Generic.IDictionary<string , long?>>(infos,type);
            System.Collections.Generic.List<Net.TheVpc.Upa.DeletionTraceElement> elements = new System.Collections.Generic.List<Net.TheVpc.Upa.DeletionTraceElement>();
            if (m != null) {
                foreach (System.Collections.Generic.KeyValuePair<string , long?> e2 in new System.Collections.Generic.HashSet<System.Collections.Generic.KeyValuePair<string,long?>>(m)) {
                    string tabName = (e2).Key;
                    long tabCount = ((e2).Value).Value;
                    if (tabCount > 0) {
                        elements.Add(new Net.TheVpc.Upa.Impl.DefaultDeletionTraceElement(type, tabName, tabCount));
                    }
                }
            }
            return elements.ToArray();
        }

        public virtual Net.TheVpc.Upa.DeletionTraceElement[] GetTrace() {
            System.Collections.Generic.IList<Net.TheVpc.Upa.DeletionTraceElement> elements = new System.Collections.Generic.List<Net.TheVpc.Upa.DeletionTraceElement>();
            foreach (System.Collections.Generic.KeyValuePair<Net.TheVpc.Upa.RelationshipType , System.Collections.Generic.IDictionary<string , long?>> e in new System.Collections.Generic.HashSet<System.Collections.Generic.KeyValuePair<Net.TheVpc.Upa.RelationshipType,System.Collections.Generic.IDictionary<string , long?>>>(infos)) {
                Net.TheVpc.Upa.RelationshipType type = (e).Key;
                foreach (System.Collections.Generic.KeyValuePair<string , long?> e2 in new System.Collections.Generic.HashSet<System.Collections.Generic.KeyValuePair<string,long?>>((e).Value)) {
                    string tabName = (e2).Key;
                    long tabCount = ((e2).Value).Value;
                    if (tabCount > 0) {
                        elements.Add(new Net.TheVpc.Upa.Impl.DefaultDeletionTraceElement(type, tabName, tabCount));
                    }
                }
            }
            return elements.ToArray();
        }

        public override string ToString() {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            bool first = true;
            sb.Append("DeleteInfo : ");
            foreach (System.Collections.Generic.KeyValuePair<Net.TheVpc.Upa.RelationshipType , System.Collections.Generic.IDictionary<string , long?>> e in new System.Collections.Generic.HashSet<System.Collections.Generic.KeyValuePair<Net.TheVpc.Upa.RelationshipType,System.Collections.Generic.IDictionary<string , long?>>>(infos)) {
                Net.TheVpc.Upa.RelationshipType k = (Net.TheVpc.Upa.RelationshipType) (e).Key;
                string typeName = k.ToString();
                sb.Append("[").Append(typeName).Append("]=").Append("{");
                foreach (System.Collections.Generic.KeyValuePair<string , long?> e2 in new System.Collections.Generic.HashSet<System.Collections.Generic.KeyValuePair<string,long?>>((e).Value)) {
                    string tabName = (e2).Key;
                    long tabCount = ((e2).Value).Value;
                    if (tabCount > 0) {
                        if (first) {
                            first = false;
                        } else {
                            sb.Append(" ; ");
                        }
                        sb.Append(tabCount).Append(" ").Append(tabName);
                    }
                }
            }
            sb.Append("\n");
            sb.Append("\tStackTrace={");
            sb.Append("\n");
            foreach (string aStackTrace in stackTrace) {
                sb.Append("\t\t");
                sb.Append(aStackTrace);
                sb.Append("\n");
            }
            sb.Append("\t}");
            sb.Append("\n");
            return sb.ToString();
        }

        public virtual long GetRemoveCount() {
            long count = 0;
            foreach (System.Collections.Generic.KeyValuePair<Net.TheVpc.Upa.RelationshipType , System.Collections.Generic.IDictionary<string , long?>> e in new System.Collections.Generic.HashSet<System.Collections.Generic.KeyValuePair<Net.TheVpc.Upa.RelationshipType,System.Collections.Generic.IDictionary<string , long?>>>(infos)) {
                foreach (System.Collections.Generic.KeyValuePair<string , long?> e2 in new System.Collections.Generic.HashSet<System.Collections.Generic.KeyValuePair<string,long?>>((e).Value)) {
                    long tabCount = ((e2).Value).Value;
                    count += tabCount;
                }
            }
            return count;
        }

        public virtual long GetRemoveCount(Net.TheVpc.Upa.RelationshipType type) {
            long count = 0;
            foreach (System.Collections.Generic.KeyValuePair<Net.TheVpc.Upa.RelationshipType , System.Collections.Generic.IDictionary<string , long?>> e in new System.Collections.Generic.HashSet<System.Collections.Generic.KeyValuePair<Net.TheVpc.Upa.RelationshipType,System.Collections.Generic.IDictionary<string , long?>>>(infos)) {
                Net.TheVpc.Upa.RelationshipType k = (e).Key;
                if (k == type) {
                    foreach (System.Collections.Generic.KeyValuePair<string , long?> e2 in new System.Collections.Generic.HashSet<System.Collections.Generic.KeyValuePair<string,long?>>((e).Value)) {
                        long tabCount = ((e2).Value).Value;
                        count += tabCount;
                    }
                }
            }
            return count;
        }
    }
}
