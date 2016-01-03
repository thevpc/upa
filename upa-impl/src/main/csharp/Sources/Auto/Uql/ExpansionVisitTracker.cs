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



namespace Net.Vpc.Upa.Impl.Uql
{


    /**
     *
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    internal class ExpansionVisitTracker {

        private System.Collections.Generic.Dictionary<string , int?> map = new System.Collections.Generic.Dictionary<string , int?>();

        private int maxEntityDepth = 2;

        private int maxGlobalDepth = 10;

        private int globalDepth = 10;

        public virtual bool NextVisit(string entity) {
            int i = GetVisited(entity);
            if (i > 0) {
                DecVisited(entity);
                return true;
            }
            return false;
        }

        public virtual int GetVisited(string entity) {
            int? i = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,int?>(map,entity);
            return i == null ? ((int)(maxEntityDepth)) : (i).Value;
        }

        public virtual void DecGlobal() {
            globalDepth--;
        }

        public virtual void DecVisited(string entity) {
            map[entity]=GetVisited(entity) - 1;
        }

        public virtual Net.Vpc.Upa.Impl.Uql.ExpansionVisitTracker Dive() {
            if (globalDepth > 0) {
                Net.Vpc.Upa.Impl.Uql.ExpansionVisitTracker cc = Copy();
                cc.globalDepth--;
                return cc;
            }
            return null;
        }

        public virtual Net.Vpc.Upa.Impl.Uql.ExpansionVisitTracker Copy() {
            Net.Vpc.Upa.Impl.Uql.ExpansionVisitTracker r = new Net.Vpc.Upa.Impl.Uql.ExpansionVisitTracker();
            Net.Vpc.Upa.Impl.FwkConvertUtils.PutAllMap<string,int?>(r.map,map);
            r.maxEntityDepth = maxEntityDepth;
            r.maxGlobalDepth = maxGlobalDepth;
            r.globalDepth = globalDepth;
            return r;
        }
    }
}
