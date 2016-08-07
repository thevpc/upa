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
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public interface UPAObjectListener {

         void ItemRemoved(Net.Vpc.Upa.UPAObject @object, int position, Net.Vpc.Upa.EventPhase eventPhase);

         void ItemMoved(Net.Vpc.Upa.UPAObject @object, int position, int toPosition, Net.Vpc.Upa.EventPhase eventPhase);

         void ItemAdded(Net.Vpc.Upa.UPAObject @object, int position, Net.Vpc.Upa.UPAObject parent, Net.Vpc.Upa.EventPhase eventPhase);
    }
}
