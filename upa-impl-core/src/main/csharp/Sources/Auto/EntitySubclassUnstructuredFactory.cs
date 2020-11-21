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
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 8/27/12 1:51 AM
     */
    public class EntitySubclassUnstructuredFactory : Net.TheVpc.Upa.Impl.AbstractEntityFactory {

        private Net.TheVpc.Upa.Entity entity;

        private System.Type recordType;

        private Net.TheVpc.Upa.ObjectFactory objectFactory;

        public EntitySubclassUnstructuredFactory(System.Type recordType, Net.TheVpc.Upa.ObjectFactory objectFactory, Net.TheVpc.Upa.Entity entity) {
            this.recordType = recordType;
            this.objectFactory = objectFactory;
            this.entity = entity;
        }

        public override Net.TheVpc.Upa.Record CreateRecord() {
            return (Net.TheVpc.Upa.Record) objectFactory.CreateObject<object>(recordType);
        }

        public override  R CreateObject<R>() {
            return (R) CreateRecord();
        }

        public override Net.TheVpc.Upa.Record ObjectToRecord(object @object, bool ignoreUnspecified) {
            return (Net.TheVpc.Upa.Record) @object;
        }


        public override  R RecordToObject<R>(Net.TheVpc.Upa.Record record) {
            if (recordType.IsInstanceOfType(record)) {
                return (R) record;
            } else {
                object ur = CreateRecord();
                ((Net.TheVpc.Upa.Record) ur).SetAll(record);
                return (R) ur;
            }
        }

        public override void SetProperty(object @object, string property, object @value) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            ((Net.TheVpc.Upa.Record) @object).SetObject(property, @value);
        }

        public override object GetProperty(object @object, string property) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return ((Net.TheVpc.Upa.Record) @object).GetObject<T>(property);
        }


        protected internal override Net.TheVpc.Upa.Entity GetEntity() {
            return entity;
        }
    }
}
