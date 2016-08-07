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



namespace Net.Vpc.Upa.Impl.Context
{


    /**
     *
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public class DefaultSessionContext : Net.Vpc.Upa.SessionContext {

        private System.Collections.Generic.IDictionary<Net.Vpc.Upa.Impl.Context.PersistenceUnitKey , object> map = new System.Collections.Generic.Dictionary<Net.Vpc.Upa.Impl.Context.PersistenceUnitKey , object>();

        public virtual bool ContainsParam(Net.Vpc.Upa.PersistenceUnit persistenceUnit, string name) {
            return map.ContainsKey(new Net.Vpc.Upa.Impl.Context.PersistenceUnitKey(persistenceUnit, name));
        }


        public virtual void SetParam(Net.Vpc.Upa.PersistenceUnit persistenceUnit, string name, object @value) {
            map[new Net.Vpc.Upa.Impl.Context.PersistenceUnitKey(persistenceUnit, name)]=@value;
        }


        public virtual  T GetParam<T>(Net.Vpc.Upa.PersistenceUnit persistenceUnit, System.Type type, string name, T defaultValue) {
            object o = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<Net.Vpc.Upa.Impl.Context.PersistenceUnitKey,object>(map,new Net.Vpc.Upa.Impl.Context.PersistenceUnitKey(persistenceUnit, name));
            if (o != null) {
                return (T) o;
            }
            return defaultValue;
        }
    }
}
