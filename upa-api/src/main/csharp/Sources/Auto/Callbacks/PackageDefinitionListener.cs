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



namespace Net.Vpc.Upa.Callbacks
{

    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 9/18/12 9:10 PM
     */
    public interface PackageDefinitionListener : Net.Vpc.Upa.Callbacks.DefinitionListener {

         void OnPreCreatePackage(Net.Vpc.Upa.Callbacks.PackageEvent @event);

         void OnCreatePackage(Net.Vpc.Upa.Callbacks.PackageEvent @event);

         void OnPreDropPackage(Net.Vpc.Upa.Callbacks.PackageEvent @event);

         void OnDropPackage(Net.Vpc.Upa.Callbacks.PackageEvent @event);

         void OnPreMovePackage(Net.Vpc.Upa.Callbacks.PackageEvent @event);

         void OnMovePackage(Net.Vpc.Upa.Callbacks.PackageEvent @event);
    }
}
