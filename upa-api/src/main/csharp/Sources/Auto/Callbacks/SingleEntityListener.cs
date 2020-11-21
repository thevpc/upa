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
     * @creationdate 9/10/12 12:38 AM
     */
    public interface SingleEntityListener : Net.TheVpc.Upa.Callbacks.EntityInterceptor {

         void BeforePersist(Net.TheVpc.Upa.Callbacks.EntityTriggerContext context, object id, Net.TheVpc.Upa.Document document) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         void AfterPersist(Net.TheVpc.Upa.Callbacks.EntityTriggerContext context, object id, Net.TheVpc.Upa.Document document) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         void BeforeUpdate(Net.TheVpc.Upa.Callbacks.EntityTriggerContext context, object id, Net.TheVpc.Upa.Document document) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         void AfterUpdate(Net.TheVpc.Upa.Callbacks.EntityTriggerContext context, object id, Net.TheVpc.Upa.Document document) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         void BeforeDelete(Net.TheVpc.Upa.Callbacks.EntityTriggerContext context, object id) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         void AfterDelete(Net.TheVpc.Upa.Callbacks.EntityTriggerContext context, object id) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         void BeforeUpdateFormulas(Net.TheVpc.Upa.Callbacks.EntityTriggerContext context, object id, Net.TheVpc.Upa.Document document) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         void AfterUpdateFormulas(Net.TheVpc.Upa.Callbacks.EntityTriggerContext context, object id, Net.TheVpc.Upa.Document document) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;
    }
}
