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
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 8/27/12 1:51 AM
     */
    public class EntitySubclassUnstructuredFactory : Net.Vpc.Upa.Impl.AbstractEntityFactory {

        private Net.Vpc.Upa.Entity entity;

        private System.Type recordType;

        private Net.Vpc.Upa.ObjectFactory objectFactory;

        public EntitySubclassUnstructuredFactory(System.Type recordType, Net.Vpc.Upa.ObjectFactory objectFactory, Net.Vpc.Upa.Entity entity) {
            this.recordType = recordType;
            this.objectFactory = objectFactory;
            this.entity = entity;
        }

        public override Net.Vpc.Upa.Record CreateRecord() {
            return (Net.Vpc.Upa.Record) objectFactory.CreateObject<object>(recordType);
        }

        public override  R CreateObject<R>() {
            return (R) CreateRecord();
        }

        public override Net.Vpc.Upa.Record ObjectToRecord(object @object, bool ignoreUnspecified) {
            return (Net.Vpc.Upa.Record) @object;
        }


        public override  R RecordToObject<R>(Net.Vpc.Upa.Record record) {
            if (recordType.IsInstanceOfType(record)) {
                return (R) record;
            } else {
                object ur = CreateRecord();
                ((Net.Vpc.Upa.Record) ur).SetAll(record);
                return (R) ur;
            }
        }

        public override void SetProperty(object @object, string property, object @value) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            ((Net.Vpc.Upa.Record) @object).SetObject(property, @value);
        }

        public override object GetProperty(object @object, string property) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return ((Net.Vpc.Upa.Record) @object).GetObject<T>(property);
        }


        protected internal override Net.Vpc.Upa.Entity GetEntity() {
            return entity;
        }
    }
}
