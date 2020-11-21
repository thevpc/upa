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



using System.Linq;
namespace Net.TheVpc.Upa.Filters
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public class FieldAndFilter : Net.TheVpc.Upa.Filters.AbstractFieldFilter {

        private Net.TheVpc.Upa.Filters.FieldFilter[] v = new Net.TheVpc.Upa.Filters.FieldFilter[0];

        public FieldAndFilter(params Net.TheVpc.Upa.Filters.FieldFilter [] filters)  : this(new System.Collections.Generic.List<Net.TheVpc.Upa.Filters.FieldFilter>(filters)){

        }

        public FieldAndFilter(System.Collections.Generic.IList<Net.TheVpc.Upa.Filters.FieldFilter> filters) {
            System.Collections.Generic.List<Net.TheVpc.Upa.Filters.FieldFilter> all = new System.Collections.Generic.List<Net.TheVpc.Upa.Filters.FieldFilter>((filters).Count);
            foreach (Net.TheVpc.Upa.Filters.FieldFilter a in filters) {
                if (a != null) {
                    all.Add(a);
                }
            }
            v = all.ToArray();
        }

        public virtual System.Collections.Generic.IList<Net.TheVpc.Upa.Filters.FieldFilter> GetChildren() {
            return new System.Collections.Generic.List<Net.TheVpc.Upa.Filters.FieldFilter>(v);
        }

        public static Net.TheVpc.Upa.Filters.FieldAndFilter And(params Net.TheVpc.Upa.Filters.FieldFilter [] filters) {
            System.Collections.Generic.List<Net.TheVpc.Upa.Filters.FieldFilter> all = new System.Collections.Generic.List<Net.TheVpc.Upa.Filters.FieldFilter>(filters.Length);
            foreach (Net.TheVpc.Upa.Filters.FieldFilter filter in filters) {
                if (filter != null) {
                    if (filter is Net.TheVpc.Upa.Filters.FieldAndFilter) {
                        Net.TheVpc.Upa.FwkConvertUtils.CollectionAddRange(all, ((Net.TheVpc.Upa.Filters.FieldAndFilter) filter).GetChildren());
                    } else {
                        all.Add(filter);
                    }
                }
            }
            return new Net.TheVpc.Upa.Filters.FieldAndFilter(all);
        }

        public override Net.TheVpc.Upa.Filters.RichFieldFilter And(Net.TheVpc.Upa.Filters.FieldFilter filter) {
            if (filter != null) {
                if (filter is Net.TheVpc.Upa.Filters.FieldAndFilter) {
                    System.Collections.Generic.IList<Net.TheVpc.Upa.Filters.FieldFilter> children = ((Net.TheVpc.Upa.Filters.FieldAndFilter) filter).GetChildren();
                    System.Collections.Generic.List<Net.TheVpc.Upa.Filters.FieldFilter> all = new System.Collections.Generic.List<Net.TheVpc.Upa.Filters.FieldFilter>(v.Length + (children).Count);
                    Net.TheVpc.Upa.FwkConvertUtils.CollectionAddRange(all, new System.Collections.Generic.List<Net.TheVpc.Upa.Filters.FieldFilter>(v));
                    Net.TheVpc.Upa.FwkConvertUtils.CollectionAddRange(all, children);
                    return new Net.TheVpc.Upa.Filters.FieldAndFilter(all);
                } else {
                    System.Collections.Generic.List<Net.TheVpc.Upa.Filters.FieldFilter> all = new System.Collections.Generic.List<Net.TheVpc.Upa.Filters.FieldFilter>(v.Length + 1);
                    Net.TheVpc.Upa.FwkConvertUtils.CollectionAddRange(all, new System.Collections.Generic.List<Net.TheVpc.Upa.Filters.FieldFilter>(v));
                    all.Add(filter);
                    return new Net.TheVpc.Upa.Filters.FieldAndFilter(all);
                }
            } else {
                return this;
            }
        }

        public override bool Accept(Net.TheVpc.Upa.Field field) {
            foreach (Net.TheVpc.Upa.Filters.FieldFilter fieldFilter in v) {
                if (!fieldFilter.Accept(field)) {
                    return false;
                }
            }
            return v.Length > 0;
        }


        public override bool AcceptDynamic() {
            foreach (Net.TheVpc.Upa.Filters.FieldFilter fieldFilter in v) {
                if (!fieldFilter.AcceptDynamic()) {
                    return false;
                }
            }
            return true;
        }


        public override string ToString() {
            if (v.Length == 0) {
                return "false";
            } else if (v.Length == 1) {
                return v[0].ToString();
            } else {
                System.Text.StringBuilder b = new System.Text.StringBuilder("(");
                b.Append(v[0]);
                for (int i = 1; i < v.Length; i++) {
                    b.Append(" and ");
                    b.Append(v[i].ToString());
                }
                b.Append(")");
                return b.ToString();
            }
        }


        public override int GetHashCode() {
            int hash = 3;
            hash = 29 * hash;
            foreach (Net.TheVpc.Upa.Filters.FieldFilter v1 in this.v) {
                hash = 29 * hash + v1.GetHashCode();
            }
            return hash;
        }


        public override bool Equals(object obj) {
            if (obj == null) {
                return false;
            }
            if (GetType() != obj.GetType()) {
                return false;
            }
            Net.TheVpc.Upa.Filters.FieldAndFilter other = (Net.TheVpc.Upa.Filters.FieldAndFilter) obj;
            if (this.v == other.v) return true;
            if (this.v == null || other.v == null) return false;
            int length = this.v.Length;
            if (other.v.Length != length) return false;
            for (int i = 0; i < length; i++) {
                object e1 = this.v[i];
                object e2 = other.v[i];
                if (e1 == e2) {
                    continue;
                }
                if (e1 == null) {
                    return false;
                }
                // Figure out whether the two elements are equal
                bool eq = e1.Equals(e2);
                if (!eq) {
                    return false;
                }
            }
            return true;
        }
    }
}
