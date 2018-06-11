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



namespace Net.Vpc.Upa.Filters
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public class FieldProtectionLevelFilter : Net.Vpc.Upa.Filters.AbstractFieldFilter {

        private bool dynamic;

        private bool checkPersist;

        private bool checkUpdate;

        private bool checkSelect;

        private System.Collections.Generic.HashSet<Net.Vpc.Upa.ProtectionLevel> accepted;

        public static Net.Vpc.Upa.Filters.FieldProtectionLevelFilter ForAll(params Net.Vpc.Upa.ProtectionLevel [] accepted) {
            System.Collections.Generic.HashSet<Net.Vpc.Upa.ProtectionLevel> all = new System.Collections.Generic.HashSet<Net.Vpc.Upa.ProtectionLevel>();
            Net.Vpc.Upa.FwkConvertUtils.CollectionAddRange(all, new System.Collections.Generic.List<Net.Vpc.Upa.ProtectionLevel>(accepted));
            return new Net.Vpc.Upa.Filters.FieldProtectionLevelFilter(true, true, true, all, false);
        }

        public static Net.Vpc.Upa.Filters.FieldProtectionLevelFilter ForPersist(params Net.Vpc.Upa.ProtectionLevel [] accepted) {
            System.Collections.Generic.HashSet<Net.Vpc.Upa.ProtectionLevel> all = new System.Collections.Generic.HashSet<Net.Vpc.Upa.ProtectionLevel>();
            Net.Vpc.Upa.FwkConvertUtils.CollectionAddRange(all, new System.Collections.Generic.List<Net.Vpc.Upa.ProtectionLevel>(accepted));
            return new Net.Vpc.Upa.Filters.FieldProtectionLevelFilter(true, false, false, all, false);
        }

        public static Net.Vpc.Upa.Filters.FieldProtectionLevelFilter ForUpdate(params Net.Vpc.Upa.ProtectionLevel [] accepted) {
            System.Collections.Generic.HashSet<Net.Vpc.Upa.ProtectionLevel> all = new System.Collections.Generic.HashSet<Net.Vpc.Upa.ProtectionLevel>();
            Net.Vpc.Upa.FwkConvertUtils.CollectionAddRange(all, new System.Collections.Generic.List<Net.Vpc.Upa.ProtectionLevel>(accepted));
            return new Net.Vpc.Upa.Filters.FieldProtectionLevelFilter(false, true, false, all, false);
        }

        public static Net.Vpc.Upa.Filters.FieldProtectionLevelFilter ForFind(params Net.Vpc.Upa.ProtectionLevel [] accepted) {
            System.Collections.Generic.HashSet<Net.Vpc.Upa.ProtectionLevel> all = new System.Collections.Generic.HashSet<Net.Vpc.Upa.ProtectionLevel>();
            Net.Vpc.Upa.FwkConvertUtils.CollectionAddRange(all, new System.Collections.Generic.List<Net.Vpc.Upa.ProtectionLevel>(accepted));
            return new Net.Vpc.Upa.Filters.FieldProtectionLevelFilter(false, false, true, all, false);
        }

        public FieldProtectionLevelFilter(bool checkPersist, bool checkUpdate, bool checkSelect, System.Collections.Generic.ISet<Net.Vpc.Upa.ProtectionLevel> accepted, bool dynamic) {
            this.checkPersist = checkPersist;
            this.checkUpdate = checkUpdate;
            this.checkSelect = checkSelect;
            this.dynamic = dynamic;
            this.accepted = new System.Collections.Generic.HashSet<Net.Vpc.Upa.ProtectionLevel>();
            if (accepted != null) {
                Net.Vpc.Upa.FwkConvertUtils.CollectionAddRange(this.accepted, accepted);
            }
        }


        public override bool AcceptDynamic() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return dynamic;
        }


        public override bool Accept(Net.Vpc.Upa.Field f) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
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
