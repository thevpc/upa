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
     * @creationdate 11/27/12 8:55 PM
     */
    public interface FieldDefinitionListener : Net.Vpc.Upa.Callbacks.DefinitionListener {

         void OnPreCreateField(Net.Vpc.Upa.Callbacks.FieldEvent @event) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void OnCreateField(Net.Vpc.Upa.Callbacks.FieldEvent @event) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void OnPreDropField(Net.Vpc.Upa.Callbacks.FieldEvent @event) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void OnDropField(Net.Vpc.Upa.Callbacks.FieldEvent @event) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void OnPreMoveField(Net.Vpc.Upa.Callbacks.FieldEvent @event) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void OnMoveField(Net.Vpc.Upa.Callbacks.FieldEvent @event) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;
    }
}
