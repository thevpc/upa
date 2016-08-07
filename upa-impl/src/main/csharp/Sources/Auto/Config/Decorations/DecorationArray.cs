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



namespace Net.Vpc.Upa.Impl.Config.Decorations
{


    /**
     *
     * @author taha.bensalah@gmail.com
     */
    public class DecorationArray : Net.Vpc.Upa.Impl.Config.Decorations.AbstractDecorationValue {

        public Net.Vpc.Upa.Config.DecorationValue[] values;

        public Net.Vpc.Upa.Config.ConfigInfo configInfo;

        public DecorationArray(Net.Vpc.Upa.Config.DecorationValue[] values, Net.Vpc.Upa.Config.ConfigInfo info) {
            this.values = values;
            this.configInfo = info;
        }

        public override Net.Vpc.Upa.Config.ConfigInfo GetConfig() {
            return configInfo;
        }

        public virtual Net.Vpc.Upa.Config.DecorationValue[] GetValues() {
            return values;
        }


        public override string ToString() {
            if (!GetConfig().Equals(Net.Vpc.Upa.Config.ConfigInfo.DEFAULT)) {
                System.Text.StringBuilder b = new System.Text.StringBuilder("Array");
                b.Append("[");
                b.Append(GetConfig());
                b.Append("]");
                b.Append(new System.Collections.Generic.List<Net.Vpc.Upa.Config.DecorationValue>(values));
                return b.ToString();
            }
            return System.Convert.ToString(new System.Collections.Generic.List<Net.Vpc.Upa.Config.DecorationValue>(values));
        }

        public virtual void Merge() {
            System.Collections.Generic.IList<object> ok = new System.Collections.Generic.List<object>();
            Net.Vpc.Upa.Config.DecorationValue[] alternatives = GetAlternatives();
            foreach (Net.Vpc.Upa.Config.DecorationValue alternative in alternatives) {
                Net.Vpc.Upa.Impl.Config.Decorations.DecorationArray d = (Net.Vpc.Upa.Impl.Config.Decorations.DecorationArray) alternative;
                switch(d.GetConfig().GetConfigAction()) {
                    case Net.Vpc.Upa.Config.ConfigAction.DELETE:
                        {
                            ok.Clear();
                            break;
                        }
                    case Net.Vpc.Upa.Config.ConfigAction.MERGE:
                    case Net.Vpc.Upa.Config.ConfigAction.REPLACE:
                        {
                            ok.Clear();
                            ok.Add(d.GetValues());
                            break;
                        }
                }
            }
            Net.Vpc.Upa.Config.DecorationValue last = alternatives[alternatives.Length - 1];
            if ((ok.Count==0)) {
                values = null;
                configInfo = new Net.Vpc.Upa.Config.ConfigInfo(last.GetConfig().GetOrder(), Net.Vpc.Upa.Config.ConfigAction.DELETE, last.GetConfig().GetPersistenceGroup(), last.GetConfig().GetPersistenceUnit());
            } else {
                values = (Net.Vpc.Upa.Config.DecorationValue[]) ok[(ok).Count - 1];
                configInfo = new Net.Vpc.Upa.Config.ConfigInfo(last.GetConfig().GetOrder(), Net.Vpc.Upa.Config.ConfigAction.MERGE, last.GetConfig().GetPersistenceGroup(), last.GetConfig().GetPersistenceUnit());
            }
        }
    }
}
