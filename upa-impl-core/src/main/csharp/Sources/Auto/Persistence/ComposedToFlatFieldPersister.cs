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



namespace Net.TheVpc.Upa.Impl.Persistence
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public class ComposedToFlatFieldPersister : Net.TheVpc.Upa.Persistence.FieldPersister {

        private Net.TheVpc.Upa.Field field;

        private Net.TheVpc.Upa.EntityBuilder relationshipTargetConverter;

        private System.Collections.Generic.IList<Net.TheVpc.Upa.Field> flatFields;

        public ComposedToFlatFieldPersister(Net.TheVpc.Upa.Field field) {
            this.field = field;
            Net.TheVpc.Upa.Types.ManyToOneType t = (Net.TheVpc.Upa.Types.ManyToOneType) field.GetDataType();
            Net.TheVpc.Upa.Entity master = t.GetRelationship().GetTargetRole().GetEntity();
            Net.TheVpc.Upa.RelationshipRole detailRole = t.GetRelationship().GetSourceRole();
            flatFields = detailRole.GetFields();
            relationshipTargetConverter = master.GetBuilder();
        }

        public virtual void BeforePersist(Net.TheVpc.Upa.Record record, Net.TheVpc.Upa.Persistence.EntityExecutionContext context) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            object o = record.GetObject<T>(field.GetName());
            Net.TheVpc.Upa.Key key = relationshipTargetConverter.ObjectToKey(o);
            if (key == null) {
                foreach (Net.TheVpc.Upa.Field ff in flatFields) {
                    record.SetObject(ff.GetName(), ff.GetUnspecifiedValueDecoded());
                }
            } else {
                int i = 0;
                foreach (Net.TheVpc.Upa.Field ff in flatFields) {
                    record.SetObject(ff.GetName(), key.GetObjectAt(i));
                    i++;
                }
            }
        }

        public virtual void AfterPersist(Net.TheVpc.Upa.Record record, Net.TheVpc.Upa.Persistence.EntityExecutionContext context) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
        }
    }
}
