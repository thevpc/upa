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



namespace Net.Vpc.Upa.Persistence
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public interface FieldPersister {

         void BeforePersist(Net.Vpc.Upa.Document document, Net.Vpc.Upa.Persistence.EntityExecutionContext context) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void AfterPersist(Net.Vpc.Upa.Document document, Net.Vpc.Upa.Persistence.EntityExecutionContext context) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;
    }
}
