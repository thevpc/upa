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



namespace Net.TheVpc.Upa.Filters
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public class FieldProtectionLevelFilter : Net.TheVpc.Upa.Filters.AbstractFieldFilter {

        private bool dynamic;

        private bool checkPersist;

        private bool checkUpdate;

        private bool checkSelect;

        private System.Collections.Generic.HashSet<Net.TheVpc.Upa.ProtectionLevel> accepted;

        public static Net.TheVpc.Upa.Filters.FieldProtectionLevelFilter ForAll(params Net.TheVpc.Upa.ProtectionLevel [] accepted) {
            System.Collections.Generic.HashSet<Net.TheVpc.Upa.ProtectionLevel> all = new System.Collections.Generic.HashSet<Net.TheVpc.Upa.ProtectionLevel>();
            Net.TheVpc.Upa.FwkConvertUtils.CollectionAddRange(all, new System.Collections.Generic.List<Net.TheVpc.Upa.ProtectionLevel>(accepted));
            return new Net.TheVpc.Upa.Filters.FieldProtectionLevelFilter(true, true, true, all, false);
        }

        public static Net.TheVpc.Upa.Filters.FieldProtectionLevelFilter ForPersist(params Net.TheVpc.Upa.ProtectionLevel [] accepted) {
            System.Collections.Generic.HashSet<Net.TheVpc.Upa.ProtectionLevel> all = new System.Collections.Generic.HashSet<Net.TheVpc.Upa.ProtectionLevel>();
            Net.TheVpc.Upa.FwkConvertUtils.CollectionAddRange(all, new System.Collections.Generic.List<Net.TheVpc.Upa.ProtectionLevel>(accepted));
            return new Net.TheVpc.Upa.Filters.FieldProtectionLevelFilter(true, false, false, all, false);
        }

        public static Net.TheVpc.Upa.Filters.FieldProtectionLevelFilter ForUpdate(params Net.TheVpc.Upa.ProtectionLevel [] accepted) {
            System.Collections.Generic.HashSet<Net.TheVpc.Upa.ProtectionLevel> all = new System.Collections.Generic.HashSet<Net.TheVpc.Upa.ProtectionLevel>();
            Net.TheVpc.Upa.FwkConvertUtils.CollectionAddRange(all, new System.Collections.Generic.List<Net.TheVpc.Upa.ProtectionLevel>(accepted));
            return new Net.TheVpc.Upa.Filters.FieldProtectionLevelFilter(false, true, false, all, false);
        }

        public static Net.TheVpc.Upa.Filters.FieldProtectionLevelFilter ForFind(params Net.TheVpc.Upa.ProtectionLevel [] accepted) {
            System.Collections.Generic.HashSet<Net.TheVpc.Upa.ProtectionLevel> all = new System.Collections.Generic.HashSet<Net.TheVpc.Upa.ProtectionLevel>();
            Net.TheVpc.Upa.FwkConvertUtils.CollectionAddRange(all, new System.Collections.Generic.List<Net.TheVpc.Upa.ProtectionLevel>(accepted));
            return new Net.TheVpc.Upa.Filters.FieldProtectionLevelFilter(false, false, true, all, false);
        }

        public FieldProtectionLevelFilter(bool checkPersist, bool checkUpdate, bool checkSelect, System.Collections.Generic.ISet<Net.TheVpc.Upa.ProtectionLevel> accepted, bool dynamic) {
            this.checkPersist = checkPersist;
            this.checkUpdate = checkUpdate;
            this.checkSelect = checkSelect;
            this.dynamic = dynamic;
            this.accepted = new System.Collections.Generic.HashSet<Net.TheVpc.Upa.ProtectionLevel>();
            if (accepted != null) {
                Net.TheVpc.Upa.FwkConvertUtils.CollectionAddRange(this.accepted, accepted);
            }
        }


        public override bool AcceptDynamic() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return dynamic;
        }


        public override bool Accept(Net.TheVpc.Upa.Field f) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            if (checkPersist) {
                if (!accepted.Contains(f.GetPersistProtectionLevel())) {
                    return false;
                }
            }
            if (checkUpdate) {
                if (!accepted.Contains(f.GetUpdateProtectionLevel())) {
                    return false;
                }
            }
            if (checkSelect) {
                if (!accepted.Contains(f.GetReadProtectionLevel())) {
                    return false;
                }
            }
            return true;
        }


        public override string ToString() {
            System.Text.StringBuilder b = new System.Text.StringBuilder();
            if (checkPersist && checkUpdate && checkSelect) {
                b.Append("AnyProtectionLevel").Append(accepted);
            } else if (!checkPersist && !checkUpdate && !checkSelect) {
                b.Append("true");
            } else {
                if (checkSelect) {
                    b.Append("Persist");
                }
                if (checkUpdate) {
                    b.Append("Update");
                }
                if (checkSelect) {
                    b.Append("Find");
                }
                b.Append("ProtectionLevel").Append(accepted);
            }
            return b.ToString();
        }
    }
}
