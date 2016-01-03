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



namespace Net.Vpc.Upa.Impl
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 8/27/12 1:51 AM
     */
    public interface EntityFactory {

         Net.Vpc.Upa.Record CreateRecord();

          R CreateObject<R>();

          Net.Vpc.Upa.Record GetRecord<R>(R entity);

          Net.Vpc.Upa.Record GetRecord<R>(R entity, bool ignoreUnspecified);

          R GetEntity<R>(Net.Vpc.Upa.Record unstructuredRecord);

         void SetProperty(object entityObject, string property, object @value) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         object GetProperty(object entityObject, string property) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;
    }
}
