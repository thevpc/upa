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
     *
     * @author taha.bensalah@gmail.com
     */
    public interface UPAContextFactory : Net.Vpc.Upa.ObjectFactory {

         Net.Vpc.Upa.Config.ScanSource CreateURLScanSource(string sourceName, string[] urls, Net.Vpc.Upa.Config.ScanFilter[] filters, bool noIgnore);

         Net.Vpc.Upa.Config.ScanSource CreateContextScanSource(string sourceName, bool noIgnore);

         Net.Vpc.Upa.Config.ScanSource CreateClassScanSource(string sourceName, System.Type[] classes, bool noIgnore);
    }
}
