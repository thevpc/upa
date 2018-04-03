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



namespace Net.Vpc.Upa.Callbacks
{

    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 11/27/12 9:11 PM
     */
    public interface RelationshipDefinitionListener {

         void OnPreCreateRelationship(Net.Vpc.Upa.Callbacks.RelationshipEvent @event);

         void OnCreateRelationship(Net.Vpc.Upa.Callbacks.RelationshipEvent @event);

         void OnPreDropRelationship(Net.Vpc.Upa.Callbacks.RelationshipEvent @event);

         void OnDropRelationship(Net.Vpc.Upa.Callbacks.RelationshipEvent @event);
    }
}
