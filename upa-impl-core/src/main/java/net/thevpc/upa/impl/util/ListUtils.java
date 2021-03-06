package net.thevpc.upa.impl.util;

import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

import net.thevpc.upa.EventPhase;
import net.thevpc.upa.UPAObject;
import net.thevpc.upa.UPAObjectListener;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 8/24/12 11:02 PM
 */
public class ListUtils {

    public static <T extends UPAObject> void add(List<T> items, T child, UPAObject newParent, UPAObject obj, ItemInterceptor<T> interceptor) {
        int index=child.getPreferredPosition();
//        int[] old=new int[items.size()];
//        for (int i = 0; i < old.length; i++) {
//            old[i]=child.getPreferredPosition();
//        }
//        if (index < 0) {
//            index = items.size() + index + 1;
//        }
//        if (index < 0) {
//            if(lenient){
//               index=0;
//            }else {
//                throw new ArrayIndexOutOfBoundsException(index);
//            }
//        }
//        if (index > items.size()) {
//            if(lenient){
//                index=items.size();
//            }else {
//                throw new ArrayIndexOutOfBoundsException(index);
//            }
//        }
        if (interceptor != null) {
            interceptor.before(child, index);
        }
        UPAObjectListener[] objectListeners = obj.getObjectListeners();
        for (UPAObjectListener li : objectListeners) {
            li.itemAdded(child, index, newParent, EventPhase.BEFORE);
        }
        
        items.add(child);
        Collections.sort(items, UPAObjectPositionComparator.INSTANCE);
        if (interceptor != null) {
            interceptor.after(child, index);
        }
        for (UPAObjectListener li : objectListeners) {
            li.itemAdded(child, index, newParent, EventPhase.AFTER);
        }
    }

    public static <T extends UPAObject> T remove(List<T> items, int index, UPAObject propertyChangeSupport, ItemInterceptor<T> interceptor) {
        if (index < 0) {
            index = items.size() + index;
        }
        T toRemove = items.get(index);
        if (interceptor != null) {
            interceptor.before(toRemove, index);
        }
        UPAObjectListener[] objectListeners = propertyChangeSupport.getObjectListeners();
        for (UPAObjectListener li : objectListeners) {
            li.itemRemoved(toRemove, index, EventPhase.BEFORE);
        }
        ListUtils.remove(items, index, 1);
        if (interceptor != null) {
            interceptor.after(toRemove, index);
        }
        for (UPAObjectListener li : objectListeners) {
            li.itemRemoved(toRemove, index, EventPhase.AFTER);
        }
        return toRemove;
    }

    public static <T extends UPAObject> void moveTo(List<T> list, int index, int toIndex, UPAObject propertyChangeSupport, ItemInterceptor<T> interceptor) {
        T item = list.get(index);
        UPAObjectListener[] objectListeners = propertyChangeSupport.getObjectListeners();
        for (UPAObjectListener li : objectListeners) {
            li.itemMoved(item, index, toIndex, EventPhase.BEFORE);
        }
        if (interceptor != null) {
            interceptor.before(item, index);
        }
        ListUtils.moveTo(list, index, toIndex);
        if (interceptor != null) {
            interceptor.after(item, index);
        }
        for (UPAObjectListener li : objectListeners) {
            li.itemMoved(item, index, toIndex, EventPhase.AFTER);
        }
    }

//    public static <T> void add(List<T> items, T child, int index, Object newParent, PropertyChangeSupport propertyChangeSupport, ItemInterceptor<T> interceptor) {
//        if (index < 0) {
//            index = items.size() + index + 1;
//        }
//        if (index < 0) {
//            throw new ArrayIndexOutOfBoundsException(index);
//        }
//        if (index > items.size()) {
//            throw new ArrayIndexOutOfBoundsException(index);
//        }
//        if (interceptor != null) {
//            interceptor.before(child, index);
//        }
//        propertyChangeSupport.firePropertyChange(UPAUtils.CONTENT_PROP_PRE_ADD, null, new Object[]{child, index, newParent});
//        items.add(index, child);
//        if (interceptor != null) {
//            interceptor.after(child, index);
//        }
//        propertyChangeSupport.firePropertyChange(UPAUtils.CONTENT_PROP_POST_ADD, null, new Object[]{child, index, newParent});
//    }
//
//    public static <T> T remove(List<T> items, int index, PropertyChangeSupport propertyChangeSupport, ItemInterceptor<T> interceptor) {
//        if (index < 0) {
//            index = items.size() + index;
//        }
//        T toRemove = items.get(index);
//        if (interceptor != null) {
//            interceptor.before(toRemove, index);
//        }
//        propertyChangeSupport.firePropertyChange(UPAUtils.CONTENT_PROP_PRE_REMOVE, null, new Object[]{toRemove, index});
//        ListUtils.remove(items, index, 1);
//        if (interceptor != null) {
//            interceptor.after(toRemove, index);
//        }
//        propertyChangeSupport.firePropertyChange(UPAUtils.CONTENT_PROP_POST_REMOVE, null, new Object[]{toRemove, index});
//        return toRemove;
//    }
//
//    public static <T> void moveTo(List<T> list, int index, int toIndex, PropertyChangeSupport propertyChangeSupport, ItemInterceptor<T> interceptor) {
//        T item = list.get(index);
//        propertyChangeSupport.firePropertyChange(UPAUtils.CONTENT_PROP_PRE_MOVE, null, new Object[]{item, index, toIndex});
//        if (interceptor != null) {
//            interceptor.before(item, index);
//        }
//        ListUtils.moveTo(list, index, toIndex);
//        if (interceptor != null) {
//            interceptor.after(item, index);
//        }
//        propertyChangeSupport.firePropertyChange(UPAUtils.CONTENT_PROP_POST_MOVE, null, new Object[]{item, index, toIndex});
//    }

    public static <T> void remove(List<T> list, int start, int count) {
        for (int i = 0; i < count; i++) {
            list.remove(start);
        }
    }

    public static <T> void moveRelative(List<T> list, int index, int delta) {
        moveTo(list, index, index + delta);
    }

    public static <T> void moveTo(List<T> list, int index, int toIndex) {
        T r = list.remove(index);
        list.add(toIndex, r);
    }

    public static <T> void moveRelative(List<T> list, int index, int delta, int count) {
        moveTo(list, index, index + delta, count);
    }

    public static <T> void moveTo(List<T> list, int index, int toIndex, int count) {
        List<T> x = new ArrayList<T>();
        for (int i = 0; i < count; i++) {
            x.add(list.remove(index));
        }
        list.addAll(toIndex, x);
    }
}
