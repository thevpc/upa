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



namespace Net.TheVpc.Upa.Persistence
{


    /**
     *
     * @author taha.bensalah@gmail.com
     */
    public sealed class PersistenceNameType {

        private static readonly System.Collections.Generic.Dictionary<string , Net.TheVpc.Upa.Persistence.PersistenceNameType> values = new System.Collections.Generic.Dictionary<string , Net.TheVpc.Upa.Persistence.PersistenceNameType>();

        private readonly string name;

        private readonly bool global;

        public static readonly Net.TheVpc.Upa.Persistence.PersistenceNameType TABLE = Create("TABLE", true);

        public static readonly Net.TheVpc.Upa.Persistence.PersistenceNameType UNION_TABLE = Create("UNION_TABLE", true);

        public static readonly Net.TheVpc.Upa.Persistence.PersistenceNameType VIEW = Create("VIEW", true);

        public static readonly Net.TheVpc.Upa.Persistence.PersistenceNameType IMPLICIT_VIEW = Create("IMPLICIT_VIEW", true);

        public static readonly Net.TheVpc.Upa.Persistence.PersistenceNameType COLUMN = Create("COLUMN", false);

        public static readonly Net.TheVpc.Upa.Persistence.PersistenceNameType FK_CONSTRAINT = Create("FK_CONSTRAINT", true);

        public static readonly Net.TheVpc.Upa.Persistence.PersistenceNameType PK_CONSTRAINT = Create("PK_CONSTRAINT", true);

        public static readonly Net.TheVpc.Upa.Persistence.PersistenceNameType INDEX = Create("INDEX", true);

        public static readonly Net.TheVpc.Upa.Persistence.PersistenceNameType ALIAS = Create("ALIAS", false);

        private PersistenceNameType(string name, bool global) {
            this.name = name;
            this.global = global;
        }

        public static Net.TheVpc.Upa.Persistence.PersistenceNameType ValueOf(string name) {
            Net.TheVpc.Upa.Persistence.PersistenceNameType f = Net.TheVpc.Upa.FwkConvertUtils.GetMapValue<K,V>(values,name);
            if (f == null) {
                throw new Net.TheVpc.Upa.Exceptions.UPAIllegalArgumentException("PersistenceNameType not found " + name);
            }
            return f;
        }

        public static Net.TheVpc.Upa.Persistence.PersistenceNameType Create(string name, bool globalScope) {
            if (name == null || (name).Length == 0 || (name.Trim()).Length != (name).Length) {
                throw new Net.TheVpc.Upa.Exceptions.UPAIllegalArgumentException("Invalid PersistenceNameType Name " + name);
            }
            if (values.ContainsKey(name)) {
                throw new Net.TheVpc.Upa.Exceptions.UPAIllegalArgumentException("PersistenceNameType already exists " + name);
            }
            Net.TheVpc.Upa.Persistence.PersistenceNameType t = new Net.TheVpc.Upa.Persistence.PersistenceNameType(name, globalScope);
            values[t.Name()]=t;
            return t;
        }

        public string Name() {
            return this.name;
        }

        public bool IsGlobal() {
            return global;
        }


        public override int GetHashCode() {
            int hash = 3;
            hash = 11 * hash + (this.name != null ? this.name.GetHashCode() : 0);
            return hash;
        }


        public override bool Equals(object obj) {
            if (obj == null) {
                return false;
            }
            if (GetType() != obj.GetType()) {
                return false;
            }
            Net.TheVpc.Upa.Persistence.PersistenceNameType other = (Net.TheVpc.Upa.Persistence.PersistenceNameType) obj;
            if ((this.name == null) ? (other.name != null) : !this.name.Equals(other.name)) {
                return false;
            }
            return true;
        }


        public override string ToString() {
            return "PersistenceNameType{" + "name=" + name + ", global=" + global + '}';
        }
    }
}
