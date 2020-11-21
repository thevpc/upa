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



namespace Net.TheVpc.Upa.Impl.Util
{


    /**
     * Created by vpc on 7/25/15.
     */
    public class CallbackManager {

        internal System.Collections.Generic.IDictionary<Net.TheVpc.Upa.Impl.Util.CallbackInvokerKey , System.Collections.Generic.IList<Net.TheVpc.Upa.Callback>> before = new System.Collections.Generic.Dictionary<Net.TheVpc.Upa.Impl.Util.CallbackInvokerKey , System.Collections.Generic.IList<Net.TheVpc.Upa.Callback>>();

        internal System.Collections.Generic.IDictionary<Net.TheVpc.Upa.Impl.Util.CallbackInvokerKey , System.Collections.Generic.IList<Net.TheVpc.Upa.Callback>> after = new System.Collections.Generic.Dictionary<Net.TheVpc.Upa.Impl.Util.CallbackInvokerKey , System.Collections.Generic.IList<Net.TheVpc.Upa.Callback>>();

        internal System.Collections.Generic.IDictionary<Net.TheVpc.Upa.Impl.Util.CallbackInvokerKey , System.Collections.Generic.IList<Net.TheVpc.Upa.PreparedCallback>> preparedAfter = new System.Collections.Generic.Dictionary<Net.TheVpc.Upa.Impl.Util.CallbackInvokerKey , System.Collections.Generic.IList<Net.TheVpc.Upa.PreparedCallback>>();

        public virtual void AddCallback(Net.TheVpc.Upa.Callback callback) {
            Net.TheVpc.Upa.Impl.Config.Callback.DefaultCallback dcallback = (Net.TheVpc.Upa.Impl.Config.Callback.DefaultCallback) callback;
            System.Collections.Generic.IDictionary<string , object> conf = dcallback.GetConfiguration();
            //        if (conf == null) {
            //            conf = new HashMap<String, Object>();
            //        }
            bool fireBefore = callback.GetPhase() == Net.TheVpc.Upa.EventPhase.BEFORE;
            string nameFilter = null;
            bool trackSystemObjects = true;
            if (conf != null && conf.ContainsKey("trackSystemObjects")) {
                trackSystemObjects = ((bool?) Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,object>(conf,"trackSystemObjects")).Value;
            }
            nameFilter = conf == null ? null : (string) Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,object>(conf,"nameFilter");
            if (Net.TheVpc.Upa.Impl.Util.StringUtils.IsNullOrEmpty(nameFilter)) {
                nameFilter = null;
            }
            if (fireBefore) {
                Net.TheVpc.Upa.Impl.Util.CallbackInvokerKey k = new Net.TheVpc.Upa.Impl.Util.CallbackInvokerKey(callback.GetCallbackType(), callback.GetObjectType(), nameFilter, trackSystemObjects);
                System.Collections.Generic.IList<Net.TheVpc.Upa.Callback> ss = Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<Net.TheVpc.Upa.Impl.Util.CallbackInvokerKey,System.Collections.Generic.IList<Net.TheVpc.Upa.Callback>>(this.before,k);
                if (ss == null) {
                    ss = new System.Collections.Generic.List<Net.TheVpc.Upa.Callback>();
                    this.before[k]=ss;
                }
                ss.Add(callback);
            } else {
                Net.TheVpc.Upa.Impl.Util.CallbackInvokerKey k = new Net.TheVpc.Upa.Impl.Util.CallbackInvokerKey(callback.GetCallbackType(), callback.GetObjectType(), nameFilter, trackSystemObjects);
                System.Collections.Generic.IList<Net.TheVpc.Upa.Callback> ss = Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<Net.TheVpc.Upa.Impl.Util.CallbackInvokerKey,System.Collections.Generic.IList<Net.TheVpc.Upa.Callback>>(this.after,k);
                if (ss == null) {
                    ss = new System.Collections.Generic.List<Net.TheVpc.Upa.Callback>();
                    this.after[k]=ss;
                }
                ss.Add(callback);
                if (callback is Net.TheVpc.Upa.PreparedCallback) {
                    System.Collections.Generic.IList<Net.TheVpc.Upa.PreparedCallback> sss = Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<Net.TheVpc.Upa.Impl.Util.CallbackInvokerKey,System.Collections.Generic.IList<Net.TheVpc.Upa.PreparedCallback>>(this.preparedAfter,k);
                    if (sss == null) {
                        sss = new System.Collections.Generic.List<Net.TheVpc.Upa.PreparedCallback>();
                        this.preparedAfter[k]=sss;
                    }
                    sss.Add((Net.TheVpc.Upa.PreparedCallback) callback);
                }
            }
        }

        public virtual void RemoveCallback(Net.TheVpc.Upa.Callback callback) {
            Net.TheVpc.Upa.Impl.Config.Callback.DefaultCallback dcallback = (Net.TheVpc.Upa.Impl.Config.Callback.DefaultCallback) callback;
            System.Collections.Generic.IDictionary<string , object> conf = dcallback.GetConfiguration();
            //        if (conf == null) {
            //            conf = new HashMap<String, Object>();
            //        }
            bool fireBefore = true;
            bool fireAfter = true;
            bool trackSystemObjects = true;
            string nameFilter = null;
            if (conf != null) {
                if (conf.ContainsKey("before")) {
                    fireBefore = ((bool?) Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,object>(conf,"before")).Value;
                }
                if (conf.ContainsKey("after")) {
                    fireBefore = ((bool?) Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,object>(conf,"after")).Value;
                }
                if (conf.ContainsKey("trackSystemObjects")) {
                    trackSystemObjects = ((bool?) Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,object>(conf,"trackSystemObjects")).Value;
                }
                nameFilter = (string) Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,object>(conf,"nameFilter");
            }
            if (Net.TheVpc.Upa.Impl.Util.StringUtils.IsNullOrEmpty(nameFilter)) {
                nameFilter = null;
            }
            Net.TheVpc.Upa.Impl.Util.CallbackInvokerKey k = new Net.TheVpc.Upa.Impl.Util.CallbackInvokerKey(callback.GetCallbackType(), callback.GetObjectType(), nameFilter, trackSystemObjects);
            System.Collections.Generic.IList<Net.TheVpc.Upa.Callback> ss = Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<Net.TheVpc.Upa.Impl.Util.CallbackInvokerKey,System.Collections.Generic.IList<Net.TheVpc.Upa.Callback>>(before,k);
            if (ss != null) {
                ss.Remove(callback);
            }
            ss = Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<Net.TheVpc.Upa.Impl.Util.CallbackInvokerKey,System.Collections.Generic.IList<Net.TheVpc.Upa.Callback>>(after,k);
            if (ss != null) {
                ss.Remove(callback);
            }
            if (callback is Net.TheVpc.Upa.PreparedCallback) {
                System.Collections.Generic.IList<Net.TheVpc.Upa.PreparedCallback> sss = Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<Net.TheVpc.Upa.Impl.Util.CallbackInvokerKey,System.Collections.Generic.IList<Net.TheVpc.Upa.PreparedCallback>>(preparedAfter,k);
                if (sss != null) {
                    sss.Remove((Net.TheVpc.Upa.PreparedCallback) callback);
                }
            }
        }

        public virtual System.Collections.Generic.IList<Net.TheVpc.Upa.Callback> GetCallbacks(Net.TheVpc.Upa.CallbackType callbackType, Net.TheVpc.Upa.ObjectType objectType, string nameFilter, bool system, bool preparedOnly, Net.TheVpc.Upa.EventPhase phase) {
            Net.TheVpc.Upa.Impl.Util.CallbackInvokerKey k = new Net.TheVpc.Upa.Impl.Util.CallbackInvokerKey(callbackType, objectType, nameFilter, system);
            System.Collections.Generic.IList<Net.TheVpc.Upa.Callback> found = new System.Collections.Generic.List<Net.TheVpc.Upa.Callback>();
            if (preparedOnly) {
                System.Collections.Generic.IDictionary<Net.TheVpc.Upa.Impl.Util.CallbackInvokerKey , System.Collections.Generic.IList<Net.TheVpc.Upa.PreparedCallback>> list = null;
                list = phase == Net.TheVpc.Upa.EventPhase.AFTER ? this.preparedAfter : null;
                System.Collections.Generic.IList<Net.TheVpc.Upa.PreparedCallback> ss = Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<Net.TheVpc.Upa.Impl.Util.CallbackInvokerKey,System.Collections.Generic.IList<Net.TheVpc.Upa.PreparedCallback>>(list,k);
                if (ss != null) {
                    Net.TheVpc.Upa.Impl.FwkConvertUtils.ListAddRange(found, ss);
                }
                if (nameFilter != null) {
                    Net.TheVpc.Upa.Impl.FwkConvertUtils.ListAddRange(found, GetCallbacks(callbackType, objectType, null, system, preparedOnly, phase));
                }
                if (!system) {
                    Net.TheVpc.Upa.Impl.FwkConvertUtils.ListAddRange(found, GetCallbacks(callbackType, objectType, null, true, preparedOnly, phase));
                }
            } else {
                System.Collections.Generic.IDictionary<Net.TheVpc.Upa.Impl.Util.CallbackInvokerKey , System.Collections.Generic.IList<Net.TheVpc.Upa.Callback>> list = null;
                list = phase == Net.TheVpc.Upa.EventPhase.AFTER ? this.after : this.before;
                System.Collections.Generic.IList<Net.TheVpc.Upa.Callback> ss = Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<Net.TheVpc.Upa.Impl.Util.CallbackInvokerKey,System.Collections.Generic.IList<Net.TheVpc.Upa.Callback>>(list,k);
                if (ss != null) {
                    Net.TheVpc.Upa.Impl.FwkConvertUtils.ListAddRange(found, ss);
                }
                if (nameFilter != null) {
                    Net.TheVpc.Upa.Impl.FwkConvertUtils.ListAddRange(found, GetCallbacks(callbackType, objectType, null, system, preparedOnly, phase));
                }
                if (!system) {
                    Net.TheVpc.Upa.Impl.FwkConvertUtils.ListAddRange(found, GetCallbacks(callbackType, objectType, null, true, preparedOnly, phase));
                }
            }
            return found;
        }

        public virtual System.Collections.Generic.IList<Net.TheVpc.Upa.PreparedCallback> GetPostPreparedCallbacks(Net.TheVpc.Upa.CallbackType callbackType, Net.TheVpc.Upa.ObjectType objectType, string nameFilter, bool system, Net.TheVpc.Upa.EventPhase phase) {
            Net.TheVpc.Upa.Impl.Util.CallbackInvokerKey k = new Net.TheVpc.Upa.Impl.Util.CallbackInvokerKey(callbackType, objectType, nameFilter, system);
            System.Collections.Generic.IList<Net.TheVpc.Upa.PreparedCallback> found = new System.Collections.Generic.List<Net.TheVpc.Upa.PreparedCallback>();
            System.Collections.Generic.IDictionary<Net.TheVpc.Upa.Impl.Util.CallbackInvokerKey , System.Collections.Generic.IList<Net.TheVpc.Upa.PreparedCallback>> list = this.preparedAfter;
            System.Collections.Generic.IList<Net.TheVpc.Upa.PreparedCallback> ss = Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<Net.TheVpc.Upa.Impl.Util.CallbackInvokerKey,System.Collections.Generic.IList<Net.TheVpc.Upa.PreparedCallback>>(list,k);
            if (ss != null) {
                Net.TheVpc.Upa.Impl.FwkConvertUtils.ListAddRange(found, ss);
            }
            if (nameFilter != null) {
                Net.TheVpc.Upa.Impl.FwkConvertUtils.ListAddRange(found, GetPostPreparedCallbacks(callbackType, objectType, null, system, phase));
            }
            if (!system) {
                Net.TheVpc.Upa.Impl.FwkConvertUtils.ListAddRange(found, GetPostPreparedCallbacks(callbackType, objectType, null, true, phase));
            }
            return found;
        }
    }
}
