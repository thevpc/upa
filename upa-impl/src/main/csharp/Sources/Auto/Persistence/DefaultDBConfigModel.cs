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



namespace Net.Vpc.Upa.Impl.Persistence
{


    /**
     * Created by IntelliJ IDEA. User: root Date: 9 mai 2003 Time: 11:38:44 To
     * change this template use Options | File Templates.
     */
    public class DefaultDBConfigModel : Net.Vpc.Upa.Persistence.DBConfigModel {

        private string[] adapters;

        private string adapter;

        public DefaultDBConfigModel() {
        }

        public virtual string[] GetConnectionStringArray() {
            return adapters;
        }

        public virtual void SetConnectionStringArray(string[] adapters) {
            this.adapters = adapters;
        }

        public virtual string GetConnectionString() {
            return adapter;
        }

        public virtual void SetConnectionString(string adapter) {
            //        AppInfos.getInstance().setString(SimpleDBAppInfos.REG_PERSISTENCE_MANAGER, adapter);
            this.adapter = adapter;
        }
    }
}
