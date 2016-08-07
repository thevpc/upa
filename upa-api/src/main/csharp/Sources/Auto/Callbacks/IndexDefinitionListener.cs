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
     * @creationdate 11/27/12 9:17 PM
     */
    public interface IndexDefinitionListener : Net.Vpc.Upa.Callbacks.DefinitionListener {

         void OnCreateIndex(Net.Vpc.Upa.Callbacks.IndexEvent @event);

         void OnPreCreateIndex(Net.Vpc.Upa.Callbacks.IndexEvent @event);

         void OnDropIndex(Net.Vpc.Upa.Callbacks.IndexEvent @event);

         void OnPreDropIndex(Net.Vpc.Upa.Callbacks.IndexEvent @event);
    }
}
