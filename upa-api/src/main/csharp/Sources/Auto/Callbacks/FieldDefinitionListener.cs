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
     * @creationdate 11/27/12 8:55 PM
     */
    public interface FieldDefinitionListener : Net.TheVpc.Upa.Callbacks.DefinitionListener {

         void OnPreCreateField(Net.TheVpc.Upa.Callbacks.FieldEvent @event) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         void OnCreateField(Net.TheVpc.Upa.Callbacks.FieldEvent @event) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         void OnPreDropField(Net.TheVpc.Upa.Callbacks.FieldEvent @event) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         void OnDropField(Net.TheVpc.Upa.Callbacks.FieldEvent @event) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         void OnPreMoveField(Net.TheVpc.Upa.Callbacks.FieldEvent @event) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         void OnMoveField(Net.TheVpc.Upa.Callbacks.FieldEvent @event) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;
    }
}
