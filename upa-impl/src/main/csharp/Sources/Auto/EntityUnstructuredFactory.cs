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

        public EntityUnstructuredFactory() {
        }

        public override Net.Vpc.Upa.Record CreateRecord() {
            return new Net.Vpc.Upa.Impl.DefaultRecord();
        }

        public override  R CreateObject<R>() {
            //double cast is needed in c#
            return (R) (object) new Net.Vpc.Upa.Impl.DefaultRecord();
        }

        public override  Net.Vpc.Upa.Record GetRecord<R>(R entity, bool ignoreUnspecified) {
            //double cast is needed in c#
            return (Net.Vpc.Upa.Record) (object) entity;
        }


        public override  R GetEntity<R>(Net.Vpc.Upa.Record unstructuredRecord) {
            return (R) unstructuredRecord;
        }

        public override void SetProperty(object entityObject, string property, object @value) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            ((Net.Vpc.Upa.Record) entityObject).SetObject(property, @value);
        }

        public override object GetProperty(object entityObject, string property) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return ((Net.Vpc.Upa.Record) entityObject).GetObject<object>(property);
        }
    }
}
