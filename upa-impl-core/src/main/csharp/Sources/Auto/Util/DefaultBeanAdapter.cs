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



namespace Net.TheVpc.Upa.Impl.Util
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 8/27/12 12:16 AM
     */
    public class DefaultBeanAdapter : Net.TheVpc.Upa.BeanAdapter {

        private Net.TheVpc.Upa.BeanType beanType;

        private object instance;

        public DefaultBeanAdapter(object obj)  : this(obj.GetType()){

            this.instance = obj;
        }

        public DefaultBeanAdapter(System.Type cls) {
            this.beanType = Net.TheVpc.Upa.Impl.Util.PlatformBeanTypeRepository.GetInstance().GetBeanType(cls);
        }

        public virtual object NewInstance() {
            return beanType.NewInstance();
        }


        public virtual Net.TheVpc.Upa.BeanType GetBeanType() {
            return beanType;
        }

        public virtual bool ContainsProperty(string property) {
            return beanType.ContainsProperty(property);
        }

        public virtual object GetProperty(string field) {
            return beanType.GetProperty(instance, field);
        }

        public virtual void InjectNull(string property) {
            beanType.Inject(instance, property, (object) null);
        }

        public virtual void SetProperty(string property, object @value) {
            beanType.Inject(instance, property, @value);
        }

        public virtual void Inject(string property, object @value) {
            beanType.Inject(instance, property, @value);
        }
    }
}
