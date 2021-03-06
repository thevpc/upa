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
    * @creationdate 1/5/13 10:10 PM*/
    internal class IndexedItemComparator<T> : System.Collections.Generic.IComparer<Net.TheVpc.Upa.Impl.Util.IndexedItem<T>> {

        private readonly Net.TheVpc.Upa.Impl.Util.IndexedComparator<T> comparator;

        public IndexedItemComparator(Net.TheVpc.Upa.Impl.Util.IndexedComparator<T> comparator) {
            this.comparator = comparator;
        }


        public virtual int Compare(Net.TheVpc.Upa.Impl.Util.IndexedItem<T> o1, Net.TheVpc.Upa.Impl.Util.IndexedItem<T> o2) {
            return comparator.Compare(o1.GetItem(), o2.GetItem(), o1.GetIndex(), o2.GetIndex());
        }
    }
}
