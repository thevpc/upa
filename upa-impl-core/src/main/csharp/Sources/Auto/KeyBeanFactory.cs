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



using System.Linq;
namespace Net.TheVpc.Upa.Impl
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 8/27/12 1:51 AM
     */
    public class KeyBeanFactory : Net.TheVpc.Upa.Impl.KeyFactory {

        private bool isEntityKey;

        private Net.TheVpc.Upa.BeanType bnfo;

        private System.Type idType;

        private string[] fieldNames;

        private Net.TheVpc.Upa.Entity entity;

        private Net.TheVpc.Upa.Entity idEntity;

        public KeyBeanFactory(System.Type keyType, Net.TheVpc.Upa.Entity entity) {
            this.idType = keyType;
            this.entity = entity;
        }

        private bool Build() {
            if (this.fieldNames == null) {
                idEntity = entity.GetPersistenceUnit().FindEntity(idType);
                if (idEntity != null) {
                    isEntityKey = true;
                    System.Collections.Generic.IList<string> fn = new System.Collections.Generic.List<string>();
                    //                for (Field primaryField : entity.getPrimaryFields()) {
                    //                    fn.add(primaryField.getName());
                    //                }
                    this.fieldNames = fn.ToArray();
                } else {
                    bnfo = Net.TheVpc.Upa.Impl.Util.PlatformBeanTypeRepository.GetInstance().GetBeanType(idType);
                    System.Collections.Generic.ISet<string> fn = bnfo.GetPropertyNames();
                    this.fieldNames = fn.ToArray();
                }
            }
            return isEntityKey;
        }

        public virtual System.Type GetIdType() {
            return idType;
        }


        public virtual Net.TheVpc.Upa.Key CreateKey(params object [] keyValues) {
            if (keyValues == null) {
                return null;
            }
            return new Net.TheVpc.Upa.Impl.DefaultKey(keyValues);
        }


        public virtual object CreateId(params object [] keyValues) {
            if (keyValues == null) {
                return null;
            }
            if (Build()) {
                //            Object o = idEntity.getBuilder().createObject();
                //            EntityBuilder f = idEntity.getBuilder();
                //            for (int i = 0; i < keyValues.length; i++) {
                //                f.setProperty(o, fieldNames[i], keyValues[i]);
                //            }
                return keyValues[0];
            } else {
                object o = bnfo.NewInstance();
                for (int i = 0; i < keyValues.Length; i++) {
                    bnfo.SetProperty(o, fieldNames[i], keyValues[i]);
                }
                return o;
            }
        }


        public virtual object GetId(Net.TheVpc.Upa.Key unstructuredKey) {
            if (unstructuredKey == null) {
                return null;
            }
            return CreateId(unstructuredKey.GetValue());
        }


        public virtual Net.TheVpc.Upa.Key GetKey(object id) {
            if (id == null) {
                return null;
            }
            if (Build()) {
                //            Object[] value = new Object[fieldNames.length];
                //            EntityBuilder entityFactory = idEntity.getBuilder();
                //            for (int i = 0; i < value.length; i++) {
                //                value[i] = entityFactory.getProperty(key, fieldNames[i]);
                //            }
                if (!idType.IsInstanceOfType(id)) {
                    Net.TheVpc.Upa.Entity ee = entity.GetPersistenceUnit().FindEntity(idType);
                    if (ee != null) {
                        //check assume this is the id of the entity ee
                        id = ee.GetBuilder().IdToObject<R>(id);
                    }
                }
                return CreateKey(new object[] { id });
            } else {
                object[] @value = new object[fieldNames.Length];
                for (int i = 0; i < @value.Length; i++) {
                    @value[i] = bnfo.GetProperty(id, fieldNames[i]);
                }
                return CreateKey(@value);
            }
        }
    }
}
