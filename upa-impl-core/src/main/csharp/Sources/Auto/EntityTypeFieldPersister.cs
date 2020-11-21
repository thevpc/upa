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
    public class EntityTypeFieldPersister : Net.TheVpc.Upa.Impl.FieldPersister {

        public virtual void PrepareFieldForPersist(Net.TheVpc.Upa.Field field, object @value, Net.TheVpc.Upa.Record userRecord, Net.TheVpc.Upa.Record persistentRecord, Net.TheVpc.Upa.Persistence.EntityExecutionContext executionContext, System.Collections.Generic.ISet<Net.TheVpc.Upa.Field> persistNonNullable, System.Collections.Generic.ISet<Net.TheVpc.Upa.Field> persistWithDefaultValue) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.Types.ManyToOneType e = (Net.TheVpc.Upa.Types.ManyToOneType) field.GetDataType();
            if (e.IsUpdatable()) {
                Net.TheVpc.Upa.Entity masterEntity = executionContext.GetPersistenceUnit().GetEntity(e.GetTargetEntityName());
                Net.TheVpc.Upa.Key k = null;
                if (@value is Net.TheVpc.Upa.Record) {
                    k = masterEntity.GetBuilder().RecordToKey((Net.TheVpc.Upa.Record) @value);
                } else {
                    k = masterEntity.GetBuilder().ObjectToKey(@value);
                }
                int x = 0;
                foreach (Net.TheVpc.Upa.Field fk in e.GetRelationship().GetSourceRole().GetFields()) {
                    persistNonNullable.Remove(fk);
                    persistWithDefaultValue.Remove(fk);
                    persistentRecord.SetObject(fk.GetName(), k == null ? null : k.GetObjectAt(x));
                    x++;
                }
            }
        }

        public virtual void PrepareFieldForUpdate(Net.TheVpc.Upa.Field field, object @value, Net.TheVpc.Upa.Record userRecord, Net.TheVpc.Upa.Record persistentRecord, Net.TheVpc.Upa.Persistence.EntityExecutionContext executionContext) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            persistentRecord.SetObject(field.GetName(), @value);
        }
    }
}
