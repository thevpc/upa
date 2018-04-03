/*********************************************************
 *********************************************************
 **   DO NOT EDIT                                       **
 **                                                     **
 **   THIS FILE HAS BEEN GENERATED AUTOMATICALLY         **
 **   BY UPA PORTABLE GENERATOR                         **
 **   (c) vpc                                           **
 **                                                     **
 *********************************************************
 ********************************************************/



namespace Net.Vpc.Upa
{


    /**
     * Lazy holder for ObjectFactory creation. ObjectFactory is created according to
     * the following procedure :
     * <ul>
     * <li>Look for System.getProperty("net.vpc.upa.ObjectFactory") and create root
     * Factory, If not Found look for net.vpc.upa.RootObjectFactory</li>
     * <li>Look for ServiceLoader.load(ObjectFactory.class) to find for extension
     * Factories</li>
     * <li>Sort extensions instances according to their
     * "getContextSupportLevel()"</li>
     * <li>Chain Factories (Each one becomes the father of the previous) and define
     * user Factory as leaf one (with min contextSupportLevel)</li>
     * <li>Bind root factory (as parent) to the very ancestor of the Factories
     * Chain</li>
     * </ul>
     *
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 1/2/13 12:53 PM
     */

    internal partial class BootstrapObjectFactoryLazyHolder {

        internal static Net.Vpc.Upa.ObjectFactory INSTANCE = Create();


    }
}
