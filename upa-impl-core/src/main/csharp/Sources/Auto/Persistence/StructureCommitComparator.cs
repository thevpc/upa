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



namespace Net.Vpc.Upa.Impl.Persistence
{


    /**
    * @author Taha BEN SALAH <taha.bensalah@gmail.com>
    * @creationdate 1/8/13 1:53 AM*/
    internal class StructureCommitComparator : System.Collections.Generic.IComparer<Net.Vpc.Upa.Impl.Persistence.StructureCommit> {

        internal System.Collections.Generic.IDictionary<Net.Vpc.Upa.Impl.Persistence.ObjectAndType , int?> pos = new System.Collections.Generic.Dictionary<Net.Vpc.Upa.Impl.Persistence.ObjectAndType , int?>();

        internal StructureCommitComparator() {
            pos[new Net.Vpc.Upa.Impl.Persistence.ObjectAndType(typeof(Net.Vpc.Upa.Entity), null)]=100;
            pos[new Net.Vpc.Upa.Impl.Persistence.ObjectAndType(typeof(Net.Vpc.Upa.PrimitiveField), null)]=200;
            pos[new Net.Vpc.Upa.Impl.Persistence.ObjectAndType(typeof(Net.Vpc.Upa.Entity), Net.Vpc.Upa.Persistence.PersistenceNameType.PK_CONSTRAINT)]=300;
            pos[new Net.Vpc.Upa.Impl.Persistence.ObjectAndType(typeof(Net.Vpc.Upa.Index), null)]=400;
            pos[new Net.Vpc.Upa.Impl.Persistence.ObjectAndType(typeof(Net.Vpc.Upa.Relationship), null)]=500;
            pos[new Net.Vpc.Upa.Impl.Persistence.ObjectAndType(typeof(Net.Vpc.Upa.Entity), Net.Vpc.Upa.Persistence.PersistenceNameType.IMPLICIT_VIEW)]=800;
        }


        public virtual int Compare(Net.Vpc.Upa.Impl.Persistence.StructureCommit o1, Net.Vpc.Upa.Impl.Persistence.StructureCommit o2) {
            if (o1 == o2) {
                return 0;
            }
            if (o1 == null) {
                return -1;
            }
            if (o2 == null) {
                return 1;
            }
            Net.Vpc.Upa.Impl.Persistence.ObjectAndType oo1 = o1.typedObject;
            Net.Vpc.Upa.Impl.Persistence.ObjectAndType oo2 = o2.typedObject;
            int? p1 = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<Net.Vpc.Upa.Impl.Persistence.ObjectAndType,int?>(pos,oo1);
            int? p2 = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<Net.Vpc.Upa.Impl.Persistence.ObjectAndType,int?>(pos,oo2);
            if (p1 == null) {
                throw new System.ArgumentException ("Unknown order for " + oo1);
            }
            if (p2 == null) {
                throw new System.ArgumentException ("Unknown order for " + oo2);
            }
            return (p1 - p2).Value;
        }
    }
}
