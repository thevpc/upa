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



namespace Net.TheVpc.Upa
{


    /**
     *
     * @author taha.bensalah@gmail.com
     */
    public interface UPAContextFactory : Net.TheVpc.Upa.ObjectFactory {

         Net.TheVpc.Upa.Config.ScanSource CreateURLScanSource(string sourceName, string[] urls, Net.TheVpc.Upa.Config.ScanFilter[] filters, bool noIgnore);

         Net.TheVpc.Upa.Config.ScanSource CreateContextScanSource(string sourceName, bool noIgnore);

         Net.TheVpc.Upa.Config.ScanSource CreateClassScanSource(string sourceName, System.Type[] classes, bool noIgnore);
    }
}
