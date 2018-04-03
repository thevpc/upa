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



namespace Net.Vpc.Upa.Persistence
{


    /**
     *
     * @author taha.bensalah@gmail.com
     */
    public class PersistenceName {

        private int configOrder;

        private string @object;

        private Net.Vpc.Upa.Persistence.PersistenceNameType persistenceNameType;

        private string @value;

        public PersistenceName(string @object, Net.Vpc.Upa.Persistence.PersistenceNameType type, string name, int configOrder) {
            if (type == null) {
                throw new Net.Vpc.Upa.Exceptions.UPAException("NullType");
            }
            if (name == null || (name.Trim()).Length == 0) {
                throw new Net.Vpc.Upa.Exceptions.UPAException("NullName");
            } else {
                name = name.Trim();
            }
            if (@object == null || (@object.Trim()).Length == 0) {
                @object = null;
            }
            this.@object = @object;
            this.persistenceNameType = type;
            this.@value = name;
            this.configOrder = configOrder;
        }

        public virtual int GetConfigOrder() {
            return configOrder;
        }

        public virtual string GetObject() {
            return @object;
        }

        public virtual Net.Vpc.Upa.Persistence.PersistenceNameType GetPersistenceNameType() {
            return persistenceNameType;
        }

        public virtual string GetValue() {
            return @value;
        }


        public override int GetHashCode() {
            int hash = 3;
            hash = 29 * hash + (this.@object != null ? this.@object.GetHashCode() : 0);
            hash = 29 * hash + (this.persistenceNameType != null ? this.persistenceNameType.GetHashCode() : 0);
            hash = 29 * hash + (this.@value != null ? this.@value.GetHashCode() : 0);
            return hash;
        }


        public override bool Equals(object obj) {
            if (obj == null) {
                return false;
            }
            if (GetType() != obj.GetType()) {
                return false;
            }
            Net.Vpc.Upa.Persistence.PersistenceName other = (Net.Vpc.Upa.Persistence.PersistenceName) obj;
            if ((this.@object == null) ? (other.@object != null) : !this.@object.Equals(other.@object)) {
                return false;
            }
            if (this.persistenceNameType != other.persistenceNameType && (this.persistenceNameType == null || !this.persistenceNameType.Equals(other.persistenceNameType))) {
                return false;
            }
            if ((this.@value == null) ? (other.@value != null) : !this.@value.Equals(other.@value)) {
                return false;
            }
            return true;
        }


        public override string ToString() {
            return "PersistenceName{" + "object=" + @object + ", type=" + persistenceNameType + ", value=" + @value + '}';
        }
    }
}
