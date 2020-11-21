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



namespace Net.TheVpc.Upa.Callbacks
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 11/27/12 9:52 PM
     */
    public class RelationshipEvent : Net.TheVpc.Upa.Callbacks.UPAEvent {

        private readonly Net.TheVpc.Upa.PersistenceUnit persistenceUnit;

        private readonly Net.TheVpc.Upa.Relationship relationship;

        private readonly Net.TheVpc.Upa.EventPhase phase;

        public RelationshipEvent(Net.TheVpc.Upa.Relationship relation, Net.TheVpc.Upa.PersistenceUnit persistenceUnit, Net.TheVpc.Upa.EventPhase phase) {
            this.persistenceUnit = persistenceUnit;
            this.relationship = relation;
            this.phase = phase;
        }

        public virtual Net.TheVpc.Upa.EventPhase GetPhase() {
            return phase;
        }

        public virtual Net.TheVpc.Upa.PersistenceUnit GetPersistenceUnit() {
            return persistenceUnit;
        }

        public virtual Net.TheVpc.Upa.Relationship GetRelationship() {
            return relationship;
        }
    }
}
