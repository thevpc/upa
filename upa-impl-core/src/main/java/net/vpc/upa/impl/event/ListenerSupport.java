/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.event;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class ListenerSupport<T> {

    private List<T> allCommun = new ArrayList<T>();
    private Map<String, List<T>> someCommun = new HashMap<String, List<T>>();
    private List<T> allSystem = new ArrayList<T>();
    private Map<String, List<T>> someSystem = new HashMap<String, List<T>>();

    public void add(boolean system, String name, T t) {
        if (name != null && name.length() == 0) {
            name = null;
        }
        if (system) {
            if (name == null) {
                allSystem.add(t);
            } else {
                List<T> v = someSystem.get(name);
                if (v == null) {
                    v = new ArrayList<T>();
                    someSystem.put(name, v);
                }
                v.add(t);
            }
        } else {
            if (name == null) {
                allCommun.add(t);
            } else {
                List<T> v = someCommun.get(name);
                if (v == null) {
                    v = new ArrayList<T>();
                    someCommun.put(name, v);
                }
                v.add(t);
            }
        }
    }

    public void remove(String n, T t) {
        remove(true, n, t);
        remove(false, n, t);
    }

    public void remove(boolean system, String n, T t) {
        if (system) {
            if (n == null) {
                allSystem.remove(t);
            } else {
                List<T> v = someSystem.get(n);
                if (v != null) {
                    v.remove(t);
                }
            }
        } else {
            if (n == null) {
                allCommun.remove(t);
            } else {
                List<T> v = someCommun.get(n);
                if (v != null) {
                    v.remove(t);
                }
            }
        }
    }

    public List<T> getAllListeners(boolean system, String... names) {
        ArrayList<T> ret = new ArrayList<T>();
        if (names == null || names.length == 0) {
            ret.addAll(allSystem);
            if (!system) {
                ret.addAll(allCommun);
            }
        } else {
            ret.addAll(allSystem);
            for (String n : names) {
                List<T> v = someSystem.get(n);
                if (v != null) {
                    ret.addAll(v);
                }
            }
            if (!system) {
                ret.addAll(allCommun);
                for (String n : names) {
                    List<T> v = someCommun.get(n);
                    if (v != null) {
                        ret.addAll(v);
                    }
                }
            }
        }
        return ret;
    }

//    public List<T> toList(String n) {
//        if (n == null) {
//            return new ArrayList<T>(allCommun);
//        } else {
//            List<T> sum = new ArrayList<T>(allCommun);
//            List<T> v = someCommun.get(n);
//            if (v != null) {
//                sum.addAll(v);
//            }
//            return sum;
//        }
//    }
//    public T[] toArray(String n, T[] arr) {
//        if (n == null) {
//            return allCommun.toArray(arr);
//        } else {
//            List<T> sum = new ArrayList<T>(allCommun);
//            List<T> v = someCommun.get(n);
//            if (v != null) {
//                sum.addAll(v);
//            }
//            return sum.toArray(arr);
//        }
//    }
    public T[] toArrayConstrainted(boolean system, String n, T[] arr) {
        if (system) {
            if (n == null) {
                return allSystem.toArray(arr);
            } else {
                List<T> sum = new ArrayList<T>();
                List<T> v = someSystem.get(n);
                if (v != null) {
                    sum.addAll(v);
                }
                return sum.toArray(arr);
            }
        } else {
            if (n == null) {
                return allCommun.toArray(arr);
            } else {
                List<T> sum = new ArrayList<T>();
                List<T> v = someCommun.get(n);
                if (v != null) {
                    sum.addAll(v);
                }
                return sum.toArray(arr);
            }
        }
    }

    public void close() {
        for (Object object : allCommun.toArray()) {
            T t = (T) object;
            remove(false, null, t);
        }
        String[] keys = someCommun.keySet().toArray(new String[someCommun.size()]);
        for (String key : keys) {
            List<T> list = someCommun.get(key);
            if (list != null) {
                for (Object object : list.toArray(new Object[list.size()])) {
                    T t = (T) object;
                    remove(false, key, t);
                }
            }
        }
        for (Object object : allSystem.toArray()) {
            T t = (T) object;
            remove(true, null, t);
        }
        keys = someSystem.keySet().toArray(new String[someSystem.size()]);
        for (String key : keys) {
            List<T> list = someSystem.get(key);
            if (list != null) {
                for (Object object : list.toArray(new Object[list.size()])) {
                    T t = (T) object;
                    remove(true, key, t);
                }
            }
        }
    }
}
