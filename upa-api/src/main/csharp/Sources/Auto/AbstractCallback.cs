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
     * Created by vpc on 6/9/17.
     */
    public abstract class AbstractCallback : Net.Vpc.Upa.Callback {

        private Net.Vpc.Upa.CallbackType callbackType;

        private Net.Vpc.Upa.EventPhase phase;

        private Net.Vpc.Upa.ObjectType objectType;

        private System.Collections.Generic.IDictionary<string , object> configuration;

        public AbstractCallback(Net.Vpc.Upa.CallbackType callbackType, Net.Vpc.Upa.EventPhase phase, Net.Vpc.Upa.ObjectType objectType, System.Collections.Generic.IDictionary<string , object> configuration) {
            this.callbackType = callbackType;
            this.phase = phase;
            this.objectType = objectType;
            this.configuration = configuration;
        }


        public virtual Net.Vpc.Upa.CallbackType GetCallbackType() {
            return callbackType;
        }


        public virtual Net.Vpc.Upa.EventPhase GetPhase() {
            return phase;
        }


        public virtual Net.Vpc.Upa.ObjectType GetObjectType() {
            return objectType;
        }


        public virtual System.Collections.Generic.IDictionary<string , object> GetConfiguration() {
            return configuration;
        }
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract object Invoke(object[] arg1);
    }
}
