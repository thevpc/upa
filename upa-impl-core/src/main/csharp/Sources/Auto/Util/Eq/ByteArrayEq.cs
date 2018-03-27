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



namespace Net.Vpc.Upa.Impl.Util.Eq
{


    /**
     *
     * @author taha.bensalah@gmail.com
     */
    public class ByteArrayEq : Net.Vpc.Upa.Impl.Util.Eq.EqualHelper {

        public static readonly Net.Vpc.Upa.Impl.Util.Eq.EqualHelper INSTANCE = new Net.Vpc.Upa.Impl.Util.Eq.ByteArrayEq();

        public virtual bool Equals(object o1, object o2) {
            byte[] a = (byte[]) o1;
            byte[] b = (byte[]) o2;
            if (a == b) {
                return true;
            }
            if (a == null || b == null) {
                return false;
            }
            if (a.Length != b.Length) {
                return false;
            }
            for (int i = 0; i < a.Length; i++) {
                if (a[i] != b[i]) {
                    return false;
                }
            }
            return true;
        }
    }
}
