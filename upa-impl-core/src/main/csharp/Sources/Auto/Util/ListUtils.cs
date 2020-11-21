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
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 8/24/12 11:02 PM
     */
    public class ListUtils {

        public static  void Add<T>(System.Collections.Generic.IList<T> items, T child, int index, Net.TheVpc.Upa.UPAObject newParent, Net.TheVpc.Upa.UPAObject obj, Net.TheVpc.Upa.Impl.Util.ItemInterceptor<T> interceptor) where  T : Net.TheVpc.Upa.UPAObject {
            if (index < 0) {
                index = (items).Count + index + 1;
            }
            if (index < 0) {
                throw new System.IndexOutOfRangeException("Invalid Index "+(index));
            }
            if (index > (items).Count) {
                throw new System.IndexOutOfRangeException("Invalid Index "+(index));
            }
            if (interceptor != null) {
                interceptor.Before(child, index);
            }
            Net.TheVpc.Upa.UPAObjectListener[] objectListeners = obj.GetObjectListeners();
            foreach (Net.TheVpc.Upa.UPAObjectListener li in objectListeners) {
                li.ItemAdded(child, index, newParent, Net.TheVpc.Upa.EventPhase.BEFORE);
            }
            items.Insert(index, child);
            if (interceptor != null) {
                interceptor.After(child, index);
            }
            foreach (Net.TheVpc.Upa.UPAObjectListener li in objectListeners) {
                li.ItemAdded(child, index, newParent, Net.TheVpc.Upa.EventPhase.AFTER);
            }
        }

        public static  T Remove<T>(System.Collections.Generic.IList<T> items, int index, Net.TheVpc.Upa.UPAObject propertyChangeSupport, Net.TheVpc.Upa.Impl.Util.ItemInterceptor<T> interceptor) where  T : Net.TheVpc.Upa.UPAObject {
            if (index < 0) {
                index = (items).Count + index;
            }
            T toRemove = items[index];
            if (interceptor != null) {
                interceptor.Before(toRemove, index);
            }
            Net.TheVpc.Upa.UPAObjectListener[] objectListeners = propertyChangeSupport.GetObjectListeners();
            foreach (Net.TheVpc.Upa.UPAObjectListener li in objectListeners) {
                li.ItemRemoved(toRemove, index, Net.TheVpc.Upa.EventPhase.BEFORE);
            }
            Net.TheVpc.Upa.Impl.Util.ListUtils.Remove<T>(items, index, 1);
            if (interceptor != null) {
                interceptor.After(toRemove, index);
            }
            foreach (Net.TheVpc.Upa.UPAObjectListener li in objectListeners) {
                li.ItemRemoved(toRemove, index, Net.TheVpc.Upa.EventPhase.AFTER);
            }
            return toRemove;
        }

        public static  void MoveTo<T>(System.Collections.Generic.IList<T> list, int index, int toIndex, Net.TheVpc.Upa.UPAObject propertyChangeSupport, Net.TheVpc.Upa.Impl.Util.ItemInterceptor<T> interceptor) where  T : Net.TheVpc.Upa.UPAObject {
            T item = list[index];
            Net.TheVpc.Upa.UPAObjectListener[] objectListeners = propertyChangeSupport.GetObjectListeners();
            foreach (Net.TheVpc.Upa.UPAObjectListener li in objectListeners) {
                li.ItemMoved(item, index, toIndex, Net.TheVpc.Upa.EventPhase.BEFORE);
            }
            if (interceptor != null) {
                interceptor.Before(item, index);
            }
            Net.TheVpc.Upa.Impl.Util.ListUtils.MoveTo<T>(list, index, toIndex);
            if (interceptor != null) {
                interceptor.After(item, index);
            }
            foreach (Net.TheVpc.Upa.UPAObjectListener li in objectListeners) {
                li.ItemMoved(item, index, toIndex, Net.TheVpc.Upa.EventPhase.AFTER);
            }
        }

        public static  void Remove<T>(System.Collections.Generic.IList<T> list, int start, int count) {
            for (int i = 0; i < count; i++) {
                list.RemoveAt(start);
            }
        }

        public static  void MoveRelative<T>(System.Collections.Generic.IList<T> list, int index, int delta) {
            MoveTo<T>(list, index, index + delta);
        }

        public static  void MoveTo<T>(System.Collections.Generic.IList<T> list, int index, int toIndex) {
            T r = Net.TheVpc.Upa.Impl.FwkConvertUtils.ListRemoveAt<T>(list,index);
            list.Insert(toIndex, r);
        }

        public static  void MoveRelative<T>(System.Collections.Generic.IList<T> list, int index, int delta, int count) {
            MoveTo<T>(list, index, index + delta, count);
        }

        public static  void MoveTo<T>(System.Collections.Generic.IList<T> list, int index, int toIndex, int count) {
            System.Collections.Generic.IList<T> x = new System.Collections.Generic.List<T>();
            for (int i = 0; i < count; i++) {
                x.Add(Net.TheVpc.Upa.Impl.FwkConvertUtils.ListRemoveAt<T>(list,index));
            }
            Net.TheVpc.Upa.Impl.FwkConvertUtils.ListInsertRange(list, toIndex, x);
        }
    }
}
