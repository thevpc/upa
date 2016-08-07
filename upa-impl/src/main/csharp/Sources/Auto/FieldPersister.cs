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
     *
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public interface FieldPersister {

         void PrepareFieldForPersist(Net.Vpc.Upa.Field field, object @value, Net.Vpc.Upa.Record userRecord, Net.Vpc.Upa.Record persistentRecord, Net.Vpc.Upa.Persistence.EntityExecutionContext executionContext, System.Collections.Generic.ISet<Net.Vpc.Upa.Field> persistNonNullable, System.Collections.Generic.ISet<Net.Vpc.Upa.Field> persistWithDefaultValue) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void PrepareFieldForUpdate(Net.Vpc.Upa.Field field, object @value, Net.Vpc.Upa.Record userRecord, Net.Vpc.Upa.Record persistentRecord, Net.Vpc.Upa.Persistence.EntityExecutionContext executionContext) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;
    }
}
