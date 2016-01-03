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



namespace Net.Vpc.Upa.Impl
{


    /**
     *
     * @author vpc
     */
    public class DefaultUPAContextFactory : Net.Vpc.Upa.UPAContextFactory {

        private Net.Vpc.Upa.ObjectFactory baseFactory;

        private readonly System.Collections.Generic.Dictionary<string , object> singletons = new System.Collections.Generic.Dictionary<string , object>();

        public DefaultUPAContextFactory(Net.Vpc.Upa.ObjectFactory baseFactory) {
            this.baseFactory = baseFactory;
        }

        public virtual int GetContextSupportLevel() {
            return baseFactory.GetContextSupportLevel();
        }

        public virtual void SetParentFactory(Net.Vpc.Upa.ObjectFactory factory) {
            baseFactory.SetParentFactory(factory);
        }

        public virtual  T CreateObject<T>(System.Type type, string name) {
            return baseFactory.CreateObject<T>(type, name);
        }

        public virtual  T CreateObject<T>(string typeName, string name) {
            return baseFactory.CreateObject<T>(typeName, name);
        }

        public virtual  T CreateObject<T>(System.Type type) {
            return baseFactory.CreateObject<T>(type);
        }

        public virtual  T CreateObject<T>(string typeName) {
            return baseFactory.CreateObject<T>(typeName);
        }

        public virtual Net.Vpc.Upa.Config.ScanSource CreateURLScanSource(string[] urls, Net.Vpc.Upa.Config.ScanFilter[] filters, bool noIgnore) {
            return new Net.Vpc.Upa.Impl.Config.URLScanSource(urls, filters, noIgnore);
        }

        /**
             *
             * @param noIgnore
             * @return
             */
        public virtual Net.Vpc.Upa.Config.ScanSource CreateContextScanSource(bool noIgnore) {
            return new Net.Vpc.Upa.Impl.Config.ContextScanSource(noIgnore);
        }


        public virtual Net.Vpc.Upa.Config.ScanSource CreateClassScanSource(System.Type[] classes, bool noIgnore) {
            return new Net.Vpc.Upa.Impl.Config.ClassesScanSource(classes, noIgnore);
        }


        public virtual  T GetSingleton<T>(System.Type type) {
            string typeName = (type).FullName;
            if (singletons.ContainsKey(typeName)) {
                return (T) Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,object>(singletons,typeName);
            }
            lock (singletons) {
                if (singletons.ContainsKey(typeName)) {
                    return (T) Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,object>(singletons,typeName);
                }
                T o = CreateObject<T>(type);
                singletons[typeName]=o;
                return o;
            }
        }


        public virtual  T GetSingleton<T>(string typeName) {
            if (singletons.ContainsKey(typeName)) {
                return (T) Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,object>(singletons,typeName);
            }
            lock (singletons) {
                if (singletons.ContainsKey(typeName)) {
                    return (T) Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,object>(singletons,typeName);
                }
                T o = CreateObject<T>(typeName);
                singletons[typeName]=o;
                return o;
            }
        }
    }
}
