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



namespace Net.TheVpc.Upa.Impl
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 8/29/12 10:52 PM
     */
    public class DefaultEntityExtensionManager {

        private System.Collections.Generic.IDictionary<System.Type , System.Collections.Generic.IList<Net.TheVpc.Upa.Impl.ExtensionSupportInfo>> extensionsMap = new System.Collections.Generic.Dictionary<System.Type , System.Collections.Generic.IList<Net.TheVpc.Upa.Impl.ExtensionSupportInfo>>();

        private System.Collections.Generic.IDictionary<System.Type , System.Collections.Generic.IList<Net.TheVpc.Upa.Impl.ExtensionSupportInfo>> extensionsSupportMap = new System.Collections.Generic.Dictionary<System.Type , System.Collections.Generic.IList<Net.TheVpc.Upa.Impl.ExtensionSupportInfo>>();

        private System.Collections.Generic.IDictionary<Net.TheVpc.Upa.Extensions.EntityExtensionDefinition , Net.TheVpc.Upa.Impl.ExtensionSupportInfo> objectMap = new System.Collections.Generic.Dictionary<Net.TheVpc.Upa.Extensions.EntityExtensionDefinition , Net.TheVpc.Upa.Impl.ExtensionSupportInfo>();

        public virtual void AddEntityExtension(System.Type specType, System.Type supportType, Net.TheVpc.Upa.Extensions.EntityExtensionDefinition specObject, Net.TheVpc.Upa.Persistence.EntityExtension extensionSupport) {
            Net.TheVpc.Upa.Impl.ExtensionSupportInfo tss = new Net.TheVpc.Upa.Impl.ExtensionSupportInfo(specType, specObject, extensionSupport);
            objectMap[specObject]=tss;
            System.Collections.Generic.IList<Net.TheVpc.Upa.Impl.ExtensionSupportInfo> list = Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<System.Type,System.Collections.Generic.IList<Net.TheVpc.Upa.Impl.ExtensionSupportInfo>>(extensionsMap,specType);
            if (list == null) {
                list = new System.Collections.Generic.List<Net.TheVpc.Upa.Impl.ExtensionSupportInfo>();
                extensionsMap[specType]=list;
            }
            list.Add(tss);
            System.Collections.Generic.IList<Net.TheVpc.Upa.Impl.ExtensionSupportInfo> list2 = Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<System.Type,System.Collections.Generic.IList<Net.TheVpc.Upa.Impl.ExtensionSupportInfo>>(extensionsSupportMap,supportType);
            if (list2 == null) {
                list2 = new System.Collections.Generic.List<Net.TheVpc.Upa.Impl.ExtensionSupportInfo>();
                extensionsSupportMap[supportType]=list2;
            }
            list2.Add(tss);
        }

        public virtual void RemoveEntityExtension(System.Type specType, Net.TheVpc.Upa.Extensions.EntityExtensionDefinition specObject) {
            objectMap.Remove(specObject);
            System.Collections.Generic.IList<Net.TheVpc.Upa.Impl.ExtensionSupportInfo> list = Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<System.Type,System.Collections.Generic.IList<Net.TheVpc.Upa.Impl.ExtensionSupportInfo>>(extensionsMap,specType);
            if (list != null) {
                for (int i = (list).Count; i >= 0; i--) {
                    Net.TheVpc.Upa.Impl.ExtensionSupportInfo tss = list[i];
                    if (tss.GetExtension().Equals(specObject)) {
                        list.RemoveAt(i);
                    }
                }
            }
            foreach (System.Collections.Generic.KeyValuePair<System.Type , System.Collections.Generic.IList<Net.TheVpc.Upa.Impl.ExtensionSupportInfo>> e in new System.Collections.Generic.HashSet<System.Collections.Generic.KeyValuePair<System.Type,System.Collections.Generic.IList<Net.TheVpc.Upa.Impl.ExtensionSupportInfo>>>(new System.Collections.Generic.Dictionary<System.Type , System.Collections.Generic.IList<Net.TheVpc.Upa.Impl.ExtensionSupportInfo>>(extensionsSupportMap))) {
                System.Collections.Generic.IList<Net.TheVpc.Upa.Impl.ExtensionSupportInfo> tss2 = (e).Value;
                for (int i2 = (tss2).Count; i2 >= 0; i2--) {
                    Net.TheVpc.Upa.Impl.ExtensionSupportInfo tss3 = tss2[i2];
                    if (tss3.GetExtension().Equals(specObject)) {
                        tss2.RemoveAt(i2);
                    }
                }
                if ((tss2.Count==0)) {
                    extensionsSupportMap.Remove((e).Key);
                }
            }
            for (System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<System.Type , System.Collections.Generic.IList<Net.TheVpc.Upa.Impl.ExtensionSupportInfo>>> i = new System.Collections.Generic.HashSet<System.Collections.Generic.KeyValuePair<System.Type,System.Collections.Generic.IList<Net.TheVpc.Upa.Impl.ExtensionSupportInfo>>>(extensionsSupportMap).GetEnumerator(); i.MoveNext(); ) {
            }
        }

        public virtual System.Collections.Generic.IList<Net.TheVpc.Upa.Extensions.EntityExtensionDefinition> GetEntityExtensions() {
            System.Collections.Generic.List<Net.TheVpc.Upa.Extensions.EntityExtensionDefinition> list = new System.Collections.Generic.List<Net.TheVpc.Upa.Extensions.EntityExtensionDefinition>();
            foreach (System.Collections.Generic.IList<Net.TheVpc.Upa.Impl.ExtensionSupportInfo> entitySpecs in (extensionsMap).Values) {
                foreach (Net.TheVpc.Upa.Impl.ExtensionSupportInfo tss in entitySpecs) {
                    list.Add(tss.GetExtension());
                }
            }
            return list;
        }

        public virtual System.Collections.Generic.IList<Net.TheVpc.Upa.Persistence.EntityExtension> GetEntityExtensionSupports() {
            System.Collections.Generic.List<Net.TheVpc.Upa.Persistence.EntityExtension> list = new System.Collections.Generic.List<Net.TheVpc.Upa.Persistence.EntityExtension>();
            foreach (System.Collections.Generic.IList<Net.TheVpc.Upa.Impl.ExtensionSupportInfo> entitySpecs in (extensionsSupportMap).Values) {
                foreach (Net.TheVpc.Upa.Impl.ExtensionSupportInfo tss in entitySpecs) {
                    list.Add(tss.GetSupport());
                }
            }
            return list;
        }

        public virtual  System.Collections.Generic.IList<S> GetEntityExtensions<S>(System.Type type) where  S : Net.TheVpc.Upa.Extensions.EntityExtensionDefinition {
            System.Collections.Generic.IList<S> list = new System.Collections.Generic.List<S>();
            System.Collections.Generic.IList<Net.TheVpc.Upa.Impl.ExtensionSupportInfo> entitySpecs = Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<System.Type,System.Collections.Generic.IList<Net.TheVpc.Upa.Impl.ExtensionSupportInfo>>(extensionsMap,type);
            if (entitySpecs == null) {
                return Net.TheVpc.Upa.Impl.Util.PlatformUtils.EmptyList<T>();
            }
            foreach (Net.TheVpc.Upa.Impl.ExtensionSupportInfo tss in entitySpecs) {
                list.Add((S) tss.GetExtension());
            }
            return list;
        }

        public virtual  System.Collections.Generic.IList<S> GetEntityExtensionSupports<S>(System.Type type) where  S : Net.TheVpc.Upa.Persistence.EntityExtension {
            System.Collections.Generic.IList<S> list = new System.Collections.Generic.List<S>();
            System.Collections.Generic.IList<Net.TheVpc.Upa.Impl.ExtensionSupportInfo> entitySpecs = Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<System.Type,System.Collections.Generic.IList<Net.TheVpc.Upa.Impl.ExtensionSupportInfo>>(extensionsSupportMap,type);
            if (entitySpecs == null) {
                return Net.TheVpc.Upa.Impl.Util.PlatformUtils.EmptyList<T>();
            }
            foreach (Net.TheVpc.Upa.Impl.ExtensionSupportInfo tss in entitySpecs) {
                list.Add((S) tss.GetSupport());
            }
            return list;
        }
    }
}
