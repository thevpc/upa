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
     * @creationdate 11/27/12 9:11 PM
     */
    public interface RelationshipDefinitionListener {

         void OnPreCreateRelationship(Net.TheVpc.Upa.Callbacks.RelationshipEvent @event);

         void OnCreateRelationship(Net.TheVpc.Upa.Callbacks.RelationshipEvent @event);

         void OnPreDropRelationship(Net.TheVpc.Upa.Callbacks.RelationshipEvent @event);

         void OnDropRelationship(Net.TheVpc.Upa.Callbacks.RelationshipEvent @event);
    }
}
