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



namespace Net.Vpc.Upa.Filters
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public class FieldAccessLevelFilter : Net.Vpc.Upa.Filters.AbstractFieldFilter {

        private bool dynamic;

        private bool checkPersist;

        private bool checkUpdate;

        private bool checkSelect;

        private System.Collections.Generic.HashSet<Net.Vpc.Upa.AccessLevel> accepted;

        public static Net.Vpc.Upa.Filters.FieldAccessLevelFilter ForAll(params Net.Vpc.Upa.AccessLevel [] accepted) {
            System.Collections.Generic.HashSet<Net.Vpc.Upa.AccessLevel> all = new System.Collections.Generic.HashSet<Net.Vpc.Upa.AccessLevel>();
            Net.Vpc.Upa.FwkConvertUtils.CollectionAddRange(all, new System.Collections.Generic.List<Net.Vpc.Upa.AccessLevel>(accepted));
            return new Net.Vpc.Upa.Filters.FieldAccessLevelFilter(true, true, true, all, false);
        }

        public static Net.Vpc.Upa.Filters.FieldAccessLevelFilter ForInsert(params Net.Vpc.Upa.AccessLevel [] accepted) {
            System.Collections.Generic.HashSet<Net.Vpc.Upa.AccessLevel> all = new System.Collections.Generic.HashSet<Net.Vpc.Upa.AccessLevel>();
            Net.Vpc.Upa.FwkConvertUtils.CollectionAddRange(all, new System.Collections.Generic.List<Net.Vpc.Upa.AccessLevel>(accepted));
            return new Net.Vpc.Upa.Filters.FieldAccessLevelFilter(true, false, false, all, false);
        }

        public static Net.Vpc.Upa.Filters.FieldAccessLevelFilter ForUpdate(params Net.Vpc.Upa.AccessLevel [] accepted) {
            System.Collections.Generic.HashSet<Net.Vpc.Upa.AccessLevel> all = new System.Collections.Generic.HashSet<Net.Vpc.Upa.AccessLevel>();
            Net.Vpc.Upa.FwkConvertUtils.CollectionAddRange(all, new System.Collections.Generic.List<Net.Vpc.Upa.AccessLevel>(accepted));
            return new Net.Vpc.Upa.Filters.FieldAccessLevelFilter(false, true, false, all, false);
        }

        public static Net.Vpc.Upa.Filters.FieldAccessLevelFilter ForSelect(params Net.Vpc.Upa.AccessLevel [] accepted) {
            System.Collections.Generic.HashSet<Net.Vpc.Upa.AccessLevel> all = new System.Collections.Generic.HashSet<Net.Vpc.Upa.AccessLevel>();
            Net.Vpc.Upa.FwkConvertUtils.CollectionAddRange(all, new System.Collections.Generic.List<Net.Vpc.Upa.AccessLevel>(accepted));
            return new Net.Vpc.Upa.Filters.FieldAccessLevelFilter(false, false, true, all, false);
        }

        public FieldAccessLevelFilter(bool checkPersist, bool checkUpdate, bool checkSelect, System.Collections.Generic.ISet<Net.Vpc.Upa.AccessLevel> accepted, bool dynamic) {
            this.checkPersist = checkPersist;
            this.checkUpdate = checkUpdate;
            this.checkSelect = checkSelect;
            this.dynamic = dynamic;
            this.accepted = new System.Collections.Generic.HashSet<Net.Vpc.Upa.AccessLevel>();
            if (accepted != null) {
                Net.Vpc.Upa.FwkConvertUtils.CollectionAddRange(this.accepted, accepted);
            }
        }


        public override bool AcceptDynamic() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return dynamic;
        }


        public override bool Accept(Net.Vpc.Upa.Field f) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (checkPersist) {
                if (!accepted.Contains(f.GetInsertAccessLevel())) {
                    return false;
                }
            }
            if (checkUpdate) {
                if (!accepted.Contains(f.GetUpdateAccessLevel())) {
                    return false;
                }
            }
            if (checkSelect) {
                if (!accepted.Contains(f.GetSelectAccessLevel())) {
                    return false;
                }
            }
            return true;
        }


        public override string ToString() {
            System.Text.StringBuilder b = new System.Text.StringBuilder();
            if (checkPersist && checkUpdate && checkSelect) {
                b.Append("AnyAccessLevel").Append(accepted);
            } else if (!checkPersist && !checkUpdate && !checkSelect) {
                b.Append("true");
            } else {
                if (checkSelect) {
                    b.Append("Insert");
                }
                if (checkUpdate) {
                    b.Append("Update");
                }
                if (checkSelect) {
                    b.Append("Select");
                }
                b.Append("AccessLevel").Append(accepted);
            }
            return b.ToString();
        }
    }
}
