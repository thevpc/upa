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
    public class OrderedIem<T> : System.IComparable<Net.Vpc.Upa.Impl.Util.OrderedIem<T>> {

        public int order;

        public T @value;

        public OrderedIem(int order, T @value) {
            this.order = order;
            this.@value = @value;
        }

        public virtual int CompareTo(Net.Vpc.Upa.Impl.Util.OrderedIem<T> o) {
            if (o == null) {
                return 1;
            }
            if (order < o.order) {
                return -1;
            } else if (order > o.order) {
                return 1;
            } else {
                return 0;
            }
        }
    }
}
