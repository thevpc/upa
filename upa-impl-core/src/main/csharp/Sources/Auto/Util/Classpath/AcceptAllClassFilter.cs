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



namespace Net.TheVpc.Upa.Impl.Util.Classpath
{

    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 12/16/12 1:05 PM
     */
    public class AcceptAllClassFilter : Net.TheVpc.Upa.Impl.Util.Classpath.ClassFilter {

        public static readonly Net.TheVpc.Upa.Impl.Util.Classpath.AcceptAllClassFilter INSTANCE = new Net.TheVpc.Upa.Impl.Util.Classpath.AcceptAllClassFilter();

        public virtual bool Accept(System.Type cls) {
            return true;
        }
    }
}
