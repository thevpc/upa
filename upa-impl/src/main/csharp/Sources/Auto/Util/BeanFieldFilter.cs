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
    public class BeanFieldFilter : Net.Vpc.Upa.Filters.ObjectFilter<System.Reflection.FieldInfo> {

        public static readonly Net.Vpc.Upa.Impl.Util.BeanFieldFilter INSTANCE = new Net.Vpc.Upa.Impl.Util.BeanFieldFilter();

        public virtual bool Accept(System.Reflection.FieldInfo s) {
            return !Net.Vpc.Upa.Impl.Util.PlatformUtils.IsStatic(s);
        }
    }
}
