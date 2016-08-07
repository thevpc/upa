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
    public class EntityBeanFactory : Net.Vpc.Upa.Impl.AbstractEntityFactory {

        private readonly Net.Vpc.Upa.BeanType nfo;

        private readonly Net.Vpc.Upa.Entity entity;

        private readonly Net.Vpc.Upa.ObjectFactory objectFactory;

        public EntityBeanFactory(Net.Vpc.Upa.Entity entity, Net.Vpc.Upa.ObjectFactory objectFactory) {
            this.entity = entity;
            this.nfo = entity.GetBeanType();
            this.objectFactory = objectFactory;
            System.Collections.Generic.IList<Net.Vpc.Upa.Field> fields = entity.GetFields();
        }


        public override Net.Vpc.Upa.Record CreateRecord() {
            return objectFactory.CreateObject<Net.Vpc.Upa.Record>(typeof(Net.Vpc.Upa.Record));
        }


        public override  R CreateObject<R>() {
            try {
                return (R) entity.GetBeanType().NewInstance();
            } catch (System.Exception e) {
                throw new System.ArgumentException ("IllegalArgumentException", e);
            }
        }


        public override Net.Vpc.Upa.Record ObjectToRecord(object @object, bool ignoreUnspecified) {
            if (@object is Net.Vpc.Upa.Record) {
                return (Net.Vpc.Upa.Record) @object;
            }
            return new Net.Vpc.Upa.Impl.BeanAdapterRecord(System.Convert.ChangeType(@object,entity.GetBeanType().GetPlatformType()), entity.GetName(), nfo, ignoreUnspecified);
        }


        public override  R RecordToObject<R>(Net.Vpc.Upa.Record record) {
            if (record is Net.Vpc.Upa.Impl.BeanAdapterRecord) {
                Net.Vpc.Upa.Impl.BeanAdapterRecord g = (Net.Vpc.Upa.Impl.BeanAdapterRecord) record;
                return (R) g.UserObject();
            }
            object obj = CreateObject<R>();
            Net.Vpc.Upa.Record ur = ObjectToRecord(obj, true);
            foreach (string k in record.KeySet()) {
                object o = record.GetObject<T>(k);
                if (o is Net.Vpc.Upa.Record) {
                    Net.Vpc.Upa.Field f = entity.FindField(k);
                    Net.Vpc.Upa.Types.DataType dt = f.GetDataType();
                    if (dt is Net.Vpc.Upa.Types.ManyToOneType) {
                        Net.Vpc.Upa.Entity oe = ((Net.Vpc.Upa.Types.ManyToOneType) dt).GetRelationship().GetTargetEntity();
                        o = oe.GetBuilder().RecordToObject<R>((Net.Vpc.Upa.Record) o);
                    }
                }
                ur.SetObject(k, o);
            }
            //        ur.setAll(unstructuredRecord);
            return (R) obj;
        }


        public override void SetProperty(object @object, string property, object @value) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (@object is Net.Vpc.Upa.Record) {
                ((Net.Vpc.Upa.Record) @object).SetObject(property, @value);
            } else {
                nfo.SetProperty(@object, property, @value);
            }
        }


        public override object GetProperty(object @object, string property) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (@object is Net.Vpc.Upa.Record) {
                return ((Net.Vpc.Upa.Record) @object).GetObject<T>(property);
            }
            return nfo.GetProperty(@object, property);
        }


        protected internal override Net.Vpc.Upa.Entity GetEntity() {
            return entity;
        }
    }
}
