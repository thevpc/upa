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



namespace Net.Vpc.Upa.Impl.Persistence
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public class ComposedToFlatFieldPersister : Net.Vpc.Upa.Persistence.FieldPersister {

        private Net.Vpc.Upa.Field field;

        private Net.Vpc.Upa.EntityBuilder relationshipTargetConverter;

        private System.Collections.Generic.IList<Net.Vpc.Upa.Field> flatFields;

        public ComposedToFlatFieldPersister(Net.Vpc.Upa.Field field) {
            this.field = field;
            Net.Vpc.Upa.Types.ManyToOneType t = (Net.Vpc.Upa.Types.ManyToOneType) field.GetDataType();
            Net.Vpc.Upa.Entity master = t.GetRelationship().GetTargetRole().GetEntity();
            Net.Vpc.Upa.RelationshipRole detailRole = t.GetRelationship().GetSourceRole();
            flatFields = detailRole.GetFields();
            relationshipTargetConverter = master.GetBuilder();
        }

        public virtual void BeforePersist(Net.Vpc.Upa.Record record, Net.Vpc.Upa.Persistence.EntityExecutionContext context) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            object o = record.GetObject<T>(field.GetName());
            Net.Vpc.Upa.Key key = relationshipTargetConverter.ObjectToKey(o);
            if (key == null) {
                foreach (Net.Vpc.Upa.Field ff in flatFields) {
                    record.SetObject(ff.GetName(), ff.GetUnspecifiedValueDecoded());
                }
            } else {
                int i = 0;
                foreach (Net.Vpc.Upa.Field ff in flatFields) {
                    record.SetObject(ff.GetName(), key.GetObjectAt(i));
                    i++;
                }
            }
        }

        public virtual void AfterPersist(Net.Vpc.Upa.Record record, Net.Vpc.Upa.Persistence.EntityExecutionContext context) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
        }
    }
}
