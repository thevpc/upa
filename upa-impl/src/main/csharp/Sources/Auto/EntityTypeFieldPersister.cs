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
    public class EntityTypeFieldPersister : Net.Vpc.Upa.Impl.FieldPersister {

        public virtual void PrepareFieldForInsert(Net.Vpc.Upa.Field field, object @value, Net.Vpc.Upa.Record userRecord, Net.Vpc.Upa.Record persistentRecord, Net.Vpc.Upa.Persistence.EntityExecutionContext executionContext, System.Collections.Generic.ISet<Net.Vpc.Upa.Field> insertNonNullable, System.Collections.Generic.ISet<Net.Vpc.Upa.Field> insertWithDefaultValue) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Types.EntityType e = (Net.Vpc.Upa.Types.EntityType) field.GetDataType();
            if (e.IsUpdatable()) {
                Net.Vpc.Upa.Entity masterEntity = executionContext.GetPersistenceUnit().GetEntity(e.GetReferencedEntityName());
                Net.Vpc.Upa.Key k = null;
                if (@value is Net.Vpc.Upa.Record) {
                    k = masterEntity.GetBuilder().RecordToKey((Net.Vpc.Upa.Record) @value);
                } else {
                    k = masterEntity.GetBuilder().EntityToKey(@value);
                }
                int x = 0;
                foreach (Net.Vpc.Upa.Field fk in e.GetRelationship().GetSourceRole().GetFields()) {
                    insertNonNullable.Remove(fk);
                    insertWithDefaultValue.Remove(fk);
                    persistentRecord.SetObject(fk.GetName(), k == null ? null : k.GetObjectAt(x));
                    x++;
                }
            }
        }

        public virtual void PrepareFieldForUpdate(Net.Vpc.Upa.Field field, object @value, Net.Vpc.Upa.Record userRecord, Net.Vpc.Upa.Record persistentRecord, Net.Vpc.Upa.Persistence.EntityExecutionContext executionContext) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            persistentRecord.SetObject(field.GetName(), @value);
        }
    }
}
