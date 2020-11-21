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



namespace Net.TheVpc.Upa.Callbacks
{

    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 9/18/12 9:10 PM
     */
    public interface PackageDefinitionListener : Net.TheVpc.Upa.Callbacks.DefinitionListener {

         void OnPreCreatePackage(Net.TheVpc.Upa.Callbacks.PackageEvent @event);

         void OnCreatePackage(Net.TheVpc.Upa.Callbacks.PackageEvent @event);

         void OnPreDropPackage(Net.TheVpc.Upa.Callbacks.PackageEvent @event);

         void OnDropPackage(Net.TheVpc.Upa.Callbacks.PackageEvent @event);

         void OnPreMovePackage(Net.TheVpc.Upa.Callbacks.PackageEvent @event);

         void OnMovePackage(Net.TheVpc.Upa.Callbacks.PackageEvent @event);
    }
}
