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



namespace Net.Vpc.Upa.Impl
{


    /**
    * @author Taha BEN SALAH <taha.bensalah@gmail.com>
    * @creationdate 1/8/13 1:55 AM*/
    internal class DefaultDeletionTraceElement : Net.Vpc.Upa.DeletionTraceElement {

        private string name;

        private long count;

        private Net.Vpc.Upa.RelationshipType relationType;

        public DefaultDeletionTraceElement(Net.Vpc.Upa.RelationshipType relationType, string entityName, long count) {
            this.name = entityName;
            this.count = count;
            this.relationType = relationType;
        }

        public virtual string GetEntityName() {
            return name;
        }

        public virtual long GetCount() {
            return count;
        }

        public virtual Net.Vpc.Upa.RelationshipType GetRelationshipType() {
            return relationType;
        }
    }
}
