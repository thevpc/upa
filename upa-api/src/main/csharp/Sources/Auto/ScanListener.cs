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
    public interface ScanListener {

         void ContextItemScanned(Net.TheVpc.Upa.ScanEvent @event);

         void PersistenceGroupItemScanned(Net.TheVpc.Upa.ScanEvent @event);

         void PersistenceUnitItemScanned(Net.TheVpc.Upa.ScanEvent @event);
    }
}
