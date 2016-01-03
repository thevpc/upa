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
    * @creationdate 1/5/13 3:41 PM*/
    public class EntityChildComparator : System.Collections.Generic.IComparer<string> {

        private Net.Vpc.Upa.Entity defaultEntity;

        public EntityChildComparator(Net.Vpc.Upa.Entity defaultEntity) {
            this.defaultEntity = defaultEntity;
        }

        public virtual int Compare(string o1, string o2) {
            string s1 = o1;
            string s2 = o2;
            int i1 = defaultEntity.IndexOfPart(s1, false, true, true, true);
            int i2 = defaultEntity.IndexOfPart(s2, false, true, true, true);
            return Net.Vpc.Upa.Impl.Util.UPAUtils.Compare(i1, i2);
        }
    }
}
