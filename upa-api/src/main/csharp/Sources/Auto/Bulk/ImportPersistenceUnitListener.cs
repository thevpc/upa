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



namespace Net.Vpc.Upa.Bulk
{

    /**
     *
     * @author taha.bensalah@gmail.com
     */
    public interface ImportPersistenceUnitListener {

         void ObjectPersisted(string entityName, object source, object target);

         void ObjectMerged(string entityName, object source, object target);

         void ObjectPersistFailed(string entityName, object source, object target, System.Exception error) /* throws System.Exception */ ;

         void ObjectMergeFailed(string entityName, object source, object target, System.Exception error) /* throws System.Exception */ ;
    }
}
