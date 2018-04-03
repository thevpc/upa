/*********************************************************
 *********************************************************
 **   DO NOT EDIT                                       **
 **                                                     **
 **   THIS FILE HAS BEEN GENERATED AUTOMATICALLY         **
 **   BY UPA PORTABLE GENERATOR                         **
 **   (c) vpc                                           **
 **                                                     **
 *********************************************************
 ********************************************************/



namespace Net.Vpc.Upa.Config
{

    /**
     * @author taha.bensalah@gmail.com
     */
    public class ConfigInfo : System.IComparable<Net.Vpc.Upa.Config.ConfigInfo> {

        public static Net.Vpc.Upa.Config.ConfigInfo DEFAULT = new Net.Vpc.Upa.Config.ConfigInfo(0, Net.Vpc.Upa.Config.ConfigAction.MERGE, null, null);

        public static Net.Vpc.Upa.Config.ConfigInfo MIN = new Net.Vpc.Upa.Config.ConfigInfo(System.Int32.MinValue, Net.Vpc.Upa.Config.ConfigAction.MERGE, null, null);

        public static Net.Vpc.Upa.Config.ConfigInfo MAX = new Net.Vpc.Upa.Config.ConfigInfo(System.Int32.MaxValue, Net.Vpc.Upa.Config.ConfigAction.MERGE, null, null);

        private readonly int configOrder;

        private readonly Net.Vpc.Upa.Config.ConfigAction configAction;

        private readonly string persistenceGroup;

        private readonly string persistenceUnit;

        public ConfigInfo(int configOrder, Net.Vpc.Upa.Config.ConfigAction configAction, string persistenceGroup, string persistenceUnit) {
            this.configOrder = configOrder;
            this.configAction = configAction;
            this.persistenceGroup = IsNullOrEmpty(persistenceGroup) ? null : persistenceGroup;
            this.persistenceUnit = IsNullOrEmpty(persistenceUnit) ? null : persistenceUnit;
        }

        public virtual int GetOrder() {
            return configOrder;
        }

        public virtual Net.Vpc.Upa.Config.ConfigAction GetConfigAction() {
            return configAction;
        }

        public virtual string GetPersistenceGroup() {
            return persistenceGroup;
        }

        public virtual string GetPersistenceUnit() {
            return persistenceUnit;
        }


        public override int GetHashCode() {
            int hash = 7;
            hash = 67 * hash + this.configOrder;
            hash = 67 * hash + (this.configAction != default(Net.Vpc.Upa.Config.ConfigAction) ? this.configAction.GetHashCode() : 0);
            hash = 67 * hash + (this.persistenceGroup != null ? this.persistenceGroup.GetHashCode() : 0);
            hash = 67 * hash + (this.persistenceUnit != null ? this.persistenceUnit.GetHashCode() : 0);
            return hash;
        }


        public override bool Equals(object obj) {
            if (obj == null) {
                return false;
            }
            if (GetType() != obj.GetType()) {
                return false;
            }
            Net.Vpc.Upa.Config.ConfigInfo other = (Net.Vpc.Upa.Config.ConfigInfo) obj;
            if (this.configOrder != other.configOrder) {
                return false;
            }
            if (this.configAction != other.configAction) {
                return false;
            }
            if ((this.persistenceGroup == null) ? (other.persistenceGroup != null) : !this.persistenceGroup.Equals(other.persistenceGroup)) {
                return false;
            }
            if ((this.persistenceUnit == null) ? (other.persistenceUnit != null) : !this.persistenceUnit.Equals(other.persistenceUnit)) {
                return false;
            }
            return true;
        }

        public virtual int CompareTo(Net.Vpc.Upa.Config.ConfigInfo o) {
            if (o == null) {
                return 1;
            }
            int v = configOrder.CompareTo(o.configOrder);
            if (v != 0) {
                return v;
            }
            v = CompareExpr(persistenceGroup, o.persistenceGroup);
            if (v != 0) {
                return v;
            }
            v = CompareExpr(persistenceUnit, o.persistenceUnit);
            if (v != 0) {
                return v;
            }
            return 0;
        }

        private int CompareExpr(string a, string b) {
            if (a == null) {
                a = "";
            }
            if (b == null) {
                b = "";
            }
            return a.CompareTo(b);
        }


        public override string ToString() {
            System.Text.StringBuilder b = new System.Text.StringBuilder("Config(");
            b.Append(configAction);
            if (configOrder != 0) {
                b.Append(":");
                if (configOrder == System.Int32.MinValue) {
                    b.Append("MIN");
                } else if (configOrder == System.Int32.MaxValue) {
                    b.Append("MAX");
                } else {
                    b.Append(configOrder);
                }
            }
            if (!IsNullOrEmpty(persistenceGroup) || !IsNullOrEmpty(persistenceUnit)) {
                b.Append(";");
                b.Append(IsNullOrEmpty(persistenceGroup) ? "" : persistenceGroup);
                b.Append("/");
                b.Append(IsNullOrEmpty(persistenceUnit) ? "" : persistenceUnit);
            }
            b.Append(")");
            return b.ToString();
        }

        private static bool IsNullOrEmpty(string s) {
            return s == null || (s.Trim()).Length == 0 || s.Equals(Net.Vpc.Upa.UPA.UNDEFINED_STRING);
        }
    }
}
