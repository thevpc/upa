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



namespace Net.Vpc.Upa
{


    public class PersistenceGroupInfo : Net.Vpc.Upa.UPAObjectInfo {

        private System.Collections.Generic.IList<Net.Vpc.Upa.PersistenceUnitInfo> persistenceUnits;

        public PersistenceGroupInfo()  : base("persistenceGroup"){

        }

        public virtual System.Collections.Generic.IList<Net.Vpc.Upa.PersistenceUnitInfo> GetPersistenceUnits() {
            return persistenceUnits;
        }

        public virtual void SetPersistenceUnits(System.Collections.Generic.IList<Net.Vpc.Upa.PersistenceUnitInfo> persistenceUnits) {
            this.persistenceUnits = persistenceUnits;
        }
    }
}
