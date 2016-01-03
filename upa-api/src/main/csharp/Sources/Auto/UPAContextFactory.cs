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



namespace Net.Vpc.Upa
{


    /**
     *
     * @author vpc
     */
    public interface UPAContextFactory : Net.Vpc.Upa.ObjectFactory {

         Net.Vpc.Upa.Config.ScanSource CreateURLScanSource(string[] urls, Net.Vpc.Upa.Config.ScanFilter[] filters, bool noIgnore);

         Net.Vpc.Upa.Config.ScanSource CreateContextScanSource(bool noIgnore);

         Net.Vpc.Upa.Config.ScanSource CreateClassScanSource(System.Type[] classes, bool noIgnore);
    }
}
