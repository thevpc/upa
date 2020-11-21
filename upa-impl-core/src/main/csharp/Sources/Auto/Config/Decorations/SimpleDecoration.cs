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



namespace Net.TheVpc.Upa.Impl.Config.Decorations
{


    /**
     *
     * @author taha.bensalah@gmail.com
     */
    public sealed class SimpleDecoration : Net.TheVpc.Upa.Impl.Config.Decorations.AbstractDecoration {

        private Net.TheVpc.Upa.Config.DecorationSourceType decorationSourceType;

        private Net.TheVpc.Upa.Config.DecorationTarget targetType;

        private string type;

        private string name;

        private string location;

        private int position;

        private Net.TheVpc.Upa.Config.ConfigInfo configInfo;

        private System.Collections.Generic.IDictionary<string , Net.TheVpc.Upa.Config.DecorationValue> values = null;

        public SimpleDecoration(string name, Net.TheVpc.Upa.Config.DecorationSourceType locationType, Net.TheVpc.Upa.Config.DecorationTarget targetType, string type, string location, int position, Net.TheVpc.Upa.Config.ConfigInfo configInfo, System.Collections.Generic.IDictionary<string , Net.TheVpc.Upa.Config.DecorationValue> attr) {
            this.name = name;
            this.decorationSourceType = locationType;
            this.targetType = targetType;
            this.type = type;
            this.location = location;
            this.configInfo = configInfo;
            this.values = attr;
            this.position = position;
        }

        public override string GetName() {
            return name;
        }

        public override int GetPosition() {
            return position;
        }

        protected internal override Net.TheVpc.Upa.Config.ConfigInfo GetConfigInfo0() {
            if (configInfo == null) {
                Net.TheVpc.Upa.Config.Decoration config = GetDecoration("config");
                if (config != null) {
                    Net.TheVpc.Upa.Config.Decoration c = (Net.TheVpc.Upa.Config.Decoration) config;
                    if (c.GetName().Equals((typeof(Net.TheVpc.Upa.Config.Config)).FullName)) {
                        configInfo = new Net.TheVpc.Upa.Config.ConfigInfo(c.GetInt("order"), (Net.TheVpc.Upa.Config.ConfigAction)(System.Enum.Parse(typeof(Net.TheVpc.Upa.Config.ConfigAction),c.GetString("action"))), c.GetString("persistenceGroup"), c.GetString("persistenceUnit"));
                    }
                }
            }
            return configInfo;
        }

        public override string GetLocation() {
            return location;
        }

        public override Net.TheVpc.Upa.Config.DecorationSourceType GetDecorationSourceType() {
            return decorationSourceType;
        }

        public override Net.TheVpc.Upa.Config.DecorationTarget GetTarget() {
            return targetType;
        }

        public override string GetLocationType() {
            return type;
        }

        public override Net.TheVpc.Upa.Config.ConfigInfo GetConfig() {
            return configInfo;
        }

        protected internal override System.Collections.Generic.IDictionary<string , Net.TheVpc.Upa.Config.DecorationValue> GetAttributes0() {
            return values;
        }


        public override string ToString() {
            System.Text.StringBuilder b = new System.Text.StringBuilder();
            b.Append("@").Append(GetName());
            b.Append("[");
            if (targetType == default(Net.TheVpc.Upa.Config.DecorationTarget)) {
                b.Append("EMBEDDED").Append(":");
            }
            b.Append(type);
            if (targetType == Net.TheVpc.Upa.Config.DecorationTarget.METHOD || targetType == Net.TheVpc.Upa.Config.DecorationTarget.FIELD) {
                b.Append(".").Append(location);
            }
            if (!GetConfig().Equals(Net.TheVpc.Upa.Config.ConfigInfo.DEFAULT)) {
                b.Append(";");
                b.Append(GetConfig());
            }
            b.Append("](");
            string s = GetAttributes().ToString();
            b.Append(s.Substring(1,((s).Length - 1)-(1)));
            b.Append(")");
            return b.ToString();
        }
    }
}
