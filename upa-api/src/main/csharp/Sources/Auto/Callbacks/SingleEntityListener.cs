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
     * @creationdate 9/10/12 12:38 AM
     */
    public interface SingleEntityListener : Net.Vpc.Upa.Callbacks.EntityInterceptor {

         void BeforePersist(Net.Vpc.Upa.Callbacks.EntityTriggerContext context, object id, Net.Vpc.Upa.Record record) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void AfterPersist(Net.Vpc.Upa.Callbacks.EntityTriggerContext context, object id, Net.Vpc.Upa.Record record) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void BeforeUpdate(Net.Vpc.Upa.Callbacks.EntityTriggerContext context, object id, Net.Vpc.Upa.Record record) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void AfterUpdate(Net.Vpc.Upa.Callbacks.EntityTriggerContext context, object id, Net.Vpc.Upa.Record record) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void BeforeDelete(Net.Vpc.Upa.Callbacks.EntityTriggerContext context, object id) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void AfterDelete(Net.Vpc.Upa.Callbacks.EntityTriggerContext context, object id) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void BeforeUpdateFormulas(Net.Vpc.Upa.Callbacks.EntityTriggerContext context, object id, Net.Vpc.Upa.Record record) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void AfterUpdateFormulas(Net.Vpc.Upa.Callbacks.EntityTriggerContext context, object id, Net.Vpc.Upa.Record record) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;
    }
}
