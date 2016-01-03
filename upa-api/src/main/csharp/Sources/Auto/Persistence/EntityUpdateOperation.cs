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



namespace Net.Vpc.Upa.Persistence
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 8/30/12 1:05 AM
     */
    public interface EntityUpdateOperation {

         int Update(Net.Vpc.Upa.Entity entity, Net.Vpc.Upa.Persistence.EntityExecutionContext context, Net.Vpc.Upa.Record updates, Net.Vpc.Upa.Expressions.Expression condition) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.Query CreateQuery(Net.Vpc.Upa.Entity e, Net.Vpc.Upa.Expressions.Update query, Net.Vpc.Upa.Persistence.EntityExecutionContext context) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;
    }
}
