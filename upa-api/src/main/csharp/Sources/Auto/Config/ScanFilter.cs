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



namespace Net.Vpc.Upa.Config
{

    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public class ScanFilter {

        private int configOrder;

        private string libs;

        private string types;

        /**
             * When true, filter is inherited in children items. Inheritance mean that
             * filter defined in context will be appended (as OR operator) to filters of
             * persistenceGroup and persistenceUnits; and persistenceGroup filter will
             * be appended to persistenceUnitFilter
             */
        private bool propagate;

        public ScanFilter(string libs, string types, bool propagate, int configOrder) {
            this.libs = libs == null ? "" : libs.Trim();
            this.types = types == null ? "" : types.Trim();
            this.propagate = propagate;
            this.configOrder = configOrder;
        }

        public virtual int GetConfigOrder() {
            return configOrder;
        }

        public virtual void SetConfigOrder(int configOrder) {
            this.configOrder = configOrder;
        }

        public virtual bool IsPropagate() {
            return propagate;
        }

        public virtual void SetPropagate(bool propagate) {
            this.propagate = propagate;
        }

        public virtual string GetLibs() {
            return libs;
        }

        public virtual string GetTypes() {
            return types;
        }


        public override int GetHashCode() {
            int hash = 5;
            hash = 59 * hash + (this.libs != null ? this.libs.GetHashCode() : 0);
            hash = 59 * hash + (this.types != null ? this.types.GetHashCode() : 0);
            hash = 59 * hash + (this.propagate ? 1 : 0);
            return hash;
        }


        public override bool Equals(object obj) {
            if (obj == null) {
                return false;
            }
            if (GetType() != obj.GetType()) {
                return false;
            }
            Net.Vpc.Upa.Config.ScanFilter other = (Net.Vpc.Upa.Config.ScanFilter) obj;
            if ((this.libs == null) ? (other.libs != null) : !this.libs.Equals(other.libs)) {
                return false;
            }
            if ((this.types == null) ? (other.types != null) : !this.types.Equals(other.types)) {
                return false;
            }
            if (this.propagate != other.propagate) {
                return false;
            }
            return true;
        }


        public override string ToString() {
            return "ContextAnnotationStrategyFilter{" + "libs=" + libs + ", types=" + types + ", propagate=" + propagate + '}';
        }
    }
}
