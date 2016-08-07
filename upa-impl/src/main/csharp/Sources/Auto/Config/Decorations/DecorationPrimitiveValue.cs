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
    public class DecorationPrimitiveValue : Net.Vpc.Upa.Impl.Config.Decorations.AbstractDecorationValue {

        private object @value;

        private Net.Vpc.Upa.Config.ConfigInfo configInfo;

        public DecorationPrimitiveValue(object @value, Net.Vpc.Upa.Config.ConfigInfo configInfo) {
            this.@value = @value;
            this.configInfo = configInfo;
        }

        public override Net.Vpc.Upa.Config.ConfigInfo GetConfig() {
            return configInfo;
        }

        public virtual object GetValue() {
            return @value;
        }

        public virtual void Merge() {
            System.Collections.Generic.IList<object> ok = new System.Collections.Generic.List<object>();
            Net.Vpc.Upa.Config.DecorationValue[] alternatives = GetAlternatives();
            foreach (Net.Vpc.Upa.Config.DecorationValue alternative in alternatives) {
                Net.Vpc.Upa.Impl.Config.Decorations.DecorationPrimitiveValue d = (Net.Vpc.Upa.Impl.Config.Decorations.DecorationPrimitiveValue) alternative;
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
                            ok.Add(d.GetValue());
                            break;
                        }
                }
            }
            Net.Vpc.Upa.Config.DecorationValue last = alternatives[alternatives.Length - 1];
            if ((ok.Count==0)) {
                @value = null;
                configInfo = new Net.Vpc.Upa.Config.ConfigInfo(last.GetConfig().GetOrder(), Net.Vpc.Upa.Config.ConfigAction.DELETE, last.GetConfig().GetPersistenceGroup(), last.GetConfig().GetPersistenceUnit());
            } else {
                @value = ok[(ok).Count - 1];
                configInfo = new Net.Vpc.Upa.Config.ConfigInfo(last.GetConfig().GetOrder(), Net.Vpc.Upa.Config.ConfigAction.MERGE, last.GetConfig().GetPersistenceGroup(), last.GetConfig().GetPersistenceUnit());
            }
        }


        public override string ToString() {
            if (!GetConfig().Equals(Net.Vpc.Upa.Config.ConfigInfo.DEFAULT)) {
                System.Text.StringBuilder b = new System.Text.StringBuilder("Value");
                b.Append("[");
                b.Append(GetConfig());
                b.Append("]");
                b.Append("(");
                b.Append(Format(@value));
                b.Append(")");
                return b.ToString();
            }
            return Format(@value);
        }

        private string Format(object o) {
            if (o == null) {
                return "null";
            }
            if (o is string) {
                return "\"" + o + "\"";
            }
            if (o is System.Type) {
                return (((System.Type) o)).FullName;
            }
            return System.Convert.ToString(o);
        }
    }
}
