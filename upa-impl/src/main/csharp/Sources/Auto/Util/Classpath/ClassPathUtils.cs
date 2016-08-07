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



namespace Net.Vpc.Upa.Impl.Util.Classpath
{


    /**
     *
     * @author taha.bensalah@gmail.com
     */
    public class ClassPathUtils {

        private static readonly System.Diagnostics.TraceSource log = new System.Diagnostics.TraceSource((typeof(Net.Vpc.Upa.Impl.Util.Classpath.ClassPathUtils)).FullName);

        public static string[] ResolveClassPathLibs() {
            return Net.Vpc.Upa.Impl.Util.Classpath.CommonClassPathUtils.ResolveClassPathLibs("META-INF/upa.xml");
        }
    }
}
