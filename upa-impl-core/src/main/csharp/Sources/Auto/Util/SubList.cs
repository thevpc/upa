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
     *
     * @author taha.bensalah@gmail.com
     */
    public class SubList<E> : System.Collections.Generic.List<E> {

        private readonly System.Collections.Generic.IList<E> parent;

        private readonly int parentOffset;

        private readonly int offset;

        private int size;

        public SubList(System.Collections.Generic.IList<E> parent, int offset, int fromIndex, int toIndex) {
            this.parent = parent;
            this.parentOffset = fromIndex;
            this.offset = offset + fromIndex;
            this.size = toIndex - fromIndex;
        }





















        private void RangeCheck(int index) {
            if (index < 0 || index >= this.size) {
                throw new System.IndexOutOfRangeException(OutOfBoundsMsg(index));
            }
        }

        private void RangeCheckForAdd(int index) {
            if (index < 0 || index > this.size) {
                throw new System.IndexOutOfRangeException(OutOfBoundsMsg(index));
            }
        }

        private string OutOfBoundsMsg(int index) {
            return "Index: " + index + ", Size: " + this.size;
        }

        private void CheckForCoModification() {
        }

        internal static void SubListRangeCheck(int fromIndex, int toIndex, int size) {
            if (fromIndex < 0) {
                throw new System.IndexOutOfRangeException("fromIndex = " + fromIndex);
            }
            if (toIndex > size) {
                throw new System.IndexOutOfRangeException("toIndex = " + toIndex);
            }
            if (fromIndex > toIndex) {
                throw new System.ArgumentException ("fromIndex(" + fromIndex + ") > toIndex(" + toIndex + ")");
            }
        }
    }
}
