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

        private readonly Net.Vpc.Upa.EventPhase phase;

        public RelationshipEvent(Net.Vpc.Upa.Relationship relation, Net.Vpc.Upa.PersistenceUnit persistenceUnit, Net.Vpc.Upa.EventPhase phase) {
            this.persistenceUnit = persistenceUnit;
            this.relationship = relation;
            this.phase = phase;
        }

        public virtual Net.Vpc.Upa.EventPhase GetPhase() {
            return phase;
        }

        public virtual Net.Vpc.Upa.PersistenceUnit GetPersistenceUnit() {
            return persistenceUnit;
        }

        public virtual Net.Vpc.Upa.Relationship GetRelationship() {
            return relationship;
        }
    }
}
