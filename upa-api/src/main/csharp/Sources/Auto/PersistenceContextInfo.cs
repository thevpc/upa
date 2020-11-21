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


    public class PersistenceContextInfo {

        private System.Collections.Generic.IList<Net.TheVpc.Upa.PersistenceGroupInfo> groups = new System.Collections.Generic.List<Net.TheVpc.Upa.PersistenceGroupInfo>();

        public virtual System.Collections.Generic.IList<Net.TheVpc.Upa.PersistenceGroupInfo> GetGroups() {
            return groups;
        }

        public virtual void SetGroups(System.Collections.Generic.IList<Net.TheVpc.Upa.PersistenceGroupInfo> groups) {
            this.groups = groups;
        }
    }
}
