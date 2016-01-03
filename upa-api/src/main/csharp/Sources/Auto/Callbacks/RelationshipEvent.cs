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



namespace Net.Vpc.Upa.Callbacks
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 11/27/12 9:52 PM
     */
    public class RelationshipEvent : Net.Vpc.Upa.Callbacks.UPAEvent {

        private readonly Net.Vpc.Upa.PersistenceUnit persistenceUnit;

        private readonly Net.Vpc.Upa.Relationship relationship;

        public RelationshipEvent(Net.Vpc.Upa.Relationship relation, Net.Vpc.Upa.PersistenceUnit persistenceUnit) {
            this.persistenceUnit = persistenceUnit;
            this.relationship = relation;
        }

        public virtual Net.Vpc.Upa.PersistenceUnit GetPersistenceUnit() {
            return persistenceUnit;
        }

        public virtual Net.Vpc.Upa.Relationship GetRelationship() {
            return relationship;
        }
    }
}
