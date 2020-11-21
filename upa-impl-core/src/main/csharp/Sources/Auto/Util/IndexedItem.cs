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
    * @creationdate 1/5/13 10:03 PM*/
    internal class IndexedItem<G> {

        private G item;

        private int index;

        internal IndexedItem(G item, int index) {
            this.SetItem(item);
            this.SetIndex(index);
        }

        public virtual G GetItem() {
            return item;
        }

        public virtual void SetItem(G item) {
            this.item = item;
        }

        public virtual int GetIndex() {
            return index;
        }

        public virtual void SetIndex(int index) {
            this.index = index;
        }
    }
}
