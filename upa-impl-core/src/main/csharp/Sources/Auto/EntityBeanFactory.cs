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
    public class EntityBeanFactory : Net.TheVpc.Upa.Impl.AbstractEntityFactory {

        private readonly Net.TheVpc.Upa.BeanType nfo;

        private readonly Net.TheVpc.Upa.Entity entity;

        private readonly Net.TheVpc.Upa.ObjectFactory objectFactory;

        public EntityBeanFactory(Net.TheVpc.Upa.Entity entity, Net.TheVpc.Upa.ObjectFactory objectFactory) {
            this.entity = entity;
            this.nfo = entity.GetBeanType();
            this.objectFactory = objectFactory;
            System.Collections.Generic.IList<Net.TheVpc.Upa.Field> fields = entity.GetFields();
        }


        public override Net.TheVpc.Upa.Record CreateRecord() {
            return objectFactory.CreateObject<Net.TheVpc.Upa.Record>(typeof(Net.TheVpc.Upa.Record));
        }


        public override  R CreateObject<R>() {
            try {
                return (R) entity.GetBeanType().NewInstance();
            } catch (System.Exception e) {
                throw new System.ArgumentException ("IllegalArgumentException", e);
            }
        }


        public override Net.TheVpc.Upa.Record ObjectToRecord(object @object, bool ignoreUnspecified) {
            if (@object is Net.TheVpc.Upa.Record) {
                return (Net.TheVpc.Upa.Record) @object;
            }
            return new Net.TheVpc.Upa.Impl.BeanAdapterRecord(System.Convert.ChangeType(@object,entity.GetBeanType().GetPlatformType()), entity.GetName(), nfo, ignoreUnspecified);
        }


        public override  R RecordToObject<R>(Net.TheVpc.Upa.Record record) {
            if (record is Net.TheVpc.Upa.Impl.BeanAdapterRecord) {
                Net.TheVpc.Upa.Impl.BeanAdapterRecord g = (Net.TheVpc.Upa.Impl.BeanAdapterRecord) record;
                return (R) g.UserObject();
            }
            object obj = CreateObject<R>();
            Net.TheVpc.Upa.Record ur = ObjectToRecord(obj, true);
            foreach (string k in record.KeySet()) {
                object o = record.GetObject<T>(k);
                if (o is Net.TheVpc.Upa.Record) {
                    Net.TheVpc.Upa.Field f = entity.FindField(k);
                    Net.TheVpc.Upa.Types.DataType dt = f.GetDataType();
                    if (dt is Net.TheVpc.Upa.Types.ManyToOneType) {
                        Net.TheVpc.Upa.Entity oe = ((Net.TheVpc.Upa.Types.ManyToOneType) dt).GetRelationship().GetTargetEntity();
                        o = oe.GetBuilder().RecordToObject<R>((Net.TheVpc.Upa.Record) o);
                    }
                }
                ur.SetObject(k, o);
            }
            //        ur.setAll(unstructuredRecord);
            return (R) obj;
        }


        public override void SetProperty(object @object, string property, object @value) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            if (@object is Net.TheVpc.Upa.Record) {
                ((Net.TheVpc.Upa.Record) @object).SetObject(property, @value);
            } else {
                nfo.SetProperty(@object, property, @value);
            }
        }


        public override object GetProperty(object @object, string property) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            if (@object is Net.TheVpc.Upa.Record) {
                return ((Net.TheVpc.Upa.Record) @object).GetObject<T>(property);
            }
            return nfo.GetProperty(@object, property);
        }


        protected internal override Net.TheVpc.Upa.Entity GetEntity() {
            return entity;
        }
    }
}
