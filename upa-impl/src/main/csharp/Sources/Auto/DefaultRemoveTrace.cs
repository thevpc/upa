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
namespace Net.Vpc.Upa.Impl
{


    public class DefaultRemoveTrace : Net.Vpc.Upa.RemoveTrace {

        private System.Collections.Generic.IDictionary<Net.Vpc.Upa.RelationshipType , System.Collections.Generic.IDictionary<string , long?>> infos;

        private System.Collections.Generic.IList<string> stackTrace;

        public DefaultRemoveTrace() {
            infos = new System.Collections.Generic.Dictionary<Net.Vpc.Upa.RelationshipType , System.Collections.Generic.IDictionary<string , long?>>(1);
            stackTrace = new System.Collections.Generic.List<string>(1);
        }

        public virtual void AddTrace(string trace) {
            stackTrace.Add(trace);
        }

        public virtual void Add(Net.Vpc.Upa.RelationshipType type, Net.Vpc.Upa.Entity entity, long count) {
            Add(type, entity.GetName(), count);
        }

        private void Add(Net.Vpc.Upa.RelationshipType type, string table, long count) {
            System.Collections.Generic.IDictionary<string , long?> tabInfos = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<Net.Vpc.Upa.RelationshipType,System.Collections.Generic.IDictionary<string , long?>>(infos,type);
            if (tabInfos == null) {
                tabInfos = new System.Collections.Generic.Dictionary<string , long?>();
                infos[type]=tabInfos;
            }
            long? l = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,long?>(tabInfos,table);
            if (l == null) {
                tabInfos[table]=count;
            } else {
                tabInfos[table]=(l).Value + count;
            }
        }

        public virtual void Add(Net.Vpc.Upa.RemoveTrace other) {
            foreach (Net.Vpc.Upa.DeletionTraceElement dependencyElement in other.GetTrace()) {
                Add(dependencyElement.GetRelationshipType(), dependencyElement.GetEntityName(), dependencyElement.GetCount());
            }
        }

        public virtual Net.Vpc.Upa.DeletionTraceElement[] GetTrace(Net.Vpc.Upa.RelationshipType type) {
            System.Collections.Generic.IDictionary<string , long?> m = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<Net.Vpc.Upa.RelationshipType,System.Collections.Generic.IDictionary<string , long?>>(infos,type);
            System.Collections.Generic.List<Net.Vpc.Upa.DeletionTraceElement> elements = new System.Collections.Generic.List<Net.Vpc.Upa.DeletionTraceElement>();
            if (m != null) {
                foreach (System.Collections.Generic.KeyValuePair<string , long?> e2 in m) {
                    string tabName = (e2).Key;
                    long tabCount = ((e2).Value).Value;
                    if (tabCount > 0) {
                        elements.Add(new Net.Vpc.Upa.Impl.DefaultDeletionTraceElement(type, tabName, tabCount));
                    }
                }
            }
            return elements.ToArray();
        }

        public virtual Net.Vpc.Upa.DeletionTraceElement[] GetTrace() {
            System.Collections.Generic.IList<Net.Vpc.Upa.DeletionTraceElement> elements = new System.Collections.Generic.List<Net.Vpc.Upa.DeletionTraceElement>();
            foreach (System.Collections.Generic.KeyValuePair<Net.Vpc.Upa.RelationshipType , System.Collections.Generic.IDictionary<string , long?>> e in infos) {
                Net.Vpc.Upa.RelationshipType type = (e).Key;
                foreach (System.Collections.Generic.KeyValuePair<string , long?> e2 in (e).Value) {
                    string tabName = (e2).Key;
                    long tabCount = ((e2).Value).Value;
                    if (tabCount > 0) {
                        elements.Add(new Net.Vpc.Upa.Impl.DefaultDeletionTraceElement(type, tabName, tabCount));
                    }
                }
            }
            return elements.ToArray();
        }

        public override string ToString() {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            bool first = true;
            sb.Append("DeleteInfo : ");
            foreach (System.Collections.Generic.KeyValuePair<Net.Vpc.Upa.RelationshipType , System.Collections.Generic.IDictionary<string , long?>> e in infos) {
                Net.Vpc.Upa.RelationshipType k = (Net.Vpc.Upa.RelationshipType) (e).Key;
                string typeName = k.ToString();
                sb.Append("[").Append(typeName).Append("]=").Append("{");
                foreach (System.Collections.Generic.KeyValuePair<string , long?> e2 in (e).Value) {
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
            foreach (System.Collections.Generic.KeyValuePair<Net.Vpc.Upa.RelationshipType , System.Collections.Generic.IDictionary<string , long?>> e in infos) {
                foreach (System.Collections.Generic.KeyValuePair<string , long?> e2 in (e).Value) {
                    long tabCount = ((e2).Value).Value;
                    count += tabCount;
                }
            }
            return count;
        }

        public virtual long GetRemoveCount(Net.Vpc.Upa.RelationshipType type) {
            long count = 0;
            foreach (System.Collections.Generic.KeyValuePair<Net.Vpc.Upa.RelationshipType , System.Collections.Generic.IDictionary<string , long?>> e in infos) {
                Net.Vpc.Upa.RelationshipType k = (e).Key;
                if (k == type) {
                    foreach (System.Collections.Generic.KeyValuePair<string , long?> e2 in (e).Value) {
                        long tabCount = ((e2).Value).Value;
                        count += tabCount;
                    }
                }
            }
            return count;
        }
    }
}
