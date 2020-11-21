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
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public interface UPAObjectListener {

         void ItemRemoved(Net.TheVpc.Upa.UPAObject @object, int position, Net.TheVpc.Upa.EventPhase eventPhase);

         void ItemMoved(Net.TheVpc.Upa.UPAObject @object, int position, int toPosition, Net.TheVpc.Upa.EventPhase eventPhase);

         void ItemAdded(Net.TheVpc.Upa.UPAObject @object, int position, Net.TheVpc.Upa.UPAObject parent, Net.TheVpc.Upa.EventPhase eventPhase);
    }
}
