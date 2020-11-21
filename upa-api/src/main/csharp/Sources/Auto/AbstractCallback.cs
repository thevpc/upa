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



namespace Net.TheVpc.Upa
{


    /**
     * Created by vpc on 6/9/17.
     */
    public abstract class AbstractCallback : Net.TheVpc.Upa.Callback {

        private Net.TheVpc.Upa.CallbackType callbackType;

        private Net.TheVpc.Upa.EventPhase phase;

        private Net.TheVpc.Upa.ObjectType objectType;

        private System.Collections.Generic.IDictionary<string , object> configuration;

        public AbstractCallback(Net.TheVpc.Upa.CallbackType callbackType, Net.TheVpc.Upa.EventPhase phase, Net.TheVpc.Upa.ObjectType objectType, System.Collections.Generic.IDictionary<string , object> configuration) {
            this.callbackType = callbackType;
            this.phase = phase;
            this.objectType = objectType;
            this.configuration = configuration;
        }


        public virtual Net.TheVpc.Upa.CallbackType GetCallbackType() {
            return callbackType;
        }


        public virtual Net.TheVpc.Upa.EventPhase GetPhase() {
            return phase;
        }


        public virtual Net.TheVpc.Upa.ObjectType GetObjectType() {
            return objectType;
        }


        public virtual System.Collections.Generic.IDictionary<string , object> GetConfiguration() {
            return configuration;
        }
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract object Invoke(object[] arg1);
    }
}
