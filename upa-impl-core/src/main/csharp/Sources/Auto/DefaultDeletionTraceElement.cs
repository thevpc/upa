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



namespace Net.TheVpc.Upa.Impl
{


    /**
    * @author Taha BEN SALAH <taha.bensalah@gmail.com>
    * @creationdate 1/8/13 1:55 AM*/
    internal class DefaultDeletionTraceElement : Net.TheVpc.Upa.DeletionTraceElement {

        private string name;

        private long count;

        private Net.TheVpc.Upa.RelationshipType relationType;

        public DefaultDeletionTraceElement(Net.TheVpc.Upa.RelationshipType relationType, string entityName, long count) {
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

        public virtual Net.TheVpc.Upa.RelationshipType GetRelationshipType() {
            return relationType;
        }
    }
}
