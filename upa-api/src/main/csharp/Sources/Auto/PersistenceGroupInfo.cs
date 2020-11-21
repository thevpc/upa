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


    public class PersistenceGroupInfo : Net.TheVpc.Upa.UPAObjectInfo {

        private System.Collections.Generic.IList<Net.TheVpc.Upa.PersistenceUnitInfo> persistenceUnits;

        public PersistenceGroupInfo()  : base("persistenceGroup"){

        }

        public virtual System.Collections.Generic.IList<Net.TheVpc.Upa.PersistenceUnitInfo> GetPersistenceUnits() {
            return persistenceUnits;
        }

        public virtual void SetPersistenceUnits(System.Collections.Generic.IList<Net.TheVpc.Upa.PersistenceUnitInfo> persistenceUnits) {
            this.persistenceUnits = persistenceUnits;
        }
    }
}
