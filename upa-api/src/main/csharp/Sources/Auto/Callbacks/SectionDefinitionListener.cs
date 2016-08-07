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
    public interface SectionDefinitionListener : Net.Vpc.Upa.Callbacks.DefinitionListener {

         void OnPreCreateSection(Net.Vpc.Upa.Callbacks.SectionEvent @event);

         void OnCreateSection(Net.Vpc.Upa.Callbacks.SectionEvent @event);

         void OnPreDropSection(Net.Vpc.Upa.Callbacks.SectionEvent @event);

         void OnDropSection(Net.Vpc.Upa.Callbacks.SectionEvent @event);

         void OnMoveSection(Net.Vpc.Upa.Callbacks.SectionEvent @event);

         void OnPreMoveSection(Net.Vpc.Upa.Callbacks.SectionEvent @event);
    }
}
