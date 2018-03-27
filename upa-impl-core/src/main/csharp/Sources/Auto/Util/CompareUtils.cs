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
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 12/17/12 7:18 PM
     */
    public class CompareUtils {

        public static  void Sort<T>(T[] array, Net.Vpc.Upa.Impl.Util.IndexedComparator<T> comparator) {
            Net.Vpc.Upa.Impl.Util.IndexedItem<T>[] x = new Net.Vpc.Upa.Impl.Util.IndexedItem<T>[array.Length];
            for (int i = 0; i < x.Length; i++) {
                x[i] = new Net.Vpc.Upa.Impl.Util.IndexedItem<T>(array[i], i);
            }
            System.Collections.Generic.IComparer<Net.Vpc.Upa.Impl.Util.IndexedItem<T>> comparator2 = new Net.Vpc.Upa.Impl.Util.IndexedItemComparator<T>(comparator);
            System.Array.Sort(x,(System.Collections.IComparer)comparator2);
        }
    }
}
