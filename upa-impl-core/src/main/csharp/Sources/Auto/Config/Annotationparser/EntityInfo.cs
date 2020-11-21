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



namespace Net.TheVpc.Upa.Impl.Config.Annotationparser
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 11/15/12 11:46 AM
     */
    internal class EntityInfo : Net.TheVpc.Upa.EntityDescriptor {

        public object source = null;

        public System.Collections.Generic.IList<Net.TheVpc.Upa.Impl.Config.Annotationparser.IndexInfo> indexes = new System.Collections.Generic.List<Net.TheVpc.Upa.Impl.Config.Annotationparser.IndexInfo>();

        public Net.TheVpc.Upa.FlagSet<Net.TheVpc.Upa.EntityModifier> modifiers = Net.TheVpc.Upa.FlagSets.NoneOf<Net.TheVpc.Upa.EntityModifier>();

        public Net.TheVpc.Upa.FlagSet<Net.TheVpc.Upa.EntityModifier> excludeModifiers = Net.TheVpc.Upa.FlagSets.NoneOf<Net.TheVpc.Upa.EntityModifier>();

        public System.Type idType = null;

        public Net.TheVpc.Upa.Impl.Config.Annotationparser.OverriddenValue<System.Type> entityType = new Net.TheVpc.Upa.Impl.Config.Annotationparser.OverriddenValue<System.Type>();

        public Net.TheVpc.Upa.Impl.Config.Annotationparser.OverriddenValue<string> listOrder = new Net.TheVpc.Upa.Impl.Config.Annotationparser.OverriddenValue<string>();

        public Net.TheVpc.Upa.Impl.Config.Annotationparser.OverriddenValue<string> archivingOrder = new Net.TheVpc.Upa.Impl.Config.Annotationparser.OverriddenValue<string>();

        public string name = null;

        public string shortName = null;

        public System.Collections.Generic.Dictionary<string , Net.TheVpc.Upa.Impl.Config.Annotationparser.FieldInfo> fieldsMap = new System.Collections.Generic.Dictionary<string , Net.TheVpc.Upa.Impl.Config.Annotationparser.FieldInfo>();

        public System.Collections.Generic.IList<Net.TheVpc.Upa.Extensions.EntityExtensionDefinition> specs = new System.Collections.Generic.List<Net.TheVpc.Upa.Extensions.EntityExtensionDefinition>();

        public System.Collections.Generic.IList<Net.TheVpc.Upa.Impl.Config.Annotationparser.RelationshipInfo> relations = new System.Collections.Generic.List<Net.TheVpc.Upa.Impl.Config.Annotationparser.RelationshipInfo>();

        public System.Collections.Generic.IList<Net.TheVpc.Upa.Impl.Config.Annotationparser.FieldInfo> fieldsList;

        public Net.TheVpc.Upa.Impl.Config.Annotationparser.OverriddenValue<string> path = new Net.TheVpc.Upa.Impl.Config.Annotationparser.OverriddenValue<string>();

        public Net.TheVpc.Upa.Impl.Config.Annotationparser.OverriddenValue<int?> pathPosition = new Net.TheVpc.Upa.Impl.Config.Annotationparser.OverriddenValue<int?>();

        public System.Collections.Generic.Dictionary<string , object> entityParams = new System.Collections.Generic.Dictionary<string , object>();

        public Net.TheVpc.Upa.Impl.Config.Decorations.DecorationRepository repo;

        public Net.TheVpc.Upa.ObjectFactory factory;

        public EntityInfo(Net.TheVpc.Upa.Impl.Config.Decorations.DecorationRepository repo, Net.TheVpc.Upa.ObjectFactory factory) {
            this.repo = repo;
            this.factory = factory;
        }

        public virtual Net.TheVpc.Upa.ObjectFactory GetFactory() {
            return factory;
        }

        public virtual System.Collections.Generic.IDictionary<string , object> GetProperties() {
            return entityParams;
        }

        public virtual void AddModifiers(System.Collections.Generic.ICollection<Net.TheVpc.Upa.EntityModifier> others) {
            foreach (Net.TheVpc.Upa.EntityModifier m in others) {
                if (excludeModifiers.Contains(m)) {
                    excludeModifiers.Remove(m);
                }
                modifiers.Add(m);
            }
        }

        public virtual void AddExcludeModifiers(System.Collections.Generic.ICollection<Net.TheVpc.Upa.EntityModifier> others) {
            foreach (Net.TheVpc.Upa.EntityModifier m in others) {
                if (modifiers.Contains(m)) {
                    modifiers.Remove(m);
                }
                excludeModifiers.Add(m);
            }
        }

        public virtual System.Collections.Generic.IList<Net.TheVpc.Upa.FieldDescriptor> GetFieldDescriptors() {
            System.Collections.Generic.IList<Net.TheVpc.Upa.FieldDescriptor> all = new System.Collections.Generic.List<Net.TheVpc.Upa.FieldDescriptor>();
            foreach (Net.TheVpc.Upa.Impl.Config.Annotationparser.FieldInfo fieldInfo in fieldsList) {
                all.Add(fieldInfo);
            }
            return all;
        }

        public virtual System.Collections.Generic.IList<Net.TheVpc.Upa.RelationshipDescriptor> GetRelationshipDescriptors() {
            System.Collections.Generic.IList<Net.TheVpc.Upa.RelationshipDescriptor> all = new System.Collections.Generic.List<Net.TheVpc.Upa.RelationshipDescriptor>();
            foreach (Net.TheVpc.Upa.Impl.Config.Annotationparser.RelationshipInfo fieldInfo in relations) {
                all.Add(fieldInfo);
            }
            return all;
        }

        public virtual System.Collections.Generic.IList<Net.TheVpc.Upa.IndexDescriptor> GetIndexDescriptors() {
            System.Collections.Generic.IList<Net.TheVpc.Upa.IndexDescriptor> all = new System.Collections.Generic.List<Net.TheVpc.Upa.IndexDescriptor>();
            foreach (Net.TheVpc.Upa.Impl.Config.Annotationparser.IndexInfo fieldInfo in indexes) {
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


        public virtual System.Collections.Generic.IList<Net.TheVpc.Upa.Extensions.EntityExtensionDefinition> GetEntityExtensions() {
            return specs;
        }


        public virtual Net.TheVpc.Upa.FlagSet<Net.TheVpc.Upa.EntityModifier> GetModifiers() {
            return modifiers;
        }

        public virtual Net.TheVpc.Upa.FlagSet<Net.TheVpc.Upa.EntityModifier> GetExcludeModifiers() {
            return excludeModifiers;
        }


        public virtual object GetSource() {
            return source;
        }

        public virtual void AddIndex(string name, System.Collections.Generic.IList<string> fields, bool unique, int configOrder) {
            if (Net.TheVpc.Upa.Impl.Util.StringUtils.IsNullOrEmpty(name)) {
                Net.TheVpc.Upa.Impl.Config.Annotationparser.IndexInfo i = new Net.TheVpc.Upa.Impl.Config.Annotationparser.IndexInfo();
                i.SetName(null);
                i.GetUnique().SetBetterValue(unique, configOrder);
                Net.TheVpc.Upa.Impl.FwkConvertUtils.ListAddRange(i.GetFieldsNames(), fields);
            } else {
                bool found = false;
                foreach (Net.TheVpc.Upa.Impl.Config.Annotationparser.IndexInfo indexInfo in indexes) {
                    if (name.Equals(indexInfo.GetName())) {
                        found = true;
                        System.Collections.Generic.IList<string> t = new System.Collections.Generic.List<string>(indexInfo.GetFieldsNames());
                        Net.TheVpc.Upa.Impl.FwkConvertUtils.ListRemoveRange(t, fields);
                        Net.TheVpc.Upa.Impl.FwkConvertUtils.ListAddRange(indexInfo.GetFieldsNames(), fields);
                        //ignore configOrder
                        if ((t).Count > 0) {
                            indexInfo.GetUnique().SetBetterValue(unique, configOrder);
                        }
                    }
                }
                if (!found) {
                    Net.TheVpc.Upa.Impl.Config.Annotationparser.IndexInfo i = new Net.TheVpc.Upa.Impl.Config.Annotationparser.IndexInfo();
                    i.SetName(null);
                    i.GetUnique().SetBetterValue(unique, configOrder);
                    Net.TheVpc.Upa.Impl.FwkConvertUtils.ListAddRange(i.GetFieldsNames(), fields);
                }
            }
        }


        public override string ToString() {
            return "EntityInfo{" + "source=" + ((source is object[]) ? System.Convert.ToString((object[]) source) : System.Convert.ToString(source)) + '}';
        }
    }
}
