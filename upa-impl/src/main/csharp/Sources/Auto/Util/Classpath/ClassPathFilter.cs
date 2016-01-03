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
     * @author vpc
     */
    public interface ClassPathFilter {

         bool AcceptLibrary(string url);

         bool AcceptClassName(string url, string className);

         bool AcceptClass(string url, string className, System.Type type);
    }
}
