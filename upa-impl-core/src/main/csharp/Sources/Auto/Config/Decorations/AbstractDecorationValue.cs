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



using System.Linq;
namespace Net.Vpc.Upa.Impl.Config.Decorations
{


    /**
     *
     * @author taha.bensalah@gmail.com
     */
    public abstract class AbstractDecorationValue : Net.Vpc.Upa.Config.DecorationValue {

        private System.Collections.Generic.IList<Net.Vpc.Upa.Config.DecorationValue> alternatives = new System.Collections.Generic.List<Net.Vpc.Upa.Config.DecorationValue>();

        public AbstractDecorationValue() {
            AddAlternative(this);
        }

        public virtual void AddAlternative(Net.Vpc.Upa.Config.DecorationValue other) {
            alternatives.Add(other);
            Net.Vpc.Upa.Impl.FwkConvertUtils.ListSort(alternatives, null);
        }

        public virtual Net.Vpc.Upa.Config.DecorationValue[] GetAlternatives() {
            return alternatives.ToArray();
        }

        public virtual int CompareTo(Net.Vpc.Upa.Config.DecorationValue o) {
            if (o == null) {
                return 1;
            }
            if (o == this) {
                return 0;
            }
            Net.Vpc.Upa.Config.ConfigInfo c1 = this.GetConfig();
            Net.Vpc.Upa.Config.ConfigInfo c2 = o.GetConfig();
            if (c1 == c2) {
                return 0;
            }
            if (c1 != null) {
                return c1.CompareTo(c2);
            }
            return 0;
        }

        public virtual Net.Vpc.Upa.Config.DecorationValue[] Shrink(Net.Vpc.Upa.Config.DecorationValue[] alternatives) {
            System.Collections.Generic.List<Net.Vpc.Upa.Config.DecorationValue> ok = new System.Collections.Generic.List<Net.Vpc.Upa.Config.DecorationValue>();
            foreach (Net.Vpc.Upa.Config.DecorationValue alternative in alternatives) {
                switch(alternative.GetConfig().GetConfigAction()) {
                    case Net.Vpc.Upa.Config.ConfigAction.MERGE:
                        {
                            ok.Add(alternative);
                            break;
                        }
                    case Net.Vpc.Upa.Config.ConfigAction.DELETE:
                        {
                            ok.Clear();
                            break;
                        }
                    case Net.Vpc.Upa.Config.ConfigAction.REPLACE:
                        {
                            ok.Clear();
                            ok.Add(alternative);
                            break;
                        }
                }
            }
            return ok.ToArray();
        }
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract Net.Vpc.Upa.Config.ConfigInfo GetConfig();
    }
}
