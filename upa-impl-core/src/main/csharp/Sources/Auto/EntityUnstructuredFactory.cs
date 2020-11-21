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
    public class EntityUnstructuredFactory : Net.TheVpc.Upa.Impl.AbstractEntityFactory {

        private Net.TheVpc.Upa.Entity entity;

        public EntityUnstructuredFactory(Net.TheVpc.Upa.Entity entity) {
            this.entity = entity;
        }

        public override Net.TheVpc.Upa.Record CreateRecord() {
            return new Net.TheVpc.Upa.Impl.DefaultRecord();
        }

        public override  R CreateObject<R>() {
            //double cast is needed in c#
            return (R) (object) new Net.TheVpc.Upa.Impl.DefaultRecord();
        }

        public override Net.TheVpc.Upa.Record ObjectToRecord(object @object, bool ignoreUnspecified) {
            return (Net.TheVpc.Upa.Record) @object;
        }


        public override  R RecordToObject<R>(Net.TheVpc.Upa.Record record) {
            return (R) record;
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
