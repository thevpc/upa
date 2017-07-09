package net.vpc.upa.impl.util;

import net.vpc.upa.*;
import net.vpc.upa.impl.config.callback.DefaultCallback;

import java.util.*;

/**
 * Created by vpc on 7/25/15.
 */
public class CallbackManager {

    Map<CallbackInvokerKey, List<Callback>> before = new HashMap<CallbackInvokerKey, List<Callback>>();
    Map<CallbackInvokerKey, List<Callback>> after = new HashMap<CallbackInvokerKey, List<Callback>>();
    Map<CallbackInvokerKey, List<PreparedCallback>> preparedAfter = new HashMap<CallbackInvokerKey, List<PreparedCallback>>();

    public void addCallback(Callback callback) {
        Map<String, Object> conf = callback.getConfiguration();
//        if (conf == null) {
//            conf = new HashMap<String, Object>();
//        }
        boolean fireBefore = callback.getPhase()==EventPhase.BEFORE;
        String nameFilter = null;
        boolean trackSystemObjects = true;
        if (conf!=null && conf.containsKey("trackSystemObjects")) {
            trackSystemObjects = (Boolean) conf.get("trackSystemObjects");
        }
        nameFilter = conf==null ?null : (String) conf.get("nameFilter");
        if (StringUtils.isNullOrEmpty(nameFilter)) {
            nameFilter = null;
        }
        if (fireBefore) {
            CallbackInvokerKey k = createCallbackInvokerKey(callback.getCallbackType(), callback.getObjectType(), nameFilter, trackSystemObjects);
            List<Callback> ss = this.before.get(k);
            if (ss == null) {
                ss = new ArrayList<Callback>();
                this.before.put(k, ss);
            }
            ss.add(callback);
        } else {
            CallbackInvokerKey k = createCallbackInvokerKey(callback.getCallbackType(), callback.getObjectType(), nameFilter, trackSystemObjects);
            List<Callback> ss = this.after.get(k);
            if (ss == null) {
                ss = new ArrayList<Callback>();
                this.after.put(k, ss);
            }
            ss.add(callback);
            if(callback instanceof PreparedCallback){
                List<PreparedCallback> sss = this.preparedAfter.get(k);
                if (sss == null) {
                    sss = new ArrayList<PreparedCallback>();
                    this.preparedAfter.put(k, sss);
                }
                sss.add((PreparedCallback) callback);

            }
        }
    }

    public void removeCallback(Callback callback) {

        Map<String, Object> conf = callback.getConfiguration();
//        if (conf == null) {
//            conf = new HashMap<String, Object>();
//        }
        boolean fireBefore = true;
        boolean fireAfter = true;
        boolean trackSystemObjects = true;
        String nameFilter = null;
        if(conf!=null) {
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
        }
        if (StringUtils.isNullOrEmpty(nameFilter)) {
            nameFilter = null;
        }

        CallbackInvokerKey k = createCallbackInvokerKey(callback.getCallbackType(), callback.getObjectType(), nameFilter, trackSystemObjects);
        List<Callback> ss = before.get(k);
        if (ss != null) {
            ss.remove(callback);
        }
        ss = after.get(k);
        if (ss != null) {
            ss.remove(callback);
        }
        if(callback instanceof PreparedCallback) {
            List<PreparedCallback> sss = preparedAfter.get(k);
            if (sss != null) {
                sss.remove((PreparedCallback) callback);
            }
        }
    }

    public List<Callback> getCallbacks(CallbackType callbackType, ObjectType objectType, String nameFilter, boolean system, boolean preparedOnly, EventPhase phase) {
        CallbackInvokerKey k = createCallbackInvokerKey(callbackType, objectType, nameFilter, system);
        List<Callback> found = new ArrayList<Callback>();
        if(preparedOnly){
            Map<CallbackInvokerKey, List<PreparedCallback>> list = null;
            list=phase == EventPhase.AFTER ? this.preparedAfter : null;
            List<PreparedCallback> ss = list.get(k);
            if (ss != null) {
                found.addAll(ss);
            }
            if (nameFilter != null) {
                CallbackInvokerKey k2 = createCallbackInvokerKey(callbackType, objectType, null, system);
                ss = list.get(k2);
                if (ss != null) {
                    found.addAll(ss);
                }
            }
            if (!system) {
                CallbackInvokerKey k2 = createCallbackInvokerKey(callbackType, objectType, nameFilter, true);
                ss = list.get(k2);
                if (ss != null) {
                    found.addAll(ss);
                }
            }
            if (nameFilter != null && !system) {
                CallbackInvokerKey k2 = createCallbackInvokerKey(callbackType, objectType, null, true);
                ss = list.get(k2);
                if (ss != null) {
                    found.addAll(ss);
                }
            }
        }else{
            Map<CallbackInvokerKey, List<Callback>> list = null;
            list=phase == EventPhase.AFTER ? this.after : this.before;

            List<Callback> ss = list.get(k);
            if (ss != null) {
                found.addAll(ss);
            }
            if (nameFilter != null) {
                CallbackInvokerKey k2 = createCallbackInvokerKey(callbackType, objectType, null, system);
                ss = list.get(k2);
                if (ss != null) {
                    found.addAll(ss);
                }
            }
            if (!system) {
                CallbackInvokerKey k2 = createCallbackInvokerKey(callbackType, objectType, nameFilter, true);
                ss = list.get(k2);
                if (ss != null) {
                    found.addAll(ss);
                }
            }
            if (nameFilter != null && !system) {
                CallbackInvokerKey k2 = createCallbackInvokerKey(callbackType, objectType, null, true);
                ss = list.get(k2);
                if (ss != null) {
                    found.addAll(ss);
                }
            }
        }

        return found;
    }

    public List<PreparedCallback> getPostPreparedCallbacks(CallbackType callbackType, ObjectType objectType, String nameFilter, boolean system, EventPhase phase) {
        CallbackInvokerKey k = createCallbackInvokerKey(callbackType, objectType, nameFilter, system);
        List<PreparedCallback> found = new ArrayList<PreparedCallback>();
        Map<CallbackInvokerKey, List<PreparedCallback>> list = this.preparedAfter;
        List<PreparedCallback> ss = list.get(k);
        if (ss != null) {
            found.addAll(ss);
        }
        if (nameFilter != null) {
            found.addAll(getPostPreparedCallbacks(callbackType, objectType, null, system, phase));
        }

        if (!system) {
            found.addAll(getPostPreparedCallbacks(callbackType, objectType, null, true, phase));
        }
        return found;
    }

    private static class HashCallbackInvokerKey{
        Map<String,CallbackInvokerKey> keys;
    }
    private HashCallbackInvokerKey[][][] hash=new HashCallbackInvokerKey[2][CallbackType.values().length][ObjectType.values().length];
    public CallbackInvokerKey createCallbackInvokerKey(CallbackType callbackType, ObjectType objectType, String name, boolean system){
        HashCallbackInvokerKey t = hash[system ? 1 : 0][callbackType.ordinal()][objectType.ordinal()];
        if(t==null){
            t=new HashCallbackInvokerKey();
            hash[system ? 1 : 0][callbackType.ordinal()][objectType.ordinal()]=t;
        }
        if(t.keys==null){
            t.keys=new HashMap<>(3);
        }
        CallbackInvokerKey m = t.keys.get(name);
        if(m==null){
            m=new CallbackInvokerKey(callbackType, objectType, name, system);
            t.keys.put(name,m);
        }
        return m;//new CallbackInvokerKey(callbackType, objectType, name, system);
    }

//    public List<Callback> getCallbacks(CallbackType callbackType, AnyObjectType objectType, String nameFilter, boolean system) {
//        CallbackInvokerKey k = new CallbackInvokerKey(callbackType, objectType, nameFilter, system);
//        List<Callback> found = new ArrayList<Callback>();
//        for (EventPhase phase : EventPhase.values()) {
//            Map<CallbackInvokerKey, List<Callback>> list = phase == EventPhase.AFTER ? this.after : this.before;
//            List<Callback> ss = list.get(k);
//            if (ss != null) {
//                found.addAll(ss);
//            }
//            if (nameFilter != null) {
//                found.addAll(getCallbacks(callbackType, objectType, null, system, phase));
//            } else if (!system) {
//                found.addAll(getCallbacks(callbackType, objectType, null, true, phase));
//            }
//        }
//        return found;
//    }

}
