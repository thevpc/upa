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

        private System.Type recordType;

        private Net.Vpc.Upa.ObjectFactory objectFactory;

        public EntitySubclassUnstructuredFactory(System.Type recordType, Net.Vpc.Upa.ObjectFactory objectFactory) {
            this.recordType = recordType;
            this.objectFactory = objectFactory;
        }

        public override Net.Vpc.Upa.Record CreateRecord() {
            return (Net.Vpc.Upa.Record) objectFactory.CreateObject<Net.Vpc.Upa.Record>(recordType);
        }

        public override  R CreateObject<R>() {
            return (R) CreateRecord();
        }

        public override  Net.Vpc.Upa.Record GetRecord<R>(R entity, bool ignoreUnspecified) {
            return (Net.Vpc.Upa.Record) entity;
        }


        public override  R GetEntity<R>(Net.Vpc.Upa.Record unstructuredRecord) {
            if (recordType.IsInstanceOfType(unstructuredRecord)) {
                return (R) unstructuredRecord;
            } else {
                R ur = (R) CreateRecord();
                ((Net.Vpc.Upa.Record) ur).SetAll(unstructuredRecord);
                return ur;
            }
        }

        public override void SetProperty(object entityObject, string property, object @value) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            ((Net.Vpc.Upa.Record) entityObject).SetObject(property, @value);
        }

        public override object GetProperty(object entityObject, string property) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return ((Net.Vpc.Upa.Record) entityObject).GetObject<object>(property);
        }
    }
}
