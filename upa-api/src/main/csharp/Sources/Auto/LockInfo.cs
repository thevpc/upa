/*********************************************************
 *********************************************************
 **   DO NOT EDIT                                       **
 **                                                     **
 **   THIS FILE HAS BEEN GENERATED AUTOMATICALLY         **
 **   BY UPA PORTABLE GENERATOR                         **
 **   (c) vpc                                           **
 **                                                     **
 *********************************************************
 ********************************************************/



namespace Net.TheVpc.Upa
{


    public class LockInfo {

        private object entity;

        private string user;

        private Net.TheVpc.Upa.Types.Temporal date;

        public LockInfo(object entity, Net.TheVpc.Upa.Types.Temporal date, string user) {
            this.entity = entity;
            this.date = date;
            this.user = user;
        }

        public virtual string GetUser() {
            return user;
        }

        public virtual Net.TheVpc.Upa.Types.Temporal GetDate() {
            return date;
        }

        public virtual object GetEntity() {
            return entity;
        }
    }
}
