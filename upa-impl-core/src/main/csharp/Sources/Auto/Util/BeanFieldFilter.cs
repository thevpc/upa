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
     *
     * @author taha.bensalah@gmail.com
     */
    public class BeanFieldFilter : Net.TheVpc.Upa.Filters.ObjectFilter<System.Reflection.FieldInfo> {

        public static readonly Net.TheVpc.Upa.Impl.Util.BeanFieldFilter INSTANCE = new Net.TheVpc.Upa.Impl.Util.BeanFieldFilter();

        public virtual bool Accept(System.Reflection.FieldInfo s) {
            return !Net.TheVpc.Upa.Impl.Util.PlatformUtils.IsStatic(s);
        }
    }
}
