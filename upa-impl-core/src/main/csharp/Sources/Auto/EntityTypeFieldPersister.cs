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

        public virtual void PrepareFieldForPersist(Net.Vpc.Upa.Field field, object @value, Net.Vpc.Upa.Record userRecord, Net.Vpc.Upa.Record persistentRecord, Net.Vpc.Upa.Persistence.EntityExecutionContext executionContext, System.Collections.Generic.ISet<Net.Vpc.Upa.Field> persistNonNullable, System.Collections.Generic.ISet<Net.Vpc.Upa.Field> persistWithDefaultValue) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Types.ManyToOneType e = (Net.Vpc.Upa.Types.ManyToOneType) field.GetDataType();
            if (e.IsUpdatable()) {
                Net.Vpc.Upa.Entity masterEntity = executionContext.GetPersistenceUnit().GetEntity(e.GetTargetEntityName());
                Net.Vpc.Upa.Key k = null;
                if (@value is Net.Vpc.Upa.Record) {
                    k = masterEntity.GetBuilder().RecordToKey((Net.Vpc.Upa.Record) @value);
                } else {
                    k = masterEntity.GetBuilder().ObjectToKey(@value);
                }
                int x = 0;
                foreach (Net.Vpc.Upa.Field fk in e.GetRelationship().GetSourceRole().GetFields()) {
                    persistNonNullable.Remove(fk);
                    persistWithDefaultValue.Remove(fk);
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
