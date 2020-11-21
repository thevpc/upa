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
     * @creationdate 11/27/12 9:17 PM
     */
    public interface IndexDefinitionListener : Net.TheVpc.Upa.Callbacks.DefinitionListener {

         void OnCreateIndex(Net.TheVpc.Upa.Callbacks.IndexEvent @event);

         void OnPreCreateIndex(Net.TheVpc.Upa.Callbacks.IndexEvent @event);

         void OnDropIndex(Net.TheVpc.Upa.Callbacks.IndexEvent @event);

         void OnPreDropIndex(Net.TheVpc.Upa.Callbacks.IndexEvent @event);
    }
}
