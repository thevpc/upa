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
     * @author taha.bensalah@gmail.com
     */
    public interface ScanListener {

         void ContextItemScanned(Net.Vpc.Upa.ScanEvent @event);

         void PersistenceGroupItemScanned(Net.Vpc.Upa.ScanEvent @event);

         void PersistenceUnitItemScanned(Net.Vpc.Upa.ScanEvent @event);
    }
}
