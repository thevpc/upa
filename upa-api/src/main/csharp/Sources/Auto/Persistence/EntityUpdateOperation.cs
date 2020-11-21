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



namespace Net.TheVpc.Upa.Persistence
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 8/30/12 1:05 AM
     */
    public interface EntityUpdateOperation {

         int Update(Net.TheVpc.Upa.Entity entity, Net.TheVpc.Upa.Persistence.EntityExecutionContext context, Net.TheVpc.Upa.Document updates, Net.TheVpc.Upa.Expressions.Expression condition) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         Net.TheVpc.Upa.Query CreateQuery(Net.TheVpc.Upa.Entity e, Net.TheVpc.Upa.Expressions.Update query, Net.TheVpc.Upa.Persistence.EntityExecutionContext context) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;
    }
}
