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

        private Net.Vpc.Upa.Impl.Util.EntityBeanAdapter nfo;

        private System.Type type;

        private Net.Vpc.Upa.ObjectFactory objectFactory;

        private System.Collections.Generic.IDictionary<string , string> setterToProp = new System.Collections.Generic.Dictionary<string , string>();

        public EntityBeanFactory(Net.Vpc.Upa.Impl.Util.EntityBeanAdapter nfo, System.Type type, Net.Vpc.Upa.ObjectFactory objectFactory) {
            this.nfo = nfo;
            this.type = type;
            this.objectFactory = objectFactory;
            System.Collections.Generic.IList<Net.Vpc.Upa.Field> fields = nfo.GetEntity().GetFields();
            foreach (Net.Vpc.Upa.Field field in fields) {
                setterToProp[Net.Vpc.Upa.Impl.Util.PlatformUtils.SetterName(field.GetName())]=field.GetName();
            }
        }

        public override Net.Vpc.Upa.Record CreateRecord() {
            return objectFactory.CreateObject<Net.Vpc.Upa.Record>(typeof(Net.Vpc.Upa.Record));
        }

        public override  R CreateObject<R>() {
            try {
                return (R) (R)System.Activator.CreateInstance(type);
            } catch (System.Exception e) {
                throw new System.ArgumentException ("IllegalArgumentException", e);
            }
        }

        public override  Net.Vpc.Upa.Record GetRecord<R>(R entity, bool ignoreUnspecified) {
            if (entity is Net.Vpc.Upa.Record) {
                return (Net.Vpc.Upa.Record) entity;
            }
            return new Net.Vpc.Upa.Impl.BeanAdapterRecord(System.Convert.ChangeType(entity,type), nfo, ignoreUnspecified);
        }


        public override  R GetEntity<R>(Net.Vpc.Upa.Record unstructuredRecord) {
            if (unstructuredRecord is Net.Vpc.Upa.Impl.BeanAdapterRecord) {
                Net.Vpc.Upa.Impl.BeanAdapterRecord g = (Net.Vpc.Upa.Impl.BeanAdapterRecord) unstructuredRecord;
                return (R) g.UserObject();
            }
            R obj = CreateObject<R>();
            Net.Vpc.Upa.Record ur = GetRecord<R>(obj, true);
            ur.SetAll(unstructuredRecord);
            return obj;
        }

        public override void SetProperty(object entityObject, string property, object @value) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            nfo.SetProperty<object>(entityObject, property, @value);
        }

        public override object GetProperty(object entityObject, string property) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return nfo.GetProperty<object>(entityObject, property);
        }
    }
}
