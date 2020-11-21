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



namespace Net.TheVpc.Upa.Impl.Context
{


    /**
     *
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public class DefaultSessionContext : Net.TheVpc.Upa.SessionContext {

        private System.Collections.Generic.IDictionary<Net.TheVpc.Upa.Impl.Context.PersistenceUnitKey , object> map = new System.Collections.Generic.Dictionary<Net.TheVpc.Upa.Impl.Context.PersistenceUnitKey , object>();

        public virtual bool ContainsParam(Net.TheVpc.Upa.PersistenceUnit persistenceUnit, string name) {
            return map.ContainsKey(new Net.TheVpc.Upa.Impl.Context.PersistenceUnitKey(persistenceUnit, name));
        }


        public virtual void SetParam(Net.TheVpc.Upa.PersistenceUnit persistenceUnit, string name, object @value) {
            map[new Net.TheVpc.Upa.Impl.Context.PersistenceUnitKey(persistenceUnit, name)]=@value;
        }


        public virtual  T GetParam<T>(Net.TheVpc.Upa.PersistenceUnit persistenceUnit, System.Type type, string name, T defaultValue) {
            object o = Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<Net.TheVpc.Upa.Impl.Context.PersistenceUnitKey,object>(map,new Net.TheVpc.Upa.Impl.Context.PersistenceUnitKey(persistenceUnit, name));
            if (o != null) {
                return (T) o;
            }
            return defaultValue;
        }
    }
}
