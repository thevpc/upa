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
    public interface SectionDefinitionListener : Net.TheVpc.Upa.Callbacks.DefinitionListener {

         void OnPreCreateSection(Net.TheVpc.Upa.Callbacks.SectionEvent @event);

         void OnCreateSection(Net.TheVpc.Upa.Callbacks.SectionEvent @event);

         void OnPreDropSection(Net.TheVpc.Upa.Callbacks.SectionEvent @event);

         void OnDropSection(Net.TheVpc.Upa.Callbacks.SectionEvent @event);

         void OnMoveSection(Net.TheVpc.Upa.Callbacks.SectionEvent @event);

         void OnPreMoveSection(Net.TheVpc.Upa.Callbacks.SectionEvent @event);
    }
}
