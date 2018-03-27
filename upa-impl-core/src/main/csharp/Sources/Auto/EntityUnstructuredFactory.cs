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
    public class EntityUnstructuredFactory : Net.Vpc.Upa.Impl.AbstractEntityFactory {

        private Net.Vpc.Upa.Entity entity;

        public EntityUnstructuredFactory(Net.Vpc.Upa.Entity entity) {
            this.entity = entity;
        }

        public override Net.Vpc.Upa.Record CreateRecord() {
            return new Net.Vpc.Upa.Impl.DefaultRecord();
        }

        public override  R CreateObject<R>() {
            //double cast is needed in c#
            return (R) (object) new Net.Vpc.Upa.Impl.DefaultRecord();
        }

        public override Net.Vpc.Upa.Record ObjectToRecord(object @object, bool ignoreUnspecified) {
            return (Net.Vpc.Upa.Record) @object;
        }


        public override  R RecordToObject<R>(Net.Vpc.Upa.Record record) {
            return (R) record;
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
