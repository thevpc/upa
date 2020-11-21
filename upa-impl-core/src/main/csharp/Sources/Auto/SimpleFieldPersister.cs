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
    public class SimpleFieldPersister : Net.TheVpc.Upa.Impl.FieldPersister {

        public virtual void PrepareFieldForPersist(Net.TheVpc.Upa.Field field, object @value, Net.TheVpc.Upa.Record userRecord, Net.TheVpc.Upa.Record persistentRecord, Net.TheVpc.Upa.Persistence.EntityExecutionContext executionContext, System.Collections.Generic.ISet<Net.TheVpc.Upa.Field> persistNonNullable, System.Collections.Generic.ISet<Net.TheVpc.Upa.Field> persistWithDefaultValue) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.Expressions.Expression valueExpression = (@value is Net.TheVpc.Upa.Expressions.Expression) ? ((Net.TheVpc.Upa.Expressions.Expression)((Net.TheVpc.Upa.Expressions.Expression) @value)) : new Net.TheVpc.Upa.Expressions.Param(field.GetName(), @value);
            persistentRecord.SetObject(field.GetName(), valueExpression);
        }

        public virtual void PrepareFieldForUpdate(Net.TheVpc.Upa.Field field, object @value, Net.TheVpc.Upa.Record userRecord, Net.TheVpc.Upa.Record persistentRecord, Net.TheVpc.Upa.Persistence.EntityExecutionContext executionContext) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            persistentRecord.SetObject(field.GetName(), @value);
        }
    }
}
