/*********************************************************
 *********************************************************
 **   DO NOT EDIT                                       **
 **                                                     **
 **   THIS FILE HAS BEEN GENERATED AUTOMATICALLY         **
 **   BY UPA PORTABLE GENERATOR                         **
 **   (c) vpc                                           **
 **                                                     **
 *********************************************************
 ********************************************************/



namespace Net.Vpc.Upa
{


    /**
     * Created by vpc on 8/6/16.
     */
    public class UPABootstrap {

        private bool contextProviderCreated = false;

        private readonly Net.Vpc.Upa.Properties properties = new Net.Vpc.Upa.BootstrapProperties();

        internal UPABootstrap() {
            foreach (System.Collections.Generic.KeyValuePair<object , object> ee in new System.Collections.Generic.HashSet<System.Collections.Generic.KeyValuePair<K,V>>(Java.Lang.System.GetProperties())) {
                properties.SetString((string) (ee).Key, (string) (ee).Value);
            }
        }

        public virtual bool IsContextInitialized() {
            return contextProviderCreated;
        }

        internal virtual void SetContextInitialized() {
            contextProviderCreated = true;
        }

        public virtual Net.Vpc.Upa.ObjectFactory GetFactory() {
            try {
                return Net.Vpc.Upa.BootstrapObjectFactoryLazyHolder.INSTANCE;
            } catch (System.Exception e) {
                if (e is Net.Vpc.Upa.Exceptions.UPAException) {
                    throw (Net.Vpc.Upa.Exceptions.UPAException) e;
                }
                throw new Net.Vpc.Upa.Exceptions.BootstrapException("LoadBootstrapFactoryException", e);
            }
        }

        public virtual Net.Vpc.Upa.Properties GetProperties() {
            return properties;
        }
    }
}
