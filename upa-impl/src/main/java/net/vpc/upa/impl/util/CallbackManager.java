package net.vpc.upa.impl.util;

import net.vpc.upa.Callback;
import net.vpc.upa.CallbackType;
import net.vpc.upa.EventPhase;
import net.vpc.upa.ObjectType;
import net.vpc.upa.impl.config.callback.DefaultCallback;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

/**
 * Created by vpc on 7/25/15.
 */
public class CallbackManager {

    Map<CallbackInvokerKey, List<Callback>> before = new HashMap<CallbackInvokerKey, List<Callback>>();
    Map<CallbackInvokerKey, List<Callback>> after = new HashMap<CallbackInvokerKey, List<Callback>>();

    public void addCallback(Callback callback) {
        DefaultCallback dcallback = (DefaultCallback) callback;
        Map<String, Object> conf = dcallback.getConfiguration();
        if (conf == null) {
            conf = new HashMap<String, Object>();
        }
        boolean fireBefore = callback.getCallbackType().name().startsWith("ON_PRE_");
        boolean trackSystemObjects = true;
        String nameFilter = null;
        if (conf.containsKey("trackSystemObjects")) {
            trackSystemObjects = (Boolean) conf.get("trackSystemObjects");
        }
        nameFilter = (String) conf.get("nameFilter");
        if (Strings.isNullOrEmpty(nameFilter)) {
            nameFilter = null;
        }
        if (fireBefore) {
            CallbackInvokerKey k = new CallbackInvokerKey(callback.getCallbackType(), callback.getObjectType(), nameFilter, trackSystemObjects);
            List<Callback> ss = this.before.get(k);
            if (ss == null) {
                ss = new ArrayList<Callback>();
                this.before.put(k, ss);
            }
            ss.add(callback);
        } else {
            CallbackInvokerKey k = new CallbackInvokerKey(callback.getCallbackType(), callback.getObjectType(), nameFilter, trackSystemObjects);
            List<Callback> ss = this.after.get(k);
            if (ss == null) {
                ss = new ArrayList<Callback>();
                this.after.put(k, ss);
            }
            ss.add(callback);
        }
    }

    public void removeCallback(Callback callback) {

        DefaultCallback dcallback = (DefaultCallback) callback;
        Map<String, Object> conf = dcallback.getConfiguration();
        if (conf == null) {
            conf = new HashMap<String, Object>();
        }
        boolean fireBefore = true;
        boolean fireAfter = true;
        boolean trackSystemObjects = true;
        String nameFilter = null;
        if (conf.containsKey("before")) {
            fireBefore = (Boolean) conf.get("before");
        }
        if (conf.containsKey("after")) {
            fireBefore = (Boolean) conf.get("after");
        }
        if (conf.containsKey("trackSystemObjects")) {
            trackSystemObjects = (Boolean) conf.get("trackSystemObjects");
        }
        nameFilter = (String) conf.get("nameFilter");
        if (Strings.isNullOrEmpty(nameFilter)) {
            nameFilter = null;
        }

        CallbackInvokerKey k = new CallbackInvokerKey(callback.getCallbackType(), callback.getObjectType(), nameFilter, trackSystemObjects);
        List<Callback> ss = before.get(k);
        if (ss != null) {
            ss.remove(callback);
        }
        ss = after.get(k);
        if (ss != null) {
            ss.remove(callback);
        }
    }

    public List<Callback> getCallbacks(CallbackType callbackType, ObjectType objectType, String nameFilter, boolean system, EventPhase phase) {
        CallbackInvokerKey k = new CallbackInvokerKey(callbackType, objectType, nameFilter, system);
        List<Callback> found = new ArrayList<Callback>();
        Map<CallbackInvokerKey, List<Callback>> list = phase == EventPhase.AFTER ? this.after : this.before;
        List<Callback> ss = list.get(k);
        if (ss != null) {
            found.addAll(ss);
        }
        if (nameFilter != null) {
            found.addAll(getCallbacks(callbackType, objectType, null, system, phase));
        } else if (!system) {
            found.addAll(getCallbacks(callbackType, objectType, null, true, phase));
        }
        return found;
    }

    public List<Callback> getCallbacks(CallbackType callbackType, ObjectType objectType, String nameFilter, boolean system) {
        CallbackInvokerKey k = new CallbackInvokerKey(callbackType, objectType, nameFilter, system);
        List<Callback> found = new ArrayList<Callback>();
        for (EventPhase phase : EventPhase.values()) {
            Map<CallbackInvokerKey, List<Callback>> list = phase == EventPhase.AFTER ? this.after : this.before;
            List<Callback> ss = list.get(k);
            if (ss != null) {
                found.addAll(ss);
            }
            if (nameFilter != null) {
                found.addAll(getCallbacks(callbackType, objectType, null, system, phase));
            } else if (!system) {
                found.addAll(getCallbacks(callbackType, objectType, null, true, phase));
            }
        }
        return found;
    }

}
