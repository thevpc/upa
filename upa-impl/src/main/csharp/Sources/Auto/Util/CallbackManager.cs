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



namespace Net.Vpc.Upa.Impl.Util
{


    /**
     * Created by vpc on 7/25/15.
     */
    public class CallbackManager {

        internal System.Collections.Generic.IDictionary<Net.Vpc.Upa.Impl.Util.CallbackInvokerKey , System.Collections.Generic.IList<Net.Vpc.Upa.Callback>> before = new System.Collections.Generic.Dictionary<Net.Vpc.Upa.Impl.Util.CallbackInvokerKey , System.Collections.Generic.IList<Net.Vpc.Upa.Callback>>();

        internal System.Collections.Generic.IDictionary<Net.Vpc.Upa.Impl.Util.CallbackInvokerKey , System.Collections.Generic.IList<Net.Vpc.Upa.Callback>> after = new System.Collections.Generic.Dictionary<Net.Vpc.Upa.Impl.Util.CallbackInvokerKey , System.Collections.Generic.IList<Net.Vpc.Upa.Callback>>();

        public virtual void AddCallback(Net.Vpc.Upa.Callback callback) {
            Net.Vpc.Upa.Impl.Config.Callback.DefaultCallback dcallback = (Net.Vpc.Upa.Impl.Config.Callback.DefaultCallback) callback;
            System.Collections.Generic.IDictionary<string , object> conf = dcallback.GetConfiguration();
            if (conf == null) {
                conf = new System.Collections.Generic.Dictionary<string , object>();
            }
            bool fireBefore = true;
            bool fireAfter = true;
            bool trackSystemObjects = true;
            string nameFilter = null;
            if (conf.ContainsKey("before")) {
                fireBefore = ((bool?) Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,object>(conf,"before")).Value;
            }
            if (conf.ContainsKey("after")) {
                fireBefore = ((bool?) Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,object>(conf,"after")).Value;
            }
            if (conf.ContainsKey("trackSystemObjects")) {
                trackSystemObjects = ((bool?) Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,object>(conf,"trackSystemObjects")).Value;
            }
            nameFilter = (string) Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,object>(conf,"nameFilter");
            if (Net.Vpc.Upa.Impl.Util.Strings.IsNullOrEmpty(nameFilter)) {
                nameFilter = null;
            }
            if (fireBefore) {
                Net.Vpc.Upa.Impl.Util.CallbackInvokerKey k = new Net.Vpc.Upa.Impl.Util.CallbackInvokerKey(callback.GetCallbackType(), callback.GetObjectType(), nameFilter, trackSystemObjects);
                System.Collections.Generic.IList<Net.Vpc.Upa.Callback> ss = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<Net.Vpc.Upa.Impl.Util.CallbackInvokerKey,System.Collections.Generic.IList<Net.Vpc.Upa.Callback>>(this.before,k);
                if (ss == null) {
                    ss = new System.Collections.Generic.List<Net.Vpc.Upa.Callback>();
                    this.before[k]=ss;
                }
                ss.Add(callback);
            }
            if (fireAfter) {
                Net.Vpc.Upa.Impl.Util.CallbackInvokerKey k = new Net.Vpc.Upa.Impl.Util.CallbackInvokerKey(callback.GetCallbackType(), callback.GetObjectType(), nameFilter, trackSystemObjects);
                System.Collections.Generic.IList<Net.Vpc.Upa.Callback> ss = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<Net.Vpc.Upa.Impl.Util.CallbackInvokerKey,System.Collections.Generic.IList<Net.Vpc.Upa.Callback>>(this.after,k);
                if (ss == null) {
                    ss = new System.Collections.Generic.List<Net.Vpc.Upa.Callback>();
                    this.after[k]=ss;
                }
                ss.Add(callback);
            }
        }

        public virtual void RemoveCallback(Net.Vpc.Upa.Callback callback) {
            Net.Vpc.Upa.Impl.Config.Callback.DefaultCallback dcallback = (Net.Vpc.Upa.Impl.Config.Callback.DefaultCallback) callback;
            System.Collections.Generic.IDictionary<string , object> conf = dcallback.GetConfiguration();
            if (conf == null) {
                conf = new System.Collections.Generic.Dictionary<string , object>();
            }
            bool fireBefore = true;
            bool fireAfter = true;
            bool trackSystemObjects = true;
            string nameFilter = null;
            if (conf.ContainsKey("before")) {
                fireBefore = ((bool?) Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,object>(conf,"before")).Value;
            }
            if (conf.ContainsKey("after")) {
                fireBefore = ((bool?) Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,object>(conf,"after")).Value;
            }
            if (conf.ContainsKey("trackSystemObjects")) {
                trackSystemObjects = ((bool?) Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,object>(conf,"trackSystemObjects")).Value;
            }
            nameFilter = (string) Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,object>(conf,"nameFilter");
            if (Net.Vpc.Upa.Impl.Util.Strings.IsNullOrEmpty(nameFilter)) {
                nameFilter = null;
            }
            Net.Vpc.Upa.Impl.Util.CallbackInvokerKey k = new Net.Vpc.Upa.Impl.Util.CallbackInvokerKey(callback.GetCallbackType(), callback.GetObjectType(), nameFilter, trackSystemObjects);
            System.Collections.Generic.IList<Net.Vpc.Upa.Callback> ss = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<Net.Vpc.Upa.Impl.Util.CallbackInvokerKey,System.Collections.Generic.IList<Net.Vpc.Upa.Callback>>(before,k);
            if (ss != null) {
                ss.Remove(callback);
            }
            ss = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<Net.Vpc.Upa.Impl.Util.CallbackInvokerKey,System.Collections.Generic.IList<Net.Vpc.Upa.Callback>>(after,k);
            if (ss != null) {
                ss.Remove(callback);
            }
        }

        public virtual System.Collections.Generic.IList<Net.Vpc.Upa.Callback> GetCallbacks(Net.Vpc.Upa.CallbackType callbackType, Net.Vpc.Upa.ObjectType objectType, string nameFilter, bool system, Net.Vpc.Upa.EventPhase phase) {
            Net.Vpc.Upa.Impl.Util.CallbackInvokerKey k = new Net.Vpc.Upa.Impl.Util.CallbackInvokerKey(callbackType, objectType, nameFilter, system);
            System.Collections.Generic.IList<Net.Vpc.Upa.Callback> found = new System.Collections.Generic.List<Net.Vpc.Upa.Callback>();
            System.Collections.Generic.IDictionary<Net.Vpc.Upa.Impl.Util.CallbackInvokerKey , System.Collections.Generic.IList<Net.Vpc.Upa.Callback>> list = phase == Net.Vpc.Upa.EventPhase.AFTER ? this.after : this.before;
            System.Collections.Generic.IList<Net.Vpc.Upa.Callback> ss = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<Net.Vpc.Upa.Impl.Util.CallbackInvokerKey,System.Collections.Generic.IList<Net.Vpc.Upa.Callback>>(list,k);
            if (ss != null) {
                Net.Vpc.Upa.Impl.FwkConvertUtils.ListAddRange(found, ss);
            }
            if (nameFilter != null) {
                Net.Vpc.Upa.Impl.FwkConvertUtils.ListAddRange(found, GetCallbacks(callbackType, objectType, null, system, phase));
            } else if (!system) {
                Net.Vpc.Upa.Impl.FwkConvertUtils.ListAddRange(found, GetCallbacks(callbackType, objectType, null, true, phase));
            }
            return found;
        }

        public virtual System.Collections.Generic.IList<Net.Vpc.Upa.Callback> GetCallbacks(Net.Vpc.Upa.CallbackType callbackType, Net.Vpc.Upa.ObjectType objectType, string nameFilter, bool system) {
            Net.Vpc.Upa.Impl.Util.CallbackInvokerKey k = new Net.Vpc.Upa.Impl.Util.CallbackInvokerKey(callbackType, objectType, nameFilter, system);
            System.Collections.Generic.IList<Net.Vpc.Upa.Callback> found = new System.Collections.Generic.List<Net.Vpc.Upa.Callback>();
            foreach (Net.Vpc.Upa.EventPhase phase in ((Net.Vpc.Upa.EventPhase[])System.Enum.GetValues(typeof(Net.Vpc.Upa.EventPhase)))) {
                System.Collections.Generic.IDictionary<Net.Vpc.Upa.Impl.Util.CallbackInvokerKey , System.Collections.Generic.IList<Net.Vpc.Upa.Callback>> list = phase == Net.Vpc.Upa.EventPhase.AFTER ? this.after : this.before;
                System.Collections.Generic.IList<Net.Vpc.Upa.Callback> ss = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<Net.Vpc.Upa.Impl.Util.CallbackInvokerKey,System.Collections.Generic.IList<Net.Vpc.Upa.Callback>>(list,k);
                if (ss != null) {
                    Net.Vpc.Upa.Impl.FwkConvertUtils.ListAddRange(found, ss);
                }
                if (nameFilter != null) {
                    Net.Vpc.Upa.Impl.FwkConvertUtils.ListAddRange(found, GetCallbacks(callbackType, objectType, null, system, phase));
                } else if (!system) {
                    Net.Vpc.Upa.Impl.FwkConvertUtils.ListAddRange(found, GetCallbacks(callbackType, objectType, null, true, phase));
                }
            }
            return found;
        }
    }
}
