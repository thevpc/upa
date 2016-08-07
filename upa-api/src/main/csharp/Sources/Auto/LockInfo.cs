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



namespace Net.Vpc.Upa
{


    public class LockInfo {

        private object entity;

        private string user;

        private Net.Vpc.Upa.Types.Temporal date;

        public LockInfo(object entity, Net.Vpc.Upa.Types.Temporal date, string user) {
            this.entity = entity;
            this.date = date;
            this.user = user;
        }

        public virtual string GetUser() {
            return user;
        }

        public virtual Net.Vpc.Upa.Types.Temporal GetDate() {
            return date;
        }

        public virtual object GetEntity() {
            return entity;
        }
    }
}
