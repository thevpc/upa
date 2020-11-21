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



namespace Net.TheVpc.Upa.Impl
{


    /**
     *
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public interface FieldPersister {

         void PrepareFieldForPersist(Net.TheVpc.Upa.Field field, object @value, Net.TheVpc.Upa.Record userRecord, Net.TheVpc.Upa.Record persistentRecord, Net.TheVpc.Upa.Persistence.EntityExecutionContext executionContext, System.Collections.Generic.ISet<Net.TheVpc.Upa.Field> persistNonNullable, System.Collections.Generic.ISet<Net.TheVpc.Upa.Field> persistWithDefaultValue) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         void PrepareFieldForUpdate(Net.TheVpc.Upa.Field field, object @value, Net.TheVpc.Upa.Record userRecord, Net.TheVpc.Upa.Record persistentRecord, Net.TheVpc.Upa.Persistence.EntityExecutionContext executionContext) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;
    }
}
