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
     * @creationdate 8/30/12 1:05 AM
     */
    public interface EntityPersistOperation {

         void Insert(Net.Vpc.Upa.Entity entity, Net.Vpc.Upa.Document originalDocument, Net.Vpc.Upa.Document persistentDocument, Net.Vpc.Upa.Persistence.EntityExecutionContext context) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.Query CreateQuery(Net.Vpc.Upa.Entity e, Net.Vpc.Upa.Expressions.Insert query, Net.Vpc.Upa.Persistence.EntityExecutionContext context) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;
    }
}
