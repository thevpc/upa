package net.thevpc.upa.impl.util;

import net.thevpc.upa.*;


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
        boolean fireBefore = callback.getEventPhase() == EventPhase.BEFORE;
        String nameFilter = null;
        boolean trackSystemObjects = true;
        if (conf != null && conf.containsKey("trackSystemObjects")) {
            trackSystemObjects = (Boolean) conf.get("trackSystemObjects");
        }
        nameFilter = conf == null ? null : (String) conf.get("nameFilter");
        if (StringUtils.isNullOrEmpty(nameFilter)) {
            nameFilter = null;
        }
        if (fireBefore) {
            CallbackInvokerKey k = createCallbackInvokerKey(callback.getEventType(), callback.getObjectType(), nameFilter, trackSystemObjects);
            List<Callback> ss = this.before.get(k);
            if (ss == null) {
                ss = new ArrayList<Callback>();
                this.before.put(k, ss);
            }
            ss.add(callback);
        } else {
            CallbackInvokerKey k = createCallbackInvokerKey(callback.getEventType(), callback.getObjectType(), nameFilter, trackSystemObjects);
            List<Callback> ss = this.after.get(k);
            if (ss == null) {
                ss = new ArrayList<Callback>();
                this.after.put(k, ss);
            }
            ss.add(callback);
            if (callback instanceof PreparedCallback) {
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
        if (conf != null) {
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

        CallbackInvokerKey k = createCallbackInvokerKey(callback.getEventType(), callback.getObjectType(), nameFilter, trackSystemObjects);
        List<Callback> ss = before.get(k);
        if (ss != null) {
            ss.remove(callback);
        }
        ss = after.get(k);
        if (ss != null) {
            ss.remove(callback);
        }
        if (callback instanceof PreparedCallback) {
            List<PreparedCallback> sss = preparedAfter.get(k);
            if (sss != null) {
                sss.remove((PreparedCallback) callback);
            }
        }
    }

    public List<Callback> getCallbacks(EventType eventType, ObjectType objectType, String nameFilter, boolean system, boolean preparedOnly, EventPhase phase) {
        CallbackInvokerKey k = createCallbackInvokerKey(eventType, objectType, nameFilter, system);
        List<Callback> found = new ArrayList<Callback>();
        if (preparedOnly) {
            Map<CallbackInvokerKey, List<PreparedCallback>> list = null;
            list = phase == EventPhase.AFTER ? this.preparedAfter : null;
            List<PreparedCallback> ss = list.get(k);
            if (ss != null) {
                found.addAll(ss);
            }
            if (nameFilter != null) {
                CallbackInvokerKey k2 = createCallbackInvokerKey(eventType, objectType, null, system);
                ss = list.get(k2);
                if (ss != null) {
                    found.addAll(ss);
                }
            }
            if (!system) {
                CallbackInvokerKey k2 = createCallbackInvokerKey(eventType, objectType, nameFilter, true);
                ss = list.get(k2);
                if (ss != null) {
                    found.addAll(ss);
                }
            }
            if (nameFilter != null && !system) {
                CallbackInvokerKey k2 = createCallbackInvokerKey(eventType, objectType, null, true);
                ss = list.get(k2);
                if (ss != null) {
                    found.addAll(ss);
                }
            }
        } else {
            Map<CallbackInvokerKey, List<Callback>> list = null;
            list = phase == EventPhase.AFTER ? this.after : this.before;

            List<Callback> ss = list.get(k);
            if (ss != null) {
                found.addAll(ss);
            }
            if (nameFilter != null) {
                CallbackInvokerKey k2 = createCallbackInvokerKey(eventType, objectType, null, system);
                ss = list.get(k2);
                if (ss != null) {
                    found.addAll(ss);
                }
            }
            if (!system) {
                CallbackInvokerKey k2 = createCallbackInvokerKey(eventType, objectType, nameFilter, true);
                ss = list.get(k2);
                if (ss != null) {
                    found.addAll(ss);
                }
            }
            if (nameFilter != null && !system) {
                CallbackInvokerKey k2 = createCallbackInvokerKey(eventType, objectType, null, true);
                ss = list.get(k2);
                if (ss != null) {
                    found.addAll(ss);
                }
            }
        }

        return found;
    }

    public List<PreparedCallback> getPostPreparedCallbacks(EventType eventType, ObjectType objectType, String nameFilter, boolean system, EventPhase phase) {
        CallbackInvokerKey k = createCallbackInvokerKey(eventType, objectType, nameFilter, system);
        List<PreparedCallback> found = new ArrayList<PreparedCallback>();
        Map<CallbackInvokerKey, List<PreparedCallback>> list = this.preparedAfter;
        List<PreparedCallback> ss = list.get(k);
        if (ss != null) {
            found.addAll(ss);
        }
        if (nameFilter != null) {
            found.addAll(getPostPreparedCallbacks(eventType, objectType, null, system, phase));
        }

        if (!system) {
            found.addAll(getPostPreparedCallbacks(eventType, objectType, null, true, phase));
        }
        return found;
    }

    private static class HashCallbackInvokerKey {

        Map<String, CallbackInvokerKey> keys;
    }
    private HashCallbackInvokerKey[][][] hash = new HashCallbackInvokerKey[2][EventType.values().length][ObjectType.values().length];

    public CallbackInvokerKey createCallbackInvokerKey(EventType eventType, ObjectType objectType, String name, boolean system) {
        HashCallbackInvokerKey t = hash[system ? 1 : 0][eventType.ordinal()][objectType.ordinal()];
        if (t == null) {
            t = new HashCallbackInvokerKey();
            hash[system ? 1 : 0][eventType.ordinal()][objectType.ordinal()] = t;
        }
        if (t.keys == null) {
            t.keys = new HashMap<String, CallbackInvokerKey>(3);
        }
        CallbackInvokerKey m = t.keys.get(name);
        if (m == null) {
            m = new CallbackInvokerKey(eventType, objectType, name, system);
            t.keys.put(name, m);
        }
        return m;//new CallbackInvokerKey(eventType, objectType, name, system);
    }

    private List<Callback> getAllBeforeCallbacks() {
        List<Callback> all = new ArrayList<>();
        for (List<Callback> value : before.values()) {
            for (Callback callback : value) {
                all.add(callback);
            }
        }
        return all;
    }
    private List<Callback> getAllAfterCallbacks() {
        List<Callback> all = new ArrayList<>();
        for (List<Callback> value : after.values()) {
            for (Callback callback : value) {
                all.add(callback);
            }
        }
        return all;
    }
    private List<PreparedCallback> getAllPreparedAfterCallbacks() {
        List<PreparedCallback> all = new ArrayList<>();
        for (List<PreparedCallback> value : preparedAfter.values()) {
            for (PreparedCallback callback : value) {
                all.add(callback);
            }
        }
        return all;
    }

    public void close() {
        for (Callback value : getAllBeforeCallbacks()) {
            removeCallback(value);
        }
        for (Callback value : getAllAfterCallbacks()) {
            removeCallback(value);
        }
        for (PreparedCallback value : getAllPreparedAfterCallbacks()) {
            removeCallback(value);
        }
    }
}
