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



namespace Net.Vpc.Upa.Impl.Config.Annotationparser
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 11/15/12 11:46 AM
     */
    internal class EntityInfo : Net.Vpc.Upa.EntityDescriptor {

        public object source = null;

        public System.Collections.Generic.IList<Net.Vpc.Upa.Impl.Config.Annotationparser.IndexInfo> indexes = new System.Collections.Generic.List<Net.Vpc.Upa.Impl.Config.Annotationparser.IndexInfo>();

        public Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.EntityModifier> modifiers = Net.Vpc.Upa.FlagSets.NoneOf<Net.Vpc.Upa.EntityModifier>();

        public Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.EntityModifier> excludeModifiers = Net.Vpc.Upa.FlagSets.NoneOf<Net.Vpc.Upa.EntityModifier>();

        public System.Type idType = null;

        public Net.Vpc.Upa.Impl.Config.Annotationparser.OverriddenValue<System.Type> entityType = new Net.Vpc.Upa.Impl.Config.Annotationparser.OverriddenValue<System.Type>();

        public Net.Vpc.Upa.Impl.Config.Annotationparser.OverriddenValue<string> listOrder = new Net.Vpc.Upa.Impl.Config.Annotationparser.OverriddenValue<string>();

        public Net.Vpc.Upa.Impl.Config.Annotationparser.OverriddenValue<string> archivingOrder = new Net.Vpc.Upa.Impl.Config.Annotationparser.OverriddenValue<string>();

        public string name = null;

        public string shortName = null;

        public System.Collections.Generic.Dictionary<string , Net.Vpc.Upa.Impl.Config.Annotationparser.FieldInfo> fieldsMap = new System.Collections.Generic.Dictionary<string , Net.Vpc.Upa.Impl.Config.Annotationparser.FieldInfo>();

        public System.Collections.Generic.IList<Net.Vpc.Upa.Extensions.EntityExtensionDefinition> specs = new System.Collections.Generic.List<Net.Vpc.Upa.Extensions.EntityExtensionDefinition>();

        public System.Collections.Generic.IList<Net.Vpc.Upa.Impl.Config.Annotationparser.RelationshipInfo> relations = new System.Collections.Generic.List<Net.Vpc.Upa.Impl.Config.Annotationparser.RelationshipInfo>();

        public System.Collections.Generic.IList<Net.Vpc.Upa.Impl.Config.Annotationparser.FieldInfo> fieldsList;

        public Net.Vpc.Upa.Impl.Config.Annotationparser.OverriddenValue<string> path = new Net.Vpc.Upa.Impl.Config.Annotationparser.OverriddenValue<string>();

        public Net.Vpc.Upa.Impl.Config.Annotationparser.OverriddenValue<int?> pathPosition = new Net.Vpc.Upa.Impl.Config.Annotationparser.OverriddenValue<int?>();

        public System.Collections.Generic.Dictionary<string , object> entityParams = new System.Collections.Generic.Dictionary<string , object>();

        public Net.Vpc.Upa.Impl.Config.Decorations.DecorationRepository repo;

        public Net.Vpc.Upa.ObjectFactory factory;

        public EntityInfo(Net.Vpc.Upa.Impl.Config.Decorations.DecorationRepository repo, Net.Vpc.Upa.ObjectFactory factory) {
            this.repo = repo;
            this.factory = factory;
        }

        public virtual Net.Vpc.Upa.ObjectFactory GetFactory() {
            return factory;
        }

        public virtual System.Collections.Generic.IDictionary<string , object> GetProperties() {
            return entityParams;
        }

        public virtual void AddModifiers(System.Collections.Generic.ICollection<Net.Vpc.Upa.EntityModifier> others) {
            foreach (Net.Vpc.Upa.EntityModifier m in others) {
                if (excludeModifiers.Contains(m)) {
                    excludeModifiers.Remove(m);
                }
                modifiers.Add(m);
            }
        }

        public virtual void AddExcludeModifiers(System.Collections.Generic.ICollection<Net.Vpc.Upa.EntityModifier> others) {
            foreach (Net.Vpc.Upa.EntityModifier m in others) {
                if (modifiers.Contains(m)) {
                    modifiers.Remove(m);
                }
                excludeModifiers.Add(m);
            }
        }

        public virtual System.Collections.Generic.IList<Net.Vpc.Upa.FieldDescriptor> GetFieldDescriptors() {
            System.Collections.Generic.IList<Net.Vpc.Upa.FieldDescriptor> all = new System.Collections.Generic.List<Net.Vpc.Upa.FieldDescriptor>();
            foreach (Net.Vpc.Upa.Impl.Config.Annotationparser.FieldInfo fieldInfo in fieldsList) {
                all.Add(fieldInfo);
            }
            return all;
        }

        public virtual System.Collections.Generic.IList<Net.Vpc.Upa.RelationshipDescriptor> GetRelationshipDescriptors() {
            System.Collections.Generic.IList<Net.Vpc.Upa.RelationshipDescriptor> all = new System.Collections.Generic.List<Net.Vpc.Upa.RelationshipDescriptor>();
            foreach (Net.Vpc.Upa.Impl.Config.Annotationparser.RelationshipInfo fieldInfo in relations) {
                all.Add(fieldInfo);
            }
            return all;
        }

        public virtual System.Collections.Generic.IList<Net.Vpc.Upa.IndexDescriptor> GetIndexDescriptors() {
            System.Collections.Generic.IList<Net.Vpc.Upa.IndexDescriptor> all = new System.Collections.Generic.List<Net.Vpc.Upa.IndexDescriptor>();
            foreach (Net.Vpc.Upa.Impl.Config.Annotationparser.IndexInfo fieldInfo in indexes) {
                all.Add(fieldInfo);
            }
            return all;
        }

        public virtual string GetName() {
            return name;
        }

        public virtual string GetShortName() {
            return shortName;
        }

        public virtual System.Type GetIdType() {
            return idType;
        }

        public virtual System.Type GetEntityType() {
            return entityType.@value;
        }


        public virtual string GetPackagePath() {
            return path.GetValue(null);
        }


        public virtual string GetListOrder() {
            return listOrder.GetValue(null);
        }


        public virtual string GetArchivingOrder() {
            return archivingOrder.GetValue(null);
        }


        public virtual int GetPosition() {
            return (pathPosition.GetValue(0)).Value;
        }


        public virtual System.Collections.Generic.IList<Net.Vpc.Upa.Extensions.EntityExtensionDefinition> GetEntityExtensions() {
            return specs;
        }


        public virtual Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.EntityModifier> GetModifiers() {
            return modifiers;
        }

        public virtual Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.EntityModifier> GetExcludeModifiers() {
            return excludeModifiers;
        }


        public virtual object GetSource() {
            return source;
        }

        public virtual void AddIndex(string name, System.Collections.Generic.IList<string> fields, bool unique, int configOrder) {
            if (Net.Vpc.Upa.Impl.Util.StringUtils.IsNullOrEmpty(name)) {
                Net.Vpc.Upa.Impl.Config.Annotationparser.IndexInfo i = new Net.Vpc.Upa.Impl.Config.Annotationparser.IndexInfo();
                i.SetName(null);
                i.GetUnique().SetBetterValue(unique, configOrder);
                Net.Vpc.Upa.Impl.FwkConvertUtils.ListAddRange(i.GetFieldsNames(), fields);
            } else {
                bool found = false;
                foreach (Net.Vpc.Upa.Impl.Config.Annotationparser.IndexInfo indexInfo in indexes) {
                    if (name.Equals(indexInfo.GetName())) {
                        found = true;
                        System.Collections.Generic.IList<string> t = new System.Collections.Generic.List<string>(indexInfo.GetFieldsNames());
                        Net.Vpc.Upa.Impl.FwkConvertUtils.ListRemoveRange(t, fields);
                        Net.Vpc.Upa.Impl.FwkConvertUtils.ListAddRange(indexInfo.GetFieldsNames(), fields);
                        //ignore configOrder
                        if ((t).Count > 0) {
                            indexInfo.GetUnique().SetBetterValue(unique, configOrder);
                        }
                    }
                }
                if (!found) {
                    Net.Vpc.Upa.Impl.Config.Annotationparser.IndexInfo i = new Net.Vpc.Upa.Impl.Config.Annotationparser.IndexInfo();
                    i.SetName(null);
                    i.GetUnique().SetBetterValue(unique, configOrder);
                    Net.Vpc.Upa.Impl.FwkConvertUtils.ListAddRange(i.GetFieldsNames(), fields);
                }
            }
        }


        public override string ToString() {
            return "EntityInfo{" + "source=" + ((source is object[]) ? System.Convert.ToString((object[]) source) : System.Convert.ToString(source)) + '}';
        }
    }
}
