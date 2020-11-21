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
namespace Net.TheVpc.Upa.Impl.Config.Decorations
{


    /**
     *
     * @author taha.bensalah@gmail.com
     */
    public abstract class AbstractDecorationValue : Net.TheVpc.Upa.Config.DecorationValue {

        private System.Collections.Generic.IList<Net.TheVpc.Upa.Config.DecorationValue> alternatives = new System.Collections.Generic.List<Net.TheVpc.Upa.Config.DecorationValue>();

        public AbstractDecorationValue() {
            AddAlternative(this);
        }

        public virtual void AddAlternative(Net.TheVpc.Upa.Config.DecorationValue other) {
            alternatives.Add(other);
            Net.TheVpc.Upa.Impl.FwkConvertUtils.ListSort(alternatives, null);
        }

        public virtual Net.TheVpc.Upa.Config.DecorationValue[] GetAlternatives() {
            return alternatives.ToArray();
        }

        public virtual int CompareTo(Net.TheVpc.Upa.Config.DecorationValue o) {
            if (o == null) {
                return 1;
            }
            if (o == this) {
                return 0;
            }
            Net.TheVpc.Upa.Config.ConfigInfo c1 = this.GetConfig();
            Net.TheVpc.Upa.Config.ConfigInfo c2 = o.GetConfig();
            if (c1 == c2) {
                return 0;
            }
            if (c1 != null) {
                return c1.CompareTo(c2);
            }
            return 0;
        }

        public virtual Net.TheVpc.Upa.Config.DecorationValue[] Shrink(Net.TheVpc.Upa.Config.DecorationValue[] alternatives) {
            System.Collections.Generic.List<Net.TheVpc.Upa.Config.DecorationValue> ok = new System.Collections.Generic.List<Net.TheVpc.Upa.Config.DecorationValue>();
            foreach (Net.TheVpc.Upa.Config.DecorationValue alternative in alternatives) {
                switch(alternative.GetConfig().GetConfigAction()) {
                    case Net.TheVpc.Upa.Config.ConfigAction.MERGE:
                        {
                            ok.Add(alternative);
                            break;
                        }
                    case Net.TheVpc.Upa.Config.ConfigAction.DELETE:
                        {
                            ok.Clear();
                            break;
                        }
                    case Net.TheVpc.Upa.Config.ConfigAction.REPLACE:
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
        public abstract Net.TheVpc.Upa.Config.ConfigInfo GetConfig();
    }
}
